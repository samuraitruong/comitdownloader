using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("Xomtruyen.info", MenuGroup = "VN - 2" , MetroTab="Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410887_Add")]
    public class XomTruyenDownloader
        : Downloader
    {
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
                return "http://xomtruyen.com/";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://xomtruyen.com/browse/";
            }

        }

        public override List<StoryInfo> GetListStories()
        {
            List<StoryInfo> results = ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();
                var html = NetworkHelper.GetHtml(this.ListStoryURL);

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"maincol\"]/div[2]//span[1]/a[contains(@href,\"http\")]");
                

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
            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mangainfo\"]//h3");

            StoryInfo info = new StoryInfo()
            {
                Url = url,
                Name = nameNode.InnerText.Trim()
            };

            var chapterLinks = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"scroll-pane\"]//span[1]/a");

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
            get { return "[Xom Truyen] - "; }
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"leftcol\"]/div[@style]/div/li[position()=1]/a");

            foreach (HtmlNode node in nodes)
            {
                var chapterUrl = node.Attributes["href"].Value;
                var storyUrl = chapterUrl.Substring(0, chapterUrl.LastIndexOf("-chap"));

                StoryInfo info = new StoryInfo()
                {
                    Url = storyUrl,
                    Name = node.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };

                info.Chapters.Add(new ChapterInfo()
                {
                    Name = node.Attributes["title"].Value.Trim(),
                    Url = chapterUrl
                });
                stories.Add(info);
            }
            return stories;
        }
    }
}
