namespace IView.Controls.Library
{
    partial class ShearPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_ShearSettings = new System.Windows.Forms.Label();
            this.pan_splitter_01 = new System.Windows.Forms.Panel();
            this.lbl_pixels_01 = new System.Windows.Forms.Label();
            this.lbl_pixels_02 = new System.Windows.Forms.Label();
            this.nud_Horizontal = new System.Windows.Forms.NumericUpDown();
            this.nud_Vertical = new System.Windows.Forms.NumericUpDown();
            this.ckb_ResizeImage = new System.Windows.Forms.CheckBox();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.ckb_TransparentBackground = new System.Windows.Forms.CheckBox();
            this.pan_splitter_02 = new System.Windows.Forms.Panel();
            this.slbl_Vertical = new IView.Controls.Library.ScrollLabel();
            this.slbl_Horizontal = new IView.Controls.Library.ScrollLabel();
            this.cpic_BackgroundColour = new IView.Controls.Library.ColourPicker();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Horizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Vertical)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ShearSettings
            // 
            this.lbl_ShearSettings.AutoSize = true;
            this.lbl_ShearSettings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ShearSettings.Location = new System.Drawing.Point(3, 9);
            this.lbl_ShearSettings.Name = "lbl_ShearSettings";
            this.lbl_ShearSettings.Size = new System.Drawing.Size(109, 17);
            this.lbl_ShearSettings.TabIndex = 0;
            this.lbl_ShearSettings.Text = "Shear Settings";
            // 
            // pan_splitter_01
            // 
            this.pan_splitter_01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_splitter_01.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_splitter_01.Location = new System.Drawing.Point(3, 29);
            this.pan_splitter_01.Name = "pan_splitter_01";
            this.pan_splitter_01.Size = new System.Drawing.Size(205, 1);
            this.pan_splitter_01.TabIndex = 1;
            // 
            // lbl_pixels_01
            // 
            this.lbl_pixels_01.AutoSize = true;
            this.lbl_pixels_01.Location = new System.Drawing.Point(158, 38);
            this.lbl_pixels_01.Name = "lbl_pixels_01";
            this.lbl_pixels_01.Size = new System.Drawing.Size(45, 17);
            this.lbl_pixels_01.TabIndex = 6;
            this.lbl_pixels_01.Text = "pixels.";
            // 
            // lbl_pixels_02
            // 
            this.lbl_pixels_02.AutoSize = true;
            this.lbl_pixels_02.Location = new System.Drawing.Point(158, 65);
            this.lbl_pixels_02.Name = "lbl_pixels_02";
            this.lbl_pixels_02.Size = new System.Drawing.Size(45, 17);
            this.lbl_pixels_02.TabIndex = 7;
            this.lbl_pixels_02.Text = "pixels.";
            // 
            // nud_Horizontal
            // 
            this.nud_Horizontal.Location = new System.Drawing.Point(82, 36);
            this.nud_Horizontal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_Horizontal.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nud_Horizontal.Name = "nud_Horizontal";
            this.nud_Horizontal.Size = new System.Drawing.Size(70, 24);
            this.nud_Horizontal.TabIndex = 10;
            this.nud_Horizontal.ValueChanged += new System.EventHandler(this.nud_Horizontal_ValueChanged);
            // 
            // nud_Vertical
            // 
            this.nud_Vertical.Location = new System.Drawing.Point(82, 63);
            this.nud_Vertical.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_Vertical.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nud_Vertical.Name = "nud_Vertical";
            this.nud_Vertical.Size = new System.Drawing.Size(70, 24);
            this.nud_Vertical.TabIndex = 11;
            this.nud_Vertical.ValueChanged += new System.EventHandler(this.nud_Vertical_ValueChanged);
            // 
            // ckb_ResizeImage
            // 
            this.ckb_ResizeImage.AutoSize = true;
            this.ckb_ResizeImage.Checked = true;
            this.ckb_ResizeImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_ResizeImage.Location = new System.Drawing.Point(3, 99);
            this.ckb_ResizeImage.Name = "ckb_ResizeImage";
            this.ckb_ResizeImage.Size = new System.Drawing.Size(111, 21);
            this.ckb_ResizeImage.TabIndex = 13;
            this.ckb_ResizeImage.Text = "Resize image ";
            this.ckb_ResizeImage.UseVisualStyleBackColor = true;
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(3, 188);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 25);
            this.btn_Apply.TabIndex = 14;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // ckb_TransparentBackground
            // 
            this.ckb_TransparentBackground.AutoSize = true;
            this.ckb_TransparentBackground.Checked = true;
            this.ckb_TransparentBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_TransparentBackground.Location = new System.Drawing.Point(3, 122);
            this.ckb_TransparentBackground.Name = "ckb_TransparentBackground";
            this.ckb_TransparentBackground.Size = new System.Drawing.Size(182, 21);
            this.ckb_TransparentBackground.TabIndex = 16;
            this.ckb_TransparentBackground.Text = "Transparent background";
            this.ckb_TransparentBackground.UseVisualStyleBackColor = true;
            this.ckb_TransparentBackground.CheckedChanged += new System.EventHandler(this.ckb_TransparentBackground_CheckedChanged);
            // 
            // pan_splitter_02
            // 
            this.pan_splitter_02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_splitter_02.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_splitter_02.Location = new System.Drawing.Point(3, 181);
            this.pan_splitter_02.Name = "pan_splitter_02";
            this.pan_splitter_02.Size = new System.Drawing.Size(205, 1);
            this.pan_splitter_02.TabIndex = 17;
            // 
            // slbl_Vertical
            // 
            this.slbl_Vertical.AutoSize = true;
            this.slbl_Vertical.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.slbl_Vertical.Location = new System.Drawing.Point(3, 65);
            this.slbl_Vertical.Maximum = 1000;
            this.slbl_Vertical.Minimum = -1000;
            this.slbl_Vertical.Name = "slbl_Vertical";
            this.slbl_Vertical.Size = new System.Drawing.Size(56, 17);
            this.slbl_Vertical.TabIndex = 12;
            this.slbl_Vertical.Text = "Vertical:";
            this.slbl_Vertical.Value = 0;
            this.slbl_Vertical.ValueChanged += new System.EventHandler<System.EventArgs>(this.slbl_Vertical_ValueChanged);
            // 
            // slbl_Horizontal
            // 
            this.slbl_Horizontal.AutoSize = true;
            this.slbl_Horizontal.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.slbl_Horizontal.Location = new System.Drawing.Point(3, 38);
            this.slbl_Horizontal.Maximum = 1000;
            this.slbl_Horizontal.Minimum = -1000;
            this.slbl_Horizontal.Name = "slbl_Horizontal";
            this.slbl_Horizontal.Size = new System.Drawing.Size(73, 17);
            this.slbl_Horizontal.TabIndex = 9;
            this.slbl_Horizontal.Text = "Horizontal:";
            this.slbl_Horizontal.Value = 0;
            this.slbl_Horizontal.ValueChanged += new System.EventHandler<System.EventArgs>(this.slbl_Horizontal_ValueChanged);
            // 
            // cpic_BackgroundColour
            // 
            this.cpic_BackgroundColour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpic_BackgroundColour.Enabled = false;
            this.cpic_BackgroundColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpic_BackgroundColour.Location = new System.Drawing.Point(3, 145);
            this.cpic_BackgroundColour.Name = "cpic_BackgroundColour";
            this.cpic_BackgroundColour.SelectedColour = System.Drawing.SystemColors.Control;
            this.cpic_BackgroundColour.Size = new System.Drawing.Size(205, 30);
            this.cpic_BackgroundColour.TabIndex = 18;
            // 
            // ShearPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cpic_BackgroundColour);
            this.Controls.Add(this.pan_splitter_02);
            this.Controls.Add(this.ckb_TransparentBackground);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.ckb_ResizeImage);
            this.Controls.Add(this.slbl_Vertical);
            this.Controls.Add(this.nud_Vertical);
            this.Controls.Add(this.nud_Horizontal);
            this.Controls.Add(this.slbl_Horizontal);
            this.Controls.Add(this.lbl_pixels_02);
            this.Controls.Add(this.lbl_pixels_01);
            this.Controls.Add(this.pan_splitter_01);
            this.Controls.Add(this.lbl_ShearSettings);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ShearPanel";
            this.Size = new System.Drawing.Size(211, 311);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Horizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Vertical)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ShearSettings;
        private System.Windows.Forms.Panel pan_splitter_01;
        private System.Windows.Forms.Label lbl_pixels_01;
        private System.Windows.Forms.Label lbl_pixels_02;
        private ScrollLabel slbl_Horizontal;
        private System.Windows.Forms.NumericUpDown nud_Horizontal;
        private System.Windows.Forms.NumericUpDown nud_Vertical;
        private ScrollLabel slbl_Vertical;
        private System.Windows.Forms.CheckBox ckb_ResizeImage;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.CheckBox ckb_TransparentBackground;
        private System.Windows.Forms.Panel pan_splitter_02;
        private ColourPicker cpic_BackgroundColour;
    }
}
