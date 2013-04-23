using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

using DDay.Update;
using System.Threading;
using System.Windows.Threading;

namespace DDay
{
    public partial class FileUpdateWindow
    {
        #region Delegates

        public delegate void UpdateProgressDelegate(DownloadProgressChangedEventArgs e);
        public delegate void StringDelegate(string txt);
        public delegate void BoolDelegate(bool val);

        #endregion

        #region Private Fields

        private DeploymentManifest _DeploymentManifest;
        private long _TotalUpdateSize;
        private long _CompletedUpdateSize;
        private DateTime _StartTime = DateTime.Now;
        private Storyboard _SlideUp;
        private Storyboard _SlideDown;

        #endregion

        #region Public Properties

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set { _DeploymentManifest = value; }
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

        public FileUpdateWindow()
        {
            this.InitializeComponent();

            _SlideUp = FindResource("SlideUp") as Storyboard;
            _SlideDown = FindResource("SlideDown") as Storyboard;
            _SlideDown.CurrentStateInvalidated += new EventHandler(_SlideDown_CurrentStateInvalidated);
        }

        #endregion

        #region Protected Methods

        protected void PositionWindow()
        {
            // FIXME: make this more flexible
            Rect workArea = SystemParameters.WorkArea;

            Top = workArea.Top;
            Left = workArea.Left;
            Width = workArea.Width;
            Height = workArea.Height;
        }

        #endregion

        #region Public Methods

        public void SlideUp()
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
                Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(SlideUp));
            else
            {
                PositionWindow();
                _SlideUp.Begin(LayoutRoot, true);
            }
        }

        public void SlideDown()
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
                Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(SlideDown));
            else
                _SlideDown.Begin(LayoutRoot, true);
        }

        public void UpdateProgress(DownloadProgressChangedEventArgs e)
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
            {
                UpdateProgressDelegate _delegate = new UpdateProgressDelegate(UpdateProgress);
                Dispatcher.Invoke(DispatcherPriority.Normal, _delegate, e);
            }
            else
            {
                double mult = 1.0;
                if (TotalUpdateSize > int.MaxValue)
                    mult = (double)int.MaxValue / TotalUpdateSize;
                                
                progressBar.Minimum = 0;
                progressBar.Maximum = (TotalUpdateSize * mult);
                
                // Set the current value.  In certain circumstances, this value may
                // become invalid, so we need to test it first.
                // NOTE: Fixes bug #1770765 - Status Bar Exception
                double currValue = (CompletedUpdateSize + e.BytesReceived) * mult;
                if (currValue >= progressBar.Minimum &&
                    currValue <= progressBar.Maximum)
                    progressBar.Value = currValue;

                TimeSpan ts = (DateTime.Now - StartTime);
                                
                SetParagraphText(
                    DownloadedBytesStringConverter.Convert(CompletedUpdateSize + e.BytesReceived, TotalUpdateSize) + 
                    " out of " + 
                    DownloadedBytesStringConverter.Convert(TotalUpdateSize) +
                    " downloaded");
                
                lblSpeed.Text = DownloadedBytesStringConverter.Convert(
                    (CompletedUpdateSize + e.BytesReceived) / ts.TotalSeconds,
                    "0.0") + "/sec";
            }
        }

        public void SetParagraphText(string txt)
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
            {
                StringDelegate _delegate = new StringDelegate(SetParagraphText);
                Dispatcher.Invoke(DispatcherPriority.Normal, _delegate, txt);
            }
            else
            {
                lblDownloadProgress.Content = txt;
            }            
        }

        public void SetTitleText(string txt)
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
            {
                StringDelegate _delegate = new StringDelegate(SetTitleText);
                Dispatcher.Invoke(DispatcherPriority.Normal, _delegate, txt);
            }
            else
            {
                lblStatus.Content = txt;
            }
        }

        public void SetCurrentItem(string txt)
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
            {
                StringDelegate _delegate = new StringDelegate(SetCurrentItem);
                Dispatcher.Invoke(DispatcherPriority.Normal, _delegate, txt);
            }
            else
            {
                lblCurrentItem.Text = txt;
            }
        }

        public void SetProgressBarMode(bool isIndeterminate)
        {
            if (Thread.CurrentThread != Dispatcher.Thread)
            {
                BoolDelegate _delegate = new BoolDelegate(SetProgressBarMode);
                Dispatcher.Invoke(DispatcherPriority.Normal, _delegate, isIndeterminate);
            }
            else
            {
                progressBar.IsIndeterminate = isIndeterminate;                
            }
        }

        #endregion        

        #region Event Handlers

        void _SlideDown_CurrentStateInvalidated(object sender, EventArgs e)
        {
            // Close the window after it is finished sliding out
            if (_SlideDown.GetCurrentState(LayoutRoot) != ClockState.Active)
                Close();
        }

        #endregion
    }
}