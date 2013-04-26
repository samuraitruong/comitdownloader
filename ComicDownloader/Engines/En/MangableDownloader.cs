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

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "all/name/asc/{0}.html";

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                int currentPage = 1;
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var paging = htmlDoc.DocumentNode.SelectNodes("//ul[@id=\"pages\"]//a");

                if (paging != null && paging.Count > 0)
                {
                    var lastPageNode = paging.ToList()[paging.Count - 2];

                    int lastPage;
                    if (lastPageNode.Attributes.Contains("class"))
                    {
                        lastPage = int.Parse(lastPageNode.FirstChild.InnerText.Trim());
                    }
                    else
                    {
                        lastPage = int.Parse(lastPageNode.FirstChild.InnerText.Trim());
                    }

                    while (currentPage <= lastPage)
                    {
                        var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@id=\"comprehensive_list\"]/li/div[position()=1]/a");

                        if (nodes != null && nodes.Count > 0)
                        {
                            foreach (var node in nodes)
                            {
                                StoryInfo info = new StoryInfo()
                                {
                                    Url = HostUrl + node.Attributes["href"].Value,
                                    Name = node.InnerText.Trim()
                                };
                                results.Add(info);
                            }
                        }

                        currentPage++;
                    }
                }

            }
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//h2[@id=\"series_title\"]").FirstChild.InnerText.Trim();

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode
            };

            var volumns = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"newlist\"]/ul/li/a");
            if (volumns != null)
            {
                foreach (HtmlNode item in volumns)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Name = item.Descendants("span").First().InnerText.Trim(),
                        Url = item.Attributes["href"].Value
                    };
                    chap.ChapId = ExtractID(chap.Name);
                    info.Chapters.Add(chap);
                }
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//img[@id=\"image\"]");
            pageUrl = img.Attributes["src"].Value;
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"select_page\"]/select/option");

            List<string> results = new List<string>();

            if (pages != null)
            {
                foreach (HtmlNode page in pages)
                {

                    results.Add(chapUrl + page.Attributes["value"].Value);
                }
            }

            return results;
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
                            Name = chap.InnerText.Trim(),
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
                            Name = node.InnerText.Trim()
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
