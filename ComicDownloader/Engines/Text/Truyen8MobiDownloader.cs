using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("truyencuatui.net", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class Truyen8MobiDownloader : Downloader
    {
        public override string Name
        {
            get { return "[truyencuatui.net] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyencuatui.net/truyen-moi.html"; }
        }

        public override string HostUrl
        {
            get { return "http://truyencuatui.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://cdn.clickzoom.net/truyencuatui/images/truyen-cua-tui-logo.png";
            }
        }
        public override List<StoryInfo> HotestStories()
        {
            return HotestStoriesSimple("http://truyenfull.vn/danh-sach/truyen-hot/trang-{0}/"
                , "//span[@class='title_story']//a");
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //List<string> startUrls = new List<string>()
            //{
            //    "http://www.doctruyen360.com/danh-sach-truyen-dai-tap-truyen-tieu-thuyet-tinh-cam/",
            //    "http://www.doctruyen360.com/danh-sach-truyen-ngan-hay-truyen-ngan-tinh-yeu/",
            //    "http://www.doctruyen360.com/danh-sach-truyen-ngon-tinh-tieu-thuyet-trung-hoa-trung-quoc/",
            //    "http://www.doctruyen360.com/truyen-cuoi-vova/",
            //    "http://www.doctruyen360.com/truyen-cuoi-ngan-truyen-cuoi-cuc-hay/",
            //    "http://www.doctruyen360.com/tam-su/    "

            //};
            return base.GetListStoriesUnknowPages(this.ListStoryURL,
                "//div[@class='truyen-inner']/a[1]", forceOnline,
                "//ul[@class='pagination']//a",convertFunc: (HtmlNode node) => {
                    return new StoryInfo()
                    {
                        Name = HttpUtility.HtmlDecode(node.InnerText.Trim()),
                        Url = base.EnsureHostName(this.HostUrl, node.Href())
                    };
            });
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyen2.hixx.info/truyen/search/index/q/" + keyword, "//ul[@class='homeListstory']//h3/a", 1);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@id='danh-sach-chuong']//a[contains(@class,'chuong-item')]",
                chapPagingPattern: "//ul[@class='pagination']//a");
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

            AfterPageDownloadedSimple(filename, chap.Name, "//div[@itemprop='articleBody']", "//h1");


        }
        //Use google search 
    }
}
