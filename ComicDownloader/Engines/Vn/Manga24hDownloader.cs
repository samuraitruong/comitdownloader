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
    [Downloader("Manga24.com", MenuGroup = "VN - 2", MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
    public class Manga24hDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://vechai.info/template/teen9x/images/logo.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://manga24h.com/danhsach"; }
        }

        public override string HostUrl
        {
            get { return "http://manga24h.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            List<StoryInfo> results = ReloadChachedData().Stories;
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                // There are various options, set as needed
                htmlDoc.OptionFixNestedTags = true;

                StringReader reader = new StringReader(html);
                // filePath is a path to a file containing the html
                htmlDoc.Load(reader);
                if (htmlDoc.DocumentNode != null)
                {
                    var nodes = htmlDoc.DocumentNode.SelectSingleNode("//ul[@class='pagination']/li/span");

                    var innertText = nodes.InnerText.Trim();
                    var count = Convert.ToInt32(Regex.Match(innertText, @"\d+").Value);

                    foreach (var item in Enumerable.Range(1, count))
                    {
                        string requestListPage = this.ListStoryURL + (item == 1 ? "" : "/" + item.ToString());

                        var pageHtml = NetworkHelper.GetHtml(requestListPage);

                        //HtmlAgilityPack.HtmlDocument htmlDoc1 = new HtmlAgilityPack.HtmlDocument();

                        // There are various options, set as needed
                       // htmlDoc.OptionFixNestedTags = true;

                        //StringReader reader1 = new StringReader(html);
                        //html = Regex.Replace(html, @"<head[^>]*>[\s\S]*?<\/head>", string.Empty);
                        // filePath is a path to a file containing the html
                        //htmlDoc1.Load(reader);
                        //var list = htmlDoc1.DocumentNode.SelectNodes("//a[@class='manga_name_update']");

                        //var links = htmlDoc1.DocumentNode
                        //.Descendants("a")
                        //.Where(tr => tr.GetAttributeValue("class", "").Contains("manga_name_update"))
                        //.SelectMany(tr => tr.Descendants("a"))
                        //.ToList();
                        var matches = Regex.Matches(pageHtml, "<a class=\"manga_name_update\"[^>]*>[\\s\\S]*?<\\/a>");

                        foreach (Match match in matches)
                        {
                            htmlDoc.LoadHtml(match.Value);
                            var story = new StoryInfo()
                            {
                                Url = HostUrl + "/" + htmlDoc.DocumentNode.FirstChild.Attributes["href"].Value,
                                Name = htmlDoc.DocumentNode.FirstChild.InnerText.Trim().Trim()
                            };
                            results.Add(story);
                        }
                    }
                }
            }
            SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string url)
        {
            
            var html = NetworkHelper.GetHtml(url);

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodeHtml = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='manga-detail-info']/h1");
            StoryInfo story = new StoryInfo()
            {
                Url = url,
                Name = nodeHtml.InnerHtml
            };
            //var match = Regex.Match(nodeHtml.InnerHtml, "<strong>(.*?)</strong>");
            //if (match != null)
            //{
            //    story.Name = match.Groups[1].Value;
            //}

            //htmlDoc.LoadHtml(nodeHtml.InnerHtml);
            //var matches = Regex.Matches("<table class="table chapt - table"[^>]*>[\s\S]*?<\/table>")
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class='table chapt-table']//tr/td/a");
            if (nodes != null)
                foreach (HtmlNode node in nodes)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Url = this.HostUrl+"/" +node.Attributes["href"].Value,
                        Name = node.InnerText.Trim().Trim(),
                        ChapId = ExtractID(node.InnerText.Trim().Trim())
                    };

                    story.Chapters.Add(chap);
                }
            story.Chapters = story.Chapters.OrderBy(p => p.ChapId).ToList();
            return story;
        }

        public override string Name
        {
            get { return "[Manga 24H] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();
            var html = NetworkHelper.GetHtml(chapUrl);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='chapcontent']/div/img");
            if (nodes == null)
            {
                //var text = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"vcfix\"]");
                //htmlDoc.LoadHtml(text.InnerHtml);
                //nodes = htmlDoc.DocumentNode.SelectNodes("//img");
            }
            var match = Regex.Match(html, "data='([^']*)'");
            var urls = match.Groups[1].Value.Split('|');
            //foreach (HtmlNode node in nodes)
            //{
            //    pages.Add(node.Attributes["src"].Value);
            //}
            return urls.ToList();
        }

        //Lastest Update chi show story, thong co link chapter moi nhat

        //Use google search
    }
}
