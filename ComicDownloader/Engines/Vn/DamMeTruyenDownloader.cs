using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Dam Me Truyen", Offline = false, Language = "Tieng viet", MenuGroup = "A->F", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class DamMeTruyenDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://dammetruyen.com/images/logo_1.png";
            }
        }

        public override string Name
        {
            get { return "[Dam Me Truyen] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://dammetruyen.com/sapxep/truyen-moi-1/"; }
        }

        public override string HostUrl
        {
            get { return "http://dammetruyen.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories() {
            return base.HotestStoriesSimple(this.HostUrl,
                "(//div[@class='wpm_wgt mng_lst'])[2]//li/a[1]");
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //GOOD Example for cleanup code.
            return base.GetListStoriesSimple("http://dammetruyen.com/sapxep/truyen-moi-{0}/",
                "//div[@class='manga_list sidebar']/a[1]",
                forceOnline);
        }

        private List<StoryInfo> CustomListParser(string html, HtmlDocument doc)
        {
            List<StoryInfo> list = new List<StoryInfo>();
            var divNode = doc.DocumentNode.Descendants("div").Where(p => p.HasAttributes && p.Attributes["class"] != null && p.Attributes["class"].Value == "ls1").FirstOrDefault();
            if (divNode == null) return list;
            doc.LoadHtml(divNode.InnerHtml);
            var nodes = doc.DocumentNode.SelectNodes("//h3/a");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    StoryInfo info = new StoryInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.Attributes["title"] != null && string.IsNullOrEmpty(node.Attributes["title"].Value) ? node.Attributes["title"].Value : node.InnerText.Trim().Trim()
                    };
                    list.Add(info);
                }
            }

            return list;
        }
        private List<ChapterInfo> CustomExtractChapters(string html, HtmlDocument doc)
        {
            var list = new List<ChapterInfo>();
            var bookId = doc.DocumentNode.SelectSingleNode("//input[@name='book_id']").Attributes["value"].Value;
            doc = base.GetParser("http://dammetruyen.com/truyen/gen_list_chapters/" + bookId);
            var nodes = doc.DocumentNode.SelectNodes("//ul/li/span/a");
            foreach (HtmlNode node in nodes)
            {
                var chapInfo = new ChapterInfo()
                {
                    Name = node.InnerText.Trim(),
                    Url = node.Attributes["href"].Value.Trim(),
                };
                chapInfo.ChapId = ExtractID(chapInfo.Name);
                list.Add(chapInfo);
            }
            return list;

        }
        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1[@class='ttl']",
                "//ul[@class='lst']/li/span/a",
                null,
                null,
                null,
                this.CustomExtractChapters,
                coverPattern: "//div[@class='cvr_ara']/img",
                summaryPattern: "//div[@class='det']/p[1]"
                );

        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);
            var match = Regex.Match(html, @"loadingBookChapters\('(\d+)', '(\d+)'\)");
            if (match != null && match.Groups.Count >= 2)
            {
                var url = "http://dammetruyen.com/truyen/gen_html_chapter/" + match.Groups[1].Value + '/' + match.Groups[2].Value;
                var doc = GetParser(url);
                var nodes = doc.DocumentNode.SelectNodes("//img");
                if (nodes != null && nodes.Count > 0)
                    return nodes.Select(p => p.Attributes["src"].Value).ToList();
            }
            return new List<string>();
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple(this.HostUrl, "//div[@class='wpm_pag mng_lts_chp']/div/ul[@class='lst']/a", "");

        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://dammetruyen.com/search?keyword=" + keyword,
                "//div[@class='manga_list sidebar']//a[@class='lst']",
                1);
        }
    }
}
