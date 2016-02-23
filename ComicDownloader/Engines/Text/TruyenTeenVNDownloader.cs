using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("truyenteen.vn", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TruyenTeenVNDownloader : Downloader
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
            get { return "[truyenteen.vn] - "; }
        }
        public override string Logo
        {
            get
            {
                return "http://www.truyenteen.vn/wp-content/themes/twentydo/logo.png";
            }
        }

        public override string ListStoryURL
        {
            get { return "http://www.truyenteen.vn/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.truyenteen.vn/"; }
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
            return base.GetListStoriesSimple("http://www.truyenteen.vn/page/{0}/",
                "//div[@class='entry-summary']/h2/a",
                forceOnline,
                convertFunc: (HtmlNode n) =>
                {
                    return new StoryInfo()
                    {
                        Url = base.EnsureHostName(this.HostUrl, n.Href()),
                        Name = n.InnerText.Trim()
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
                "//h1",
                "//div[@class='listpages']//a",
                coverPattern: "//div[@class='entry-content']//img",
                summaryPattern: "",
                categoryPattern: "//p[@class='tags']//a",
                authorPattern: "//div[@class='entry-content']//h3");

            info.Author = info.Author.Replace("Tác giả: ", string.Empty);
            if(info.Chapters.Count ==0 )
            {
                info.Chapters.Add(new ChapterInfo
                {
                   Name = info.Name,
                   Url = info.Url
                });
            }
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
            
            AfterPageDownloadedSimple(filename, chap.Name, "//div[@class='entry-content']", "");

            
        }
        //Use google search 
    }
}
