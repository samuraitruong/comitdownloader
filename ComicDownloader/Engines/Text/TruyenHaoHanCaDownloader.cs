using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("truyen.haohanca.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TruyenHaoHanCaDownloader : Downloader
    {
        public override bool IsTextEngine
        {
            get
            {
                return true;
            }
        }
        public override string Name
        {
            get { return "[truyen.haohanca.com] - "; }
        }

        public override string Logo
        {
            get
            {
                return "http://truyen.haohanca.com/system/application/frontend/views/skins/images/truyen_kiem_hiep.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://truyen.haohanca.com/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.haohanca.com"; }
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
                "//div[@class='story-name']/p/a",
                forceOnline,
                "//*[@id='header-top']//a;//a[@class='paging-one-link']");


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
                "//h1",
                "//li[@class='list-vertical']/div/a",
                coverPattern: "",
                summaryPattern: "",
                categoryPattern: "//div[@itemtype='http://data-vocabulary.org/Breadcrumb']/div[2]/a",
                authorPattern: "//div[@id='chapter-info']//span[1]/strong/a");

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
            
            AfterPageDownloadedSimple(filename, chap.Name, "//div[contains(@class,'story-detail')]", "");

            
        }
        //Use google search 
    }
}
