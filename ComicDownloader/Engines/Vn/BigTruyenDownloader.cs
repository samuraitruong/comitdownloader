using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Big Truyen", Offline = false, Language = "Tieng viet", MenuGroup = "A->F", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class BigTruyenDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://bigtruyen.net/wp-content//uploads/2015/04/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Big Truyen] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://bigtruyen.net/danh-sach-truyen/"; }
        }

        public override string HostUrl
        {
            get { return "http://bigtruyen.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories() {
            return base.HotestStoriesSimple("http://bigtruyen.net/truyen-hot/",
                "//h3[@class='truyen-title']/a",4);
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //GOOD Example for cleanup code.
            return base.GetListStoriesSimple("http://bigtruyen.net/danh-sach-truyen/?trang={0}",
                "//div[@class='list-truyen-item-wrap']/a",
                forceOnline
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1[@class='title']",
                "//div[@class='chapter-list']//a"
                );
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@id='chapter-content']//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple(this.HostUrl,
                "//a[@class='title-h3-link']",
                "");
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://bigtruyen.net/?trang={0}&s=" + keyword;

            return base.OnlineSearchGet(url, "//div[@class='list-truyen-item-wrap']/a");
        }
    }
}
