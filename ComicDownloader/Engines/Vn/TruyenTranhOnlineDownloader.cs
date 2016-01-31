using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Truyen Tranh Online", Offline = false, Language = "Tieng viet", MenuGroup = "O->T", MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class TruyenTranhOnlineDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyentranhonline.vn/wp-content/themes/truyentranhonline/images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Truyen Tranh Online] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyentranhonline.vn/truyen-moi/page/1/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyentranhonline.vn/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //GOOD Example for cleanup code.
            return base.GetListStoriesSimple("http://truyentranhonline.vn/truyen-moi/page/{0}/",
                "//div[@class='ls1']//ul/h3/a",
                forceOnline,
                "", null,
                this.CustomListParser);
        }

        private  List<StoryInfo> CustomListParser(string html, HtmlDocument doc)
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

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1/a",
                "//ul[@class='chapter']/li//a");

        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl+ "&load=0",
                "//section[@id='viewer']//img");
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
