using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;

using DDay.Update.Utilities;
using DDay.Update.Configuration;

[[AssemblyAttributes]]

namespace DDay.Update.Bootstrap
{
    class Program
    {
        static private ILog log = new Log4NetLogger();

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Get the DDay.Update configuration section
            DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                as DDayUpdateConfigurationSection;

            // Set the command line parameters to the application
            UpdateManager.SetCommandLineParameters(args);

            try
            {
                // Determine if an update is available
                if (cfg.Automatic)
                {
                    if (UpdateManager.IsUpdateAvailable(cfg.Uri, cfg.Username, cfg.Password, cfg.Domain))
                    {
                        log.Debug("Update is available, beginning update process...");

                        // Perform the update, which performs the following steps:
                        // 1. Updates to a new version of the application
                        // 2. Saves new deployment and application manifests locally
                        // 3. Removes previous versions of the application (depending on configuration settings)
                        UpdateManager.Update();
                    }
                    else
                    {
                        log.Debug("Application is up-to-date.");
                    }
                }
                else
                {
                    log.Debug("Automatic updates are disabled.");
                }
            }
            finally
            {
                // Start the application
                UpdateManager.StartApplication();
            }
            
            log.Debug("Exiting bootstrap application...");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            log.Error("An unhandled exception occurred during the update process!", e.ExceptionObject as Exception);
            UpdateManager.StartApplication();
        }
    }
}
