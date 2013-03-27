namespace IView.UI.Forms
{
    partial class AboutBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.btn_ViewLicence = new System.Windows.Forms.Button();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_Author = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.picb_Banner = new System.Windows.Forms.PictureBox();
            this.tt_Info = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Banner)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ViewLicence
            // 
            this.btn_ViewLicence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ViewLicence.Location = new System.Drawing.Point(247, 160);
            this.btn_ViewLicence.Name = "btn_ViewLicence";
            this.btn_ViewLicence.Size = new System.Drawing.Size(85, 25);
            this.btn_ViewLicence.TabIndex = 0;
            this.btn_ViewLicence.Text = "&License";
            this.btn_ViewLicence.UseVisualStyleBackColor = true;
            this.btn_ViewLicence.Click += new System.EventHandler(this.btn_ViewLicence_Click);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Version.Location = new System.Drawing.Point(12, 103);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(81, 17);
            this.lbl_Version.TabIndex = 1;
            this.lbl_Version.Text = "Version: 2.0";
            // 
            // lbl_Author
            // 
            this.lbl_Author.AutoSize = true;
            this.lbl_Author.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Author.Location = new System.Drawing.Point(12, 120);
            this.lbl_Author.Name = "lbl_Author";
            this.lbl_Author.Size = new System.Drawing.Size(143, 17);
            this.lbl_Author.TabIndex = 2;
            this.lbl_Author.Text = "Author: Stephen Daily";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Email.Location = new System.Drawing.Point(12, 171);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(39, 17);
            this.lbl_Email.TabIndex = 5;
            this.lbl_Email.Text = "Email";
            this.tt_Info.SetToolTip(this.lbl_Email, "sdaily2004@hotmail.com");
            this.lbl_Email.Click += new System.EventHandler(this.lbl_Email_Click);
            // 
            // picb_Banner
            // 
            this.picb_Banner.BackColor = System.Drawing.Color.White;
            this.picb_Banner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picb_Banner.BackgroundImage")));
            this.picb_Banner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picb_Banner.Dock = System.Windows.Forms.DockStyle.Top;
            this.picb_Banner.Location = new System.Drawing.Point(0, 0);
            this.picb_Banner.Name = "picb_Banner";
            this.picb_Banner.Size = new System.Drawing.Size(344, 100);
            this.picb_Banner.TabIndex = 9;
            this.picb_Banner.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "License: GPL 2.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Copyright © 2011 Stephen Daily";
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(344, 197);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picb_Banner);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_Author);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.btn_ViewLicence);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.picb_Banner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ViewLicence;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label lbl_Author;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.PictureBox picb_Banner;
        private System.Windows.Forms.ToolTip tt_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}