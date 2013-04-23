using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace PDFCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"C:\Users\Administrator\Desktop\TESTIMGS";
            string pdf = @"C:\Users\Administrator\Desktop\generatedpdf.pdf";

            Document pdfDoc = new Document(PageSize.A4,5f,5f,5f,5f);
            float docw = pdfDoc.PageSize.Width;
            float doch = pdfDoc.PageSize.Height;

            PdfDate st = new PdfDate(DateTime.Today);
            Chapter chapter = new Chapter(new Paragraph("Dragon ball chapter 1"),1);
            try
            {
                var stream = File.Create(pdf);
                var writer = PdfWriter.GetInstance(pdfDoc, stream);

                pdfDoc.Open();

                
                DirectoryInfo di = new DirectoryInfo(folder);
                var files = di.GetFiles();
                if (files != null)
                {
                    foreach (var fi in files)
                    {
                        
                        // img.ScaleToFit(750, 550);
                        pdfDoc.NewPage();

                        Image img = Image.GetInstance(fi.FullName);
                        float h = img.Height;
                        float w = img.Width;

                        float hp = doch / h;
                        float wp = docw / w;
                        //if (img.Width > docw*1.15f)
                        {
                          // img.ScaleToFit(docw*1.35f, doch*1.35f);
                            //img.SetAbsolutePosition(5, 5);
                           // img.ScaleToFit(pdfDoc.PageSize.Width - 10, pdfDoc.PageSize.Width - 10);
                        }

                        
                        //Section section = chapter.AddSection(0f, "Pages", 1);
                        
                        
                        //pdfDoc.Add(chapter);
                        PdfPTable nestedTable = new PdfPTable(1);
                        PdfPCell cell = new PdfPCell(img);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        nestedTable.AddCell(cell);
                        //pdfDoc.Add(nestedTable);
                        
                        Section section = chapter.AddSection(0f,new Paragraph("", new Font()
                        {
                            Color = BaseColor.WHITE
                        }));
                        
                        section.Add(nestedTable);
                        pdfDoc.Add(section);
                        //pdfDoc.Add(img);
                        //pdfDoc.Add(new iTextSharp.text.Jpeg(new Uri(fi.FullName)));

                    }

                   



                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
               //pdfDoc.Add(chapter);
                pdfDoc.Close();
                Process.Start(pdf);
            }
        }
    }
}
