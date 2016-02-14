using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EPubDocument = Epub.Document;

namespace ConsoleApplication1
{
    public class UnicodeFontFactory : FontFactoryImp
    {
        private static readonly string FontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
          "Calibri.ttf");

        private readonly BaseFont _baseFont;

        public UnicodeFontFactory()
        {
            _baseFont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

        }

        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color,
          bool cached)
        {
            return new Font(_baseFont, size, style, color);
        }
    }

  
    class Program
    {

        public static void GenereateEpubFromHtml(string[] htmlFiles, string epubFile, string title)
        {
            var epub = new EPubDocument();

            epub.AddAuthor("samuraitruong");
            epub.AddTitle(title);
            epub.AddLanguage("en");

            String css = File.ReadAllText("EpubCss.css");

            //epub.AddData("Calibri.otf", Resources.Calibri, "font/opentype");

            //epub.AddData("LiberationSerif-Regular.ttf", Resources.LiberationSerif_Regular, "application/octet-stream");
            //epub.AddData("LiberationSerif-Bold.ttf", Resources.LiberationSerif_Bold, "application/octet-stream");
            //epub.AddData("LiberationSerif-Italic.ttf", Resources.LiberationSerif_Italic, "application/octet-stream");
            //epub.AddData("LiberationSerif-BoldItalic.ttf", Resources.LiberationSerif_BoldItalic, "application/octet-stream");

            try
            {
                epub.AddStylesheetData("style.css", css);
                var navCounter = 1;
                string pageTemplate = File.ReadAllText("EpubTemplate.xhtml");
                foreach (var item in htmlFiles)
                {
                    var page = File.ReadAllText(item);
                    HtmlDocument doc = new HtmlDocument();

                    doc.LoadHtml(page);
                    var chapTitle = doc.DocumentNode.SelectSingleNode("//h1").InnerText;
                    var pageName = "aaaaaaaaa";
                    pageName = Regex.Replace(pageName, "[^a-zA-z0-9]", "_") + ".xhtml";
                    page = pageTemplate.Replace("[[CONTENT]]", doc.DocumentNode.SelectSingleNode("//body").InnerHtml);
                    page = page.Replace("<br>", "<br/>");
                    //pageTemplate.Replace("", FileStyleUriParser.)
                    epub.AddXhtmlData(pageName, page);
                    epub.AddNavPoint(chapTitle, pageName, navCounter++);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                epub.Generate(epubFile);
            }
        }


        static void Main(string[] args)
        {
            GenereateEpubFromHtml(new string[] { "unicode.html" }, "a.epub", "unicode chap");
            Process.Start("a.epub");

            return;
            Document pdfDoc = new Document(PageSize.A4);
            File.Delete("pdfFile.pdf");
            using (var stream = File.Create("pdfFile.pdf"))
            {
                var writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                var instance = XMLWorkerHelper.GetInstance();
                instance.ParseXHtml(writer,
                                    pdfDoc,
                                    File.OpenRead("01.html"),
                                    File.OpenRead("a.css"),
                                    Encoding.UTF8,
                                    new UnicodeFontFactory());

                pdfDoc.Close();
            }
            Process.Start("pdffile.pdf");
        }
    }
}
