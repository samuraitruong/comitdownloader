namespace IView.Controls.Library
{
    partial class ResizePanel
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
            this.pan_line_01 = new System.Windows.Forms.Panel();
            this.rbtn_OriginalSize = new System.Windows.Forms.RadioButton();
            this.rbtn_PredefinedSize = new System.Windows.Forms.RadioButton();
            this.cbx_PredefinedSizes = new System.Windows.Forms.ComboBox();
            this.rbtn_CustomSize = new System.Windows.Forms.RadioButton();
            this.pan_Line_02 = new System.Windows.Forms.Panel();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.lbl_Info_01 = new System.Windows.Forms.Label();
            this.lbl_NewSize = new System.Windows.Forms.Label();
            this.lbl_Info_02 = new System.Windows.Forms.Label();
            this.cbx_Interpolation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.num_Width = new System.Windows.Forms.NumericUpDown();
            this.num_Height = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Quality = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_LockScale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_line_01
            // 
            this.pan_line_01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_line_01.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_line_01.Location = new System.Drawing.Point(3, 29);
            this.pan_line_01.Name = "pan_line_01";
            this.pan_line_01.Size = new System.Drawing.Size(195, 1);
            this.pan_line_01.TabIndex = 4;
            // 
            // rbtn_OriginalSize
            // 
            this.rbtn_OriginalSize.AutoSize = true;
            this.rbtn_OriginalSize.Checked = true;
            this.rbtn_OriginalSize.Enabled = false;
            this.rbtn_OriginalSize.Location = new System.Drawing.Point(3, 35);
            this.rbtn_OriginalSize.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_OriginalSize.Name = "rbtn_OriginalSize";
            this.rbtn_OriginalSize.Size = new System.Drawing.Size(98, 21);
            this.rbtn_OriginalSize.TabIndex = 5;
            this.rbtn_OriginalSize.TabStop = true;
            this.rbtn_OriginalSize.Text = "Original size";
            this.rbtn_OriginalSize.UseVisualStyleBackColor = true;
            this.rbtn_OriginalSize.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbtn_PredefinedSize
            // 
            this.rbtn_PredefinedSize.AutoSize = true;
            this.rbtn_PredefinedSize.Enabled = false;
            this.rbtn_PredefinedSize.Location = new System.Drawing.Point(3, 60);
            this.rbtn_PredefinedSize.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_PredefinedSize.Name = "rbtn_PredefinedSize";
            this.rbtn_PredefinedSize.Size = new System.Drawing.Size(118, 21);
            this.rbtn_PredefinedSize.TabIndex = 6;
            this.rbtn_PredefinedSize.TabStop = true;
            this.rbtn_PredefinedSize.Text = "Predefined size";
            this.rbtn_PredefinedSize.UseVisualStyleBackColor = true;
            this.rbtn_PredefinedSize.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cbx_PredefinedSizes
            // 
            this.cbx_PredefinedSizes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_PredefinedSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_PredefinedSizes.Enabled = false;
            this.cbx_PredefinedSizes.FormattingEnabled = true;
            this.cbx_PredefinedSizes.Location = new System.Drawing.Point(3, 86);
            this.cbx_PredefinedSizes.Name = "cbx_PredefinedSizes";
            this.cbx_PredefinedSizes.Size = new System.Drawing.Size(195, 25);
            this.cbx_PredefinedSizes.TabIndex = 7;
            this.cbx_PredefinedSizes.SelectedIndexChanged += new System.EventHandler(this.cbx_PredefinedSizes_SelectedIndexChanged);
            // 
            // rbtn_CustomSize
            // 
            this.rbtn_CustomSize.AutoSize = true;
            this.rbtn_CustomSize.Enabled = false;
            this.rbtn_CustomSize.Location = new System.Drawing.Point(3, 116);
            this.rbtn_CustomSize.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_CustomSize.Name = "rbtn_CustomSize";
            this.rbtn_CustomSize.Size = new System.Drawing.Size(102, 21);
            this.rbtn_CustomSize.TabIndex = 8;
            this.rbtn_CustomSize.TabStop = true;
            this.rbtn_CustomSize.Text = "Custom size";
            this.rbtn_CustomSize.UseVisualStyleBackColor = true;
            this.rbtn_CustomSize.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // pan_Line_02
            // 
            this.pan_Line_02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_Line_02.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_Line_02.Location = new System.Drawing.Point(3, 279);
            this.pan_Line_02.Name = "pan_Line_02";
            this.pan_Line_02.Size = new System.Drawing.Size(195, 1);
            this.pan_Line_02.TabIndex = 9;
            // 
            // btn_Apply
            // 
            this.btn_Apply.Enabled = false;
            this.btn_Apply.Location = new System.Drawing.Point(3, 330);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 25);
            this.btn_Apply.TabIndex = 10;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // lbl_Info_01
            // 
            this.lbl_Info_01.AutoSize = true;
            this.lbl_Info_01.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Info_01.Location = new System.Drawing.Point(3, 9);
            this.lbl_Info_01.Name = "lbl_Info_01";
            this.lbl_Info_01.Size = new System.Drawing.Size(112, 17);
            this.lbl_Info_01.TabIndex = 11;
            this.lbl_Info_01.Text = "Resize Settings";
            // 
            // lbl_NewSize
            // 
            this.lbl_NewSize.AutoSize = true;
            this.lbl_NewSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_NewSize.Location = new System.Drawing.Point(3, 0);
            this.lbl_NewSize.Name = "lbl_NewSize";
            this.lbl_NewSize.Size = new System.Drawing.Size(91, 38);
            this.lbl_NewSize.TabIndex = 12;
            this.lbl_NewSize.Text = "Size: 0 x 0 px";
            // 
            // lbl_Info_02
            // 
            this.lbl_Info_02.AutoSize = true;
            this.lbl_Info_02.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Info_02.Location = new System.Drawing.Point(3, 259);
            this.lbl_Info_02.Name = "lbl_Info_02";
            this.lbl_Info_02.Size = new System.Drawing.Size(121, 17);
            this.lbl_Info_02.TabIndex = 13;
            this.lbl_Info_02.Text = "Resize Summary";
            // 
            // cbx_Interpolation
            // 
            this.cbx_Interpolation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Interpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Interpolation.Enabled = false;
            this.cbx_Interpolation.FormattingEnabled = true;
            this.cbx_Interpolation.Location = new System.Drawing.Point(3, 226);
            this.cbx_Interpolation.Name = "cbx_Interpolation";
            this.cbx_Interpolation.Size = new System.Drawing.Size(195, 25);
            this.cbx_Interpolation.TabIndex = 14;
            this.cbx_Interpolation.SelectedIndexChanged += new System.EventHandler(this.cbx_Interpolation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Interpolation:";
            // 
            // num_Width
            // 
            this.num_Width.Enabled = false;
            this.num_Width.Location = new System.Drawing.Point(63, 146);
            this.num_Width.Name = "num_Width";
            this.num_Width.Size = new System.Drawing.Size(60, 24);
            this.num_Width.TabIndex = 17;
            this.num_Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Width.ValueChanged += new System.EventHandler(this.num_Width_ValueChanged);
            // 
            // num_Height
            // 
            this.num_Height.Enabled = false;
            this.num_Height.Location = new System.Drawing.Point(63, 173);
            this.num_Height.Name = "num_Height";
            this.num_Height.Size = new System.Drawing.Size(60, 24);
            this.num_Height.TabIndex = 18;
            this.num_Height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Height.ValueChanged += new System.EventHandler(this.num_Height_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Height:";
            // 
            // lbl_Quality
            // 
            this.lbl_Quality.AutoSize = true;
            this.lbl_Quality.Location = new System.Drawing.Point(100, 0);
            this.lbl_Quality.Name = "lbl_Quality";
            this.lbl_Quality.Size = new System.Drawing.Size(59, 34);
            this.lbl_Quality.TabIndex = 22;
            this.lbl_Quality.Text = "Quality: Default";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Quality, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_NewSize, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 286);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(195, 38);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // btn_LockScale
            // 
            this.btn_LockScale.Enabled = false;
            this.btn_LockScale.Image = ComicDownloader.Properties.Resources.locked_16x16;
            this.btn_LockScale.Location = new System.Drawing.Point(129, 153);
            this.btn_LockScale.Name = "btn_LockScale";
            this.btn_LockScale.Size = new System.Drawing.Size(15, 32);
            this.btn_LockScale.TabIndex = 23;
            this.btn_LockScale.UseVisualStyleBackColor = true;
            this.btn_LockScale.Click += new System.EventHandler(this.btn_LockScale_Click);
            // 
            // ResizePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_LockScale);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_Height);
            this.Controls.Add(this.num_Width);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_Interpolation);
            this.Controls.Add(this.lbl_Info_02);
            this.Controls.Add(this.lbl_Info_01);
            this.Controls.Add(this.pan_Line_02);
            this.Controls.Add(this.rbtn_CustomSize);
            this.Controls.Add(this.cbx_PredefinedSizes);
            this.Controls.Add(this.rbtn_PredefinedSize);
            this.Controls.Add(this.rbtn_OriginalSize);
            this.Controls.Add(this.pan_line_01);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ResizePanel";
            this.Size = new System.Drawing.Size(201, 358);
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pan_line_01;
        private System.Windows.Forms.RadioButton rbtn_OriginalSize;
        private System.Windows.Forms.RadioButton rbtn_PredefinedSize;
        private System.Windows.Forms.ComboBox cbx_PredefinedSizes;
        private System.Windows.Forms.RadioButton rbtn_CustomSize;
        private System.Windows.Forms.Panel pan_Line_02;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Label lbl_Info_01;
        private System.Windows.Forms.Label lbl_NewSize;
        private System.Windows.Forms.Label lbl_Info_02;
        private System.Windows.Forms.ComboBox cbx_Interpolation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_Width;
        private System.Windows.Forms.NumericUpDown num_Height;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Quality;
        private System.Windows.Forms.Button btn_LockScale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
