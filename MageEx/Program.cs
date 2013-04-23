using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MageEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadLine();

            //MageEx -icon icon.ico manifest file
            if (args[0] == "-icon")
            {
                string icon = args[1];
                string manifest = args[2];
                string fileContent = string.Empty;
                using (var file = File.OpenText(manifest))
                {
                    fileContent = file.ReadToEnd();
                }
                string iconstr = string.Format("<description asmv2:iconFile=\"{0}\" xmlns=\"urn:schemas-microsoft-com:asm.v1\" />", icon) +
                                    "\r\n<application />";

                fileContent = fileContent.Replace("<application />", iconstr);

                using (var f = File.OpenWrite(manifest))
                {
                    var bytes = Encoding.Default.GetBytes(fileContent);
                    f.Write(bytes, 0, bytes.Length);
                }

            }
            //mageex -rename input_dir .extension
            if (args[0] == "-rename"){
                string path = args[1];
                string ext = args[2];
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (var item in di.GetFiles())
                {
                    File.Move(item.FullName, item.FullName + ext);
                }
            }
        }
    }
}
