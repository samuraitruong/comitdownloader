﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ComicDownloader.Properties;
using System.Reflection;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.Windows.Forms;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;

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
                            using (var html = new StringReader(HtmlData))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, html);
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

        public static bool IsImageFile(string file)
        {
            try
            {
                System.Drawing.Image imgInput = System.Drawing.Image.FromFile(file);
                System.Drawing.Graphics gInput = System.Drawing.Graphics.FromImage(imgInput);
                System.Drawing.Imaging.ImageFormat thisFormat = imgInput.RawFormat;
                imgInput.Dispose();
                gInput.Dispose();
                return true;
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

        internal static void CreatePDFFromHtmls(string[] htmlFiles, string pdfPath, string name, ComicDownloaderSettings settings)
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
                    

                var instance = XMLWorkerHelper.GetInstance();
                var cssPath = Application.StartupPath + "\\Resources\\defaultcss.css";

                foreach (var item in htmlFiles)
                {
                    //add header
                    instance.ParseXHtml(writer,
                        pdfDoc,
                        File.OpenRead(item),
                        File.OpenRead(cssPath),
                        Encoding.UTF8,
                        new UnicodeFontFactory());
                    pdfDoc.NewPage();
                }

                if (settings.IncludePDFIntroPage && settings.PdfIntroPagePosition == PagePosition.LastPage)
                    EmbedeIntroPage(pdfDoc, writer);

            }
            catch(Exception ex)
            {

            }
            finally
            {
                pdfDoc.Close();
            }
        }

        public static void CreatePDF(string directoryPath , string pdfFile, string name, ComicDownloaderSettings settings){

           try
           {
               Directory.CreateDirectory(Path.GetDirectoryName(pdfFile));
           }
           finally{}

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

                if (settings.IncludePDFIntroPage && settings.PdfIntroPagePosition == PagePosition.FirstPage)
                    EmbedeIntroPage(pdfDoc, writer);

                DirectoryInfo di = new DirectoryInfo(directoryPath);
                var files = di.GetFiles();
                if (files != null)
                {
                    foreach (var fi in files)
                    {
                        if (IsImageFile(fi.FullName))
                        {
                            Image img = Image.GetInstance(fi.FullName);
                            float h = img.Height;
                            float w = img.Width;

                            float hp = doch / h;
                            float wp = docw / w;

                            ///img.ScaleToFit(docw * 1.35f, doch * 1.35f);
                            // img.ScaleToFit(750, 550);
                            pdfDoc.NewPage();
                            //pdfDoc.Add(img);
                            PdfPTable nestedTable = new PdfPTable(1);
                            PdfPCell cell = new PdfPCell(img);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            nestedTable.AddCell(cell);
                            //pdfDoc.Add(nestedTable);

                            Section section = chapter.AddSection(0f, new Paragraph("", new Font()
                            {
                                Color = BaseColor.WHITE
                            }));
                            //section.Add(nestedTable);
                            //pdfDoc.Add(section);
                            pdfDoc.Add(nestedTable);
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
