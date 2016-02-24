using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("thichdoctruyen.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class ThichDocTruyenDownloader : Downloader
    {
        public override bool IsTextEngine
        {
            get { return true; }
        }
        public override string Name
        {
            get { return "[thichdoctruyen.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://thichdoctruyen.com/all/"; }
        }

        public override string HostUrl
        {
            get { return "http://thichdoctruyen.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://thichdoctruyen.com/images/logo_d.png";//"http://thichdoctruyen.com/images/logov2.gif";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://thichdoctruyen.com/the-loai/truyen-hot/page{0}"
                , "//div[@class='wapcat']/table//tr/td[2]/a", 3);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://thichdoctruyen.com/the-loai/truyen-moi/page{0}";

            return base.GetListStoriesSimple(urlPattern,
                "//div[@class='wapcat']/table//tr/td[2]/a", forceOnline);
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://thichdoctruyen.com/tim-truyen/search.php?page={0}&keysearch="+keyword, "//div[@class='wapcat']/table//tr/td[2]/a", 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@class='wapcat']/table//tr[position()<last()]//a", 
                chapterExtract: (HtmlNode node)=> {
                    var aaa=  new ChapterInfo()
                    {
                        Name = node.ParentNode.PreviousSibling.PreviousSibling.InnerText.Trim() + "-" +node.ParentNode.InnerText.Trim(),
                        Url = EnsureHostName(this.HostUrl, node.Attributes["href"].Value.Trim()),
                    };
                    return aaa;
                },
                chapPagingPattern: "//*[@class='pagenav']/a");
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
            string lastestUpdateUrl = "http://thichdoctruyen.com/the-loai/truyen-moi/page{0}";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//div[@class='wapcat']/table//tr/td[2]/a", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//*[@class='boxview']", "//p[@class='tenchuong']");

            
        }
        //Use google search 
    }
}
