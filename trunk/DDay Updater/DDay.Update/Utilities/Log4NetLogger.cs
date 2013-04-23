using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DDay.Update.Utilities
{
    public class Log4NetLogger : ILog
    {
        #region Static Private Fields

        static private Type logType;
        static private Type logManagerType;
        static private object logger;

        static private MethodInfo Debug1;
        static private MethodInfo Debug2;
        static private MethodInfo Error1;
        static private MethodInfo Error2;
        static private MethodInfo Fatal1;
        static private MethodInfo Fatal2;
        static private MethodInfo Info1;
        static private MethodInfo Info2;
        static private MethodInfo Warn1;
        static private MethodInfo Warn2;

        #endregion

        #region Static Constructor

        static Log4NetLogger()
        {
            try
            {
                logType = Type.GetType("log4net.ILog, log4net");
                logManagerType = Type.GetType("log4net.LogManager, log4net");
                if (logManagerType != null)
                {
                    Type configuratorType = Type.GetType("log4net.Config.XmlConfigurator, log4net");
                    if (configuratorType != null)
                    {
                        MethodInfo mi = configuratorType.GetMethod("Configure", new Type[0]);
                        if (mi != null)
                        {
                            // Use the XmlConfigurator to configure the logging system
                            mi.Invoke(null, null);

                            // Get the "GetLogger" method from the LogManager
                            mi = logManagerType.GetMethod("GetLogger", new Type[] { typeof(string) });
                            if (mi != null)
                            {
                                logger = mi.Invoke(null, new object[] { "DDay.Update" });

                                Debug1 = logType.GetMethod("Debug", new Type[] { typeof(object) });
                                Debug2 = logType.GetMethod("Debug", new Type[] { typeof(object), typeof(Exception) });
                                Error1 = logType.GetMethod("Error", new Type[] { typeof(object) });
                                Error2 = logType.GetMethod("Error", new Type[] { typeof(object), typeof(Exception) });
                                Fatal1 = logType.GetMethod("Fatal", new Type[] { typeof(object) });
                                Fatal2 = logType.GetMethod("Fatal", new Type[] { typeof(object), typeof(Exception) });
                                Info1 = logType.GetMethod("Info", new Type[] { typeof(object) });
                                Info2 = logType.GetMethod("Info", new Type[] { typeof(object), typeof(Exception) });
                                Warn1 = logType.GetMethod("Warn", new Type[] { typeof(object) });
                                Warn2 = logType.GetMethod("Warn", new Type[] { typeof(object), typeof(Exception) });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ILog Members

        public void Debug(object msg)
        {
            if (logger != null && Debug1 != null)
                Debug1.Invoke(logger, new object[] { msg });
        }

        public void Debug(object msg, Exception e)
        {
            if (logger != null && Debug2 != null)
                Debug2.Invoke(logger, new object[] { msg, e });
        }

        public void Error(object msg)
        {
            if (logger != null && Error1 != null)
                Error1.Invoke(logger, new object[] { msg });
        }

        public void Error(object msg, Exception e)
        {
            if (logger != null && Error2 != null)
                Error2.Invoke(logger, new object[] { msg, e });
        }

        public void Fatal(object msg)
        {
            if (logger != null && Fatal1 != null)
                Fatal1.Invoke(logger, new object[] { msg });
        }

        public void Fatal(object msg, Exception e)
        {
            if (logger != null && Fatal2 != null)
                Fatal2.Invoke(logger, new object[] { msg, e });
        }

        public void Info(object msg)
        {
            if (logger != null && Info1 != null)
                Info1.Invoke(logger, new object[] { msg });
        }

        public void Info(object msg, Exception e)
        {
            if (logger != null && Info2 != null)
                Info2.Invoke(logger, new object[] { msg, e });
        }

        public void Warn(object msg)
        {
            if (logger != null && Warn1 != null)
                Warn1.Invoke(logger, new object[] { msg });
        }

        public void Warn(object msg, Exception e)
        {
            if (logger != null && Warn2 != null)
                Warn2.Invoke(logger, new object[] { msg, e });
        }

        #endregion
    }
}
