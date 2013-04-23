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
	// Copyright (C) 2012 Artem Los, All rights reserved.
	// To view the full license, goto http://softwareprotector.codeplex.com/license
	public partial class main_form: Form
	{
		static SKGL.SerialKeyConfiguration  skc = new SKGL.SerialKeyConfiguration();
		SKGL.Generate generate = new SKGL.Generate(skc);
		SKGL.Validate validate = new SKGL.Validate(skc);
		private void Form1_Load(System.Object sender, System.EventArgs e)
		{
			DateTimePicker2.Value = DateAndTime.Today.AddDays(30);
			NumericUpDown1.Value = 30;
        }

        private void DateTimePicker2_ValueChanged(System.Object sender, System.EventArgs e)
        {
            int num = (DateTimePicker2.Value - DateTimePicker1.Value).Days;//.DateDiff(DateInterval.DayOfYear, DateTimePicker1.Value, DateTimePicker2.Value);
            if (num <= 999)
            {
                NumericUpDown1.Value = num;// DateAndTime.DateDiff(DateInterval.DayOfYear, DateTimePicker1.Value, DateTimePicker2.Value);
            }
            else
            {
                DateTimePicker2.Value = DateTimePicker1.Value.AddDays(999);
                NumericUpDown1.Value = 999;
            }
        }
        private void DateTimePicker1_ValueChanged(System.Object sender, System.EventArgs e)
        {
            int num = (DateTimePicker2.Value - DateTimePicker1.Value).Days;// DateAndTime.DateDiff(DateInterval.DayOfYear, DateTimePicker1.Value, DateTimePicker2.Value);
            if (num <= 999)
            {
                NumericUpDown1.Value = num;// DateAndTime.DateDiff(DateInterval.DayOfYear, DateTimePicker1.Value, DateTimePicker2.Value);
            }
            else
            {
                DateTimePicker2.Value = DateTimePicker1.Value.AddDays(999);
                NumericUpDown1.Value = 999;
            }
        }

        private void NumericUpDown1_ValueChanged(System.Object sender, System.EventArgs e)
        {
            DateTimePicker2.Value = DateTimePicker1.Value.AddDays((int)NumericUpDown1.Value);
        }

        private void CheckBox1_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                TextBox1.PasswordChar = '\0';
            }
            else
            {
                TextBox1.PasswordChar = '*';
            }
        }


        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            generate.secretPhase = TextBox1.Text;
            skc.Features = new bool[8] {
		CheckBox2.Checked,
		CheckBox3.Checked,
		CheckBox4.Checked,
		CheckBox5.Checked,
		CheckBox6.Checked,
		CheckBox7.Checked,
		CheckBox8.Checked,
		CheckBox9.Checked
	};
            if (NumericUpDown2.Value > 1)
            {
                keys frmKeys = new keys();

                for (int i = 0; i <= NumericUpDown2.Value - 1; i++)
                {
                    frmKeys.TextBox1.Text += generate.doKey((int)NumericUpDown1.Value, DateTimePicker1.Value,0) + Environment.NewLine;
                }

                frmKeys.Show();
            }
            else
            {
                TextBox2.Text = generate.doKey((int)NumericUpDown1.Value, DateTimePicker1.Value,0);
            }

        }

        private void Button2_Click(System.Object sender, System.EventArgs e)
        {
            validateCheck validator = new validateCheck();
            validate.Key = TextBox2.Text;
            validate.secretPhase = TextBox1.Text;


            if (validate.IsValid)
            {

                validator.TextBox2.Text = TextBox2.Text;
                validator.TextBox1.Text = validate.CreationDate.ToShortDateString();
                validator.TextBox3.Text = validate.ExpireDate.ToShortDateString();
                validator.TextBox4.Text = validate.SetTime.ToString();
                validator.TextBox5.Text = validate.DaysLeft.ToString();
                if (validate.IsExpired)
                {
                    validator.TextBox6.Text = "True";
                    validator.TextBox6.ForeColor = Color.Red;
                }
                else
                {
                    validator.TextBox6.Text = "False";
                    validator.TextBox6.ForeColor = Color.Blue;
                }

                validator.CheckBox2.Checked = validate.Features[0];
                validator.CheckBox3.Checked = validate.Features[1];
                validator.CheckBox4.Checked = validate.Features[2];
                validator.CheckBox5.Checked = validate.Features[3];
                validator.CheckBox6.Checked = validate.Features[4];
                validator.CheckBox7.Checked = validate.Features[5];
                validator.CheckBox8.Checked = validate.Features[6];
                validator.CheckBox9.Checked = validate.Features[7];

                validator.Show();
            }
            else
            {
                validator.Label2.ForeColor = Color.Red;
                validator.Label2.Text = "Error";
                validator.TextBox2.Text = TextBox2.Text;

                validator.Show();
            }

        }

        private void Button3_Click(System.Object sender, System.EventArgs e)
        {
           Clipboard.SetText(TextBox2.Text);
        }

        private void Button4_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3R59VSU8LKETW");

            }
            catch (Exception ex)
            {
            }
        }

        private void LinkLabel1_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://softwareprotector.codeplex.com");

            }
            catch (Exception ex)
            {
            }
        }


		

		
	}
}
