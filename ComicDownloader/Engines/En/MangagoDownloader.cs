using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Mangago", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangagoDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.mangago.com/images/logo-chirstmas.png";
            }
        }
        public override string Name
        {
            get { return "[Mangago.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangago.com/list/directory/all"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangago.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "/{0}/";

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {
                    string url = string.Format(urlPattern, currentPage);

                    string html = NetworkHelper.GetHtml(url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"pic_list\"]/li/h3/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = node.Attributes["href"].Value,
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
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"manga_title\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"listing\"]//td[1]/h4/a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim().Trim(),
                    Url =  chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText.Trim())
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
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"page1\"]");
            pageUrl = img.Attributes["src"].Value;

            
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"page-mainer\"]/div[1]/div[2]/div[2]/select/option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(HostUrl+page.Attributes["value"].Value);
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"new_chapter\"]/ul/li[@class=\"updatesli\"]/span[@class=\"newchapter_title\"]/h3/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
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
            string urlPattern = string.Format("http://www.mangago.com/r/l_search/?{1}&name={0}", keyword.Replace(" ", "+"), "page={0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@id=\"search_list\"]/li//span[@class=\"tit\"]/h2/a");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        var storyUrl = node.Attributes["href"].Value;
                        var storyTitle = storyUrl.Substring(0, storyUrl.LastIndexOf("/"));
                        storyTitle = storyTitle.Substring(storyTitle.LastIndexOf("/") + 1).Replace("_", " ");

                        StoryInfo info = new StoryInfo()
                        {
                            Url = storyUrl,
                            Name = storyTitle.Trim()
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
