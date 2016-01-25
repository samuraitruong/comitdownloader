using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Comic.Vuilen.com", Offline =true, Language="Tieng viet", MenuGroup = "VN - 2" , MetroTab="Tiếng Việt", Image32 = "_1364410884_add1_")]
    public class ComicVuiLenDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://www.vuilen.com/images/vuilen.gif";
            }
        }

        public override string Name
        {
            get { return "[Comic Vui Len] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://comic.vuilen.com/"; }
        }

        public override string HostUrl
        {
            get { return "http://comic.vuilen.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { return string.Empty; }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "{0}";

            List<StoryInfo> results = base.ReloadChachedData();

            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();


                string html = NetworkHelper.GetHtml(this.ListStoryURL);

                
                string p = "<option value='([^>]*)'>([^<]*)</option>";

                var matches = Regex.Matches(html, p);

                if (matches != null && matches.Count > 0)
                {

                    foreach (Match m in matches)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = HostUrl+m.Groups[1].Value,
                            Name = m.Groups[2].Value,
                        };
                        results.Add(info);
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

            var table = htmlDoc.DocumentNode.SelectNodes("//td[@class=\"page\"]/table[@class=\"tborder\"]")[1];

            htmlDoc.LoadHtml(table.OuterHtml);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//b");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Substring(0,nameNode.InnerText.Trim().IndexOf("-"))
            };

            var pageNav = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='pagenav']");
            if (pageNav != null)
            {
                var countText = pageNav.SelectSingleNode("//td[@class='vbmenu_control']");
                var count = countText.InnerText.Trim().Replace("Page 1 of", string.Empty);
                var pagingUrl = storyUrl + "&order=desc&sort=timeupdate&page={0}";

                for (var i=1; i< int.Parse(count); i++ )
                {
                    var pageHtml = NetworkHelper.GetHtml(string.Format(pagingUrl, i));
                    pageHtml = Regex.Replace(pageHtml, @"(\[tap\d+\])", "<b>$1</b>");
                    htmlDoc.LoadHtml(pageHtml);

                    var chapNodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href,'view_book_detail')]");

                    foreach (HtmlNode node in chapNodes)
                    {
                        ChapterInfo chapInfo = new ChapterInfo()
                        {
                            //Name = node.InnerText.Trim().Trim(),
                            Url = HostUrl + node.Attributes["href"].Value.Trim(),
                            //ChapId = ExtractID(node.InnerText.Trim().Trim())
                        };
                        var bnodes = node.ParentNode.ParentNode.ParentNode.ParentNode.SelectNodes("b");
                        var name = "";
                        foreach (HtmlNode b in bnodes)
                        {
                            name += b.InnerText.Trim() + " - ";
                        }
                        chapInfo.Name = name;
                        chapInfo.ChapId = ExtractID(name, @"tap([\d]*)");

                        info.Chapters.Add(chapInfo);
                    }
                }   
            }
            else {
                var chapNodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href,'view_book_detail')]");

                foreach (HtmlNode node in chapNodes)
                {
                    ChapterInfo chapInfo = new ChapterInfo()
                    {
                        //Name = node.InnerText.Trim().Trim(),
                        Url = HostUrl + node.Attributes["href"].Value.Trim(),
                        //ChapId = ExtractID(node.InnerText.Trim().Trim())
                    };
                    var t = node.ParentNode.ParentNode.ParentNode.NextSibling.NextSibling.NextSibling.NextSibling;
                    chapInfo.Name = t.InnerText.Trim().Trim();
                    chapInfo.ChapId = ExtractID(t.InnerText.Trim().Trim(), @"tap([\d]*)");
                    info.Chapters.Add(chapInfo);
                }

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

        //Ko thu hien get lastest upate

        //Don't provide search
    }
}
