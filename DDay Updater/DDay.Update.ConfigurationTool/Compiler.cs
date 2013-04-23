using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.CodeDom;
using Microsoft.CSharp;

namespace DDay.Update.ConfigurationTool
{
    [Serializable]
    public class Compiler
    {
        static public string CompileBootstrap(string sourceExe, string assemblyName, string targetDir, string iconPath)
        {
            CSharpCodeProvider provider;
            CompilerParameters parameters;
            CompilerResults results;

            if (sourceExe != null)
                sourceExe = Path.GetFullPath(sourceExe);
            
            parameters = new CompilerParameters();
            parameters.OutputAssembly = Path.Combine(targetDir, assemblyName);
            parameters.GenerateExecutable = true;
            parameters.GenerateInMemory = false;
            parameters.MainClass = "DDay.Update.Bootstrap.Program";
            parameters.IncludeDebugInformation = false;
            parameters.TreatWarningsAsErrors = false;
            parameters.WarningLevel = 4;

            // Optimize output, and make a windows executable (no console)
            parameters.CompilerOptions = "/optimize /target:winexe";
            if (!string.IsNullOrEmpty(iconPath))
                parameters.CompilerOptions += " /win32icon:\"" + iconPath + "\"";

            // Put any references you need here - even your own dll's, if you want to use them
            string[] refs = new string[]
            {
                "System.dll",
                "System.Windows.Forms.dll",
                "System.Configuration.dll",
                "DDay.Update.dll"
            };

            // Add the assemblies that we will reference to our compiler parameters
            parameters.ReferencedAssemblies.AddRange(refs);

            // Get the old directory
            string oldDirectory = Directory.GetCurrentDirectory();

            // Set the path to the bootstrap script
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            try
            {
                // Get a code provider for C#
                provider = new CSharpCodeProvider();

                // Open the bootstrap script
                FileStream fs = new FileStream("Bootstrap.cs", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                // Read the entire contents of the file
                string sourceCode = sr.ReadToEnd();

                // Close the bootstrap script
                sr.Close();

                string assemblyAttributes = string.Empty;
                if (sourceExe != null)
                    assemblyAttributes = CopyAssemblyInformation(sourceExe);

                // Add assembly attributes to the source code
                sourceCode = sourceCode.Replace("[[AssemblyAttributes]]", assemblyAttributes);
                
                // Compile our code
                results = provider.CompileAssemblyFromSource(parameters, new string[] { sourceCode });

                if (results.Errors.Count > 0)
                {
                    foreach (CompilerError error in results.Errors)
                    {
                        throw new Exception("An error occurred while compiling the bootstrap: " +
                            String.Format(
                                "Line {0}, Col {1}: Error {2} - {3}",
                                error.Line,
                                error.Column,
                                error.ErrorNumber,
                                error.ErrorText));
                    }
                }

                return results.PathToAssembly;
            }
            finally
            {
                // Return the directory to the previous setting
                Directory.SetCurrentDirectory(oldDirectory);
            }
        }

        static public string CopyAssemblyInformation(string assemblyFile)
        {
            // Open the assembly for the previous .exe
            FileStream fs = new FileStream(assemblyFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] assemblyBytes = br.ReadBytes((int)fs.Length);
            br.Close();

            Assembly assembly = Assembly.Load(assemblyBytes);

            string assemblyAttributes = string.Empty;
                        
            // Determine the assembly attributes from the previous .exe
            foreach (object obj in assembly.GetCustomAttributes(true))
            {
                if (obj is AssemblyCompanyAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyCompany(\"" + ((AssemblyCompanyAttribute)obj).Company + "\")]" + Environment.NewLine;
                if (obj is AssemblyConfigurationAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyConfigurationAttribute(\"" + ((AssemblyConfigurationAttribute)obj).Configuration + "\")]" + Environment.NewLine;
                if (obj is AssemblyCopyrightAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyCopyright(\"" + ((AssemblyCopyrightAttribute)obj).Copyright + "\")]" + Environment.NewLine;
                if (obj is AssemblyCultureAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyCulture(\"" + ((AssemblyCultureAttribute)obj).Culture + "\")]" + Environment.NewLine;
                if (obj is AssemblyDescriptionAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyDescription(\"" + ((AssemblyDescriptionAttribute)obj).Description + "\")]" + Environment.NewLine;
                if (obj is AssemblyFileVersionAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyFileVersion(\"" + ((AssemblyFileVersionAttribute)obj).Version + "\")]" + Environment.NewLine;
                if (obj is AssemblyInformationalVersionAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyInformationalVersion(\"" + ((AssemblyInformationalVersionAttribute)obj).InformationalVersion + "\")]" + Environment.NewLine;
                if (obj is AssemblyProductAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyProduct(\"" + ((AssemblyProductAttribute)obj).Product + "\")]" + Environment.NewLine;
                if (obj is AssemblyTitleAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyTitle(\"" + ((AssemblyTitleAttribute)obj).Title + "\")]" + Environment.NewLine;
                if (obj is AssemblyTrademarkAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyTrademark(\"" + ((AssemblyTrademarkAttribute)obj).Trademark + "\")]" + Environment.NewLine;
                if (obj is AssemblyVersionAttribute)
                    assemblyAttributes += "[assembly: System.Reflection.AssemblyVersion(\"" + ((AssemblyVersionAttribute)obj).Version + "\")]" + Environment.NewLine;
            }

            return assemblyAttributes;
        }
    }
}
