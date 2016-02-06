using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Manga Park", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "1364150669_folder_add")]
    public class MangaParkDownloader :  Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://h.s.mangapark.me/img/logo.png";
            }
        }

        public override string Name
        {
            get { return "[MangaPark] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://mangapark.me/genre"; }
        }

        public override string HostUrl
        {
            get { return "http://mangapark.me"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple("http://mangapark.me/genre/{0}",
                "//ul/h3/a",
                forceOnline,
                this.HostUrl);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//ul[@class='chapter']/li",
                chapterExtract:delegate(HtmlNode node) {
                    return new ChapterInfo()
                    {
                        Name = node.Descendants("A").First().InnerText + node.Descendants("A").First().NextSibling.InnerText,
                        Url = this.HostUrl+node.Descendants("A").Last().Attributes["href"].Value
                    };
                });
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            //var html = NetworkHelper.GetHtml(pageUrl);
            //HtmlDocument htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(html);
            //var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"image\"]//img");
            //pageUrl = img.Attributes["src"].Value;
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//a[@class='img-link']/img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"cnt\"]/div[@class=\"text\"]/span[@class=\"title\"]/a[position()=1]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("a[position()>1]");
                if (chapters != null)
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = HostUrl + chap.Attributes["href"].Value,
                        });
                    }
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.mangapark.com/search?name={0}", keyword.Replace(" ", "+"));
            urlPattern = urlPattern + "&page={0}";

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"main\"]//div[@class=\"item\"]//a[@class=\"title\"]");
                if (nodes != null && nodes.Count > 0)
                {

                    foreach (var node in nodes)
                    {

                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + node.Attributes["href"].Value,
                            Name = node.Attributes["title"].Value.Trim()
                        };
                        results.Add(info);
                    }
                }

                currentPage ++;
            }
            return results;
        }
    }
}
