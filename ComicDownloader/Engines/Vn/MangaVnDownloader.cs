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
    [Downloader("MangaVn.com", MenuGroup = "VN - 2", MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
    public class MangaVnDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://i39.servimg.com/u/f39/18/97/06/08/logotr12.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://www.mangavn.net/f3-danh-sach-truyen"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangavn.net/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            var queue = new Queue<string>();
            queue.Enqueue(this.ListStoryURL);
            List<string> visitedLinks = new List<string>();
            visitedLinks.Add(this.ListStoryURL);

            List<StoryInfo> results = base.ReloadChachedData();

            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
                while (queue.Count>0)
                {
                    var url = queue.Dequeue();

                    string html = NetworkHelper.GetHtml(url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='blog_message']/span/a");
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

                    //get navigation page
                    var paging = htmlDoc.DocumentNode.SelectNodes("//p[@class='paging']//a[contains(@href,'f3p')]");
                    foreach (HtmlNode p in paging)
                    {
                        var nextUrl = this.HostUrl + p.Attributes["href"].Value;
                        if(!visitedLinks.Contains(nextUrl))
                        {
                            queue.Enqueue(nextUrl);
                            visitedLinks.Add(nextUrl);
                        }
                    }
                }

            }
            this.SaveCache(results);
            return results;
        }


        public override StoryInfo RequestInfo(string url)
        {
            
            var html = NetworkHelper.GetHtml(url);

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodeHtml = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='truyen_Content']//h2");
            StoryInfo story = new StoryInfo()
            {
                Url = url,
                Name = nodeHtml.InnerText.Trim()
            };
            //var match = Regex.Match(nodeHtml.InnerHtml, "<strong>(.*?)</strong>");
            //if (match != null)
            //{
            //    story.Name = match.Groups[1].Value;
            //}

            //htmlDoc.LoadHtml(nodeHtml.InnerHtml);
            //var matches = Regex.Matches("<table class="table chapt - table"[^>]*>[\s\S]*?<\/table>")
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class='listing']//a");
            if (nodes != null)
                foreach (HtmlNode node in nodes)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.InnerText.Trim(),
                        ChapId = ExtractID(node.InnerText.Trim())
                    };

                    story.Chapters.Add(chap);
                }
            story.Chapters = story.Chapters.OrderBy(p => p.ChapId).ToList();
            return story;
        }

        public override string Name
        {
            get { return "[Manga VN] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,"//div[@class='img_truyen']//img");
        }
        
    }
}
