using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DDay.Update.Utilities;

namespace DDay.Update.WindowsServices
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("service-update.log", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                Queue<string> argList = new Queue<string>(args);

                // Get the name of the service that is being updated
                string serviceName = argList.Dequeue();

                // The path of the current service executable
                string oldServicePath = argList.Dequeue();

                // Uri is required
                Uri uri = new Uri(argList.Dequeue());

                // Other information is not required
                string username = argList.Count > 0 ? argList.Dequeue() : null;
                string password = argList.Count > 0 ? argList.Dequeue() : null;
                string domain = argList.Count > 0 ? argList.Dequeue() : null;

                if (UpdateManager.IsUpdateAvailable(uri, username, password, domain))
                {
                    sw.WriteLine("Update is available, beginning update process...");

                    // Perform the update, which performs the following steps:
                    // 1. Updates to a new version of the application
                    // 2. Saves new deployment and application manifests locally
                    // 3. Removes previous versions of the application (depending on configuration settings)
                    UpdateManager.Update();
                    sw.WriteLine("Update complete.");

                    // Load the application manifest from the update
                    sw.WriteLine("Loading new application manifest...");
                    ApplicationManifest appManifest = UpdateManager.GetCurrentApplicationManifest();
                    if (appManifest != null && appManifest.EntryPoint != null)
                    {
                        string workingDir = Path.Combine(
                            UpdateManager.VersionRepositoryFolder,
                            appManifest.AssemblyIdentity.Version.ToString()
                        );

                        string servicePath = Path.Combine(workingDir, appManifest.EntryPoint.CommandLine.File);

                        // Stop the service, and all dependent services
                        sw.WriteLine("Stopping service '" + serviceName + "'...");
                        ServiceManager.Stop(serviceName, true);
                        sw.WriteLine("Service stopped.");

                        sw.WriteLine("Uninstalling previous service...");
                        ServiceManager.Uninstall(Assembly.LoadFile(oldServicePath));
                        sw.WriteLine("Service uninstalled.");

                        // Install the new service
                        sw.WriteLine("Installing service at '" + servicePath + "'...");
                        ServiceManager.Install(Assembly.LoadFile(servicePath));
                        sw.WriteLine("Service installed.");

                        // Start the service, and all dependent services
                        sw.WriteLine("Starting service '" + serviceName + "'...");
                        ServiceManager.Start(serviceName, true);

                        sw.WriteLine("Service started.");
                    }
                    else sw.WriteLine("Could not get an application manifest for the new version of the service.");
                }
                else
                {
                    sw.WriteLine("Application is up-to-date.");
                }
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
        }
    }
}