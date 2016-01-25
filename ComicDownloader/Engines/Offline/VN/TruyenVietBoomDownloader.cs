using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace ComicDownloader.Engines
{
    [Downloader("Vietboom", MenuGroup = "VN",Offline = true,  MetroTab="Tiếng Việt", Language = "Tieng viet", Image32 = "1364150669_folder_add")]
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

        public override string ServiceUrl
        {
            get
            {
                return "http://truyen.vietboom.com/MainHandler.ashx";
            }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "?ViewType=1&SortBy=1&IsAsc=1&CurrentPage={0}";
           
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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"cListStory\"]//h4/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl+node.Attributes["href"].Value,
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
                Name = nameNode.InnerText.Trim()
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"cellChapter\"]//a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url = HostUrl + chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText.Trim())
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
        //            Name = node.InnerText.Trim().Trim(),
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
        //                    Name = chap.InnerText.Trim().Trim(),
        //                    Url = HostUrl + chap.Attributes["href"].Value,
        //                });
        //            }
        //        }
        //        stories.Add(info);
        //    }
        //    return stories;
        //}

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://truyen.vietboom.com/tim-kiem?ViewType=1&SearchText={0}&SearchBy=1&CurrentPage={1}", keyword.Replace(" ", "+"), "{0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"cListStory\"]/div[contains(@class, 'item')]/h4/a");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {

                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + node.Attributes["href"].Value,
                            Name = node.InnerText.Trim().Trim()
                        };
                        results.Add(info);
                    }
                }

                currentPage++;
            }
            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            var jsonStr = "{{\"id\": {0},\"method\":\"getListStoryNewUpdateChapter\",\"params\":[\"{1}\"]}}";
            var jsonArray = new string[]{
                string.Format(jsonStr, "2", DateTime.Now.ToString("O")),
                string.Format(jsonStr, "2", DateTime.Now.AddDays(-1).ToString("O")),
                string.Format(jsonStr, "2", DateTime.Now.AddDays(-2).ToString("O"))
            };

            var stories = new List<StoryInfo>();

            foreach (string json in jsonArray)
            {
                var resultStr = NetworkHelper.PostHtml(ServiceUrl, HostUrl, json);

                if (!string.IsNullOrEmpty(resultStr))
                {
                    JObject obj = JObject.Parse(resultStr);
                    var resultJson = (JObject)obj["result"];
                    var data = (JArray)resultJson["data"];

                    foreach (JObject item in data)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl + "/truyen/" + item["userDefineURL"],
                            Name = item["name"].ToString(),
                            Chapters = new List<ChapterInfo>()
                            {
                                new ChapterInfo()
                                {
                                    Url = HostUrl + "/truyen/" + item["userDefineURL"] + "/" + item["lastChapterID"] + "/" + item["lastChapterNameUserDefineURL"],
                                    Name = item["lastChapterName"].ToString()
                                }
                            }
                        };

                        stories.Add(info);
                    }
                }
            }

            return stories;
        }
    }
}
