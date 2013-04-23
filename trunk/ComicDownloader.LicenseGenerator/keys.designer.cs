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
	partial class keys : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(keys));
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.Button3 = new System.Windows.Forms.Button();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.TableLayoutPanel1.SuspendLayout();
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
			this.TableLayoutPanel1.Location = new System.Drawing.Point(161, 262);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29f));
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
			//TextBox1
			//
			this.TextBox1.BackColor = System.Drawing.Color.White;
			this.TextBox1.Location = new System.Drawing.Point(12, 12);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBox1.Size = new System.Drawing.Size(317, 240);
			this.TextBox1.TabIndex = 1;
			//
			//Button3
			//
			this.Button3.BackgroundImage = (System.Drawing.Image)resources.GetObject("Button3.BackgroundImage");
			this.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Button3.Location = new System.Drawing.Point(12, 258);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(28, 24);
			this.Button3.TabIndex = 7;
			this.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ToolTip1.SetToolTip(this.Button3, "Copy Keys");
			this.Button3.UseVisualStyleBackColor = false;
			//
			//keys
			//
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(345, 303);
			this.Controls.Add(this.Button3);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.TableLayoutPanel1);
			this.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "keys";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Keys";
			this.TableLayoutPanel1.ResumeLayout(false);
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
		internal System.Windows.Forms.TextBox TextBox1;
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

		internal System.Windows.Forms.ToolTip ToolTip1;
	}
}
