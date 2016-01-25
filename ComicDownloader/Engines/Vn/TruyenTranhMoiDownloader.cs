using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Truyen Tranh Moi", Offline = false, Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class TruyenTranhMoiDownloader: Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyentranhmoi.com/wp-content/themes/truyentranhmoi/icons/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Truyen Tranh Moi] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyentranhmoi.com/danh-sach/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyentranhmoi.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://truyentranhmoi.com/danh-sach/page/{0}/";
            
            List<StoryInfo> results = base.ReloadChachedData();

            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {

                    string url = string.Format(urlPattern, currentPage);

                    string html = NetworkHelper.GetHtml(url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'truyen-list')]/ul/li/a[2]");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url =  node.Attributes["href"].Value,
                                Name = node.Attributes["title"].Value
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//h1");
 
            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Trim()
            };

              var chapNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'chap-list')]/ul/li/a");

              foreach (HtmlNode node in chapNodes)
              {
                  ChapterInfo chapInfo = new ChapterInfo()
                  {
                      Name =  node.InnerText.Trim(),
                      Url = node.Attributes["href"].Value.Trim(),
                      ChapId = ExtractID(node.InnerText.Trim())
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
            
            var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class,'image-chap')]/img");
            foreach (HtmlNode node in nodes)
            {
                pages.Add(node.Attributes["src"].Value);
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
