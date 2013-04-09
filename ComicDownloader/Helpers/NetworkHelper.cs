using System;
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
    }
}
