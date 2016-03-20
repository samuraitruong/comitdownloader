using ComicWeb.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ComicWeb.JsonService
{
    public class DataManager
    {
        private static string rootFolder = @"D:\Data1\truyentranh8.net\";
        public static List<StoryInfo> stories;
        private static bool dataCached = false;
        public static Dictionary<string, GenreInfo> genres = new Dictionary<string, GenreInfo>();
        public static object threadLocker = new object();
        public static void EnsureDBCache()
        {
            if (dataCached) return;
            
            lock(threadLocker)
            {
                var all = AllStories(true);
                Parallel.ForEach(all, (s) =>
                {
                    lock (genres)
                    {
                        if (s.Categories != null)
                        {
                            foreach (var cat in s.Categories)
                            {
                                if (!genres.ContainsKey(cat))
                                {
                                    var key = new GenreInfo()
                                    {
                                        Name = cat,
                                        Stories = new List<IStoryInfo>(),
                                        StoriesCount = 0
                                    };
                                    genres[cat] = key;
                                }

                                var current = genres[cat];
                                current.Stories.Add(s);
                                current.StoriesCount++;
                                genres[cat] = current;
                            }
                        }
                    }
                });
            }
            dataCached = true;
        }
        public static StoryInfo LoadStory(string filename)
        {
            var storyFile = Path.Combine(rootFolder, filename);
            if (File.Exists(storyFile))
            {
                var fullStory = JsonConvert.DeserializeObject<StoryInfo>(File.ReadAllText(storyFile));
                return fullStory;
            }
            return null;
        }
        private static object lk = new object();
        public static List<GenreInfo> AllGenres(bool includeStories)
        {
            EnsureDBCache();
            List<GenreInfo> results = new List<GenreInfo>();
            foreach (var item in genres.Keys)
            {
                if (genres[item].StoriesCount <10)
                {
                    continue;
                }
                results.Add(includeStories?genres[item] : new GenreInfo() {  Name= genres[item].Name, StoriesCount = genres[item].StoriesCount});
            }
            return results;
        }
        public static List<StoryInfo> AllStories(bool fullLoad = false)
        {
            lock (lk)
            {
                if (stories == null || stories.Count == 0)
                {
                    stories = new List<StoryInfo>();
                    string file = Path.Combine(rootFolder, "stories.json");
                    var temp = JsonConvert.DeserializeObject<List<StoryInfo>>(File.ReadAllText(file));
                    if (fullLoad)
                    {
                        Parallel.ForEach(temp, (s) =>
                        {
                            var storyFile = Path.Combine(rootFolder, s.JsonFileName);
                            if (File.Exists(storyFile))
                            {
                                try
                                {
                                    var fullStory = JsonConvert.DeserializeObject<StoryInfo>(File.ReadAllText(storyFile));
                                    if (fullStory != null)
                                    {
                                        stories.Add(fullStory);
                                    }
                                    else
                                    {
                                        stories.Add(s);
                                    }
                                }
                                catch (Exception ex) { }
                            }

                        });

                        stories.Sort((x, y) =>
                        {

                            if (x== null || y == null || x.Chapters == null || y.Chapters == null) return 0;
                            return y.Chapters.Count - x.Chapters.Count;
                        });
                    }
                    else
                    {
                        stories = temp;
                    }
                }
                return stories;
            }
        }

        internal static void Update(StoryInfo story)
        {
            var fileName = Path.Combine(rootFolder, story.JsonFileName);

            var index = stories.FindIndex(p => p.Name == story.Name);
            var oginalStory = LoadStory(story.JsonFileName);
            oginalStory.ViewCounts = story.ViewCounts;
            oginalStory.RatingUsers = story.RatingUsers;
            oginalStory.Rating = story.Rating;
           stories[index] = oginalStory;
            File.WriteAllText(fileName,JsonConvert.SerializeObject(oginalStory));
        }

        public static ChapterInfo LoadChapter(string filename)
        {
            var storyFile = Path.Combine(rootFolder, filename);
            if (File.Exists(storyFile))
            {
                var fullChapInfo = JsonConvert.DeserializeObject<ChapterInfo>(File.ReadAllText(storyFile));
                return fullChapInfo;
            }
            return null;

        }

        internal static List<IStoryInfo> GenreStories(string name)
        {
            if(!genres.ContainsKey(name))
            {
                var stories = new List<IStoryInfo>();
                Parallel.ForEach(AllStories(true), (s) =>
                {
                    if(s.Categories.Any(p=>p.ToLower() == name.ToLower())) {
                        stories.Add(s);
                    }
                });
                var info = new GenreInfo()
                {
                    Name = name,
                    Stories = stories,
                    StoriesCount = stories.Count
                };

                genres.Add(name, info);
            }

            return genres[name].Stories;
        }
    }
}
