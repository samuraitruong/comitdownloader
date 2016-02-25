using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epub;
using EPubDocument = Epub.Document;
using ComicDownloader.Properties;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ComicDownloader.Helpers
{
    public class EPUBHelper
    {
        public static void GenereateEpubFromHtml(string[] htmlFiles, string epubFile, string title, string coverPage="", Action<int> afterPageProcecced = null)
        {
            var epub = new EPubDocument();

            epub.AddAuthor("Comic Downloader");
            epub.AddTitle(title);
            epub.AddLanguage("en");

            String css = Resources.EpubCss;
      
            epub.AddData("css/fonts/Calibri.otf", Resources.Calibri, "application/vnd.ms-opentype");

            //epub.AddData("LiberationSerif-Regular.ttf", Resources.LiberationSerif_Regular, "application/octet-stream");
            //epub.AddData("LiberationSerif-Bold.ttf", Resources.LiberationSerif_Bold, "application/octet-stream");
            //epub.AddData("LiberationSerif-Italic.ttf", Resources.LiberationSerif_Italic, "application/octet-stream");
            //epub.AddData("LiberationSerif-BoldItalic.ttf", Resources.LiberationSerif_BoldItalic, "application/octet-stream");

            try
            {
                var navCounter = 1;

                if (!string.IsNullOrEmpty(coverPage))
                {
                    epub.AddXhtmlData("html/cover.xhtml", coverPage);
                    epub.AddNavPoint(title, "html/cover.xhtml", navCounter++);
                }
                epub.AddStylesheetData("css/style.css", css);
                string pageTemplate = Encoding.UTF8.GetString(Resources.EpubTemplate);
                foreach (var item in htmlFiles)
                {
                    var page = File.ReadAllText(item);
                    HtmlDocument doc = new HtmlDocument();
                    
                    doc.LoadHtml(page);
                    var chapTitle = doc.DocumentNode.SelectSingleNode("//h1").InnerText;
                    var pageName = chapTitle.RemoveDiacritics() ;
                    pageName = Regex.Replace(pageName,"[^a-zA-z0-9]", "_") + ".xhtml";
                    page = pageTemplate.Replace("[[CONTENT]]", doc.DocumentNode.SelectSingleNode("//body").InnerHtml);
                     if(afterPageProcecced != null)
                    {
                        afterPageProcecced(navCounter);
                    }
                    //pageTemplate.Replace("", FileStyleUriParser.)
                    epub.AddXhtmlData("html/"+pageName, page);
                    epub.AddNavPoint(chapTitle, "html/" +pageName, navCounter++);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                epub.Generate(epubFile);
                try
                {
                    MobiHelper.ConvertEpubToMobi(epubFile);
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
