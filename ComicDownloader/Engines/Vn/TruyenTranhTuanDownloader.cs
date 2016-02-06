using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenTranhTuan", Offline = false, Language = "Tieng viet", MenuGroup = "O->T", MetroTab = "Tiếng Việt", Image32 = "_1364410919_Add_Green_Button")]
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

        public override List<StoryInfo> HotestStories() { throw new NotImplementedException(); }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple(this.ListStoryURL,
                "//span[@class='manga']/a",
                forceOnline, singleListPage: true);
        }

        public override StoryInfo RequestInfo(string url)
        {
            return base.RequestInfoSimple(url, "//h1[@itemprop='name']", "//span[@class='chapter-name']/a");
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

                var chapTitle = node.InnerText.Trim().Trim();
                chapTitle = chapTitle.Substring(chapTitle.LastIndexOf("]") + 1);
                var storyTitle = chapTitle.Substring(0, chapTitle.LastIndexOf(" "));

                StoryInfo info = new StoryInfo()
                {
                    Url = storyUrl,
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
