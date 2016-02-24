using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("truyenngontinh.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TruyenNgonTinhAZDownloader : Downloader
    {
        public override string Name
        {
            get { return "[truyenngontinhaz.com] - "; }
        }
        public override bool IsTextEngine
        {
            get { return true; }
        }
        public override string ListStoryURL
        {
            get { return "http://truyenngontinhaz.com/muc-luc-truyen-ngon-tinh.html"; }
        }

        public override string HostUrl
        {
            get { return "http://truyenngontinhaz.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://truyenngontinhaz.com//logo.gif";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple(this.HostUrl
                , "//div[contains(@class,'tabs_wrap')]//li/a",1);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple(this.ListStoryURL,
                "//*[@class='listruyenngontinh']/li/a", forceOnline, singleListPage:true);
        }
        //public override List<StoryInfo> OnlineSearch(string keyword)
        //{
        //    return base.OnlineSearchGet("http://thichdoctruyen.com/tim-truyen/search.php?page={0}&keysearch="+keyword, "//div[@class='wapcat']/table//tr/td[2]/a", 3);
        //}

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@class='entry-content']/ul/li/a");
        }

        public override List<string> GetPages(string chapUrl)
        {
            return new List<string>() { chapUrl };
        }

        //public override List<StoryInfo> GetLastestUpdates()
        //{
        //    string lastestUpdateUrl = "http://truyenngontinhaz.com/the-loai/truyen-moi/page{0}";
        //    return base.GetLastestUpdateSimple(lastestUpdateUrl, "//div[@class='wapcat']/table//tr/td[2]/a", "", null, 3);
        //}
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            AfterPageDownloadedSimple(filename, chap.Name, "//div[@class='entry-content']/div[@class='nd']", "//h1");
        }
        //Use google search 
    }
}
