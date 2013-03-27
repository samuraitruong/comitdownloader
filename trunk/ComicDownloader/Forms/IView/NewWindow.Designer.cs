namespace IView.UI.Forms
{
    partial class NewWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewWindow));
            this.ss_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Dimensions = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsddb_Zoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.cms_Zoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_zoom_800 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_zoom_400 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_zoom_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_zoom_150 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_zoom_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_zoom_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_zoom_25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_zoom_AutoScale = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ImageBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_AutoScale = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.imgbx_DisplayImage = new IView.Controls.Library.ImageBox();
            this.ss_Main.SuspendLayout();
            this.cms_Zoom.SuspendLayout();
            this.cms_ImageBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ss_Main
            // 
            this.ss_Main.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tssl_Dimensions,
            this.tsddb_Zoom});
            this.ss_Main.Location = new System.Drawing.Point(0, 339);
            this.ss_Main.Name = "ss_Main";
            this.ss_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ss_Main.Size = new System.Drawing.Size(484, 23);
            this.ss_Main.TabIndex = 0;
            this.ss_Main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(296, 18);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Ready";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssl_Dimensions
            // 
            this.tssl_Dimensions.Image = ((System.Drawing.Image)(resources.GetObject("tssl_Dimensions.Image")));
            this.tssl_Dimensions.Margin = new System.Windows.Forms.Padding(0, 3, 30, 2);
            this.tssl_Dimensions.Name = "tssl_Dimensions";
            this.tssl_Dimensions.Size = new System.Drawing.Size(47, 18);
            this.tssl_Dimensions.Text = "0 x 0";
            // 
            // tsddb_Zoom
            // 
            this.tsddb_Zoom.DropDown = this.cms_Zoom;
            this.tsddb_Zoom.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_Zoom.Image")));
            this.tsddb_Zoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_Zoom.Margin = new System.Windows.Forms.Padding(0, 2, 30, 1);
            this.tsddb_Zoom.Name = "tsddb_Zoom";
            this.tsddb_Zoom.ShowDropDownArrow = false;
            this.tsddb_Zoom.Size = new System.Drawing.Size(66, 20);
            this.tsddb_Zoom.Text = "100.0%";
            this.tsddb_Zoom.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // cms_Zoom
            // 
            this.cms_Zoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_Zoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_zoom_800,
            this.tsmi_zoom_400,
            this.tsmi_zoom_200,
            this.tsmi_zoom_150,
            this.tsmi_zoom_100,
            this.tsmi_zoom_50,
            this.tsmi_zoom_25,
            this.toolStripSeparator1,
            this.tsmi_zoom_AutoScale});
            this.cms_Zoom.Name = "cms_Zoom";
            this.cms_Zoom.OwnerItem = this.tsddb_Zoom;
            this.cms_Zoom.Size = new System.Drawing.Size(126, 186);
            this.cms_Zoom.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Zoom_Opening);
            // 
            // tsmi_zoom_800
            // 
            this.tsmi_zoom_800.Name = "tsmi_zoom_800";
            this.tsmi_zoom_800.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_800.Text = "800%";
            this.tsmi_zoom_800.Click += new System.EventHandler(this.tsmi_zoom_Generic_Click);
            // 
            // tsmi_zoom_400
            // 
            this.tsmi_zoom_400.Name = "tsmi_zoom_400";
            this.tsmi_zoom_400.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_400.Text = "400%";
            this.tsmi_zoom_400.Click += new System.EventHandler(this.tsmi_zoom_Generic_Click);
            // 
            // tsmi_zoom_200
            // 
            this.tsmi_zoom_200.Name = "tsmi_zoom_200";
            this.tsmi_zoom_200.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_200.Text = "200%";
            this.tsmi_zoom_200.Click += new System.EventHandler(this.tsmi_zoom_Generic_Click);
            // 
            // tsmi_zoom_150
            // 
            this.tsmi_zoom_150.Name = "tsmi_zoom_150";
            this.tsmi_zoom_150.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_150.Text = "150%";
            this.tsmi_zoom_150.Click += new System.EventHandler(this.tsmi_zoom_Generic_Click);
            // 
            // tsmi_zoom_100
            // 
            this.tsmi_zoom_100.Name = "tsmi_zoom_100";
            this.tsmi_zoom_100.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_100.Text = "100%";
            this.tsmi_zoom_100.Click += new System.EventHandler(this.tsmi_zoom_Generic_Click);
            // 
            // tsmi_zoom_50
            // 
            this.tsmi_zoom_50.Name = "tsmi_zoom_50";
            this.tsmi_zoom_50.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_50.Text = "50%";
            this.tsmi_zoom_50.Click += new System.EventHandler(this.tsmi_zoom_Generic_Click);
            // 
            // tsmi_zoom_25
            // 
            this.tsmi_zoom_25.Name = "tsmi_zoom_25";
            this.tsmi_zoom_25.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_25.Text = "25%";
            this.tsmi_zoom_25.Click += new System.EventHandler(this.tsmi_zoom_Generic_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // tsmi_zoom_AutoScale
            // 
            this.tsmi_zoom_AutoScale.Name = "tsmi_zoom_AutoScale";
            this.tsmi_zoom_AutoScale.Size = new System.Drawing.Size(125, 22);
            this.tsmi_zoom_AutoScale.Text = "Auto Scale";
            this.tsmi_zoom_AutoScale.Click += new System.EventHandler(this.tsmi_zoom_AutoScale_Click);
            // 
            // cms_ImageBox
            // 
            this.cms_ImageBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_ImageBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Copy,
            this.toolStripSeparator2,
            this.tsmi_AutoScale,
            this.toolStripSeparator3,
            this.tsmi_Close});
            this.cms_ImageBox.Name = "cms_ImageBox";
            this.cms_ImageBox.Size = new System.Drawing.Size(141, 82);
            this.cms_ImageBox.Opening += new System.ComponentModel.CancelEventHandler(this.cms_ImageBox_Opening);
            // 
            // tsmi_Copy
            // 
            this.tsmi_Copy.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Copy.Image")));
            this.tsmi_Copy.Name = "tsmi_Copy";
            this.tsmi_Copy.Size = new System.Drawing.Size(140, 22);
            this.tsmi_Copy.Text = "Copy";
            this.tsmi_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmi_AutoScale
            // 
            this.tsmi_AutoScale.Name = "tsmi_AutoScale";
            this.tsmi_AutoScale.Size = new System.Drawing.Size(140, 22);
            this.tsmi_AutoScale.Text = "Auto Scale";
            this.tsmi_AutoScale.Click += new System.EventHandler(this.tsmi_AutoScale_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmi_Close
            // 
            this.tsmi_Close.Name = "tsmi_Close";
            this.tsmi_Close.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmi_Close.Size = new System.Drawing.Size(140, 22);
            this.tsmi_Close.Text = "Close";
            this.tsmi_Close.Click += new System.EventHandler(this.tsmi_Close_Click);
            // 
            // imgbx_DisplayImage
            // 
            this.imgbx_DisplayImage.AllowMouseMove = false;
            this.imgbx_DisplayImage.AllowMouseResize = false;
            this.imgbx_DisplayImage.BackColor = System.Drawing.Color.White;
            this.imgbx_DisplayImage.ContextMenuStrip = this.cms_ImageBox;
            this.imgbx_DisplayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgbx_DisplayImage.FocusControl = false;
            this.imgbx_DisplayImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgbx_DisplayImage.ImageBoxHeight = 0;
            this.imgbx_DisplayImage.ImageBoxRectangle = new System.Drawing.Rectangle(0, 0, 1, 0);
            this.imgbx_DisplayImage.ImageBoxSize = new System.Drawing.Size(1, 0);
            this.imgbx_DisplayImage.ImageBoxSmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.imgbx_DisplayImage.ImageBoxVisible = false;
            this.imgbx_DisplayImage.ImageBoxWidth = 1;
            this.imgbx_DisplayImage.Location = new System.Drawing.Point(0, 0);
            this.imgbx_DisplayImage.Name = "imgbx_DisplayImage";
            this.imgbx_DisplayImage.Size = new System.Drawing.Size(484, 339);
            this.imgbx_DisplayImage.TabIndex = 1;
            this.imgbx_DisplayImage.ImageBoxImageLoaded += new System.EventHandler<IView.Controls.Library.ImageBoxEventArgs>(this.imgbx_DisplayImage_ImageBoxImageLoaded);
            this.imgbx_DisplayImage.SizeChanged += new System.EventHandler(this.imgbx_DisplayImage_SizeChanged);
            // 
            // FormNewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.imgbx_DisplayImage);
            this.Controls.Add(this.ss_Main);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "FormNewWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Window";
            this.ss_Main.ResumeLayout(false);
            this.ss_Main.PerformLayout();
            this.cms_Zoom.ResumeLayout(false);
            this.cms_ImageBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ss_Main;
        private Controls.Library.ImageBox imgbx_DisplayImage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Dimensions;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_Zoom;
        private System.Windows.Forms.ContextMenuStrip cms_Zoom;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_800;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_400;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_200;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_150;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_100;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_50;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zoom_AutoScale;
        private System.Windows.Forms.ContextMenuStrip cms_ImageBox;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AutoScale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}