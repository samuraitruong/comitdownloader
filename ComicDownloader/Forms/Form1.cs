using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicDownloader.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            groupedCombo.ValueMember = "Value";
            groupedCombo.DisplayMember = "Display";
            groupedCombo.GroupMember = "Group";

            var ar  = new ArrayList(new object[] {
                new { Value=100, Display="Apples", Group="Fruit" },
                new { Value=101, Display="Pears", Group="Fruit" },
                new { Value=102, Display="Carrots", Group="Vegetables" },
                new { Value=103, Display="Beef", Group="Meat" },
                new { Value=104, Display="Cucumbers", Group="Vegetables" },
                new { Value=0, Display="(other)", Group=String.Empty },
                new { Value=105, Display="Chillies", Group="Vegetables" },
                new { Value=106, Display="Strawberries", Group="Fruit" }
            });
            //groupedCombo.DataSource = ar;
            //ar.Add(new { Value = 106, Display = "Strawberries1", Group = "AAAA" });
            //groupedCombo.DataSource = ar;
            //this.Invalidate();

            groupedCombo.Items.Add(new { Value = 106, Display = "Strawberries1", Group = "AAAA" });
            groupedCombo.Items.Add(new { Value = 106, Display = "Strawberries1", Group = "BB" });
        }

        private void groupedCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
