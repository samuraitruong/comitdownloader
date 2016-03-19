using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComicDownloader.Helpers
{
    public class UrlHelper
    {
        public static string TryFixUrl(string url)
        {
            url = url.Replace("\r", string.Empty);
            url = url.Replace("\n", string.Empty);
            url = url.Trim();
            //http://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&resize_h=0&rewriteMime=image%2F*&url=https://3.bp.blogspot.com/-95jVsKqsQFs/VqOBGM9n-xI/AAAAAAAASxA/noGXu_AuGgs/d/Ac-Ma-Phap-Tac-Chapter-14-ve-chai-02.jpg
            if (Regex.IsMatch(url, @"\*&url="))
            {
                var match = Regex.Match(url, @"\*&url=(.*)");
                if(match != null)
                {
                    return match.Groups[1].Value;
                }
            }

            if(url.Contains("blogspot.com"))
            {
                url = url.Replace("https://", "http://");
            }
            return url;

        }
    }
}
