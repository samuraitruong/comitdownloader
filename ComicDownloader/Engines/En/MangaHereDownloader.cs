using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Manga Here", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410898_file_add")]
    public class MangaHereDownloader :  Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.mangahere.com/favicon32.ico";
            }
        }

        public override string Name
        {
            get { return "[Manga Here] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangahere.co/mangalist"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangahere.co"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }


       public override List<StoryInfo> GetListStories(bool forceOnline)            
        {
            return base.GetListStoriesSimple(this.ListStoryURL,
                "//a[@class='manga_info']",
                forceOnline,
                string.Empty);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@class='detail_list']//ul/li/span/a");
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chappter = null)
        {
            var img = base.ExtractImage(pageUrl,"//*[@id=\"viewer\"]//img[2]");
            return base.DownloadPage(img, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//*[@class='readpage_top']//span[@class='right']//select/option", imgAttrName: "value");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"manga_updates\"]//dt/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("dd/a");
                if (chapters != null)
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = chap.Attributes["href"].Value,
                        });
                    }
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.mangahere.com/search.php?name={0}", keyword.Replace(" ", "+"));
            urlPattern = urlPattern + "&page={0}";

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"result_search\"]/dl/dt/a[position()=1]");
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

        public override List<StoryInfo> HotestStories()
        {
            throw new NotImplementedException();
        }
    }
}
