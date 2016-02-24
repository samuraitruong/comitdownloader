using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("TruyenVnSharing.net", MenuGroup = "O->T", Offline = false, MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "1364131990_document_add")]
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

        public override List<StoryInfo> HotestStories() { throw new NotImplementedException(); }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://truyen.vnsharing.vn/newmanga/{0}";
            return base.GetListStoriesSimple(urlPattern, "//li[@class='browse_result_item']/a[@class='thumb_wrap']", forceOnline,
                
                convertFunc: (HtmlNode s) =>
                {
                    return new StoryInfo()
                    {
                        Url = s.Href(),
                        Name = s.GetNodeText("span[@class='title']").TextBeautifier()
                    };
                });
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {

            return base.RequestInfoSimple(storyUrl,
                "//div[@class='popup_info']//table/tbody/tr[2]//h2",
                "//div[contains(@class,'fullist')]//a",
                categoryPattern: "//*[@id='manga_detail']/ul/li[1]//a",
                authorPattern: "//*[@id='manga_detail']/ul/li[4]//a",
                coverPattern: "//img[@class='popup_manga_cover']",
                summaryPattern: "//div[@class='info_des']");
        }

        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//*[@class='read_content']//a/img");
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
