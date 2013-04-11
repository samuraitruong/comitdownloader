#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using ComicDownloader.Properties;

namespace ComicDownloader.Engines
{
    [Downloader("BlogTruyen", MenuGroup = "VN" , Language="Tieng viet", Image32 = "_1364410895_001_01")]
    public class BlogTruyenDownloader: Downloader
    {
        public override string Name
        {
            get { return "[BlogTruyen] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://danhmuc.blogtruyen.com/2009/11/danh-sach-tong-hop.html"; }
        }

        public override string HostUrl
        {
            get { return "http://home.blogtruyen.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories()
        {
            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0)
            {
                results = new List<StoryInfo>();

                string[] urls = {"http://blogtruyen.com/list/list-0abc-3.js",
                              "http://blogtruyen.com/list/list-defgh-3.js",
                              "http://blogtruyen.com/list/list-ijkl-3.js",
                              "http://blogtruyen.com/list/list-mnop-3.js",
                              "http://blogtruyen.com/list/list-qrst-3.js",
                              "http://blogtruyen.com/list/list-uvwxyz-3.js"
                             };
                foreach (var url in urls)
                {

                    string html = NetworkHelper.GetHtml(url);

                    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    var links = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"listing\"]//a");

                    //htmlDoc.LoadHtml(table.InnerHtml);
                    //var links = htmlDoc.DocumentNode.SelectNodes("//a");
                    foreach (HtmlNode item in links)
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Name = item.InnerText,
                            Url = item.Attributes["href"].Value
                        };
                        results.Add(info);
                    }
#if DEBUG
                   // break;
#endif
                }
            }
            base.SaveCache(results);
            return results;
        }
        
        public override StoryInfo RequestInfo(string storyUrl)
        {
            StoryInfo info = new StoryInfo
            {
                Url = storyUrl,
            };

            var html = NetworkHelper.GetHtml(storyUrl);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            
            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"post\"]/div[1]/h1/a");
            info.Name = node.InnerText.Replace("&nbsp;", string.Empty);

            //var chapters = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"post\"]//a[contains(@href,'x2.blogtruyen.com')]");
            var chapters = htmlDoc.DocumentNode
                .Descendants("a")
                .Where(x => x.Attributes.Contains("href") &&
                          ( x.Attributes["href"].Value.Contains("x1.blogtruyen.com") ||
                            x.Attributes["href"].Value.Contains("x2.blogtruyen.com") ||
                            x.Attributes["href"].Value.Contains("x3.blogtruyen.com")))
                .ToList();

            foreach (HtmlNode item in chapters)
            {

                var chapInfo = new ChapterInfo()
                {
                    Url = item.Attributes["href"].Value,
                    Name = item.FirstChild.InnerText,
                    ChapId = ExtractID(item.FirstChild.InnerText)
                };


                info.Chapters.Add(chapInfo);

            }

            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }

        public static string ReplaceText(string s)
        {

            s = s.Replace("http:\\x1.blogtruyen.com", "prereplinkx1");
            s = s.Replace("http:\\x2.blogtruyen.com", "prereplinkx2");

            s = s.Replace("http://ca", "a-s-u");
            s = s.Replace("http://cz", "a-s-u");
            s = s.Replace("http://va", "a-s-u");
            s = s.Replace("http://vb", "a-s-u");
            s = s.Replace("http://cb", "a-s-u");
            s = s.Replace("a-s-u0.upanh", "fix-u-a");
            s = s.Replace("a-s-u1.upanh", "fix-u-a");
            s = s.Replace("a-s-u2.upanh", "fix-u-a");
            s = s.Replace("a-s-u3.upanh", "fix-u-a");
            s = s.Replace("a-s-u4.upanh", "fix-u-a");
            s = s.Replace("a-s-u5.upanh", "fix-u-b");
            s = s.Replace("a-s-u6.upanh", "fix-u-b");
            s = s.Replace("a-s-u7.upanh", "fix-u-b");
            s = s.Replace("a-s-u8.upanh", "fix-u-b");
            s = s.Replace("a-s-u9.upanh", "fix-u-b");
            s = s.Replace("fix-u-a", "http://ca3.upanh");
            s = s.Replace("fix-u-b", "http://cb3.upanh");

            s = s.Replace("width=", "wi=");
            s = s.Replace("height=", "hei=");
            s = s.Replace("<table>", "");
            s = s.Replace("<tbody>", "");
            //s = s.Replace("manhua.comicvn.net","go.blogtruyen.com/reup" rel="/");
            s = s.Replace("manhua.comicvn.net", "go.blogtruyen.com/reup");

            s = s.Replace("http://images0-focus-opensocial.googleusercontent", "");
            s = s.Replace("https://images0-focus-opensocial.googleusercontent", "");
            s = s.Replace("http://images-focus-opensocial.googleusercontent", "");
            s = s.Replace("https://images-focus-opensocial.googleusercontent", "");
            s = s.Replace("http://images2-focus-opensocial.googleusercontent", "");
            s = s.Replace("https://images2-focus-opensocial.googleusercontent", "");
            s = s.Replace(".com/gadgets/proxy?container=focus&gadget=a&no_expand=1&resize_h=0&rewriteMime=image%2F*&url=", "");
            s = s.Replace("%25252520", "");
            s = s.Replace("%252520", "");
            s = s.Replace("%20", "");
            s = s.Replace("%3a", ":");
            s = s.Replace("%2f", "/");
            s = s.Replace("%3d", "=");
            s = s.Replace("%3f", "?");
            s = s.Replace("lstImages.push(\"", "[IMG]");
            s = s.Replace("\"\\);", "[/IMG]");
            s = s.Replace("https://lh6", "http://4");
            s = s.Replace("https://lh5", "http://4");
            s = s.Replace("https://lh", "http://");
            s = s.Replace("http://lh6", "http://4");
            s = s.Replace("http://lh5", "http://4");
            s = s.Replace("http://lh", "http://");

            s = s.Replace("lh1", "1");
            s = s.Replace("lh2", "2");
            s = s.Replace("lh3", "3");
            s = s.Replace("lh4", "4");
            s = s.Replace("lh5", "4");
            s = s.Replace("lh6", "4");
            s = s.Replace("ggpht", "bp.blogspot");
            s = s.Replace("googleusercontent", "bp.blogspot");


            s = s.Replace("alt=\"%name\"", "/");
            s = s.Replace("?ssitoken", "\"  \"");
            s = s.Replace("S.jpg", "Ss.jpg");
            s = s.Replace("S.JPG", "Ss.jpg");

            s = s.Replace("S.gif", "Ss.gif");
            s = s.Replace("S.GIF", "Ss.gif");
            s = s.Replace("S.png", "Ss.png");
            s = s.Replace("S.PNG", "Ss.png");
            s = s.Replace("S.bmp", "Ss.bmp");
            s = s.Replace("S.BMP", "Ss.bmp");
            s = s.Replace("s.jpg", ".jpg");
            s = s.Replace("s.gif", ".gif");
            s = s.Replace("s.png", ".png");
            s = s.Replace("s.bmp", ".bmp");
            //s = s.Replace("\]=\"http://", "[IMG]http://");
            s = s.Replace("jpg\";", "jpg[/IMG]");
            s = s.Replace("png\";", "png[/IMG]");
            s = s.Replace("gif\";", "gif[/IMG]");

            s = s.Replace("images[", "");
            s = s.Replace("</a>", "</a><br/>");
            s = s.Replace("/h120/", "/s1600/");
            s = s.Replace("/s160/", "/s1600/");
            s = s.Replace("/s72/", "/s1600/");
            s = s.Replace("/s94/", "/s1600/");
            s = s.Replace("/s110/", "/s1600/");
            s = s.Replace("/s128/", "/s1600/");
            s = s.Replace("/s288/", "/s1600/");
            s = s.Replace("/s320/", "/s1600/");

            s = s.Replace("/s800/", "/s1600/");

            //s=s.Replace("/s1600/","/s1600/" /"");
            s = s.Replace("smalls", "1024x768");
            s = s.Replace("w160h", "1024x768");
            s = s.Replace("w240h", "1024x768");
            s = s.Replace("bigs500x320", "1024x768");
            s = s.Replace("w642h", "1024x768");
            s = s.Replace("sources", "1024x768");
            s = s.Replace("border=\"0\"", "");

            s = s.Replace("alt=\"\"", "");
            s = s.Replace("alt=", "al=");
            s = s.Replace("src=", "title=\"Upload Bởi BlogTruyen.Com\" alt=\"BlogTruyen.Com - Blog Truyện Tranh Online Siêu Tốc\" src=\"");
            s = s.Replace("alt=\"upanh.com\"", "alt=\"blogtruyen.com\"");
            s = s.Replace("img.photo.zing.vn", "d.f2.photo.zdn.vn");
            s = s.Replace("t.f6.photo.zdn.vn", "d.f6.photo.zdn.vn");
            s = s.Replace("href=\"", "href=\"#copy\" cop=\"");
            s = s.Replace("href=\"", "href=\"#copy\" cop=\"");
            s = s.Replace("[URL=", "<a href=\"#copy\" cop=\"");
            s = s.Replace(".html\"]", "\">");
            s = s.Replace(".html]", "\">");
            s = s.Replace("[/URL]", "</a><br/>");
            s = s.Replace("[IMG]", "<a href=\"#copy\"><img  title=\"Upload Bởi BlogTruyen.Com\" alt=\"BlogTruyen.Com - Blog Truyện Tranh Online Siêu Tốc\" src=\"");
            s = s.Replace("[img]", "<a href=\"#copy\"><img  title=\"Upload Bởi BlogTruyen.Com\" alt=\"BlogTruyen.Com - Blog Truyện Tranh Online Siêu Tốc\" src=\"");
            s = s.Replace("[/IMG]", " /></a><br/>");
            s = s.Replace("[/img]", "\" /></a><br/>");
            s = s.Replace("src=\"http://diendan.truyenmoi.com/images/statusicon/wol_error.gif\"", "");
            s = s.Replace("2sou", "sources");
            s = s.Replace("_130_130", "");
            s = s.Replace("_574_0", "");
            s = s.Replace("_574_574", "");
            s = s.Replace("PhotoHandler.ashx?actions=", "pic/");
            s = s.Replace("&auth=", "/");
            s = s.Replace("&api=", "/");
            s = s.Replace("&mz=", "/");
            s = s.Replace("&mz=", "/");


            s = s.Replace("textarea", "");
            s = s.Replace("<img", "<br/><img");

            s = s.Replace("http://img514.imageshack.us/img514/795/adsclick.gif", "");
            s = s.Replace("14.695.18930286.5Bl0/1.jpg", "16.147.20471380.42j0/check.png");
            s = s.Replace("id=\"", "dst1=\"");
            s = s.Replace("class=\"", "dst2=\"");
            s = s.Replace("style=\"", "dst3=\"");
            s = s.Replace("prereplinkx1", "href=\"http://x1.blogtruyen.com");
            s = s.Replace("prereplinkx2", "href=\"http://x2.blogtruyen.com");
            s = s.Replace("iframe", "");
            s = s.Replace("script", "");
            s = s.Replace("http://up.blogtruyen", "ggucthttp://up.blogtruyen");
            s = s.Replace("http://i.imgur.com", "ggucthttp://i.imgur.com");
            s = s.Replace("http://edge.imgur.com", "ggucthttp://i.imgur.com");
            s = s.Replace("http://imgur.com", "ggucthttp://imgur.com");
            s = s.Replace("prefocus", "http://images2-focus-opensocial.googleusercontent");
            s = s.Replace("gguct", "http://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&resize_h=0&rewriteMime=image%2F*&url=");
            //s = s.Replace("preguser","image%2F\*&url=http");s = s.Replace("<img","<img class="m_picture"");
            s = s.Replace(".jpg", ".jpg?imgmax=2000"); s = s.Replace(".JPG", ".JPG?imgmax=2000");
            s = s.Replace(".png", ".png?imgmax=2000"); s = s.Replace(".PNG", ".PNG?imgmax=2000");
            s = s.Replace(".gif", ".gif?imgmax=2000"); s = s.Replace(".GIF", ".GIF?imgmax=2000");
            s = s.Replace(".bmp", ".bmp?imgmax=2000"); s = s.Replace(".BMP", ".BMP?imgmax=2000");
            s = s.Replace("?imgmax=2000?imgmax=2000", "?imgmax=2000");
            s = s.Replace("?imgmax=1600?imgmax=2000", "?imgmax=2000");
            s = s.Replace("?imgmax=2000?imgmax=1600", "?imgmax=2000");
            s = s.Replace("?imgmax=1600?imgmax=1600", "?imgmax=2000");
            return s;
        }
  
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);
            //html = ReplaceText(html);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var textare = doc.DocumentNode.SelectSingleNode("//*[@id=\"blogtruyencopy\"]");

            //var images = doc.DocumentNode.Descendants("img")
            //                .Where(p => p.Attributes.Contains("src") &&
            //                        p.Attributes["src"].Value.StartsWith("http://img.photo.zing.vn"))
            //                .Select(p=>p.Attributes["src"].Value.Replace("http://img.photo.zing.vn","http://d.f2.photo.zdn.vn"))

            //                .ToList();
            List<string> result = new List<string>();

            var matches = Regex.Matches(textare.InnerHtml, "https?://[\\*&=?%0-9a-zA-Z._/-]*(.jpg|.JPG|.png|.PNG)");
            if (matches != null)
            {
                foreach (Match  match in matches)
                {
                    //if(match.Value.Contains("die-report")) break;
                    string url = ReplaceText(match.Value);
                    //if (!IsDump(url)) 
                        result.Add(url);
                }
            }
            //

            //foreach (HtmlNode  node in  images)
            //{
            //    result.Add(node.Attributes["src"].Value);
            //}
            return result.Distinct().ToList();
        }

        private bool IsDump(string url)
        {
            return url.Contains("button") ||
                    url.Contains("black50") ||
                    url.Contains("die-report")||
                    url.Contains("newGB1-zip");

        }

       
    }
}
