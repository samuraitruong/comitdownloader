#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ComicDownloader.Engines
{
    [Downloader("Vechai.info", MenuGroup = "U-Z", Offline = false, MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
    public class VechaiDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://cdn.vechai.info/images/logo.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://vechai.info/danh-sach.tmoinhat.html"; }
        }

        public override string HostUrl
        {
            get { return "http://vechai.info"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            string urlPattern = "http://vechai.info/danh-sach.tmoinhat.p{0}.json";
            return base.GetListStoriesSimple(urlPattern, "//ul[@id='comic-list']/li/a[1]", forceOnline);
        }

        public override StoryInfo RequestInfo(string url)
        {
            return base.RequestInfoSimple(url,
                "//h2[contains(@class,'TitleH2')]",
                "//ul[@id='acc1']//li/a");
        }

        public override string Name
        {
            get { return "[Ve Chai] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//div[@id='contentChapter']//img");
        }

        //Lastest Update chi show story, thong co link chapter moi nhat

        //Use google search
    }
}
