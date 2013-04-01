using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaWall", MenuGroup = "English - 2", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaWallDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[Manga Wall] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://mangawall.com/browse"; }
        }

        public override string HostUrl
        {
            get { return "http://mangawall.com"; }
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

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"mangalisttext\"]//li/a");
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"leftbig\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.ChildNodes[1].InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"chapterlistfull\"]/li/a");

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
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"inthemiddle\"]//img");
            pageUrl = img.Attributes["src"].Value;

            
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"mangaselecter pageselect\"]//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                var url = Regex.Replace(chapUrl, @"(.*)/(\d+$)", "$1/" + page.Attributes["value"].Value);
                results.Add(url);
            }
            return results;
        }
    }
}
