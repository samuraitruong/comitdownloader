using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace DDay.Update
{
    public interface IUpdateNotifier
    {
        event EventHandler<DownloadProgressChangedEventArgs> ProgressChanged;
        event EventHandler<EventArgs> Cancelled;
        event EventHandler<ExceptionEventArgs> Error;

        void BeginVersionCheck();
        void EndVersionCheck(bool updatePending);
        void BeginUpdate(DeploymentManifest manifest);
        void EndUpdate();
        bool ConfirmDoUpdate();
        void BeginFileDownload(Uri downloadUri, long size);
        void EndFileDownload(Uri downloadUri, long size);
        void BeginFileSave(string filePath);
        void EndFileSave(string filePath);
        void NotifyTotalUpdateSize(long size);
        void NotifyException(Exception ex);
        void OnProgressChanged(DownloadProgressChangedEventArgs args);
        void OnCancelled(EventArgs args);
        void OnError(ExceptionEventArgs args);
    }

    #region ExceptionEventArgs class

    public class ExceptionEventArgs : EventArgs
    {
        private Exception _Exception;

        public Exception Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }

        public ExceptionEventArgs(Exception ex)
        {
            Exception = ex;
        }
    }

    #endregion
}
