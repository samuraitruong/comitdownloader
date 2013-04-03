using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicDownloader
{
    public class MyLogger
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Log(Exception ex)
        {
            logger.Error(ex.Message + ex.StackTrace);
        }
    }
}
