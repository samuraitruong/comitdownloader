using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ComicDownloader.Engines.En
{
    [Downloader("Mangable", MenuGroup = "English - 1", MetroTab = "English", Language = "English", Image32 = "_1364410906_add")]
    public class MangableDownloader : Downloader
    {
        public override string Name
        {
            get { return "[Mangable] - "; }
        }
        public override string Logo
        {
            get
            {
                return "http://mangable.com/imgs/logo.png";
            }
        }

        public override string ListStoryURL
        {
            get { return "http://mangable.com/manga-list/"; }
        }

        public override string HostUrl
        {
            get { return "http://mangable.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories() { throw new NotImplementedException(); }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesUnknowPages("http://mangable.com/manga-list/all/name/asc/1.html",
                "//ul[@id='comprehensive_list']//li//div[@class='col1']/a",
                forceOnline,
                "//ul[@id='pages']//li//a",
                null,
                this.HostUrl);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h2[@id='series_title']",
                "//div[@id='newlist']/ul/li/a",
                string.Empty,
                chapterExtract: delegate (HtmlNode node)
                {
                    return new ChapterInfo()
                    {
                        Name = node.Descendants("b").First().InnerText.Trim(),
                        Url = node.Attributes["href"].Value
                    };
                });

        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var imgUrl = base.ExtractImage(pageUrl, "//img[@id=\"image\"]");

            return base.DownloadPage(imgUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@id=\"select_page\"]/select/option",
                null,
                string.Empty,
                delegate (HtmlNode node)
                {
                    return chapUrl + node.Attributes["value"].Value;
                });

        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"newlist_home\"]/ul/li/p[position()=1]/a[position()=1]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
                    Name = node.Attributes["title"].Value.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };

                var chapters = node.ParentNode.SelectNodes("a[position()=2]");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = HostUrl + chap.Attributes["href"].Value,
                        });
                    }
                }
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://mangable.com/search/?completed=1&series_contains=1&series_name={0}&where=all&order=name&sort=asc&page={1}", keyword.Replace(" ", "+"), "{0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@id=\"comprehensive_list\"]/li/div[position()=1]/a");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + node.Attributes["href"].Value,
                            Name = node.InnerText.Trim().Trim()
                        };
                        results.Add(info);
                    }
                }

                currentPage++;
            }
            return results;
        }
    }
}
