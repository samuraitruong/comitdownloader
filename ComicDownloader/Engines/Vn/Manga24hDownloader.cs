#define DEBUG
using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace ComicDownloader.Engines
{
    [Downloader("Manga24.com", MenuGroup = "I->N", MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
    public class Manga24hDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://vechai.info/template/teen9x/images/logo.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://manga24h.com/danhsach"; }
        }

        public override string HostUrl
        {
            get { return "http://manga24h.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://manga24h.com/capnhat/{0}",
                "//h4/a", 
                "");

        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://manga24h.com/index.php?module=ajax&act=manga&opt=search&manga_search_home&q=" + keyword;
            return base.OnlineSearchGet(url, "", 1, customParser: (html, doc) => {
                var obj = JObject.Parse(html);
                var list = from p in obj["items"]
                           select new StoryInfo()
                           {
                             Name = p["text"].ToString(),
                             Url  = base.EnsureHostName(this.HostUrl, p["id"].ToString())
                           };
                return list.ToList();
            });
        }
        public override List<StoryInfo> HotestStories() {
            return base.HotestStoriesSimple("http://manga24h.com/status/hot.html/{0}",
                "//h4/a",
                5);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesUnknowPages(this.ListStoryURL,
                "//a[@class='manga_name_update']",
                forceOnline,
                "//ul[@class='pagination']/li/a", null, this.HostUrl);
        }

        public override StoryInfo RequestInfo(string url)
        {

            return base.RequestInfoSimple(url,
                "//div[@id='manga-detail-info']/h1",
                "//table[@class='table chapt-table']//tr/td/a");
        }

        public override string Name
        {
            get { return "[Manga 24H] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();
            var html = NetworkHelper.GetHtml(chapUrl);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='chapcontent']/div/img");
            if (nodes == null)
            {
                //var text = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"vcfix\"]");
                //htmlDoc.LoadHtml(text.InnerHtml);
                //nodes = htmlDoc.DocumentNode.SelectNodes("//img");
            }
            var match = Regex.Match(html, "data='([^']*)'");
            var urls = match.Groups[1].Value.Split('|');
            //foreach (HtmlNode node in nodes)
            //{
            //    pages.Add(node.Attributes["src"].Value);
            //}
            return urls.ToList();
        }

        //Lastest Update chi show story, thong co link chapter moi nhat

        //Use google search
    }
}
