using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicDownloader.Helpers
{
    public class MobiHelper
    {
        public static void ConvertEpubToMobi(string filepath)
        {
            var kindleGen = new Process();
            kindleGen.StartInfo.UseShellExecute = false;
            kindleGen.StartInfo.RedirectStandardOutput = true;
            kindleGen.StartInfo.FileName = Path.Combine(Application.StartupPath, "kindlegen.exe");
            kindleGen.StartInfo.Arguments = string.Format("\"{0}\" -c1 -verbose", filepath);
            kindleGen.Start();

            var output = kindleGen.StandardOutput.ReadToEnd();
            kindleGen.WaitForExit();
        }
        //public static void GenereateEpubFromHtml(string[] htmlFiles, string mobileFile, string title)
        //{
        //    var mergeFile = Path.GetTempFileName();

        //    foreach (var item in htmlFiles)
        //    {

        //    }
        //    File.Delete(mobileFile);
        //    var kindleGen = new Process();
        //    kindleGen.StartInfo.UseShellExecute = false;
        //    kindleGen.StartInfo.RedirectStandardOutput = true;
        //    kindleGen.StartInfo.FileName = Path.Combine(Application.StartupPath, "kindlegen.exe");
        //    kindleGen.StartInfo.Arguments = string.Format("\"{0}\"", filepath);
        //    kindleGen.Start();

        //    var output = kindleGen.StandardOutput.ReadToEnd();
        //    kindleGen.WaitForExit();

        //}
    }
}
