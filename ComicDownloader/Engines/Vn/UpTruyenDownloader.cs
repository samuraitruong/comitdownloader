using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("Up Truyen", Offline = false, Language = "Tieng viet", MenuGroup = "U->Z", MetroTab="Tiếng Việt", Image32 = "1364078951_insert-object")]
    public class UpTruyenDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://uptruyen.com/public/templates/uptruyen/style/images/uptruyen.com.png";
            }
        }

        public override string LoginUrl
        {
            get
            {
                return "http://uptruyen.com/default/index/login";
            }
        }
        public override string Name
        {
            get { return "[Up Truyen] - "; }
        }
        public override bool Login()
        {
            var data = string.Format("username={0}&password={1}", this.Settings.UserName, this.Settings.Password);
            CookieContainer cookies = null; 
            var html = NetworkHelper.PostHtml(this.LoginUrl, this.HostUrl, data, postProcess:(c)=>
            {
                cookies = c;
            });
            html = NetworkHelper.GetHtml(this.HostUrl, cookies);
            return true;
        }

        public override string ListStoryURL
        {
            get { return "http://uptruyen.com/manga/genre/manga-moi"; }
        }

        public override string HostUrl
        {
            get { return "http://uptruyen.com"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            //GOOD Example for cleanup code.
            return base.GetListStoriesSimple("http://uptruyen.com/manga/genre/manga-moi?&page={0}&order_by=time&order_type=DESC",
                "//h3[@class='title']/a",
                forceOnline,
                this.HostUrl
                );
        }
        
        public override StoryInfo RequestInfo(string storyUrl)
        {
            return base.RequestInfoSimple(storyUrl,
                "//h1//a[last()]",
                "//table[@id='chapter_table']//h4/a",
                this.HostUrl
                );
        }
        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl,
                "//div[@id='reader-box']//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://uptruyen.com/manga/genre/cap-nhat-cuoi/page/{0}", "//ul[@id='search_list']/li//h2/a", "", numberOfpage: 3);
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string url = "http://uptruyen.com/search?page={0}&order_by=&order_type=&search_string=" + keyword;

            return base.OnlineSearchGet(url,
                "//span[@class='tit']/h2/a");
        }
    }
}
