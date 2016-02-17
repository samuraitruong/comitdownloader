using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("truyen368.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class Truyen368Downloader : Downloader
    {
        public override string Name
        {
            get { return "[truyen368.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyen368.com/truyen-dang-update"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen368.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://truyen368.com/theme/img/logo.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple(this.HostUrl
                , "//div[@class='box-shadow-preview']//h3/a", 1);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://truyen368.com/truyen-dang-update/trang-{0}.html",
                "//*[@id='comic_full']//td[1]/a[2]", forceOnline);
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyen368.com/tim-kiem/"+ keyword + "/trang-{0}.html", "//td[@class='td_1']/a", 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//*[@id='list_all_chap']//a", chapterExtract: (HtmlNode node)=> {
                    return new ChapterInfo()
                    {
                        Name = node.InnerText.Trim(),
                        Url = base.EnsureHostName(this.HostUrl, node.Href())
                    };
                });
        }
        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chapter = null)
        {
            var match = Regex.Match(pageUrl, @"(\d*).html$");

            string file = chapter.Name + ".html";
            string html = NetworkHelper.PostHtml("http://truyen368.com/process/chap.php", pageUrl, "id="+ match.Groups[1].Value);
            Directory.CreateDirectory(folder.ToValidFileName());
            file = file.Replace(chapter.ChapId.ToString(), chapter.ChapId.ToString("D3"));
            var filename = Path.Combine(folder, file.ToValidFileName());
            File.WriteAllText(filename, html);
            this.AfterPageDownloaded(filename, chapter);
            return filename;

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
            
            AfterPageDownloadedSimple(filename, chap.Name, "", "//h1");

            
        }
        //Use google search 
    }
}
