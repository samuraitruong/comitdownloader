using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections;

namespace ComicDownloader.Engines
{
    [Downloader("Batoto", MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class BatotoDownloader :  Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.batoto.net/forums/public/style_images/Deluxe_Images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Batoto.NET] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.batoto.net/search"; }
        }

        public override string HostUrl
        {
            get { return "http://www.batoto.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "?p={0}";

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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"comic_search_results\"]//td[1]/strong/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = node.Attributes["href"].Value,
                                Name = node.ChildNodes[1].InnerText.Trim()
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"ipsBox_withphoto\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim(),
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"ipb_table chapters_list\"]//td[1]/a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.ChildNodes[1].InnerText.Trim(),
                    Url =  chapter.Attributes["href"].Value,
                    ChapId = ExtractID(chapter.InnerText)
                };
                info.Chapters.Add(chap);
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            if (!Regex.IsMatch(pageUrl, "(.jpg|.JPG|.png|.PNG)$"))
            {
                var html = NetworkHelper.GetHtml(pageUrl);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var img = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"comic_page\"]");
                pageUrl = img.Attributes["src"].Value;
            }
            
            return base.DownloadPage(pageUrl, renamePattern, folder, httpReferer);
        }
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var pages = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"page_select\"]//option");

            List<string> results = new List<string>();
            if (pages != null)
            {
                foreach (HtmlNode page in pages)
                {
                    results.Add(page.Attributes["value"].Value);
                }
            }
            else
            {
                //var pageSettingNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"read_settings\"]");

                //pages = pageSettingNode.NextSibling.NextSibling.SelectNodes("img")
                pages = htmlDoc.DocumentNode.SelectSingleNode("//div[@style='width:77%; text-align:center; padding-right: 15px;']").SelectNodes("img");
                foreach (HtmlNode page in pages)
                {
                    results.Add(page.Attributes["src"].Value);
                }
            }
            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(this.HostUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"ipb_table chapters_list\"]//tr/td/a[@style=\"font-weight:bold;\"]");

            foreach (HtmlNode node in nodes.Where(p=>!string.IsNullOrEmpty(p.InnerText)))
            {
                
                string url = node.Attributes["href"].Value;
                string key = Regex.Replace(url,@"(.*)_/(.*)(-r\d+)","$2");


                StoryInfo info = new StoryInfo()
                {
                    Url = url,
                    Name = node.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };


                var chapters = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href,'" + key + "')]");
                if (chapters != null)
                    foreach (HtmlNode chap in chapters.Skip(1))
                    {
                        if (chap.SelectSingleNode("img") == null || chap.ChildNodes.Count !=2) continue;
                        if (info.Chapters.Exists(p => p.Url == chap.Attributes["href"].Value)) continue;

                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.ChildNodes[1].InnerText.Trim(),
                            Url = chap.Attributes["href"].Value,
                        });
                    }
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://www.batoto.net/search?name={0}&name_cond=c", keyword.Replace(" ", "+"));
            urlPattern = urlPattern + "&p={0}";

            var results = new List<StoryInfo>();

            int currentPage = 1;
            while (currentPage <= Constant.LimitedPageForSearch)
            {
                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id=\"comic_search_results\"]/table[@class=\"ipb_table chapters_list\"]//td[position()=1]//a");
                if (nodes != null && nodes.Count > 0)
                {

                    foreach (var node in nodes)
                    {

                        StoryInfo info = new StoryInfo()
                        {
                            Url = node.Attributes["href"].Value,
                            Name = node.ChildNodes[1].InnerText.Trim()
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
