using System; using System.Net;
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
                return "http://iweb2.mangapicgallery.com/images/logo-new-g.png";
            }
        }
        public override string Name
        {
            get { return "[Mangago.me] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangago.me/list/directory/all/"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangago.me/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple("http://www.mangago.me/list/directory/all/{0}/",
                "//ul[@class='pic_list']//li/h3/a",
                forceOnline);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//*[@id='chapter_table']//a"
                , string.Empty,
                null);
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chappter = null)
        {
            var url = base.ExtractImage(pageUrl, "//img[@id='page1']");
            return base.DownloadPage(url, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//ul[@id='dropdown-menu-page']/li/a",null, this.HostUrl, null, "href");
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
