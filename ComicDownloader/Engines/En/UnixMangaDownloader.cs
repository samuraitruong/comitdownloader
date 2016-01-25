using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ComicDownloader.Engines.En
{
    [Downloader("UnixManga", MenuGroup = "English - 1", MetroTab = "English", Language = "English", Image32 = "_1364410906_add")]
    public class UnixMangaDownloader : Downloader
    {
        public override string Name
        {
            get { return "[Unix Manga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://unixmanga.com/onlinereading/manga-lists.html"; }
        }

        public override string HostUrl
        {
            get { return "http://unixmanga.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL;

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                string html = NetworkHelper.GetHtml(urlPattern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"mycontent\"]/div[position()=1]/div[position()=3]/table//tr[position()>1]/td[position()=2]/a");

                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = node.Attributes["href"].Value,
                            Name = node.InnerText.Trim().Trim()
                        };
                        results.Add(info);
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

            var nameNode = storyUrl.Substring(storyUrl.LastIndexOf("/") + 1);
            nameNode = nameNode.Substring(0, nameNode.LastIndexOf(".htm")).Replace("_", " ");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode
            };

            var volumns = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"snif\"]//tr[position()>2]/td[position()=2]/a");
            if (volumns != null)
            {
                foreach (HtmlNode item in volumns)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Name = item.InnerText.Trim().Trim(),
                        Url = item.Attributes["href"].Value,
                        ChapId = ExtractID(item.InnerText.Trim().Trim())
                    };
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
            var imgUrl = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"contentRH\"]/div[@align=\"center\"]/script").InnerText.Trim();
            imgUrl = imgUrl.Substring(imgUrl.IndexOf("SRC") + 5);
            imgUrl = imgUrl.Substring(0, imgUrl.IndexOf('"'));

            pageUrl = imgUrl;
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            List<string> results = new List<string>();

            var html = NetworkHelper.GetHtml(chapUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var link = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"news\"]//ul//a[position()=1]");
            if (link != null)
            {
                html = NetworkHelper.GetHtml(link.Attributes["href"].Value);
                htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var pages = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"controls\"]//a[position()>1]");
                pages.RemoveAt(pages.Count - 1);
                pages.RemoveAt(pages.Count - 1);

                if (pages != null)
                {
                    foreach (HtmlNode page in pages)
                    {
                        if (page.Attributes.Contains("class"))
                        {
                            continue;
                        }
                        results.Add("http://ex1.unixmanga.net/onlinereading/" + page.Attributes["href"].Value);
                    }
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"latest\"]/span/li/a");

            foreach (HtmlNode node in nodes)
            {
                var chapUrl = node.Attributes["href"].Value;
                var storyUrl = chapUrl.Substring(0, chapUrl.LastIndexOf("/")) + ".html";
                var storyName = chapUrl.Substring(0, chapUrl.LastIndexOf("/"));
                storyName = storyName.Substring(storyName.LastIndexOf("/") + 1).Replace("_", " ");

                StoryInfo info;
                if (!stories.Any(p => p.Url == storyUrl))
                {
                    info = new StoryInfo()
                    {
                        Url = storyUrl,
                        Name = storyName,
                        Chapters = new List<ChapterInfo>(),
                    };

                    stories.Add(info);
                }
                else
                {
                    info = stories.Where(p => p.Url == storyUrl).Single();
                }

                info.Chapters.Add(new ChapterInfo()
                {
                    Name = node.ParentNode.ParentNode.Attributes["title"].Value,
                    Url = chapUrl,
                });
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://unixmanga.net/onlinereading/{0}.html", keyword.Replace(" ", "_"));

            var results = new List<StoryInfo>();

            string html = NetworkHelper.GetHtml(urlPattern);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//table[@class=\"snif\"]//tr[position()=2]/td[position()=2]/a");
            if (node.InnerText.Trim().Trim() == "[ Goto Main ]")
            {
                var nameNode = urlPattern.Substring(urlPattern.LastIndexOf("/") + 1);
                nameNode = nameNode.Substring(0, nameNode.LastIndexOf(".htm")).Replace("_", " ");

                StoryInfo info = new StoryInfo()
                {
                    Url = urlPattern,
                    Name = nameNode
                };

                results.Add(info);
            }

            return results;
        }
    }
}
