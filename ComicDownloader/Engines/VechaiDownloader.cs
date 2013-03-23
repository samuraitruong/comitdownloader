using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicDownloader.Engines
{
    public class VechaiDownloader: Downloader
    {
        public override string ListStoryURL
        {
            get { throw new NotImplementedException(); }
        }

        public override string HostUrl
        {
            get { throw new NotImplementedException(); }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            throw new NotImplementedException();
        }

        public override StoryInfo RequestInfo(string urlSegment)
        {
            throw new NotImplementedException();
        }

        public override List<string> GetPages(string chapUrl)
        {
            throw new NotImplementedException();
        }
    }
}
