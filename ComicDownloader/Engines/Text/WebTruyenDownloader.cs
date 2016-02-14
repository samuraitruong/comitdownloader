using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("webtruyen.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class WebTruyenDownloader : Downloader
    {
        public override string Name
        {
            get { return "[webtruyen.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://webtruyen.com/all/"; }
        }

        public override string HostUrl
        {
            get { return "http://webtruyen.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://webtruyen.com/frontend/image/logo.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://webtruyen.com/truyen-duoc-xem-nhieu-nhat/{0}/"
                , "//li/h3/a", 3);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://webtruyen.com/home/pagingtabmain/0/{0}";

            return base.GetListStoriesSimple(urlPattern,
                "//li/h3/a", forceOnline);
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://webtruyen.com/searching/" + keyword  +"/{0}" , "//li/h3/a", 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1[@class='title']",
                "//div[@class='ullistchap']/ul/li", chapterExtract: (HtmlNode node) =>
                {
                    var first = node.SelectSingleNode("span[@class='spanstt']");
                    var span = node.SelectSingleNode("span[@class='spanchapter']");
                    var a = node.SelectSingleNode("span/a");//.Attributes["href"].Value
                    ChapterInfo info = new ChapterInfo();
                    info.Url = a.Attributes["href"].Value;
                    info.Name = span.InnerText.Trim() + " - " + a.Attributes["title"].Value;
                    return info;
                },

                chapPagingPattern: "//div[contains(@class,'pagination')]//a");
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
            string lastestUpdateUrl = "http://webtruyen.com/truyen-moi-dang/{0}/";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//li/h3/a", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//*[@id='detailcontent']", "//h1");

            
        }
        //Use google search 
    }
}
