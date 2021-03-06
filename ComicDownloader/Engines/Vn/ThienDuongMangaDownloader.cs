﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("ThienDuongManga.com", MenuGroup = "VN - 2" , MetroTab="Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410887_Add")]
    public class ThienDuongMangaDownloader
        : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://thienduongmanga.com/views/css/thien-duong-manga.jpg";
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
                return "http://thienduongmanga.com";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://thienduongmanga.com/danh-sach-truyen";
            }

        }
         
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            List<StoryInfo> results = ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                var html = NetworkHelper.GetHtml(this.ListStoryURL);

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"divRow\"]/div[1]/a");

                if (nodes != null)
                {
                    foreach (HtmlNode node in nodes)
                    {
                        results.Add(new StoryInfo()
                        {

                            Name = node.InnerText.Trim(),
                            Url = HostUrl + node.Attributes["href"].Value
                        });
                    }
                }
            }
            SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string url)
        {
         
            var html = NetworkHelper.GetHtml(url);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"content-main-chapter\"]//a");

            StoryInfo info = new StoryInfo()
            {
                Url = url,
                Name = nameNode.FirstChild.InnerText.Trim()
            };

            var chapterLinks = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"divRow\"]//dev[1]/a");

            info.ChapterCount = chapterLinks.Count;
            foreach (HtmlNode item in chapterLinks)
            {

                ChapterInfo chapter = new ChapterInfo()
                {
                    Url = HostUrl+ item.Attributes["href"].Value,
                    Name = item.InnerText
                    ,
                    ChapId = ExtractID(item.InnerText,@"Chap (\d*)")

                };
               

                info.Chapters.Add(chapter);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();

            return info;
        }
        public override string Name
        {
            get { return "[Thien Duong Manga] - "; }
        }
        //public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        //{
        //    var html = NetworkHelper.GetHtml(pageUrl);
        //    HtmlDocument htmlDoc = new HtmlDocument();
        //    htmlDoc.LoadHtml(html);
        //    var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img[@class=\"1picture\"]");

        //    var url = "http://img.mangakung.com/read/"+imgNode.Attributes["src"].Value;

        //    base.DownloadPage(url, filename, httpReferer);
        //}
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

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"slide4hinh\"]//div[@class=\"tentruyen\"]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("div[@class=\"sochap\"]/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim(),
                            Url = chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }

            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var stories = new List<StoryInfo>();

            if (!string.IsNullOrEmpty(keyword))
            {
                var urlPartern = string.Format("http://thienduongmanga.com/truyen/{0}", keyword.Replace(" ", "_"));

                string html = NetworkHelper.GetHtml(urlPartern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"divTable\"]");

                if (node != null)
                {
                    stories.Add(new StoryInfo() { Url = urlPartern, Name = keyword });
                }
            }

            return stories;
        }
    }
}
