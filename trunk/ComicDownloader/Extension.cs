using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Reflection;

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


            return number.ToString() + "Bytes";

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
    }
}
