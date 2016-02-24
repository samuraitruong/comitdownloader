using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("tunghoanh.com", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class TungHoanhDownloader : Downloader
    {
        public override string Name
        {
            get { return "[tunghoanh.com] - "; }
        }
        public override bool IsTextEngine
        {
            get { return true; }
        }
        public override string ListStoryURL
        {
            get { return "http://tunghoanh.com/truyen/moi-cap-nhat/"; }
        }

        public override string HostUrl
        {
            get { return "http://tunghoanh.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        //public override string Logo
        //{
        //    get
        //    {
        //        return "http://truyendich.com/public/frontend/img/logo.png";
        //    }
        //}
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple("http://truyendich.com/truyen-duoc-xem-nhieu-nhat/{0}"
                , "//ul[@class='homeListstory']//h3/a", 3);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
           

            return base.GetListStoriesSimple("http://tunghoanh.com/truyen/moi-cap-nhat/trang-{0}.html",
                "//div[@class='main']//h2/a", forceOnline);
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyendich.com/search/"+ keyword+ "/{0}" ,
                "//ul[@class='homeListstory']//h3/a", 3);
        }
        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://truyendich.com/truyen-moi-dang/{0}",
                "//ul[@class='homeListstory']//h3/a", "", null, 3);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1",
                "//*[@class='table table-striped']//tr//a",
                customChapterExtract: (string html, HtmlDocument doc) =>
                {
                    List<ChapterInfo> results = new List<ChapterInfo>();
                    var match = Regex.Match(html, @"showChapter\('(\d*)','(\d*)','(\d*)','(.*)'\);");
                    var media = match.Groups[1].Value;
                    var number = match.Groups[2].Value;
                    var page = 1;// match.Groups[3].Value;
                    var title = match.Groups[4].Value;
                    var eof = false;
                    while(!eof)
                    {
                        var responseHtml = NetworkHelper.PostHtml("http://tunghoanh.com/index.php",
                            this.HostUrl,
                            string.Format("showChapter=1&media_id={0}&number={1}&page={2}&type={3}", media, number, page++, title)
                            );
                        var parser = base.GetParser(responseHtml);
                        var nodes = parser.DocumentNode.SelectNodes("//div[contains(@class,'name')]/a");
                        if (nodes != null)
                        {
                            foreach (HtmlNode item in nodes)
                            {
                                results.Add(new ChapterInfo()
                                {
                                   Name = HttpUtility.HtmlDecode(item.InnerText.Trim()),
                                   Url = base.EnsureHostName("",item.Href()),
                                   ChapId = ExtractID(item.InnerText.Trim())
                                });
                            }
                        }
                        else
                        {
                            eof = true;
                        }

                    }
                    return results;
                });
        }
        //public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chapter = null)
        //{
        //    var html = NetworkHelper.GetHtml(pageUrl);
        //    var match = Regex.Match(html, @"Reading\((\d+),(\d+)\)");
        //    var post = string.Format("btnReading=1&story_id={0}&chapter_id={1}", match.Groups[1].Value, match.Groups[2].Value);
        //    var fileName = Path.Combine(folder, chapter.Name + ".html");
        //    html = NetworkHelper.PostHtml("http://tunghoanh.com/index.php", pageUrl, post);
        //    File.Delete(fileName);
        //    File.WriteAllText(fileName, html);
        //    base.AfterPageDownloaded(fileName, chapter);
        //    return fileName;
        //}

        public override List<string> GetPages(string chapUrl)
        {
            return new List<string>() { chapUrl };
        }

        //public override List<StoryInfo> GetLastestUpdates()
        //{
        //    string lastestUpdateUrl = "http://truyenngontinhaz.com/the-loai/truyen-moi/page{0}";
        //    return base.GetLastestUpdateSimple(lastestUpdateUrl, "//div[@class='wapcat']/table//tr/td[2]/a", "", null, 3);
        //}
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            AfterPageDownloadedSimple(filename, chap.Name, "//div[@id='chapter_content']", "//div[@id='chapter_content']/p/span/a[1]");
        }
        //Use google search 
    }
}
