using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenTranh8.com", Offline = false, Language = "Tieng viet", MenuGroup = "O->T", MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class TruyenTranh8Downloader: Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://newupload.truyentranh8.com/templates/main/images/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Truyen Tranh 8] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyentranh8.net/danh_sach_truyen/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyentranh8.net"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://truyentranh8.net/search.php?act=search&sort=ten&page={0}&view=list";

            return base.GetListStoriesSimple(urlPattern,
                "//td[@class='tit']/a[1]",
                forceOnline,
                convertFunc:(node)=> {
                    return new StoryInfo()
                    {
                        Name = node.InnerText,
                        Url = base.EnsureHostName(this.HostUrl, node.Attributes["href"].Value)
                    };
                });
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {

            return base.RequestInfoSimple(storyUrl,
                "//h1[@itemprop=\"name\"]",
                "//*[@itemprop=\"itemListElement\"]", 
                chapterExtract : (node)=> {
                    ChapterInfo chapInfo = new ChapterInfo()
                    {
                        Name = node.SelectSingleNode("//span[@class='hm']").InnerText.Trim() + node.SelectSingleNode("//strong").InnerText.Trim(),
                        Url = node.Attributes["href"].Value.Trim(),
                        ChapId = ExtractID(node.SelectSingleNode("//strong").InnerText.Trim())
                    };
                    return chapInfo;
                });
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
