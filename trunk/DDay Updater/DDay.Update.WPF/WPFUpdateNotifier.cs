using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.IO;
using System.Windows.Threading;

namespace DDay.Update.WPF
{
    [DescriptionAttribute("Windows Presentation Foundation (.NET 3.0)")]
    public class WPFUpdateNotifier : IUpdateNotifier
    {
        #region Private Fields

        private DeploymentManifest _DeploymentManifest;
        private long _TotalUpdateSize;
        private FileUpdateWindow _FileUpdateWindow = null;
        private object _Lock = new object();

        #endregion

        #region Public Properties

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set
            {
                _DeploymentManifest = value;
                if (_FileUpdateWindow != null)
                    _FileUpdateWindow.DeploymentManifest = _DeploymentManifest;
            }
        }

        public long TotalUpdateSize
        {
            get { return _TotalUpdateSize; }
            set
            {
                _TotalUpdateSize = value;
                if (_FileUpdateWindow != null)
                    _FileUpdateWindow.TotalUpdateSize = _TotalUpdateSize;
            }
        }

        #endregion

        #region Private Methods

        private void EnsureFileUpdateWindow()
        {
            lock (_Lock)
            {
                if (_FileUpdateWindow == null)
                {
                    AutoResetEvent wait = new AutoResetEvent(false);

                    ThreadStart threadStart =
                        delegate
                        {
                            _FileUpdateWindow = new FileUpdateWindow();
                            _FileUpdateWindow.DeploymentManifest = DeploymentManifest;
                            _FileUpdateWindow.TotalUpdateSize = TotalUpdateSize;
                            wait.Set();

                            _FileUpdateWindow.Show();
                            _FileUpdateWindow.SlideUp();

                            Application app = new Application();
                            app.Run(_FileUpdateWindow);
                        };
                    Thread thread = new Thread(threadStart);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();

                    wait.WaitOne();
                }
            }
        }

        private void Complete()
        {
            if (_FileUpdateWindow != null)
            {
                _FileUpdateWindow.SetCurrentItem(string.Empty);
                _FileUpdateWindow.SetTitleText("Completed.");
                _FileUpdateWindow.SlideDown();
            }
        }

        #endregion

        #region IUpdateNotifier Members

        public event EventHandler<DownloadProgressChangedEventArgs> ProgressChanged;
        public event EventHandler<EventArgs> Cancelled;
        public event EventHandler<ExceptionEventArgs> Error;

        public void BeginVersionCheck()
        {
            EnsureFileUpdateWindow();
            if (_FileUpdateWindow != null)
            {
                _FileUpdateWindow.SetTitleText("Checking for updates...");
                _FileUpdateWindow.SetParagraphText("Checking for updated versions...");
                _FileUpdateWindow.SetProgressBarMode(true);
            }
        }

        public void EndVersionCheck(bool updatePending)
        {
            if (_FileUpdateWindow != null)
            {
                _FileUpdateWindow.SetProgressBarMode(false);
            }

            if (!updatePending)
                Complete();
        }

        public void BeginUpdate(DeploymentManifest manifest)
        {
            DeploymentManifest = manifest;
        }

        public void EndUpdate()
        {
            Complete();
        }

        public bool ConfirmDoUpdate()
        {
            AutoResetEvent wait = new AutoResetEvent(false);
            bool retVal = false;

            ThreadStart threadStart =
                delegate
                {
                    ConfirmDoUpdateWindow doUpdate = new ConfirmDoUpdateWindow(DeploymentManifest);
                    retVal = doUpdate.ShowDialog() == true;

                    wait.Set();
                };
            Thread thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            wait.WaitOne();

            return retVal;
        }

        public void BeginFileDownload(Uri downloadUri, long size)
        {
            EnsureFileUpdateWindow();
            if (_FileUpdateWindow != null)
            {
                string filename = Path.GetFileName(downloadUri.LocalPath);
                if (Path.GetExtension(filename).Equals(".deploy", StringComparison.CurrentCultureIgnoreCase))
                    filename = Path.GetFileNameWithoutExtension(filename);
                
                _FileUpdateWindow.SetCurrentItem(filename);
            }
        }

        public void EndFileDownload(Uri downloadUri, long size)
        {
            if (_FileUpdateWindow != null)
                _FileUpdateWindow.CompletedUpdateSize += size;
        }

        public void BeginFileSave(string filePath)
        {
            if (_FileUpdateWindow != null)
                _FileUpdateWindow.SetTitleText("Updating files...");
        }

        public void EndFileSave(string filePath)
        {
        }

        public void NotifyTotalUpdateSize(long size)
        {
            TotalUpdateSize = size;            
        }

        public void NotifyException(Exception ex)
        {
            MessageBox.Show(ex.Message, "An Error Occurred");
        }

        public void OnProgressChanged(DownloadProgressChangedEventArgs args)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, args);

            if (_FileUpdateWindow != null)
                _FileUpdateWindow.UpdateProgress(args);
        }

        public void OnCancelled(EventArgs args)
        {
            if (Cancelled != null)
                Cancelled(this, args);
        }

        public void OnError(ExceptionEventArgs args)
        {
            if (Error != null)
                Error(this, args);

            MessageBox.Show(
                "An error occurred while updating the application:" +
                Environment.NewLine + Environment.NewLine +
                args.Exception.Message,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        #endregion
    }
}
