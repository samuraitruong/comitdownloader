﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace ComicDownloader.Engines
{
    public class NetworkHelper
    {
        public static string GetHtml(string url)
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

                    // Set the user agent as if we were a web browser
                    myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                    var stream = myHttpWebResponse.GetResponseStream();
                    var reader = new StreamReader(stream);
                    var html = reader.ReadToEnd();
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

        public static string PostHtml(string serviceUrl, string refererUrl, string json, 
                                      string origin = null,
                                      string contentType = null,
                                      string accept = null,
                                      string charset = null,
                                      string encoding = null,
                                      string language = null,
                                      string cacheControl = null,
                                      bool connection = false,
                                      string userAgent = null)
        {
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(serviceUrl);

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
                request.Headers.Add("Accept-Charset", accept);
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

            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
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
    }
}
