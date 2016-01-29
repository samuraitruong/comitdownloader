using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("My Manga Online", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "1364078951_insert-object")]
    public class MyMangaOnlineDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://mymangaonline.net/images/logo.jpg";
            }
        }

        public override string Name
        {
            get { return "[My Manga Online] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://mymangaonline.net/manga-list/firstchar-special.html"; }
        }

        public override string HostUrl
        {
            get { return "http://mymangaonline.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesUnknowPages(this.ListStoryURL,
                "//div[@class='box-item ']/span/a",
                forceOnline,
                "", null,
                this.HostUrl,
                allLinksExtract: delegate(string html, HtmlDocument document)
                {
                    List<String> results = new List<string>();
                    var nodes = document.DocumentNode.SelectNodes("//div[@id='top-box-alpha']//ul/li[position()>4]/a");
                    var pages = document.DocumentNode.SelectNodes("//ul[@class='pagination-list']/li/a");
                    var totalsNodes = nodes.Cast<HtmlNode>().ToList();
                    if (pages != null)
                    {
                        totalsNodes.AddRange(pages.ToList());
                    }
                    results = totalsNodes.Select(p => this.HostUrl + p.Attributes["href"].Value).ToList();
                    return results;
                }
                );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@class='item-chapter']/a"
                , this.HostUrl);
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@id='divImage']//img"
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
