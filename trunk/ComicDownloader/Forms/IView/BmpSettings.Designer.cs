namespace IView.UI.Forms
{
    partial class BmpSettings
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
            this.gbx_Controls = new System.Windows.Forms.GroupBox();
            this.rbtn_24Bit = new System.Windows.Forms.RadioButton();
            this.rbtn_32Bit = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.hp_HelpInfo = new System.Windows.Forms.HelpProvider();
            this.gbx_Controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Controls
            // 
            this.gbx_Controls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Controls.Controls.Add(this.rbtn_24Bit);
            this.gbx_Controls.Controls.Add(this.rbtn_32Bit);
            this.gbx_Controls.Location = new System.Drawing.Point(12, 12);
            this.gbx_Controls.Name = "gbx_Controls";
            this.gbx_Controls.Size = new System.Drawing.Size(245, 73);
            this.gbx_Controls.TabIndex = 2;
            this.gbx_Controls.TabStop = false;
            this.gbx_Controls.Text = "Colour Depth";
            // 
            // rbtn_24Bit
            // 
            this.rbtn_24Bit.AutoSize = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_24Bit, "Specifies that the colour depth used will be 24 bit and consist of 3 channels (Re" +
                    "d, Green, Blue) at 8 bits per channel.");
            this.rbtn_24Bit.Location = new System.Drawing.Point(6, 43);
            this.rbtn_24Bit.Name = "rbtn_24Bit";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_24Bit, true);
            this.rbtn_24Bit.Size = new System.Drawing.Size(107, 17);
            this.rbtn_24Bit.TabIndex = 1;
            this.rbtn_24Bit.Text = "24 bit - R8 G8 B8";
            this.rbtn_24Bit.UseVisualStyleBackColor = true;
            // 
            // rbtn_32Bit
            // 
            this.rbtn_32Bit.AutoSize = true;
            this.rbtn_32Bit.Checked = true;
            this.hp_HelpInfo.SetHelpString(this.rbtn_32Bit, "Specifies that the colour depth used will be 32 bit and consist of 4 channels (Al" +
                    "pha, Red, Green, Blue) at 8 bits per channel.");
            this.rbtn_32Bit.Location = new System.Drawing.Point(6, 20);
            this.rbtn_32Bit.Name = "rbtn_32Bit";
            this.hp_HelpInfo.SetShowHelp(this.rbtn_32Bit, true);
            this.rbtn_32Bit.Size = new System.Drawing.Size(123, 17);
            this.rbtn_32Bit.TabIndex = 0;
            this.rbtn_32Bit.TabStop = true;
            this.rbtn_32Bit.Text = "32 bit - A8 R8 G8 B8";
            this.rbtn_32Bit.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(182, 91);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(101, 91);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 25);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "&OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // FormBmpSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 126);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.gbx_Controls);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBmpSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BMP Settings";
            this.gbx_Controls.ResumeLayout(false);
            this.gbx_Controls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Controls;
        private System.Windows.Forms.RadioButton rbtn_24Bit;
        private System.Windows.Forms.RadioButton rbtn_32Bit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.HelpProvider hp_HelpInfo;
    }
}