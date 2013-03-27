namespace IView.UI.Forms
{
    partial class JpegSettings
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
            this.gbx_Quality = new System.Windows.Forms.GroupBox();
            this.lbl_ValueInfo = new System.Windows.Forms.Label();
            this.tbar_QualityValue = new System.Windows.Forms.TrackBar();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.hp_HelpInfo = new System.Windows.Forms.HelpProvider();
            this.ckb_PreserveData = new System.Windows.Forms.CheckBox();
            this.gbx_Quality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_QualityValue)).BeginInit();
            this.SuspendLayout();
            // 
            // gbx_Quality
            // 
            this.gbx_Quality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Quality.Controls.Add(this.lbl_ValueInfo);
            this.gbx_Quality.Controls.Add(this.tbar_QualityValue);
            this.gbx_Quality.Location = new System.Drawing.Point(12, 12);
            this.gbx_Quality.Name = "gbx_Quality";
            this.gbx_Quality.Size = new System.Drawing.Size(320, 89);
            this.gbx_Quality.TabIndex = 0;
            this.gbx_Quality.TabStop = false;
            this.gbx_Quality.Text = "Quality";
            // 
            // lbl_ValueInfo
            // 
            this.lbl_ValueInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ValueInfo.AutoSize = true;
            this.lbl_ValueInfo.Location = new System.Drawing.Point(256, 17);
            this.lbl_ValueInfo.Name = "lbl_ValueInfo";
            this.lbl_ValueInfo.Size = new System.Drawing.Size(46, 13);
            this.lbl_ValueInfo.TabIndex = 1;
            this.lbl_ValueInfo.Text = "Value: 0";
            // 
            // tbar_QualityValue
            // 
            this.tbar_QualityValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hp_HelpInfo.SetHelpString(this.tbar_QualityValue, "Specifies the quality used when saving. (Values range from 0 to 100)");
            this.tbar_QualityValue.Location = new System.Drawing.Point(6, 38);
            this.tbar_QualityValue.Maximum = 100;
            this.tbar_QualityValue.Name = "tbar_QualityValue";
            this.hp_HelpInfo.SetShowHelp(this.tbar_QualityValue, true);
            this.tbar_QualityValue.Size = new System.Drawing.Size(308, 45);
            this.tbar_QualityValue.TabIndex = 0;
            this.tbar_QualityValue.TickFrequency = 50;
            this.tbar_QualityValue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbar_QualityValue.ValueChanged += new System.EventHandler(this.tbar_QualityValue_ValueChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(176, 107);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 25);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "&OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(257, 107);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // ckb_PreserveData
            // 
            this.ckb_PreserveData.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.ckb_PreserveData, "Specifies whether to preserve any EXIF meta data contained in the current image.");
            this.ckb_PreserveData.Location = new System.Drawing.Point(12, 112);
            this.ckb_PreserveData.Name = "ckb_PreserveData";
            this.hp_HelpInfo.SetShowHelp(this.ckb_PreserveData, true);
            this.ckb_PreserveData.Size = new System.Drawing.Size(121, 17);
            this.ckb_PreserveData.TabIndex = 2;
            this.ckb_PreserveData.Text = "Preserve meta data";
            this.ckb_PreserveData.UseVisualStyleBackColor = true;
            // 
            // FormJpegSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 142);
            this.Controls.Add(this.ckb_PreserveData);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_Quality);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJpegSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JPEG Settings";
            this.gbx_Quality.ResumeLayout(false);
            this.gbx_Quality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_QualityValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Quality;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_ValueInfo;
        private System.Windows.Forms.TrackBar tbar_QualityValue;
        private System.Windows.Forms.HelpProvider hp_HelpInfo;
        private System.Windows.Forms.CheckBox ckb_PreserveData;
    }
}