using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Thich Truyen Tranh", Offline = false, Language = "Tieng viet", MenuGroup = "O->T", MetroTab = "Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class ThichTruyenTranhDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://thichtruyentranh.com/images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Thich Truyen Tranh] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://thichtruyentranh.com/truyen-moi-nhat/trang.1.html"; }
        }

        public override string HostUrl
        {
            get { return "http://thichtruyentranh.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories() { throw new NotImplementedException(); }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //GOOD Example for cleanup code.
            return base.GetListStoriesSimple("http://thichtruyentranh.com/truyen-moi-nhat/trang.{0}.html",
                "//ul[@class='ulListruyen']//a[@class='tile']",
                forceOnline,
               this.HostUrl);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var doc = base.GetParser(storyUrl);
            var paging = doc.DocumentNode.SelectSingleNode("(//div[@class='paging'])[1]//li[last()]/a");
            var listPages = new List<string>() { storyUrl };

            if (paging != null)
            {
                var pagingUrl = this.HostUrl + paging.Attributes["href"].Value;
                var pageCount = Regex.Match(pagingUrl, @"trang\.(\d+).html").Groups[1].Value;
                pagingUrl = Regex.Replace(pagingUrl, @"trang\.(\d+).html", "trang.{0}.html");
                foreach (var item in Enumerable.Range(2, int.Parse(pageCount) - 1))
                {
                    listPages.Add(string.Format(pagingUrl, item));
                }

            }
            List<ChapterInfo> chapters = new List<ChapterInfo>();
            StoryInfo info = new StoryInfo();
            foreach (var url in listPages)
            {
                info = base.RequestInfoSimple(storyUrl,
                "//ul[@class='ulpro_line']//h1",
                "//ul[@class='ul_listchap']//a",
                this.HostUrl);
                chapters.AddRange(info.Chapters);
            }
            info.Chapters = chapters;
            info.ChapterCount = chapters.Count;
            return info;
        }
        private List<string> CustomExtractPages(string html)
        {
            List<string> list = new List<string>();

            var match = Regex.Match(html, @"var imgArray = \[([^\]]*)]");
            if (match != null)
            {
                html = match.Groups[1].Value;
                var nodes = base.GetParser(html).DocumentNode.SelectNodes("//img");
                foreach (HtmlNode node in nodes)
                {
                    list.Add(node.Attributes["src"].Value);
                }
            }
            return list;
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@id='content_read']/img",
                customExtractor: this.CustomExtractPages);
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"product\"]/div[@class=\"list-chap\"]/ul/li[position()=1]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + "/" + node.Attributes["href"].Value,
                    Name = node.FirstChild.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("li[position()=3]/ul/h3/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = HostUrl + "/" + chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }

            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var stories = new List<StoryInfo>();

            if (!string.IsNullOrEmpty(keyword))
            {
                var urlPartern = string.Format("http://truyentranh8.com/{0}/", keyword.Replace(" ", "_"));

                string html = NetworkHelper.GetHtml(urlPartern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"info1\"]/table//tr[position()=1]/td/a");

                if (node != null && node.Attributes["href"].Value != "/#doctruyen")
                {
                    stories.Add(new StoryInfo() { Url = urlPartern, Name = keyword });
                }
            }

            return stories;
        }
    }
}
