using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace JSONRPC
{
    class Program
    {
        static void Main(string[] args)
        {
            //{"id":2,"method":"getListStoryNewUpdateChapter","params":["2013-04-09T23:34:57-07:00"]}

//            X-JSON-RPC: getListStoryNewUpdateChapter
//User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.43 Safari/537.31
//Content-Type: application/json; charset=UTF-8
//Accept: */*
//Referer: http://truyen.vietboom.com/
//Accept-Encoding: gzip,deflate,sdch
//Accept-Language: en-US,en;q=0.8
//Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3

//          * 
            HttpWebRequest request = (HttpWebRequest)
                            WebRequest.Create("http://truyen.vietboom.com/MainHandler.ashx ");


            request.ServicePoint.Expect100Continue = false;
            request.Timeout = 20000;


            request.Referer = "http://truyen.vietboom.com/";
            request.Method = "POST";
            //request.Headers.Add("X-JSON-RPC", "getListStoryNewUpdateChapter");
            //request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            //request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            //request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.43 Safari/537.31";
            request.ContentType = "application/json; charset=UTF-8";
            //request.Accept = "*/*";
            //request.Headers.Add("Cookie","__cfduid=db551ebf631e62da04b1589b858555b2a1365662080; __utma=3427383.1612196896.1365662079.1365662079.1365662079.1; __utmb=3427383.2.10.1365662079; __utmc=3427383; __utmz=3427383.1365662079.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); ASP.NET_SessionId=v1z5cqndk2blzn45fnrwmprm; ad_play_index=47; __utma=129494345.2067403875.1364113861.1364122161.1365662088.3; __utmb=129494345.9.10.1365662088; __utmc=129494345; __utmz=129494345.1364113861.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)");

            //request.Headers.Add("Origin", "http://truyen.vietboom.com");
            string json = "{\"id\":2,\"method\":\"getListStoryNewUpdateChapter\",\"params\":[\"2013-04-09T23:34:57-07:00\"]}";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();

            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            Console.Write(reader.ReadToEnd());
            

        }
    }
}
