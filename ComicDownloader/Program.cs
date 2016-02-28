using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using ComicDownloader.Forms;
using System.Diagnostics;
using ComicDownloader.Engines;
using Fclp;
using ComicDownloader.Engines.DataExtractor;

namespace ComicDownloader
{
    static class Program
    {
        public class ApplicationArguments
        {
            public bool Uninstall { get; set; }
            public bool Extract { get; set; }

            public  bool Full { get; set; }
            public bool Incremental { get; set; }
            public string OutputFolder { get; set; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args){

            var p = new FluentCommandLineParser<ApplicationArguments>();
            p.Setup(arg => arg.Extract).As('e', "extract");
            p.Setup(arg => arg.OutputFolder).As('o', "output");
            p.Setup(arg => arg.Full).As('f', "full");
            p.Setup(arg => arg.Incremental).As('i', "incremental");
            p.Setup(arg => arg.Uninstall).As('u', "uninstall");
            var cmd = p.Parse(args);

            if (args.Length>0 && args[0] =="/uninstall") {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = args[0] + " " + args[1],
                    FileName = "msiexec.exe"
                });
                return;
                }

            if (p.Object.Extract)
            {

                Win32NativeMethods.AllocConsole();
                DataExtractor.Run(p.Object);
                return;
            };

            //if (CheckInternetConnection())
            {
                Application.ThreadException += OnThreadException;
                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new AppMainForm());
                Application.Run(new ModernUIForm());
            }
            //else
            {
             //   Application.Exit();
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MyLogger.Log(e.ExceptionObject as Exception);
            //Application.Exit();
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MyLogger.Log(e.Exception);
            //Application.Exit();
        }

        public static bool CheckInternetConnection()
        {
            HttpWebRequest objReq;
            HttpWebResponse objRes;
            bool availableInternet = false;

            try
            {
                objReq = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com");
                objRes = (HttpWebResponse)objReq.GetResponse();
                if (objRes.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("Internet Connection is not Available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    availableInternet = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internet Connection is not Available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return availableInternet;
        }
    }
}
