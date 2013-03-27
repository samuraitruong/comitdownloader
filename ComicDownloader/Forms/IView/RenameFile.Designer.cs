namespace IView.UI.Forms
{
    partial class RenameFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameFile));
            this.txtb_FileName = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.pan_Error = new System.Windows.Forms.Panel();
            this.tt_Error = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtb_FileName
            // 
            this.txtb_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_FileName.Location = new System.Drawing.Point(12, 35);
            this.txtb_FileName.MaxLength = 256;
            this.txtb_FileName.Name = "txtb_FileName";
            this.txtb_FileName.Size = new System.Drawing.Size(290, 21);
            this.txtb_FileName.TabIndex = 0;
            this.txtb_FileName.TextChanged += new System.EventHandler(this.txtb_FileName_TextChanged);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Ok.Enabled = false;
            this.btn_Ok.Location = new System.Drawing.Point(146, 62);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 25);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "&OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(227, 62);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // pan_Error
            // 
            this.pan_Error.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_Error.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan_Error.BackgroundImage")));
            this.pan_Error.Location = new System.Drawing.Point(286, 13);
            this.pan_Error.Name = "pan_Error";
            this.pan_Error.Size = new System.Drawing.Size(16, 16);
            this.pan_Error.TabIndex = 4;
            this.pan_Error.Visible = false;
            // 
            // tt_Error
            // 
            this.tt_Error.AutoPopDelay = 5000;
            this.tt_Error.InitialDelay = 500;
            this.tt_Error.ReshowDelay = 3000;
            // 
            // FormRenameFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 97);
            this.Controls.Add(this.pan_Error);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.txtb_FileName);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRenameFile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_FileName;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Panel pan_Error;
        private System.Windows.Forms.ToolTip tt_Error;
    }
}