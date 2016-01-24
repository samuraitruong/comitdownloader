using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("Manga89", Offline = false, Language = "Tieng viet", MenuGroup = "VN - 2" , MetroTab="Tiếng Việt", Image32 = "_1364410884_add1_")]
    public class Manga89Downloader
        : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.manga89.com/files/banner.png";
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
                return "http://www.manga89.com/";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://www.manga89.com/directory/";
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
            get { return "[Manga 89] - "; }
        }
        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img[@class=\"1picture\"]");

            var url = "http://img.manga89.com/read/"+ imgNode.Attributes["src"].Value;

            return base.DownloadPage(url, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            
                string html = NetworkHelper.GetHtml(chapUrl);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var options = htmlDoc.DocumentNode.SelectNodes("//select[@name=\"page\"]//option");
                //var paged = htmlDoc.DocumentNode.SelectSingleNode("//select[@name='chapter']/option[@selected='selected']");
                //if(paged.InnerText == "End")
                //{
                    
                //}
                foreach (var item in options)
	            {
                    pages.Add(chapUrl + item.Attributes["value"].Value);
	            }
            

            return pages;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.Manga89.com/page/{1}/?s={0}", keyword.Replace(" ", "+"), "{0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"maincontent\"]/div[@class=\"galleryitem\"]/h3/a");
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

                currentPage++;
            }
            return results;
        }

        //Ko co lastest update
    }
}
