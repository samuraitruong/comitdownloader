namespace ComicDownloader.Forms
{
    partial class DownloaderSettingForm
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkIECookie = new MetroFramework.Controls.MetroCheckBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.toggleClipboard = new MetroFramework.Controls.MetroToggle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(66, 232);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(131, 45);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Update";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(225, 232);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(152, 45);
            this.metroButton2.TabIndex = 1;
            this.metroButton2.Text = "Cancel";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(21, 82);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "User Name";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 121);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(63, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Password";
            // 
            // chkIECookie
            // 
            this.chkIECookie.AutoSize = true;
            this.chkIECookie.Location = new System.Drawing.Point(23, 164);
            this.chkIECookie.Name = "chkIECookie";
            this.chkIECookie.Size = new System.Drawing.Size(177, 15);
            this.chkIECookie.TabIndex = 4;
            this.chkIECookie.Text = "User Internet Explorer Session";
            this.chkIECookie.UseVisualStyleBackColor = true;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.ForeColor = System.Drawing.SystemColors.Control;
            this.metroTile1.Location = new System.Drawing.Point(338, 82);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(75, 75);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile1.TabIndex = 5;
            this.metroTile1.TileImage = global::ComicDownloader.Properties.Resources._1454338876_18;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // toggleClipboard
            // 
            this.toggleClipboard.AutoSize = true;
            this.toggleClipboard.Checked = true;
            this.toggleClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleClipboard.Location = new System.Drawing.Point(220, 195);
            this.toggleClipboard.Name = "toggleClipboard";
            this.toggleClipboard.Size = new System.Drawing.Size(80, 17);
            this.toggleClipboard.TabIndex = 6;
            this.toggleClipboard.Text = "~StatusOn";
            this.toggleClipboard.UseVisualStyleBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(21, 193);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(137, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Clipboard monitoring";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(115, 82);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(185, 20);
            this.txtUserName.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 121);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(185, 20);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.Text = "metroTextBox2";
            // 
            // DownloaderSettingForm
            // 
            this.AcceptButton = this.metroButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 300);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.toggleClipboard);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.chkIECookie);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloaderSettingForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Setting";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox chkIECookie;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroToggle toggleClipboard;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
    }
}