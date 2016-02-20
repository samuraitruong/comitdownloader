using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using ComicDownloader;
using System.Resources;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace System
{
    public static class HtmlDocumentExtensions
    {
        public static string Href(this HtmlNode node)
        {
            return node.Attr("href");
        }
        public static string Attr(this HtmlNode node, string attr)
        {
            if (node == null) return string.Empty;
            if(node.Attributes[attr]!= null)
            {
                return node.Attributes[attr].Value.Trim();
            }
            return "";
        }
        public static string GetNodeTextAsString(this HtmlNode node, string patterns, string defaultValue = "", string separator = "; ")
        {
            return string.Join(separator, node.GetNodeTextAsList(patterns).ToArray());
        }
        public static List<string> GetNodeTextAsList(this HtmlNode node, string patterns, Func<HtmlNode, string> extractTextFunc = null, Func<HtmlNode, List<string>> customExtractFunc = null)
        {
            var result = new List<string>() { };

            if (!string.IsNullOrEmpty(patterns))
            {
                var nodes = node.SelectNodes(patterns);
                if (nodes != null)
                {
                    result.AddRange(nodes.Select(p => extractTextFunc!= null? extractTextFunc(p): p.InnerText.Trim()));
                }
            }
            if(customExtractFunc!= null)
            {
                result.AddRange(customExtractFunc(node));
            }
            return result;
        }
        public static HtmlNode GetSingleNode(this HtmlNode node, string patterns)
        {
            string[] arr = patterns.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arr)
            {
                var test = node.SelectSingleNode(item);
                if (test != null) return test;
            }
            return null;
        }
        public static string GetNodeText(this HtmlNode node, string patterns, string defaultValue="")
        {
            var a = node.GetSingleNode(patterns);
            if(a!= null)
            {
                return a.InnerText.Trim();
            }
            return defaultValue;
        }

        public static string GetNodeHtml(this HtmlNode node, string patterns, string defaultValue = "")
        {
            var a = node.GetSingleNode(patterns);
            if (a != null)
            {
                return a.InnerHtml;
            }
            return defaultValue;
        }


        /// <summary>
        /// Get all node match with multiple patterns.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="patterns">separate by comma</param>
        /// <returns></returns>
        public static List<HtmlNode> GellAllNodes(this HtmlNode  node, string patterns)
        {
            var results = new List<HtmlNode>();

            string[] arr = patterns.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arr)
            {
                var test = node.SelectNodes(item);
                if (test != null)
                {
                    results.AddRange(test.Cast<HtmlNode>().ToList());
                }
            }
            return results;
        }



    }
}

