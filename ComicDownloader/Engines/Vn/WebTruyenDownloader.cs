﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Webtruyen.com", Category = "VN", Image32 = "1364131990_document_add")]
    public class WebTruyenDownloader : Downloader
    {
        public override string Name
        {
            get { return "[Web Truyen] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://webtruyen.net/browse/"; }
        }

        public override string HostUrl
        {
            get { return "http://webtruyen.net/"; }
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

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'alt')]/span[1]/a");
                if (nodes != null && nodes.Count > 0)
                {

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


            }

            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string url)
        {

            var html = NetworkHelper.GetHtml(url);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mangainfo\"]//h3");

            StoryInfo info = new StoryInfo()
            {
                Url = url,
                Name = nameNode.InnerText.Trim()
            };

            var chapterLinks = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"manga_chapters\"]//span[1]/a");

            info.ChapterCount = chapterLinks.Count;
            foreach (HtmlNode item in chapterLinks)
            {

                ChapterInfo chapter = new ChapterInfo()
                {
                    Url = item.Attributes["href"].Value,
                    Name = item.InnerText
                    ,
                    ChapId = ExtractID(item.InnerText, @"Chapter (\d*)")

                };


                info.Chapters.Add(chapter);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();

            return info;
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();


            string html = NetworkHelper.GetHtml(chapUrl);
            var p = "var images = \\[(.*)\\]";
            var match = Regex.Match(html, p);
            var arr = match.Groups[1].Value.Split("',".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            pages.AddRange(arr);

            return pages;
        } 

       
    }
}
