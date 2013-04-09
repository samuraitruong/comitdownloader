using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaTraders", MenuGroup = "English - 2", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaTradersDownloader : Downloader
    {
        public override string Name
        {
            get { return "[MangaTraders] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangatraders.com/manga/serieslistext/all/page/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangatraders.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "{0}";

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
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

                    var urlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"footer bg9 leftBoxFtr\"]/p/a");
                    var titleNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"infoBox-title\"]/h2");
                    if (urlNodes != null && urlNodes.Count > 0)
                    {
                        currentPage++;

                        for(int i = 0; i < urlNodes.Count; i++)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl.Substring(0,HostUrl.Length-1) + urlNodes[i].Attributes["href"].Value,
                                Name = titleNodes[i].InnerText.Trim()
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"box2\"]/h2");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.FirstChild.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"files\"]//table[1]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url =  HostUrl.Substring(0,HostUrl.Length-1) + chapter.Attributes["href"].Value,
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
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='image_display']//a[1]/img");
            pageUrl = img.Attributes["src"].Value;

            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@name=\"page_top2\"]//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(chapUrl + "/page/" + page.Attributes["value"].Value);
            }
            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://www.mangatraders.com/releases/";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"dataTable\"]/table/tr[position()>1]/td[position()=3]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
                    Name = node.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("td[position()=5]/a");
                if (chapters != null)
                    foreach (HtmlNode chap in chapters)
                    {
                        var title = chap.ParentNode.ParentNode.SelectSingleNode("td[position()=2]");
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = title.FirstChild.InnerText.Trim(),
                            Url = HostUrl + chap.Attributes["href"].Value,
                        });
                    }
                stories.Add(info);
            }
            return stories;
        }
    }
}
