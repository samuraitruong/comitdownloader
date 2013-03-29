using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Truyen 18", Category = "VN", Image32 = "1364078951_insert-object")]
    [Downloader("Truyen 18", Category = "VN 18+", Image32 = "1364078951_insert-object")]

    public class Truyen18Downloader : Downloader
    {
        public override string Name
        {
            get { return "[Truyen 18] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.truyen18.org/moi-cap-nhat/danhsach.html"; }
        }

        public override string HostUrl
        {
            get { return "http://www.truyen18.org/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = "http://www.truyen18.org/moi-cap-nhat/danhsach/page/{0}.html";
           
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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"listing\"]//td[1]/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl+node.Attributes["href"].Value,
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

            var testNode = htmlDoc.DocumentNode.SelectSingleNode("//a[@class=\"xacnhan\"]");
            if (testNode!= null)
            {
                var url = testNode.Attributes["href"].Value;
                 url = System.Web.HttpUtility.UrlDecode(url);
                storyUrl = url.Substring(url.IndexOf("/http://") + 1);
                html = NetworkHelper.GetHtml(storyUrl);
                htmlDoc.LoadHtml(html);
            }
            

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"barContent\"]//a");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"listing\"]//td[1]/a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText,
                    Url =  chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
                info.Chapters.Add(chap);
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }
        

        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            var matches = Regex.Matches(html, @"\[IMG\](.*)?\[/IMG\]");

            List<string> results = new List<string>();
            foreach (Match match in matches)
            {
                results.Add(match.Groups[1].Value+"?imgmax=1600");
                
            }
            return results;
        }
    }
}
