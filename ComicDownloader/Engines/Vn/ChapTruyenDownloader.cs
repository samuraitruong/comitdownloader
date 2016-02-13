using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ComicDownloader.Engines
{
    [Downloader("Chaptruyen.com", Offline = false, MenuGroup = "A->F", MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410887_Add")]
    public class ChapTruyenDownloader
        : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://chaptruyen.com/wp-content/themes/glossy-bright/logo.png";
            }
        }

        public override string StoryUrlPattern
        {
            get
            {
                return HostUrl + "/{0}/";
            }

        }
        public override string HostUrl
        {
            get
            {
                return "http://chaptruyen.com/";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://chaptruyen.com/truyen/all/any/name-az";
            }

        }

        public override List<StoryInfo> HotestStories() {
            return base.HotestStoriesSimple(this.HostUrl,
                "//div[@class='wpm_wgt mng_ppl']//div[@class='ttb']/a");
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesUnknowPages(this.ListStoryURL,
                "//a[@class='mng_det_pop']",
                forceOnline,
                "(//ul[@class='pgg'])[1]/li/a");
        }

        public override StoryInfo RequestInfo(string url)
        {
            return base.RequestInfoSimple(url,
                "//h1/a",
                "//ul[@class='lst']//a[@class='lst']"
                );
        }
        public override string Name
        {
            get { return "[Chap Truyen] - "; }
        }
        //public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        //{
        //    var html = NetworkHelper.GetHtml(pageUrl);
        //    HtmlDocument htmlDoc = new HtmlDocument();
        //    htmlDoc.LoadHtml(html);
        //    var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img[@class=\"1picture\"]");

        //    var url = "http://img.mangakung.com/read/"+imgNode.Attributes["src"].Value;

        //    base.DownloadPage(url, filename, httpReferer);
        //}
        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();


            string html = NetworkHelper.GetHtml(chapUrl);
            var p = "lstImages\\.push\\(\"([^\"]*)\"";
            var matches = Regex.Matches(html, p);
            foreach (Match item in matches)
            {
                pages.Add(item.Groups[1].Value);
            }
            return pages;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://chaptruyen.com/truyen/all/any/last-updated/",
                "//a[@class='mng_det_pop']",
                "");
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://chaptruyen.com/wpm-ajx/mng-sch-lst/?q="+ keyword+"&limit=1000";

            return OnlineSearchGet(url,
                "//dummy", 1, customParser: (html, doc)=> {
                    List<StoryInfo> list = new List<StoryInfo>();
                    var json = html.Replace("}", "},");
                    json = json.TrimEnd(new char[] { ',' });
                    var obj = JArray.Parse("[" + json + "]");
                    list = obj.Select(x => new StoryInfo()
                    {
                        Name = x["nme"].ToString(),
                        Url = x["url"].ToString()
                    }).ToList();
                    return list;
                });
        }
    }
}
