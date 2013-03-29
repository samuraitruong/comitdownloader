using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ComicDownloader
{
    public enum PagePosition
    {
        FirstPage,
        LastPage
    }
    [DefaultPropertyAttribute("Comic")]
    public class ComicDownloaderSettings
    {
        [CategoryAttribute("PDF Settings"), DescriptionAttribute("This allow to generate pdf file")]
        public bool CreatePDF { get; set; }
        [CategoryAttribute("PDF Settings"), DescriptionAttribute("Add an introduction page to generated pdf")]
        public bool IncludePDFIntroPage { get; set; }

        [CategoryAttribute("PDF Settings"), DescriptionAttribute("Select where is the introduction page located")]
        public PagePosition PdfIntroPagePosition { get; set; }

        public bool AutoLoadChapter { get; set; }

        public bool EnableResizeImage { get; set; }
        public bool KeepRatio { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// {{PAGENUM}} .{FILENAME} {{CHAPTER} {{}}
        /// </summary>
        //public bool EnableRename { get; set; }
        public string RenamePattern { get; set; }


        [CategoryAttribute("Download settings"), DescriptionAttribute("Using multiple thread to download pages in a chapter, this will make increase download speed but need more CPU & Network usage. Use this option on slow netowrk will help you save a ton of time. :)")]
        public bool UseMultiThreadToDownloadChapter { get; set; }

        public ComicDownloaderSettings()
        {
            CreatePDF = true;
            IncludePDFIntroPage = true;
            PdfIntroPagePosition = PagePosition.LastPage;
        }
    }
}
