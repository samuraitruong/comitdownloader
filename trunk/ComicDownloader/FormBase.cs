using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TruyenTranhTuan_Downloader
{
    public class FormBase: Form
    {
        public TabPage TabPag
        {
            get;
            set;
        }

        public TabControl TabCtrl
        {
            get;
            set;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "FormBase";
            this.Activated += new System.EventHandler(this.FormBase_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            this.ResumeLayout(false);

        }

        private void FormBase_Activated(object sender, EventArgs e)
        {
         
            
                 
                   TabCtrl.SelectedTab = TabPag;

                   if (!TabCtrl.Visible)
                  {
                      TabCtrl.Visible = true;
                  }
            
      
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.TabPag.Dispose();

            if (!TabCtrl.HasChildren)
            {
                TabCtrl.Visible = false;
            }
        }
    }
}
