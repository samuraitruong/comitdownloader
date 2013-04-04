using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaReader", MenuGroup = "English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaReaderDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[Manga Reader] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangareader.net/alphabetical"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangareader.net"; }
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

                var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"series_alpha\"]//li/a");

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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mangaproperties\"]//h2");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"listing\"]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText,
                    Url = HostUrl + chapter.Attributes["href"].Value,
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
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"imgholder\"]//img");
            pageUrl = img.Attributes["src"].Value;

            
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"pageMenu\"]//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(HostUrl+ page.Attributes["value"].Value);
            }
            return results;
        }
        public override List<StoryInfo> GetLastestUpdates()
        {
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(this.HostUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"latestchapters\"]/table[1]//a[@class=\"chapter\"]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl+node.Attributes["href"].Value,
                    Name = node.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("a[@class='chaptersrec']");
                if(chapters!=null)
                foreach (HtmlNode chap in chapters)
                {
                    info.Chapters.Add(new ChapterInfo()
                    {
                        Name = chap.InnerText.Trim(),
                        Url = HostUrl + chap.Attributes["href"].Value,
                    });
                }
                stories.Add(info);
            }
            return stories;
        }
    }
}
