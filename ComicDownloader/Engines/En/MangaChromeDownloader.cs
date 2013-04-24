using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaChrome", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410887_Add")]
    public class MangaChromeDownloader : Downloader
    {
        

        public override string Name
        {
            get { return "[Manga Chrome] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://mangachrome.com/manga-list/"; }
        }

        public override string HostUrl
        {
            get { return "http://mangachrome.com"; }
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
            string urlPattern = "http://mangachrome.com/manga-list/all/any/name-az/{0}/";
            //*[@id="sct_content"]/div/div/div[1]/ul
            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                string html = NetworkHelper.GetHtml(ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"pgg\"]//li[last()]/a");

                var match = Regex.Match(node.Attributes["href"].Value, @"/(\d*)/$");

                int totalPage = int.Parse(match.Groups[1].Value); ;
                for (int i = 1; i <= totalPage; i++)
                {
                    string url = string.Format(urlPattern, i);

                    html = NetworkHelper.GetHtml(url);
                    htmlDoc.LoadHtml(html);

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"wpm_mng_lst\"]//td[1]/a[last()]");
                    if (nodes != null && nodes.Count > 0)
                    {

                        foreach (var currentNode in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = currentNode.Attributes["href"].Value,
                                Name = currentNode.Attributes["title"].Value.Trim()
                            };
                            results.Add(info);
                        }
                    }


                }

            }

            this.SaveCache(results);
            return results;
        }


        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"content_mangalist\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Replace("Manga",""),
            };


            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"content_mangalist\"]//table//td[1]/a");
            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.Descendants("font").First().InnerText.Trim(),
                    Url = chapter.Attributes["href"].Value,
                    //ChapId = ExtractID(chapter.InnerText)
                };
                chap.ChapId = ExtractID(chap.Name);
                info.Chapters.Add(chap);
            }
            
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
           
            var m = Regex.Match(html, "Getxload.src = \"(.*)\"");

            pageUrl = HostUrl + m.Groups[1].Value;
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"contentRead\"]/div[3]/div/div[2]/select/option");

            List<string> results = new List<string>();

            foreach (HtmlNode page in pages)
            {
                results.Add(chapUrl + page.Attributes["value"].Value + "/");
            }

            return results;
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
                    Name = node.FirstChild.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("a[position()>1]");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim(),
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
