using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("EatManga", MenuGroup = "English", MetroTab = "English", Language = "English", Image32 = "_1364410884_add1_")]
    public class EatMangaDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://cdn.eatmanga.com/media/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Eatmanga.com] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://eatmanga.com/Manga-Scan/"; }
        }

        public override string HostUrl
        {
            get { return "http://eatmanga.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories() { throw new NotImplementedException(); }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple(this.ListStoryURL,
                "//table[@id='updates']//th/a",
                forceOnline,
                this.HostUrl,
                singleListPage: true
            );
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl, "//h1", "//*[@id=\"updates\"]//th/a", this.HostUrl);
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chappter = null)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"eatmanga_image_big\"]");
            if (img == null)
                img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"eatmanga_image\"]");
            pageUrl = img.Attributes["src"].Value;


            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//select[@id='pages']/option",
                null,
                this.HostUrl,
                null,
                "value"
                );
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://eatmanga.com/latest/";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//th[@class=\"title\"]/a");

            foreach (HtmlNode node in nodes)
            {
                string chapterUrl = HostUrl + node.Attributes["href"].Value.Substring(0, node.Attributes["href"].Value.LastIndexOf("/"));
                string pageUrl = chapterUrl.Substring(0, chapterUrl.LastIndexOf("/"));
                StoryInfo info;

                if (stories.Any(p => p.Url == pageUrl))
                {
                    info = stories.Where(p => p.Url == pageUrl).Single();
                }
                else
                {
                    info = new StoryInfo()
                    {
                        Url = pageUrl,
                        Name = pageUrl.Substring(pageUrl.LastIndexOf("/") + 1).Replace("-", " "),
                        Chapters = new List<ChapterInfo>()
                    };

                    stories.Add(info);
                }

                var chapter = new ChapterInfo()
                {
                    Url = chapterUrl,
                    Name = node.InnerText.Trim().Trim()
                };

                info.Chapters.Add(chapter);
            }
            return stories;
        }

        //Use Google Search
    }
}
