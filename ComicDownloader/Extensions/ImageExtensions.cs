using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;

namespace ComicDownloader.Extensions
{
    public static class ImageExtensions
    {
        public static Image FromUrl(this string url)
        {
            var request = WebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return  Bitmap.FromStream(stream);
            }
            return null;

        }
    }
}
