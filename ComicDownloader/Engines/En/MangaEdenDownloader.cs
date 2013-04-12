using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaReader", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410887_Add")]
    public class MangaEdenDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[Manga Eden] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangaeden.com/en-directory/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangaeden.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "?page={0}";

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {
                    string url = string.Format(urlPattern, currentPage);

                    string html = NetworkHelper.GetHtml(url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"mangaList\"]//td[1]/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
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
                    else
                    {
                        isStillHasPage = false;
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"leftContent\"]//h2");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Replace("Manga",""),
            };

            
            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"chapterLink\"]");
            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name =chapter.ChildNodes[1].InnerText.Trim()+" "+ chapter.ChildNodes[3].InnerText.Trim(),
                    Url = HostUrl+ chapter.Attributes["href"].Value,
                    //ChapId = ExtractID(chapter.InnerText)
                };
                chap.ChapId = ExtractID(chap.Name);
                info.Chapters.Add(chap);
            }
            
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"image\"]//img");
            pageUrl = img.Attributes["src"].Value;
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

           // string patternUrl = chapUrl.Replace("/1/","{0}.html");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[contains(@class,\"pagination\")]//a");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                if (page.FirstChild.Name=="span") continue;

                string url = HostUrl+ page.Attributes["href"].Value;
                if(string.IsNullOrEmpty(url) )url = chapUrl;

                results.Add(url);
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

            var chapters = htmlDoc.DocumentNode.SelectNodes("//ul[@id=\"news\"]/li/a[contains(@href,\"en-manga\")]");
            if (chapters != null)
            {
                foreach (HtmlNode chap in chapters)
                {
                    var item = new ChapterInfo()
                    {
                        Name = chap.InnerText.Trim(),
                        Url = HostUrl + chap.Attributes["href"].Value
                    };

                    var page = chap.ParentNode.SelectSingleNode("div[position()=1]/a[position()=1]");
                    var pageUrl = page.Attributes["href"].Value;
                    if (pageUrl.Contains("it-manga"))
                    {
                        pageUrl = pageUrl.Replace("it-manga", "en-manga");
                    }

                    if (stories.Any(p => p.Url == page.Attributes["href"].Value))
                    {
                        stories.Where(p => p.Url == page.Attributes["href"].Value).Single().Chapters.Add(item);
                    }
                    else
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + pageUrl,
                            Name = page.InnerText.Trim(),
                            Chapters = new List<ChapterInfo>() { item }
                        };

                        stories.Add(info);
                    }
                }
            }
                
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.mangaeden.com/en-directory/?{1}&title={0}", keyword.Replace(" ", "+"), "page={0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;
            bool isStillHasPage = true;
            while (isStillHasPage)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@id=\"mangaList\"]//tr/td[position()=1]/a");
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
                else
                {
                    isStillHasPage = false;
                }
                currentPage = results.Count;
            }
            return results;
        }
    }
}
