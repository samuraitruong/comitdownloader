namespace IView.UI.Forms
{
    partial class ProcessingDialog
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
                CleanUp();

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
            this.gbx_Before = new System.Windows.Forms.GroupBox();
            this.gbx_After = new System.Windows.Forms.GroupBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tp_BrightnessContrast = new System.Windows.Forms.TabPage();
            this.lbl_Brightness = new System.Windows.Forms.Label();
            this.tbar_Brightness = new System.Windows.Forms.TrackBar();
            this.nud_Contrast = new System.Windows.Forms.NumericUpDown();
            this.nud_Brightness = new System.Windows.Forms.NumericUpDown();
            this.tbar_Contrast = new System.Windows.Forms.TrackBar();
            this.lbl_Contrast = new System.Windows.Forms.Label();
            this.tp_ColourBalance = new System.Windows.Forms.TabPage();
            this.lbl_Blue = new System.Windows.Forms.Label();
            this.lbl_Red = new System.Windows.Forms.Label();
            this.nud_Green = new System.Windows.Forms.NumericUpDown();
            this.nud_Blue = new System.Windows.Forms.NumericUpDown();
            this.tbar_Green = new System.Windows.Forms.TrackBar();
            this.tbar_Red = new System.Windows.Forms.TrackBar();
            this.lbl_Green = new System.Windows.Forms.Label();
            this.tbar_Blue = new System.Windows.Forms.TrackBar();
            this.nud_Red = new System.Windows.Forms.NumericUpDown();
            this.tp_Gamma = new System.Windows.Forms.TabPage();
            this.lbl_Gamma = new System.Windows.Forms.Label();
            this.nud_Gamma = new System.Windows.Forms.NumericUpDown();
            this.tbar_Gamma = new System.Windows.Forms.TrackBar();
            this.tp_Transparency = new System.Windows.Forms.TabPage();
            this.lbl_Threshold = new System.Windows.Forms.Label();
            this.nud_Threshold = new System.Windows.Forms.NumericUpDown();
            this.tbar_Threshold = new System.Windows.Forms.TrackBar();
            this.lbl_Transparency = new System.Windows.Forms.Label();
            this.nud_Transparency = new System.Windows.Forms.NumericUpDown();
            this.tbar_Transparency = new System.Windows.Forms.TrackBar();
            this.tlp_Preview = new System.Windows.Forms.TableLayoutPanel();
            this.tp_Noise = new System.Windows.Forms.TabPage();
            this.lbl_Noise = new System.Windows.Forms.Label();
            this.nud_Noise = new System.Windows.Forms.NumericUpDown();
            this.tbar_Noise = new System.Windows.Forms.TrackBar();
            this.pan_After = new IView.Controls.Library.BufferedPanel();
            this.pan_Before = new IView.Controls.Library.BufferedPanel();
            this.gbx_Before.SuspendLayout();
            this.gbx_After.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.tc_Main.SuspendLayout();
            this.tp_BrightnessContrast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Contrast)).BeginInit();
            this.tp_ColourBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Red)).BeginInit();
            this.tp_Gamma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Gamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Gamma)).BeginInit();
            this.tp_Transparency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Transparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Transparency)).BeginInit();
            this.tlp_Preview.SuspendLayout();
            this.tp_Noise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Noise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Noise)).BeginInit();
            this.SuspendLayout();
            // 
            // gbx_Before
            // 
            this.gbx_Before.Controls.Add(this.pan_Before);
            this.gbx_Before.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Before.Location = new System.Drawing.Point(3, 3);
            this.gbx_Before.Name = "gbx_Before";
            this.gbx_Before.Size = new System.Drawing.Size(178, 152);
            this.gbx_Before.TabIndex = 1;
            this.gbx_Before.TabStop = false;
            this.gbx_Before.Text = "Before";
            // 
            // gbx_After
            // 
            this.gbx_After.Controls.Add(this.pan_After);
            this.gbx_After.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_After.Location = new System.Drawing.Point(187, 3);
            this.gbx_After.Name = "gbx_After";
            this.gbx_After.Size = new System.Drawing.Size(178, 152);
            this.gbx_After.TabIndex = 2;
            this.gbx_After.TabStop = false;
            this.gbx_After.Text = "After";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(287, 345);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(206, 345);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 25);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "&OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.tc_Main, 0, 1);
            this.tlp_Main.Controls.Add(this.tlp_Preview, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tlp_Main.Size = new System.Drawing.Size(374, 339);
            this.tlp_Main.TabIndex = 6;
            // 
            // tc_Main
            // 
            this.tc_Main.Controls.Add(this.tp_BrightnessContrast);
            this.tc_Main.Controls.Add(this.tp_ColourBalance);
            this.tc_Main.Controls.Add(this.tp_Gamma);
            this.tc_Main.Controls.Add(this.tp_Transparency);
            this.tc_Main.Controls.Add(this.tp_Noise);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Location = new System.Drawing.Point(6, 167);
            this.tc_Main.Margin = new System.Windows.Forms.Padding(6, 3, 5, 3);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(363, 169);
            this.tc_Main.TabIndex = 9;
            // 
            // tp_BrightnessContrast
            // 
            this.tp_BrightnessContrast.BackColor = System.Drawing.Color.White;
            this.tp_BrightnessContrast.Controls.Add(this.lbl_Brightness);
            this.tp_BrightnessContrast.Controls.Add(this.tbar_Brightness);
            this.tp_BrightnessContrast.Controls.Add(this.nud_Contrast);
            this.tp_BrightnessContrast.Controls.Add(this.nud_Brightness);
            this.tp_BrightnessContrast.Controls.Add(this.tbar_Contrast);
            this.tp_BrightnessContrast.Controls.Add(this.lbl_Contrast);
            this.tp_BrightnessContrast.Location = new System.Drawing.Point(4, 22);
            this.tp_BrightnessContrast.Name = "tp_BrightnessContrast";
            this.tp_BrightnessContrast.Padding = new System.Windows.Forms.Padding(3);
            this.tp_BrightnessContrast.Size = new System.Drawing.Size(355, 143);
            this.tp_BrightnessContrast.TabIndex = 0;
            this.tp_BrightnessContrast.Text = "Brightness and Contrast";
            // 
            // lbl_Brightness
            // 
            this.lbl_Brightness.AutoSize = true;
            this.lbl_Brightness.Location = new System.Drawing.Point(6, 12);
            this.lbl_Brightness.Name = "lbl_Brightness";
            this.lbl_Brightness.Size = new System.Drawing.Size(61, 13);
            this.lbl_Brightness.TabIndex = 2;
            this.lbl_Brightness.Text = "Brightness:";
            // 
            // tbar_Brightness
            // 
            this.tbar_Brightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Brightness.AutoSize = false;
            this.tbar_Brightness.Location = new System.Drawing.Point(6, 28);
            this.tbar_Brightness.Maximum = 100;
            this.tbar_Brightness.Minimum = -100;
            this.tbar_Brightness.Name = "tbar_Brightness";
            this.tbar_Brightness.Size = new System.Drawing.Size(277, 22);
            this.tbar_Brightness.TabIndex = 0;
            this.tbar_Brightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Brightness.ValueChanged += new System.EventHandler(this.tbar_Brightness_ValueChanged);
            // 
            // nud_Contrast
            // 
            this.nud_Contrast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Contrast.BackColor = System.Drawing.Color.White;
            this.nud_Contrast.Location = new System.Drawing.Point(289, 69);
            this.nud_Contrast.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nud_Contrast.Name = "nud_Contrast";
            this.nud_Contrast.ReadOnly = true;
            this.nud_Contrast.Size = new System.Drawing.Size(60, 21);
            this.nud_Contrast.TabIndex = 4;
            this.nud_Contrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Contrast.ValueChanged += new System.EventHandler(this.nud_Contrast_ValueChanged);
            // 
            // nud_Brightness
            // 
            this.nud_Brightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Brightness.BackColor = System.Drawing.Color.White;
            this.nud_Brightness.Location = new System.Drawing.Point(289, 28);
            this.nud_Brightness.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nud_Brightness.Name = "nud_Brightness";
            this.nud_Brightness.ReadOnly = true;
            this.nud_Brightness.Size = new System.Drawing.Size(60, 21);
            this.nud_Brightness.TabIndex = 1;
            this.nud_Brightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Brightness.ValueChanged += new System.EventHandler(this.nud_Brightness_ValueChanged);
            // 
            // tbar_Contrast
            // 
            this.tbar_Contrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Contrast.AutoSize = false;
            this.tbar_Contrast.Location = new System.Drawing.Point(6, 69);
            this.tbar_Contrast.Maximum = 100;
            this.tbar_Contrast.Minimum = -100;
            this.tbar_Contrast.Name = "tbar_Contrast";
            this.tbar_Contrast.Size = new System.Drawing.Size(277, 22);
            this.tbar_Contrast.TabIndex = 3;
            this.tbar_Contrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Contrast.ValueChanged += new System.EventHandler(this.tbar_Contrast_ValueChanged);
            // 
            // lbl_Contrast
            // 
            this.lbl_Contrast.AutoSize = true;
            this.lbl_Contrast.Location = new System.Drawing.Point(6, 53);
            this.lbl_Contrast.Name = "lbl_Contrast";
            this.lbl_Contrast.Size = new System.Drawing.Size(53, 13);
            this.lbl_Contrast.TabIndex = 5;
            this.lbl_Contrast.Text = "Contrast:";
            // 
            // tp_ColourBalance
            // 
            this.tp_ColourBalance.BackColor = System.Drawing.Color.White;
            this.tp_ColourBalance.Controls.Add(this.lbl_Blue);
            this.tp_ColourBalance.Controls.Add(this.lbl_Red);
            this.tp_ColourBalance.Controls.Add(this.nud_Green);
            this.tp_ColourBalance.Controls.Add(this.nud_Blue);
            this.tp_ColourBalance.Controls.Add(this.tbar_Green);
            this.tp_ColourBalance.Controls.Add(this.tbar_Red);
            this.tp_ColourBalance.Controls.Add(this.lbl_Green);
            this.tp_ColourBalance.Controls.Add(this.tbar_Blue);
            this.tp_ColourBalance.Controls.Add(this.nud_Red);
            this.tp_ColourBalance.Location = new System.Drawing.Point(4, 22);
            this.tp_ColourBalance.Name = "tp_ColourBalance";
            this.tp_ColourBalance.Padding = new System.Windows.Forms.Padding(3);
            this.tp_ColourBalance.Size = new System.Drawing.Size(355, 143);
            this.tp_ColourBalance.TabIndex = 1;
            this.tp_ColourBalance.Text = "Colour Balance";
            // 
            // lbl_Blue
            // 
            this.lbl_Blue.AutoSize = true;
            this.lbl_Blue.Location = new System.Drawing.Point(6, 94);
            this.lbl_Blue.Name = "lbl_Blue";
            this.lbl_Blue.Size = new System.Drawing.Size(31, 13);
            this.lbl_Blue.TabIndex = 8;
            this.lbl_Blue.Text = "Blue:";
            // 
            // lbl_Red
            // 
            this.lbl_Red.AutoSize = true;
            this.lbl_Red.Location = new System.Drawing.Point(6, 12);
            this.lbl_Red.Name = "lbl_Red";
            this.lbl_Red.Size = new System.Drawing.Size(30, 13);
            this.lbl_Red.TabIndex = 2;
            this.lbl_Red.Text = "Red:";
            // 
            // nud_Green
            // 
            this.nud_Green.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Green.BackColor = System.Drawing.Color.White;
            this.nud_Green.Location = new System.Drawing.Point(280, 69);
            this.nud_Green.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Green.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nud_Green.Name = "nud_Green";
            this.nud_Green.ReadOnly = true;
            this.nud_Green.Size = new System.Drawing.Size(60, 21);
            this.nud_Green.TabIndex = 4;
            this.nud_Green.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Green.ValueChanged += new System.EventHandler(this.nud_Green_ValueChanged);
            // 
            // nud_Blue
            // 
            this.nud_Blue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Blue.BackColor = System.Drawing.Color.White;
            this.nud_Blue.Location = new System.Drawing.Point(280, 108);
            this.nud_Blue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Blue.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nud_Blue.Name = "nud_Blue";
            this.nud_Blue.ReadOnly = true;
            this.nud_Blue.Size = new System.Drawing.Size(60, 21);
            this.nud_Blue.TabIndex = 7;
            this.nud_Blue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Blue.ValueChanged += new System.EventHandler(this.nud_Blue_ValueChanged);
            // 
            // tbar_Green
            // 
            this.tbar_Green.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Green.AutoSize = false;
            this.tbar_Green.Location = new System.Drawing.Point(6, 69);
            this.tbar_Green.Maximum = 255;
            this.tbar_Green.Minimum = -255;
            this.tbar_Green.Name = "tbar_Green";
            this.tbar_Green.Size = new System.Drawing.Size(268, 22);
            this.tbar_Green.TabIndex = 3;
            this.tbar_Green.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Green.ValueChanged += new System.EventHandler(this.tbar_Green_ValueChanged);
            // 
            // tbar_Red
            // 
            this.tbar_Red.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Red.AutoSize = false;
            this.tbar_Red.Location = new System.Drawing.Point(6, 28);
            this.tbar_Red.Maximum = 255;
            this.tbar_Red.Minimum = -255;
            this.tbar_Red.Name = "tbar_Red";
            this.tbar_Red.Size = new System.Drawing.Size(268, 22);
            this.tbar_Red.TabIndex = 0;
            this.tbar_Red.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Red.ValueChanged += new System.EventHandler(this.tbar_Red_ValueChanged);
            // 
            // lbl_Green
            // 
            this.lbl_Green.AutoSize = true;
            this.lbl_Green.Location = new System.Drawing.Point(6, 53);
            this.lbl_Green.Name = "lbl_Green";
            this.lbl_Green.Size = new System.Drawing.Size(40, 13);
            this.lbl_Green.TabIndex = 5;
            this.lbl_Green.Text = "Green:";
            // 
            // tbar_Blue
            // 
            this.tbar_Blue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Blue.AutoSize = false;
            this.tbar_Blue.Location = new System.Drawing.Point(6, 110);
            this.tbar_Blue.Maximum = 255;
            this.tbar_Blue.Minimum = -255;
            this.tbar_Blue.Name = "tbar_Blue";
            this.tbar_Blue.Size = new System.Drawing.Size(268, 22);
            this.tbar_Blue.TabIndex = 6;
            this.tbar_Blue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Blue.ValueChanged += new System.EventHandler(this.tbar_Blue_ValueChanged);
            // 
            // nud_Red
            // 
            this.nud_Red.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Red.BackColor = System.Drawing.Color.White;
            this.nud_Red.Location = new System.Drawing.Point(280, 28);
            this.nud_Red.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Red.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nud_Red.Name = "nud_Red";
            this.nud_Red.ReadOnly = true;
            this.nud_Red.Size = new System.Drawing.Size(60, 21);
            this.nud_Red.TabIndex = 1;
            this.nud_Red.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Red.ValueChanged += new System.EventHandler(this.nud_Red_ValueChanged);
            // 
            // tp_Gamma
            // 
            this.tp_Gamma.BackColor = System.Drawing.Color.White;
            this.tp_Gamma.Controls.Add(this.lbl_Gamma);
            this.tp_Gamma.Controls.Add(this.nud_Gamma);
            this.tp_Gamma.Controls.Add(this.tbar_Gamma);
            this.tp_Gamma.Location = new System.Drawing.Point(4, 22);
            this.tp_Gamma.Name = "tp_Gamma";
            this.tp_Gamma.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Gamma.Size = new System.Drawing.Size(355, 143);
            this.tp_Gamma.TabIndex = 2;
            this.tp_Gamma.Text = "Exposure";
            // 
            // lbl_Gamma
            // 
            this.lbl_Gamma.AutoSize = true;
            this.lbl_Gamma.Location = new System.Drawing.Point(6, 12);
            this.lbl_Gamma.Name = "lbl_Gamma";
            this.lbl_Gamma.Size = new System.Drawing.Size(46, 13);
            this.lbl_Gamma.TabIndex = 5;
            this.lbl_Gamma.Text = "Gamma:";
            // 
            // nud_Gamma
            // 
            this.nud_Gamma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Gamma.BackColor = System.Drawing.Color.White;
            this.nud_Gamma.DecimalPlaces = 2;
            this.nud_Gamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_Gamma.Location = new System.Drawing.Point(280, 28);
            this.nud_Gamma.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Gamma.Name = "nud_Gamma";
            this.nud_Gamma.ReadOnly = true;
            this.nud_Gamma.Size = new System.Drawing.Size(60, 21);
            this.nud_Gamma.TabIndex = 6;
            this.nud_Gamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Gamma.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.nud_Gamma.ValueChanged += new System.EventHandler(this.nud_Gamma_ValueChanged);
            // 
            // tbar_Gamma
            // 
            this.tbar_Gamma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Gamma.AutoSize = false;
            this.tbar_Gamma.Location = new System.Drawing.Point(6, 28);
            this.tbar_Gamma.Maximum = 1000;
            this.tbar_Gamma.Name = "tbar_Gamma";
            this.tbar_Gamma.Size = new System.Drawing.Size(268, 22);
            this.tbar_Gamma.TabIndex = 4;
            this.tbar_Gamma.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Gamma.Value = 100;
            this.tbar_Gamma.ValueChanged += new System.EventHandler(this.tbar_Gamma_ValueChanged);
            // 
            // tp_Transparency
            // 
            this.tp_Transparency.BackColor = System.Drawing.Color.White;
            this.tp_Transparency.Controls.Add(this.lbl_Threshold);
            this.tp_Transparency.Controls.Add(this.nud_Threshold);
            this.tp_Transparency.Controls.Add(this.tbar_Threshold);
            this.tp_Transparency.Controls.Add(this.lbl_Transparency);
            this.tp_Transparency.Controls.Add(this.nud_Transparency);
            this.tp_Transparency.Controls.Add(this.tbar_Transparency);
            this.tp_Transparency.Location = new System.Drawing.Point(4, 22);
            this.tp_Transparency.Name = "tp_Transparency";
            this.tp_Transparency.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Transparency.Size = new System.Drawing.Size(355, 143);
            this.tp_Transparency.TabIndex = 3;
            this.tp_Transparency.Text = "Transparency";
            // 
            // lbl_Threshold
            // 
            this.lbl_Threshold.AutoSize = true;
            this.lbl_Threshold.Location = new System.Drawing.Point(6, 53);
            this.lbl_Threshold.Name = "lbl_Threshold";
            this.lbl_Threshold.Size = new System.Drawing.Size(58, 13);
            this.lbl_Threshold.TabIndex = 11;
            this.lbl_Threshold.Text = "Threshold:";
            // 
            // nud_Threshold
            // 
            this.nud_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Threshold.BackColor = System.Drawing.Color.White;
            this.nud_Threshold.Location = new System.Drawing.Point(289, 69);
            this.nud_Threshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Threshold.Name = "nud_Threshold";
            this.nud_Threshold.ReadOnly = true;
            this.nud_Threshold.Size = new System.Drawing.Size(60, 21);
            this.nud_Threshold.TabIndex = 12;
            this.nud_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Threshold.ValueChanged += new System.EventHandler(this.nud_Threshold_ValueChanged);
            // 
            // tbar_Threshold
            // 
            this.tbar_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Threshold.AutoSize = false;
            this.tbar_Threshold.Location = new System.Drawing.Point(6, 69);
            this.tbar_Threshold.Maximum = 255;
            this.tbar_Threshold.Name = "tbar_Threshold";
            this.tbar_Threshold.Size = new System.Drawing.Size(277, 22);
            this.tbar_Threshold.TabIndex = 10;
            this.tbar_Threshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Threshold.ValueChanged += new System.EventHandler(this.tbar_Threshold_ValueChanged);
            // 
            // lbl_Transparency
            // 
            this.lbl_Transparency.AutoSize = true;
            this.lbl_Transparency.Location = new System.Drawing.Point(6, 12);
            this.lbl_Transparency.Name = "lbl_Transparency";
            this.lbl_Transparency.Size = new System.Drawing.Size(77, 13);
            this.lbl_Transparency.TabIndex = 8;
            this.lbl_Transparency.Text = "Transparency:";
            // 
            // nud_Transparency
            // 
            this.nud_Transparency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Transparency.BackColor = System.Drawing.Color.White;
            this.nud_Transparency.DecimalPlaces = 1;
            this.nud_Transparency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Transparency.Location = new System.Drawing.Point(289, 28);
            this.nud_Transparency.Name = "nud_Transparency";
            this.nud_Transparency.ReadOnly = true;
            this.nud_Transparency.Size = new System.Drawing.Size(60, 21);
            this.nud_Transparency.TabIndex = 9;
            this.nud_Transparency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Transparency.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_Transparency.ValueChanged += new System.EventHandler(this.nud_Transparency_ValueChanged);
            // 
            // tbar_Transparency
            // 
            this.tbar_Transparency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Transparency.AutoSize = false;
            this.tbar_Transparency.Location = new System.Drawing.Point(6, 28);
            this.tbar_Transparency.Maximum = 255;
            this.tbar_Transparency.Name = "tbar_Transparency";
            this.tbar_Transparency.Size = new System.Drawing.Size(277, 22);
            this.tbar_Transparency.TabIndex = 7;
            this.tbar_Transparency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Transparency.Value = 255;
            this.tbar_Transparency.ValueChanged += new System.EventHandler(this.tbar_Transparancy_ValueChanged);
            // 
            // tlp_Preview
            // 
            this.tlp_Preview.ColumnCount = 2;
            this.tlp_Preview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Preview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Preview.Controls.Add(this.gbx_After, 1, 0);
            this.tlp_Preview.Controls.Add(this.gbx_Before, 0, 0);
            this.tlp_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Preview.Location = new System.Drawing.Point(3, 3);
            this.tlp_Preview.Name = "tlp_Preview";
            this.tlp_Preview.RowCount = 1;
            this.tlp_Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Preview.Size = new System.Drawing.Size(368, 158);
            this.tlp_Preview.TabIndex = 4;
            // 
            // tp_Noise
            // 
            this.tp_Noise.BackColor = System.Drawing.Color.White;
            this.tp_Noise.Controls.Add(this.lbl_Noise);
            this.tp_Noise.Controls.Add(this.nud_Noise);
            this.tp_Noise.Controls.Add(this.tbar_Noise);
            this.tp_Noise.Location = new System.Drawing.Point(4, 22);
            this.tp_Noise.Name = "tp_Noise";
            this.tp_Noise.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Noise.Size = new System.Drawing.Size(355, 143);
            this.tp_Noise.TabIndex = 4;
            this.tp_Noise.Text = "Noise";
            // 
            // lbl_Noise
            // 
            this.lbl_Noise.AutoSize = true;
            this.lbl_Noise.Location = new System.Drawing.Point(6, 12);
            this.lbl_Noise.Name = "lbl_Noise";
            this.lbl_Noise.Size = new System.Drawing.Size(37, 13);
            this.lbl_Noise.TabIndex = 14;
            this.lbl_Noise.Text = "Noise:";
            // 
            // nud_Noise
            // 
            this.nud_Noise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Noise.BackColor = System.Drawing.Color.White;
            this.nud_Noise.Location = new System.Drawing.Point(289, 28);
            this.nud_Noise.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Noise.Name = "nud_Noise";
            this.nud_Noise.ReadOnly = true;
            this.nud_Noise.Size = new System.Drawing.Size(60, 21);
            this.nud_Noise.TabIndex = 15;
            this.nud_Noise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Noise.ValueChanged += new System.EventHandler(this.nud_Noise_ValueChanged);
            // 
            // tbar_Noise
            // 
            this.tbar_Noise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbar_Noise.AutoSize = false;
            this.tbar_Noise.Location = new System.Drawing.Point(6, 28);
            this.tbar_Noise.Maximum = 255;
            this.tbar_Noise.Name = "tbar_Noise";
            this.tbar_Noise.Size = new System.Drawing.Size(277, 22);
            this.tbar_Noise.TabIndex = 13;
            this.tbar_Noise.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_Noise.ValueChanged += new System.EventHandler(this.tbar_Noise_ValueChanged);
            // 
            // pan_After
            // 
            this.pan_After.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_After.BackColor = System.Drawing.Color.Black;
            this.pan_After.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pan_After.Location = new System.Drawing.Point(6, 20);
            this.pan_After.Name = "pan_After";
            this.pan_After.Size = new System.Drawing.Size(166, 126);
            this.pan_After.TabIndex = 0;
            // 
            // pan_Before
            // 
            this.pan_Before.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_Before.BackColor = System.Drawing.Color.Black;
            this.pan_Before.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pan_Before.Location = new System.Drawing.Point(6, 20);
            this.pan_Before.Name = "pan_Before";
            this.pan_Before.Size = new System.Drawing.Size(166, 126);
            this.pan_Before.TabIndex = 1;
            // 
            // FormProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 382);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProcessing";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing";
            this.gbx_Before.ResumeLayout(false);
            this.gbx_After.ResumeLayout(false);
            this.tlp_Main.ResumeLayout(false);
            this.tc_Main.ResumeLayout(false);
            this.tp_BrightnessContrast.ResumeLayout(false);
            this.tp_BrightnessContrast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Contrast)).EndInit();
            this.tp_ColourBalance.ResumeLayout(false);
            this.tp_ColourBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Red)).EndInit();
            this.tp_Gamma.ResumeLayout(false);
            this.tp_Gamma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Gamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Gamma)).EndInit();
            this.tp_Transparency.ResumeLayout(false);
            this.tp_Transparency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Transparency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Transparency)).EndInit();
            this.tlp_Preview.ResumeLayout(false);
            this.tp_Noise.ResumeLayout(false);
            this.tp_Noise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Noise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_Noise)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Before;
        private System.Windows.Forms.GroupBox gbx_After;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Preview;
        private System.Windows.Forms.TrackBar tbar_Red;
        private System.Windows.Forms.Label lbl_Blue;
        private System.Windows.Forms.NumericUpDown nud_Blue;
        private System.Windows.Forms.TrackBar tbar_Blue;
        private System.Windows.Forms.Label lbl_Green;
        private System.Windows.Forms.NumericUpDown nud_Green;
        private System.Windows.Forms.TrackBar tbar_Green;
        private System.Windows.Forms.Label lbl_Red;
        private System.Windows.Forms.NumericUpDown nud_Red;
        private Controls.Library.BufferedPanel pan_Before;
        private Controls.Library.BufferedPanel pan_After;
        private System.Windows.Forms.Label lbl_Brightness;
        private System.Windows.Forms.TrackBar tbar_Brightness;
        private System.Windows.Forms.NumericUpDown nud_Brightness;
        private System.Windows.Forms.Label lbl_Contrast;
        private System.Windows.Forms.TrackBar tbar_Contrast;
        private System.Windows.Forms.NumericUpDown nud_Contrast;
        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tp_BrightnessContrast;
        private System.Windows.Forms.TabPage tp_ColourBalance;
        private System.Windows.Forms.TabPage tp_Gamma;
        private System.Windows.Forms.Label lbl_Gamma;
        private System.Windows.Forms.NumericUpDown nud_Gamma;
        private System.Windows.Forms.TrackBar tbar_Gamma;
        private System.Windows.Forms.TabPage tp_Transparency;
        private System.Windows.Forms.Label lbl_Transparency;
        private System.Windows.Forms.NumericUpDown nud_Transparency;
        private System.Windows.Forms.TrackBar tbar_Transparency;
        private System.Windows.Forms.Label lbl_Threshold;
        private System.Windows.Forms.NumericUpDown nud_Threshold;
        private System.Windows.Forms.TrackBar tbar_Threshold;
        private System.Windows.Forms.TabPage tp_Noise;
        private System.Windows.Forms.Label lbl_Noise;
        private System.Windows.Forms.NumericUpDown nud_Noise;
        private System.Windows.Forms.TrackBar tbar_Noise;
    }
}