using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Vietboom", MenuGroup = "VN", Language = "Tieng viet", Image32 = "1364150669_folder_add")]
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

        //public override List<StoryInfo> GetLastestUpdates()
        //{
        //    string lastestUpdateUrl = HostUrl;
        //    List<StoryInfo> stories = new List<StoryInfo>();
        //    var html = NetworkHelper.GetHtml(lastestUpdateUrl);

        //    var htmlDoc = new HtmlDocument();
        //    htmlDoc.LoadHtml(html);
        //    var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"containerStoryToday\"]/a");

        //    foreach (HtmlNode node in nodes)
        //    {
        //        StoryInfo info = new StoryInfo()
        //        {
        //            Url = HostUrl + node.Attributes["href"].Value,
        //            Name = node.InnerText.Trim(),
        //            Chapters = new List<ChapterInfo>(),
        //        };

        //        html = NetworkHelper.GetHtml(info.Url);
        //        htmlDoc = new HtmlDocument();
        //        htmlDoc.LoadHtml(html);
        //        var chapters = node.ParentNode.ParentNode.SelectNodes("//div[@class=\"newChapter\"]/div[@class=\"body\"]/div[@class=\"item\"]/a");

        //        if (chapters != null)
        //        {
        //            foreach (HtmlNode chap in chapters)
        //            {
        //                info.Chapters.Add(new ChapterInfo()
        //                {
        //                    Name = chap.InnerText.Trim(),
        //                    Url = HostUrl + chap.Attributes["href"].Value,
        //                });
        //            }
        //        }
        //        stories.Add(info);
        //    }
        //    return stories;
        //}
    }
}
