using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaReader", MenuGroup = "English", Language = "English", Image32 = "_1364410906_add")]
    public class MangaFoxDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[Manga Fox] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://mangafox.me/manga/"; }
        }

        public override string HostUrl
        {
            get { return "http://mangafox.me"; }
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

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"manga_list\"]//li/a");

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
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"title\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Replace("Manga",""),
            };

            var volumns = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"slide\"]");
            foreach (HtmlNode item in volumns)
	        {
		    string vol = item.SelectSingleNode("h3").InnerText;
            vol = Regex.Replace(vol, "(Volume \\d*).*", "$1");
            var chapterNodes = item.NextSibling.SelectNodes("li//a[@class=\"tips\"]");
            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name =vol+" - "+ chapter.InnerText,
                    Url = chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
                info.Chapters.Add(chap);
            }
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"viewer\"]//img");
            pageUrl = img.Attributes["src"].Value;
            base.DownloadPage(pageUrl, filename, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            string patternUrl = chapUrl.Replace("1.html","{0}.html");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"top_center_bar\"]//select[@class=\"m\"]/option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                
                results.Add(string.Format(patternUrl,page.Attributes["value"].Value));
            }
            return results;
        }
    }
}
