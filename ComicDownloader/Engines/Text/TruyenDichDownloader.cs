using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;

namespace ComicDownloader.Engines
{
    [Downloader("truyendich.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TruyenDichDownloader : Downloader
    {
        public override string Name
        {
            get { return "[truyendich.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyendich.com"; }
        }

        public override string HostUrl
        {
            get { return "http://truyendich.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://truyendich.com/public/frontend/img/logo.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://truyendich.com/truyen-duoc-xem-nhieu-nhat/{0}"
                , "//ul[@class='homeListstory']//h3/a", 3);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            List<String> urls = new List<string>()
            {
                "http://truyendich.com/truyen-ngon-tinh/",
                "http://truyendich.com/truyen-teen/",
                "http://truyendich.com/truyen-xuyen-khong/",
                "http://truyendich.com/truyen-do-thi/",
                "http://truyendich.com/truyen-tien-hiep/",
                "http://truyendich.com/truyen-kiem-hiep/"
            };

            return base.GetListStoriesUnknowPages(String.Join(";", urls),
                "//ul[@class='homeListstory']//h3/a", forceOnline, "//ul[@class='page']//a");
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyendich.com/search/"+ keyword+ "/{0}" ,
                "//ul[@class='homeListstory']//h3/a", 3);
        }
        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://truyendich.com/truyen-moi-dang/{0}",
                "//ul[@class='homeListstory']//h3/a", "", null, 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//*[@class='table table-striped']//tr//a",
                chapterExtract: (HtmlNode n) =>
                {
                    return new ChapterInfo()
                    {
                      Name = n.ParentNode.PreviousSibling.InnerText.Trim() +" " + n.InnerText.Trim(),
                      Url =base.EnsureHostName(this.HostUrl,n.Href())
                    };
                },
                chapPagingPattern: "//ul[@class='page']//a");
        }

        public override List<string> GetPages(string chapUrl)
        {
            return new List<string>() { chapUrl };
        }

        //public override List<StoryInfo> GetLastestUpdates()
        //{
        //    string lastestUpdateUrl = "http://truyenngontinhaz.com/the-loai/truyen-moi/page{0}";
        //    return base.GetLastestUpdateSimple(lastestUpdateUrl, "//div[@class='wapcat']/table//tr/td[2]/a", "", null, 3);
        //}
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            AfterPageDownloadedSimple(filename, chap.Name, "//*[@id='detailcontent']", "//h3");
        }
        //Use google search 
    }
}
