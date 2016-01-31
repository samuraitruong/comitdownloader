using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("Xomtruyentranh.con", Offline = false, MenuGroup = "U-Z", MetroTab="Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410887_Add")]
    public class XomTruyenDownloader
        : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://xomtruyentranh.com/skin/default/img/xomtruyen.png";
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
                return "http://xomtruyentranh.com/";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://xomtruyen.com/browse/";
            }

        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple(this.ListStoryURL, "//*[@id='maincol']/div[2]//span[1]/a[contains(@href,'http')]", forceOnline, singleListPage: true);
        }

        public override StoryInfo RequestInfo(string url)
        {
            return base.RequestInfoSimple(url, "//*[@id=\"mangainfo\"]//h3", "//*[@class=\"scroll-pane\"]//span[1]/a");       
        }
        public override string Name
        {
            get { return "[Xom Truyen] - "; }
        }
        //public override void DownloadPage(string pageUrl, string filename, string httpReferer)
        //{
        //    var html = NetworkHelper.GetHtml(pageUrl);
        //    HtmlDocument htmlDoc = new HtmlDocument();
        //    htmlDoc.LoadHtml(html);
        //    var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img[@class=\"1picture\"]");

        //    var url = "http://img.mangakung.com/read/"+imgNode.Attributes["src"].Value;

        //    base.DownloadPage(url, filename, httpReferer);
        //}
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//div[@class='breadcumb'][2]//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"leftcol\"]/div[@style]/div/li[position()=1]/a");

            foreach (HtmlNode node in nodes)
            {
                var chapterUrl = node.Attributes["href"].Value;
                var storyUrl = chapterUrl.Substring(0, chapterUrl.LastIndexOf("-chap"));

                StoryInfo info = new StoryInfo()
                {
                    Url = storyUrl,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };

                info.Chapters.Add(new ChapterInfo()
                {
                    Name = node.Attributes["title"].Value.Trim(),
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
                var urlPartern = string.Format("http://xomtruyen.com/{0}/", keyword.Replace(" ", "-"));

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
