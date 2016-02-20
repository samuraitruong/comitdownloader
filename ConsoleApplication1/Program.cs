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


        public static void TestStringTemplate()
        {
            var remplate = File.ReadAllText("covertemplate.html");
            Antlr4.StringTemplate.Template templator = new Antlr4.StringTemplate.Template(remplate, '$', '$');
            templator.Add("story", new  {
                Name="I am Truong"
            });
            Console.Write(templator.Render());
        }
        static void Main(string[] args)
        {
            TestPDFImages();
            //TestStringTemplate();
            return;

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

        private static void TestPDFImages()
        {
            string directoryPath = @"C:\Users\Khoaimap\Documents\Scuro\Scuro chap 1-a";
            Document pdfDoc = new Document(PageSize.A4);

            float docw = pdfDoc.PageSize.Width;
            float doch = pdfDoc.PageSize.Width;

            PdfDate st = new PdfDate(DateTime.Today);
            Chapter chapter = new Chapter(new Paragraph("AAAAAAAAAAAAAAAA"), 1);
            chapter.BookmarkTitle = "A B C D E F";

            try
            {
                File.Delete("output.pdf");
                var stream = File.Create("output.pdf");
                var writer = PdfWriter.GetInstance(pdfDoc, stream);

                pdfDoc.Open();
             
                DirectoryInfo di = new DirectoryInfo(directoryPath);
                var files = di.GetFiles();
                if (files != null)
                {
                    foreach (var fi in files)
                    {

                        Image img = Image.GetInstance(fi.FullName);
                        float h = img.Height;
                        float w = img.Width;

                        float hp = doch / h;
                        float wp = docw / w;
                        pdfDoc.NewPage();
                        PdfPTable nestedTable = new PdfPTable(1);
                        PdfPCell cell = new PdfPCell(img);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        nestedTable.AddCell(cell);
                        Section section = chapter.AddSection(0f, new Paragraph("Page xxx", new Font()
                        {
                            
                            Color = BaseColor.WHITE
                        }));
                        if (img.Height < img.Width)
                        {
                            PdfPTable table = new PdfPTable(1);
                            table.WidthPercentage = 100;
                            PdfPCell c = new PdfPCell(img, true);
                            c.Border = PdfPCell.NO_BORDER;
                            c.Padding = 5;
                            //c.Image.ScaleToFitLineWhenOverflow = true;
                            c.Image.ScaleToFitHeight = true; /*The new line*/
                            c.VerticalAlignment = PdfPCell.ALIGN_TOP;
                            table.AddCell(c);

                            section.Add(nestedTable);
                        }
                        else
                        {
                            var margin = 35;
                            img.SetAbsolutePosition(margin, margin);
                            img.ScaleToFit(pdfDoc.PageSize.Width - 2 * margin, pdfDoc.PageSize.Height - 2 * margin);
                            section.Add(img);
                        }
                        
                        //section.Add(table);
                        pdfDoc.Add(section);
                        //pdfDoc.NewPage();

                    }
                }

            }
            catch (Exception ex)
            {
                //MyLogger.Log(ex);
            }
            finally
            {
                pdfDoc.Close();
                Process.Start("output.pdf");
            }
        }
    }
}
