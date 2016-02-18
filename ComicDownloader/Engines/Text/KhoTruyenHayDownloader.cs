﻿using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ComicDownloader.Engines
{
    [Downloader("khotruyenhay.vn", Offline = true, Language = "Truyen chu tieng viet", MenuGroup = "O-S", MetroTab = "Text Tiếng Việt", Image32 = "1364078951_insert-object")]

    //ajax post/get to get list chapter
    public class KhoTruyenHayDownloader : Downloader
    {
        public override string Name
        {
            get { return "[khotruyenhay.vn] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://santruyen.com/"; }
        }

        public override string HostUrl
        {
            get { return "http://khotruyenhay.vn/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }
        public override string Logo
        {
            get
            {
                return "http://khotruyenhay.vn/template/img/logo.png";
            }
        }
        public override List<StoryInfo> HotestStories() {
            return HotestStoriesSimple(this.HostUrl
                , "//div[@id='left-story-read-more']//a[@class='view-item-story-title']", 1);
        }
        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://khotruyenhay.vn/truyen-doc/listNovel.htm?page={0}&status=2&cfil=&cati=&type=&style=grid&author=&psize=200",
                "//li/a[1]",
                forceOnline,convertFunc: (HtmlNode n)=> {
                    return new StoryInfo()
                    {
                        Url = base.EnsureHostName(this.HostUrl, n.Href()),
                        Name = n.Attr("title").Replace("Truyện chữ ", string.Empty)
                    };
                });
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
                "//h2",
                "//div[@class='list-chap']//a", chapterExtract: (HtmlNode n) =>{
                    return new ChapterInfo()
                    {
                        Name = n.InnerText.Trim(),
                        Url = base.EnsureHostName(this.HostUrl, n.Href())
                    };
            });
            return info;
        }
       
        public override List<string> GetPages(string chapUrl)
        {
            return new List<string>() { chapUrl };
        }
        //public override string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chappter = null)
        //{
        //    cc = NetworkHelper.GetCookie(pageUrl, httpReferer);
        //    var html = NetworkHelper.GetHtml(pageUrl, cc);
        //    var match = Regex.Match(html, "load\\(\\\"([^\\\"]*)\\\"\\)");
        //    var ajaxUrl = this.HostUrl + match.Groups[1].Value;
        //    return base.DownloadPage(ajaxUrl, renamePattern, folder, httpReferer, cc, pageUrl, chapter:chappter);
        //}
        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = "http://truyen368.com/truyen-dang-update/trang-{0}.html";
            return base.GetLastestUpdateSimple(lastestUpdateUrl, "//*[@id='comic_full']//td[1]/a[2]", "", null, 3);
        }
        
        public override void AfterPageDownloaded(string filename, ChapterInfo chap)
        {
            
            AfterPageDownloadedSimple(filename, chap.Name, "//div[@class='contents-comic']", "//h2[@class='chapter-number']");

            
        }
        //Use google search 
    }
}
