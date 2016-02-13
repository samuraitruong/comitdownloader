using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Free Manga", Offline =false, MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "1364078951_insert-object")]
    public class FreeMangaMeDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://freemanga.me/images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Freemanga.me] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://freemanga.me/latest-manga"; }
        }

        public override string HostUrl
        {
            get { return "http://freemanga.me/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){

            return base.HotestStoriesSimple("http://freemanga.me/ajax/home_hot_list/2/page/{0}",
                "//li/div/a[1]", totalPages:5);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple("http://freemanga.me/latest-manga/page.{0}.html",
                "//ul[@class='ulListruyen']//a[@class='tile']",
                forceOnline
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//span/h1",
                "//*[@class='ul_listchap']//a"
                , this.HostUrl,
                chapPagingPattern: "//div[@class='paging']//a");
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesRegex(chapUrl,
                "'<img src=\\\"([^\"]*)\".*\\/>'");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://freemanga.me/manga.html?category=&demographic=&order=0&page={0}",
                "//a[@class='tile']", "", numberOfpage: 3);

        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://freemanga.me/manga.html?q=Dragon&page=1",
                "//a[@class='tile']", 3);
        }
    }
}
