﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenTranhTuan", Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "_1364410919_Add_Green_Button")]
    public class TruyenTranhTuanDownloader
        : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyentranhtuan.com/banner/banner-onepiece110720181938.jpg";
            }
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

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            List<StoryInfo> results = ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
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
            }
            SaveCache(results);
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
                    ChapId = ExtractID(item.InnerText)

                };
               

                info.Chapters.Add(chapter);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();

            return info;
        }
        public override string Name
        {
            get { return "[Truyen Tranh Tuan] - "; }
        }
        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString(chapUrl);
                var matches = Regex.Matches(html, @"/manga/[0-9a-zA-Z//s-]*(?:.png|.jpg|.PNG|.JPG)");
                pages = matches.Cast<Match>()
                    .OrderBy(p => p.Value)
                    .Select(p => this.HostUrl+p.Value)
                    .ToList();
            }

            return pages;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"side-list\"]//td/a");

            foreach (HtmlNode node in nodes)
            {
                var chapUrl = HostUrl + node.Attributes["href"].Value;
                var storyUrl = chapUrl.Substring(0, chapUrl.LastIndexOf("/"));
                storyUrl = storyUrl.Substring(0, storyUrl.LastIndexOf("/"));

                var chapTitle = node.InnerText.Trim();
                chapTitle = chapTitle.Substring(chapTitle.LastIndexOf("]") + 1);
                var storyTitle = chapTitle.Substring(0, chapTitle.LastIndexOf(" "));

                StoryInfo info = new StoryInfo()
                {
                    Url = storyUrl ,
                    Name = storyTitle,
                    Chapters = new List<ChapterInfo>(),
                };

                info.Chapters.Add(new ChapterInfo()
                {
                    Name = chapTitle,
                    Url = chapUrl
                });

                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var stories = new List<StoryInfo>();

            if (!string.IsNullOrEmpty(keyword))
            {
                var urlPartern = string.Format("http://truyentranhtuan.com/{0}/", keyword.Replace(" ", "-"));

                string html = NetworkHelper.GetHtml(urlPartern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"fontsize-chitiet\"]");

                if (node != null)
                {
                    stories.Add(new StoryInfo() { Url = urlPartern, Name = keyword });
                }
            }

            return stories;
        }
    }
}
