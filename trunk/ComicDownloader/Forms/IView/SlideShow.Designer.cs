namespace IView.UI.Forms
{
    partial class SlideShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_oBlankCursor != null)
                {
                    m_oBlankCursor.Dispose();
                    m_oBlankCursor = null;
                }
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlideShow));
            this.tim_SlideShowTimer = new System.Windows.Forms.Timer(this.components);
            this.cms_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_PlayPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Previous = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_NormalTransition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_FadeTransition = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // tim_SlideShowTimer
            // 
            this.tim_SlideShowTimer.Interval = 10;
            this.tim_SlideShowTimer.Tick += new System.EventHandler(this.tim_SlideShowTimer_Tick);
            // 
            // cms_Options
            // 
            this.cms_Options.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_PlayPause,
            this.tss_01,
            this.tsmi_Next,
            this.tsmi_Previous,
            this.tss_02,
            this.tsmi_NormalTransition,
            this.tsmi_FadeTransition,
            this.tss_03,
            this.tsmi_Close});
            this.cms_Options.Name = "cms_Options";
            this.cms_Options.Size = new System.Drawing.Size(158, 154);
            this.cms_Options.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cms_Options_Closing);
            this.cms_Options.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Options_Opening);
            // 
            // tsmi_PlayPause
            // 
            this.tsmi_PlayPause.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_PlayPause.Image")));
            this.tsmi_PlayPause.Name = "tsmi_PlayPause";
            this.tsmi_PlayPause.Size = new System.Drawing.Size(157, 22);
            this.tsmi_PlayPause.Text = "Play";
            this.tsmi_PlayPause.Click += new System.EventHandler(this.tsmi_PlayPause_Click);
            // 
            // tss_01
            // 
            this.tss_01.Name = "tss_01";
            this.tss_01.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmi_Next
            // 
            this.tsmi_Next.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Next.Image")));
            this.tsmi_Next.Name = "tsmi_Next";
            this.tsmi_Next.Size = new System.Drawing.Size(157, 22);
            this.tsmi_Next.Text = "Next";
            this.tsmi_Next.Click += new System.EventHandler(this.tsmi_Next_Click);
            // 
            // tsmi_Previous
            // 
            this.tsmi_Previous.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Previous.Image")));
            this.tsmi_Previous.Name = "tsmi_Previous";
            this.tsmi_Previous.Size = new System.Drawing.Size(157, 22);
            this.tsmi_Previous.Text = "Previous";
            this.tsmi_Previous.Click += new System.EventHandler(this.tsmi_Previous_Click);
            // 
            // tss_02
            // 
            this.tss_02.Name = "tss_02";
            this.tss_02.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmi_NormalTransition
            // 
            this.tsmi_NormalTransition.Name = "tsmi_NormalTransition";
            this.tsmi_NormalTransition.Size = new System.Drawing.Size(157, 22);
            this.tsmi_NormalTransition.Text = "Normal Transition";
            this.tsmi_NormalTransition.Click += new System.EventHandler(this.tsmi_NormalTransition_Click);
            // 
            // tsmi_FadeTransition
            // 
            this.tsmi_FadeTransition.Name = "tsmi_FadeTransition";
            this.tsmi_FadeTransition.Size = new System.Drawing.Size(157, 22);
            this.tsmi_FadeTransition.Text = "Fade Transition";
            this.tsmi_FadeTransition.Click += new System.EventHandler(this.tsmi_FadeTransition_Click);
            // 
            // tss_03
            // 
            this.tss_03.Name = "tss_03";
            this.tss_03.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmi_Close
            // 
            this.tsmi_Close.Name = "tsmi_Close";
            this.tsmi_Close.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmi_Close.Size = new System.Drawing.Size(157, 22);
            this.tsmi_Close.Text = "&Close";
            this.tsmi_Close.Click += new System.EventHandler(this.tsmi_Close_Click);
            // 
            // SlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SlideShow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "iView.NET Slide Show";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SlideShow_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SlideShow_PreviewKeyDown);
            this.cms_Options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tim_SlideShowTimer;
        private System.Windows.Forms.ContextMenuStrip cms_Options;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Close;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NormalTransition;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PlayPause;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Next;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Previous;
        private System.Windows.Forms.ToolStripSeparator tss_01;
        private System.Windows.Forms.ToolStripSeparator tss_02;
        private System.Windows.Forms.ToolStripSeparator tss_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_FadeTransition;
    }
}