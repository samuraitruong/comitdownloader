using ComicDownloader.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Helpers
{
    public class ReplaceTokensHelper
    {
        private static List<KeyValuePair<string, string>> tokens = null;
        private static object locker = new object();
        public static List<KeyValuePair<string, string>> GetTokens()
        {
            lock (locker)
            {
                if (tokens == null)
                {
                    tokens = new List<KeyValuePair<string, string>>();
                    var result = Resources.replace_tokens.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    tokens.AddRange(result.Skip(1).Select(p =>
                    {
                        var arr = p.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        return new KeyValuePair<string, string>(arr[0], arr[1]);
                    }));

                    tokens.Sort((a, b) =>
                    {
                        return b.Key.Length - a.Key.Length;
                    });
                }

            }
            return tokens;
        }
        /// <summary>
        /// replace string token if matchs
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Replace(string s)
        {
            var replacedSrc = s;
            var arr = GetTokens();
            foreach (var item in arr)
            {
                replacedSrc = replacedSrc.Replace(item.Key, item.Value);
            }

            return replacedSrc;

        }
    }
}
