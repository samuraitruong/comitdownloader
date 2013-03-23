using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicDownloader.Engines
{
    public abstract class Downloader
    {
        public List<StoryInfo> AllStories { get; set; }

        public abstract  string ListStoryURL { get;  }
        public abstract string HostUrl { get; }
        public abstract string StoryUrlPattern { get; }

        public abstract List<StoryInfo> GetListStories();
        public abstract StoryInfo RequestInfo(string urlSegment);

        public abstract List<string> GetPages(string chapUrl);
    }
}
