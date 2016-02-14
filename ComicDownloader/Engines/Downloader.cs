using System;
using System.Net;
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
using System.Diagnostics;
using MoreLinq;

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
        public DownloaderSetting Settings { get; set; }

        public virtual int MaxThreadCrawlList { get; set; }
        public virtual int NumberRetryWhenFailed { get; set; }
        public List<StoryInfo> AllStories { get; set; }
        public abstract string Name { get; }
        public abstract string ListStoryURL { get; }
        public abstract string HostUrl { get; }

        public virtual int MaxRequestInfoChapterThread
        {
            get
            {
                return Math.Max(this.MaxThreadCrawlList, 8);
            }
        }
        public virtual bool InitCookie()
        {
            return false;
        }

        public List<StoryInfo> GetLastestUpdateSimple(string pageUrl, string storyNodePattern, string chapterPattern, Func<HtmlNode, StoryInfo> storyExtractor = null, int numberOfpage = 1)
        {
            List<StoryInfo> result = new List<StoryInfo>();
            List<Task> listTask = new List<Task>();
            for (var i = 1; i <= numberOfpage; i++)
            {
                string url = string.Format(pageUrl, i);
                var task = Task.Run(() =>
                {
                    var htmlDoc = GetParser(url);
                    var nodes = htmlDoc.DocumentNode.SelectNodes(storyNodePattern);
                    if (nodes != null)
                    {
                        foreach (HtmlNode node in nodes)
                        {
                            StoryInfo info = null;
                            if (storyExtractor != null)
                            {
                                info = storyExtractor(node);
                            }
                            else
                            {
                                info = new StoryInfo()
                                {
                                    Name = node.Attributes["title"] != null ? node.Attributes["title"].Value : node.InnerText.Trim(),
                                    Url = EnsureHostName("", node.Attributes["href"].Value)

                                };
                            }
                            info.Beautifier();
                            lock (result)
                            {
                                result.Add(info);
                            }
                        }
                    }

                });
                listTask.Add(task);

            }
            Task.WaitAll(listTask.ToArray());

            return result;
        }

        private CookieContainer Cookies = null;

        public event AfterCookieSet AfterCookieSet;
        public event ListPageCrawled OnListPageCrawled;
        public event ListPageCrawled OnSearchPageFinished;
        public event ListPageCrawled OnHostestPageCrawled;
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
        public virtual string LoginUrl
        {
            get { return string.Empty; }
        }

        public abstract string StoryUrlPattern { get; }
        public virtual string Logo
        {
            get
            {
                return string.Empty;
            }
        }

        //public abstract List<StoryInfo> GetListStories();
        public abstract StoryInfo RequestInfo(string storyUrl);

        public virtual bool Login()
        {
            return true;
        }
        public abstract List<string> GetPages(string chapUrl);

        public StoryInfo RequestInfoSimple(string storyUrl, string namePattern, string chapterPattern, string appendHostUrl = "", Func<HtmlNode, string> nameExtract = null, Func<HtmlNode, ChapterInfo> chapterExtract = null, Func<string, HtmlDocument, List<ChapterInfo>> customChapterExtract = null, string chapPagingPattern = "", Func<string, HtmlDocument, List<string>> customChapPagingExtract = null, Func<HtmlNode, string> chapPagingNodeExtract=null)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(storyUrl);
            List<string> alllinks = new List<string>() { storyUrl };
            StoryInfo info = null;

            while (queue.Count > 0)
            {
                var threadCount = Math.Min(this.MaxRequestInfoChapterThread,Math.Min(queue.Count, this.MaxThreadCrawlList));
                var patch = Enumerable.Range(1, threadCount).Select(p => queue.Dequeue());

                var parallelResult = Parallel.ForEach(patch, (currentPageUrl) =>
                {
                    var html = NetworkHelper.GetHtml(currentPageUrl);

                    HtmlDocument htmlDoc = new HtmlDocument();

                    htmlDoc.LoadHtml(html);

                    var nameNode = htmlDoc.DocumentNode.SelectSingleNode(namePattern);
                    string chapterName = (nameExtract != null) ? nameExtract(nameNode) : nameNode.InnerText.Trim().Trim();
                    if (info == null)
                    {
                        info = new StoryInfo()
                        {
                            Url = storyUrl,
                            Name = chapterName
                        };
                    }

                    var chapNodes = htmlDoc.DocumentNode.SelectNodes(chapterPattern);
                    if (chapNodes != null)
                    {
                        foreach (HtmlNode node in chapNodes)
                        {
                            var chapInfo = chapterExtract != null ? chapterExtract(node) : new ChapterInfo()
                            {
                                Name = (node.Attributes["title"] != null && !string.IsNullOrEmpty(node.Attributes["title"].Value)) ? node.Attributes["title"].Value : node.InnerText.Trim().Trim(),
                                Url = EnsureHostName(appendHostUrl, node.Attributes["href"].Value.Trim()),
                            };
                            chapInfo.ChapId = ExtractID(chapInfo.Name);
                            info.Chapters.Add(chapInfo);
                        }

                        info.Chapters = info.Chapters.OrderBy(p => p.ChapId).ToList();
                    }
                    else
                    {
                        if (customChapterExtract != null)
                        {
                            var list = customChapterExtract(html, htmlDoc);
                            info.Chapters.AddRange(list);
                        }
                    }
                    List<string> pagingLinks = new List<string>();
                    if (customChapPagingExtract != null)
                    {
                        pagingLinks = customChapPagingExtract(html, htmlDoc);

                    }
                    else
                    if (!string.IsNullOrEmpty(chapPagingPattern))
                    {
                        var pagingNodes = htmlDoc.DocumentNode.SelectNodes(chapPagingPattern);
                        if (pagingNodes != null)
                        {
                            foreach (HtmlNode item in pagingNodes)
                            {
                                if(item.Attributes["href"]== null || 
                                item.Attributes["href"].Value.StartsWith("javascript"))
                                {
                                    continue;
                                };

                                string link = chapPagingNodeExtract != null ? chapPagingNodeExtract(item) : EnsureHostName(this.HostUrl, item.Attributes["href"].Value);
                                pagingLinks.Add(link);
                            }
                        }
                    }
                    lock (alllinks)
                    {
                        foreach (var item in pagingLinks)
                        {
                            if (!alllinks.Contains(item))
                            {
                                alllinks.Add(item);
                                queue.Enqueue(item);
                            }
                        }
                    }
                });
            }
            info.Chapters = info.Chapters.DistinctBy(p => p.Url).ToList();
            return info;
        }

        internal List<string> GetPagesRegex(string chapUrl, string pattern, string hostExpanded = "", Func<Match, string> customMatch = null)
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

        public string EnsureHostName(string hostUrl, string url)
        {
            if (url.StartsWith("http")) return url;
            if (string.IsNullOrEmpty(hostUrl))
            {
                hostUrl = this.HostUrl;
            }

            string newUrl = hostUrl + "/" + url;
            var left = newUrl.Substring(0, 8);
            var right = newUrl.Substring(8).Replace("//", "/");

            return left + right;
        }
        public List<StoryInfo> GetListStoriesUnknowPages(string startUrl, string matchPattern, bool forceOnline, string pagingPattern, Func<HtmlNode, string> pagingExtract = null, string appendHost = "", Func<HtmlNode, StoryInfo> convertFunc = null, Func<string, HtmlDocument, List<StoryInfo>> customParser = null, bool singleListPage = false, Func<string, HtmlDocument, List<String>> allLinksExtract = null)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startUrl);
            List<string> alllinks = new List<string>() { startUrl };

            var catchItem = this.ReloadChachedData();
            List<StoryInfo> results = catchItem.Stories;
            Stopwatch clock = new Stopwatch();

            if (results == null || results.Count == 0 || forceOnline)
            {
                clock.Start();
                results = new List<StoryInfo>();
                while (queue.Count > 0)
                {
                    var threadCount = Math.Min(queue.Count, this.MaxThreadCrawlList);
                    var patch = Enumerable.Range(1, threadCount).Select(p => queue.Dequeue());

                    var parallelResult = Parallel.ForEach(patch, (currentPageUrl) =>
                    {

                        var listStories = this.CrawlOnePage(currentPageUrl, matchPattern, 0, appendHost, convertFunc, customParser,
                        pagingCrawler: (HtmlDocument doc, string rawhtml) =>
                        {

                            var links = new List<String>();
                            #region grab links/paging
                            if (allLinksExtract != null)
                            {
                                links = allLinksExtract(rawhtml, doc);
                            }
                            else
                            {
                                var paging = doc.DocumentNode.SelectNodes(pagingPattern);
                                if (paging != null)
                                {
                                    foreach (var p in paging)
                                    {
                                        if (p.Attributes["href"] == null || p.Attributes["href"].Value.StartsWith("javascript"))
                                            continue;

                                        var href = p.Attributes["href"].Value;
                                        
                                        var pageUrl = pagingExtract!= null? pagingExtract(p): EnsureHostName(appendHost, p.Attributes["href"].Value);
                                        links.Add(pageUrl);
                                    }
                                }
                            }
                            lock (alllinks)
                            {
                                foreach (var item in links)
                                {
                                    if (!alllinks.Contains(item))
                                    {
                                        alllinks.Add(item);
                                        queue.Enqueue(item);
                                    }
                                }
                            }
                            #endregion
                        });

                        if (this.OnListPageCrawled != null)
                        {
                            this.OnListPageCrawled(listStories);
                        }

                        lock (results)
                        {
                            results.AddRange(listStories);
                        }

                    });
                }
                results = results.OrderBy(p => p.Name).ToList();

                clock.Stop();
                this.SaveCache(results, clock.ElapsedMilliseconds);
            }
            return results;
        }

        public List<ChapterInfo> NormalizedChaptersSimple(List<ChapterInfo> chapters)
        {
            var story = chapters[0].Story;
            var list = new List<ChapterInfo>();
            var nomalized = new ChapterInfo()
            {
                Name =  story.Name,
                Pages = new List<string>()
            };
            foreach (var item in chapters)
            {
                nomalized.Pages.Add(item.Url);
            }
            return list;

        }
        internal List<ChapterInfo> NormalizedChapters(List<ChapterInfo> toBeDownloadedChapters)
        {
            //override on text downloader to merge all chapter to become 1 chapter with multiple pages
            return toBeDownloadedChapters;
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
        private List<StoryInfo> CrawlOnePage(string url, string matchPattern, int retry = 0, string appendHost = "", Func<HtmlNode, StoryInfo> convertFunc = null, Func<string, HtmlDocument, List<StoryInfo>> customParser = null, Action<HtmlDocument, string> pagingCrawler = null)
        {
            var results1 = new List<StoryInfo>();
            string html = NetworkHelper.GetHtml(url, this.Cookies);
            if (html == "HTTP ERROR" && retry <= this.NumberRetryWhenFailed)
            {
                return CrawlOnePage(url, matchPattern, retry++, appendHost, convertFunc, customParser, pagingCrawler);
            }
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            if (pagingCrawler != null)
            {
                pagingCrawler(htmlDoc, html);
            }

            if (!string.IsNullOrEmpty(matchPattern))
            {
                var nodes = htmlDoc.DocumentNode.SelectNodes(matchPattern);


                if (nodes != null && nodes.Count > 0)
                {
                    foreach (var node in nodes)
                    {
                        StoryInfo info = null;
                        if (convertFunc != null)
                        {
                            info = convertFunc(node);
                        }
                        else
                        {
                            info = new StoryInfo()
                            {
                                Url = EnsureHostName(appendHost, node.Attributes["href"].Value),
                                Name = node.Attributes["title"] != null && !string.IsNullOrEmpty(node.Attributes["title"].Value) ? node.Attributes["title"].Value.Trim() : node.InnerText.Trim().Trim()
                            };
                        }
                        info.Beautifier();
                        results1.Add(info);
                    }
                }
            }
            if (customParser != null && results1.Count == 0)
            {
                var listparsed = customParser(html, htmlDoc);
                if (listparsed != null && listparsed.Count > 0)
                {
                    results1.AddRange(listparsed);
                }
            }

            return results1;
        }

        public List<StoryInfo> GetListStoriesSimple(string urlPattern, string matchPattern, bool forceOnline, string appendHost = "", Func<HtmlNode, StoryInfo> convertFunc = null, Func<string, HtmlDocument, List<StoryInfo>> customParser = null, bool singleListPage = false)
        {
            var catchItem = this.ReloadChachedData();
            List<StoryInfo> results = catchItem.Stories;
            Stopwatch clock = new Stopwatch();
            if (results == null || results.Count == 0 || forceOnline)
            {
                clock.Start();
                results = new List<StoryInfo>();
                int currentPage = 1;
                bool isStillHasPage = true;
                while (isStillHasPage)
                {
                    var tasks = new List<Task<List<StoryInfo>>>();

                    foreach (var item in Enumerable.Range(1, singleListPage ? 1 : MaxThreadCrawlList))
                    {
                        string url = string.Format(urlPattern, currentPage++);
                        var oneTask = new Task<List<StoryInfo>>(() => this.CrawlOnePage(url, matchPattern, 0, appendHost, convertFunc, customParser));
                        oneTask.ContinueWith((t) =>
                        {
                            if (this.OnListPageCrawled != null)
                            {
                                this.OnListPageCrawled(t.Result);
                            }
                        });
                        tasks.Add(oneTask);
                        oneTask.Start();
                    }
                    Task.WaitAll(tasks.ToArray(), 100);

                    foreach (var item in tasks)
                    {
                        if (item.Result.Count > 0)
                        {
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
                clock.Stop();
                this.SaveCache(results, clock.ElapsedMilliseconds);
            }
            return results;
        }

        public List<string> GetPagesSimple(string chapUrl, string pattern, Func<string, List<string>> customExtractor = null, string hostExpanded = "", Func<HtmlNode, string> imgExtract = null, string imgAttrName = "src")
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
                if (customExtractor != null)
                {
                    return customExtractor(html);
                }
            }
            return pages;
        }

        public string CachedFile
        {
            get
            {

                return Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData) + "\\ComicDownloader\\" + this.GetType().Name + ".CACHED";

            }
        }
        public virtual List<StoryInfo> GetLastestUpdates()
        {
            throw new Exception("must implement this function");
            return new List<StoryInfo>();
        }
        public abstract List<StoryInfo> HotestStories();
        public List<StoryInfo> HotestStoriesSimple(string urlpattern, string nodePattern, int totalPages = 1, Func<HtmlNode, StoryInfo> nodeConvert = null, Func<string, HtmlDocument, List<StoryInfo>> customParser = null)
        {
            var results = new List<StoryInfo>();

            bool isStillHasPage = true;
            var currentPage = 1;
            while (isStillHasPage)
            {
                var tasks = new List<Task<List<StoryInfo>>>();

                foreach (var item in Enumerable.Range(1, Math.Min(totalPages, MaxThreadCrawlList)))
                {
                    string url = string.Format(urlpattern, currentPage++);
                    var oneTask = new Task<List<StoryInfo>>(() => this.CrawlOnePage(url, nodePattern, 0, "", nodeConvert, customParser));
                    oneTask.ContinueWith((t) =>
                    {
                        if (this.OnHostestPageCrawled != null)
                        {
                            this.OnHostestPageCrawled(t.Result);
                        }
                    });
                    tasks.Add(oneTask);
                    oneTask.Start();
                }
                Task.WaitAll(tasks.ToArray(), 100);

                foreach (var item in tasks)
                {
                    if (item.Result.Count > 0)
                    {
                        results.AddRange(item.Result);
                    }
                    else
                    {
                        isStillHasPage = false;
                    }
                }
                if (totalPages > 0 && currentPage >= totalPages)
                {
                    isStillHasPage = false;
                }
            }
            return results.DistinctBy(p => p.Url).ToList();

        }
        public List<StoryInfo> OnlineSearchGet(string urlSearch, string matchPattern, int totalSearchPage = 0, Func<HtmlNode, StoryInfo> nodeConvert = null, Func<String, HtmlDocument, List<StoryInfo>> customParser = null)
        {
            var results = new List<StoryInfo>();

            bool isStillHasPage = true;
            var currentPage = 1;
            while (isStillHasPage)
            {
                var tasks = new List<Task<List<StoryInfo>>>();

                foreach (var item in Enumerable.Range(1, totalSearchPage == 0 ? MaxThreadCrawlList : Math.Min(totalSearchPage, MaxThreadCrawlList)))
                {
                    string url = string.Format(urlSearch, currentPage++);
                    var oneTask = new Task<List<StoryInfo>>(() => this.CrawlOnePage(url, matchPattern, 0, "", nodeConvert, customParser));
                    oneTask.ContinueWith((t) =>
                    {
                        if (this.OnSearchPageFinished != null)
                        {
                            this.OnSearchPageFinished(t.Result);
                        }
                    });
                    tasks.Add(oneTask);
                    oneTask.Start();
                }
                Task.WaitAll(tasks.ToArray(), 100);

                foreach (var item in tasks)
                {
                    if (item.Result.Count > 0)
                    {
                        results.AddRange(item.Result);
                    }
                    else
                    {
                        isStillHasPage = false;
                    }
                }
                if (totalSearchPage > 0 && currentPage >= totalSearchPage)
                {
                    isStillHasPage = false;
                }
            }
            return results;

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
                results = ReloadChachedData().Stories;
            }


            if (results != null)
            {
                results = results.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
            }

            return results;
        }
        public virtual bool IsTextEngines { get; }
        //this is 
        public virtual void AfterPageDownloadedSimple(string filename, string chapterName, string contentPattern = "", string titlePattern = "")
        {
            try
            {
                var fileContents = File.ReadAllText(filename);
                File.Delete(filename);
                using (var stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    string template = Resources.HtmlTemplate;
                    var doc = GetParser(fileContents);
                    if (!string.IsNullOrEmpty(contentPattern))
                    {
                        var node = doc.DocumentNode.SelectSingleNode(contentPattern);
                        if(node!= null)
                        {
                            fileContents = node.InnerHtml;
                        }
                    }
                    
                     if (!string.IsNullOrEmpty(titlePattern))
                    {
                        var node = doc.DocumentNode.SelectSingleNode(titlePattern);
                        if (node != null)
                        {
                            chapterName = node.InnerText.Trim();
                        }
                    }
                    fileContents = fileContents.TryFixHtml();
                    var newContent = template.Replace("[[content]]", fileContents);
                    newContent = newContent.Replace("[[title]]", chapterName.ToUpper());
                    stream.Seek(0, SeekOrigin.Begin);
                    var writer = new StreamWriter(stream);
                    writer.Write(newContent);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        public virtual void AfterPageDownloaded(string filename, ChapterInfo chapter)
        {
            AfterPageDownloadedSimple(filename, chapter.Name);
        }
        public ResolveImageOnPage ResolveImageInHtmlPage { get; set; }
        public StoryInfo CurrentStory { get; private set; }
        public virtual string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer, CookieContainer cc = null, string originalUrl = null, ChapterInfo chapter = null)
        {
            if (this.ResolveImageInHtmlPage != null)
            {
                pageUrl = this.ResolveImageInHtmlPage(pageUrl);
            }
            pageUrl = Helpers.UrlHelper.TryFixUrl(pageUrl);
            if (originalUrl == null)
            {
                originalUrl = pageUrl;
            }

            string filename = Path.GetFileName(originalUrl);

            if (filename.Contains("?"))
            {
                filename = filename.Substring(0, filename.IndexOf("?"));
            }
            using (WebClient client = new CookieAwareWebClient(cc))
            {
                client.Headers.Add("Referer", httpReferer);
                try
                {
                    string replaceFileName = renamePattern.Replace("{FILENAME}", filename);
                    if(Path.GetExtension(replaceFileName) =="")
                    {
                        replaceFileName += ".html";
                        replaceFileName = replaceFileName.Replace("..", ".");
                    }
                    {
                        filename = Path.Combine(folder, replaceFileName);
                        client.DownloadFile(pageUrl, filename);
                    }
                }
                catch
                {
                }
            }
            this.AfterPageDownloaded(filename, chapter);
            return filename;
        }
        public void SaveCache(List<StoryInfo> stories, long crawlTime = 0, CrawlTypes type = CrawlTypes.Manual)
        {
            var info = new StoryInfoCacheFile()
            {
                Stories = stories,
                Type = type,
                TotalTime = crawlTime,
                Updated = DateTime.Now
            };

            var temp = Path.GetTempPath() + Path.GetRandomFileName();
            var xml = SerializationHelper.SerializeToXml<StoryInfoCacheFile>(info);
            using (var file = new StreamWriter(File.Open(temp, FileMode.OpenOrCreate)))
            {
                file.Write(xml);
            }

            Directory.CreateDirectory(Path.GetDirectoryName(CachedFile));
            SecureHelper.EncryptFile(temp, CachedFile, Resources.SecureKey);
        }

        public StoryInfoCacheFile ReloadChachedData()
        {
            StoryInfoCacheFile info = new StoryInfoCacheFile()
            {
            };
            try
            {
                if (File.Exists(this.CachedFile))
                {
                    var temp = Path.GetTempPath() + Path.GetRandomFileName();

                    SecureHelper.DecryptFile(CachedFile, temp, Resources.SecureKey);

                    using (var file = File.OpenText(temp))
                    {
                        info = SerializationHelper.DeserializeFromXml<StoryInfoCacheFile>(file.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return info;
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
            int id = ExtractID(name, @".*\s(\d*)$");
            if (id > 0) return id;

            id = ExtractID(name, @".*\s(\d*)\s.*");
            if (id > 0) return id;

            return ExtractID(name, @"\d\d*");

        }

        internal void DeleteCached()
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

        public static Downloader Resolve(string url, bool fetchDat = false)
        {
            var dl = GetAllDownloaders().FirstOrDefault(p => url.Contains(p.HostUrl));
            if (dl != null)
            {
                if (fetchDat)
                {
                    dl = (Downloader)Activator.CreateInstance(dl.GetType());
                    List<string> pages = new List<string>();
                    dl.CurrentStory = dl.RequestInfo(url);
                    if (dl.CurrentStory == null)
                    {
                        var resolvedUrl = dl.TryGetStoryUrl(url);
                        if (!string.IsNullOrEmpty(resolvedUrl))
                        {
                            dl.CurrentStory = dl.RequestInfo(url);
                        };
                        //try to parse link from chapter o 
                        //dl.CurrentChapter =dl.GetPages(url);
                    }
                }
            }
            return dl;
        }

        private string TryGetStoryUrl(string url)
        {
            return url;
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
                    if (attributes.Length > 0 && !((DownloaderAttribute)attributes[0]).Offline)
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
            this.NumberRetryWhenFailed = SettingForm.GetSetting().NumberRetryWhenFailed;

            //load setting.
            this.Settings = new DownloaderSetting();
            this.Settings = this.Settings.FromFile<DownloaderSetting>(this.SettingFile, Resources.SecureKey);
            if (this.Settings == null)
            {
                this.Settings = new DownloaderSetting()
                {
                    LastKeyword = "Dragon Ball"
                };
            }
        }
        public string SettingFile
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                   "\\ComicDownloader\\settings\\" + this.GetType().Name + ".cfg";
            }
        }

        public void SaveSetting(DownloaderSetting setting)
        {
            this.Settings = setting;
            setting.ToFile<DownloaderSetting>(this.SettingFile, Resources.SecureKey);
        }
    }
}
