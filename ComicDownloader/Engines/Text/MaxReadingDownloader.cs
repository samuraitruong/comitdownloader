using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("maxreading.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class MaxReadingDownloader : Downloader
    {
        public override string Name
        {
            get { return "[maxreading.com] - "; }
        }

        public override string Logo
        {
            get
            {
                return "http://maxreading.com/images/logo.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://maxreading.com/"; }
        }

        public override string HostUrl
        {
            get { return "http://maxreading.com/"; }
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
            return base.GetListStoriesUnknowPages(this.HostUrl,
                "//div[@id='perex']//table[@class='table-style01']//td[@class='bigger']//a",
                forceOnline,
                "//div[@id='aside']//a");


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
                "//div[@id='perex']/h2",
                "//div[@id='perex']//table[@class='table-style01']//td[@class='bigger']//a",
                coverPattern: "",
                summaryPattern: "",
                categoryPattern: "//h3[@id='perex-title']/strong/a[last()]",
                authorPattern: "");

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
            
            AfterPageDownloadedSimple(filename, chap.Name, "//div[@id='chapter']", "//div[@id='perex']/h2");
        }
        //Use google search 
    }
}
