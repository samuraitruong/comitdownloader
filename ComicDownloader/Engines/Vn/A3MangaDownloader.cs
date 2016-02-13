using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace ComicDownloader.Engines
{
    [Downloader("A3 Manga", Offline = false, Language = "Tieng viet", MenuGroup = "A->F", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class A3MangaDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.a3manga.com/wp-content/themes/a3manga/images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[A3 Manga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.a3manga.com/danh-sach-truyen/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.a3manga.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){
            return base.HotestStoriesSimple(this.HostUrl,
                "//ul[contains(@class,'most-views')]/li/a",
                nodeConvert: (node) =>
                {
                    return new StoryInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.SelectSingleNode("p").InnerText.Trim()
                    };
                });
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple("http://www.a3manga.com/danh-sach-truyen/",
                "//table//tr/td[2]/a",
                forceOnline,
                singleListPage: true
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h2[@class='info-title']",
                "//table//tr/td/a",
                nameExtract: delegate (HtmlNode node)
                {
                    return node.InnerText.Trim().Replace(" - ", " ");
                });

        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//section[contains(@class,'view-chapter')]//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple(this.HostUrl,
                "//div[@class='comic-title-link']/a[1]",
                "");
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://www.a3manga.com/wp-admin/admin-ajax.php?action=autocompleteCallback&term=" + keyword;
            return base.OnlineSearchGet(url,
                "",
                1,
                customParser: (html, doc) =>
                {

                    JObject myjson = JObject.Parse(html);
                    var list = myjson["results"];
                    var aaa = from p in myjson["results"]
                              select
                    new StoryInfo
                     {
                         Name = p["title"].ToString(),
                         Url = p["url"].ToString()
                    };
                    

                    return aaa.ToList();
                });
        }
    }
}
