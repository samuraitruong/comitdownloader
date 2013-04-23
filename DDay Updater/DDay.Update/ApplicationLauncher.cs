using System;
using System.Collections.Generic;
using System.Text;
using DDay.Update.Utilities;
using System.Diagnostics;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Threading;

namespace DDay.Update
{
    /// <summary>
    /// A delegate for shutting down the application.
    /// </summary>
    public delegate void ApplicationShutdownDelegate();

    public class ApplicationLauncher
    {
        static private ILog log = new Log4NetLogger();
        static private string[] _Arguments = null;

        #region Static Private Methods

        static private void GenerateAndRunLauncherAssembly(Assembly assembly, string[] args)
        {
            CSharpCodeProvider provider;
            CompilerParameters parameters;
            CompilerResults results;

            if (assembly != null)
            {
                // Get the path to the executable
                string pathToExe = assembly.Location;

                parameters = new CompilerParameters();
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
                    "System.dll"
                };

                // Add the assemblies that we will reference to our compiler parameters
                parameters.ReferencedAssemblies.AddRange(refs);

                // Get a code provider for C#
                provider = new CSharpCodeProvider();

                string sourceCode = @"
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DDay.Update.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            bool okToRun = true;

            // Queue up all arguments
            Queue<string> argList = new Queue<string>(args);            

            int processId = -1;            
            if (Int32.TryParse(argList.Peek(), out processId))
                argList.Dequeue();

            if (processId > -1)
            {                
                // Get the process that we're going to restart...
                Process process = null;

                try
                {
                    process = Process.GetProcessById(processId);
                }
                catch (ArgumentException) {} // The process may have already expired

                int milliseconds;
                if (Int32.TryParse(argList.Peek(), out milliseconds))
                    argList.Dequeue();
                else
                    milliseconds = 10000; // 10 seconds

                if (process != null)
                {
                    if (!process.WaitForExit(milliseconds))
                        okToRun = false;
                }
            }

            if (okToRun)
            {
                // Start a new process
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo(argList.Dequeue(), string.Join(" + "\" \"" + @", argList.ToArray()));
                process.Start();
            }
        }
    }
}";
                // Compile our code
                results = provider.CompileAssemblyFromSource(parameters, new string[] { sourceCode });

                // Ensure there were no errors in the code
                if (results.Errors.Count > 0)
                    throw new Exception("There were errors while compiling the launcher assembly!");

                // Build our list of arguments
                Process currentProcess = Process.GetCurrentProcess();
                List<string> argList = new List<string>();
                argList.Add(currentProcess.Id.ToString());
                argList.Add("10000"); // 10 seconds to wait for application to exit, maximum
                argList.Add(pathToExe);
                if (args != null)
                    argList.AddRange(args);

                // Execute the launcher process that we just compiled
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = results.PathToAssembly;
                process.StartInfo.Arguments = string.Join(" ", argList.ToArray());
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }

        #endregion

        #region Static Public Methods

        static public void CaptureArguments(string[] args)
        {
            _Arguments = args;
        }

        /// <summary>
        /// Relaunches the current application with the arguments
        /// passed, using the provided ApplicationShutDownDelegate
        /// to shut down the current application.
        /// </summary>
        static public void Relaunch(ApplicationShutdownDelegate appShutdownDelegate)
        {
            Relaunch(_Arguments, appShutdownDelegate);
        }

        static public void Relaunch(string[] args, ApplicationShutdownDelegate appShutdownDelegate)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            GenerateAndRunLauncherAssembly(assembly, args);

            // Attempt to shut down the application
            if (appShutdownDelegate != null)
            {
                appShutdownDelegate();
            }
        }

        #endregion
    }
}
