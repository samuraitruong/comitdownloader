using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Academy VN", Offline = false, Language = "Tieng viet", MenuGroup = "A->F", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class AcademyVNDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyen.academyvn.com/uploads/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Academy VN] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyen.academyvn.com/manga/all"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.academyvn.com"; }
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
            return base.GetListStoriesSimple("http://truyen.academyvn.com/manga/all?page={0}",
                "//div[@class='table-responsive']/table//tr/td[1]/a",
                forceOnline
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h2",
                "//div[@class='table-scroll']/table//tr/td[1]/a",
                coverPattern: "//div[@class='__image']/img",
                summaryPattern: "//div[@class='__description']",
                authorPattern: "//div[@class='__info']/p[2]/a",
                categoryPattern: "//div[@class='__info']/p[1]/a"
                );
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@class='manga-container']//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://blogtruyen.com/trangchu",
                "//*[@id='top-newest-story']//a",
                "");
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://bigtruyen.net/?trang={0}&s=" + keyword;

            return base.OnlineSearchGet(url, "//div[@class='list-truyen-item-wrap']/a");
        }
    }
}
