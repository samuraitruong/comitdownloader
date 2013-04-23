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
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class validateCheck : System.Windows.Forms.Form
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
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(validateCheck));
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.CheckBox9 = new System.Windows.Forms.CheckBox();
			this.CheckBox8 = new System.Windows.Forms.CheckBox();
			this.CheckBox7 = new System.Windows.Forms.CheckBox();
			this.CheckBox5 = new System.Windows.Forms.CheckBox();
			this.CheckBox4 = new System.Windows.Forms.CheckBox();
			this.CheckBox3 = new System.Windows.Forms.CheckBox();
			this.CheckBox2 = new System.Windows.Forms.CheckBox();
			this.CheckBox6 = new System.Windows.Forms.CheckBox();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox4 = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.TextBox5 = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.TextBox6 = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.TableLayoutPanel1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.SuspendLayout();
			//
			//TableLayoutPanel1
			//
			this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(169, 327);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(170, 29);
			this.TableLayoutPanel1.TabIndex = 0;
			//
			//OK_Button
			//
			this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.OK_Button.Location = new System.Drawing.Point(3, 3);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(78, 23);
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "OK";
			//
			//Cancel_Button
			//
			this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point(88, 3);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(78, 23);
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "Cancel";
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(15, 58);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(34, 13);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Key:";
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.CheckBox9);
			this.GroupBox2.Controls.Add(this.CheckBox8);
			this.GroupBox2.Controls.Add(this.CheckBox7);
			this.GroupBox2.Controls.Add(this.CheckBox5);
			this.GroupBox2.Controls.Add(this.CheckBox4);
			this.GroupBox2.Controls.Add(this.CheckBox3);
			this.GroupBox2.Controls.Add(this.CheckBox2);
			this.GroupBox2.Controls.Add(this.CheckBox6);
			this.GroupBox2.Location = new System.Drawing.Point(12, 211);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(208, 113);
			this.GroupBox2.TabIndex = 4;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Features";
			//
			//CheckBox9
			//
			this.CheckBox9.AutoSize = true;
			this.CheckBox9.Location = new System.Drawing.Point(107, 89);
			this.CheckBox9.Name = "CheckBox9";
			this.CheckBox9.Size = new System.Drawing.Size(80, 17);
			this.CheckBox9.TabIndex = 10;
			this.CheckBox9.Text = "Feature 8";
			this.CheckBox9.UseVisualStyleBackColor = true;
			//
			//CheckBox8
			//
			this.CheckBox8.AutoSize = true;
			this.CheckBox8.Location = new System.Drawing.Point(107, 66);
			this.CheckBox8.Name = "CheckBox8";
			this.CheckBox8.Size = new System.Drawing.Size(80, 17);
			this.CheckBox8.TabIndex = 9;
			this.CheckBox8.Text = "Feature 7";
			this.CheckBox8.UseVisualStyleBackColor = true;
			//
			//CheckBox7
			//
			this.CheckBox7.AutoSize = true;
			this.CheckBox7.Location = new System.Drawing.Point(107, 43);
			this.CheckBox7.Name = "CheckBox7";
			this.CheckBox7.Size = new System.Drawing.Size(80, 17);
			this.CheckBox7.TabIndex = 8;
			this.CheckBox7.Text = "Feature 6";
			this.CheckBox7.UseVisualStyleBackColor = true;
			//
			//CheckBox5
			//
			this.CheckBox5.AutoSize = true;
			this.CheckBox5.Location = new System.Drawing.Point(10, 89);
			this.CheckBox5.Name = "CheckBox5";
			this.CheckBox5.Size = new System.Drawing.Size(80, 17);
			this.CheckBox5.TabIndex = 6;
			this.CheckBox5.Text = "Feature 4";
			this.CheckBox5.UseVisualStyleBackColor = true;
			//
			//CheckBox4
			//
			this.CheckBox4.AutoSize = true;
			this.CheckBox4.Location = new System.Drawing.Point(10, 66);
			this.CheckBox4.Name = "CheckBox4";
			this.CheckBox4.Size = new System.Drawing.Size(80, 17);
			this.CheckBox4.TabIndex = 2;
			this.CheckBox4.Text = "Feature 3";
			this.CheckBox4.UseVisualStyleBackColor = true;
			//
			//CheckBox3
			//
			this.CheckBox3.AutoSize = true;
			this.CheckBox3.Location = new System.Drawing.Point(10, 43);
			this.CheckBox3.Name = "CheckBox3";
			this.CheckBox3.Size = new System.Drawing.Size(80, 17);
			this.CheckBox3.TabIndex = 1;
			this.CheckBox3.Text = "Feature 2";
			this.CheckBox3.UseVisualStyleBackColor = true;
			//
			//CheckBox2
			//
			this.CheckBox2.AutoSize = true;
			this.CheckBox2.Location = new System.Drawing.Point(10, 20);
			this.CheckBox2.Name = "CheckBox2";
			this.CheckBox2.Size = new System.Drawing.Size(80, 17);
			this.CheckBox2.TabIndex = 0;
			this.CheckBox2.Text = "Feature 1";
			this.CheckBox2.UseVisualStyleBackColor = true;
			//
			//CheckBox6
			//
			this.CheckBox6.AutoSize = true;
			this.CheckBox6.Location = new System.Drawing.Point(107, 20);
			this.CheckBox6.Name = "CheckBox6";
			this.CheckBox6.Size = new System.Drawing.Size(80, 17);
			this.CheckBox6.TabIndex = 7;
			this.CheckBox6.Text = "Feature 5";
			this.CheckBox6.UseVisualStyleBackColor = true;
			//
			//TextBox2
			//
			this.TextBox2.BackColor = System.Drawing.Color.White;
			this.TextBox2.Location = new System.Drawing.Point(55, 55);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.ReadOnly = true;
			this.TextBox2.Size = new System.Drawing.Size(272, 21);
			this.TextBox2.TabIndex = 5;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Verdana", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.Color.Green;
			this.Label2.Location = new System.Drawing.Point(12, 9);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(91, 32);
			this.Label2.TabIndex = 6;
			this.Label2.Text = "Valid!";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(16, 109);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(100, 13);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Expiration Date:";
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(16, 85);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(92, 13);
			this.Label5.TabIndex = 8;
			this.Label5.Text = "Creation Date:";
			//
			//TextBox1
			//
			this.TextBox1.BackColor = System.Drawing.Color.White;
			this.TextBox1.Location = new System.Drawing.Point(114, 82);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.Size = new System.Drawing.Size(213, 21);
			this.TextBox1.TabIndex = 12;
			//
			//TextBox3
			//
			this.TextBox3.BackColor = System.Drawing.Color.White;
			this.TextBox3.Location = new System.Drawing.Point(114, 106);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.ReadOnly = true;
			this.TextBox3.Size = new System.Drawing.Size(213, 21);
			this.TextBox3.TabIndex = 13;
			//
			//TextBox4
			//
			this.TextBox4.BackColor = System.Drawing.Color.White;
			this.TextBox4.Location = new System.Drawing.Point(114, 133);
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.ReadOnly = true;
			this.TextBox4.Size = new System.Drawing.Size(213, 21);
			this.TextBox4.TabIndex = 14;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(16, 136);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(63, 13);
			this.Label3.TabIndex = 11;
			this.Label3.Text = "Set Time:";
			//
			//TextBox5
			//
			this.TextBox5.BackColor = System.Drawing.Color.White;
			this.TextBox5.Location = new System.Drawing.Point(114, 155);
			this.TextBox5.Name = "TextBox5";
			this.TextBox5.ReadOnly = true;
			this.TextBox5.Size = new System.Drawing.Size(213, 21);
			this.TextBox5.TabIndex = 16;
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(15, 158);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(65, 13);
			this.Label6.TabIndex = 15;
			this.Label6.Text = "Time Left:";
			//
			//TextBox6
			//
			this.TextBox6.BackColor = System.Drawing.Color.White;
			this.TextBox6.ForeColor = System.Drawing.Color.Blue;
			this.TextBox6.Location = new System.Drawing.Point(114, 182);
			this.TextBox6.Name = "TextBox6";
			this.TextBox6.ReadOnly = true;
			this.TextBox6.Size = new System.Drawing.Size(213, 21);
			this.TextBox6.TabIndex = 11;
			//
			//Label7
			//
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(16, 183);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(70, 13);
			this.Label7.TabIndex = 17;
			this.Label7.Text = "Is Expired:";
			//
			//Label8
			//
			this.Label8.AutoSize = true;
			this.Label8.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.Location = new System.Drawing.Point(100, 9);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(227, 26);
			this.Label8.TabIndex = 18;
			this.Label8.Text = "Note that \"Valid\" indicates whether the" + Strings.ChrW(13) + Strings.ChrW(10) + "key has been modified or not.";
			//
			//validateCheck
			//
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(353, 368);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.TextBox6);
			this.Controls.Add(this.TextBox5);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.TextBox4);
			this.Controls.Add(this.TextBox3);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.TextBox2);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TableLayoutPanel1);
			this.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "validateCheck";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Validator";
			this.TableLayoutPanel1.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		private System.Windows.Forms.Button withEventsField_OK_Button;
		internal System.Windows.Forms.Button OK_Button {
			get { return withEventsField_OK_Button; }
			set {
				if (withEventsField_OK_Button != null) {
					withEventsField_OK_Button.Click -= OK_Button_Click;
				}
				withEventsField_OK_Button = value;
				if (withEventsField_OK_Button != null) {
					withEventsField_OK_Button.Click += OK_Button_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_Cancel_Button;
		internal System.Windows.Forms.Button Cancel_Button {
			get { return withEventsField_Cancel_Button; }
			set {
				if (withEventsField_Cancel_Button != null) {
					withEventsField_Cancel_Button.Click -= Cancel_Button_Click;
				}
				withEventsField_Cancel_Button = value;
				if (withEventsField_Cancel_Button != null) {
					withEventsField_Cancel_Button.Click += Cancel_Button_Click;
				}
			}
		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.CheckBox CheckBox9;
		internal System.Windows.Forms.CheckBox CheckBox8;
		internal System.Windows.Forms.CheckBox CheckBox7;
		internal System.Windows.Forms.CheckBox CheckBox5;
		internal System.Windows.Forms.CheckBox CheckBox4;
		internal System.Windows.Forms.CheckBox CheckBox3;
		internal System.Windows.Forms.CheckBox CheckBox2;
		internal System.Windows.Forms.CheckBox CheckBox6;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.TextBox TextBox3;
		internal System.Windows.Forms.TextBox TextBox4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox TextBox5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox TextBox6;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label8;

		internal System.Windows.Forms.ToolTip ToolTip1;
		public validateCheck()
		{
			InitializeComponent();
		}
	}
}
