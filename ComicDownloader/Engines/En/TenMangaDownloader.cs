using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Ten Manga", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "1364078951_insert-object")]
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
            return base.GetListStoriesSimple("http://www.tenmanga.com/ajax/lastest/page-{0}",
                "//dd/a[position()=1]",
                forceOnline
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//div[@class='book-info']//h1[1]/b",
                "//ul[@class='chapter-box']/li/div[1]/a");
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var imgUrl = base.ExtractImage(pageUrl, "//div[@class='pic_box']//img");
            return base.DownloadPage(imgUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "(//div[@class='read-head' and position()])[1]//select[@class='sl-page']/option",
                null, 
                null, 
                null,
                "value"
                );
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
