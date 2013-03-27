namespace IView.Controls.Library
{
    partial class RedEyePanel
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
            this.lbl_Info = new System.Windows.Forms.Label();
            this.lbl_PupileSize = new System.Windows.Forms.Label();
            this.tbar_PupilSize = new System.Windows.Forms.TrackBar();
            this.txtb_PupilSize = new System.Windows.Forms.TextBox();
            this.pan_splitter_02 = new System.Windows.Forms.Panel();
            this.btn_Activate = new System.Windows.Forms.Button();
            this.lbl_RedEyeCorrection = new System.Windows.Forms.Label();
            this.pan_splitter_01 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_PupilSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Info
            // 
            this.lbl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Info.AutoEllipsis = true;
            this.lbl_Info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_Info.Location = new System.Drawing.Point(3, 33);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(205, 38);
            this.lbl_Info.TabIndex = 0;
            this.lbl_Info.Text = "Click the activate button, then click the center of the red eye you want to fix.";
            // 
            // lbl_PupileSize
            // 
            this.lbl_PupileSize.AutoSize = true;
            this.lbl_PupileSize.Location = new System.Drawing.Point(3, 111);
            this.lbl_PupileSize.Name = "lbl_PupileSize";
            this.lbl_PupileSize.Size = new System.Drawing.Size(68, 17);
            this.lbl_PupileSize.TabIndex = 1;
            this.lbl_PupileSize.Text = "Pupil Size:";
            // 
            // tbar_PupilSize
            // 
            this.tbar_PupilSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_PupilSize.AutoSize = false;
            this.tbar_PupilSize.Location = new System.Drawing.Point(3, 131);
            this.tbar_PupilSize.Maximum = 100;
            this.tbar_PupilSize.Minimum = 1;
            this.tbar_PupilSize.Name = "tbar_PupilSize";
            this.tbar_PupilSize.Size = new System.Drawing.Size(144, 22);
            this.tbar_PupilSize.TabIndex = 3;
            this.tbar_PupilSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_PupilSize.Value = 1;
            this.tbar_PupilSize.ValueChanged += new System.EventHandler(this.tbar_PupilSize_ValueChanged);
            // 
            // txtb_PupilSize
            // 
            this.txtb_PupilSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_PupilSize.BackColor = System.Drawing.Color.White;
            this.txtb_PupilSize.Location = new System.Drawing.Point(153, 132);
            this.txtb_PupilSize.Name = "txtb_PupilSize";
            this.txtb_PupilSize.ReadOnly = true;
            this.txtb_PupilSize.Size = new System.Drawing.Size(55, 24);
            this.txtb_PupilSize.TabIndex = 5;
            this.txtb_PupilSize.Text = "100%";
            this.txtb_PupilSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pan_splitter_02
            // 
            this.pan_splitter_02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_splitter_02.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_splitter_02.Location = new System.Drawing.Point(3, 105);
            this.pan_splitter_02.Name = "pan_splitter_02";
            this.pan_splitter_02.Size = new System.Drawing.Size(205, 1);
            this.pan_splitter_02.TabIndex = 9;
            // 
            // btn_Activate
            // 
            this.btn_Activate.Location = new System.Drawing.Point(3, 74);
            this.btn_Activate.Name = "btn_Activate";
            this.btn_Activate.Size = new System.Drawing.Size(75, 25);
            this.btn_Activate.TabIndex = 10;
            this.btn_Activate.Text = "Activate";
            this.btn_Activate.UseVisualStyleBackColor = true;
            this.btn_Activate.Click += new System.EventHandler(this.btn_Activate_Click);
            // 
            // lbl_RedEyeCorrection
            // 
            this.lbl_RedEyeCorrection.AutoSize = true;
            this.lbl_RedEyeCorrection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RedEyeCorrection.Location = new System.Drawing.Point(3, 9);
            this.lbl_RedEyeCorrection.Name = "lbl_RedEyeCorrection";
            this.lbl_RedEyeCorrection.Size = new System.Drawing.Size(141, 17);
            this.lbl_RedEyeCorrection.TabIndex = 11;
            this.lbl_RedEyeCorrection.Text = "Red Eye Correction";
            // 
            // pan_splitter_01
            // 
            this.pan_splitter_01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_splitter_01.BackColor = System.Drawing.Color.Gainsboro;
            this.pan_splitter_01.Location = new System.Drawing.Point(3, 29);
            this.pan_splitter_01.Name = "pan_splitter_01";
            this.pan_splitter_01.Size = new System.Drawing.Size(205, 1);
            this.pan_splitter_01.TabIndex = 12;
            // 
            // RedEyePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pan_splitter_01);
            this.Controls.Add(this.lbl_RedEyeCorrection);
            this.Controls.Add(this.btn_Activate);
            this.Controls.Add(this.pan_splitter_02);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.txtb_PupilSize);
            this.Controls.Add(this.tbar_PupilSize);
            this.Controls.Add(this.lbl_PupileSize);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RedEyePanel";
            this.Size = new System.Drawing.Size(211, 318);
            ((System.ComponentModel.ISupportInitialize)(this.tbar_PupilSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Label lbl_PupileSize;
        private System.Windows.Forms.TrackBar tbar_PupilSize;
        private System.Windows.Forms.TextBox txtb_PupilSize;
        private System.Windows.Forms.Panel pan_splitter_02;
        private System.Windows.Forms.Button btn_Activate;
        private System.Windows.Forms.Label lbl_RedEyeCorrection;
        private System.Windows.Forms.Panel pan_splitter_01;
    }
}
