using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using System.Net;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

using DDay.Update.Utilities;
using DDay.Update.Configuration;

namespace DDay.Update
{
    public class UpdateManager
    {
        static private ILog log = new Log4NetLogger();
        static string[] _CommandLineParameters = new string[0];
        static private AutoResetEvent _UpdateEvent = new AutoResetEvent(false);

        const string LocalDeploymentManifestFilename = "deployment.manifest";
        const string LocalApplicationManifestFilename = "application.manifest";
        const string BootstrapFolder = "Bootstrap";
        const string BootstrapFilesExtension = "bootstrap";

        #region Static Public Events

        static public event EventHandler UpdateCompleted;
        static public event EventHandler UpdateCancelled;
        static public event EventHandler<ExceptionEventArgs> UpdateError;

        #endregion

        #region Static Private Fields

        static private DeploymentManifest _DeploymentManifest;
        static private DeploymentManifest _LocalDeploymentManifest;
        static private IUpdateNotifier _UpdateNotifier = null;
        
        #endregion

        #region Static Public Properties

        /// <summary>
        /// Gets/sets the remote deployment manifest.
        /// </summary>
        public static DeploymentManifest DeploymentManifest
        {
            get { return UpdateManager._DeploymentManifest; }
            set { UpdateManager._DeploymentManifest = value; }
        }

        /// <summary>
        /// Gets/sets the local deployment manifest.
        /// </summary>
        public static DeploymentManifest LocalDeploymentManifest
        {
            get { return UpdateManager._LocalDeploymentManifest; }
            set { UpdateManager._LocalDeploymentManifest = value; }
        }

        /// <summary>
        /// The 'Company' specified in the current assembly.
        /// </summary>
        static private string _AssemblyCompany = null;
        static public string AssemblyCompany
        {
            get
            {
                if (_AssemblyCompany == null)
                {
                    Assembly currentAssembly = Assembly.GetEntryAssembly();
                    object[] attrs = currentAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);
                    if (attrs.Length > 0)
                        _AssemblyCompany = ((AssemblyCompanyAttribute)attrs[0]).Company;
                    else
                        _AssemblyCompany = string.Empty;
                }
                return _AssemblyCompany;
            }
        }

        /// <summary>
        /// The 'Product' specified in the current assembly.
        /// </summary>
        static private string _AssemblyProduct = null;
        static public string AssemblyProduct
        {
            get
            {
                if (_AssemblyProduct == null)
                {
                    Assembly currentAssembly = Assembly.GetEntryAssembly();
                    object[] attrs = currentAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), true);
                    if (attrs.Length > 0)
                        _AssemblyProduct = ((AssemblyProductAttribute)attrs[0]).Product;
                    else
                        _AssemblyProduct = Path.GetFileName(currentAssembly.Location);
                }

                return _AssemblyProduct;
            }
        }

        /// <summary>
        /// Gets the path to the base folder of the application.  This folder should
        /// contain the bootstrap (launcher) files and the deployment manifest.        
        /// </summary>
        static public string BaseApplicationFolder
        {
            get
            {
                Assembly currentAssembly = Assembly.GetEntryAssembly();

                string assemblyLocation = Path.GetDirectoryName(currentAssembly.Location);
                string baseLocation = assemblyLocation;

                while (!File.Exists(
                    Path.Combine(baseLocation, LocalDeploymentManifestFilename)))
                {
                    string oldLocation = baseLocation;
                    baseLocation = Path.GetFullPath(Path.Combine(baseLocation, ".."));
                    if (!Directory.Exists(baseLocation) ||
                        oldLocation.Equals(baseLocation))
                    {
                        return assemblyLocation;
                    }
                }

                return baseLocation;
            }
        }

        static public string VersionRepositoryFolder
        {
            get
            {
                DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                    as DDayUpdateConfigurationSection;

                if (cfg != null &&
                    (
                        cfg.UseUserFolder ||
                        cfg.UsePublicFolder
                    ))
                {
                    string[] parts = new string[] { AssemblyCompany, AssemblyProduct };
                    string appDir = string.Join(Path.DirectorySeparatorChar.ToString(), parts);
                    string appData = Environment.GetFolderPath(
                        cfg.UseUserFolder ?
                        Environment.SpecialFolder.ApplicationData :
                        Environment.SpecialFolder.CommonApplicationData
                    );
                    string appPath = Path.Combine(appData, appDir);

                    if (!Directory.Exists(appPath))
                        Directory.CreateDirectory(appPath);

                    return appPath;
                }
                return BaseApplicationFolder;
            }
        }

        /// <summary>
        /// Gets the absolute path to the local deployment manifest.
        /// </summary>
        static public string LocalDeploymentManifestPath
        {
            get
            {
                return Path.Combine(VersionRepositoryFolder, LocalDeploymentManifestFilename);
            }
        }

        /// <summary>
        /// Gets the relative path to the entry point (executable) of
        /// the current published version of the application.
        /// </summary>
        static public string ApplicationRelativePath
        {
            get
            {
                if (LocalDeploymentManifest != null)
                {
                    return
                        Path.Combine(
                            LocalDeploymentManifest.CurrentPublishedVersion.ToString(),
                            LocalApplicationManifestFilename
                        );
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the absolute path to the entry point (executable) of
        /// the current published version of the application.
        /// </summary>
        static public string ApplicationPath
        {
            get
            {
                string relativePath = ApplicationRelativePath;

                if (relativePath != null)
                {
                    return
                        Path.Combine(
                            VersionRepositoryFolder,
                            relativePath
                        );
                }
                return null;
            }
        }
        
        /// <summary>
        /// Gets the relative path to the entry point (executable) of
        /// the new version of the application.
        /// </summary>
        static public string ApplicationDestinationRelativePath
        {
            get
            {
                if (DeploymentManifest != null)
                {
                    return 
                        Path.Combine(
                            DeploymentManifest.CurrentPublishedVersion.ToString(),
                            LocalApplicationManifestFilename
                        );
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the absolute path to the entry point (executable) of
        /// the new version of the application.
        /// </summary>
        static public string ApplicationDestinationPath
        {
            get
            {                
                string relativePath = ApplicationDestinationRelativePath;

                if (relativePath != null)
                {
                    return
                        Path.Combine(
                            VersionRepositoryFolder,
                            relativePath
                        );
                }
                return null;
            }
        }

        #endregion

        #region Static Protected Methods

        static protected void OnUpdateCompleted()
        {
            if (UpdateCompleted != null)
                UpdateCompleted(null, EventArgs.Empty);
        }

        static protected void OnUpdateCancelled()
        {
            if (UpdateCancelled != null)
                UpdateCancelled(null, EventArgs.Empty);
        }

        static protected void OnUpdateError(Exception ex)
        {
            if (UpdateError != null)
                UpdateError(null, new ExceptionEventArgs(ex));
        }

        #endregion

        #region Static Public Methods

        /// <summary>
        /// Sets the command-line parameters that will be
        /// passed to the target application.
        /// </summary>
        static public void SetCommandLineParameters(string[] parameters)
        {
            _CommandLineParameters = parameters;
        }

        /// <summary>
        /// Determines if an update is available by downloading the
        /// deployment manifest for the application and comparing
        /// the current version vs. the most recent deployment
        /// version found in the deployment manifest.
        /// </summary>
        /// <returns>True if an update is available, false otherwise.</returns>
        static public bool IsUpdateAvailable(Uri uri) { return IsUpdateAvailable(uri, null, null, null); }
        static public bool IsUpdateAvailable(Uri uri, string username, string password, string domain)
        {
            bool retval = false;

            try
            {
                EnsureUpdateNotifier();

                if (_UpdateNotifier != null)
                    _UpdateNotifier.BeginVersionCheck();

                // Append the deployment manifest name to the end of the
                // update uri, if it isn't already provided
                if (!uri.AbsoluteUri.EndsWith(".application", true, CultureInfo.CurrentCulture))
                {
                    string applicationName = Path.GetFileNameWithoutExtension(
                        Assembly.GetEntryAssembly().ManifestModule.Name) + ".application";

                    UriBuilder uriBuilder = new UriBuilder(uri.AbsoluteUri);
                    uriBuilder.Path = Path.Combine(uriBuilder.Path, applicationName);
                    uri = uriBuilder.Uri;
                }

                // Try to download a deployment manifest
                DeploymentManifest = new DeploymentManifest(uri, username, password, domain);

                // Get the local deployment manifest
                LoadLocalDeploymentManifest();

                // Determine if the local version is less than the server version
                Version serverVersion = new Version(1, 0);
                Version localVersion = new Version(0, 0);

                log.Debug("Comparing versions...");

                if (DeploymentManifest != null)
                    serverVersion = DeploymentManifest.CurrentPublishedVersion;

                if (LocalDeploymentManifest != null)
                    localVersion = LocalDeploymentManifest.CurrentPublishedVersion;

                log.Debug("Server version is: " + serverVersion);
                log.Debug("Local version is: " + localVersion);

                if (localVersion < serverVersion)
                {
                    log.Debug("An update is available!");

                    // If the server version is newer than our local version,
                    // then an update is available!
                    retval = true;
                    return retval;
                }
                log.Debug("No update is necessary.");
            }
            catch (WebException ex)
            {
                string s = ex.Message;
            }
            catch (Exception)
            {
                // FIXME: log information on catch
            }
            finally
            {
                if (_UpdateNotifier != null)
                    _UpdateNotifier.EndVersionCheck(retval);
            }
            
            return retval;
        }

        /// <summary>
        /// Performs a synchronous update of the application.
        /// </summary>
        /// <returns>True if an update was started, false otherwise.</returns>
        static public bool Update()
        {
            return Update(false);
        }

        /// <summary>
        /// Performs a synchronous update of the application.
        /// </summary>
        /// <param name="doQuietUpdate">
        /// True if no user-intervention should be allowed, 
        /// false otherwise (defaults to false).
        /// </param>
        /// <returns>True if an update was started, false otherwise.</returns>
        static public bool Update(bool doQuietUpdate)
        {            
            try
            {
                Updater updater = new Updater();
                updater.UpdateNotifier = _UpdateNotifier;

                AutoResetEvent updateEvent = new AutoResetEvent(false);
                bool updateSuccessful = true;

                updater.Error += delegate(object sender, ExceptionEventArgs errorArgs)
                {
                    // Indicate that the update did not succeed
                    updateSuccessful = false;

                    // Notify that an error occurred
                    OnUpdateError(errorArgs.Exception);
                    
                    // Allow the method to exit
                    updateEvent.Set();
                };

                updater.Cancelled += delegate(object sender, EventArgs cancelArgs)
                {
                    // Indicate that the update did not succeed
                    updateSuccessful = false;

                    // Notify that the update was cancelled
                    OnUpdateCancelled();

                    // Allow the method to exit
                    updateEvent.Set();
                };

                updater.Completed += delegate(object sender, EventArgs compArgs)
                {
                    // If the update completed successfully,
                    // update the local manifest files
                    SaveLocalManifests();

                    // Remove previous versions of the application,
                    // if setup to do so
                    RemovePreviousVersions();

                    // Notify that the update has completed
                    OnUpdateCompleted();

                    // Allow the method to exit
                    updateEvent.Set();
                };

                // Start the update process, and get the initial result
                bool initialUpdateResult = updater.Update(doQuietUpdate);
                
                // Wait for the update process to complete
                if (initialUpdateResult)
                    updateEvent.WaitOne();

                return initialUpdateResult && updateSuccessful;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Performs an asynchronous update of the application.
        /// </summary>
        static public void UpdateAsync()
        {
            new Thread(new ThreadStart(delegate { Update(); })).Start();
        }

        /// <summary>
        /// Performs an asynchronous update of the application.
        /// </summary>
        /// <param name="doQuietUpdate">
        /// True if no user-intervention should be allowed, 
        /// false otherwise (defaults to false).
        /// </param>
        static public void UpdateAsync(bool doQuietUpdate)
        {
            ThreadStart starter = delegate { Update(doQuietUpdate); };
            new Thread(starter).Start();
        }

        /// <summary>
        /// Starts the application using the deployment and
        /// application manifests.
        /// </summary>
        /// <exception cref="ApplicationRestartException">
        /// If the application could not be started automatically
        /// </exception>
        static public void StartApplication()
        {
            log.Info("Starting application...");

            // Get the current application manifest
            ApplicationManifest appManifest = GetCurrentApplicationManifest();            

            // If there is enough information to restart the application, do it now!            
            if (appManifest != null &&
                appManifest.EntryPoint != null)
            {
                // NOTE: using workingDir fixes bug #1955109 - Working Directory not set
                string workingDir = Path.Combine(
                    VersionRepositoryFolder,
                    appManifest.AssemblyIdentity.Version.ToString()
                );

                log.Debug("Executing entry point...");
                appManifest.EntryPoint.Run(
                    workingDir,
                    _CommandLineParameters);
                log.Debug("Done.");
            }
            else
            {
                log.Error("The application manifest could not be loaded, or the entry point was missing or invalid.");
                throw new ApplicationStartException();
            }
        }

        /// <summary>
        /// Updates bootstrap files.  This should be called
        /// as the first line of code in the main application.
        /// </summary>
        static public void UpdateBootstrapFiles()
        {
            Assembly currentAssembly = Assembly.GetEntryAssembly();

            // Ensure we aren't running from the bootstrap application
            if (!currentAssembly.FullName.Contains("DDay.Update.Bootstrap"))
            {
                DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                    as DDayUpdateConfigurationSection;

                // Determine the name of the bootstrap files folder
                string bootstrapFolderName = BootstrapFolder;
                if (cfg != null &&
                    !string.IsNullOrEmpty(cfg.BootstrapFilesFolder))
                    bootstrapFolderName = cfg.BootstrapFilesFolder;

                string assemblyLocation = Path.GetDirectoryName(currentAssembly.Location);
                string assemblyName = Path.GetFileName(currentAssembly.Location);
                string bootstrapFolder = Path.Combine(assemblyLocation, bootstrapFolderName);
                string baseLocation = BaseApplicationFolder;

                log.Debug("Looking for bootstrap folder at '" + bootstrapFolder + "'...");

                // Ensure the bootstrap folder exists
                if (Directory.Exists(bootstrapFolder))
                {
                    log.Debug("Found bootstrap folder!");

                    try
                    {
                        // Find all files in the bootstrap folder
                        string[] files = Directory.GetFiles(bootstrapFolder);
                        foreach (string file in files)
                        {
                            // Determine the name of the destination file                            
                            string filename = Path.GetFileName(file);
                            if (filename.EndsWith(BootstrapFilesExtension))
                                filename = filename.Substring(filename.Length - BootstrapFilesExtension.Length);

                            // Determine the destination path...
                            string destFile = Path.Combine(baseLocation, filename);
                            log.Debug("File destination is: '" + destFile + "'");

                            // Rename the previous file, if it exists
                            if (File.Exists(destFile))
                            {
                                log.Debug("Renaming file '" + destFile + "' to '" + destFile + ".backup'...");
                                File.Move(destFile, destFile + ".backup");
                            }

                            log.Debug("Copying '" + file + "' to '" + destFile + "'...");
                            File.Copy(file, destFile);

                            // If we got this far OK, then delete the backup file!
                            if (File.Exists(destFile + ".backup"))
                            {
                                log.Debug("Deleting '" + destFile + ".backup'...");
                                File.Delete(destFile + ".backup");
                            }
                        }

                        // Delete each file in the bootstrap folder
                        foreach (string file in files)
                            File.Delete(file);

                        // Delete the bootstrap folder altogether
                        Directory.Delete(bootstrapFolder);
                    }
                    catch (Exception ex)
                    {
                        log.Error("An error occurred while updating the bootstrap files: " + ex.Message);
                        log.Debug("Restoring backup files...");

                        string[] files = Directory.GetFiles(baseLocation, "*.backup");
                        foreach (string file in files)
                        {
                            string destFile = file.Substring(0, file.Length - ".backup".Length);
                            if (File.Exists(destFile))
                                File.Move(destFile, destFile + ".old");

                            File.Move(file, destFile);

                            File.Delete(destFile + ".old");
                        }
                    }
                }
                else
                {
                    log.Debug("The bootstrap folder could not be found.");
                }
            }
        }

        /// <summary>
        /// Loads the deployment manifest, if it exists!
        /// </summary>
        static public void LoadLocalDeploymentManifest()
        {
            DeploymentManifest manifest = null;

            log.Debug("Loading local deployment manifest...");

            Assembly assembly = Assembly.GetExecutingAssembly();
            string pathToManifest = Path.Combine(VersionRepositoryFolder, LocalDeploymentManifestFilename);

            log.Debug("Checking for deployment manifest at '" + pathToManifest + "'...");

            // Check if an application manifest exists at the specified location...
            if (File.Exists(pathToManifest))
            {
                log.Debug("Local deployment manifest found.");

                // Get the uri directory for the current assembly
                string baseUri = Path.GetDirectoryName(assembly.CodeBase);

                // Build a Uri to the manifest
                UriBuilder uriBuilder = new UriBuilder(pathToManifest);

                log.Debug("Loading deployment manifest...");
                // Build an ApplicationManifest from the manifest file
                manifest = new DeploymentManifest(uriBuilder.Uri);
            }
            else log.Warn("Manifest not found at '" + pathToManifest + "'.");

            LocalDeploymentManifest = manifest;
        }

        static public ApplicationManifest GetCurrentApplicationManifest()
        {
            ApplicationManifest appManifest = null;

            DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                as DDayUpdateConfigurationSection;

            // Try to load a local deployment manifest
            if (LocalDeploymentManifest == null)
                LoadLocalDeploymentManifest();

            DeploymentManifest deploymentManifest = LocalDeploymentManifest ?? DeploymentManifest;

            // Try to retrieve the application manifest from the
            // deployment manifest.
            if (deploymentManifest != null)
            {
                // Load the deployment manifest, if we haven't done so already!            
                log.Debug("Loading application manifest from deployment manifest...");
                try
                {
                    deploymentManifest.LoadApplicationManifest();
                    appManifest = deploymentManifest.ApplicationManifest;
                    log.Debug("Loaded.");
                }
                catch
                {
                }
            }

            // If we haven't found an application manifest yet, then let's try to load
            // it from a previous version!            
            if (appManifest == null)
            {
                log.Debug("The application manifest could not be located; searching previous versions...");
                if (cfg != null)
                {
                    Version[] localVersions = cfg.VersionManager.LocalVersions;

                    if (localVersions.Length > 0)
                    {
                        for (int i = 0; i < localVersions.Length; i++)
                        {
                            log.Debug("Searching version '" + localVersions[i] + "'...");

                            // Try to load an application manifest
                            // from this version!
                            try
                            {
                                string directory = Path.Combine(VersionRepositoryFolder, localVersions[i].ToString());
                                Uri uri = new Uri(
                                    Path.Combine(
                                        directory,
                                        LocalApplicationManifestFilename
                                    )
                                );

                                log.Debug("Attempting to load manifest from '" + uri.AbsolutePath + "'...");

                                // Get the application manifest                                
                                appManifest = new ApplicationManifest(uri);
                            }
                            catch { }

                            // If we found an application manifest, then check to see
                            // if the application name matches our bootstrap executable
                            // name.  If it doesn't, then we're looking at a version 
                            // of a *different* application, and should ignore it!
                            if (appManifest.EntryPoint != null &&
                                appManifest.EntryPoint.AssemblyIdentity != null &&
                                appManifest.EntryPoint.AssemblyIdentity.Name != null)
                            {
                                string manifestName = appManifest.EntryPoint.AssemblyIdentity.Name;
                                string appName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
                                if (!object.Equals(manifestName, appName))
                                {
                                    log.Debug("The application manifest for application '" + manifestName + "' was found and ignored (looking for '" + appName + "')");
                                    appManifest = null;
                                }
                            }

                            // We found an application manifest that we can use!
                            if (appManifest != null)
                            {
                                log.Debug("Application manifest found!");
                                break;
                            }
                        }
                    }
                }
            }

            return appManifest;
        }
                
        #endregion        

        #region Static Private Methods

        /// <summary>
        /// Tries to determine an update notifier via the configuration file.
        /// </summary>
        static private void EnsureUpdateNotifier()
        {
            DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                as DDayUpdateConfigurationSection;

            // Determine the update notifier that will be used to handle
            // update GUI display.
            if (cfg != null)
            {
                _UpdateNotifier = cfg.UpdateNotifier;
            }
        }

        /// <summary>
        /// Saves deployment and application manifests
        /// to local directories for future reference.
        /// </summary>
        static private void SaveLocalManifests()
        {
            if (DeploymentManifest != null)
            {
                // Get the path where the application manifest should reside...
                Assembly assembly = Assembly.GetExecutingAssembly();

                // Load the application manifest
                DeploymentManifest.LoadApplicationManifest();
                
                // Save the local application manifest also
                DeploymentManifest.ApplicationManifest.Save(ApplicationDestinationPath);

                // Update information in the deployment manifest to reflect
                // the new location of the application manifest.
                foreach (DependentAssembly da in DeploymentManifest.DependentAssemblies)
                {
                    // The deployment manifest should have a single dependent assembly -
                    // the application manifest

                    // Set new information about the application manifest
                    FileInfo fi = new FileInfo(Path.GetFullPath(ApplicationDestinationPath));

                    // Set the codebase for the application to the new version
                    // NOTE: this fixes bug #2001838 - deployment.manifest uses absolute paths
                    da.CodeBase = ApplicationDestinationRelativePath;
                    da.Size = fi.Length;
                }

                // Save the deployment manifest
                DeploymentManifest.Save(LocalDeploymentManifestPath);

                // Get a new local deployment manifest
                LoadLocalDeploymentManifest();
            }
        }

        /// <summary>
        /// Removes previous versions of the application based
        /// on the bootstrap's configuration settings.
        /// </summary>
        static private void RemovePreviousVersions()
        {
            DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                as DDayUpdateConfigurationSection;

            if (cfg != null)
            {
                if (cfg.KeepVersions != null &&
                    cfg.KeepVersions.HasValue)
                {
                    int numToKeep = cfg.KeepVersions.Value;
                    if (numToKeep >= 0)
                    {
                        List<Version> versions = new List<Version>();
                        string[] dirs = Directory.GetDirectories(VersionRepositoryFolder);
                        foreach (string dir in dirs)
                        {
                            try
                            {
                                Version v = new Version(Path.GetFileName(dir));
                                versions.Add(v);
                            }
                            catch
                            {
                            }
                        }

                        // Sort the versions in descending order
                        versions.Sort(delegate(Version v1, Version v2)
                        {
                            return (v2.CompareTo(v1));
                        });

                        if (versions.Count > 1)
                        {
                            // Remove the current version from the list
                            // (always keep the current version)
                            versions.RemoveAt(0);

                            // Remove the versions we want to keep
                            // from the list
                            while (numToKeep-- > 0 &&
                                versions.Count > 0)
                                versions.RemoveAt(0);

                            // We are left with a list of versions
                            // that need to be removed.  Remove them!
                            foreach (Version v in versions)
                                cfg.VersionManager.RemoveVersion(v);
                        }
                    }
                }

                if (cfg.RemovePriorToVersion != null)
                {
                    // Get the maximum version that will
                    // be retained.
                    Version version = cfg.RemovePriorToVersion;
                    if (version != null)
                    {
                        List<Version> versions = new List<Version>();
                        string[] dirs = Directory.GetDirectories(VersionRepositoryFolder);
                        foreach (string dir in dirs)
                        {
                            try
                            {
                                // Get all versions that are less than
                                // the version provided
                                Version v = new Version(Path.GetFileName(dir));
                                if (v < version)
                                    versions.Add(v);
                            }
                            catch
                            {
                            }
                        }

                        // Remove each previous version
                        foreach (Version v in versions)
                            cfg.VersionManager.RemoveVersion(v);
                    }
                }
            }
        }

        #endregion
    }
}
