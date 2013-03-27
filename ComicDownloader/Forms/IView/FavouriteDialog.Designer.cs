namespace IView.UI.Forms
{
    partial class FavouriteDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouriteDialog));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txtb_Name = new System.Windows.Forms.TextBox();
            this.txtb_Location = new System.Windows.Forms.TextBox();
            this.lbl_info_Name = new System.Windows.Forms.Label();
            this.lbl_info_Location = new System.Windows.Forms.Label();
            this.pan_Error = new System.Windows.Forms.Panel();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.tt_Error = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(176, 106);
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
            this.btn_Cancel.Location = new System.Drawing.Point(257, 106);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txtb_Name
            // 
            this.txtb_Name.Location = new System.Drawing.Point(12, 29);
            this.txtb_Name.MaxLength = 256;
            this.txtb_Name.Name = "txtb_Name";
            this.txtb_Name.Size = new System.Drawing.Size(320, 21);
            this.txtb_Name.TabIndex = 2;
            this.txtb_Name.TextChanged += new System.EventHandler(this.txtb_Name_TextChanged);
            // 
            // txtb_Location
            // 
            this.txtb_Location.Location = new System.Drawing.Point(12, 76);
            this.txtb_Location.Name = "txtb_Location";
            this.txtb_Location.ReadOnly = true;
            this.txtb_Location.Size = new System.Drawing.Size(284, 21);
            this.txtb_Location.TabIndex = 3;
            // 
            // lbl_info_Name
            // 
            this.lbl_info_Name.AutoSize = true;
            this.lbl_info_Name.Location = new System.Drawing.Point(12, 9);
            this.lbl_info_Name.Name = "lbl_info_Name";
            this.lbl_info_Name.Size = new System.Drawing.Size(38, 13);
            this.lbl_info_Name.TabIndex = 4;
            this.lbl_info_Name.Text = "Name:";
            // 
            // lbl_info_Location
            // 
            this.lbl_info_Location.AutoSize = true;
            this.lbl_info_Location.Location = new System.Drawing.Point(12, 56);
            this.lbl_info_Location.Name = "lbl_info_Location";
            this.lbl_info_Location.Size = new System.Drawing.Size(51, 13);
            this.lbl_info_Location.TabIndex = 5;
            this.lbl_info_Location.Text = "Location:";
            // 
            // pan_Error
            // 
            this.pan_Error.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan_Error.BackgroundImage")));
            this.pan_Error.Location = new System.Drawing.Point(316, 7);
            this.pan_Error.Name = "pan_Error";
            this.pan_Error.Size = new System.Drawing.Size(16, 16);
            this.pan_Error.TabIndex = 6;
            this.pan_Error.Visible = false;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(302, 74);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(30, 23);
            this.btn_Browse.TabIndex = 7;
            this.btn_Browse.Text = "...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // tt_Error
            // 
            this.tt_Error.AutoPopDelay = 5000;
            this.tt_Error.InitialDelay = 500;
            this.tt_Error.ReshowDelay = 3000;
            // 
            // FormFavourite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 143);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.pan_Error);
            this.Controls.Add(this.lbl_info_Location);
            this.Controls.Add(this.lbl_info_Name);
            this.Controls.Add(this.txtb_Location);
            this.Controls.Add(this.txtb_Name);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFavourite";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favourite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txtb_Name;
        private System.Windows.Forms.TextBox txtb_Location;
        private System.Windows.Forms.Label lbl_info_Name;
        private System.Windows.Forms.Label lbl_info_Location;
        private System.Windows.Forms.Panel pan_Error;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.ToolTip tt_Error;
    }
}