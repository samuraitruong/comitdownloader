﻿namespace ComicDownloader
{
    partial class AppMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMainForm));
            this.mdiTabStrip1 = new Cx.Windows.Forms.MdiTabStrip();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAddNewTTT = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnVCAdd = new System.Windows.Forms.RibbonButton();
            this.bntRefeshList = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.txtVCHost = new System.Windows.Forms.RibbonTextBox();
            this.txtVSList = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.btnAddTTTGeneric = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.btnVechaiForm = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // mdiTabStrip1
            // 
            this.mdiTabStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mdiTabStrip1.Location = new System.Drawing.Point(0, 110);
            this.mdiTabStrip1.Name = "mdiTabStrip1";
            this.mdiTabStrip1.SelectedTab = null;
            this.mdiTabStrip1.ShowItemToolTips = false;
            this.mdiTabStrip1.Size = new System.Drawing.Size(731, 25);
            this.mdiTabStrip1.TabIndex = 3;
            this.mdiTabStrip1.Text = "mdiTabStrip1";
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Items.Add(this.ribbonButton1);
            this.ribbon1.QuickAcessToolbar.Items.Add(this.ribbonButton2);
            this.ribbon1.Size = new System.Drawing.Size(731, 110);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.MaximumSize = new System.Drawing.Size(0, 0);
            this.ribbonOrbMenuItem1.MinimumSize = new System.Drawing.Size(0, 0);
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "&Exit";
            this.ribbonOrbMenuItem1.Click += new System.EventHandler(this.ribbonOrbMenuItem1_Click);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.MaximumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.MinimumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.MaximumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton2.MinimumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel5);
            this.ribbonTab1.Text = "Home";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnAddNewTTT);
            this.ribbonPanel1.Text = "truyentranhtuan.com";
            this.ribbonPanel1.Click += new System.EventHandler(this.ribbonPanel1_Click);
            // 
            // btnAddNewTTT
            // 
            this.btnAddNewTTT.Image = global::ComicDownloader.Properties.Resources._1363939449_netvibes;
            this.btnAddNewTTT.MaximumSize = new System.Drawing.Size(0, 0);
            this.btnAddNewTTT.MinimumSize = new System.Drawing.Size(0, 0);
            this.btnAddNewTTT.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAddNewTTT.SmallImage")));
            this.btnAddNewTTT.Text = "";
            this.btnAddNewTTT.Click += new System.EventHandler(this.btnAddNewTTT_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Text = "group2";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnVCAdd);
            this.ribbonPanel2.Items.Add(this.bntRefeshList);
            this.ribbonPanel2.Text = "Download";
            // 
            // btnVCAdd
            // 
            this.btnVCAdd.Image = global::ComicDownloader.Properties.Resources._1363942937_ark2;
            this.btnVCAdd.MaximumSize = new System.Drawing.Size(0, 0);
            this.btnVCAdd.MinimumSize = new System.Drawing.Size(0, 0);
            this.btnVCAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnVCAdd.SmallImage")));
            this.btnVCAdd.Click += new System.EventHandler(this.btnVCAdd_Click);
            // 
            // bntRefeshList
            // 
            this.bntRefeshList.Image = global::ComicDownloader.Properties.Resources._1363960953_adept_update;
            this.bntRefeshList.MaximumSize = new System.Drawing.Size(0, 0);
            this.bntRefeshList.MinimumSize = new System.Drawing.Size(0, 0);
            this.bntRefeshList.SmallImage = ((System.Drawing.Image)(resources.GetObject("bntRefeshList.SmallImage")));
            this.bntRefeshList.Click += new System.EventHandler(this.bntRefeshList_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.txtVCHost);
            this.ribbonPanel3.Items.Add(this.txtVSList);
            this.ribbonPanel3.Text = "Infomation";
            // 
            // txtVCHost
            // 
            this.txtVCHost.Text = "Host";
            this.txtVCHost.TextBoxText = "http://vechai.info";
            this.txtVCHost.TextBoxWidth = 150;
            this.txtVCHost.Value = "http://vechai.info";
            // 
            // txtVSList
            // 
            this.txtVSList.Text = "List URL";
            this.txtVSList.TextBoxText = "http://vechai.info/danh-sach/";
            this.txtVSList.TextBoxWidth = 150;
            this.txtVSList.Value = "http://vechai.info/danh-sach/";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel4);
            this.ribbonTab3.Text = "TO BE USED";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.btnAddTTTGeneric);
            this.ribbonPanel4.Text = "Truyen Tranh Tuan";
            // 
            // btnAddTTTGeneric
            // 
            this.btnAddTTTGeneric.Image = global::ComicDownloader.Properties.Resources._1363939449_netvibes;
            this.btnAddTTTGeneric.MaximumSize = new System.Drawing.Size(0, 0);
            this.btnAddTTTGeneric.MinimumSize = new System.Drawing.Size(0, 0);
            this.btnAddTTTGeneric.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAddTTTGeneric.SmallImage")));
            this.btnAddTTTGeneric.Click += new System.EventHandler(this.btnAddTTTGeneric_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.btnVechaiForm);
            this.ribbonPanel5.Text = "vechai.info";
            // 
            // btnVechaiForm
            // 
            this.btnVechaiForm.Image = global::ComicDownloader.Properties.Resources._1363942937_ark2;
            this.btnVechaiForm.MaximumSize = new System.Drawing.Size(0, 0);
            this.btnVechaiForm.MinimumSize = new System.Drawing.Size(0, 0);
            this.btnVechaiForm.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnVechaiForm.SmallImage")));
            this.btnVechaiForm.Click += new System.EventHandler(this.btnVechaiForm_Click);
            // 
            // AppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 273);
            this.Controls.Add(this.mdiTabStrip1);
            this.Controls.Add(this.ribbon1);
            this.IsMdiContainer = true;
            this.Name = "AppMainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonButton btnAddNewTTT;
        public System.Windows.Forms.RibbonPanel ribbonPanel1;
        private Cx.Windows.Forms.MdiTabStrip mdiTabStrip1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnVCAdd;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonTextBox txtVCHost;
        private System.Windows.Forms.RibbonTextBox txtVSList;
        private System.Windows.Forms.RibbonButton bntRefeshList;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton btnAddTTTGeneric;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton btnVechaiForm;
    }
}