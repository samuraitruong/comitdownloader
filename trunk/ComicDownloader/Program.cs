using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using ComicDownloader.Forms;

namespace ComicDownloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
