using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DDay.Update.ConfigurationTool.Forms
{
    public partial class LoadFromURIForm : Form
    {
        #region Private Fields

        private DeploymentManifest _DeploymentManifest;

        #endregion

        #region Public Properties

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set { _DeploymentManifest = value; }
        }

        #endregion

        public LoadFromURIForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DeploymentManifest = Program.ValidateUpdateUri(null, textBox1.Text);
                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("A valid deployment manifest could not be found at the location provided, or you did not have access to the manifest.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}