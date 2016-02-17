using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace ComicDownloader.Engines
{
    [Downloader("truyen.qiqi.vn", Offline = false, MenuGroup = "U-Z", MetroTab = "Tiếng Việt", Language = "Tieng viet", Image32 = "_1364410887_Add")]
    public class TruyenQiQuiVNDownloader
        : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyen.qiqi.vn/template/frontend/images/logo.png";
            }
        }

        public override string StoryUrlPattern
        {
            get
            {
                return HostUrl + "/{0}/";
            }

        }
        public override string HostUrl
        {
            get
            {
                return "http://truyen.qiqi.vn";
            }
        }
        public override string ListStoryURL
        {
            get
            {
                return "http://truyen.qiqi.vn/danh-sach-truyen-tranh/";
            }

        }

        public override List<StoryInfo> HotestStories() { throw new NotImplementedException(); }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            return base.GetListStoriesSimple("http://truyen.qiqi.vn/danh-sach-truyen-tranh/trang-{0}.html",
                "//div[@id='content_category']//p[contains(@class,'ind_text')]/a", 
                forceOnline);
        }

        public override StoryInfo RequestInfo(string url)
        {
            return base.RequestInfoSimple(url,
                "//h1",
                "//*[@class='info_content']//a");
        }
        public override string Name
        {
            get { return "[Truyen QiQi] - "; }
        }

        public override List<string> GetPages(string chapUrl)
        {
            return base.GetPagesSimple(chapUrl, "//div[contains(@class,'dtl_img')]//img");
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            return base.GetLastestUpdateSimple("http://truyen.qiqi.vn/danh-sach-truyen-tranh/trang-{0}.html", "//div[@id='content_category']//p[contains(@class,'ind_text')]/a", "",null, 3);
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            return base.OnlineSearchGet("http://truyen.qiqi.vn/tim-kiem/trang-{0}.html?q=" + keyword, "", 3);
        }
    }
}
