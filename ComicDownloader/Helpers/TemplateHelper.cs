using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.StringTemplate;

namespace ComicDownloader.Helpers
{
    public class TemplateHelper
    {
        public static string Populate(string template, string key, object obj)
        {
            return Populate(template, new KeyValuePair<string, object>(key, obj));
        }
        public static string Populate(string remplate, params KeyValuePair<string, object>[] variables)
        {

            Antlr4.StringTemplate.Template templator = new Antlr4.StringTemplate.Template(remplate,'$','$');
            Parallel.ForEach(variables, (p) =>
            {
                templator.Add(p.Key, p.Value);
            });
            return templator.Render();
        }
    }
}
