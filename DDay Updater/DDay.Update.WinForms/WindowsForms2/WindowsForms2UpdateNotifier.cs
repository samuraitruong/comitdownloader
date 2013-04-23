using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Net;

namespace DDay.Update.WinForms
{
    [DescriptionAttribute("Windows Forms (.NET 2.0)")]
    public class WindowsForms2UpdateNotifier : IUpdateNotifier
    {
        #region Private Fields

        private DeploymentManifest _DeploymentManifest;
        private long _TotalUpdateSize;
        private FileUpdateForm _FileUpdateForm = null;
        private object _Lock = new object();

        #endregion

        #region Public Properties

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set
            {
                _DeploymentManifest = value;
                if (_FileUpdateForm != null)
                    _FileUpdateForm.DeploymentManifest = _DeploymentManifest;
            }
        }

        public long TotalUpdateSize
        {
            get { return _TotalUpdateSize; }
            set
            {
                _TotalUpdateSize = value;
                if (_FileUpdateForm != null)
                    _FileUpdateForm.TotalUpdateSize = _TotalUpdateSize;
            }
        }

        #endregion

        #region Private Methods

        private void EnsureFormWindowCreated()
        {
            lock (_Lock)
            {
                if (_FileUpdateForm == null)
                {
                    AutoResetEvent wait = new AutoResetEvent(false);

                    ThreadStart threadStart =
                        delegate
                        {
                            _FileUpdateForm = new FileUpdateForm();

                            // NOTE: Patch #2007811 - fix attached.
                            // Force creation of a handle for the form, so we can access it before it
                            // is displayed.  This fixes the exception - System.InvalidOperationException:
                            // Invoke or BeginInvoke cannot be called on a control until the window handle
                            // has been created.
                            //
                            // Thanks to DethKnite for the patch.
                            IntPtr handle = _FileUpdateForm.Handle;

                            _FileUpdateForm.DeploymentManifest = DeploymentManifest;
                            _FileUpdateForm.TotalUpdateSize = TotalUpdateSize;

                            wait.Set();

                            Application.Run(_FileUpdateForm);
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
            if (_FileUpdateForm != null)
            {
                _FileUpdateForm.SetTitleText("Completed.");
                _FileUpdateForm.Close();
            }
        }

        #endregion

        #region IUpdateNotifier Members

        public event EventHandler<DownloadProgressChangedEventArgs> ProgressChanged;
        public event EventHandler<EventArgs> Cancelled;
        public event EventHandler<ExceptionEventArgs> Error;

        public void BeginVersionCheck()
        {
            EnsureFormWindowCreated();
            if (_FileUpdateForm != null)
                _FileUpdateForm.SetTitleText("Checking for updates...");
        }

        public void EndVersionCheck(bool updatePending)
        {
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
                    ConfirmDoUpdateForm doUpdate = new ConfirmDoUpdateForm(DeploymentManifest);                    
                    retVal = doUpdate.ShowDialog() == DialogResult.OK;

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
            EnsureFormWindowCreated();
        }

        public void EndFileDownload(Uri downloadUri, long size)
        {
            if (_FileUpdateForm != null)
                _FileUpdateForm.CompletedUpdateSize += size;
        }

        public void BeginFileSave(string filePath)
        {
            if (_FileUpdateForm != null)
                _FileUpdateForm.SetTitleText("Updating files...");
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

            if (_FileUpdateForm != null)
                _FileUpdateForm.UpdateProgress(args);
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
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #endregion
    }
}
