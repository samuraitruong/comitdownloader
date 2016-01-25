using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("TenManga", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "1364078951_insert-object")]
    public class TenMangaDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.tenmanga.com/files/img/logo.gif";
            }
        }

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

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
             List<StoryInfo> results = base.ReloadChachedData();
             if (results == null || results.Count == 0 || forceOnline)
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
                                     Name = node.InnerText.Trim().Trim()
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
                Name = nameNode.InnerText.Trim().Trim().Replace("Manga",""),
            };


            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"chapter_list\"]//td[1]/a");
            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim().Trim(),
                    Url = HostUrl+ chapter.Attributes["href"].Value,
                    //ChapId = ExtractID(chapter.InnerText.Trim())
                };
                chap.ChapId = ExtractID(chap.Name);
                info.Chapters.Add(chap);
            }
            
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"comicpic\"]");
            pageUrl = img.Attributes["src"].Value;
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
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

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://www.tenmanga.com/list/New-Update/";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"clistChr\"]/ul/li/div[@class=\"intro\"]/h2/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("span/a[position()=1]");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.FirstChild.InnerText.Trim().Trim(),
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
            string urlPattern = string.Format("http://search.tenmanga.com/list/?wd={0}", keyword.Replace(" ", "+"));
            urlPattern = urlPattern + "&page={0}.html";

            var results = new List<StoryInfo>();
            
            int currentPage = 1;
            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"search_list\"]/ul/li/div[@class=\"intro\"]/h2/a");
                if (nodes != null && nodes.Count > 0)
                {

                    foreach (var node in nodes)
                    {

                        StoryInfo info = new StoryInfo()
                        {
                            Url = node.Attributes["href"].Value,
                            Name = node.Attributes["title"].Value.Trim()
                        };
                        results.Add(info);
                    }
                }
                currentPage++;
            }
            return results;
        }
    }
}
