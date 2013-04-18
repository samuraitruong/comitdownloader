using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("GoodManga", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class GoodMangaDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://w2.goodmanga.net/images/site/front/logo.png";
            }
        }

        public override string Name
        {
            get { return "[GoodManga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.goodmanga.net/manga-list"; }
        }

        public override string HostUrl
        {
            get { return "http://www.goodmanga.net/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL;

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
               
                    
                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"series_index\"]//a");
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
                

            }
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"right_col\"]/h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"chapters\"]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url =  chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
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
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='manga_viewer']/a/img");
            pageUrl = img.Attributes["src"].Value;

            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"page_select\"]//option[@value]");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(page.Attributes["value"].Value);
            }
            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@id=\"updates\"]//tr/td/div/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("ul/li/a");
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
            string urlPattern = string.Format("http://www.goodmanga.net/manga-search?key={0}", keyword.Replace(" ", "+"));
            urlPattern = urlPattern + "&page={0}";

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"series_list\"]/ul/li/div[@class=\"right_col\"]/h3/a");
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
    }
}
