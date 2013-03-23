﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ComicDownloader.Engines
{
    public class TruyenTranhTuanDownloader
        : Downloader
    {

        public override List<StoryInfo> GetListStories()
        {
            List<StoryInfo> results = new List<StoryInfo>();

            var html = NetworkHelper.GetHtml(this.ListStoryURL);

            string pattern = "<a class=\"ch-subject\" href=\"/(.+)/\" title=\"\">(.+)</a>";
            var matches = Regex.Matches(html, pattern);

            foreach (Match match in matches)
            {
                results.Add(new StoryInfo()
                {
                    UrlSegment = match.Groups[1].Value,
                    Name = match.Groups[2].Value,
                    Url = HostUrl + "/" + match.Groups[1].Value
                });
            }

            return results;
        }

        public override StoryInfo RequestInfo(string url)
        {
            StoryInfo info = new StoryInfo();

            // LockControl(false);
            //string url = string.Format(StoryUrlPattern, urlSegment);

            var html = NetworkHelper.GetHtml(url);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"fontsize-chitiet\"]/span[1]");
            info.Name = node.InnerText;
            var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"fontsize-chitiet\"]/span[2]");
            info.AltName = node2.InnerText;
            var node3 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"fontsize-chitiet\"]/span[2]");
            info.Categories = node3.InnerText;
            info.Url = url;

            var ccontentmain = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"content-main\"]");
            

            htmlDoc.LoadHtml(ccontentmain.InnerHtml);

            var chapterLinks = htmlDoc.DocumentNode.SelectNodes("//a[@href!='']");

            info.ChapterCount = chapterLinks.Count;
            foreach (HtmlNode item in chapterLinks)
            {

                ChapterInfo chapter = new ChapterInfo()
                {
                    Url = string.Format("{0}{1}doc-truyen/", HostUrl, item.Attributes["href"].Value),
                    Name = item.InnerText
                    ,
                    ChapId = 0

                };
                var match=Regex.Match(chapter.Name, @".*\s(\d*)$");
                if (match != null)
                {
                    int id = 0;
                    int.TryParse(match.Groups[1].Value, out id);
                    chapter.ChapId = id;
                }

                info.Chapters.Add(chapter);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();

            return info;
        }
        public override string StoryUrlPattern
        {
            get
            {
                return HostUrl + "/{0}/";
            }
            
        }
        public override string HostUrl
        {
            get
            {
                return "http://truyentranhtuan.com";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://truyentranhtuan.com/danh-sach-truyen/";
            }
            
        }
        public TruyenTranhTuanDownloader()
        {
            
        }
    }
}
