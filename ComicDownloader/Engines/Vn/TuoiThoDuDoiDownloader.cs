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
    [Downloader("Tuoi tho DD", Offline = false, Language = "Tieng viet", MenuGroup = "T", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class TuoiThoDuDoiDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.tuoithodudoi.com/staticres/images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Tuoi tho DD] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.tuoithodudoi.com/danh-sach-truyen-tranh/moi-cap-nhat.html"; }
        }

        public override string HostUrl
        {
            get { return "http://www.tuoithodudoi.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){
            return base.HotestStoriesSimple(this.HostUrl,
                "//div[@class='content-list-hot']/a");
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesUnknowPages(this.ListStoryURL,
                "//li[@class='wrap-item-story']/div/div[contains(@class,'name')]/a",
                forceOnline,
                "//ul[@class='pagination']//a"
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h2",
                "//a[@class='chap-name-link']",
                authorPattern: "//span[@class='author']",
                categoryPattern: "//span[@class='type']",
                summaryPattern: "//div[@class='brief-content-wrap']//p",
                coverPattern: "//img[@class='comic-image img-thumbnail']");

        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@class='detail-list-chapter']//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple(this.ListStoryURL,
                "//li[@class='wrap-item-story']/div/div[contains(@class,'name')]/a",
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
