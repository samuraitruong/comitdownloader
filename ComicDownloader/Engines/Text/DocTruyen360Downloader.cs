using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("doctruyen360.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class DocTruyen360Downloader : Downloader
    {
        public override string Name
        {
            get { return "[doctruyen360.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.doctruyen360.com/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.doctruyen360.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://www.doctruyen360.com/wp-content/themes/doctruyen/images/logo.png";
            }
        }
        public override List<StoryInfo> HotestStories()
        {
            return HotestStoriesSimple("http://truyenfull.vn/danh-sach/truyen-hot/trang-{0}/"
                , "//span[@class='title_story']//a");
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            List<string> startUrls = new List<string>()
            {
                "http://www.doctruyen360.com/danh-sach-truyen-dai-tap-truyen-tieu-thuyet-tinh-cam/",
                "http://www.doctruyen360.com/danh-sach-truyen-ngan-hay-truyen-ngan-tinh-yeu/",
                "http://www.doctruyen360.com/danh-sach-truyen-ngon-tinh-tieu-thuyet-trung-hoa-trung-quoc/",
                "http://www.doctruyen360.com/truyen-cuoi-vova/",
                "http://www.doctruyen360.com/truyen-cuoi-ngan-truyen-cuoi-cuc-hay/",
                "http://www.doctruyen360.com/tam-su/    "

            };
            return base.GetListStoriesUnknowPages(string.Join(";", startUrls.ToArray()),
                "//div[@class='entry']//a;//h2/a", forceOnline,
                "//div[@class='wp-pagenavi']//a");
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyen2.hixx.info/truyen/search/index/q/" + keyword, "//ul[@class='homeListstory']//h3/a", 1);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//p/strong;//h1",
                "//div[@class='entry']//ul/li/a",
                customChapterExtract: (string html, HtmlDocument document) =>
                {
                    List<ChapterInfo> chapters = new List<ChapterInfo>();
                    var name = document.DocumentNode.GetSingleNode("//p/strong;//h1");
                    chapters.Add(new ChapterInfo()
                    {
                        Name = name.InnerText.Trim(),
                        Url = storyUrl
                    });
                    //string pattern = "//div[@class='entry']//ul/li/a";
                    //var nodes = document.DocumentNode.SelectNodes(pattern);
                    //if(nodes!= null && nodes.Count > 0)
                    //{
                    //    nodes.Cast
                    //}

                    return chapters;
                }
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
            string lastestUpdateUrl = "http://goctruyen.com/truyen-moi-dang/{0}/";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//ul[@class='homeListstory']//h3/a", "", null, 3);
        }

        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {

            AfterPageDownloadedSimple(filename, chap.Name, "//div[@class='dtct1072']", "//h1");


        }
        //Use google search 
    }
}
