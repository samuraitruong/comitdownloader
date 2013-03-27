namespace IView.UI.Forms
{
    partial class AdjustTime
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
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.lbl_Hours = new System.Windows.Forms.Label();
            this.nud_Hours = new System.Windows.Forms.NumericUpDown();
            this.nud_Minutes = new System.Windows.Forms.NumericUpDown();
            this.lbl_Minutes = new System.Windows.Forms.Label();
            this.lbl_Seconds = new System.Windows.Forms.Label();
            this.nud_Seconds = new System.Windows.Forms.NumericUpDown();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.lbl_CurrentDate = new System.Windows.Forms.Label();
            this.pan_Splitter = new System.Windows.Forms.Panel();
            this.bgw_ChangeTimeStampWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_Date
            // 
            this.dtp_Date.Location = new System.Drawing.Point(229, 58);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(198, 21);
            this.dtp_Date.TabIndex = 5;
            // 
            // lbl_Hours
            // 
            this.lbl_Hours.AutoSize = true;
            this.lbl_Hours.Location = new System.Drawing.Point(12, 38);
            this.lbl_Hours.Name = "lbl_Hours";
            this.lbl_Hours.Size = new System.Drawing.Size(39, 13);
            this.lbl_Hours.TabIndex = 7;
            this.lbl_Hours.Text = "Hours:";
            // 
            // nud_Hours
            // 
            this.nud_Hours.Location = new System.Drawing.Point(12, 58);
            this.nud_Hours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nud_Hours.Name = "nud_Hours";
            this.nud_Hours.Size = new System.Drawing.Size(55, 21);
            this.nud_Hours.TabIndex = 2;
            this.nud_Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud_Minutes
            // 
            this.nud_Minutes.Location = new System.Drawing.Point(83, 58);
            this.nud_Minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nud_Minutes.Name = "nud_Minutes";
            this.nud_Minutes.Size = new System.Drawing.Size(55, 21);
            this.nud_Minutes.TabIndex = 3;
            this.nud_Minutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Minutes
            // 
            this.lbl_Minutes.AutoSize = true;
            this.lbl_Minutes.Location = new System.Drawing.Point(80, 38);
            this.lbl_Minutes.Name = "lbl_Minutes";
            this.lbl_Minutes.Size = new System.Drawing.Size(48, 13);
            this.lbl_Minutes.TabIndex = 8;
            this.lbl_Minutes.Text = "Minutes:";
            // 
            // lbl_Seconds
            // 
            this.lbl_Seconds.AutoSize = true;
            this.lbl_Seconds.Location = new System.Drawing.Point(153, 38);
            this.lbl_Seconds.Name = "lbl_Seconds";
            this.lbl_Seconds.Size = new System.Drawing.Size(51, 13);
            this.lbl_Seconds.TabIndex = 9;
            this.lbl_Seconds.Text = "Seconds:";
            // 
            // nud_Seconds
            // 
            this.nud_Seconds.Location = new System.Drawing.Point(156, 58);
            this.nud_Seconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nud_Seconds.Name = "nud_Seconds";
            this.nud_Seconds.Size = new System.Drawing.Size(55, 21);
            this.nud_Seconds.TabIndex = 4;
            this.nud_Seconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(12, 9);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(265, 13);
            this.lbl_Info.TabIndex = 6;
            this.lbl_Info.Text = "Change the creation time stamp for the selected files.";
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Location = new System.Drawing.Point(226, 38);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(34, 13);
            this.lbl_Date.TabIndex = 10;
            this.lbl_Date.Text = "Date:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(347, 97);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.Enabled = false;
            this.btn_Ok.Location = new System.Drawing.Point(261, 97);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 25);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "&OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // lbl_CurrentDate
            // 
            this.lbl_CurrentDate.AutoSize = true;
            this.lbl_CurrentDate.Location = new System.Drawing.Point(12, 103);
            this.lbl_CurrentDate.Name = "lbl_CurrentDate";
            this.lbl_CurrentDate.Size = new System.Drawing.Size(73, 13);
            this.lbl_CurrentDate.TabIndex = 11;
            this.lbl_CurrentDate.Text = "Current date:";
            // 
            // pan_Splitter
            // 
            this.pan_Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_Splitter.BackColor = System.Drawing.Color.Silver;
            this.pan_Splitter.Location = new System.Drawing.Point(12, 29);
            this.pan_Splitter.Name = "pan_Splitter";
            this.pan_Splitter.Size = new System.Drawing.Size(415, 1);
            this.pan_Splitter.TabIndex = 12;
            // 
            // bgw_ChangeTimeStampWorker
            // 
            this.bgw_ChangeTimeStampWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_ChangeTimeStampWorker_DoWork);
            this.bgw_ChangeTimeStampWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_ChangeTimeStampWorker_RunWorkerCompleted);
            // 
            // FormAdjustTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 134);
            this.Controls.Add(this.pan_Splitter);
            this.Controls.Add(this.lbl_CurrentDate);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_Date);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.lbl_Seconds);
            this.Controls.Add(this.lbl_Minutes);
            this.Controls.Add(this.nud_Seconds);
            this.Controls.Add(this.nud_Minutes);
            this.Controls.Add(this.nud_Hours);
            this.Controls.Add(this.lbl_Hours);
            this.Controls.Add(this.dtp_Date);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdjustTime";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adjust Time";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Seconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.Label lbl_Hours;
        private System.Windows.Forms.NumericUpDown nud_Hours;
        private System.Windows.Forms.NumericUpDown nud_Minutes;
        private System.Windows.Forms.Label lbl_Minutes;
        private System.Windows.Forms.Label lbl_Seconds;
        private System.Windows.Forms.NumericUpDown nud_Seconds;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Label lbl_CurrentDate;
        private System.Windows.Forms.Panel pan_Splitter;
        private System.ComponentModel.BackgroundWorker bgw_ChangeTimeStampWorker;
    }
}