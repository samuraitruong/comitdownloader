using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Webtruyen.com", Offline = true, MenuGroup = "VN" , MetroTab="Tiếng Việt", Language = "Tieng viet", Image32 = "1364131990_document_add")]
    public class WebTruyenDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://webtruyen.net/skin/default/img/emanga-logo-mini.png";
            }
        }

        public override string Name
        {
            get { return "[Web Truyen] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://webtruyen.net/browse/"; }
        }

        public override string HostUrl
        {
            get { return "http://webtruyen.net/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            List<StoryInfo> results = base.ReloadChachedData().Stories;
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'alt')]/span[1]/a");
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


            }

            this.SaveCache(results);
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
                Name = nameNode.InnerText.Trim().Trim()
            };

            var chapterLinks = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"manga_chapters\"]//span[1]/a");

            info.ChapterCount = chapterLinks.Count;
            foreach (HtmlNode item in chapterLinks)
            {

                ChapterInfo chapter = new ChapterInfo()
                {
                    Url = item.Attributes["href"].Value,
                    Name = item.InnerText.Trim()
                    ,
                    ChapId = ExtractID(item.InnerText.Trim(), @"Chapter (\d*)")

                };


                info.Chapters.Add(chapter);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();

            return info;
        }

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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"leftcol\"]//div[@onmouseover]/a");

            foreach (HtmlNode node in nodes)
            {
                var chapterUrl = node.Attributes["href"].Value;
                var storyUrl = chapterUrl.Substring(0, chapterUrl.LastIndexOf("/chap"));
                var chapterTitle = node.InnerText.Trim().Trim();
                var storyTitle = chapterTitle.Substring(0, chapterTitle.LastIndexOf("chap")).Trim();

                StoryInfo info = new StoryInfo()
                {
                    Url = storyUrl,
                    Name = storyTitle,
                    Chapters = new List<ChapterInfo>(),
                };

                info.Chapters.Add(new ChapterInfo()
                {
                    Name = chapterTitle,
                    Url = chapterUrl
                });
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var stories = new List<StoryInfo>();

            if (!string.IsNullOrEmpty(keyword))
            {
                var urlPartern = string.Format("http://webtruyen.net/{0}/", keyword.Replace(" ", "_"));

                string html = NetworkHelper.GetHtml(urlPartern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"mangainfo\"]");

                if (node != null)
                {
                    stories.Add(new StoryInfo() { Url = urlPartern, Name = keyword });
                }
            }

            return stories;
        }
    }
}
