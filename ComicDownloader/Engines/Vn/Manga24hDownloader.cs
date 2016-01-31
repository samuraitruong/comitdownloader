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
    [Downloader("Manga24.com", MenuGroup = "I->N", MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
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
            return base.GetListStoriesUnknowPages(this.ListStoryURL,
                "//a[@class='manga_name_update']",
                forceOnline,
                "//ul[@class='pagination']/li/a",null, this.HostUrl);
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
