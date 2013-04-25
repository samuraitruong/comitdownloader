using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ComicDownloader.Engines.En
{
    [Downloader("OneManga", MenuGroup = "English - 1", MetroTab = "English", Language = "English", Image32 = "_1364410906_add")]
    public class OneMangeDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.onemanga.me/css/img/onemanga_logo.png";
            }
        }

        public override string Name
        {
            get { return "[One Manga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.onemanga.me/manga-list/all/any/most-popular/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.onemanga.me"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "{0}/";

            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                int currentPage = 1;
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var paging = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"sct_content\"]//ul[@class=\"pgg\"]/li/a");

                if (paging != null && paging.Count > 0)
                {
                    var lastpageStr = paging.ToList()[paging.Count - 1].Attributes["href"].Value;
                    lastpageStr = lastpageStr.Substring(0, lastpageStr.Length - 1);
                    lastpageStr = lastpageStr.Substring(lastpageStr.LastIndexOf("/") + 1);
                    int lastPage = int.Parse(lastpageStr);

                    while (currentPage <= lastPage)
                    {
                        var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"wpm_pag mng_lst tbn\"]/div[contains(@class,\"nde\")]/div[@class=\"det\"]/a");

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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"wpm_pag mng_det\"]/h1[position()=1]").InnerText.Trim();

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode
            };

            var volumns = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"wpm_pag mng_det\"]/ul[@class=\"lst\"]/li/a");
            if (volumns != null)
            {
                foreach (HtmlNode item in volumns)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Name = item.Attributes["title"].Value.Trim(),
                        Url = item.Attributes["href"].Value,
                        ChapId = ExtractID(item.Attributes["title"].Value.Trim())
                    };
                    info.Chapters.Add(chap);
                }
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//img[@class=\"manga-page\"]");
            pageUrl = img.Attributes["src"].Value;
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"nav_pag\"]//select[@class=\"cbo_wpm_pag\"]/option");

            List<string> results = new List<string>();

            if (pages != null)
            {
                foreach (HtmlNode page in pages)
                {

                    results.Add(chapUrl + page.Attributes["value"].Value);
                }
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"wpm_pag mng_lts_chp grp\"]//div[@class=\"det\"]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.Attributes["alt"].Value.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };

                var chapters = node.ParentNode.SelectNodes("ul[@class=\"lst\"]/li/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.Attributes["title"].Value.Trim(),
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
            string urlPattern = string.Format("http://www.manga2u.me/list/search/{0}/name-az/{1}/", keyword.Replace(" ", "+"), "{0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"wpm_pag mng_lst tbn\"]/div[contains(@class,\"nde\")]/div[@class=\"det\"]/a");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        if (results.Any(p => p.Url == node.Attributes["href"].Value))
                        {
                            currentPage = Constant.LimitedPageForSearch;
                            break;
                        }

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
