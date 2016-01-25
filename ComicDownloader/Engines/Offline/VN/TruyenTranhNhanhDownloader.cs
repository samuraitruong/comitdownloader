using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Truyentranhnhanh.com", Offline = true, Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "1364131990_document_add")]
    public class TruyenTranhNhanhDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyentranhnhanh.com/design/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Truyen Tranh Nhanh] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyentranhnhanh.com/comics/list/truyenmoi/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyentranhnhanh.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "{0}";

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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"list_search\"]//h3/a");
                                        
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (HtmlNode node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = node.Attributes["href"].Value,
                                Name = node.InnerText.Trim(),
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

            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mainle\"]//strong");



            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim()
            };

            var chapNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"manga_detail\"]//li//h3/a");

            foreach (HtmlNode node in chapNodes)
            {
                ChapterInfo chapInfo = new ChapterInfo()
                {
                    Name = node.InnerText.Trim().Trim(),
                    Url = node.Attributes["href"].Value.Trim(),
                    ChapId = ExtractID(node.InnerText.Trim().Trim())
                };
                
                info.Chapters.Add(chapInfo);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;

        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            var html = NetworkHelper.GetHtml(chapUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"imgw\"]//img");

            foreach (HtmlNode img in nodes)
            {
                pages.Add(img.Attributes["src"].Value);
            }
            
            return pages;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://truyentranhnhanh.com/comics/list/chapnew/1";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//article[@class=\"manga_updates\"]/dl/dt/div[@class=\"manga_info\"]/h3/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };

                var chapters = node.ParentNode.ParentNode.ParentNode.ParentNode.SelectNodes("dd//a");
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
            string urlPattern = string.Format("http://truyentranhnhanh.com/comics/timkiem/{1}/{0}", keyword.Replace(" ", "+"), "{0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"list_search\"]/ul/li/div[@class=\"manga_text\"]/div[@class=\"title\"]/h3/a");
                if (nodes != null && nodes.Count > 0)
                {

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

                currentPage++;
            }
            return results;
        }
    }
}
