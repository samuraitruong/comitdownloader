using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public class MangaParkDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[MangaPark] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangapark.com/manga"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangapark.com"; }
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

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"section\"]//li/a");

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
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//section[@class=\"manga\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Replace("Manga",""),
            };

            
            var chapters = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"list\"]//li/span/a");
            var links = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"list\"]//em/a[last()]");

            for (int i = 0; i < chapters.Count; i++)
            {
            
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapters[i].ChildNodes[0].InnerText + chapters[i].ChildNodes[1].InnerText,
                    Url = HostUrl + links[i].Attributes["href"].Value.Trim()
                    //ChapId = ExtractID(chapter.InnerText)
                };
                chap.ChapId = ExtractID(chap.Name, "Ch.(\\d*)");
                info.Chapters.Add(chap);
            }
            
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        {
            //var html = NetworkHelper.GetHtml(pageUrl);
            //HtmlDocument htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(html);
            //var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"image\"]//img");
            //pageUrl = img.Attributes["src"].Value;
            base.DownloadPage(pageUrl, filename, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

           // string patternUrl = chapUrl.Replace("/1/","{0}.html");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//a[@class=\"img-link\"]//img");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {


                results.Add(page.Attributes["src"].Value);
            }
            return results;
        }
    }
}
