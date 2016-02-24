using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("hixx.info", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class HixxInfoDownloader : Downloader
    {
        public override bool IsTextEngine
        {
            get
            {
                return true;
            }
        }
        public override string Name
        {
            get { return "[hixx.info] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyen.hixx.info/truyen.html"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.hixx.info/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://truyen.hixx.info/assets/truyen/images/no_image_found_120x180.jpg";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://truyenfull.vn/danh-sach/truyen-hot/trang-{0}/"
                , "//span[@class='title_story']//a");
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesUnknowPages("http://truyen2.hixx.info/truyen",
                "//ul[@class='content']/li/a[2]", forceOnline,
                "//div[@class='bt_pagination']//a");
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyen2.hixx.info/truyen/search/index/q/"+ keyword, "//ul[@class='homeListstory']//h3/a", 1);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@class='danh_sach']/a",
                chapterExtract: (HtmlNode node)=> {
                    var aaa= new ChapterInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.InnerText.Replace("Đọc truyện Online - ","").Trim()
                    };
                    aaa.Name = Regex.Replace(aaa.Name,"<!.*-->", "").Trim();
                    return aaa;
                },
                chapPagingPattern: "//div[@class='bt_pagination']//a");
        }

        public override List<string> GetPages(string chapUrl)
        {
            return new List<string>() { chapUrl };
        }
        //public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chappter = null)
        //{
        //    cc = NetworkHelper.GetCookie(pageUrl, httpReferer);
        //    var html = NetworkHelper.GetHtml(pageUrl, cc);
        //    var match = Regex.Match(html, "load\\(\\\"([^\\\"]*)\\\"\\)");
        //    var ajaxUrl = this.HostUrl + match.Groups[1].Value;
        //    return base.DownloadPage(ajaxUrl, renamePattern, folder, httpReferer, cc, pageUrl, chapter:chappter);
        //}
        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://goctruyen.com/truyen-moi-dang/{0}/";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//ul[@class='homeListstory']//h3/a", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//*[@id='ar-content-html']", "//h3");

            
        }
        //Use google search 
    }
}
