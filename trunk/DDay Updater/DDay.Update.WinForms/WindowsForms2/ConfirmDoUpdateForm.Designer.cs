namespace DDay.Update.WinForms
{
    partial class ConfirmDoUpdateForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProgramTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMostRecentVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNow = new System.Windows.Forms.Button();
            this.btnLater = new System.Windows.Forms.Button();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.MinimumSize = new System.Drawing.Size(170, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProgramTitle
            // 
            this.lblProgramTitle.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblProgramTitle.Location = new System.Drawing.Point(12, 28);
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.Size = new System.Drawing.Size(313, 27);
            this.lblProgramTitle.TabIndex = 1;
            this.lblProgramTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 83);
            this.label1.MinimumSize = new System.Drawing.Size(170, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "The most recent version is:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMostRecentVersion
            // 
            this.lblMostRecentVersion.AutoSize = true;
            this.lblMostRecentVersion.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostRecentVersion.Location = new System.Drawing.Point(192, 84);
            this.lblMostRecentVersion.Name = "lblMostRecentVersion";
            this.lblMostRecentVersion.Size = new System.Drawing.Size(0, 15);
            this.lblMostRecentVersion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Would you like to upgrade now or later?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNow
            // 
            this.btnNow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNow.Location = new System.Drawing.Point(171, 133);
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(108, 23);
            this.btnNow.TabIndex = 5;
            this.btnNow.Text = "Upgrade &Now";
            this.btnNow.UseVisualStyleBackColor = true;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // btnLater
            // 
            this.btnLater.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLater.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLater.Location = new System.Drawing.Point(57, 133);
            this.btnLater.Name = "btnLater";
            this.btnLater.Size = new System.Drawing.Size(108, 23);
            this.btnLater.TabIndex = 6;
            this.btnLater.Text = "Upgrade &Later";
            this.btnLater.UseVisualStyleBackColor = true;
            this.btnLater.Click += new System.EventHandler(this.btnLater_Click);
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentVersion.Location = new System.Drawing.Point(191, 63);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(0, 15);
            this.lblCurrentVersion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.MinimumSize = new System.Drawing.Size(170, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Your current version is:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConfirmDoUpdateForm
            // 
            this.AcceptButton = this.btnNow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnLater;
            this.ClientSize = new System.Drawing.Size(337, 168);
            this.Controls.Add(this.lblCurrentVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLater);
            this.Controls.Add(this.btnNow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMostRecentVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProgramTitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfirmDoUpdateForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " An Update Is Available";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProgramTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMostRecentVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.Button btnLater;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Label label4;
    }
}