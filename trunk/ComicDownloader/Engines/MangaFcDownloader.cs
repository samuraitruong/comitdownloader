using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public class MangaFcDownloader : Downloader
    {
        public override string Name
        {
            get { return "[Manga Fc] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://mangafc.com/danhsachtruyen/"; }
        }

        public override string HostUrl
        {
            get { return "http://mangafc.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "trang-{0}.html";
           
            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();


                string html = NetworkHelper.GetHtml(this.ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var totalPageNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"navigation\"]//span[1]/b[2]");

                int totalPage = Convert.ToInt32(totalPageNode.InnerText);
                for (int i = 1; i <= totalPage; i++)
                {
                    
              
                    string url = string.Format(urlPattern, i);

                     html = NetworkHelper.GetHtml(url);
                    HtmlDocument parser = new HtmlDocument();
                    parser.LoadHtml(html);

                    var nodes = parser.DocumentNode.SelectNodes("//*[@id=\"table_example\"]//td[1]/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = node.Attributes["href"].Value,
                                Name = node.FirstChild.InnerText
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"container\"]//h1/a");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"table_example\"]//td[1]/a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText,
                    Url = chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
                info.Chapters.Add(chap);
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }
        

        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl+"nhieutrang.html");

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"nhieutrang\"]//a/img");
            List<string> results = new List<string>();
            foreach (HtmlNode match in pages)
            {
                results.Add(BlogTruyenDownloader.ReplaceText(match.Attributes["data-src"].Value));
                
            }
            return results;
        }
    }
}
