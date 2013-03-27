namespace IView.Controls.Library
{
    partial class Histogram
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
            if (disposing)
            {
                if (m_oHost != null)
                {
                    m_oHost.Dispose();
                    m_oHost = null;
                }
            }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Histogram));
            this.tt_HistogramData = new System.Windows.Forms.ToolTip(this.components);
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.tscbx_Channels = new System.Windows.Forms.ToolStripComboBox();
            this.tsb_Refresh = new System.Windows.Forms.ToolStripButton();
            this.pan_Histogram = new IView.Controls.Library.BufferedPanel();
            this.ckb_AutoRefresh = new System.Windows.Forms.CheckBox();
            this.ts_Main.SuspendLayout();
            this.pan_Histogram.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts_Main
            // 
            this.ts_Main.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ts_Main.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbx_Channels,
            this.tsb_Refresh});
            this.ts_Main.Location = new System.Drawing.Point(0, 0);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts_Main.Size = new System.Drawing.Size(200, 25);
            this.ts_Main.TabIndex = 1;
            this.ts_Main.Text = "toolStrip1";
            // 
            // tscbx_Channels
            // 
            this.tscbx_Channels.AutoToolTip = true;
            this.tscbx_Channels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbx_Channels.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbx_Channels.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tscbx_Channels.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tscbx_Channels.Name = "tscbx_Channels";
            this.tscbx_Channels.Size = new System.Drawing.Size(75, 24);
            this.tscbx_Channels.SelectedIndexChanged += new System.EventHandler(this.tscbx_Channels_SelectedIndexChanged);
            // 
            // tsb_Refresh
            // 
            this.tsb_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Refresh.Image")));
            this.tsb_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Refresh.Name = "tsb_Refresh";
            this.tsb_Refresh.Size = new System.Drawing.Size(23, 22);
            this.tsb_Refresh.Text = "Refresh";
            this.tsb_Refresh.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // pan_Histogram
            // 
            this.pan_Histogram.BackColor = System.Drawing.Color.Black;
            this.pan_Histogram.Controls.Add(this.ckb_AutoRefresh);
            this.pan_Histogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Histogram.Location = new System.Drawing.Point(0, 25);
            this.pan_Histogram.Name = "pan_Histogram";
            this.pan_Histogram.Size = new System.Drawing.Size(200, 75);
            this.pan_Histogram.TabIndex = 0;
            this.pan_Histogram.SizeChanged += new System.EventHandler(this.pan_Histogram_SizeChanged);
            this.pan_Histogram.Paint += new System.Windows.Forms.PaintEventHandler(this.pan_Histogram_Paint);
            this.pan_Histogram.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pan_Histogram_MouseClick);
            this.pan_Histogram.MouseLeave += new System.EventHandler(this.pan_Histogram_MouseLeave);
            // 
            // ckb_AutoRefresh
            // 
            this.ckb_AutoRefresh.AutoSize = true;
            this.ckb_AutoRefresh.Location = new System.Drawing.Point(3, 3);
            this.ckb_AutoRefresh.Name = "ckb_AutoRefresh";
            this.ckb_AutoRefresh.Size = new System.Drawing.Size(90, 17);
            this.ckb_AutoRefresh.TabIndex = 0;
            this.ckb_AutoRefresh.Text = "Auto Refresh";
            this.ckb_AutoRefresh.UseVisualStyleBackColor = true;
            // 
            // Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pan_Histogram);
            this.Controls.Add(this.ts_Main);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Histogram";
            this.Size = new System.Drawing.Size(200, 100);
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.pan_Histogram.ResumeLayout(false);
            this.pan_Histogram.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BufferedPanel pan_Histogram;
        private System.Windows.Forms.ToolTip tt_HistogramData;
        private System.Windows.Forms.ToolStrip ts_Main;
        private System.Windows.Forms.ToolStripComboBox tscbx_Channels;
        private System.Windows.Forms.ToolStripButton tsb_Refresh;
        private System.Windows.Forms.CheckBox ckb_AutoRefresh;
    }
}
