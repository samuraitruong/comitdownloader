using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Tuoi Tre Nang Dong", Offline = false, Language = "Tieng viet", MenuGroup = "O->T", MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class TuoiTreNangDongDownloader : Downloader
    {
        public TuoiTreNangDongDownloader()
        {
            this.ResolveImageInHtmlPage = this.ExtractImageOnPage;
        }

        private string ExtractImageOnPage(string pageUrl)
        {
            var doc = GetParser(pageUrl);
            var node = doc.DocumentNode.SelectSingleNode("//div[@class='comiclist']/a/img");
            if(doc!= null)
            {
                return node.Attributes["src"].Value;
            }
            return pageUrl;
        }

        public override string Logo
        {
            get
            {
                return "http://tuoitrenangdong.net/comic/comic_logo.png";
            }
        }

        public override string Name
        {
            get { return "[Tuoi Tre Nang Dong] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://tuoitrenangdong.net/comic/danhsach"; }
        }

        public override string HostUrl
        {
            get { return "http://tuoitrenangdong.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //GOOD Example for cleanup code.
            return base.GetListStoriesSimple("http://tuoitrenangdong.net/comic/danhsach/{0}/",
                "//div[@class='title']/a",
                forceOnline,
                this.HostUrl
                );
        }
        
        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//div[@class='title']/a"
                );
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl +"/1",
                "//select[@name='page']/option",null,null, 
                delegate(HtmlNode node) {
                return chapUrl +"/" + node.Attributes["value"].Value;
            });
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"product\"]/div[@class=\"list-chap\"]/ul/li[position()=1]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + "/" + node.Attributes["href"].Value,
                    Name = node.FirstChild.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("li[position()=3]/ul/h3/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = HostUrl + "/" + chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }

            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var stories = new List<StoryInfo>();

            if (!string.IsNullOrEmpty(keyword))
            {
                var urlPartern = string.Format("http://truyentranh8.com/{0}/", keyword.Replace(" ", "_"));

                string html = NetworkHelper.GetHtml(urlPartern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"info1\"]/table//tr[position()=1]/td/a");

                if (node != null && node.Attributes["href"].Value != "/#doctruyen")
                {
                    stories.Add(new StoryInfo() { Url = urlPartern, Name = keyword });
                }
            }

            return stories;
        }
    }
}
