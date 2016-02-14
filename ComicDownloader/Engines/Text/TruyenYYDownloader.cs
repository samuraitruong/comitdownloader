using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("truyenyy.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TruyenYYDownloader : Downloader
    {
        public override string Name
        {
            get { return "[truyenyy.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyenyy.com/danhmuctruyen/?loai_truyen=all&the_loai=all&sap_xep=alphabet&page=1"; }
        }

        public override string HostUrl
        {
            get { return "http://truyenyy.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://truyenyy.com/static/img/truyenyy-logo.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://webtruyen.com/truyen-duoc-xem-nhieu-nhat/{0}/"
                , "//li/h3/a", 3);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://truyenyy.com/danhmuctruyen/?loai_truyen=all&the_loai=all&sap_xep=alphabet";

            return base.GetListStoriesUnknowPages(urlPattern,
                "//td[@class='nav-list name_list']/a", forceOnline,
                "//div[contains(@class,'pagination')]//a",
                (node) =>
                {   
                    return "http://truyenyy.com/danhmuctruyen/" + node.Attributes["href"].Value.Replace("&amp;","&");
                });
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://webtruyen.com/searching/" + keyword  +"/{0}" , "//li/h3/a", 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@id='dschuong']//a",
                chapPagingPattern: "//div[@class='pagination pagination-centered']//a",
                chapPagingNodeExtract: (HtmlNode node) => {
                    return storyUrl + node.Attributes["href"].Value;
                });
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
        public override int MaxRequestInfoChapterThread
        {
            get
            {
                return 1;
            }
        }
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//*[@id='id_noidung_chuong']", "//h1");

            
        }
        //Use google search 
    }
}
