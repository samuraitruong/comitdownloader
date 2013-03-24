﻿#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ComicDownloader.Engines
{
    public class VechaiDownloader: Downloader
    {
        public override string ListStoryURL
        {
            get { return "http://vechai.info/danh-sach/"; }
        }

        public override string HostUrl
        {
            get { return "http://vechai.info"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            List<StoryInfo> stories = new List<StoryInfo>();

            if (stories != null && stories.Count == 0)
            {

                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                // There are various options, set as needed
                htmlDoc.OptionFixNestedTags = true;

                StringReader reader = new StringReader(html);
                // filePath is a path to a file containing the html
                htmlDoc.Load(reader);

                //if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
                //{
                //    // Handle any parse errors as required

                //}
                //else

                {

                    if (htmlDoc.DocumentNode != null)
                    {
                        var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='list-manga-paging']/span");

                        int count = nodes.Count;
                    #if DEBUG
                        count = 1;
                    #endif
                        foreach (var item in nodes.Take(count))
                        {
                            string requestListPage = string.Format("http://vechai.info/list.php?job=ajaxlist&letter=all&page={0}&sort=1", item.InnerText);
                            var pageHtml = NetworkHelper.GetHtml(requestListPage);

                            string regex = "<span class=\"item-number\">(\\d*)</span><a href=\"/([\\d\\w\\s_-]*)/\">(.*)</a>";

                            var matches = Regex.Matches(pageHtml, regex);
                            foreach (Match match in matches)
                            {
                                var story = new StoryInfo()
                                {
                                    Url = HostUrl + "/" + match.Groups[2].Value,

                                    Name = match.Groups[3].Value
                                };
                                stories.Add(story);

                            }
                        }
                    }
                }
                
            }
            return stories;
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

            var nodeHtml = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"vcfix\"]");

            var match = Regex.Match(nodeHtml.InnerHtml, "<strong>(.*?)</strong>");
            if (match != null)
            {
                story.Name = match.Groups[1].Value;
            }

            htmlDoc.LoadHtml(nodeHtml.InnerHtml);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//p/a");
            if (nodes != null)
                foreach (HtmlNode node in nodes)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.InnerText,
                        ChapId = ExtractID(node.InnerText)
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='entry2']/p/img");
            foreach (HtmlNode node in nodes)
            {
                pages.Add(node.Attributes["src"].Value);
            }
            return pages;
        }
    }
}
