using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("EatManga", MenuGroup = "English - 2", Language = "English", Image32 = "_1364410884_add1_")]
    public class EatMangaDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[Eatmanga.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://eatmanga.com/Manga-Scan/"; }
        }

        public override string HostUrl
        {
            get { return "http://eatmanga.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "?p={0}";

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();


                string html = NetworkHelper.GetHtml(ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"updates\"]//th[1]/a");
                if (nodes != null && nodes.Count > 0)
                {

                    foreach (var node in nodes)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl+node.Attributes["href"].Value,
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"main_content\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"updates\"]//th/a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url =  HostUrl+ chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
                info.Chapters.Add(chap);
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"eatmanga_image_big\"]");
            pageUrl = img.Attributes["src"].Value;

            
            base.DownloadPage(pageUrl, filename, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"pages\"]").SelectNodes("option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(HostUrl+page.Attributes["value"].Value);
            }
            return results;
        }
    }
}
