using System.Text;
using Griffin.Networking.Protocol.Http.Protocol;

namespace Griffin.WebServer
{
    /// <summary>
    /// Used to build error info.
    /// </summary>
    internal static class RequestExtensions
    {
        /// <summary>
        /// Generate error information string including query string, form and cookies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string BuildErrorInfo(this IRequest request)
        {
            var sb = new StringBuilder();
            sb.AppendLine("URI: " + request.Uri);

            sb.AppendLine("Querystring");
            foreach (var kvp in request.QueryString)
            {
                sb.AppendFormat("{0}: {1}\r\n", kvp, kvp.Value);
            }

            sb.AppendLine("Form");
            foreach (var kvp in request.Form)
            {
                sb.AppendFormat("{0}: {1}\r\n", kvp, kvp.Value);
            }

            sb.AppendLine("Cookies");
            foreach (var kvp in request.Cookies)
            {
                sb.AppendFormat("{0}: {1}\r\n", kvp, kvp.Value);
            }

            return sb.ToString();
        }
    }
}