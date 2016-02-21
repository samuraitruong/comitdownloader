using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("truyenfull.vn", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TruyenFullDownloader : Downloader
    {
        public override string Name
        {
            get { return "[truyenfull.vn] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyenfull.vn/danh-sach/truyen-moi"; }
        }

        public override string HostUrl
        {
            get { return "http://truyenfull.vn/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://static.truyenfull.vn/img/spriteimg_newyear_op.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://truyenfull.vn/danh-sach/truyen-hot/trang-{0}/"
                , "//h3[@class='truyen-title']/a", 3);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesUnknowPages(this.ListStoryURL,
                "//h3[@class='truyen-title']/a", forceOnline,

                "//ul[@class='pagination pagination-sm']//a");
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyenfull.vn/tim-kiem/?page={0}&tukhoa=" + keyword, "//h3[@class='truyen-title']/a", 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//ul[@class='list-chapter']//a",
                chapPagingPattern: "//ul[@class='pagination pagination-sm']//a",
                coverPattern: "//div[@class='book']/img",
                authorPattern: "//div[@class='info']//a[@itemprop='author']",
                categoryPattern: "//div[@class='info']//a[@itemprop='genre']",
                summaryPattern: "//div[@itemprop='about']"
                );
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
            string lastestUpdateUrl = "http://truyenfull.vn/danh-sach/truyen-moi/trang-{0}/";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//h3[@class='truyen-title']/a", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//*[@class='chapter-content']", "//a[@class='chapter-title']");

            
        }
        //Use google search 
    }
}
