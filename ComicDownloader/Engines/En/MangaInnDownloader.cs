using System;
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
                return "http://www.mangainn.com/images/logoM.png?1366264019";
            }
        }

        public override string Name
        {
            get { return "[Manga Inn] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.mangainn.com/MangaList"; }
        }

        public override string HostUrl
        {
            get { return "http://www.mangainn.com/"; }
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

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {


            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"mangalistItems\"]//a");

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
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"headLBL\"]//tr[1]//td[2]");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Trim(),
            };

           var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"divThickBorder\"]//table//tr/td[1]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.ChildNodes[0].InnerText.Trim() +" " + chapter.ChildNodes[0].InnerText.Trim() ,
                    Url =  chapter.Attributes["href"].Value,
                    
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
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"imgholder\"]//img");
            pageUrl = img.Attributes["src"].Value;

            
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"pageMenu\"]//option");

            List<string> results = new List<string>();
            foreach (HtmlNode page in pages)
            {
                results.Add(HostUrl+ page.Attributes["value"].Value);
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
