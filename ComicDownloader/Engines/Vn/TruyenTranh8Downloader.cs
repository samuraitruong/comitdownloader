using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenTranh8.com", Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class TruyenTranh8Downloader: Downloader
    {
        public override string Name
        {
            get { return "[Truyen Tranh 8] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyentranh8.com/danh_sach_truyen/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyentranh8.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "page={0}";

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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"tblChap\"]//a[@class=\"tipsy\"]");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl+"/" + node.Attributes["href"].Value,
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

            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//h1[@itemprop=\"name\"]");

            
             
            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText
            };

              var chapNodes = htmlDoc.DocumentNode.SelectNodes("//*[@itemprop=\"itemListElement\"]");

              foreach (HtmlNode node in chapNodes)
              {
                  ChapterInfo chapInfo = new ChapterInfo()
                  {
                      Name = node.Descendants("strong").FirstOrDefault().InnerText,
                      Url = node.Descendants("a").FirstOrDefault().Attributes["href"].Value.Trim(),
                      ChapId = ExtractID(node.Descendants("strong").FirstOrDefault().InnerText)
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
            string pvip = "lstImagesVIP.push\\(\"(.*)\"\\)";

            string p = "lstImages.push\\(\"(.*)\"\\)";

            var matches = Regex.Matches(html, pvip);
            if(matches== null || matches.Count ==0)
             matches = Regex.Matches(html,p );

            foreach (Match match in matches)
            {
                pages.Add(match.Groups[1].Value);
            }
            //HtmlDocument htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(html);

            //var pageNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"wrapper\"]//img");
            //foreach (HtmlNode node in pageNodes)
            //{
            //    pages.Add(node.Attributes["src"].Value);
            //}
            return pages;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"product\"]/div[@class=\"list-chap\"]/ul/li[position()=1]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + "/" + node.Attributes["href"].Value,
                    Name = node.FirstChild.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("li[position()=3]/ul/h3/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim(),
                            Url = HostUrl + "/" + chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }

            return stories;
        }
    }
}
