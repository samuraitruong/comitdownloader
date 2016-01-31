using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenVnSharing.net", MenuGroup = "O->T", Offline = false, MetroTab ="Tiếng Việt", Language = "Tieng viet", Image32 = "1364131990_document_add")]
    public class TruyenVnSharingDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyen.vn-sharing.net/views/public/imgs/CLANNAD-CTD-banner.png";
            }
        }
        public override string Name
        {
            get { return "[Truyen Vn-Sharing] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyen.vn-sharing.net/index/KhamPha/newest"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.vnsharing.net"; }
        }

        public override string ServiceUrl
        {
            get
            {
                return "http://truyen.vnsharing.net/TimKiem/Truyen";
            }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = this.ListStoryURL + "/{0}";
            return base.GetListStoriesSimple(urlPattern, "//li[@class='browse_result_item']/a[@class='title']", forceOnline);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {

            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='title']");



            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim()
            };

            var chapNodes = htmlDoc.DocumentNode.SelectNodes("//li[@class='browse_result_item']/a[@class='title']");

            foreach (HtmlNode node in chapNodes)
            {
                ChapterInfo chapInfo = new ChapterInfo()
                {
                    Name = node.InnerText.Trim().Trim(),
                    Url = node.Attributes["href"].Value.Trim(),
                    ChapId = ExtractID(node.InnerText.Trim().Trim())   
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
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//img[@id='manga_page']");
            //string pvip = "lstImagesVIP.push\\(\"(.*)\"\\)";

            //string p = "lstImages.push\\(\"(.*)\"\\)";

            //var matches = Regex.Matches(html, pvip);
            //if (matches == null || matches.Count == 0)
            //    matches = Regex.Matches(html, p);

            foreach (HtmlNode node in nodes)
            {
                pages.Add(node.Attributes["src"].Value);
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
                    Name = node.InnerText.Trim().Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.ParentNode.SelectNodes("td[position()=3]/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.InnerText.Trim().Trim(),
                            Url = HostUrl + chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            var json = "keyword={0}";
            json = string.Format(json, keyword.Replace(" ", "+"));

            var html = NetworkHelper.PostHtml(ServiceUrl, ServiceUrl + "/" + keyword.Replace(" ", "-"), json,
                HostUrl,
                "application/x-www-form-urlencoded",
                "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
                "ISO-8859-1,utf-8;q=0.7,*;q=0.3",
                "gzip,deflate,sdch",
                "en-US,en;q=0.8",
                "max-age=0",
                true,
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31");

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"listing\"]//tr[position()>2]/td[position()=1]/a");

            var stories = new List<StoryInfo>();

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    stories.Add(new StoryInfo() { Url = HostUrl + node.Attributes["href"].Value, Name = node.InnerText.Trim().Trim() });
                }
            }

            return stories;
        }
    }
}
