using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Manga Koi", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "1364078951_insert-object")]
    public class MangaKoiDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.mangakoi.com/media/home/images/logo-r.png?v=001";
            }
        }

        public override string Name
        {
            get { return "[Manga Koi] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangakoi.com/latest"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangakoi.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://www.mangakoi.com/latest/{0}.html",
                "//p[@class='title']/a",
                forceOnline
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//ul[@class='detail-chlist']/li/a"
                , "");
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var imgUrl = base.ExtractImage(pageUrl, "//*[@id='viewer']//img");
            return base.DownloadPage(imgUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@class='mangaread-pagenav']/select/option",
                null, 
                null, null,
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
