using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Manga Inn", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaInnDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.mangainn.me/images/logoM.png";
            }
        }

        public override string Name
        {
            get { return "[Manga Inn] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangainn.me/MangaList"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangainn.ne/"; }
        }

        public override string ServiceUrl
        {
            get
            {
                return "http://www.mangainn.com/advresults";
            }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple(this.ListStoryURL,
               "//li[@class='mangalistItems']/a",
               forceOnline,
               string.Empty);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//table[@class='headLBL'][1]//td[@itemprop='name']",
                "//div[@class='divThickBorder'][3]//span/a"
                );

        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chappter = null)
        {
            var imgUrl = base.ExtractImage(pageUrl, "//div[@id='divimgPage']/img");
            return base.DownloadPage(imgUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//select[@id='cmbpages']/option",imgExtract: delegate(HtmlNode node)
                {
                    return chapUrl + "/page_" + node.Attributes["value"].Value;
                });
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"content\"]/table[position()=2]/tr/td[position()=1]/div/a[@title=\"ongoing\"]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.SelectSingleNode("span").InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };

                HtmlNode tag = node.NextSibling;
                while (true)
                {
                    if (tag == null)
                    {
                        break;
                    }

                    if (tag.Name == "div" && tag.Attributes.Contains("class") && tag.Attributes["class"].Value == "ayirac")
                    {
                        break;
                    }

                    if (tag.Name == "a" && tag.Attributes["href"].Value != "latest/1_page")
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = tag.SelectSingleNode("span").InnerText.Trim(),
                            Url = tag.Attributes["href"].Value,
                        });
                    }
                    else if (tag.Name == "a" && tag.Attributes["href"].Value == "latest/1_page")
                    {
                        break;
                    }

                    tag = tag.NextSibling;
                }

                stories.Add(info);
            }

            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var json = "seriestype=c&series={0}&authortype=c&author=&artisttype=c&artist=&yeartype=o&releaseyear=&genreListYes=&genreListNo=";
            json = string.Format(json, keyword.Replace(" ", "+"));

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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"divThickBorder\"]//tr/td[position()=2]/a");

            var stories = new List<StoryInfo>();

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    var storyUrl = node.Attributes["onclick"].Value;
                    storyUrl = storyUrl.Substring(storyUrl.IndexOf("(") + 2);
                    storyUrl = storyUrl.Substring(0, storyUrl.LastIndexOf(")") - 1);

                    stories.Add(new StoryInfo() 
                    { 
                        Url = HostUrl + "manga/" + storyUrl,
                        Name = node.InnerText.Trim().Trim() 
                    });
                }
            }

            return stories;
        }
    }
}
