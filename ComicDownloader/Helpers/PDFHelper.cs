using System;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ComicDownloader.Properties;
using iTextSharp.tool.xml;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ComicDownloader.Helpers
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

    public class PDFHelper
    {

        // return value class  
        public class ReturnValue
        {
            // constructor  
            public ReturnValue()
            {
                this.Success = false;
                this.Message = string.Empty;
            }

            // properties  
            public bool Success = false;
            public string Message = string.Empty;
            public Byte[] Data = null;
        }
        public static ReturnValue ConvertHtmlToPdfAsFile(string FilePath, string HtmlData)
        {
            // variables  
            ReturnValue Result = new ReturnValue();

            try
            {
                // convert html to pdf and get bytes array  
                Result = ConvertHtmlToPdfAsBytes(HtmlData: HtmlData);

                // check for errors  
                if (!Result.Success)
                {
                    return Result;
                }

                // create file  
                File.WriteAllBytes(path: FilePath, bytes: Result.Data);

                // result  
                Result.Success = true;
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }

            // return  
            return Result;
        }
        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static ReturnValue ConvertHtmlToPdfAsBytes(string HtmlData)
        {
            // variables  
            ReturnValue Result = new ReturnValue();

            // do some additional cleansing to handle some scenarios that are out of control with the html data  
            HtmlData = HtmlData.Replace("<br>", "<br />");

            // convert html to pdf  
            try
            {
                // create a stream that we can write to, in this case a MemoryStream  
                using (var stream = new MemoryStream())
                {
                    // create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF  
                    using (var document = new Document())
                    {
                        // create a writer that's bound to our PDF abstraction and our stream  
                        using (var writer = PdfWriter.GetInstance(document, stream))
                        {
                            // open the document for writing  
                            document.Open();

                            // read html data to StringReader  
                            using (var htmlStream = GenerateStreamFromString(HtmlData))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlStream, null,Encoding.UTF8, new UnicodeFontFactory());
                            }

                            // close document  
                            document.Close();
                        }
                    }

                    // get bytes from stream  
                    Result.Data = stream.ToArray();

                    // success  
                    Result.Success = true;
                }
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }

            // return  
            return Result;
        }

        private static void EmbedeIntroPage(Document pdfDoc, PdfWriter writer)
        {
            pdfDoc.NewPage();
            PdfReader reader = new PdfReader(Resources.Intro);
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage page = writer.GetImportedPage(reader, 1); ;

            //cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
            cb.AddTemplate(page, 0, 0);
        }
        private static void EmbedePDFPage(Document pdfDoc, PdfWriter writer, params string[] files)
        {
            foreach (var item in files)
            {
                try
                {
                    pdfDoc.NewPage();
                    PdfReader reader = new PdfReader(item);
                    PdfContentByte cb = writer.DirectContent;
                    PdfImportedPage page = writer.GetImportedPage(reader, 1); ;
                    //cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
                    cb.AddTemplate(page, 0, 0);
                }
                catch (Exception ex)
                {
                }
            }
            
        }
        public static bool IsImageFile(string file)
        {
            try
            {
                var match = Regex.Match(file.ToLower(), @"([^\s]+(\.(?i)(jpg|png|gif|bmp))$)");
                return match != null;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public static MemoryStream CopyToMemory(Stream input)
        {
            // It won't matter if we throw an exception during this method;
            // we don't *really* need to dispose of the MemoryStream, and the
            // caller should dispose of the input stream
            MemoryStream ret = new MemoryStream();

            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ret.Write(buffer, 0, bytesRead);
            }
            // Rewind ready for reading (typical scenario)
            ret.Position = 0;
            return ret;
        }
        public static Chapter CreateChapterContent(string html)
        {
            // Declare a font to used for the bookmarks
            iTextSharp.text.Font bookmarkFont = iTextSharp.text.FontFactory.GetFont
            (iTextSharp.text.FontFactory.HELVETICA, 16, iTextSharp.text.Font.NORMAL, new BaseColor(255, 153, 0));

            // Split H2 Html Tag
            string pattern = @"<\s*h1[^>]*>(.*?)<\s*/h1\s*>";
            var match = Regex.Match(html, pattern);
            Chapter chapter = new Chapter(new Paragraph(match.Groups[1].Value), 0);
            chapter.NumberDepth = 0;

            chapter.AddSection(20f, new Paragraph(match.Groups[1].Value, bookmarkFont), 0);

            foreach (IElement element in XMLWorkerHelper.ParseToElementList(html, Resources.DefaultCss))
            {
                if (element.Type == 666) continue;
                try{
                    chapter.Add(element);
                }
                catch(Exception ex) { }
                
            }
            chapter.BookmarkTitle = match.Groups[1].Value;
            return chapter;
        }
        internal static void CreatePDFFromHtmls(string[] htmlFiles, string pdfPath, string name, ComicDownloaderSettings settings, string cover="")
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
            }
            finally { }

            Document pdfDoc = new Document(PageSize.A4);
            AssemblyInfoHelper info = new AssemblyInfoHelper(typeof(PDFHelper));
            pdfDoc.AddAuthor(info.Company);
            pdfDoc.AddCreationDate();
            pdfDoc.AddTitle(name);
            try
            {
                var stream = File.Create(pdfPath);
                var writer = PdfWriter.GetInstance(pdfDoc, stream);

                pdfDoc.Open();

                if (settings.IncludePDFIntroPage && settings.PdfIntroPagePosition == PagePosition.FirstPage)
                {
                    EmbedeIntroPage(pdfDoc, writer);
                    pdfDoc.NewPage();
                }
                EmbedePDFPage(pdfDoc, writer, cover);

               var instance = XMLWorkerHelper.GetInstance();
                var cssPath = Application.StartupPath + "\\Resources\\defaultcss.css";

                foreach (var item in htmlFiles)
                {
                    //var chap = CreateChapterContent(File.ReadAllText(item, Encoding.UTF8));
                    //pdfDoc.Add(chap);
                    //add header
                    //Chapter chapter = new Chapter(new Paragraph("aaa"), 0);
                    //pdfDoc.Add(chapter);
                    try {
                        instance.ParseXHtml(writer,
                            pdfDoc,
                            File.OpenRead(item),
                            File.OpenRead(cssPath),
                            Encoding.UTF8,
                            new UnicodeFontFactory());
                        writer.NewPage();
                        //pdfDoc.NewPage();

                    }
                    catch(Exception ex)
                    {

                    }
                }

                if (settings.IncludePDFIntroPage && settings.PdfIntroPagePosition == PagePosition.LastPage)
                    EmbedeIntroPage(pdfDoc, writer);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                try
                {
                    pdfDoc.Close();

                }
                catch (Exception)
                {
                }
            }
        }

        public static void CreatePDF(string directoryPath, string pdfFile, string name, ComicDownloaderSettings settings, string coverPDF)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pdfFile));
            }
            finally { }

            Document pdfDoc = new Document(PageSize.A4);
            AssemblyInfoHelper info = new AssemblyInfoHelper(typeof(PDFHelper));

            pdfDoc.AddAuthor(info.Company);
            pdfDoc.AddCreationDate();
            pdfDoc.AddTitle(name);


            float docw = pdfDoc.PageSize.Width;
            float doch = pdfDoc.PageSize.Width;

            PdfDate st = new PdfDate(DateTime.Today);
            Chapter chapter = new Chapter(new Paragraph(name), 1);

            try
            {
                var stream = File.Create(pdfFile);
                var writer = PdfWriter.GetInstance(pdfDoc, stream);

                pdfDoc.Open();

                if (settings.IncludePDFIntroPage && settings.PdfIntroPagePosition == PagePosition.FirstPage && string.IsNullOrEmpty(coverPDF))
                    EmbedeIntroPage(pdfDoc, writer);
                EmbedePDFPage(pdfDoc, writer, coverPDF);
                DirectoryInfo di = new DirectoryInfo(directoryPath);
                var files = di.GetFiles();
                if (files != null)
                {
                    foreach (var fi in files)
                    {
                        if (IsImageFile(fi.FullName))
                        {
                            Section section = chapter.AddSection(0f, new Paragraph("", new Font()
                            {
                                Color = BaseColor.WHITE
                            }));

                            Image img = Image.GetInstance(fi.FullName);
                            float h = img.Height;
                            float w = img.Width;

                            float hp = doch / h;
                            float wp = docw / w;
                            pdfDoc.NewPage();
                            if (img.Height < img.Width)
                            {
                                PdfPTable nestedTable = new PdfPTable(1);
                                PdfPCell cell = new PdfPCell(img, true);
                                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                cell.Border = PdfPCell.NO_BORDER;
                                cell.Padding = 5;
                                cell.Image.ScaleToFitHeight = true;
                                cell.Image.ScaleToFitLineWhenOverflow = true;
                                nestedTable.AddCell(cell);
                                section.Add(nestedTable);
                            }
                            else {
                                //Another technique posible working for have image full -width and auto height.
                                var margin = 35;
                                img.SetAbsolutePosition(margin, margin);
                                img.ScaleToFit(pdfDoc.PageSize.Width - 2 * margin, pdfDoc.PageSize.Height - 2 * margin);
                                section.Add(img);
                            }
                            pdfDoc.Add(section);

                        }
                        else
                        {
                            var instance = XMLWorkerHelper.GetInstance();
                            var cssPath = Application.StartupPath + "\\Resources\\defaultcss.css";
                            using (var cssStream = File.OpenRead(cssPath))
                            {
                                using (Stream input = File.OpenRead(fi.FullName))
                                {
                                    using (Stream memory = CopyToMemory(input))
                                    {
                                        using (var cssMem = CopyToMemory(cssStream))
                                        {
                                            instance.ParseXHtml(writer,
                                            pdfDoc, memory,
                                            cssMem,
                                            Encoding.UTF8,
                                            new UnicodeFontFactory());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (settings.IncludePDFIntroPage && settings.PdfIntroPagePosition == PagePosition.LastPage)
                        EmbedeIntroPage(pdfDoc, writer);
                }
            }
            catch (Exception ex)
            {
                MyLogger.Log(ex);
            }
            finally
            {
                pdfDoc.Close();
            }


        }
    }
}
