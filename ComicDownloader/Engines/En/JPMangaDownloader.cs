﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("JPManga", MenuGroup = "Japan", Language = "English", Image32 = "_1364410887_Add")]
    public class JPMangaDownloader : Downloader
    {
        public override string Name
        {
            get { return "[JP Manga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.jpmanga.com/manga-directory/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.jpmanga.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {

            string urlPattern = "http://www.jpmanga.com/manga-directory-p{0}/"; 

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {
                    string url = string.Format(urlPattern, currentPage);

                    string html = NetworkHelper.GetHtml(url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"lvkbg2\"]//td[1]/a[@class=\"a_comicname\"]");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl + node.Attributes["href"].Value,
                                Name = node.InnerText.Trim()
                            };
                            results.Add(info);
                        }
                    }
                    else
                    {
                        isStillHasPage = false;
                    }

                }

            }
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[1]");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Replace("Comic Introduction", ""),
            };


            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"tempc\"]//td[1]/a[1]");
            foreach (HtmlNode chapter in chapterNodes)
            {
                if (string.IsNullOrEmpty(chapter.Attributes["href"].Value)) continue;
                ChapterInfo chap = new ChapterInfo()
                {
                    
                    Name =chapter.InnerText.Trim(),
                    Url = HostUrl+ chapter.Attributes["href"].Value,
                    //ChapId = ExtractID(chapter.InnerText)
                };
                chap.ChapId = ExtractID(chap.Name);
                info.Chapters.Add(chap);
            }
            
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
           
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class='pagelist']/option");
                List<string> results  = new List<string>();

            foreach (HtmlNode node in nodes)
            {
                
            }

            return results;
        }
    }
}
