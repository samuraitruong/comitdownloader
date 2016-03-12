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
        private static string rootFolder = @"D:\Data1\uptruyen.com\";
        public static List<StoryInfo> stories;
        private static bool dataCached = false;
        public static Dictionary<string, GenreInfo> genres = new Dictionary<string, GenreInfo>();
        public static void EnsureDBCache()
        {
            if (dataCached) return;
            
            var all = AllStories(true);
            Parallel.ForEach(all, (s) =>
            {
                lock (genres)
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
            });
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
                                var fullStory = JsonConvert.DeserializeObject<StoryInfo>(File.ReadAllText(storyFile));
                                stories.Add(fullStory);
                            }

                        });

                        stories.Sort((x, y) =>
                        {
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
