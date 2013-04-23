﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenVnSharing.net", MenuGroup = "VN - 2" , MetroTab="Tiếng Việt", Language = "Tieng viet", Image32 = "1364131990_document_add")]
    public class TruyenVnSharingDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyen.vnsharing.net/Content/images/logo.png";
            }
        }
        public override string Name
        {
            get { return "[Truyen VnSharing] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyen.vnsharing.net/DanhSach"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.vnsharing.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "?page={0}";

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
                    //var pattern = "<a class=\"bigChar\" href=\"(.*)\">(.*)</a>";

                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"listing\"]/tr/td[1]/a");
                    //var nodes = htmlDoc.DocumentNode.Descendants("a")
                    //                    .Where(p => p.Attributes.Contains("class") &&
                    //                              p.Attributes["class"].Value == "bigChar")
                    //                    .ToList();
                    //var matches = Regex.Matches(html, pattern);
                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        //cheat page 25 return no result
                        if (currentPage == 25) currentPage++;
                        foreach (HtmlNode node in  nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl  +node.Attributes["href"].Value,
                                Name = node.InnerText.Trim(),
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

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//a[@class=\"bigChar\"]");



            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText
            };

            var chapNodes = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"listing\"]//td[1]/a");

            foreach (HtmlNode node in chapNodes)
            {
                ChapterInfo chapInfo = new ChapterInfo()
                {
                    Name = node.InnerText.Trim(),
                    Url = HostUrl+node.Attributes["href"].Value.Trim(),
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

            var html = NetworkHelper.GetHtml(chapUrl);
            string pvip = "lstImagesVIP.push\\(\"(.*)\"\\)";

            string p = "lstImages.push\\(\"(.*)\"\\)";

            var matches = Regex.Matches(html, pvip);
            if (matches == null || matches.Count == 0)
                matches = Regex.Matches(html, p);

            foreach (Match match in matches)
            {
                pages.Add(match.Groups[1].Value);
            }
            
            return pages;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://truyen.vnsharing.net/DanhSach/MoiCapNhat";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"listing\"]//tr[@class=\"odd\"]/td[position()=1]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl + node.Attributes["href"].Value,
                    Name = node.InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("td[position()=3]/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim(),
                            Url = HostUrl + chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }
            return stories;
        }
    }
}
