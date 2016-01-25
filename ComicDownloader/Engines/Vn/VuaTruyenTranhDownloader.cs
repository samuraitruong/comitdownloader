﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Vua Truyen Tranh", Offline = false, Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class VuaTruyenTranhDownloader: Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://vuatruyentranh.com/addons/themes/default/img/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Vua Truyen Tranh] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://vuatruyentranh.com/comic/browse/all"; }
        }

        public override string HostUrl
        {
            get { return "http://vuatruyentranh.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "/{0}";
            
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

                    var nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'books')]/div/a");
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url =  node.Attributes["href"].Value,
                                Name = node.Attributes["title"].Value
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='book-title']/span");
 
            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim().Trim()
            };

              var chapNodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='chapters']//a");

              foreach (HtmlNode node in chapNodes)
              {
                  ChapterInfo chapInfo = new ChapterInfo()
                  {
                      Name =  node.InnerText.Trim(),
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

            var doc = base.GetParser(chapUrl);
            
            var nodes = doc.DocumentNode.SelectNodes("//div[@id='pics']//img");
            foreach (HtmlNode node in nodes)
            {
                pages.Add(node.Attributes["src"].Value);
            }

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
                    Name = node.FirstChild.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("li[position()=3]/ul/h3/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = HostUrl + "/" + chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }

            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var stories = new List<StoryInfo>();

            if (!string.IsNullOrEmpty(keyword))
            {
                var urlPartern = string.Format("http://truyentranh8.com/{0}/", keyword.Replace(" ", "_"));

                string html = NetworkHelper.GetHtml(urlPartern);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=\"info1\"]/table//tr[position()=1]/td/a");

                if (node != null && node.Attributes["href"].Value != "/#doctruyen")
                {
                    stories.Add(new StoryInfo() { Url = urlPartern, Name = keyword });
                }
            }

            return stories;
        }
    }
}
