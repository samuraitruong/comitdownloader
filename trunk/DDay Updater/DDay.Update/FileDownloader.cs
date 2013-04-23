using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Timers;

using DDay.Update.Utilities;

namespace DDay.Update
{
    public class FileDownloader
    {
        static private ILog log = new Log4NetLogger();

        #region Public Events

        public event EventHandler Completed;
        public event EventHandler<ExceptionEventArgs> Error;
        public event EventHandler Cancelled;
        public event EventHandler TimedOut;
        public event EventHandler Saved;

        #endregion

        #region Private Fields

        private WebClient _WebClient;
        private Uri _DownloadUri;
        private string _Username;
        private string _Password;
        private string _Domain;        
        private string _DestinationName;
        private string _DestinationFolder;
        private Version _CurrentVersion;        
        private long _Size;
        private string _Hash;        
        private byte[] _DownloadData;        
        private IUpdateNotifier _UpdateNotifier;
        private bool _IsCancelled = false;
        private bool _IsCompleted = false;        
        private object _LockObject = new object();
        Timer _Timer;
        private bool _IsPreserved = false;

        #endregion

        #region Public Properties

        public Uri DownloadUri
        {
            get { return _DownloadUri; }
            set { _DownloadUri = value; }
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }

        public string DestinationName
        {
            get { return _DestinationName; }
            set { _DestinationName = value; }
        }

        public string DestinationFolder
        {
            get { return _DestinationFolder; }
            set { _DestinationFolder = value; }
        }

        public Version CurrentVersion
        {
            get { return _CurrentVersion; }
            set { _CurrentVersion = value; }
        }

        public long Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }

        public long DownloadSize
        {
            get
            {
                if (RequiresDownload())
                    return Size;
                return 0;
            }
        }

        public byte[] DownloadData
        {
            get { return _DownloadData; }
            set { _DownloadData = value; }
        }

        public string DestinationPath
        {
            get { return Path.Combine(DestinationFolder, DestinationName); }
        }

        public bool IsCancelled
        {
            get { return _IsCancelled; }
            protected set { _IsCancelled = value; }
        }

        public bool IsCompleted
        {
            get { return _IsCompleted; }
            protected set { _IsCompleted = value; }
        }        

        #endregion

        #region Constructors

        public FileDownloader() { }

        public FileDownloader(
            Uri downloadUri,
            long size,
            string hash,
            string destFolder,            
            string destName,            
            Version currentVersion) : this()
        {
            DownloadUri = downloadUri;
            Size = size;
            Hash = hash;
            DestinationFolder = destFolder;            
            CurrentVersion = currentVersion;
            DestinationName = destName;
        }

        public FileDownloader(
            Uri downloadUri,
            long size,
            string hash,
            string destFolder,
            string destName,            
            Version currentVersion,            
            string username,
            string password,
            string domain)
            : this(downloadUri, size, hash, destFolder, destName, currentVersion)
        {
            Username = username;
            Password = password;
            Domain = domain;
        }

        #endregion

        #region Private Methods

        private bool RequiresDownload()
        {
            string filename = Path.GetFullPath(DestinationPath);
            if (File.Exists(DestinationPath))
            {
                if (_IsPreserved)
                {
                    log.Debug(DestinationName + ": File is preserved; no download required.");
                    return false;
                }

                if (CurrentVersion != null)
                {
                    FileVersionInfo fileVersion =
                        FileVersionInfo.GetVersionInfo(filename);

                    // Determine the version of the file
                    // NOTE: fixes bug #1862120 - Error: Version string portion was too short or too long
                    Version version = new Version(string.Format("{0}.{1}.{2}.{3}",
                        fileVersion.FileMajorPart, fileVersion.FileMinorPart,
                        fileVersion.FileBuildPart, fileVersion.FilePrivatePart));

                    if (version < CurrentVersion)
                    {
                        log.Debug(DestinationName + ": File version (" + version.ToString() + ") differs from server file version (" + CurrentVersion + ")");
                        return true;
                    }
                }

                if (Size != long.MinValue)
                {
                    FileInfo fileInfo = new FileInfo(filename);
                    if (fileInfo.Length != Size)
                    {
                        log.Debug(DestinationName + ": File size (" + fileInfo.Length + ") differs from server file size (" + Size + ")");
                        return true;
                    }
                }

                if (!String.IsNullOrEmpty(Hash))
                {
                    string hash = HashUtility.GetSHA1Hash(filename);
                    if (!hash.Equals(Hash))
                    {
                        log.Debug(DestinationName + ": File hash (" + hash + ") differs from server file hash (" + Hash + ")");
                        return true;
                    }
                }

                return false;
            }
            return true;
        }

        #endregion

        #region Protected Methods

        virtual protected void OnCompleted()
        {
            IsCompleted = true;

            if (Completed != null)
                Completed(this, EventArgs.Empty);
        }

        virtual protected void OnCancelled()
        {
            Cancel();

            if (_UpdateNotifier != null)
                _UpdateNotifier.OnCancelled(EventArgs.Empty);

            if (Cancelled != null)
                Cancelled(this, EventArgs.Empty);
        }

        virtual protected void OnError(Exception ex)
        {
            Cancel();

            if (_UpdateNotifier != null)
                _UpdateNotifier.OnError(new ExceptionEventArgs(ex));

            if (Error != null)
                Error(this, new ExceptionEventArgs(ex));
        }

        virtual protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }

        virtual protected void OnTimedOut()
        {
            log.Debug("Timeout reached for '" + DestinationName + "'");
            if (TimedOut != null)
                TimedOut(this, EventArgs.Empty);
        }

        #endregion

        #region Public Methods

        public bool Cancel()
        {
            if (_WebClient != null &&                
                !IsCancelled &&
                !IsCompleted // NOTE: fixes a bug where the download is cancelled after is completes downloading.
                )
            {
                log.Debug("Cancelling file download of '" + DestinationName + "'...");

                IsCancelled = true;
                if (_WebClient.IsBusy)
                    _WebClient.CancelAsync();

                return true;
            }
            return false;
        }

        public void Download(IUpdateNotifier updateNotifier)
        {
            lock (_LockObject)
            {
                _UpdateNotifier = updateNotifier;

                log.Debug("Determining if '" + DestinationName + "' requires downloading...");
                if (RequiresDownload())
                {
                    log.Info("Downloading '" + DestinationName + "'...");

                    // Setup a web client to download the latest
                    // version of this file
                    _WebClient = new WebClient();

                    if (Username != null &&
                        Password != null)
                        _WebClient.Credentials = new NetworkCredential(Username, Password, Domain);

                    _WebClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
                    _WebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);

                    // Notify that an update is about to begin!
                    if (_UpdateNotifier != null)
                        _UpdateNotifier.BeginFileDownload(DownloadUri, Size);

                    // Download the file!
                    _WebClient.DownloadDataAsync(DownloadUri);

                    // Start the timeout timer
                    StartTimer();
                }
                else
                {
                    log.Debug("No download required.");
                                        
                    // NOTE: partial fix for bug #2021741 - Application Hangs
                    // ======================================================                    
                    // Ensure our download data is null.
                    // Fixes a bug where the object is attempted to be saved,
                    // even though it doesn't need to be.
                    DownloadData = null;
                    
                    // Notify that the file has effectively finished downloading,
                    // and is saved
                    OnCompleted();
                    OnSaved();
                }
            }
        }

        public void Save()
        {
            lock (_LockObject)
            {
                log.Debug("Attempting to save '" + DestinationName + "'...");

                if (DownloadData != null &&
                    DownloadData.Length > 0)
                {
                    // Overwrite the previous version of the file, if the update hasn't been cancelled
                    if (!IsCancelled)
                    {
                        // Notify our UI that we're about to replace files
                        if (_UpdateNotifier != null)
                            _UpdateNotifier.BeginFileSave(DestinationPath);

                        try
                        {
                            // Determine if the directory exists at the destination path
                            // NOTE: fixes bug #1760479 - Directories not created for updated files
                            string directoryName = Path.GetDirectoryName(DestinationPath);
                            if (!string.IsNullOrEmpty(directoryName) &&
                                !Directory.Exists(directoryName))
                            {
                                // The directory does not exist; create it!
                                Directory.CreateDirectory(directoryName);
                            }

                            // Overwrite the previous version of the file!
                            FileStream fs = new FileStream(
                                DestinationPath,
                                FileMode.Create,
                                FileAccess.Write);
                            fs.Write(DownloadData, 0, DownloadData.Length);
                            fs.Close();

                            // Notify that we've completed replacing the file
                            if (_UpdateNotifier != null)
                                _UpdateNotifier.EndFileSave(DestinationPath);

                            OnSaved();
                        }
                        catch (Exception ex)
                        {
                            if (_UpdateNotifier != null)
                                _UpdateNotifier.OnError(new ExceptionEventArgs(ex));
                        }
                    }
                    else
                    {
                        log.Warn("'" + DestinationPath + "' could not be saved!");
                    }
                }
                else
                {
                    log.Info("Using '" + DestinationName + "' from previous version.");
                }
            }
        }

        public void DeterminePreservedStatus(string[] patterns)
        {
            _IsPreserved = false;
            try
            {
                if (Directory.Exists(DestinationFolder))
                {
                    foreach (string pattern in patterns)
                    {
                        string[] files = Directory.GetFiles(DestinationFolder, pattern);

                        // NOTE: fixes bug #2001859 - Preserve preserves all files
                        if (files.Length > 0)
                        {
                            foreach (string filepath in files)
                            {
                                if (filepath.Equals(DestinationPath, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    _IsPreserved = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Private Methods

        void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Cancel())
                OnTimedOut();

            StopTimer();
        }

        private void StartTimer()
        {
            StopTimer();

            if (_Timer == null)
            {
                _Timer = new Timer();
                _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
                _Timer.AutoReset = false;
                _Timer.Interval = 5000;                
            }
            _Timer.Enabled = true;
        }        

        private void StopTimer()
        {
            if (_Timer != null)
            {
                _Timer.Enabled = false;
            }
        }

        #endregion

        #region Event Handlers

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lock (_LockObject)
            {
                StartTimer();

                if (_UpdateNotifier != null)
                    _UpdateNotifier.OnProgressChanged(e);
            }
        }

        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            // NOTE: Fixes bug #2021741 - Application Hangs
            // =============================================
            // Ensure the timer is stopped whenever a download
            // is completed.
            lock (_LockObject)
            {
                StopTimer();
            }

            log.Info("Download of '" + DestinationName + "' completed.");
            if (e.Cancelled)
                OnCancelled();
            else if (e.Error != null)
                OnError(e.Error);
            else
            {
                DownloadData = e.Result;

                if (_UpdateNotifier != null)
                    _UpdateNotifier.EndFileDownload(DownloadUri, Size);

                OnCompleted();
            }
        }

        #endregion
    }
}
