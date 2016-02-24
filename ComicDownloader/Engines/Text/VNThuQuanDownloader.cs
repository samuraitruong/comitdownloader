using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Threading.Tasks;

namespace ComicDownloader.Engines
{
    [Downloader("vnthuquan.net", Offline = false, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    public class VNThuQuanDownloader : Downloader
    {
        public override string Name
        {
            get { return "[vnthuquan.net] - "; }
        }
        public override bool IsTextEngine
        {
            get { return true; }
        }
        public override string ListStoryURL
        {
            get { return "http://vnthuquan.net"; }
        }

        public override string HostUrl
        {
            get { return "http://vnthuquan.net/truyen"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://vnthuquan.net/img3/LOGO1d.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple(this.HostUrl
                , "//div[@id='left-story-read-more']//a[@class='view-item-story-title']", 1);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://vnthuquan.net/truyen/?tranghientai={0}",
                "//div[@id='noidung']//li[@class='menutruyen']/a",
                forceOnline); 
        }
        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://thichtruyen.vn/site/search?key_word=" + keyword,
                "//div[contains(@class,'view-category-item-infor')]/a",
                1);
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            
            var info = base.RequestInfoSimple(storyUrl,
                "//h3/a/b",
                "//div[@id='muluben_to']/acronym/div",
                chapterExtract: (HtmlNode n) =>
                {
                    return new ChapterInfo()
                    {
                        Name = n.InnerText.Trim(),
                        Url = n.Attr("onclick")
                    };
                }, customChapterExtract: (string html, HtmlDocument doc) =>
                  {
                      var match = Regex.Match(html, @"noidung1\('(.*)'\);");
                      if(match!= null)
                      {
                          var chapter = new ChapterInfo()
                          {
                              Name = "Chuong 01",
                              Url = match.Groups[0].Value
                          };
                          return new List<ChapterInfo>() { chapter };
                      }
                      return null;
                  });
            
            if(info.Chapters.Count == 1)
            {
                info.Chapters[0].Name = info.Name;
            }
            return info;
        }
       
        public override List<string> GetPages(string chapUrl)
        {
            return new List<string>() { Regex.Match(chapUrl, @"noidung1\('(.*)'\)").Groups[1].Value };
        }
        public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chapter = null)
        {
            //cc = NetworkHelper.GetCookie(pageUrl, httpReferer);
            var match = Regex.Match(pageUrl, @"(\d*).html$");

            string file = chapter.Name + ".html";
            string html = NetworkHelper.PostHtml("http://vnthuquan.net/truyen/chuonghoi_moi.aspx?&rand=352.1643669810146", this.HostUrl, pageUrl, 
                cookies:this.Cookies, 
                accept:"*/*",
                encoding: "gzip, deflate",
                language: "en-US,en;q=0.8",
                origin: "http://vnthuquan.net"
                );
            Directory.CreateDirectory(folder.ToValidFileName());
            file = file.Replace(chapter.ChapId.ToString(), chapter.ChapId.ToString("D3"));
            var filename = Path.Combine(folder, file.ToValidFileName());
            File.WriteAllText(filename, html);
            this.AfterPageDownloaded(filename, chapter);
            return filename;
        }
        public override bool InitCookie()
        {
            Task.Run(() =>
            {
                
                base.InitCookieFromUrl("http://vnthuquan.net/truyen/?AspxAutoDetectCookieSupport=1", "AspxAutoDetectCookieSupport=1");

                if(this.Cookies!= null)
                {
                    Uri target = new Uri(this.HostUrl);

                    this.Cookies.Add(new Cookie("AspxAutoDetectCookieSupport", "1") { Domain = target.Host });
                }

            });
            return base.InitCookie();
        }
        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://truyen368.com/truyen-dang-update/trang-{0}.html";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//*[@id='comic_full']//td[1]/a[2]", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename,
                chap.Name, 
                "//*[@class='chuhoa1'];//*[@class='chuhoain']", 
                "//spam[@class='chuto40']",
                extractContent: (string s, HtmlDocument doc) =>
                {
                    var pos = s.IndexOf("--!!tach_noi_dung!!--");
                    var start = s.IndexOf("--!!tach_noi_dung!!--", pos + 22) +22;

                    var end = s.IndexOf("--!!tach_noi_dung!!--",start);

                    string html = s.Substring(start, end - start);
                    return html.Trim();
                });

            
        }
        //Use google search 
    }
}
