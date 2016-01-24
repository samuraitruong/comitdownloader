#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ComicDownloader.Engines
{
    [Downloader("Vechai.info", MenuGroup = "VN - 2" , Offline = false, MetroTab ="Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
    public class VechaiDownloader: Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://cdn.vechai.info/images/logo.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://vechai.info/danh-sach.tmoinhat.html"; }
        }

        public override string HostUrl
        {
            get { return "http://vechai.info"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://vechai.info/danh-sach.tmoinhat.p{0}.json";

            List<StoryInfo> results = base.ReloadChachedData();

            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                int currentPage = 0;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {

                    string url = string.Format(urlPattern, currentPage);

                    string html = NetworkHelper.GetHtml(url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@id='comic-list']/li/a[1]");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = node.Attributes["href"].Value,
                                Name = node.Attributes["title"].Value
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

        public override StoryInfo RequestInfo(string url)
        {
            StoryInfo story = new StoryInfo()
            {
                Url = url
            };
            var html = NetworkHelper.GetHtml(url);

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodeHtml = htmlDoc.DocumentNode.SelectSingleNode("//h2[contains(@class,'TitleH2')]");

            //var match = Regex.Match(nodeHtml.InnerHtml, "<strong>(.*?)</strong>");
            //if (match != null)
            //{
            //    story.Name = match.Groups[1].Value;
            //}
            story.Name = nodeHtml.InnerText;
            var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@id='acc1']//li/a");
            if (nodes != null)
                foreach (HtmlNode node in nodes)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.Attributes["title"].Value,
                        ChapId = ExtractID(node.Attributes["title"].Value)
                    };

                    story.Chapters.Add(chap);
                }
            story.Chapters = story.Chapters.OrderBy(p => p.ChapId).ToList();
            return story;
        }

          public override string Name
        {
            get { return "[Ve Chai] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();
            var html = NetworkHelper.GetHtml(chapUrl);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='contentChapter']//img");
            //if (nodes == null)
            //{
            //    //var text = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"vcfix\"]");
            //    //htmlDoc.LoadHtml(text.InnerHtml);
            //    nodes = htmlDoc.DocumentNode.SelectNodes("//img");
            //}
            foreach (HtmlNode node in nodes)
            {
                pages.Add(node.Attributes["src"].Value);
            }
            return pages;
        }

        //Lastest Update chi show story, thong co link chapter moi nhat

        //Use google search
    }
}
