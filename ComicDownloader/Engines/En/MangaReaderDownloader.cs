﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaReader", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaReaderDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://s2.mangareader.net/favicon.ico";
            }
        }

        public override string Name
        {
            get { return "[Manga Reader] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangareader.net/alphabetical"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangareader.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple(this.ListStoryURL,
                "//ul[@class='series_alpha']/li/a",
                forceOnline,
                this.HostUrl,
                singleListPage: true);

        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
               "//h1",
               "//table[@id='listing']//tr/td/a",
               chapterExtract: delegate (HtmlNode node)
               {
                   return new ChapterInfo()
                   {
                       Name = node.InnerText.Trim() + node.FirstChild.InnerText.Trim(),
                       Url = this.HostUrl + node.Attributes["href"].Value
                   };
               });
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var imgUrl = base.ExtractImage(pageUrl, "//div[@id='imgholder']/a/img");

            return base.DownloadPage(imgUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                  "//select[@id='pageMenu']/option", null, this.HostUrl, null, "value");
        }


        public override List<StoryInfo> GetLastestUpdates()
        {
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(this.HostUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"latestchapters\"]/table[1]//a[@class=\"chapter\"]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("a[@class='chaptersrec']");
                if (chapters != null)
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = HostUrl + chap.Attributes["href"].Value,
                        });
                    }
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.mangareader.net/search/?w={0}&rd=0&status=0&order=0&genre=0000000000000000000000000000000000000", keyword.Replace(" ", "+"));
            urlPattern = urlPattern + "&p={0}";

            var results = new List<StoryInfo>();

            //&p= so item da hien
            int currentPage = 1;
            int items = 0;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"manga_name\"]//h3/a");
                if (nodes != null && nodes.Count > 0)
                {

                    foreach (var node in nodes)
                    {

                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + node.Attributes["href"].Value,
                            Name = node.InnerText.Trim().Trim()
                        };
                        results.Add(info);
                    }
                }

                items = results.Count;
                currentPage++;
            }
            return results;
        }


    }
}
