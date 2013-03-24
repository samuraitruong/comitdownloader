using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public class TruyenTranhNhanhDownloader : Downloader
    {
        public override string Name
        {
            get { return "[Truyen Tranh Nhanh] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyentranhnhanh.com/comics/list/truyenmoi/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.vnsharing.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "{0}";

            List<StoryInfo> results = base.ReloadChachedData();

            if (results == null || results.Count == 0)
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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"list_search\"]//h3/a");
                                        
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (HtmlNode node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = node.Attributes["href"].Value,
                                Name = node.InnerText,
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mainle\"]//strong");



            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText
            };

            var chapNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"manga_detail\"]//li//h3/a");

            foreach (HtmlNode node in chapNodes)
            {
                ChapterInfo chapInfo = new ChapterInfo()
                {
                    Name = node.InnerText.Trim(),
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

            var html = NetworkHelper.GetHtml(chapUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"imgw\"]//img");

            foreach (HtmlNode img in nodes)
            {
                pages.Add(img.Attributes["src"].Value);
            }
            
            return pages;
        }
    }
}
