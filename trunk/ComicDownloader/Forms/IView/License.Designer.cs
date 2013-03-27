namespace IView.UI.Forms
{
    partial class License
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
            this.rtxtb_License = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtb_License
            // 
            this.rtxtb_License.BackColor = System.Drawing.Color.White;
            this.rtxtb_License.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtb_License.Location = new System.Drawing.Point(0, 0);
            this.rtxtb_License.Name = "rtxtb_License";
            this.rtxtb_License.ReadOnly = true;
            this.rtxtb_License.Size = new System.Drawing.Size(394, 233);
            this.rtxtb_License.TabIndex = 0;
            this.rtxtb_License.Text = "";
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 233);
            this.Controls.Add(this.rtxtb_License);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLicense";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPL v2.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtb_License;
    }
}