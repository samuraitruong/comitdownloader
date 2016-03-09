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
        public static List<StoryInfo> AllStories(bool fullLoad = false)
        {
            if(stories == null || stories.Count ==0)
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
}
