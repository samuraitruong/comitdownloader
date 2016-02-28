using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class IOExtensions
    {
        public static void Overwrite(string filename, string text)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            File.WriteAllText(filename, text, Encoding.UTF8);

        }
    }
}
