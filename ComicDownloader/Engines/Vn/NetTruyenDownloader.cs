using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Net Truyen", Offline = false, Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class NetTruyenDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.nettruyen.com/Data/logos/nettruyen.png";
            }
        }

        public override string Name
        {
            get { return "[Net Truyen] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.nettruyen.com/tim-truyen"; }
        }

        public override string HostUrl
        {
            get { return "http://www.nettruyen.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //GOOD Example for cleanup code.
            return base.GetListStoriesSimple("http://www.nettruyen.com/tim-truyen?status=-1&sort=5&page={0}",
                "//div[@class='item']//h3/a",
                forceOnline);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1[@class='title-detail']",
                "//td[@class='chapter']/a");

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
                "//div[contains(@class,'reading-detail')]/img");
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
