using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("SSTruyen.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class SSTruyenDownloader : Downloader
    {
        public override string Name
        {
            get { return "[sstruyen.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://sstruyen.com/doc-truyen/"; }
        }

        public override string HostUrl
        {
            get { return "http://sstruyen.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories()
        {
            return HotestStoriesSimple("http://sstruyen.com/doc-truyen/index.php?search=&cate=&order=2&page={0}"
                , "//*[@class='listTitle']/a", 1);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://sstruyen.com/doc-truyen/truyen-moi-nhat/page-{0}.html";

            return base.GetListStoriesSimple(urlPattern,
                "//*[@class='listTitle']/a", forceOnline);
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://sstruyen.com/doc-truyen/index.php?page={0}&search=" + keyword, "//*[@class='listTitle']/a", 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1[@class='title']",
                "//div[@class='chuongmoi']//a",
                chapPagingPattern: "//div[@class='page-split']/a");

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
            string lastestUpdateUrl = "http://sstruyen.com/doc-truyen/index.php?search=&cate=&order=8&page={0}";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//*[@class='listTitle']/a", "", null, 3);
        }

        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            //replace content 
            base.AfterPageDownloaded(filename, chap);

            var fileContent = File.ReadAllText(filename);
            fileContent = fileContent.Replace("<p></p>", "<br/><br/>");
            fileContent = fileContent.Replace("</div></div>", "</div>");
            File.WriteAllText(filename, fileContent);
        }
        //Use google search 
    }
}
