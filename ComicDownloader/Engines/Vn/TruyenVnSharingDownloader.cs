using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public class TruyenVnSharingDownloader : Downloader
    {
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

        public override List<StoryInfo> GetListStories()
        {
            string urlPattern = this.ListStoryURL + "?page={0}";

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
                    var pattern = "<a class=\"bigChar\" href=\"(.*)\">(.*)</a>";
                    //HtmlDocument htmlDoc = new HtmlDocument();
                    //htmlDoc.LoadHtml(html);

                    //var nodes = htmlDoc.DocumentNode.Descendants("a")
                    //                    .Where(p => p.Attributes.Contains("class") &&
                    //                              p.Attributes["class"].Value == "bigChar")
                    //                    .ToList();
                    var matches = Regex.Matches(html, pattern);
                    if (matches != null && matches.Count > 0)
                    {
                        currentPage++;
                        foreach (Match match in matches)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = HostUrl  + match.Groups[1].Value,
                                Name = match.Groups[2].Value,
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
                    ChapId = ExtractID(node.InnerText.Trim(),@"Chap (\d*)")   
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
    }
}
