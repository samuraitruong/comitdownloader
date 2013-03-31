using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaReader", MenuGroup = "English", Language = "English", Image32 = "1364078951_insert-object")]
    public class TenMangaDownloader : Downloader
    {
        public override string Name
        {
            get { return "[Ten Manga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.tenmanga.com/category/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.tenmanga.com"; }
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

                 var html = NetworkHelper.GetHtml(this.ListStoryURL);

                 HtmlDocument htmlDoc = new HtmlDocument();
                 htmlDoc.LoadHtml(html);

                 var catPages = htmlDoc.DocumentNode.SelectNodes("/html/body/div[2]//a[@href]");
                 foreach (var item in catPages)
                 {
                     string urlPattern = item.Attributes["href"].Value.Replace(".html", "_{0}.html");


                     int currentPage = 1;
                     bool isStillHasPage = true;
                     while (isStillHasPage)
                     {
                         string url = string.Format(urlPattern, currentPage);

                         var phtml = NetworkHelper.GetHtml(url);
                         HtmlDocument phtmlDoc = new HtmlDocument();
                         phtmlDoc.LoadHtml(phtml);

                         var nodes = phtmlDoc.DocumentNode.SelectNodes("//*[@class='intro']//h2/a");
                         if (nodes != null && nodes.Count > 0)
                         {
                             currentPage++;
                             foreach (var node in nodes)
                             {
                                 StoryInfo info = new StoryInfo()
                                 {
                                     Url =node.Attributes["href"].Value,
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
             }
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);
            
            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"cmtList\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Replace("Manga",""),
            };


            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"chapter_list\"]//td[1]/a");
            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url = HostUrl+ chapter.Attributes["href"].Value,
                    //ChapId = ExtractID(chapter.InnerText)
                };
                chap.ChapId = ExtractID(chap.Name);
                info.Chapters.Add(chap);
            }
            
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"comicpic\"]");
            pageUrl = img.Attributes["src"].Value;
            base.DownloadPage(pageUrl, filename, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

           // string patternUrl = chapUrl.Replace("/1/","{0}.html");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id='page']//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                string url = page.Attributes["value"].Value;
                results.Add(url);
            }
            return results;
        }
    }
}
