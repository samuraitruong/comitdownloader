using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("tieuthuyethay.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TieuThuyetHayDownloader : Downloader
    {
        public override string Name
        {
            get { return "[thichtruyen.vn] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://tieuthuyethay.com/"; }
        }

        public override string HostUrl
        {
            get { return "http://tieuthuyethay.com/truyen-moi"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://tieuthuyethay.com/wp-content/themes/truyentt/images/logo-truyen-tieu-thuyet.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple(this.HostUrl
                , "//div[@id='left-story-read-more']//a[@class='view-item-story-title']", 1);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://tieuthuyethay.com/truyen-moi/page/{0}",
                "//div[@class='title']/a",
                forceOnline); 
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://thichtruyen.vn/site/search?key_word=" + keyword,
                "//div[contains(@class,'view-category-item-infor')]/a",
                1);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var info = base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@class='list-chap-wrap']//a");
            return info;
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
            string lastestUpdateUrl = "http://truyen368.com/truyen-dang-update/trang-{0}.html";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//*[@id='comic_full']//td[1]/a[2]", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//*[@class='article_content']", "//*[@id='ht_middle']/section/article/header/p/strong");

            
        }
        //Use google search 
    }
}
