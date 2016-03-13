using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComicWeb.Core
{
    public static class Extensions
    {
        //static string ToSHA256(this string password)
        //{
        //    System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
        //    System.Text.StringBuilder hash = new System.Text.StringBuilder();
        //    byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
        //    foreach (byte theByte in crypto)
        //    {
        //        hash.Append(theByte.ToString("x2"));
        //    }
        //    return hash.ToString();
        //}

        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            return new PagedList<T>(source, pageIndex, pageSize, totalCount);
        }

        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            return new PagedList<T>(source, pageIndex, pageSize, totalCount);
        }


        public static List<string> ToStringList(this char[] chars)
        {
            List<string> list = new List<string>();
            foreach (char c in chars)
            {
                list.Add(c.ToString());
            }

            return list;
        }

        public static string ToCsv(this string[] arr)
        {
            StringBuilder sb = new StringBuilder();
            string comma = string.Empty;
            foreach (string s in arr)
            {
                sb.Append(comma);
                sb.Append(s);
                comma = ",";
            }

            return sb.ToString();
            //return arr.
        }
    }
}
