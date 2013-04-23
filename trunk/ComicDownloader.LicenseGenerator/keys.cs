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

	public partial class keys
	{

		private void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void Button3_Click(System.Object sender, System.EventArgs e)
		{
			Clipboard.SetText(TextBox1.Text);
		}
		public keys()
		{
			InitializeComponent();
		}
	}
}
