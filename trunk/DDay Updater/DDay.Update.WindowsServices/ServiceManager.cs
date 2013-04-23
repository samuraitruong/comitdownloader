using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using Microsoft.CSharp;

namespace DDay.Update.WindowsServices
{
    static public class ServiceManager
    {
        #region Static Private Methods

        static private void GenerateAndRunServiceUpdaterAssembly(
            string serviceName,
            string servicePath, 
            Uri uri, 
            string username,
            string password, 
            string domain)
        {
            CSharpCodeProvider provider;
            CompilerParameters parameters;
            CompilerResults results;

            string folder = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            string serviceUpdaterPath = Path.Combine(folder, "ServiceUpdater.exe");

            FileStream fs = new FileStream(Path.Combine(folder, "update.log"), FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                if (File.Exists(serviceUpdaterPath))
                {
                    sw.WriteLine("Deleting ServiceUpdater.exe from previous update...");
                    File.Delete(serviceUpdaterPath);
                }

                sw.WriteLine("Preparing for updater assembly compilation...");

                parameters = new CompilerParameters();
                parameters.OutputAssembly = serviceUpdaterPath;
                parameters.GenerateExecutable = true;
                parameters.GenerateInMemory = false;
                parameters.MainClass = "DDay.Update.Launcher.Program";
                parameters.IncludeDebugInformation = false;
                parameters.TreatWarningsAsErrors = false;
                parameters.WarningLevel = 4;

                // Optimize output, and prevent it from opening a console window
                parameters.CompilerOptions = "/optimize /target:winexe";

                // Put any references needed here
                string[] refs = new string[]
                    {
                        "System.dll",
                        "System.ServiceProcess.dll",
                        Path.Combine(folder, "DDay.Update.dll"),
                        Path.Combine(folder, "DDay.Update.WindowsServices.dll")
                    };

                // Add the assemblies that we will reference to our compiler parameters
                parameters.ReferencedAssemblies.AddRange(refs);

                // Get a code provider for C#
                provider = new CSharpCodeProvider();

                string sourceCode = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DDay.Update.Utilities;
using DDay.Update.WindowsServices;

namespace DDay.Update.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(" + "\"service-update.log\"" + @", FileMode.Create, FileAccess.Write);
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
                    sw.WriteLine(" + "\"Update is available, beginning update process...\"" + @");

                    sw.WriteLine(" + "\"Stopping service '\" + serviceName + \"'...\"" + @");

                    // Perform the update, which performs the following steps:
                    // 1. Updates to a new version of the application
                    // 2. Saves new deployment and application manifests locally
                    // 3. Removes previous versions of the application (depending on configuration settings)
                    UpdateManager.Update();
                    sw.WriteLine(" + "\"Update complete.\"" + @");

                    // Load the application manifest from the update
                    sw.WriteLine(" + "\"Loading new application manifest...\"" + @");
                    ApplicationManifest appManifest = UpdateManager.GetCurrentApplicationManifest();
                    if (appManifest != null && appManifest.EntryPoint != null)
                    {
                        string workingDir = Path.Combine(
                            UpdateManager.VersionRepositoryFolder,
                            appManifest.AssemblyIdentity.Version.ToString()
                        );

                        string servicePath = Path.Combine(workingDir, appManifest.EntryPoint.CommandLine.File);

                        // Stop the service, and all dependent services
                        ServiceManager.Stop(serviceName, true);

                        sw.WriteLine(" + "\"Service stopped.\"" + @");

                        sw.WriteLine(" + "\"Uninstalling previous service...\"" + @");
                        ServiceManager.Uninstall(Assembly.LoadFile(oldServicePath));
                        sw.WriteLine(" + "\"Service uninstalled.\"" + @");

                        // Install the new service
                        sw.WriteLine(" + "\"Installing service at '\" + servicePath + \"'...\"" + @");
                        ServiceManager.Install(Assembly.LoadFile(servicePath));
                        sw.WriteLine(" + "\"Service installed.\"" + @");

                        // Start the service, and all dependent services
                        sw.WriteLine(" + "\"Starting service '\" + serviceName + \"'...\"" + @");
                        ServiceManager.Start(serviceName, true);

                        sw.WriteLine(" + "\"Service started.\"" + @");
                    }
                    else sw.WriteLine(" + "\"Could not get an application manifest for the new version of the service.\"" + @");
                }
                else
                {
                    sw.WriteLine(" + "\"Application is up-to-date.\"" + @");
                }
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
        }
    }
}";
                // Compile our code
                results = provider.CompileAssemblyFromSource(parameters, new string[] { sourceCode });

                // Ensure there were no errors in the code
                if (results.Errors.Count > 0)
                {
                    sw.WriteLine("Compilation failed.");

                    foreach (CompilerError err in results.Errors)
                        sw.WriteLine(err.ToString());

                    throw new Exception("There were errors while compiling the updater assembly!");
                }
                else
                {
                    sw.WriteLine("Compilation succeeded.");
                }

                sw.WriteLine("Building a list of arguments to run update assembly...");

                // Build a list of arguments
                List<string> argList = new List<string>();
                argList.Add("\"" + serviceName + "\"");
                argList.Add("\"" + servicePath + "\"");
                argList.Add("\"" + uri.AbsoluteUri + "\"");                
                if (!string.IsNullOrEmpty(username))
                {
                    argList.Add("\"" + username + "\"");                    
                    if (!string.IsNullOrEmpty(password))
                    {
                        argList.Add("\"" + password + "\"");
                        if (!string.IsNullOrEmpty(domain))
                            argList.Add("\"" + domain + "\"");                            
                    }
                }

                sw.WriteLine("Attempting to run updater assembly: " + results.PathToAssembly + " " + string.Join(" ", argList.ToArray()));

                // Execute the launcher process that we just compiled
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = results.PathToAssembly;
                process.StartInfo.Arguments = string.Join(" ", argList.ToArray());
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
        }

        #endregion

        #region Static Public Methods

        /// <summary>
        /// Installs the windows service contained in the provided assembly.
        /// </summary>        
        static public void Install(Assembly assembly)
        {
            AssemblyInstaller Installer = new AssemblyInstaller(assembly, null);
            Installer.UseNewContext = true;
            Installer.Install(null);
            Installer.Commit(null);
        }

        /// <summary>
        /// Uninstalls the windows service contained in the provided assembly.
        /// </summary>
        /// <param name="assembly"></param>
        static public void Uninstall(Assembly assembly)
        {
            AssemblyInstaller Installer = new AssemblyInstaller(assembly, null);
            Installer.UseNewContext = true;
            Installer.Uninstall(null);
        }

        /// <summary>
        /// Stops the service indicated by the ServiceController parameter.
        /// </summary>
        /// <param name="controller">The service to stop.</param>
        /// <param name="stopDependentServices">Whether or not to stop dependent services also.</param>
        static public void Stop(ServiceController controller, bool stopDependentServices)
        {
            if (controller != null &&
                controller.CanStop &&
                controller.Status != ServiceControllerStatus.Stopped &&
                controller.Status != ServiceControllerStatus.StopPending)
            {
                // First stop all dependent services
                foreach (ServiceController dep in controller.DependentServices)
                {
                    Stop(dep, stopDependentServices);
                }

                // Then stop this service
                controller.Stop();
            }
        }

        /// <summary>
        /// Stops the service indicated by the ServiceController parameter.
        /// </summary>
        /// <param name="serviceName">The name of the service to stop.</param>
        /// <param name="stopDependentServices">Whether or not to stop dependent services also.</param>
        static public void Stop(string serviceName, bool stopDependentServices)
        {
            using (ServiceController controller = new ServiceController(serviceName))
            {
                Stop(controller, stopDependentServices);
            }
        }

        /// <summary>
        /// Starts the service indicated by the ServiceController parameter.
        /// </summary>
        /// <param name="controller">The service to start.</param>
        /// <param name="startDependentServices">Whether or not to start dependent services also.</param>
        static public void Start(ServiceController controller, bool startDependentServices)
        {
            if (controller != null &&
                controller.Status != ServiceControllerStatus.StartPending &&
                controller.Status != ServiceControllerStatus.Running)
            {
                // First start this service
                controller.Start();

                // Then start all dependent services
                foreach (ServiceController dep in controller.DependentServices)
                {
                    Start(dep, startDependentServices);
                }
            }
        }

        /// <summary>
        /// Starts the service indicated by the ServiceController parameter.
        /// </summary>
        /// <param name="serviceName">The name of the service to start.</param>
        /// <param name="startDependentServices">Whether or not to start dependent services also.</param>
        static public void Start(string serviceName, bool startDependentServices)
        {
            using (ServiceController controller = new ServiceController(serviceName))
            {
                Start(controller, startDependentServices);
            }
        }

        /// <summary>
        /// Performs an update on the service with the
        /// given service name.  It is safe for the service
        /// itself to execute this code, with the understanding
        /// that the service may be shut down, uninstalled,
        /// updated, and reinstalled afterward.
        /// </summary>
        static public void Update(string serviceName, string servicePath, Uri uri, string username, string password, string domain)
        {
            GenerateAndRunServiceUpdaterAssembly(serviceName, servicePath, uri, username, password, domain);
        }

        #endregion
    }
}
