using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public class TruyenVietBoomDownloader :  Downloader
    {
        public override string Name
        {
            get { return "[Viet Boom] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyen.vietboom.com/danh-sach-truyen"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.vietboom.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "?ViewType=1&SortBy=1&IsAsc=1&CurrentPage={0}";
           
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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"cListStory\"]//h4/a");
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
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"bgTitle\"]//b");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"cellChapter\"]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText,
                    Url = HostUrl + chapter.Attributes["href"].Value,
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

            var matches = Regex.Matches(html, "\"imageUrl\":\"([^,]*)\"");

            List<string> results = new List<string>();
            foreach (Match match in matches)
            {
                results.Add(string.Format("{0}/Resources/Images/Pages/{1}",this.HostUrl,match.Groups[1].Value));
                
            }
            return results;
        }
    }
}
