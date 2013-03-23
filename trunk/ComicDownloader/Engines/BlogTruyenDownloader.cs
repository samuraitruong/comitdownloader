using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicDownloader.Engines
{
    public class BlogTruyenDownloader: Downloader
    {
        public override string Name
        {
            get { return "[BlogTruyen] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://danhmuc.blogtruyen.com/2009/11/danh-sach-tong-hop.html"; }
        }

        public override string HostUrl
        {
            get { return "http://home.blogtruyen.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            throw new NotImplementedException();
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            throw new NotImplementedException();
        }

        public override List<string> GetPages(string chapUrl)
        {
            throw new NotImplementedException();
        }
    }
}
