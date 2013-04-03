using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("GoodManga", MenuGroup = "English - 2", Language = "English", Image32 = "_1364410884_add1_")]
    public class GoodMangaDownloader : Downloader
    {
        public override string Name
        {
            get { return "[GoodManga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.goodmanga.net/manga-list"; }
        }

        public override string HostUrl
        {
            get { return "http://www.goodmanga.net/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL;

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
               
                    
                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"series_index\"]//a");
                if (nodes != null && nodes.Count > 0)
                {
                    currentPage++;
                    foreach (var node in nodes)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = node.Attributes["href"].Value,
                            Name = node.InnerText.Trim()
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"right_col\"]/h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"chapters\"]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url =  chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
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
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='manga_viewer']/a/img");
            pageUrl = img.Attributes["src"].Value;

            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"page_select\"]//option[@value]");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(page.Attributes["value"].Value);
            }
            return results;
        }
    }
}
