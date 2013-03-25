using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    public class MangaKungDownloader
        : Downloader
    {

        public override List<StoryInfo> GetListStories()
        {
            List<StoryInfo> results = ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();
                var html = NetworkHelper.GetHtml(this.ListStoryURL);

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"ddsg-wrapper\"]/ul/li[1]/ul/li/a");
                

                foreach (HtmlNode node in nodes)
                {
                    results.Add(new StoryInfo()
                    {
                        
                        Name = node.InnerText.Trim(),
                        Url = node.Attributes["href"].Value
                    });
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
            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"postcontent\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = url,
                Name = nameNode.InnerText.Trim()
            };

            var chapterLinks = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"postcontent\"]//a[contains(@href,'http://img')]");

            info.ChapterCount = chapterLinks.Count;
            foreach (HtmlNode item in chapterLinks)
            {

                ChapterInfo chapter = new ChapterInfo()
                {
                    Url = item.Attributes["href"].Value,
                    Name = item.InnerText
                    ,
                    ChapId = ExtractID(item.InnerText,@"Chapter (\d*)")

                };
               

                info.Chapters.Add(chapter);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();

            return info;
        }
        public override string Name
        {
            get { return "[Manga Kung] - "; }
        }
        public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img[@class=\"1picture\"]");

            var url = imgNode.Attributes["src"].Value;

            base.DownloadPage(url, filename, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            
                string html = NetworkHelper.GetHtml(chapUrl);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var options = htmlDoc.DocumentNode.SelectNodes("//select[@name=\"page\"]//option");

                foreach (var item in options)
	            {
                    pages.Add(chapUrl + item.Attributes["value"].Value);
	            }
            

            return pages;
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
                return "http://www.mangakung.com/";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://www.mangakung.com/directory/";
            }
            
        }
        public MangaKungDownloader()
        {
            
        }
    }
}
