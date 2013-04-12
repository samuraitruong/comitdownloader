using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Comic.Vuilen.com", Language="Tieng viet", MenuGroup = "VN - 2" , MetroTab="Tiếng Việt", Image32 = "_1364410884_add1_")]
    public class ComicVuiLenDownloader : Downloader
    {
        public override string Name
        {
            get { return "[Comic Vui Len] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://comic.vuilen.com/"; }
        }

        public override string HostUrl
        {
            get { return "http://comic.vuilen.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { return string.Empty; }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "{0}";

            List<StoryInfo> results = base.ReloadChachedData();

            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();


                string html = NetworkHelper.GetHtml(this.ListStoryURL);

                
                string p = "<option value='([^>]*)'>([^<]*)</option>";

                var matches = Regex.Matches(html, p);

                if (matches != null && matches.Count > 0)
                {

                    foreach (Match m in matches)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl+m.Groups[1].Value,
                            Name = m.Groups[2].Value,
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

            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var table = htmlDoc.DocumentNode.SelectNodes("//td[@class=\"page\"]/table[@class=\"tborder\"]")[1];

            htmlDoc.LoadHtml(table.OuterHtml);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//b");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Substring(0,nameNode.InnerText.IndexOf("-"))
            };

            var chapNodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href,'view_book_detail')]");

            foreach (HtmlNode node in chapNodes)
            {
                ChapterInfo chapInfo = new ChapterInfo()
                {
                    //Name = node.InnerText.Trim(),
                    Url = HostUrl+ node.Attributes["href"].Value.Trim(),
                    //ChapId = ExtractID(node.InnerText.Trim())
                };
                var t = node.ParentNode.ParentNode.ParentNode.NextSibling.NextSibling.NextSibling.NextSibling;
                chapInfo.Name = t.InnerText.Trim();
                chapInfo.ChapId = ExtractID(t.InnerText.Trim(), @"tap([\d]*)");
                info.Chapters.Add(chapInfo);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;

        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            var html = NetworkHelper.GetHtml(chapUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"imgw\"]//img");

            foreach (HtmlNode img in nodes)
            {
                pages.Add(img.Attributes["src"].Value);
            }
            
            return pages;
        }
    }
}
