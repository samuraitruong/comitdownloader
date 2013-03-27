namespace IView.UI.Forms
{
    partial class UpdateLocations
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvw_Locations = new System.Windows.Forms.ListView();
            this.ch_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "A newer version of iView.NET has been released.\r\n\r\nDownload locations:";
            // 
            // lvw_Locations
            // 
            this.lvw_Locations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw_Locations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Name,
            this.ch_Location});
            this.lvw_Locations.FullRowSelect = true;
            this.lvw_Locations.GridLines = true;
            this.lvw_Locations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_Locations.Location = new System.Drawing.Point(12, 63);
            this.lvw_Locations.MultiSelect = false;
            this.lvw_Locations.Name = "lvw_Locations";
            this.lvw_Locations.Size = new System.Drawing.Size(370, 118);
            this.lvw_Locations.TabIndex = 2;
            this.lvw_Locations.UseCompatibleStateImageBehavior = false;
            this.lvw_Locations.View = System.Windows.Forms.View.Details;
            this.lvw_Locations.SelectedIndexChanged += new System.EventHandler(this.lvw_Locations_SelectedIndexChanged);
            this.lvw_Locations.DoubleClick += new System.EventHandler(this.lvw_Locations_DoubleClick);
            // 
            // ch_Name
            // 
            this.ch_Name.Text = "Name";
            this.ch_Name.Width = 110;
            // 
            // ch_Location
            // 
            this.ch_Location.Text = "Location";
            this.ch_Location.Width = 223;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(307, 187);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.Enabled = false;
            this.btn_Ok.Location = new System.Drawing.Point(226, 187);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 25);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "&OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // FormUpdateLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 222);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lvw_Locations);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateLocations";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iView.NET Updates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvw_Locations;
        private System.Windows.Forms.ColumnHeader ch_Name;
        private System.Windows.Forms.ColumnHeader ch_Location;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
    }
}