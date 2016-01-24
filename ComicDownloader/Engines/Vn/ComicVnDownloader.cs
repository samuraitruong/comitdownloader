using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("ComicVN.NET", Offline = false, Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class ComicVnDownloader: Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://comicvn.net/static/image/default/new/images/comic.png";
            }
        }

        public override string Name
        {
            get { return "[Comic VN] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://comicvn.net/truyen-tranh"; }
        }

        public override string HostUrl
        {
            get { return "http://comicvn.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://comicvn.net/truyen-tranh?parent_slug=truyen-tranh&name_slug=&id_category=1&orderBy=&type=0&&page={0}";
            string  cheUrl = "http://comicvn.net/truyen-che";

            List<StoryInfo> results = base.ReloadChachedData();

            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                int currentPage = 0;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {

                    string url = string.Format(urlPattern, currentPage);

                    string html = NetworkHelper.GetHtml(currentPage==0? cheUrl: url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class='list']/li/div/h2/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = this.HostUrl + node.Attributes["href"].Value,
                                Name = node.InnerText
                            };
                            results.Add(info);
                        }
                    }
                    else
                    {
                        isStillHasPage = false;
                    }

                }

            }
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='title-detail']");
 
            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText
            };

              var chapNodes = htmlDoc.DocumentNode.SelectNodes("//table[@class='list-chapter']//a");

              foreach (HtmlNode node in chapNodes)
              {
                  ChapterInfo chapInfo = new ChapterInfo()
                  {
                      Name =  node.InnerText,
                      Url = this.HostUrl + node.Attributes["href"].Value.Trim(),
                      ChapId = ExtractID(node.InnerText)
                  };
                  info.Chapters.Add(chapInfo);
              }

              info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override List<string> GetPages(string chapUrl)
        {
            List<string> pages = new List<string>();

            var doc = base.GetParser(chapUrl);
            var html = doc.DocumentNode.SelectSingleNode("//*[@id='txtarea']").InnerHtml;
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//img");
            foreach (HtmlNode node in nodes)
            {
                pages.Add(node.Attributes["src"].Value);
            }
            //HtmlDocument htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(html);

            //var pageNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"wrapper\"]//img");
            //foreach (HtmlNode node in pageNodes)
            //{
            //    pages.Add(node.Attributes["src"].Value);
            //}
            return pages;
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
                    Name = node.FirstChild.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("li[position()=3]/ul/h3/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim(),
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
