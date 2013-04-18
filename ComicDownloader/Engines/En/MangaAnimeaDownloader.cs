using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("MangaAnimea", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaAnimeaDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://cdn.animea.net/gfx/mgfx/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Manga.Animea.NET] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://manga.animea.net/browse.html"; }
        }

        public override string HostUrl
        {
            get { return "http://manga.animea.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "?page={0}";

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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"mangalist\"]//li/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl+node.Attributes["href"].Value,
                                Name = node.Attributes["title"].Value.Trim()
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

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"content\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"chapters_list\"]//li/a");
            if(chapterNodes!=null)
            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url =  HostUrl + chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
                info.Chapters.Add(chap);
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"mangaimg\"]");
            pageUrl = img.Attributes["src"].Value;

            
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"mangaselecter pageselect\"]//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                string url = chapUrl.Replace(".html", "-page-"+page.Attributes["value"].Value+".html");
                results.Add(url);
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
            var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"updated_list\"]/li/a[position()=1]");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
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
            string urlPattern = string.Format("http://manga.animea.net/search.html?title={0}&completed=0&yor_range=0&yor=&type=any&author=&artist=&genre%5BAction%5D=0&genre%5BAdventure%5D=0&genre%5BComedy%5D=0&genre%5BDoujinshi%5D=0&genre%5BDrama%5D=0&genre%5BEcchi%5D=0&genre%5BFantasy%5D=0&genre%5BGender_Bender%5D=0&genre%5BHarem%5D=0&genre%5BHistorical%5D=0&genre%5BHorror%5D=0&genre%5BJosei%5D=0&genre%5BMartial_Arts%5D=0&genre%5BMature%5D=0&genre%5BMecha%5D=0&genre%5BMystery%5D=0&genre%5BPsychological%5D=0&genre%5BRomance%5D=0&genre%5BSchool_Life%5D=0&genre%5BSci-fi%5D=0&genre%5BSeinen%5D=0&genre%5BShotacon%5D=0&genre%5BShoujo%5D=0&genre%5BShoujo_Ai%5D=0&genre%5BShounen%5D=0&genre%5BShounen_Ai%5D=0&genre%5BSlice_of_Life%5D=0&genre%5BSmut%5D=0&genre%5BSports%5D=0&genre%5BSupernatural%5D=0&genre%5BTragedy%5D=0&genre%5BYaoi%5D=0&genre%5BYuri%5D=0", keyword.Replace(" ", "+"));
            urlPattern = urlPattern + "&page={0}";

            var results = new List<StoryInfo>();

            int currentPage = 0;

            while (currentPage < Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"mangalist\"]/li/div[@class=\"manga_desc\"]/a");
                if (nodes != null && nodes.Count > 0)
                {

                    foreach (var node in nodes)
                    {

                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + node.Attributes["href"].Value,
                            Name = node.InnerText.Trim()
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

