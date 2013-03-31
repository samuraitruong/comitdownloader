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

    public enum FinishActions
    {
        Nothing,
        OpenInViewer,
        ShutdownPC
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

         [CategoryAttribute("Queue download"), DescriptionAttribute("select action to execute when queue finish")]
        public FinishActions WhenDoneAction { get; set; }

        public bool AutoLoadChapter { get; set; }

         [CategoryAttribute("Download settings")]
        public bool EnableResizeImage { get; set; }
        [CategoryAttribute("Download settings")]
        public bool KeepRatio { get; set; }
        [CategoryAttribute("Download settings")]
        public int Width { get; set; }
        [CategoryAttribute("Download settings")]
        public int Height { get; set; }

        /// <summary>
        /// {{PAGENUM}} .{FILENAME} {{CHAPTER} {{}}
        /// </summary>
        //public bool EnableRename { get; set; }
        [CategoryAttribute("Download settings")]
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
