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
    [Downloader("Manga4Vn.com", MenuGroup = "I->N", MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410881_plus_32")]
    public class Manga4VNDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://manga4vn.com/wp-content/themes/webtruyen24h/images/logo.png";
            }
        }
        public override string ListStoryURL
        {
            get { return "http://manga4vn.com/truyen-moi-dang"; }
        }

        public override string HostUrl
        {
            get { return "http://manga4vn.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://manga4vn.com/truyen-moi-dang/page/{0}";

            return base.GetListStoriesSimple(urlPattern,
                "//ul[@class='homeListstory']/li/h3/a",
                forceOnline);
        }


        public override StoryInfo RequestInfo(string url)
        {
            
            var html = NetworkHelper.GetHtml(url);

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodeHtml = htmlDoc.DocumentNode.SelectSingleNode("//h1/a");
            StoryInfo story = new StoryInfo()
            {
                Url = url,
                Name = nodeHtml.InnerText.Trim().Trim()
            };
            //var match = Regex.Match(nodeHtml.InnerHtml, "<strong>(.*?)</strong>");
            //if (match != null)
            //{
            //    story.Name = match.Groups[1].Value;
            //}

            //htmlDoc.LoadHtml(nodeHtml.InnerHtml);
            //var matches = Regex.Matches("<table class="table chapt - table"[^>]*>[\s\S]*?<\/table>")
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'detailStory-table')]/table//a");
            if (nodes != null)
                foreach (HtmlNode node in nodes)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Url = node.Attributes["href"].Value,
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
            get { return "[Manga 4VN] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();
            var html = NetworkHelper.GetHtml(chapUrl);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='content']//img");
            foreach (HtmlNode item in nodes)
            {
                pages.Add(item.Attributes["src"].Value);
            }
            return pages;
        }

        //Lastest Update chi show story, thong co link chapter moi nhat

        //Use google search
    }
}
