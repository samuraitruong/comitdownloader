using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaPanda", MenuGroup = "English - 2", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaPandaDownloader__ : Downloader
    {
        public override string Name
        {
            get { return "[MangaPanda] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangapanda.com/alphabetical"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangapanda.com"; }
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


                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"series_col\"]//li/a");
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


            }
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mangaproperties\"]/h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            //var match = Regex.Match(html,"<table id=\"listing\"");
            //var index = match.Captures[0].Index;
            //var table = html.Substring(index, html.IndexOf("</table>", index)-index+9);
            //htmlDoc.LoadHtml(table);
            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"listing\"]//td//a");

            if (chapterNodes != null)
            {
                foreach (HtmlNode chapter in chapterNodes)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Name = chapter.InnerText.Trim(),
                        Url = HostUrl + chapter.Attributes["href"].Value,
                        ChapId = ExtractID(chapter.InnerText)
                    };
                    info.Chapters.Add(chap);
                }
                info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            }
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='imgholder']//img");
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
                results.Add(HostUrl + page.Attributes["value"].Value);
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"updates\"]/tr/td[position()=2]/a[position()=1]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
                    Name = node.FirstChild.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("a[position()>1]");
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
    }

}
