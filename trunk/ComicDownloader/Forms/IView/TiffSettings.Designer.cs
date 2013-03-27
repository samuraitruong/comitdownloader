namespace IView.UI.Forms
{
    partial class TiffSettings
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
            this.gbx_ColourDepth = new System.Windows.Forms.GroupBox();
            this.rbtn_24Bits = new System.Windows.Forms.RadioButton();
            this.rbtn_32Bits = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_CompressionRle = new System.Windows.Forms.RadioButton();
            this.rbtn_CompressionLZW = new System.Windows.Forms.RadioButton();
            this.rbtn_CompressionCCITT4 = new System.Windows.Forms.RadioButton();
            this.rbtn_CompressionCCITT3 = new System.Windows.Forms.RadioButton();
            this.rbtn_CompressionNone = new System.Windows.Forms.RadioButton();
            this.hp_HelpInfo = new System.Windows.Forms.HelpProvider();
            this.ckb_PreserveData = new System.Windows.Forms.CheckBox();
            this.gbx_ColourDepth.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_ColourDepth
            // 
            this.gbx_ColourDepth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_ColourDepth.Controls.Add(this.rbtn_24Bits);
            this.gbx_ColourDepth.Controls.Add(this.rbtn_32Bits);
            this.gbx_ColourDepth.Location = new System.Drawing.Point(12, 12);
            this.gbx_ColourDepth.Name = "gbx_ColourDepth";
            this.gbx_ColourDepth.Size = new System.Drawing.Size(320, 75);
            this.gbx_ColourDepth.TabIndex = 0;
            this.gbx_ColourDepth.TabStop = false;
            this.gbx_ColourDepth.Text = "Colour Depth";
            // 
            // rbtn_24Bits
            // 
            this.rbtn_24Bits.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_24Bits, "Specifies that the colour depth used will be 24 bit and consist of 3 channels (Re" +
                    "d, Green, Blue) at 8 bits per channel.");
            this.rbtn_24Bits.Location = new System.Drawing.Point(6, 43);
            this.rbtn_24Bits.Name = "rbtn_24Bits";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_24Bits, true);
            this.rbtn_24Bits.Size = new System.Drawing.Size(107, 17);
            this.rbtn_24Bits.TabIndex = 1;
            this.rbtn_24Bits.Text = "24 bit - R8 G8 B8";
            this.rbtn_24Bits.UseVisualStyleBackColor = true;
            // 
            // rbtn_32Bits
            // 
            this.rbtn_32Bits.AutoSize = true;
            this.rbtn_32Bits.Checked = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_32Bits, "Specifies that the colour depth used will be 32 bit and consist of 4 channels (Al" +
                    "pha, Red, Green, Blue) at 8 bits per channel.");
            this.rbtn_32Bits.Location = new System.Drawing.Point(6, 20);
            this.rbtn_32Bits.Name = "rbtn_32Bits";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_32Bits, true);
            this.rbtn_32Bits.Size = new System.Drawing.Size(123, 17);
            this.rbtn_32Bits.TabIndex = 0;
            this.rbtn_32Bits.TabStop = true;
            this.rbtn_32Bits.Text = "32 bit - A8 R8 G8 B8";
            this.rbtn_32Bits.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(257, 242);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(176, 242);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 25);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "&OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbtn_CompressionRle);
            this.groupBox2.Controls.Add(this.rbtn_CompressionLZW);
            this.groupBox2.Controls.Add(this.rbtn_CompressionCCITT4);
            this.groupBox2.Controls.Add(this.rbtn_CompressionCCITT3);
            this.groupBox2.Controls.Add(this.rbtn_CompressionNone);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 143);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compression";
            // 
            // rbtn_CompressionRle
            // 
            this.rbtn_CompressionRle.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_CompressionRle, "Specifies that Rle compression will be used when saving.");
            this.rbtn_CompressionRle.Location = new System.Drawing.Point(6, 112);
            this.rbtn_CompressionRle.Name = "rbtn_CompressionRle";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_CompressionRle, true);
            this.rbtn_CompressionRle.Size = new System.Drawing.Size(41, 17);
            this.rbtn_CompressionRle.TabIndex = 4;
            this.rbtn_CompressionRle.Text = "Rle";
            this.rbtn_CompressionRle.UseVisualStyleBackColor = true;
            // 
            // rbtn_CompressionLZW
            // 
            this.rbtn_CompressionLZW.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_CompressionLZW, "Specifies that LZW compression will be used when saving.");
            this.rbtn_CompressionLZW.Location = new System.Drawing.Point(6, 89);
            this.rbtn_CompressionLZW.Name = "rbtn_CompressionLZW";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_CompressionLZW, true);
            this.rbtn_CompressionLZW.Size = new System.Drawing.Size(49, 17);
            this.rbtn_CompressionLZW.TabIndex = 3;
            this.rbtn_CompressionLZW.Text = "LZW";
            this.rbtn_CompressionLZW.UseVisualStyleBackColor = true;
            // 
            // rbtn_CompressionCCITT4
            // 
            this.rbtn_CompressionCCITT4.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_CompressionCCITT4, "Specifies that CCITT4 compression will be used when saving.");
            this.rbtn_CompressionCCITT4.Location = new System.Drawing.Point(6, 66);
            this.rbtn_CompressionCCITT4.Name = "rbtn_CompressionCCITT4";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_CompressionCCITT4, true);
            this.rbtn_CompressionCCITT4.Size = new System.Drawing.Size(62, 17);
            this.rbtn_CompressionCCITT4.TabIndex = 2;
            this.rbtn_CompressionCCITT4.Text = "CCITT4";
            this.rbtn_CompressionCCITT4.UseVisualStyleBackColor = true;
            // 
            // rbtn_CompressionCCITT3
            // 
            this.rbtn_CompressionCCITT3.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_CompressionCCITT3, "Specifies that the CCITT3 compression will be used when saving.");
            this.rbtn_CompressionCCITT3.Location = new System.Drawing.Point(6, 43);
            this.rbtn_CompressionCCITT3.Name = "rbtn_CompressionCCITT3";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_CompressionCCITT3, true);
            this.rbtn_CompressionCCITT3.Size = new System.Drawing.Size(62, 17);
            this.rbtn_CompressionCCITT3.TabIndex = 1;
            this.rbtn_CompressionCCITT3.Text = "CCITT3";
            this.rbtn_CompressionCCITT3.UseVisualStyleBackColor = true;
            // 
            // rbtn_CompressionNone
            // 
            this.rbtn_CompressionNone.AutoSize = true;
            this.rbtn_CompressionNone.Checked = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_CompressionNone, "Specifies that no compression will be used when saving.");
            this.rbtn_CompressionNone.Location = new System.Drawing.Point(6, 20);
            this.rbtn_CompressionNone.Name = "rbtn_CompressionNone";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_CompressionNone, true);
            this.rbtn_CompressionNone.Size = new System.Drawing.Size(51, 17);
            this.rbtn_CompressionNone.TabIndex = 0;
            this.rbtn_CompressionNone.TabStop = true;
            this.rbtn_CompressionNone.Text = "None";
            this.rbtn_CompressionNone.UseVisualStyleBackColor = true;
            // 
            // ckb_PreserveData
            // 
            this.ckb_PreserveData.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.ckb_PreserveData, "Specifies whether to preserve any EXIF meta data contained in the current image.");
            this.ckb_PreserveData.Location = new System.Drawing.Point(12, 247);
            this.ckb_PreserveData.Name = "ckb_PreserveData";
            this.hp_HelpInfo.SetShowHelp(this.ckb_PreserveData, true);
            this.ckb_PreserveData.Size = new System.Drawing.Size(121, 17);
            this.ckb_PreserveData.TabIndex = 4;
            this.ckb_PreserveData.Text = "Preserve meta data";
            this.ckb_PreserveData.UseVisualStyleBackColor = true;
            // 
            // FormTiffSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 277);
            this.Controls.Add(this.ckb_PreserveData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.gbx_ColourDepth);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTiffSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TIFF Settings";
            this.gbx_ColourDepth.ResumeLayout(false);
            this.gbx_ColourDepth.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_ColourDepth;
        private System.Windows.Forms.RadioButton rbtn_24Bits;
        private System.Windows.Forms.RadioButton rbtn_32Bits;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_CompressionNone;
        private System.Windows.Forms.RadioButton rbtn_CompressionRle;
        private System.Windows.Forms.RadioButton rbtn_CompressionLZW;
        private System.Windows.Forms.RadioButton rbtn_CompressionCCITT4;
        private System.Windows.Forms.RadioButton rbtn_CompressionCCITT3;
        private System.Windows.Forms.HelpProvider hp_HelpInfo;
        private System.Windows.Forms.CheckBox ckb_PreserveData;
    }
}