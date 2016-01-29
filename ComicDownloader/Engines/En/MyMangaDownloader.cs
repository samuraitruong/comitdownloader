using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("My Manga", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410887_Add")]
    public class MyMangaDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.mymanga.me/img/logo_new.png";
            }
        }

        public override string Name
        {
            get { return "[My Manga] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mymanga.me/manga-directory/all/az/1"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mymanga.me"; }
        }

        public override string ServiceUrl
        {
            get
            {
                return "http://mangachrome.com/manga-list/search/";
            }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://www.mymanga.me/manga-directory/all/az/{0}",
                "//div[@class='manga-hover-wrapper']/a",
                forceOnline,
                convertFunc: delegate (HtmlNode node)
                {
                    HtmlDocument doc = base.GetParser(node.InnerHtml);

                    return new StoryInfo()
                    {
                        Name = doc.DocumentNode.SelectSingleNode("//div[@class='manga-details directory']").InnerText.Trim(),
                        Url  = this.HostUrl + node.Attributes["href"].Value
                    };
                });
        }


        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//*[@class='section-chapter']//a", 
                this.HostUrl);
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var url = base.ExtractImage(pageUrl, "//div[@class='reader-image']//img");
           // url = Regex.Replace(url,"i\\d+.","i1.");
            return base.DownloadPage(url, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
               "//div[@class='reader-nav']/select/option",
               null,
               string.Empty,
               delegate (HtmlNode node)
               {
                   return Regex.Replace( chapUrl ,@"\d+$", node.Attributes["value"].Value);
               });
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://mangachrome.com/";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"wpm_pag mng_lts_chp\"]")[1].SelectNodes("table//tr/td/a[position()=1]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.FirstChild.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("a[position()>1]");
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
            string urlPattern = string.Format("http://mangachrome.com/manga-list/search/{0}/name-az/{1}/", keyword.Replace(" ", "+"), "{0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@id=\"wpm_mng_lst\"]//tr/td/a[position()=2]");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        if (results.Any(p => p.Url == node.Attributes["href"].Value))
                        {
                            currentPage = Constant.LimitedPageForSearch;
                            break;
                        }
                        StoryInfo info = new StoryInfo()
                        {
                            Url = node.Attributes["href"].Value,
                            Name = node.Attributes["title"].Value.Trim()
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
