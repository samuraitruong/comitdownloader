using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Hamtruyen.vn", Offline = false, Language = "Tieng viet", MenuGroup = "I->N", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class HamTruyenDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "https://lh3.googleusercontent.com/yeo6JMkCt9KBUOui-ho2xNoFYlkvZzX5QzranDn6Wg86nm2jjF1QryE4orBCDRwqovg=w300";
            }
        }

        public override string Name
        {
            get { return "[Hamtruyen VN] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://hamtruyen.vn/danhsach/index.html"; }
        }

        public override string HostUrl
        {
            get { return "http://hamtruyen.vn"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories()
        {
            return base.HotestStoriesSimple(this.HostUrl,
                "//div[@class='carousel-inner onebyone-carosel']//a");
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://hamtruyen.vn/danhsach/P{0}/index.html?sort=1";

            return base.GetListStoriesSimple(urlPattern,
               "//div[@class='item_truyennendoc']/a",
               forceOnline,
               this.HostUrl);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1[@class='tentruyen']",
                "//div[@id='wrapper_listchap']//a",
                categoryPattern: "//p[@class='row_theloai']/a",
                summaryPattern: "//p[@id='tomtattruyen']",
                coverPattern: "//div[contains(@class,'wrapper_image')]//img",
                authorPattern: "//div[contains(@class,'wrapper_info')]//p[1]"
                );
        }

        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//div[@id='content_chap']//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple(this.HostUrl, "//div[@class='wrapper_imgage']/a[1]", "", (node)=>
            {
                return new StoryInfo()
                {
                  Name = node.SelectSingleNode("img").Attributes["alt"].Value,
                  Url = base.EnsureHostName(this.HostUrl, node.Attributes["href"].Value)

                };
            });
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://hamtruyen.vn/" + keyword + "/search.html";
            return base.OnlineSearchGet(url, "//div[@class='wrapper_imgage']/a[1]", 1, 
                (node) => {
                return new StoryInfo()
                {
                    Name = node.SelectSingleNode("img").Attributes["alt"].Value,
                    Url = base.EnsureHostName(this.HostUrl, node.Attributes["href"].Value)

                };
            }); 

        }
        public override int MaxThreadCrawlList
        {
            get
            {
                return 6; //dont do it so fast, server will return 403 :) this will override global setting
            }

            set
            {
                base.MaxThreadCrawlList = value;
            }
        }
    }
}
