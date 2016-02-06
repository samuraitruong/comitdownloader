using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections;

namespace ComicDownloader.Engines
{
    //Offline - require authenticated to get chappter list
    [Downloader("Batoto", Offline =true, MenuGroup = "English" , MetroTab="English", Language = "English", Image32 = "_1364410884_add1_")]
    public class BatotoDownloader :  Downloader
    {
        public override string Logo
        {
            get
            {
                return "https://bato.to/forums/public/style_images/11_4_logo.png";
            }
        }

        public override string Name
        {
            get { return "[Bato.to] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://bato.to/search"; }
        }

        public override string HostUrl
        {
            get { return "http://www.bato.to"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> HotestStories(){throw new NotImplementedException();}    public override List<StoryInfo> GetListStories(bool forceOnline)      
        {
            return base.GetListStoriesSimple("http://bato.to/search_ajax?&p={0}",
                "//table//tr/td[1]/strong/a",
                forceOnline);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                ""
                );
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

            foreach (HtmlNode node in nodes.Where(p=>!string.IsNullOrEmpty(p.InnerText.Trim())))
            {
                
                string url = node.Attributes["href"].Value;
                string key = Regex.Replace(url,@"(.*)_/(.*)(-r\d+)","$2");


                StoryInfo info = new StoryInfo()
                {
                    Url = url,
                    Name = node.InnerText.Trim().Trim(),
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
                            Name = chap.ChildNodes[1].InnerText.Trim().Trim(),
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
                            Name = node.ChildNodes[1].InnerText.Trim().Trim()
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
