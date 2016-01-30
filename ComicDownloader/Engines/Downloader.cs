using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;
using System.Net;
using ComicDownloader.Properties;
using HtmlAgilityPack;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ComicDownloader.Engines
{
    public delegate string ResolveImageOnPage(string pageUrl);
    public delegate void AfterCookieSet();
    public delegate void ListPageCrawled(List<StoryInfo> listStories);


    public class StoryComparer : IComparer<StoryInfo>
    {
        public int Compare(StoryInfo x, StoryInfo y)
        {
            return string.CompareOrdinal(x.Name, y.Name);
        }
    }

    public abstract class Downloader
    {
        public virtual int MaxThreadCrawlList { get; set; }
        public List<StoryInfo> AllStories { get; set; }
        public abstract string Name { get; }
        public abstract  string ListStoryURL { get;  }
        public abstract string HostUrl { get; }
        public virtual bool InitCookie()
        {
            return false;
        }
        private CookieContainer Cookies = null;

        public event AfterCookieSet AfterCookieSet;
        public event ListPageCrawled OnListPageCrawled;

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookieEx(
        string url,
        string cookieName,
        StringBuilder cookieData,
        ref int size,
        Int32 dwFlags,
        IntPtr lpReserved);

        private const Int32 InternetCookieHttponly = 0x2000;

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
       
        /// <summary>
        /// Gets the URI cookie container.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            CookieContainer cookies = null;
            // Determine the size of the cookie
            int datasize = 8192 * 16;
            StringBuilder cookieData = new StringBuilder(datasize);
            if (!InternetGetCookieEx(uri.ToString(), null, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(
                    uri.ToString(),
                    null, cookieData,
                    ref datasize,
                    InternetCookieHttponly,
                    IntPtr.Zero))
                    return null;
            }
            if (cookieData.Length > 0)
            {
                cookies = new CookieContainer();
                cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }
            return cookies;
        }

        //this function to create a web browser/load cookies from browser
        public virtual void EnsureCookies()
        {
            //var webBrowser1 = new System.Windows.Forms.WebBrowser();
            //webBrowser1.Navigated += WebBrowser1_Navigated;
            //webBrowser1.Navigate(this.HostUrl);

        }

        //private void WebBrowser1_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        //{
        //    //this.Cookies = GetUriCookieContainer(new Uri(this.HostUrl));
        //    if(AfterCookieSet != null)
        //    {
        //        AfterCookieSet();
        //    }
        //}

        public HtmlDocument GetParser(string url)
        {
            if (url.StartsWith("http"))
            {
                url = NetworkHelper.GetHtml(url);
            }
            var doc = new HtmlDocument();
            doc.LoadHtml(url);
            return doc;
        }
        public virtual string ServiceUrl
        {
            get
            {
                return string.Empty;
            }
        }
        public abstract string StoryUrlPattern { get; }
        public virtual string Logo { get {
            return string.Empty;
        } }

        //public abstract List<StoryInfo> GetListStories();
        public abstract StoryInfo RequestInfo(string storyUrl);

        public abstract List<string> GetPages(string chapUrl);

        public StoryInfo RequestInfoSimple(string storyUrl, string namePattern, string chapterPattern, string appendHostUrl="", Func<HtmlNode, string> nameExtract = null, Func<HtmlNode, ChapterInfo> chapterExtract = null, Func<string, HtmlDocument, List<ChapterInfo>> customChapterExtract= null)
        {
            var html = NetworkHelper.GetHtml(storyUrl);

            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var nameNode = htmlDoc.DocumentNode.SelectSingleNode(namePattern);
            string chapterName = (nameExtract != null )? nameExtract(nameNode) : nameNode.InnerText.Trim().Trim();

            StoryInfo info = new StoryInfo()
            {
                Url = storyUrl,
                Name = chapterName
            };

            var chapNodes = htmlDoc.DocumentNode.SelectNodes(chapterPattern);
            if (chapNodes != null) {
                foreach (HtmlNode node in chapNodes)
                {
                    var chapInfo = chapterExtract != null ? chapterExtract(node) : new ChapterInfo()
                    {
                        Name = (node.Attributes["title"] != null && !string.IsNullOrEmpty(node.Attributes["title"].Value)) ? node.Attributes["title"].Value : node.InnerText.Trim().Trim(),
                        Url = appendHostUrl + node.Attributes["href"].Value.Trim(),
                    };
                    chapInfo.ChapId = ExtractID(chapInfo.Name);
                    info.Chapters.Add(chapInfo);
                }

                info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
                return info;

            }
            else
            {
                if(customChapterExtract != null)
                {
                    var list = customChapterExtract(html, htmlDoc);
                    info.Chapters.AddRange(list);
                }
            }
            return info;
        }

        internal List<string> GetPagesRegex(string chapUrl, string pattern, string hostExpanded="", Func<Match, string> customMatch=null)
        {
            var html = NetworkHelper.GetHtml(chapUrl);
            var matches = Regex.Matches(html, pattern);
            List<string> pages = new List<string>();

            foreach (Match match in matches)
            {
                if (customMatch != null)
                {
                    pages.Add(customMatch(match));
                }
                else
                {
                    pages.Add(match.Groups[1].Value);
                }
            }

            return pages;
        }

        public List<StoryInfo> GetListStoriesUnknowPages(string startUrl, string matchPattern, bool forceOnline, string pagingPattern, Func<HtmlNode, string> pagingExtract= null, string appendHost = "", Func<HtmlNode, StoryInfo> convertFunc = null, Func<string, HtmlDocument, List<StoryInfo>> customParser = null, bool singleListPage = false, Func<string,HtmlDocument, List<String>> allLinksExtract=null)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startUrl);
            List<string> alllinks = new List<string>() { startUrl };

            List<StoryInfo> results = this.ReloadChachedData();

            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
                while (queue.Count>0)
                {
                    string url = queue.Dequeue();
                    string html = NetworkHelper.GetHtml(url);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    var isStillHasPage = true;
                    var nodes = htmlDoc.DocumentNode.SelectNodes(matchPattern);
                    var links = new List<String>();
                    #region grab links/paging
                    if (allLinksExtract != null)
                    {
                        links = allLinksExtract(html, htmlDoc);
                    }
                    else
                    {
                        var paging =  htmlDoc.DocumentNode.SelectNodes(pagingPattern);
                        if (paging != null)
                        {
                            foreach (var p in paging)
                            {
                                var pageUrl = appendHost + p.Attributes["href"].Value;
                                links.Add(pageUrl);
                            }
                        }
                    }

                    foreach (var item in links)
                    { 
                        if (!alllinks.Contains(item))
                        {
                            alllinks.Add(item);
                            queue.Enqueue(item);
                        }
                    }
                    #endregion

                    if (nodes != null && nodes.Count > 0)
                    {
                        currentPage++;
                        foreach (var node in nodes)
                        {
                            if (convertFunc != null)
                            {
                                results.Add(convertFunc(node));
                            }
                            else
                            {
                                StoryInfo info = new StoryInfo()
                                {
                                    Url = appendHost + node.Attributes["href"].Value,
                                    Name = node.Attributes["title"] != null && !string.IsNullOrEmpty(node.Attributes["title"].Value) ? node.Attributes["title"].Value.Trim() : node.InnerText.Trim().Trim()
                                };
                                results.Add(info);
                            }
                        }
                    }
                    else
                    if (customParser != null)
                    {
                        currentPage++;
                        var listparsed = customParser(html, htmlDoc);
                        if (listparsed != null && listparsed.Count > 0)
                        {
                            results.AddRange(listparsed);
                        }
                        else
                        {
                            isStillHasPage = false;
                        }
                    }
                    else
                    {
                        isStillHasPage = false;
                    }

                    //only process 1 page
                    if (singleListPage)
                    {
                        isStillHasPage = false;
                    }
                }

            }
            this.SaveCache(results);
            return results;
        }

        internal string ExtractImage(string pageUrl, string pattern)
        {
            var html = NetworkHelper.GetHtml(pageUrl);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var img = htmlDoc.DocumentNode.SelectSingleNode(pattern);
            var imgUrl = img.Attributes["src"].Value;
            return imgUrl;

        }
        private List<StoryInfo> CrawlOnePage(string url, string matchPattern, string appendHost = "", Func<HtmlNode, StoryInfo> convertFunc = null, Func<string, HtmlDocument, List<StoryInfo>> customParser = null)
        {
            var results1 = new List<StoryInfo>();
            string html = NetworkHelper.GetHtml(url, this.Cookies);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes(matchPattern);
            if (nodes != null && nodes.Count > 0)
            {
                foreach (var node in nodes)
                {
                    if (convertFunc != null)
                    {
                        results1.Add(convertFunc(node));
                    }
                    else
                    {
                        StoryInfo info = new StoryInfo()
                        {
                            Url = appendHost + node.Attributes["href"].Value,
                            Name = node.Attributes["title"] != null && !string.IsNullOrEmpty(node.Attributes["title"].Value) ? node.Attributes["title"].Value.Trim() : node.InnerText.Trim().Trim()
                        };
                        results1.Add(info);
                    }
                }
            }
            else
            if (customParser != null)
            {
                var listparsed = customParser(html, htmlDoc);
                if (listparsed != null && listparsed.Count > 0)
                {
                    results1.AddRange(listparsed);
                }
            }

            if(this.OnListPageCrawled != null)
            {
                this.OnListPageCrawled(results1);
            }
            return results1;
        }
        public List<StoryInfo> GetListStoriesSimple(string urlPattern,string matchPattern, bool forceOnline, string appendHost="", Func<HtmlNode, StoryInfo> convertFunc = null,   Func<string, HtmlDocument, List<StoryInfo>> customParser= null, bool singleListPage= false)
        {            
            List<StoryInfo> results = this.ReloadChachedData();

            if (results == null || results.Count == 0 || forceOnline)
            {
                results = new List<StoryInfo>();
                int currentPage = 1;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {
                    var tasks = new List<Task<List<StoryInfo>>>();

                    foreach (var item in Enumerable.Range(1, singleListPage?1: MaxThreadCrawlList))
                    {
                        string url = string.Format(urlPattern, currentPage++);
                        var oneTask = new Task<List<StoryInfo>>(() => this.CrawlOnePage(url, matchPattern, appendHost, convertFunc, customParser));
                        tasks.Add(oneTask);
                        oneTask.Start();
                    }
                    Task.WaitAll(tasks.ToArray(),100);

                    foreach (var item in tasks)
                    {
                        if (item.Result.Count > 0) {
                            results.AddRange(item.Result);
                        }
                        else
                        {
                            isStillHasPage = false;
                        }
                    }
                    if (singleListPage)
                    {
                        isStillHasPage = false;
                    }
                }

                //sort result 
                results = results.OrderBy(p => p.Name).ToList();

            }
            this.SaveCache(results);
            return results;
        }

        public List<string> GetPagesSimple(string chapUrl, string pattern, Func<string, List<string>> customExtractor=null, string hostExpanded="", Func<HtmlNode, string> imgExtract= null,string imgAttrName="src")
        {
            List<string> pages = new List<string>();
            var html = NetworkHelper.GetHtml(chapUrl);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes(pattern);
            if (nodes != null)
            {
                foreach (HtmlNode item in nodes)
                {
                    if (imgExtract != null)
                    {
                        pages.Add(imgExtract(item));
                    }
                    else {
                        pages.Add(hostExpanded + item.Attributes[imgAttrName].Value);
                    }
                }
            }
            else
            {
                if(customExtractor != null)
                {
                    return customExtractor(html);
                }
            }
            return pages;
        }
        
        public string CachedFile { get {
            
            return Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData)+"\\ComicDownloader\\"+ this.GetType().Name + ".CACHED";
        
        } }


        public virtual List<StoryInfo> GetLastestUpdates()
        {
            return new List<StoryInfo>();
        }

        public virtual List<StoryInfo> OnlineSearch(string keyword)
        {
            return new List<StoryInfo>();
        }
        /// <summary>
        /// online = true, will search online, false will search on cache data load before.
        /// Recache = true,
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="online"></param>
        /// <param name="recache"></param>
        /// <returns></returns>
        public List<StoryInfo> Search(string keyword, bool online, bool recache)
        {
            if (online) return OnlineSearch(keyword);

            List<StoryInfo> results = new List<StoryInfo>();

            if (recache)
            {
                
                results = GetListStories(true);
            }
            else
            {
                results = ReloadChachedData();
            }


            if (results != null)
                {
                    results = results.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
                }
            
            return results;
        }
        public ResolveImageOnPage ResolveImageInHtmlPage { get; set; }

        public virtual string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            if(this.ResolveImageInHtmlPage != null)
            {
                pageUrl = this.ResolveImageInHtmlPage(pageUrl);
            }
            pageUrl = Helpers.UrlHelper.TryFixUrl(pageUrl);
            string filename = Path.GetFileName(pageUrl);
            if(filename.Contains("?"))
            {
                filename = filename.Substring(0, filename.IndexOf("?"));
            }

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Referer", httpReferer);
                try
                {

                    string replaceFileName = renamePattern.Replace("{FILENAME}", filename);

                    filename = Path.Combine(folder, replaceFileName);
                    client.DownloadFile(pageUrl, filename);
                }
                catch 
                {
                }
            }
            return filename;
        }
        public void SaveCache(List<StoryInfo> stories)
        {
            var temp = Path.GetTempPath() + Path.GetRandomFileName();
            var xml = SerializationHelper.SerializeToXml<List<StoryInfo>>(stories);
            using (var file = new StreamWriter(File.Open(temp, FileMode.OpenOrCreate)))
            {
                file.Write(xml);
            }
            
            Directory.CreateDirectory(Path.GetDirectoryName(CachedFile));
            SecureHelper.EncryptFile(temp, CachedFile, Resources.SecureKey);
        }

        public List<StoryInfo> ReloadChachedData()
        {

            if (File.Exists(this.CachedFile))
            {
                var temp = Path.GetTempPath()+ Path.GetRandomFileName();

                SecureHelper.DecryptFile(CachedFile, temp, Resources.SecureKey);

                using (var file = File.OpenText(temp))
                {
                    return SerializationHelper.DeserializeFromXml<List<StoryInfo>>(file.ReadToEnd());
                }
            }
            return null;
        }

        public int ExtractID(string name, string pattern)
        {
            var match = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
            if (match != null)
            {
                int id = 0;
                int.TryParse(match.Groups[1].Value, out id);
                return id;
            }
            return 0;

        }

        public int ExtractID(string name)
        {
            int id= ExtractID(name, @".*\s(\d*)$");
            if (id > 0) return id;

            id=  ExtractID(name, @".*\s(\d*)\s.*");
            if (id > 0) return id;

            return ExtractID(name,@"\d\d*");
            
        }

        internal  void DeleteCached()
        {
            try
            {
                File.Delete(this.CachedFile);
            }
            finally
            {

            }
        }
        private static List<Downloader> _downloaders;

        public static Downloader Resolve(string url)
        {
            return GetAllDownloaders().FirstOrDefault(p => url.Contains(p.HostUrl));
        }
        public static List<Downloader> GetAllDownloaders()
        {
           
            if (_downloaders != null) return _downloaders;
            _downloaders = new List<Downloader>();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var item in types)
            {
                if (item.BaseType == typeof(Downloader))
                {
                    Downloader instance = (Downloader)Activator.CreateInstance(item);

                    var attributes = instance.GetType().GetCustomAttributes(typeof(DownloaderAttribute), true);
                    if (attributes.Length>0  && !((DownloaderAttribute)attributes[0]).Offline)
                    {
                       

                        _downloaders.Add(instance);
                    }
                }
            }
            return _downloaders;
        }

        

        public abstract List<StoryInfo> GetListStories(bool forceOnline);
        //{
        //    //if (force)
        //    //{
        //    //    File.Delete(this.CachedFile);
        //    //    return GetListStories();
        //    //}
        //    //else
        //    //{
        //    //    if (!File.Exists(CachedFile)) return new List<StoryInfo>();


        //    //}

        //    //return ReloadChachedData();

        //}

        public Downloader()
        {
            //this.InitCookie();
            this.Cookies = GetUriCookieContainer(new Uri(this.HostUrl));
            this.MaxThreadCrawlList = SettingForm.GetSetting().MaxThreadCrawlList;
        }
    }
}
