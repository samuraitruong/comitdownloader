using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaReader", MenuGroup = "English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaAccessDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[Manga Access] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.manga-access.com/manga/list"; }
        }

        public override string HostUrl
        {
            get { return "http://www.manga-access.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {


            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();

                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"inner_page\"]//div[contains(@class,\"c_h\")]/a");
                if(nodes!=null)
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
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"bc\"]//a[last()]");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"download-link\"]");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText ,//+ " " + chapter.ChildNodes[0].InnerText + " " + chapter.ChildNodes[1].InnerText,
                    Url = HostUrl + chapter.Attributes["href"].Value,
                    
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
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"inner_page\"]//img");
            pageUrl = img.Attributes["src"].Value;

            
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"page_switch\"]//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(HostUrl+ page.Attributes["value"].Value);
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"inner_page\"]/div[position()>2]//a");

            foreach (HtmlNode node in nodes)
            {
                string chapterUrl = HostUrl + node.Attributes["href"].Value;
                string pageUrl;
                if (chapterUrl.Contains("chapter"))
                {
                    pageUrl = chapterUrl.Substring(0, chapterUrl.LastIndexOf("/"));
                    pageUrl = pageUrl.Substring(0, pageUrl.LastIndexOf("/"));
                }
                else
                {
                    pageUrl = chapterUrl;
                }
                StoryInfo info;

                if (stories.Any(p => p.Url == pageUrl))
                {
                    info = stories.Where(p => p.Url == pageUrl).Single();
                }
                else
                {
                    info = new StoryInfo()
                    {
                        Url = pageUrl,
                        Name = node.ChildNodes[0].InnerText.Trim(),
                        Chapters = new List<ChapterInfo>()
                    };

                    stories.Add(info);
                }

                var chapter = new ChapterInfo()
                {
                    Url = chapterUrl,
                    Name = node.ChildNodes[0].InnerText.Trim() + ' ' + node.ChildNodes[1].InnerText.Trim() + ' ' + node.ChildNodes[2].NextSibling.InnerText.Trim()
                };

                info.Chapters.Add(chapter);
            }

            
            return stories;
        }
    }
}
