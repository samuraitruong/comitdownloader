using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("ComicVN.NET", Offline = false, Language = "Tieng viet", MenuGroup = "A->F", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class ComicVnDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://comicvn.net/static/image/default/new/images/comic.png";
            }
        }

        public override string Name
        {
            get { return "[Comic VN] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://comicvn.net/truyen-tranh"; }
        }

        public override string HostUrl
        {
            get { return "http://comicvn.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories() {
            return base.HotestStoriesSimple(this.HostUrl,
                "//div[@id='home-top-ten']//ul[@class='list-items']//h2/a");

        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://comicvn.net/truyen-tranh?parent_slug=truyen-tranh&name_slug=&id_category=1&orderBy=&type=0&&page={0}";
            string cheUrl = "http://comicvn.net/truyen-che";

            return base.GetListStoriesSimple(urlPattern,
                "//ul[@class='list']/li/div/h2/a",
                forceOnline,
                this.HostUrl);
            //request  truyen che


        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1[@class='title-detail']",
                "//table[@class='list-chapter']//a");
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            var doc = base.GetParser(chapUrl);
            var html = doc.DocumentNode.SelectSingleNode("//*[@id='txtarea']").InnerHtml;
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//img");
            foreach (HtmlNode node in nodes)
            {
                pages.Add(node.Attributes["src"].Value);
            }
            return pages;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple(this.HostUrl,
                "//div[@class='content-new']//h2/a", "");
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://comicvn.net/truyentranh/manga/search/?parent_slug=&name_slug=&id_category=&page=1&orderBy=&type=0&key=" + keyword + "&type_search=truyen";
            return base.OnlineSearchGet(url, "//div[@class='content']//h2/a", 1);

        }

        public override int MaxThreadCrawlList
        {
            get
            {
                return 8; // seem this site block if we call to it so fast.
            }

            set
            {
                base.MaxThreadCrawlList = value;
            }
        }
    }
}
