using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("thuquantruyen.com.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class ThuQuanTruyenDownloader : Downloader
    {
        public override string Name
        {
            get { return "[thuquantruyen.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://santruyen.com"; }
        }

        public override string HostUrl
        {
            get { return "http://thuquantruyen.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://thuquantruyen.com/truyen-doc-hay"
                , "//li/section/a", 1,(HtmlNode n)=>
                {
                    return new StoryInfo()
                    {
                        Name = n.SelectSingleNode("img").Attr("alt"),
                        Url = base.EnsureHostName(this.HostUrl, n.Href())
                    };
                });
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://thuquantruyen.com/truyen-online-moi-trang-{0}",
                "//li/section/a",
                forceOnline,
                convertFunc: (HtmlNode n) => {
                    return new StoryInfo()
                    {
                        Name = n.SelectSingleNode("img").Attr("alt"),
                        Url = base.EnsureHostName(this.HostUrl, n.Href())
                    };
            });
        }
        private StoryInfo CustomExtractor(HtmlNode n)
        {
            return new StoryInfo()
            {
                Name = n.SelectSingleNode("img").Attr("alt"),
                Url = base.EnsureHostName(this.HostUrl, n.Href())
            };
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
                "//h1/span[@itemprop='name']",
                "//ul[@id='thechapters']//a",
                coverPattern: "//article//a[@class='img-wrap']/img",
                summaryPattern: "//p[@class='big support-read']",
                categoryPattern: "//ul[@class='meta-cross']/li[1]/a",
                authorPattern: "//section/h5/a");

            return info;
        }
       
        public override List<string> GetPages(string chapUrl)
        {
            return new List<string>() { chapUrl };
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://thuquantruyen.com/truyen-online-moi-trang-{0}";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//li/section/a", "", this.CustomExtractor, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//p[@class='big support-read']", "");

            
        }
        //Use google search 
    }
}
