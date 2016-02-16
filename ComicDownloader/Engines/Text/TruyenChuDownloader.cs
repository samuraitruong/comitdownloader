using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("truyenchu.net", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TruyenChuDownloader : Downloader
    {
        public override string Name
        {
            get { return "[truyenchu.net] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyenchu.net/danh-sach-truyen/tat-ca"; }
        }

        public override string HostUrl
        {
            get { return "http://truyenchu.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://goctruyen.com/public/frontend/img/logo.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://truyenfull.vn/danh-sach/truyen-hot/trang-{0}/"
                , "//h3[@class='truyen-title']/a", 3);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://truyenchu.net/danh-sach-truyen/tat-ca?page={0}",
                "//a[@class='text-bold']", forceOnline);
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://goctruyen.com/search/"+keyword+"/{0}/", "//ul[@class='homeListstory']//h3/a", 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[contains(@class,'lst-chapter')]//a",
                chapterExtract: (HtmlNode node)=> {
                    return new ChapterInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.PreviousSibling.InnerText.Trim() +" - " + node.InnerText.Trim()
                    };
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
            string lastestUpdateUrl = "http://goctruyen.com/truyen-moi-dang/{0}/";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//ul[@class='homeListstory']//h3/a", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//div[contains(@class,'set-textresize')]", "//h1");

            
        }
        //Use google search 
    }
}
