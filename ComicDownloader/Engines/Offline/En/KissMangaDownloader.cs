using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    //TODO : Site require cookies need to be keep and pass omn every request
    [Downloader("Kiss Manga", Offline =false, MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410887_Add")]
    public class KissMangaDownloader : Downloader
    {
        public KissMangaDownloader() : base()
        {
            //this.InitCookie();
        }
        public override string Logo
        {
            get
            {
                return "http://kissmanga.com/Content/images/logo.png";
            }
        }


        public override string Name
        {
            get { return "[Kiss Manga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://kissmanga.com/MangaList"; }
        }

        public override string HostUrl
        {
            get { return "http://kissmanga.com"; }
        }

        public override string ServiceUrl
        {
            get
            {
                return "http://kissmanga.com/Search/Manga";
            }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override bool InitCookie()
        {
            base.EnsureCookies();
            return base.InitCookie();
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple(
                this.ListStoryURL + "?page={0}",
                "//table[@class='listing']//td[1]/a",
                forceOnline,
                this.HostUrl
               );
        }

        private void KissMangaDownloader_AfterCookieSet()
        {
            throw new NotImplementedException();
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
              "//*[@class=\"bigBarContainer\"]//a[1]",
              "//*[@class=\"listing\"]//td[1]/a"
              ,this.HostUrl);
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chappter = null)
        {
           return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesRegex(chapUrl, "lstImages.push\\(\"(.*)\"\\)");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"tab-newest\"]/div/a[position()=2]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
                    Name = node.FirstChild.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("p[position()=2]/a");
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
            var json = "keyword={0}";
            json = string.Format(json, keyword.Replace(" ","+"));

            var html = NetworkHelper.PostHtml(ServiceUrl, ServiceUrl, json, 
                HostUrl,
                "application/x-www-form-urlencoded",
                "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
                "ISO-8859-1,utf-8;q=0.7,*;q=0.3",
                "gzip,deflate,sdch",
                "en-US,en;q=0.8",
                "max-age=0",
                true,
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31");

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"listing\"]//tr[position()>2]/td[position()=1]/a");

            var stories = new List<StoryInfo>();

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    stories.Add(new StoryInfo() { Url = HostUrl + node.Attributes["href"].Value, Name = node.InnerText.Trim().Trim() }); 
                }
            }

            return stories;
        }

    }
}
