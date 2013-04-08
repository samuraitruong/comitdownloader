namespace ComicDownloader.Forms
{
    partial class StartServerForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bntBrowse = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.bntStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 92);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(110, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://127.0.0.1:9999";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // bntBrowse
            // 
            this.bntBrowse.Location = new System.Drawing.Point(261, 10);
            this.bntBrowse.Name = "bntBrowse";
            this.bntBrowse.Size = new System.Drawing.Size(28, 23);
            this.bntBrowse.TabIndex = 3;
            this.bntBrowse.Text = "...";
            this.bntBrowse.UseVisualStyleBackColor = true;
            this.bntBrowse.Click += new System.EventHandler(this.bntBrowse_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(13, 13);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(242, 20);
            this.txtDir.TabIndex = 2;
            this.txtDir.Text = "C:\\Users\\Administrator\\Desktop";
            // 
            // bntStart
            // 
            this.bntStart.Location = new System.Drawing.Point(295, 11);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(56, 23);
            this.bntStart.TabIndex = 0;
            this.bntStart.Text = "Start";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // StartServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 200);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.bntBrowse);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.bntStart);
            this.Name = "StartServerForm";
            this.Text = "StartServerForm";
            this.Load += new System.EventHandler(this.StartServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button bntBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel linkLabel1;

    }
}