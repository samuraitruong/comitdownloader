using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    //[Downloader("Truyen 18", Category = "VN", Image32 = "1364078951_insert-object")]
    [Downloader("Hakihome", Language = "Tieng viet", MetroTab="18+", MenuGroup = "VN 18+", Image32 = "1364078951_insert-object")]

    public class HakihomeDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://hakihome.com/images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Hakihome] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.hakihome.com/ListMangaHentai.html"; }
        }

        public override string HostUrl
        {
            get { return "http://www.hakihome.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://www.hakihome.com/ListMangaHentai.html/pagel/{0}/";
           
            List<StoryInfo> results = base.ReloadChachedData().Stories;
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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"listing\"]//td[1]/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = node.Attributes["href"].Value,
                                Name = node.InnerText.Trim()
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
            results = results.OrderBy(p => p.Name).ToList();
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);
            //detect hentai
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"tuade\"]/a");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"listing\"]//td[1]/h6/a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim().Trim(),
                    Url =  chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText.Trim())
                };
                chap.Url = chap.Url.Substring(chap.Url.IndexOf("/http")+1);
                info.Chapters.Add(chap);

                
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }
        
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl+"/more.html");

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"con\"]//img");

            List<string> results = new List<string>();
            foreach (HtmlNode p in pages)
            {
                results.Add(p.Attributes["src"].Value.Trim());
                
            }
            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"nchap newchap\"]//tr/td/a[position()=1]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("a[position()=2]");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        var chapUrl = chap.Attributes["href"].Value;
                        chapUrl = chapUrl.Substring(chapUrl.IndexOf("url")+4);

                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = chapUrl
                        });
                    }
                }
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.hakihome.com/sea/tit={0}", keyword);

            var results = new List<StoryInfo>();

            string html = NetworkHelper.GetHtml(urlPattern);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"rightb\"]/h2/div[@class=\"tuade\"]/a");
            if (nodes != null && nodes.Count > 0)
            {

                foreach (var node in nodes)
                {

                    StoryInfo info = new StoryInfo()
                    {
                        Url = node.Attributes["href"].Value,
                        Name = node.InnerText.Trim().Trim()
                    };
                    results.Add(info);
                }
            }

            return results;
        }
    }
}
