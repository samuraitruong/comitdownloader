namespace IView.Controls.Library
{
    partial class PropertiesPanel
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
            this.components = new System.ComponentModel.Container();
            this.pg_Info = new System.Windows.Forms.PropertyGrid();
            this.cms_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_PropertiesToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_PropertiesHelpPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Histogram = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AnchorHistogram = new System.Windows.Forms.ToolStripMenuItem();
            this.sc_Main = new System.Windows.Forms.SplitContainer();
            this.hp_Histogram = new IView.Controls.Library.Histogram();
            this.cms_Main.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.sc_Main)).BeginInit();
            this.sc_Main.Panel1.SuspendLayout();
            this.sc_Main.Panel2.SuspendLayout();
            this.sc_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pg_Info
            // 
            this.pg_Info.ContextMenuStrip = this.cms_Main;
            this.pg_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg_Info.HelpBackColor = System.Drawing.Color.WhiteSmoke;
            this.pg_Info.LineColor = System.Drawing.Color.WhiteSmoke;
            this.pg_Info.Location = new System.Drawing.Point(0, 0);
            this.pg_Info.Name = "pg_Info";
            this.pg_Info.Size = new System.Drawing.Size(198, 195);
            this.pg_Info.TabIndex = 0;
            // 
            // cms_Main
            // 
            this.cms_Main.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_PropertiesToolbar,
            this.tsmi_PropertiesHelpPanel,
            this.toolStripSeparator2,
            this.tsmi_Histogram,
            this.tsmi_AnchorHistogram});
            this.cms_Main.Name = "cms_Main";
            this.cms_Main.Size = new System.Drawing.Size(177, 98);
            this.cms_Main.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Main_Opening);
            // 
            // tsmi_PropertiesToolbar
            // 
            this.tsmi_PropertiesToolbar.Name = "tsmi_PropertiesToolbar";
            this.tsmi_PropertiesToolbar.Size = new System.Drawing.Size(176, 22);
            this.tsmi_PropertiesToolbar.Text = "Properties Toolbar";
            this.tsmi_PropertiesToolbar.Click += new System.EventHandler(this.tsmi_PropertiesToolbar_Click);
            // 
            // tsmi_PropertiesHelpPanel
            // 
            this.tsmi_PropertiesHelpPanel.Name = "tsmi_PropertiesHelpPanel";
            this.tsmi_PropertiesHelpPanel.Size = new System.Drawing.Size(176, 22);
            this.tsmi_PropertiesHelpPanel.Text = "Properties Help Panel";
            this.tsmi_PropertiesHelpPanel.Click += new System.EventHandler(this.tsmi_PropertiesHelpPanel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // tsmi_Histogram
            // 
            this.tsmi_Histogram.Name = "tsmi_Histogram";
            this.tsmi_Histogram.Size = new System.Drawing.Size(176, 22);
            this.tsmi_Histogram.Text = "Histogram";
            this.tsmi_Histogram.Click += new System.EventHandler(this.tsmi_Histogram_Click);
            // 
            // tsmi_AnchorHistogram
            // 
            this.tsmi_AnchorHistogram.Name = "tsmi_AnchorHistogram";
            this.tsmi_AnchorHistogram.Size = new System.Drawing.Size(176, 22);
            this.tsmi_AnchorHistogram.Text = "Anchor Histogram";
            this.tsmi_AnchorHistogram.Click += new System.EventHandler(this.tsmi_AnchorHistogram_Click);
            // 
            // sc_Main
            // 
            this.sc_Main.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sc_Main.Location = new System.Drawing.Point(1, 0);
            this.sc_Main.Name = "sc_Main";
            this.sc_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc_Main.Panel1
            // 
            this.sc_Main.Panel1.Controls.Add(this.pg_Info);
            // 
            // sc_Main.Panel2
            // 
            this.sc_Main.Panel2.Controls.Add(this.hp_Histogram);
            this.sc_Main.Panel2MinSize = 100;
            this.sc_Main.Size = new System.Drawing.Size(198, 299);
            this.sc_Main.SplitterDistance = 195;
            this.sc_Main.TabIndex = 1;
            // 
            // hp_Histogram
            // 
            this.hp_Histogram.AutoRefreshEnabled = false;
            this.hp_Histogram.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hp_Histogram.ContextMenuStrip = this.cms_Main;
            this.hp_Histogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hp_Histogram.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hp_Histogram.Location = new System.Drawing.Point(0, 0);
            this.hp_Histogram.Name = "hp_Histogram";
            this.hp_Histogram.Size = new System.Drawing.Size(198, 100);
            this.hp_Histogram.TabIndex = 0;
            this.hp_Histogram.UpdateRequested += new System.EventHandler<System.EventArgs>(this.hp_Histogram_UpdateRequested);
            // 
            // PropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc_Main);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PropertiesPanel";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.Size = new System.Drawing.Size(200, 300);
            this.cms_Main.ResumeLayout(false);
            this.sc_Main.Panel1.ResumeLayout(false);
            this.sc_Main.Panel2.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.sc_Main)).EndInit();
            this.sc_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pg_Info;
        private System.Windows.Forms.SplitContainer sc_Main;
        private Histogram hp_Histogram;
        private System.Windows.Forms.ContextMenuStrip cms_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AnchorHistogram;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PropertiesToolbar;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PropertiesHelpPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Histogram;

    }
}
