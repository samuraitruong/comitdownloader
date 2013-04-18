using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    [Downloader("Truyen.Lauphim.com", Language = "Tieng viet", MenuGroup = "VN" , MetroTab="Tiếng Việt", Image32 = "_1364410898_file_add")]
    public class TruyenLauPhimDownloader : Downloader
    {
        public override string Logo
        {
            get
            {
                return "http://truyen.lauphim.com/wp-content/themes/glossy-bright/logo.png";
            }
        }

        public override string Name
        {
            get { return "[Truyen Lau Phim] - "; }
        }

        public override string ListStoryURL
        {
            get { return "http://truyen.lauphim.com/manga-list/"; }
        }

        public override string HostUrl
        {
            get { return "http://truyen.lauphim.com/"; }
        }

        public override string StoryUrlPattern
        {
            get { throw new NotImplementedException(); }
        }

        public override List<StoryInfo> GetListStories(bool forceOnline)
        {
            string urlPattern = "http://truyen.lauphim.com/manga-list/all/any/name-az/{0}/";
            //*[@id="sct_content"]/div/div/div[1]/ul
            List<StoryInfo> results = base.ReloadChachedData();
            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();

                string html = NetworkHelper.GetHtml(ListStoryURL);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"pgg\"]//li[last()]/a");
                
                var match = Regex.Match(node.Attributes["href"].Value,@"/(\d*)/$");
                
                int totalPage = int.Parse(match.Groups[1].Value);;
                for (int i = 1; i <= totalPage; i++)
			{
                    string url = string.Format(urlPattern, i);

                     html = NetworkHelper.GetHtml(url);
                     htmlDoc.LoadHtml(html);

                     var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"sct_content\"]//div[contains(@class,\"img_wrp\")]//a[1]");
                    if (nodes != null && nodes.Count > 0)
                    {
                        
                        foreach (var currentNode in nodes)
                        {
                            StoryInfo info = new StoryInfo()
                            {
                                Url = currentNode.Attributes["href"].Value,
                                Name = currentNode.Attributes["title"].Value.Trim()
                            };
                            results.Add(info);
                        }
                    }
                   
                                        
                }

            }
            
            this.SaveCache(results);
            return results;
        }

        public override StoryInfo RequestInfo(string storyUrl)
        {
            var html = NetworkHelper.GetHtml(storyUrl);
            //detect hentai
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

           
            

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"sct_content\"]//h1");

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = nameNode.InnerText
            };

            List<string> urls = new List<string>();

            var pagingNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"pgg\"]");

            if (pagingNode == null) urls.Add(storyUrl);
            else
            {
                var paging = pagingNode.Descendants("a");
                foreach (HtmlNode pNode  in paging)
                {
                    if (!urls.Contains(pNode.Attributes["href"].Value.Trim()))
                        urls.Add(pNode.Attributes["href"].Value.Trim());
                }
            }
            foreach (var pageUrl in urls)
            {
                html = NetworkHelper.GetHtml(pageUrl);
                htmlDoc.LoadHtml(html);

                var chapterNodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"lst\"][1]//a");

                foreach (HtmlNode chapter in chapterNodes)
                {
                    ChapterInfo chap = new ChapterInfo()
                    {
                        Name = chapter.ChildNodes[1].InnerText.Trim(),
                        Url = chapter.Attributes["href"].Value,
                        
                    };
                    var p = @"&(\d*); (.*)";
                    chap.Name = Regex.Replace(chap.Name, @"&#(\d*);(.*)", "$2");
                    chap.ChapId = ExtractID(chap.Name);
                    info.Chapters.Add(chap);
                }
            }
            info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
            return info;
        }
        
        public override List<string> GetPages(string chapUrl)
        {
            var html = NetworkHelper.GetHtml(chapUrl);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"prw\"]//img");
            List<string> results = new List<string>();
           if(nodes!= null)
            foreach (HtmlNode match in nodes)
            {
                results.Add(match.Attributes["src"].Value);
                
            }
            return results;
        }

        public override List<StoryInfo> GetLastestUpdates()
        {
            string lastestUpdateUrl = HostUrl;
            List<StoryInfo> stories = new List<StoryInfo>();
            var html = NetworkHelper.GetHtml(lastestUpdateUrl);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"wpm_pag mng_lts_chp grp\"]/div[@class=\"row\"]/div[@class=\"det\"]/a");

            foreach (HtmlNode node in nodes)
            {
                StoryInfo info = new StoryInfo()
                {
                    Url = node.Attributes["href"].Value,
                    Name = node.ChildNodes[1].InnerText.Trim(),
                    Chapters = new List<ChapterInfo>(),
                };
                var chapters = node.ParentNode.SelectNodes("ul/li/a");
                if (chapters != null)
                {
                    foreach (HtmlNode chap in chapters)
                    {
                        info.Chapters.Add(new ChapterInfo()
                        {
                            Name = chap.ChildNodes[1].InnerText.Trim(),
                            Url = chap.Attributes["href"].Value,
                        });
                    }
                }
                stories.Add(info);
            }
            return stories;
        }

        public override List<StoryInfo> OnlineSearch(string keyword)
        {
            string urlPattern = string.Format("http://truyen.lauphim.com/manga-list/search/{0}/name-az/{1}/", keyword.Replace(" ", "+"), "{0}");

            var results = new List<StoryInfo>();

            int currentPage = 1;
            bool end = false;

            while (currentPage <= Constant.LimitedPageForSearch)
            {
                if (end)
                {
                    break;
                }

                string url = string.Format(urlPattern, currentPage);

                string html = NetworkHelper.GetHtml(url);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class=\"wpm_pag mng_lst tbn\"]/div[contains(@class,'nde')]/div/a");
                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        if (results.Any(p => p.Url == node.Attributes["href"].Value))
                        {
                            end = true;
                            break;
                        }

                        StoryInfo info = new StoryInfo()
                        {
                            Url = node.Attributes["href"].Value,
                            Name = node.Attributes["title"].Value.Trim()
                        };
                        results.Add(info);
                    }
                }

                currentPage++;
            }
            return results;
        }
    }
}
