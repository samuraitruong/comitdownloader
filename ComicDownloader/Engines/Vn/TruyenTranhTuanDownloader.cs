using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenTranhTuan", Offline = false, Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "_1364410919_Add_Green_Button")]
    public class TruyenTranhTuanDownloader
        : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyentranhtuan.com/banner/banner-onepiece110720181938.jpg";
            }
        }

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
                return "http://truyentranhtuan.com";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://truyentranhtuan.com/danh-sach-truyen/";
            }

        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            List<StoryInfo> results = ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                var doc = base.GetParser(this.ListStoryURL);
                var nodes = doc.DocumentNode.SelectNodes("//span[@class='manga']/a");
               

                foreach (HtmlNode match in nodes)
                {
                    results.Add(new StoryInfo()
                    {
                        //UrlSegment = match.Groups[1].Value,
                        Url = match.Attributes["href"].Value,
                        Name = match.InnerText.Trim()
                    });
                }
            }
            SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string url)
        {
            StoryInfo info = new StoryInfo();

            // LockControl(false);
            //string url = string.Format(StoryUrlPattern, urlSegment);

            var html = NetworkHelper.GetHtml(url);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");
            info.Name = node.InnerText;
            //var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"fontsize-chitiet\"]/span[2]");
            //info.AltName = node2.InnerText;
            //var node3 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"fontsize-chitiet\"]/span[2]");
            //info.Categories = node3.InnerText;
            info.Url = url;

            //var ccontentmain = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"content-main\"]");
            

            //htmlDoc.LoadHtml(ccontentmain.InnerHtml);

            var chapterLinks = htmlDoc.DocumentNode.SelectNodes("//span[@class='chapter-name']/a");

            info.ChapterCount = chapterLinks.Count;
            foreach (HtmlNode item in chapterLinks)
            {

                ChapterInfo chapter = new ChapterInfo()
                {
                    Url = item.Attributes["href"].Value,
                    Name = item.InnerText,
                    ChapId = ExtractID(item.InnerText)

                };
               

                info.Chapters.Add(chapter);
            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();

            return info;
        }
        public override string Name
        {
            get { return "[Truyen Tranh Tuan] - "; }
        }
        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            //using (WebClient client = new WebClient())
            {
                string html = NetworkHelper.GetHtml(chapUrl);
                var match = Regex.Match(html, "var slides_page_url_path = \\[([^\\]]*)\\]");
                var arr = match.Groups[1].Value.Split(new char[] { '"', ',' }, StringSplitOptions.RemoveEmptyEntries);
                pages.AddRange(arr);
            }

            return pages;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"side-list\"]//td/a");

            foreach (HtmlNode node in nodes)
            {
                var chapUrl = HostUrl + node.Attributes["href"].Value;
                var storyUrl = chapUrl.Substring(0, chapUrl.LastIndexOf("/"));
                storyUrl = storyUrl.Substring(0, storyUrl.LastIndexOf("/"));

                var chapTitle = node.InnerText.Trim();
                chapTitle = chapTitle.Substring(chapTitle.LastIndexOf("]") + 1);
                var storyTitle = chapTitle.Substring(0, chapTitle.LastIndexOf(" "));

                StoryInfo info = new StoryInfo()
                {
                    Url = storyUrl ,
                    Name = storyTitle,
                    Chapters = new List<ChapterInfo>(),
                };

                info.Chapters.Add(new ChapterInfo()
                {
                    Name = chapTitle,
                    Url = chapUrl
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
                var urlPartern = string.Format("http://truyentranhtuan.com/{0}/", keyword.Replace(" ", "-"));

                string html = NetworkHelper.GetHtml(urlPartern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"fontsize-chitiet\"]");

                if (node != null)
                {
                    stories.Add(new StoryInfo() { Url = urlPartern, Name = keyword });
                }
            }

            return stories;
        }
    }
}
