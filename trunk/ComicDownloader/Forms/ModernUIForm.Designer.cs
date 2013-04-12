using System.Windows.Forms.VisualStyles;
namespace ComicDownloader.Forms
{
    partial class ModernUIForm
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

            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            
           

            
            
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroTabControl1.SuspendLayout();
            
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(627, 305);
            this.metroTabControl1.TabIndex = 0;
            // 
           
           
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // ModernUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 385);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "ModernUIForm";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Comic Downloader 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.metroTabControl1.ResumeLayout(false);
            
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        
        
        //private MetroFramework.Controls.MetroTile metroTile2;


    }
}