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

        //public static string JsonRPCCall(string url, string data)
        //{
        //    HttpWebRequest request = (HttpWebRequest)
        //                    WebRequest.Create("url");


        //    request.ServicePoint.Expect100Continue = false;
        //    request.Timeout = 20000;


        //    request.Referer = "http://truyen.vietboom.com/";
        //    request.Method = "POST";
        //    request.Headers.Add("X-JSON-RPC", "getListStoryNewUpdateChapter");
        //    //request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
        //    //request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
        //    //request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
        //    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.43 Safari/537.31";
        //    request.ContentType = "application/json; charset=UTF-8";
        //    //request.Accept = "*/*";
        //    //request.Headers.Add("Cookie","__cfduid=db551ebf631e62da04b1589b858555b2a1365662080; __utma=3427383.1612196896.1365662079.1365662079.1365662079.1; __utmb=3427383.2.10.1365662079; __utmc=3427383; __utmz=3427383.1365662079.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASP.NET_SessionId=v1z5cqndk2blzn45fnrwmprm; ad_play_index=47; __utma=129494345.2067403875.1364113861.1364122161.1365662088.3; __utmb=129494345.9.10.1365662088; __utmc=129494345; __utmz=129494345.1364113861.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)");

        //    //request.Headers.Add("Origin", "http://truyen.vietboom.com");
        //    string json = "{\"id\":2,\"method\":\"getListStoryNewUpdateChapter\",\"params\":[\"2013-04-09T23:34:57-07:00\"]}";

        //    StreamWriter writer = new StreamWriter(request.GetRequestStream());
        //    writer.Write(json);
        //    writer.Close();

        //    StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
        //    Console.Write(reader.ReadToEnd());
        //}
    }
}
