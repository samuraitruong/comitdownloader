using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
namespace Software_Protector
{
	//[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class main_form 
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		//[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Label10 = new System.Windows.Forms.Label();
            this.NumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.CheckBox9 = new System.Windows.Forms.CheckBox();
            this.CheckBox8 = new System.Windows.Forms.CheckBox();
            this.CheckBox7 = new System.Windows.Forms.CheckBox();
            this.CheckBox5 = new System.Windows.Forms.CheckBox();
            this.CheckBox4 = new System.Windows.Forms.CheckBox();
            this.CheckBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.CheckBox6 = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(532, 322);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TabPage1.Controls.Add(this.SplitContainer1);
            this.TabPage1.Controls.Add(this.Label13);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(524, 296);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Main";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(3, 41);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Panel1.Controls.Add(this.CheckBox1);
            this.SplitContainer1.Panel1.Controls.Add(this.Button3);
            this.SplitContainer1.Panel1.Controls.Add(this.Label10);
            this.SplitContainer1.Panel1.Controls.Add(this.Button2);
            this.SplitContainer1.Panel1.Controls.Add(this.NumericUpDown2);
            this.SplitContainer1.Panel1.Controls.Add(this.Button1);
            this.SplitContainer1.Panel1.Controls.Add(this.TextBox2);
            this.SplitContainer1.Panel1.Controls.Add(this.Label4);
            this.SplitContainer1.Panel1.Controls.Add(this.TextBox1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Panel2.Controls.Add(this.GroupBox2);
            this.SplitContainer1.Panel2.Controls.Add(this.GroupBox1);
            this.SplitContainer1.Size = new System.Drawing.Size(518, 252);
            this.SplitContainer1.SplitterDistance = 293;
            this.SplitContainer1.TabIndex = 2;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(16, 164);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(98, 13);
            this.Label10.TabIndex = 7;
            this.Label10.Text = "Amount of Keys";
            // 
            // NumericUpDown2
            // 
            this.NumericUpDown2.Location = new System.Drawing.Point(120, 160);
            this.NumericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown2.Name = "NumericUpDown2";
            this.NumericUpDown2.Size = new System.Drawing.Size(82, 21);
            this.NumericUpDown2.TabIndex = 3;
            this.ToolTip1.SetToolTip(this.NumericUpDown2, "Amount of keys to generate");
            this.NumericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(11, 187);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(238, 21);
            this.TextBox2.TabIndex = 4;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(8, 5);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(61, 13);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Password";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(11, 21);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.PasswordChar = '*';
            this.TextBox1.Size = new System.Drawing.Size(272, 21);
            this.TextBox1.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.TextBox1, "Password of the Key. KEEP IT LONG AND SAFE!");
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.CheckBox9);
            this.GroupBox2.Controls.Add(this.CheckBox8);
            this.GroupBox2.Controls.Add(this.CheckBox7);
            this.GroupBox2.Controls.Add(this.CheckBox5);
            this.GroupBox2.Controls.Add(this.CheckBox4);
            this.GroupBox2.Controls.Add(this.CheckBox3);
            this.GroupBox2.Controls.Add(this.CheckBox2);
            this.GroupBox2.Controls.Add(this.CheckBox6);
            this.GroupBox2.Location = new System.Drawing.Point(4, 121);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(208, 113);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Features";
            // 
            // CheckBox9
            // 
            this.CheckBox9.AutoSize = true;
            this.CheckBox9.Location = new System.Drawing.Point(107, 89);
            this.CheckBox9.Name = "CheckBox9";
            this.CheckBox9.Size = new System.Drawing.Size(80, 17);
            this.CheckBox9.TabIndex = 10;
            this.CheckBox9.Text = "Feature 8";
            this.CheckBox9.UseVisualStyleBackColor = true;
            // 
            // CheckBox8
            // 
            this.CheckBox8.AutoSize = true;
            this.CheckBox8.Location = new System.Drawing.Point(107, 66);
            this.CheckBox8.Name = "CheckBox8";
            this.CheckBox8.Size = new System.Drawing.Size(80, 17);
            this.CheckBox8.TabIndex = 9;
            this.CheckBox8.Text = "Feature 7";
            this.CheckBox8.UseVisualStyleBackColor = true;
            // 
            // CheckBox7
            // 
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.Location = new System.Drawing.Point(107, 43);
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Size = new System.Drawing.Size(80, 17);
            this.CheckBox7.TabIndex = 8;
            this.CheckBox7.Text = "Feature 6";
            this.CheckBox7.UseVisualStyleBackColor = true;
            // 
            // CheckBox5
            // 
            this.CheckBox5.AutoSize = true;
            this.CheckBox5.Location = new System.Drawing.Point(10, 89);
            this.CheckBox5.Name = "CheckBox5";
            this.CheckBox5.Size = new System.Drawing.Size(80, 17);
            this.CheckBox5.TabIndex = 6;
            this.CheckBox5.Text = "Feature 4";
            this.CheckBox5.UseVisualStyleBackColor = true;
            // 
            // CheckBox4
            // 
            this.CheckBox4.AutoSize = true;
            this.CheckBox4.Location = new System.Drawing.Point(10, 66);
            this.CheckBox4.Name = "CheckBox4";
            this.CheckBox4.Size = new System.Drawing.Size(80, 17);
            this.CheckBox4.TabIndex = 2;
            this.CheckBox4.Text = "Feature 3";
            this.CheckBox4.UseVisualStyleBackColor = true;
            // 
            // CheckBox3
            // 
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.Location = new System.Drawing.Point(10, 43);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new System.Drawing.Size(80, 17);
            this.CheckBox3.TabIndex = 1;
            this.CheckBox3.Text = "Feature 2";
            this.CheckBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Location = new System.Drawing.Point(10, 20);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(80, 17);
            this.CheckBox2.TabIndex = 0;
            this.CheckBox2.Text = "Feature 1";
            this.CheckBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBox6
            // 
            this.CheckBox6.AutoSize = true;
            this.CheckBox6.Location = new System.Drawing.Point(107, 20);
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Size = new System.Drawing.Size(80, 17);
            this.CheckBox6.TabIndex = 7;
            this.CheckBox6.Text = "Feature 5";
            this.CheckBox6.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.DateTimePicker2);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.NumericUpDown1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.DateTimePicker1);
            this.GroupBox1.Location = new System.Drawing.Point(4, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(208, 112);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Date and Time";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 80);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Time Left\r\n";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(95, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Expiration Date";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Creation Date";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label13.Location = new System.Drawing.Point(8, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(446, 29);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "Comic Downloader  - Key Generator";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.Label12);
            this.TabPage2.Controls.Add(this.Label11);
            this.TabPage2.Controls.Add(this.Label9);
            this.TabPage2.Controls.Add(this.Label8);
            this.TabPage2.Controls.Add(this.Label7);
            this.TabPage2.Controls.Add(this.Label6);
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(524, 296);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "About";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(369, 128);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(134, 13);
            this.Label12.TabIndex = 7;
            this.Label12.Text = "SKGL Version: 2.0.2.1";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(8, 128);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(125, 13);
            this.Label11.TabIndex = 6;
            this.Label11.Text = "GUI Version: 1.0.2.1";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(-7, 141);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(763, 13);
            this.Label9.TabIndex = 4;
            this.Label9.Text = "_________________________________________________________________________________" +
                "___________________________";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(8, 163);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(439, 117);
            this.Label8.TabIndex = 3;
            this.Label8.Text = resources.GetString("Label8.Text");
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(258, 48);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(252, 65);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "This software uses SKGL API by Artem Los\r\nwhen creating and validating keys.\r\n\r\nC" +
                "opyright (C) 2011-2012 Artem Los\r\nAll rights reserved";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(8, 48);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(208, 52);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Designed and written by Artem Los\r\n\r\nCopyrigt (C) 2012 Artem Los\r\nAll rights rese" +
                "rved";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label5.Location = new System.Drawing.Point(80, 3);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(359, 32);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "About Software Protector";
            // 
            // Button3
            // 
            this.Button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button3.BackgroundImage")));
            this.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button3.Location = new System.Drawing.Point(252, 184);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(28, 24);
            this.Button3.TabIndex = 5;
            this.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ToolTip1.SetToolTip(this.Button3, "Copy Key");
            this.Button3.UseVisualStyleBackColor = false;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(124, 211);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 7;
            this.Button2.Text = "Validate";
            this.ToolTip1.SetToolTip(this.Button2, "Validate Key");
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(205, 211);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "Generate";
            this.ToolTip1.SetToolTip(this.Button1, "Create Key");
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker2.Location = new System.Drawing.Point(113, 47);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(89, 21);
            this.DateTimePicker2.TabIndex = 9;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(172, 50);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(111, 17);
            this.CheckBox1.TabIndex = 10;
            this.CheckBox1.Text = "View password";
            this.ToolTip1.SetToolTip(this.CheckBox1, "Show/hide password field");
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.Location = new System.Drawing.Point(113, 74);
            this.NumericUpDown1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.Size = new System.Drawing.Size(74, 21);
            this.NumericUpDown1.TabIndex = 11;
            this.ToolTip1.SetToolTip(this.NumericUpDown1, "Amount of days key will be valid");
            this.NumericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker1.Location = new System.Drawing.Point(113, 20);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(89, 21);
            this.DateTimePicker1.TabIndex = 8;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 322);
            this.Controls.Add(this.TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 349);
            this.MinimumSize = new System.Drawing.Size(540, 349);
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comic Downloader Key Generator";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label3;
		private System.Windows.Forms.DateTimePicker withEventsField_DateTimePicker2;
		internal System.Windows.Forms.DateTimePicker DateTimePicker2 {
			get { return withEventsField_DateTimePicker2; }
			set {
				if (withEventsField_DateTimePicker2 != null) {
					withEventsField_DateTimePicker2.ValueChanged -= DateTimePicker2_ValueChanged;
				}
				withEventsField_DateTimePicker2 = value;
				if (withEventsField_DateTimePicker2 != null) {
					withEventsField_DateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;
				}
			}
		}
		private System.Windows.Forms.NumericUpDown withEventsField_NumericUpDown1;
		internal System.Windows.Forms.NumericUpDown NumericUpDown1 {
			get { return withEventsField_NumericUpDown1; }
			set {
				if (withEventsField_NumericUpDown1 != null) {
					withEventsField_NumericUpDown1.KeyUp -= NumericUpDown1_ValueChanged;
					withEventsField_NumericUpDown1.ValueChanged -= NumericUpDown1_ValueChanged;
				}
				withEventsField_NumericUpDown1 = value;
				if (withEventsField_NumericUpDown1 != null) {
					withEventsField_NumericUpDown1.KeyUp += NumericUpDown1_ValueChanged;
					withEventsField_NumericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
				}
			}
		}
		internal System.Windows.Forms.Label Label2;
		private System.Windows.Forms.DateTimePicker withEventsField_DateTimePicker1;
		internal System.Windows.Forms.DateTimePicker DateTimePicker1 {
			get { return withEventsField_DateTimePicker1; }
			set {
				if (withEventsField_DateTimePicker1 != null) {
					withEventsField_DateTimePicker1.ValueChanged -= DateTimePicker1_ValueChanged;
				}
				withEventsField_DateTimePicker1 = value;
				if (withEventsField_DateTimePicker1 != null) {
					withEventsField_DateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
				}
			}
		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TabPage TabPage2;
		private System.Windows.Forms.Button withEventsField_Button1;
		internal System.Windows.Forms.Button Button1 {
			get { return withEventsField_Button1; }
			set {
				if (withEventsField_Button1 != null) {
					withEventsField_Button1.Click -= Button1_Click;
				}
				withEventsField_Button1 = value;
				if (withEventsField_Button1 != null) {
					withEventsField_Button1.Click += Button1_Click;
				}
			}
		}
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.Label Label4;
		private System.Windows.Forms.CheckBox withEventsField_CheckBox1;
		internal System.Windows.Forms.CheckBox CheckBox1 {
			get { return withEventsField_CheckBox1; }
			set {
				if (withEventsField_CheckBox1 != null) {
					withEventsField_CheckBox1.CheckedChanged -= CheckBox1_CheckedChanged;
				}
				withEventsField_CheckBox1 = value;
				if (withEventsField_CheckBox1 != null) {
					withEventsField_CheckBox1.CheckedChanged += CheckBox1_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_Button2;
		internal System.Windows.Forms.Button Button2 {
			get { return withEventsField_Button2; }
			set {
				if (withEventsField_Button2 != null) {
					withEventsField_Button2.Click -= Button2_Click;
				}
				withEventsField_Button2 = value;
				if (withEventsField_Button2 != null) {
					withEventsField_Button2.Click += Button2_Click;
				}
			}
		}
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.CheckBox CheckBox5;
		internal System.Windows.Forms.CheckBox CheckBox4;
		internal System.Windows.Forms.CheckBox CheckBox3;
		internal System.Windows.Forms.CheckBox CheckBox2;
		internal System.Windows.Forms.CheckBox CheckBox7;
		internal System.Windows.Forms.CheckBox CheckBox6;
		internal System.Windows.Forms.CheckBox CheckBox9;
		internal System.Windows.Forms.CheckBox CheckBox8;
		private System.Windows.Forms.Button withEventsField_Button3;
		internal System.Windows.Forms.Button Button3 {
			get { return withEventsField_Button3; }
			set {
				if (withEventsField_Button3 != null) {
					withEventsField_Button3.Click -= Button3_Click;
				}
				withEventsField_Button3 = value;
				if (withEventsField_Button3 != null) {
					withEventsField_Button3.Click += Button3_Click;
				}
			}
		}
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label9;
		private System.Windows.Forms.Button withEventsField_Button4;
		internal System.Windows.Forms.Button Button4 {
			get { return withEventsField_Button4; }
			set {
				if (withEventsField_Button4 != null) {
					withEventsField_Button4.Click -= Button4_Click;
				}
				withEventsField_Button4 = value;
				if (withEventsField_Button4 != null) {
					withEventsField_Button4.Click += Button4_Click;
				}
			}
		}
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.NumericUpDown NumericUpDown2;
		internal System.Windows.Forms.ToolTip ToolTip1;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label12;
		private System.Windows.Forms.LinkLabel withEventsField_LinkLabel1;
		internal System.Windows.Forms.LinkLabel LinkLabel1 {
			get { return withEventsField_LinkLabel1; }
			set {
				if (withEventsField_LinkLabel1 != null) {
					withEventsField_LinkLabel1.LinkClicked -= LinkLabel1_LinkClicked;
				}
				withEventsField_LinkLabel1 = value;
				if (withEventsField_LinkLabel1 != null) {
					withEventsField_LinkLabel1.LinkClicked += LinkLabel1_LinkClicked;
				}
			}

		}
		public main_form()
		{
			Load += Form1_Load;
			InitializeComponent();
		}

        

      
	}
}
