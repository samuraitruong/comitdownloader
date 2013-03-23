using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public abstract class Downloader
    {
        public List<StoryInfo> AllStories { get; set; }
        public abstract string Name { get; }
        public abstract  string ListStoryURL { get;  }
        public abstract string HostUrl { get; }
        public abstract string StoryUrlPattern { get; }

        public abstract List<StoryInfo> GetListStories();
        public abstract StoryInfo RequestInfo(string storyUrl);

        public abstract List<string> GetPages(string chapUrl);
        public int ExtractID(string name)
        {
            var match = Regex.Match(name, @".*\s(\d*)$");
            if (match != null)
            {
                int id = 0;
                int.TryParse(match.Groups[1].Value, out id);
                return id;
            }
            return 0;

        }
    }
}
