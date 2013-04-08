using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Manga Inn", MenuGroup = "English - 2", Language = "English", Image32 = "_1364410884_add1_")]
    public class MangaInnDownloader : Downloader
    {
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

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {


            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
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
                        Name = node.InnerText.Trim()
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
                Name = nameNode.InnerText.Trim(),
            };

           var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"divThickBorder\"]//table//tr/td[1]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.ChildNodes[0].InnerText +" " + chapter.ChildNodes[0].InnerText ,
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
                    Name = node.SelectSingleNode("span").InnerText,
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
                            Name = tag.SelectSingleNode("span").InnerText,
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
    }
}
