using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace DDay.Update.WinForms
{
    public partial class FileUpdateForm : Form
    {
        #region Delegates

        public delegate void UpdateProgressDelegate(DownloadProgressChangedEventArgs e);
        public delegate void StringDelegate(string txt);

        #endregion

        #region Private Fields

        private DeploymentManifest _DeploymentManifest;
        private long _TotalUpdateSize;
        private long _CompletedUpdateSize;
        private DateTime _StartTime = DateTime.Now;        

        #endregion

        #region Public Properties

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set
            {
                _DeploymentManifest = value;
                if (DeploymentManifest != null)
                {
                    if (DeploymentManifest.Description != null)
                    {
                        Text = " Updating " + DeploymentManifest.Description.Product + "...";
                    }
                    else
                    {
                        Text = " Updating...";
                    }
                }
            }
        }

        public long TotalUpdateSize
        {
            get { return _TotalUpdateSize; }
            set { _TotalUpdateSize = value; }
        }

        public long CompletedUpdateSize
        {
            get { return _CompletedUpdateSize; }
            set { _CompletedUpdateSize = value; }
        }

        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }        

        #endregion

        #region Constructors

        public FileUpdateForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void UpdateProgress(DownloadProgressChangedEventArgs e)
        {
            if (progressBar.InvokeRequired)
            {
                UpdateProgressDelegate _delegate = new UpdateProgressDelegate(UpdateProgress);
                progressBar.Invoke(_delegate, new object[] { e });
            }
            else
            {
                double mult = 1.0;
                if (TotalUpdateSize > int.MaxValue)
                    mult = (double)int.MaxValue / TotalUpdateSize;

                progressBar.Minimum = 0;
                progressBar.Maximum = (int)(TotalUpdateSize * mult);
                
                // Set the current value.  In certain circumstances, this value may
                // become invalid, so we need to test it first.
                // NOTE: Fixes bug #1770765 - Status Bar Exception
                int currValue = (int)((CompletedUpdateSize + e.BytesReceived) * mult);
                if (currValue >= progressBar.Minimum &&
                    currValue <= progressBar.Maximum)
                    progressBar.Value = currValue;

                TimeSpan ts = (DateTime.Now - StartTime);
                                
                lblBytes.Text = 
                    DownloadedBytesStringConverter.Convert(CompletedUpdateSize + e.BytesReceived, TotalUpdateSize) + 
                    " out of " + 
                    DownloadedBytesStringConverter.Convert(TotalUpdateSize) +
                    " downloaded (" + 
                    DownloadedBytesStringConverter.Convert(
                        (CompletedUpdateSize + e.BytesReceived) / ts.TotalSeconds,
                        "0.0") +
                    "/sec)";
            }
        }

        public void SetTitleText(string txt)
        {
            if (lblTitle.InvokeRequired)
            {
                StringDelegate _delegate = new StringDelegate(SetTitleText);
                lblTitle.Invoke(_delegate, new object[] { txt });
            }
            else
            {
                lblTitle.Text = txt;
            }
        }

        public new void Close()
        {
            if (this.InvokeRequired)
                this.Invoke(new ThreadStart(Close));
            else
                base.Close();
        }

        #endregion        
    }
}
