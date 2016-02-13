using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ComicDownloader.Extensions
{
    public static class ImageExtensions
    {
        public static Image DownloadAsImage(this string url)
        {
            var request = WebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return  Bitmap.FromStream(stream);
            }
            return null;

        }

        public static Image Clip(this Image imgPhoto, int width, int height)
        {
            return Clip(imgPhoto, width, height, false);
        }

        public static Image ToImage(this byte[] ba)
        {
            var ms = new MemoryStream(ba);
            return Image.FromStream(ms);
        }

        public static byte[] ToArray(this Image imgPhoto)
        {
            var ms = new MemoryStream();

            imgPhoto.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }


        static ImageCodecInfo GetImageCodec(string mimetype)
        {
            foreach (ImageCodecInfo ici in ImageCodecInfo.GetImageEncoders())
            {
                if (ici.MimeType == mimetype) return ici;
            }
            return null;
        }




        public static Image Clip(this Image imgPhoto, int width, int height, bool stretch)
        {
            if (!stretch && (imgPhoto.Width <= width && imgPhoto.Height <= height))
                return imgPhoto;


            // detect if portrait
            if (imgPhoto.Height > imgPhoto.Width)
            {
                // swap
                int a = width;
                width = height;
                height = a;
            }


            var d = new Dimension(imgPhoto.Width, imgPhoto.Height);
            double scale = d.NewSizeScaleFactor(new Dimension(width, height), stretch);

            var newD = scale * d;


            if (stretch)
            {
                if (!(newD.Width == width || newD.Height == height))
                    throw new Exception("Stretching algo has some error");
            }




            var bmPhoto = new Bitmap(imgPhoto, new Size(newD.Width, newD.Height));

            return bmPhoto;
        }


        // using for crystal report
        public static Image PadImage(this Image imgPhoto, int width, int height)
        {
            // detect if portrait
            if (imgPhoto.Height > imgPhoto.Width)
            {
                // swap
                int a = width;
                width = height;
                height = a;
            }

            var d = new Dimension(imgPhoto.Width, imgPhoto.Height);
            double scale = d.NewSizeScaleFactor(new Dimension(width, height), true);

            Dimension newSize = scale * d;


            PadAt padAt;
            int padNeeded;
            newSize.GetPadNeeded(new Dimension(width, height), out padAt, out padNeeded);


            int padLeft = 0, padTop = 0;

            if (padAt == PadAt.Width)
                padLeft = padNeeded;
            else if (padAt == PadAt.Height)
                padTop = padNeeded;



            var bmPhoto = new Bitmap(width, height, PixelFormat.Format24bppRgb);



            var grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);

            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(padLeft, padTop, newSize.Width, newSize.Height),
                new Rectangle(0, 0, imgPhoto.Width, imgPhoto.Height),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;

        }


    }







    public enum PadAt { None = 0, Width = 1, Height }


    public struct Dimension
    {
        public int Width { set; get; }
        public int Height { set; get; }



        public Dimension(int width, int height)
            : this()
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("Width: {0} Height: {1}", Width, Height);
        }



        public static Dimension operator *(Dimension src, double scale)
        {
            return new Dimension((int)Math.Ceiling((scale * src.Width)), (int)Math.Ceiling((scale * src.Height)));
        }


        public static Dimension operator *(double scale, Dimension src)
        {
            return new Dimension((int)Math.Ceiling((scale * src.Width)), (int)Math.Ceiling((scale * src.Height)));
        }


        public double NewSizeScaleFactor(Dimension newSize, bool stretch)
        {


            if (!stretch
                &&

                (this.Width <= newSize.Width && this.Height <= newSize.Height))

                return 1;


            double widthScaleFactor = (double)newSize.Width / this.Width;
            double heightScaleFactor = (double)newSize.Height / this.Height;



            // return the lowest scale factor

            if (widthScaleFactor < heightScaleFactor)
                return widthScaleFactor;
            else if (heightScaleFactor < widthScaleFactor)
                return heightScaleFactor;
            else
                return widthScaleFactor; // can even use heightscalefactor
        }


        public Dimension Clip(Dimension newSize, bool stretch)
        {
            if (!stretch
                &&

                (this.Width <= newSize.Width && this.Height <= newSize.Height))

                return new Dimension(this.Width, this.Height);



            double smallestScaleFactor = NewSizeScaleFactor(newSize, stretch);


            return new Dimension((int)(this.Width * smallestScaleFactor), (int)(this.Height * smallestScaleFactor));
        }




        // so crystal report images would have exact dimension
        public void GetPadNeeded(Dimension newSize, out PadAt padAt, out int padNeeded)
        {

            if (this.Width == newSize.Width && this.Height == newSize.Height)
            {
                padAt = PadAt.None;
                padNeeded = 0;
                return;
            }



            if (this.Width > newSize.Width || this.Height > newSize.Height)
                throw new Exception("Source cannot be bigger than the new size");


            if (this.Width != newSize.Width && this.Height != newSize.Height)
                throw new Exception("At least one side should be equal");


            if (newSize.Width != this.Width)
            {
                padAt = PadAt.Width;
                padNeeded = (newSize.Width - this.Width) / 2;
            }
            else if (newSize.Height != this.Width)
            {
                padAt = PadAt.Height;
                padNeeded = (newSize.Height - this.Height) / 2;
            }
            else
            {
                throw new Exception("Some anomaly occured, contact the programmer");
            }

        }




    }
}
