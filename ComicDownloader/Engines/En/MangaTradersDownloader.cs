using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    //TODO : Offline , require loging
    [Downloader("Manga Traders", Offline =true, MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaTradersDownloader : Downloader
    {
        

        public override string Name
        {
            get { return "[Manga Traders] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://mangatraders.org/directory/"; }
        }

        public override string HostUrl
        {
            get { return "http://mangatraders.org"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple(this.ListStoryURL,
                "//p[@class='seriesList']/a",
                forceOnline,
                this.HostUrl);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1", ""
                );
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='image_display']//a[1]/img");
            pageUrl = img.Attributes["src"].Value;

            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@name=\"page_top2\"]//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(chapUrl + "/page/" + page.Attributes["value"].Value);
            }
            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://www.mangatraders.com/releases/";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"dataTable\"]/table/tr[position()>1]/td[position()=3]/a");

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    StoryInfo info = new StoryInfo()
                    {
                        Url = HostUrl + node.Attributes["href"].Value,
                        Name = node.InnerText.Trim().Trim(),
                        Chapters = new List<ChapterInfo>(),
                    };
                    var chapters = node.ParentNode.ParentNode.SelectNodes("td[position()=5]/a");
                    if (chapters != null)
                    {
                        foreach (HtmlNode chap in chapters)
                        {
                            var title = chap.ParentNode.ParentNode.SelectSingleNode("td[position()=2]");
                            info.Chapters.Add(new ChapterInfo()
                            {
                                Name = title.FirstChild.InnerText.Trim().Trim(),
                                Url = HostUrl + chap.Attributes["href"].Value,
                            });
                        }
                    }
                    stories.Add(info);
                }
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.mangatraders.com/search/?term={0}&searchSeries=1&showOnlySeries=1", keyword.Replace(" ", "+"));

            var results = new List<StoryInfo>();

            string html = NetworkHelper.GetHtml(urlPattern);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"list1\"]/li/a");
            //Ket qua search hien thi tren cung 1 trang, chi lay 200 item
            int count = 0;

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if (count <= 200)
                    {
                        string title = string.Empty;
                        foreach (HtmlNode n in node.ChildNodes)
                        {
                            title += n.InnerText.Trim().Trim() + " ";
                        }

                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl.Substring(0, HostUrl.LastIndexOf("/")) + node.Attributes["href"].Value,
                            Name = title
                        };
                        results.Add(info);

                        count++;
                    }
                }
            }
            return results;
        }
    }
}
