namespace IView.UI.Forms
{
    partial class ScreenShot
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
                if (m_oStringFormat != null)
                {
                    m_oStringFormat.Dispose();
                    m_oStringFormat = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenShot));
            this.cms_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_FitToScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Ruler = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_OpenCaptureFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_Main
            // 
            this.cms_Main.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Copy,
            this.tsmi_Save,
            this.tss_01,
            this.tsmi_FitToScreen,
            this.tsmi_Ruler,
            this.tss_02,
            this.tsmi_OpenCaptureFolder,
            this.tss_03,
            this.tsmi_Close});
            this.cms_Main.Name = "cms_Main";
            this.cms_Main.Size = new System.Drawing.Size(212, 154);
            this.cms_Main.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Main_Opening);
            // 
            // tsmi_Copy
            // 
            this.tsmi_Copy.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Copy.Image")));
            this.tsmi_Copy.Name = "tsmi_Copy";
            this.tsmi_Copy.ShortcutKeyDisplayString = "Ctrl+C";
            this.tsmi_Copy.Size = new System.Drawing.Size(211, 22);
            this.tsmi_Copy.Text = "Copy";
            this.tsmi_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
            // 
            // tsmi_Save
            // 
            this.tsmi_Save.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Save.Image")));
            this.tsmi_Save.Name = "tsmi_Save";
            this.tsmi_Save.ShortcutKeyDisplayString = "Ctrl+S";
            this.tsmi_Save.Size = new System.Drawing.Size(211, 22);
            this.tsmi_Save.Text = "Save";
            this.tsmi_Save.Click += new System.EventHandler(this.tsmi_Save_Click);
            // 
            // tss_01
            // 
            this.tss_01.Name = "tss_01";
            this.tss_01.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmi_FitToScreen
            // 
            this.tsmi_FitToScreen.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_FitToScreen.Image")));
            this.tsmi_FitToScreen.Name = "tsmi_FitToScreen";
            this.tsmi_FitToScreen.Size = new System.Drawing.Size(211, 22);
            this.tsmi_FitToScreen.Text = "Fit to Screen";
            this.tsmi_FitToScreen.Click += new System.EventHandler(this.tsmi_FitToScreen_Click);
            // 
            // tsmi_Ruler
            // 
            this.tsmi_Ruler.Name = "tsmi_Ruler";
            this.tsmi_Ruler.Size = new System.Drawing.Size(211, 22);
            this.tsmi_Ruler.Text = "Show Ruler";
            this.tsmi_Ruler.Click += new System.EventHandler(this.tsmi_Ruler_Click);
            // 
            // tss_02
            // 
            this.tss_02.Name = "tss_02";
            this.tss_02.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmi_OpenCaptureFolder
            // 
            this.tsmi_OpenCaptureFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_OpenCaptureFolder.Image")));
            this.tsmi_OpenCaptureFolder.Name = "tsmi_OpenCaptureFolder";
            this.tsmi_OpenCaptureFolder.Size = new System.Drawing.Size(211, 22);
            this.tsmi_OpenCaptureFolder.Text = "Open Screen Capture Folder";
            this.tsmi_OpenCaptureFolder.Click += new System.EventHandler(this.tsmi_OpenCaptureFolder_Click);
            // 
            // tss_03
            // 
            this.tss_03.Name = "tss_03";
            this.tss_03.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmi_Close
            // 
            this.tsmi_Close.Name = "tsmi_Close";
            this.tsmi_Close.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmi_Close.Size = new System.Drawing.Size(211, 22);
            this.tsmi_Close.Text = "Close";
            this.tsmi_Close.Click += new System.EventHandler(this.tsmi_Close_Click);
            // 
            // FormScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.ContextMenuStrip = this.cms_Main;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(16, 17);
            this.Name = "FormScreenShot";
            this.Opacity = 0.6D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Capture Tool";
            this.cms_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Ruler;
        private System.Windows.Forms.ToolStripSeparator tss_02;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Close;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save;
        private System.Windows.Forms.ToolStripSeparator tss_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_FitToScreen;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenCaptureFolder;
        private System.Windows.Forms.ToolStripSeparator tss_03;


    }
}