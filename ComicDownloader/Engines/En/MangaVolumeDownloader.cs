using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaVolume", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaVolumeDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.mangavolume.com/templates/mangavolume/images/logo.jpg";
            }
        }

        public override string Name
        {
            get { return "[MangaVolume] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangavolume.com/manga-archive/mangas"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangavolume.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            string urlPattern = this.ListStoryURL;
            return base.GetListStoriesUnknowPages(urlPattern,
                "//table[@id='MostPopular']//tr/td/a", 
                forceOnline,
                "//div[@id='NavigationPanel']/ul/li/a",
                null,
                this.HostUrl);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//div[@class='StarsBlock']/h1",
                "//table[@id='MainList']//tr/td[1]/a",
                this.HostUrl);
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var imgUrl = base.ExtractImage(pageUrl, "//td[@align='center']/a/img[@title]");

            return base.DownloadPage(imgUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//select[@id='pages']/option",
                null,
                this.HostUrl,
                null,
                "value");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//fieldset[@class=\"most most_latest\"]/table//tr/td/a");

            foreach (HtmlNode node in nodes)
            {
                string chapterUrl = HostUrl + node.Attributes["href"].Value;
                string pageUrl = HostUrl + "/serie-archive/mangas-" + node.Attributes["href"].Value.Substring(1, node.Attributes["href"].Value.LastIndexOf("/"));
                var chapterTitle = node.ChildNodes[2].InnerText.Trim().Trim();
                StoryInfo info;

                if (stories.Any(p => p.Url == pageUrl))
                {
                    info = stories.Where(p => p.Url == pageUrl).Single();
                }
                else
                {
                    var pageTitle = chapterTitle.Substring(0, chapterTitle.LastIndexOf(' '));
                    info = new StoryInfo()
                    {
                        Url = pageUrl,
                        Name = pageTitle,
                        Chapters = new List<ChapterInfo>()
                    };

                    stories.Add(info);
                }

                var chapter = new ChapterInfo()
                {
                    Url = chapterUrl,
                    Name = chapterTitle
                };

                info.Chapters.Add(chapter);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.mangavolume.com/manga-archive/mangas/search-{0}/", keyword.Replace(" ", string.Empty));

            var results = new List<StoryInfo>();

            int currentPage = 1;
            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = urlPattern;
                if (currentPage > 1)
                {
                    url = url + "npage-{0}";
                    url = string.Format(url, currentPage);
                }

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@id=\"MostPopular\"]//tr/td/a");
                if (nodes != null && nodes.Count > 0)
                {

                    foreach (var node in nodes)
                    {

                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + node.Attributes["href"].Value,
                            Name = node.ChildNodes[2].InnerText.Trim().Trim()
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
