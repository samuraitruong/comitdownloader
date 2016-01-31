using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Truyen Mut", Offline = false, Language = "Tieng viet", MenuGroup = "O->T", MetroTab="Tiếng Việt", Image32 = "load_download")]
    public class TruyenMutDownloader: Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyenmut.com/skin/mutvn/img/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Truyen Mut] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyenmut.com/danh-sach/truyen-moi-update"; }
        }

        public override string HostUrl
        {
            get { return "http://truyenmut.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://truyenmut.com/danh-sach/truyen-moi-update/page-{0}.html";

            return base.GetListStoriesSimple(urlPattern,
                "(//div[@class='list list-thumbnail col-xs-12'])[1]//div[2]//div/a",
                forceOnline,
               // "//ul[@class='pagination pagination-sm']/li/a",
                convertFunc: (node) =>
                {
                    return new StoryInfo()
                    {
                        Name = node.InnerText.Trim(),
                        Url = base.EnsureHostName(this.HostUrl, node.Attributes["href"].Value)
                    };
                }
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);
            return base.RequestInfoSimple(storyUrl,
                "//div[@class='title-list']/h2",
                "//*[@id='list-chapter']/div[2]/div[1]//a");
        }

        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//div[@class='chapter-content']//img");
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
