using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ComicDownloader.Properties;

namespace ComicDownloader.Helpers
{
   public class PDFHelper
    {
       private static void EmbedeIntroPage(Document pdfDoc, PdfWriter writer)
       {
           pdfDoc.NewPage();
           PdfReader reader = new PdfReader(Resources.Intro);
           PdfContentByte cb = writer.DirectContent;
           PdfImportedPage page = writer.GetImportedPage(reader, 1); ;

           //cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
           cb.AddTemplate(page, 0, 0);
       }

       public static void CreatePDF(string directoryPath , string pdfFile, string name, ComicDownloaderSettings settings){

           try
           {
               Directory.CreateDirectory(Path.GetDirectoryName(pdfFile));
           }
           finally{}

            Document pdfDoc = new Document(PageSize.A4);
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
                        section.Add(nestedTable);
                        pdfDoc.Add(section);


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
