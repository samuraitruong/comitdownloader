using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Threading;

using DDay.Update.Utilities;
using DDay.Update.Configuration;

namespace DDay.Update
{
    public class Updater
    {
        static private ILog log = new Log4NetLogger();
        
        #region Static Private Properties

        static private DeploymentManifest DeploymentManifest
        {
            get { return UpdateManager.DeploymentManifest; }
        }

        static private DeploymentManifest LocalDeploymentManifest
        {
            get { return UpdateManager.LocalDeploymentManifest; }
        }

        #endregion

        #region Public Events

        public event EventHandler Completed;
        public event EventHandler<ExceptionEventArgs> Error;
        public event EventHandler Cancelled;

        #endregion

        #region Private Fields

        private IUpdateNotifier _UpdateNotifier;
        private bool _CancelledOrError = false;        
        private List<FileDownloader> _FileDownloaders;
        private List<FileDownloader> _Saved;
        private AutoResetEvent _DownloadEvent;

        #endregion

        #region Public Properties

        public IUpdateNotifier UpdateNotifier
        {
            get { return _UpdateNotifier; }
            set { _UpdateNotifier = value; }
        }

        public bool CancelledOrError
        {
            get { return _CancelledOrError; }
            set { _CancelledOrError = value; }
        }

        #endregion

        #region Protected Methods

        virtual protected void OnCompleted()
        {
            if (Completed != null)
                Completed(this, EventArgs.Empty);
        }

        virtual protected void OnCancelled()
        {
            Cancel();

            if (Cancelled != null)
                Cancelled(this, EventArgs.Empty);
        }

        virtual protected void OnError(Exception ex)
        {
            Cancel();

            if (Error != null)
                Error(this, new ExceptionEventArgs(ex));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Performs an update using the update manager's deployment manifest.
        /// </summary>
        /// <returns>True if an update was started, false otherwise.</returns>
        public bool Update()
        {
            return Update(false);
        }

        /// <summary>
        /// Performs an update using the update manager's deployment manifest.
        /// </summary>        
        /// <param name="doQuietUpdate">
        /// True if no user-intervention should be allowed, 
        /// false otherwise (defaults to false).
        /// </param>
        /// <returns>True if an update was started, false otherwise.</returns>
        public bool Update(bool doQuietUpdate)
        {
            try
            {
                log.Debug("Beginning update process...");

                // Add event handlers for our event notifiers
                if (UpdateNotifier != null)
                {
                    log.Debug("Update Notifier setup as '" + UpdateNotifier.ToString() + "'...");
                    log.Debug("Notifying update notifier that the update is beginning...");

                    // Begin the update process with our notifier
                    UpdateNotifier.BeginUpdate(UpdateManager.DeploymentManifest);
                }

                // Determine if the update is required.  If not, then give the user
                // the option to update or not.
                bool doUpdate = true;

                // NOTE: only give the user the option when a valid current version can
                // be detected (a local deployment manifest exists); otherwise, this is
                // a forced deployment (an install rather than an update)
                if (!doQuietUpdate &&
                    (LocalDeploymentManifest != null) &&
                    (UpdateNotifier != null) &&
                    (
                        (DeploymentManifest.Deployment == null) ||
                        (DeploymentManifest.Deployment.MinimumRequiredVersion == null) ||
                        (DeploymentManifest.Deployment.MinimumRequiredVersion < DeploymentManifest.CurrentPublishedVersion)
                    ))
                {
                    try
                    {
                        // Ensure an application manifest exists for the previous version!
                        // If it doesn't, we won't be able to start the previous version,
                        // and the application will crash if the user selects "update later."
                        if (LocalDeploymentManifest == null)
                            throw new ManifestException();
                        LocalDeploymentManifest.LoadApplicationManifest();

                        log.Debug("Update is optional; confirming update with user...");
                        doUpdate = UpdateNotifier.ConfirmDoUpdate();

                        if (doUpdate)
                            log.Debug("User accepted update.");
                        else log.Debug("User declined update.");
                    }
                    catch (ManifestException)
                    {
                        log.Warn("The application manifest is missing for the previous " +
                            "version of the application; update is starting automatically...");                        
                    }
                }

                if (doUpdate)
                {
                    log.Debug("Update is approved. Updating files...");

                    // Copy the previous version, if applicable
                    CopyPreviousVersion();

                    // Update files, if necessary
                    doUpdate = UpdateFiles();
                }

                if (UpdateNotifier != null)
                {
                    // End the update process with our notifier
                    UpdateNotifier.EndUpdate();
                }

                return doUpdate;
            }
            catch (Exception ex)
            {
                log.Error("Could not perform update.", ex);

                // Notify the update notifier of the exception
                if (UpdateNotifier != null)
                    UpdateNotifier.NotifyException(ex);
            }

            return false;
        }

        /// <summary>
        /// Cancels an update already in progress.
        /// </summary>
        public void Cancel()
        {
            CancelledOrError = true;
            if (_FileDownloaders != null)
            {
                foreach (FileDownloader fd in _FileDownloaders)
                    fd.Cancel();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Copies the previous version of the application
        /// to the current version.
        /// </summary>
        /// <exception cref="DeploymentManifestException">
        /// if the deployment manifest has not yet been loaded
        /// </exception>
        private void CopyPreviousVersion()
        {
            // If the local deployment manifest does not exists, then
            // silently return; the update process will download all files
            if (LocalDeploymentManifest == null)
                return;

            if (DeploymentManifest == null)
                throw new DeploymentManifestException();
           
            string previousVersionFolder = LocalDeploymentManifest.CurrentPublishedVersion.ToString();
            string destinationFolder = DeploymentManifest.CurrentPublishedVersion.ToString();

            // If the previous version exists, copy its contents to the destination folder!
            if (Directory.Exists(previousVersionFolder))
            {
                // Use the "Remove" configuration section to determine
                // the file patterns that should be removed from this version.
                List<string> patternsToExclude = new List<string>();
                DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                    as DDayUpdateConfigurationSection;
                if (cfg != null)
                {
                    foreach (KeyValuePairConfigurationElement kvpe in cfg.Remove)
                    {
                        if (!string.IsNullOrEmpty(kvpe.Value))
                            patternsToExclude.Add(kvpe.Value);
                    }
                }

                CopyDirectoryStructure(previousVersionFolder, string.Empty, destinationFolder, patternsToExclude.ToArray());
            }
        }

        /// <summary>
        /// Recursively copies the contents of one directory to another.
        /// </summary>
        private void CopyDirectoryStructure(string baseDir, string newDir, string destPath, string[] exclusions)
        {
            string destNewPath = Path.Combine(destPath, newDir);
            if (!Directory.Exists(destNewPath))
                Directory.CreateDirectory(destNewPath);            

            // Get a list of directories and/or files to copy
            string sourceDir = Path.Combine(baseDir, newDir);
            string[] dirs = Directory.GetDirectories(sourceDir);
            string[] files = Directory.GetFiles(sourceDir);

            // Determine which files should be excluded from the copy process
            List<string> excludedFiles = new List<string>();
            foreach(string pattern in exclusions)
            {
                string exclusionPath = Path.Combine(baseDir, Path.GetDirectoryName(pattern));
                string[] excludedFilepaths = Directory.GetFiles(exclusionPath, Path.GetFileName(pattern));
                foreach (string f in excludedFilepaths)
                    excludedFiles.Add(f);
            }

            foreach (string file in files)
            {
                // Only copy the file if it hasn't been excluded!
                if (!excludedFiles.Contains(file))
                {
                    string destFilepath = Path.Combine(destNewPath, Path.GetFileName(file));
                    if (!File.Exists(destFilepath))
                        File.Copy(file, destFilepath);
                }
            }

            foreach (string dir in dirs)
                CopyDirectoryStructure(baseDir, dir.Substring(baseDir.Length + 1), destPath, exclusions);
        }

        /// <summary>
        /// Downloads updated versions of each file that is outdated.
        /// </summary>
        /// <exception cref="DeploymentManifestException">
        /// if the deployment manifest has not yet been loaded
        /// </exception>
        private bool UpdateFiles()
        {
            // Ensure the deployment manifest has been loaded
            if (DeploymentManifest == null)
                throw new DeploymentManifestException();

            // First, load the application manifest from the deployment manifest
            DeploymentManifest.LoadApplicationManifest();

            // Start a list of file downloaders the will be obtained from
            // the application manifest.
            _FileDownloaders = new List<FileDownloader>();
            _Saved = new List<FileDownloader>();

            // Then, iterate through each downloadable file, determine if
            // an update is required for it, and download a new version
            // if necessary.
            foreach (IDownloadableFile file in
                DeploymentManifest.ApplicationManifest.DownloadableFiles)
            {
                FileDownloader download = file.GetDownloader();
                download.Completed += new EventHandler(download_Completed);
                download.Cancelled += new EventHandler(download_Cancelled);                
                download.Error += new EventHandler<ExceptionEventArgs>(download_Error);
                download.Saved += new EventHandler(download_Saved);

                log.Debug("Retrieved a downloader for '" + download.DestinationName + "'...");
                _FileDownloaders.Add(download);                
            }

            log.Debug("Determining total download size...");

            // Determine the file patterns that are preserved (never overwritten)
            // during the update process...
            List<string> preservedPatterns = new List<string>();
            DDayUpdateConfigurationSection cfg = ConfigurationManager.GetSection("DDay.Update")
                as DDayUpdateConfigurationSection;
            if (cfg != null)
            {
                foreach (KeyValuePairConfigurationElement kvpe in cfg.Preserve)
                {
                    if (!string.IsNullOrEmpty(kvpe.Value))
                        preservedPatterns.Add(kvpe.Value);
                }
            }

            // Determine the preserved status of each file downloader.
            // Preserved files will not be downloaded
            foreach (FileDownloader downloader in _FileDownloaders)
                downloader.DeterminePreservedStatus(preservedPatterns.ToArray());

            // Determine the total size in bytes of updates to be made
            long totalSize = 0;
            foreach (FileDownloader downloader in _FileDownloaders)
                totalSize += downloader.DownloadSize;

            log.Debug("Total download size is " + totalSize + " bytes; notifying GUI...");

            // Notify of the total update size in bytes
            if (UpdateNotifier != null)
                UpdateNotifier.NotifyTotalUpdateSize(totalSize);

            // Setup an event to synchronize with...
            _DownloadEvent = new AutoResetEvent(false);

            log.Debug("Downloading each file to be updated...");

            // Download each file
            foreach (FileDownloader downloader in _FileDownloaders)
            {
                if (!CancelledOrError)
                {
                    // Download the new copy of the file
                    downloader.Download(UpdateNotifier);

                    // Wait for the item to be downloaded
                    _DownloadEvent.WaitOne();
                }
                else break;
            }

            log.Info("File downloads finished.");
            return true;
        }

        #endregion

        #region Event Handlers

        void download_Error(object sender, ExceptionEventArgs e)
        {
            _DownloadEvent.Set();
            OnError(e.Exception);
        }

        void download_Cancelled(object sender, EventArgs e)
        {
            _DownloadEvent.Set();
            OnCancelled();
        }

        void download_Completed(object sender, EventArgs e)
        {
            _DownloadEvent.Set();

            FileDownloader fd = sender as FileDownloader;
            if (fd != null &&
                !CancelledOrError)
            {
                fd.Save();
            }
        }

        void download_Saved(object sender, EventArgs e)
        {
            FileDownloader fd = sender as FileDownloader;
            if (fd != null)
            {
                _Saved.Add(fd);
            }

            if (_Saved.Count.Equals(_FileDownloaders.Count))
                OnCompleted();
        }

        #endregion
    }
}
