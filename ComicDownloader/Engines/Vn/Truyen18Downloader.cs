using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Truyen 18", Offline = false, Language = "Tieng viet", MenuGroup = "O->T", MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    [Downloader("Truyen 18", Offline = false, Language = "Tieng viet", MenuGroup = "18+", MetroTab = "18+", Image32 = "1364078951_insert-object")]

    public class Truyen18Downloader : Downloader
    {
        public override string Name
        {
            get { return "[Truyen 18] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://www.truyen18.org/moi-cap-nhat/danhsach.html"; }
        }

        public override string HostUrl
        {
            get { return "http://www.truyen18.org/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://www.truyen18.org/moi-cap-nhat/danhsach/page/{0}.html";

            return base.GetListStoriesSimple(urlPattern, "//div[@class='show-content-cat']/ul/li/a[2]", forceOnline);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);
            //detect hentai
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var testNode = htmlDoc.DocumentNode.SelectSingleNode("//a[@class=\"xacnhan\"]");
            if (testNode!= null)
            {
                var url = testNode.Attributes["href"].Value;
                 url = System.Web.HttpUtility.UrlDecode(url);
                storyUrl = url.Substring(url.IndexOf("/http://") + 1);
                html = NetworkHelper.GetHtml(storyUrl);
                htmlDoc.LoadHtml(html);
            }
            

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"barContent\"]//a");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText.Trim()
            };

            var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"listing\"]//td[1]/a");

            foreach (HtmlNode chapter in chapterNodes)
            {
                ChapterInfo chap = new ChapterInfo()
                {
                    Name = chapter.InnerText.Trim(),
                    Url =  chapter.Attributes["href"].Value,
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
            var doc = new HtmlDocument();
            //doc.LoadHtml(html);
            //var html1 = doc.DocumentNode.SelectSingleNode("//textarea").InnerText.Trim();
            //doc.LoadHtml(html1);
            //var nodes = doc.DocumentNode.SelectNodes("//img");
            var patterns = new string[] { "\\*&url=([^\"]*)" , @"\[IMG\]([^\[]*)\[\/IMG\]" };
            List<string> results = new List<string>();

            foreach (var pattern in patterns)
            {
                var matches = Regex.Matches(html, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    var url = match.Groups[1].Value;
                    url = System.Web.HttpUtility.UrlDecode(url);
                    url = BlogTruyenDownloader.ConvertURL(url);
                    results.Add(url);

                }
            }


            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://www.truyen18.org/moi-cap-nhat/danhsach.html";
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"listing\"]//tr[@class=\"odd\"]/td[position()=1]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = HostUrl.Substring(0, HostUrl.LastIndexOf("/")) + node.Attributes["href"].Value,
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
                            Url = chap.Attributes["href"].Value,
                        });
                    }
                }

                stories.Add(info);
            }
            return stories;
        }

        //Use google search 
    }
}
