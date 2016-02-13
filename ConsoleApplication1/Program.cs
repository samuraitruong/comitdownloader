using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void Main(string[] args)
        {
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
