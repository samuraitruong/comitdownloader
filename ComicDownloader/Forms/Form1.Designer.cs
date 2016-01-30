namespace ComicDownloader.Forms
{
    partial class Form1
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
            this.groupedCombo = new GroupedComboBox();
            this.SuspendLayout();
            // 
            // groupedCombo
            // 
            this.groupedCombo.DataSource = null;
            this.groupedCombo.FormattingEnabled = true;
            this.groupedCombo.Location = new System.Drawing.Point(106, 43);
            this.groupedCombo.Name = "groupedCombo";
            this.groupedCombo.Size = new System.Drawing.Size(121, 21);
            this.groupedCombo.TabIndex = 1;
            this.groupedCombo.SelectedIndexChanged += new System.EventHandler(this.groupedCombo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 243);
            this.Controls.Add(this.groupedCombo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupedComboBox groupedCombo;
    }
}