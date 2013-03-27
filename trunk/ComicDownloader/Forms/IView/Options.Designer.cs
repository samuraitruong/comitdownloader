namespace IView.UI.Forms
{
    partial class Options
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
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tp_General = new System.Windows.Forms.TabPage();
            this.gbx_Misc = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_MaxFiles = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nud_MaxSize = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_NewWindows = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_MaxUndos = new System.Windows.Forms.NumericUpDown();
            this.gbx_Behaviour = new System.Windows.Forms.GroupBox();
            this.ckb_AutomaticUpdates = new System.Windows.Forms.CheckBox();
            this.ckb_ShowConfirmOverwriteDialog = new System.Windows.Forms.CheckBox();
            this.ckb_OpenNewWindowDoubleClick = new System.Windows.Forms.CheckBox();
            this.ckb_ShowImageChangesDialog = new System.Windows.Forms.CheckBox();
            this.ckb_ImageListTooltips = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cpic_MainDisplayColour = new IView.Controls.Library.ColourPicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_ThumbnailEffects = new System.Windows.Forms.ComboBox();
            this.ckb_HighQualityThumbnails = new System.Windows.Forms.CheckBox();
            this.lbl_MainDisplayColour = new System.Windows.Forms.Label();
            this.lbl_ColourScheme = new System.Windows.Forms.Label();
            this.cbx_ColourSchemes = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Default = new System.Windows.Forms.Button();
            this.tc_Main.SuspendLayout();
            this.tp_General.SuspendLayout();
            this.gbx_Misc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_NewWindows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxUndos)).BeginInit();
            this.gbx_Behaviour.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_Main.Controls.Add(this.tp_General);
            this.tc_Main.Controls.Add(this.tabPage1);
            this.tc_Main.Location = new System.Drawing.Point(9, 9);
            this.tc_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(406, 333);
            this.tc_Main.TabIndex = 1;
            // 
            // tp_General
            // 
            this.tp_General.Controls.Add(this.gbx_Misc);
            this.tp_General.Controls.Add(this.gbx_Behaviour);
            this.tp_General.Location = new System.Drawing.Point(4, 26);
            this.tp_General.Name = "tp_General";
            this.tp_General.Padding = new System.Windows.Forms.Padding(3);
            this.tp_General.Size = new System.Drawing.Size(398, 303);
            this.tp_General.TabIndex = 0;
            this.tp_General.Text = "General";
            this.tp_General.UseVisualStyleBackColor = true;
            // 
            // gbx_Misc
            // 
            this.gbx_Misc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Misc.Controls.Add(this.label3);
            this.gbx_Misc.Controls.Add(this.nud_MaxFiles);
            this.gbx_Misc.Controls.Add(this.label9);
            this.gbx_Misc.Controls.Add(this.nud_MaxSize);
            this.gbx_Misc.Controls.Add(this.label10);
            this.gbx_Misc.Controls.Add(this.label6);
            this.gbx_Misc.Controls.Add(this.nud_NewWindows);
            this.gbx_Misc.Controls.Add(this.label5);
            this.gbx_Misc.Controls.Add(this.label2);
            this.gbx_Misc.Controls.Add(this.label4);
            this.gbx_Misc.Controls.Add(this.label1);
            this.gbx_Misc.Controls.Add(this.nud_MaxUndos);
            this.gbx_Misc.Location = new System.Drawing.Point(3, 162);
            this.gbx_Misc.Name = "gbx_Misc";
            this.gbx_Misc.Size = new System.Drawing.Size(389, 139);
            this.gbx_Misc.TabIndex = 72;
            this.gbx_Misc.TabStop = false;
            this.gbx_Misc.Text = "Misc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "Do not open more than:";
            // 
            // nud_MaxFiles
            // 
            this.nud_MaxFiles.Location = new System.Drawing.Point(198, 25);
            this.nud_MaxFiles.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_MaxFiles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MaxFiles.Name = "nud_MaxFiles";
            this.nud_MaxFiles.Size = new System.Drawing.Size(61, 24);
            this.nud_MaxFiles.TabIndex = 63;
            this.nud_MaxFiles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 70;
            this.label9.Text = "new windows.";
            // 
            // nud_MaxSize
            // 
            this.nud_MaxSize.Location = new System.Drawing.Point(198, 52);
            this.nud_MaxSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_MaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MaxSize.Name = "nud_MaxSize";
            this.nud_MaxSize.Size = new System.Drawing.Size(61, 24);
            this.nud_MaxSize.TabIndex = 64;
            this.nud_MaxSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 17);
            this.label10.TabIndex = 69;
            this.label10.Text = "Do not open more than:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "megabyte(s).";
            // 
            // nud_NewWindows
            // 
            this.nud_NewWindows.Location = new System.Drawing.Point(198, 106);
            this.nud_NewWindows.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_NewWindows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_NewWindows.Name = "nud_NewWindows";
            this.nud_NewWindows.Size = new System.Drawing.Size(61, 24);
            this.nud_NewWindows.TabIndex = 68;
            this.nud_NewWindows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 17);
            this.label5.TabIndex = 61;
            this.label5.Text = "Do not open files larger than:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 67;
            this.label2.Text = "undo entries.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 60;
            this.label4.Text = "files.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 66;
            this.label1.Text = "Do not create more than:";
            // 
            // nud_MaxUndos
            // 
            this.nud_MaxUndos.Location = new System.Drawing.Point(198, 79);
            this.nud_MaxUndos.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_MaxUndos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MaxUndos.Name = "nud_MaxUndos";
            this.nud_MaxUndos.Size = new System.Drawing.Size(61, 24);
            this.nud_MaxUndos.TabIndex = 65;
            this.nud_MaxUndos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbx_Behaviour
            // 
            this.gbx_Behaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Behaviour.Controls.Add(this.ckb_AutomaticUpdates);
            this.gbx_Behaviour.Controls.Add(this.ckb_ShowConfirmOverwriteDialog);
            this.gbx_Behaviour.Controls.Add(this.ckb_OpenNewWindowDoubleClick);
            this.gbx_Behaviour.Controls.Add(this.ckb_ShowImageChangesDialog);
            this.gbx_Behaviour.Controls.Add(this.ckb_ImageListTooltips);
            this.gbx_Behaviour.Location = new System.Drawing.Point(3, 6);
            this.gbx_Behaviour.Name = "gbx_Behaviour";
            this.gbx_Behaviour.Size = new System.Drawing.Size(389, 150);
            this.gbx_Behaviour.TabIndex = 71;
            this.gbx_Behaviour.TabStop = false;
            this.gbx_Behaviour.Text = "Behaviour";
            // 
            // ckb_AutomaticUpdates
            // 
            this.ckb_AutomaticUpdates.AutoSize = true;
            this.ckb_AutomaticUpdates.Location = new System.Drawing.Point(6, 29);
            this.ckb_AutomaticUpdates.Name = "ckb_AutomaticUpdates";
            this.ckb_AutomaticUpdates.Size = new System.Drawing.Size(285, 21);
            this.ckb_AutomaticUpdates.TabIndex = 30;
            this.ckb_AutomaticUpdates.Text = "Check for updates on application startup";
            this.ckb_AutomaticUpdates.UseVisualStyleBackColor = true;
            // 
            // ckb_ShowConfirmOverwriteDialog
            // 
            this.ckb_ShowConfirmOverwriteDialog.AutoSize = true;
            this.ckb_ShowConfirmOverwriteDialog.Location = new System.Drawing.Point(6, 98);
            this.ckb_ShowConfirmOverwriteDialog.Name = "ckb_ShowConfirmOverwriteDialog";
            this.ckb_ShowConfirmOverwriteDialog.Size = new System.Drawing.Size(308, 21);
            this.ckb_ShowConfirmOverwriteDialog.TabIndex = 32;
            this.ckb_ShowConfirmOverwriteDialog.Text = "Show dialog when overwriting an existing file";
            this.ckb_ShowConfirmOverwriteDialog.UseVisualStyleBackColor = true;
            // 
            // ckb_OpenNewWindowDoubleClick
            // 
            this.ckb_OpenNewWindowDoubleClick.AutoSize = true;
            this.ckb_OpenNewWindowDoubleClick.Location = new System.Drawing.Point(6, 75);
            this.ckb_OpenNewWindowDoubleClick.Name = "ckb_OpenNewWindowDoubleClick";
            this.ckb_OpenNewWindowDoubleClick.Size = new System.Drawing.Size(316, 21);
            this.ckb_OpenNewWindowDoubleClick.TabIndex = 31;
            this.ckb_OpenNewWindowDoubleClick.Text = "Open a new window on image list double click";
            this.ckb_OpenNewWindowDoubleClick.UseVisualStyleBackColor = true;
            // 
            // ckb_ShowImageChangesDialog
            // 
            this.ckb_ShowImageChangesDialog.AutoSize = true;
            this.ckb_ShowImageChangesDialog.Location = new System.Drawing.Point(6, 121);
            this.ckb_ShowImageChangesDialog.Name = "ckb_ShowImageChangesDialog";
            this.ckb_ShowImageChangesDialog.Size = new System.Drawing.Size(389, 21);
            this.ckb_ShowImageChangesDialog.TabIndex = 33;
            this.ckb_ShowImageChangesDialog.Text = "Show dialog when changes have been made to an image";
            this.ckb_ShowImageChangesDialog.UseVisualStyleBackColor = true;
            // 
            // ckb_ImageListTooltips
            // 
            this.ckb_ImageListTooltips.AutoSize = true;
            this.ckb_ImageListTooltips.Location = new System.Drawing.Point(6, 52);
            this.ckb_ImageListTooltips.Name = "ckb_ImageListTooltips";
            this.ckb_ImageListTooltips.Size = new System.Drawing.Size(203, 21);
            this.ckb_ImageListTooltips.TabIndex = 34;
            this.ckb_ImageListTooltips.Text = "Show image list info tooltips";
            this.ckb_ImageListTooltips.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cpic_MainDisplayColour);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cbx_ThumbnailEffects);
            this.tabPage1.Controls.Add(this.ckb_HighQualityThumbnails);
            this.tabPage1.Controls.Add(this.lbl_MainDisplayColour);
            this.tabPage1.Controls.Add(this.lbl_ColourScheme);
            this.tabPage1.Controls.Add(this.cbx_ColourSchemes);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(398, 303);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Appearance";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cpic_MainDisplayColour
            // 
            this.cpic_MainDisplayColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpic_MainDisplayColour.Location = new System.Drawing.Point(3, 169);
            this.cpic_MainDisplayColour.Name = "cpic_MainDisplayColour";
            this.cpic_MainDisplayColour.SelectedColour = System.Drawing.Color.White;
            this.cpic_MainDisplayColour.Size = new System.Drawing.Size(280, 30);
            this.cpic_MainDisplayColour.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "Thumbnail effect:";
            // 
            // cbx_ThumbnailEffects
            // 
            this.cbx_ThumbnailEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ThumbnailEffects.FormattingEnabled = true;
            this.cbx_ThumbnailEffects.Location = new System.Drawing.Point(3, 84);
            this.cbx_ThumbnailEffects.Name = "cbx_ThumbnailEffects";
            this.cbx_ThumbnailEffects.Size = new System.Drawing.Size(280, 25);
            this.cbx_ThumbnailEffects.TabIndex = 54;
            // 
            // ckb_HighQualityThumbnails
            // 
            this.ckb_HighQualityThumbnails.AutoSize = true;
            this.ckb_HighQualityThumbnails.Location = new System.Drawing.Point(3, 115);
            this.ckb_HighQualityThumbnails.Name = "ckb_HighQualityThumbnails";
            this.ckb_HighQualityThumbnails.Size = new System.Drawing.Size(196, 21);
            this.ckb_HighQualityThumbnails.TabIndex = 53;
            this.ckb_HighQualityThumbnails.Text = "Use high quality thumbnails";
            this.ckb_HighQualityThumbnails.UseVisualStyleBackColor = true;
            // 
            // lbl_MainDisplayColour
            // 
            this.lbl_MainDisplayColour.AutoSize = true;
            this.lbl_MainDisplayColour.Location = new System.Drawing.Point(3, 149);
            this.lbl_MainDisplayColour.Name = "lbl_MainDisplayColour";
            this.lbl_MainDisplayColour.Size = new System.Drawing.Size(160, 17);
            this.lbl_MainDisplayColour.TabIndex = 43;
            this.lbl_MainDisplayColour.Text = "Main display back colour:";
            // 
            // lbl_ColourScheme
            // 
            this.lbl_ColourScheme.AutoSize = true;
            this.lbl_ColourScheme.Location = new System.Drawing.Point(3, 16);
            this.lbl_ColourScheme.Name = "lbl_ColourScheme";
            this.lbl_ColourScheme.Size = new System.Drawing.Size(104, 17);
            this.lbl_ColourScheme.TabIndex = 41;
            this.lbl_ColourScheme.Text = "Colour scheme:";
            // 
            // cbx_ColourSchemes
            // 
            this.cbx_ColourSchemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ColourSchemes.FormattingEnabled = true;
            this.cbx_ColourSchemes.Location = new System.Drawing.Point(3, 36);
            this.cbx_ColourSchemes.Name = "cbx_ColourSchemes";
            this.cbx_ColourSchemes.Size = new System.Drawing.Size(280, 25);
            this.cbx_ColourSchemes.TabIndex = 40;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(256, 345);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 25);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "&OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(337, 345);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Default
            // 
            this.btn_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Default.Location = new System.Drawing.Point(12, 345);
            this.btn_Default.Name = "btn_Default";
            this.btn_Default.Size = new System.Drawing.Size(75, 25);
            this.btn_Default.TabIndex = 4;
            this.btn_Default.Text = "&Default";
            this.btn_Default.UseVisualStyleBackColor = true;
            this.btn_Default.Click += new System.EventHandler(this.btn_Default_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 382);
            this.Controls.Add(this.btn_Default);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tc_Main);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.tc_Main.ResumeLayout(false);
            this.tp_General.ResumeLayout(false);
            this.gbx_Misc.ResumeLayout(false);
            this.gbx_Misc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_NewWindows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxUndos)).EndInit();
            this.gbx_Behaviour.ResumeLayout(false);
            this.gbx_Behaviour.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tp_General;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Default;
        private System.Windows.Forms.GroupBox gbx_Misc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_MaxFiles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nud_MaxSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_NewWindows;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_MaxUndos;
        private System.Windows.Forms.GroupBox gbx_Behaviour;
        private System.Windows.Forms.CheckBox ckb_AutomaticUpdates;
        private System.Windows.Forms.CheckBox ckb_ShowConfirmOverwriteDialog;
        private System.Windows.Forms.CheckBox ckb_OpenNewWindowDoubleClick;
        private System.Windows.Forms.CheckBox ckb_ShowImageChangesDialog;
        private System.Windows.Forms.CheckBox ckb_ImageListTooltips;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_ThumbnailEffects;
        private System.Windows.Forms.CheckBox ckb_HighQualityThumbnails;
        private System.Windows.Forms.Label lbl_MainDisplayColour;
        private System.Windows.Forms.Label lbl_ColourScheme;
        private System.Windows.Forms.ComboBox cbx_ColourSchemes;
        private Controls.Library.ColourPicker cpic_MainDisplayColour;

    }
}