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
    [Downloader("MangaK.net", MenuGroup = "VN - 2" , Offline = false, MetroTab ="Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
    public class MangaKDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://orig00.deviantart.net/11d0/f/2011/227/a/e/manga_style___by_uljjang-d46q0wn.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://mangak.net/moi-cap-nhat/"; }
        }

        public override string HostUrl
        {
            get { return "http://mangak.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://mangak.net/moi-cap-nhat/page/{0}/";

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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='update_image']/a[1]");
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

            var nodeHtml = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='entry-title']");

            //var match = Regex.Match(nodeHtml.InnerHtml, "<strong>(.*?)</strong>");
            //if (match != null)
            //{
            //    story.Name = match.Groups[1].Value;
            //}
            story.Name = nodeHtml.InnerText;
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='list_chapter']//a");
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
            get { return "[MangaK] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();
            var html = NetworkHelper.GetHtml(chapUrl);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='vung_doc']/img");
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
