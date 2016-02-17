using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public class CookieAwareWebClient : WebClient
    {
        private readonly CookieContainer m_container = new CookieContainer();
        public CookieAwareWebClient(CookieContainer cc): base()
        {
            m_container = cc;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            HttpWebRequest webRequest = request as HttpWebRequest;
            if (webRequest != null && this.m_container != null)
            {
                webRequest.CookieContainer = m_container;
            }
            if(webRequest != null)
            {
                webRequest.Accept =  "application/xml,application/xhtml+xml,text/html;q=0.9,text/plain; q = 0.8,image/png,*/*;q=0.5";
                webRequest.UserAgent =  "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.109 Safari/537.36";
                //webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, sdch");
                webRequest.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
                webRequest.Headers.Add("X-Requested-With:XMLHttpRequest");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            }
            return request;
        }
    }

    public class NetworkHelper
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
        const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
        public static string GetGlobalCookies(string uri)
        {
            uint datasize = 1024;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (InternetGetCookieEx(uri, null, cookieData, ref datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero)
            && cookieData.Length > 0)
            {
                return cookieData.ToString();
            }
            else
            {
                return null;
            }
        }
        public static CookieContainer GetCookie(string url, string referer, string cookieheaders="")
        {
            var cookies = new CookieContainer();
            try
            {
                Uri myUri = new Uri(url);
                // Create a 'HttpWebRequest' object for the specified url. 
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                myHttpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;//Or DecompressionMethods.Deflate
                myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";
                if (!string.IsNullOrEmpty(cookieheaders)) { 
                    myHttpWebRequest.CookieContainer = new CookieContainer();
                    myHttpWebRequest.CookieContainer.SetCookies(new Uri(url), cookieheaders);
                }         ;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                foreach (Cookie item in myHttpWebResponse.Cookies)
                {
                    cookies.Add(item);
                }
                for (int i = 0; i < myHttpWebResponse.Headers.Count; i++)
                {
                    string name = myHttpWebResponse.Headers.GetKey(i);
                    string value = myHttpWebResponse.Headers.Get(i);
                    if (name == "Set-Cookie")
                    {
                        Match match = Regex.Match(value, "(.+?)=(.+?);");
                        if (match.Captures.Count > 0)
                        {
                            cookies.Add(new Cookie(match.Groups[1].Value, match.Groups[2].Value, "/", "example.com"));
                        }
                    }
                }

            }
            catch(Exception ex)
            {

            }
            return cookies;
        }
        public static string GetHtml(string url, CookieContainer cookies = null)
        {
            try
            {
                if (url.Length > 0)
                {
                    Uri myUri = new Uri(url);
                    // Create a 'HttpWebRequest' object for the specified url. 
                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                    myHttpWebRequest.Method = "GET";
                    myHttpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    myHttpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;//Or DecompressionMethods.Deflate
                    if(cookies != null)
                    {
                        myHttpWebRequest.CookieContainer = cookies;
                    }
                    else
                    {
                        var uri = new Uri(url);
                        string cookiesss = GetGlobalCookies(uri.AbsoluteUri);
                        if(cookiesss!= null) {
                            myHttpWebRequest.CookieContainer = new CookieContainer();
                            myHttpWebRequest.CookieContainer.SetCookies(new Uri(uri.AbsoluteUri), GetGlobalCookies(uri.AbsoluteUri));

                        }
                    }
                    // Set the user agent as if we were a web browser
                    myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                    var stream = myHttpWebResponse.GetResponseStream();
                    var reader = new StreamReader(stream);
                    var html = reader.ReadToEnd();
                    if(cookies == null)
                    {
                        cookies = new CookieContainer();
                        foreach (Cookie item in myHttpWebResponse.Cookies)
                        {
                            cookies.Add(item);
                        }
                    }
                    // Release resources of response object.
                    myHttpWebResponse.Close();

                    return html;
                }
                else { return "NO URL"; }
            }
            catch (Exception ex)
            {

                //throw;
            }
            finally
            {
                Thread.Sleep(100);
            }
            return "HTTP ERROR";
        }

        public static string PostHtml(string serviceUrl, 
                                      string refererUrl, 
                                      string json, 
                                      string origin = null,
                                      string contentType = "application/x-www-form-urlencoded",
                                      string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
                                      string charset = "ISO-8859-1,utf-8;q=0.7,*;q=0.3",
                                      string encoding = "text/html",
                                      string language = "en-US,en;q=0.8",
                                      string cacheControl = "max-age=0",
                                      bool connection = false,
                                      string userAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.97 Safari/537.36",
                                      Action<CookieContainer> postProcess= null,
                                      CookieContainer cookies= null)
        {
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(serviceUrl);
            
            if(cookies != null)
            {
                request.CookieContainer = cookies;
            }
            request.ServicePoint.Expect100Continue = false;
            request.Timeout = 20000;

            request.Referer = refererUrl;
            request.Method = "POST";

            if (!string.IsNullOrEmpty(origin))
            {
                request.Headers.Add("Origin", origin);
            }

            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }

            if (!string.IsNullOrEmpty(accept))
            {
                request.Accept = accept;
            }

            if (!string.IsNullOrEmpty(charset))
            {
                request.Headers.Add("Accept-Charset", charset);
            }

            if (!string.IsNullOrEmpty(encoding))
            {
                request.Headers.Add("Accept-Encoding", encoding);
            }

            if (!string.IsNullOrEmpty(language))
            {
                request.Headers.Add("Accept-Language", language);
            }

            if (!string.IsNullOrEmpty(cacheControl))
            {
                request.Headers.Add("Cache-Control", cacheControl);
            }

            if (connection)
            {
                request.KeepAlive = connection;
            }

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();
            var response = (HttpWebResponse)request.GetResponse();
            if (postProcess != null)
            {
                CookieContainer container = new CookieContainer();

                foreach(Cookie item in response.Cookies)
                {
                    container.Add(item);
                }
                postProcess(container);
            }
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }

        internal static byte[] DownloadFile(string p)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(p);
            }
            return null;
        }
        public string GetContentType(string url)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Method = "HEAD";
            var response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            string ct= response.ContentType;
            response.Close();
            return ct;
        }
    }
}
