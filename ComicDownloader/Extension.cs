using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ComicDownloader
{
    public static class Extension
    {
        public static string ToKB(this long number){
            if(number>1024 * 1024 * 1024)
                return Math.Round((decimal)number/(1024*1024*1024),2).ToString() +" GB";

            if (number > 1024 * 1024 )
                return Math.Round((decimal)number / (1024 * 1024 ), 2).ToString() + " MB";

            if (number > 1024 )
                return Math.Round((decimal)number / (1024 ), 2).ToString() + " KB";


            return number.ToString() + " Bytes";

        }
        private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);

        public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;

            if (propertyInfo == null ||
                !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
                @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
            }
        }

        public static object GetPropertyValue(this object destination, string name)
        {
            var type = destination.GetType();
            var pi = type.GetProperty(name);
            object result = null;
            if (pi != null)
            {
                result = pi.GetValue(destination, null);
            }
            return result;
        }

        public static byte[] GetBytes(this Image image)
        {
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                data = ms.GetBuffer();
            }
            return data;
        }
    }
}
