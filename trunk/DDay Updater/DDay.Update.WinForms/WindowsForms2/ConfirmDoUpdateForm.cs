using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DDay.Update.WinForms
{
    public partial class ConfirmDoUpdateForm : Form
    {
        private DeploymentManifest _DeploymentManifest;

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set
            {
                _DeploymentManifest = value;
                if (_DeploymentManifest != null)
                {
                    if (DeploymentManifest.Description != null)
                    {
                        lblTitle.Text = DeploymentManifest.Description.Publisher + " has a new update for:";
                        lblProgramTitle.Text = DeploymentManifest.Description.Product;
                    }
                    else
                    {
                        lblTitle.Text += "A new update is available for this program";
                        lblProgramTitle.Text = string.Empty;
                    }

                    if (UpdateManager.LocalDeploymentManifest != null)
                        lblCurrentVersion.Text = UpdateManager.LocalDeploymentManifest.CurrentPublishedVersion.ToString();
                    else lblCurrentVersion.Text = "Unknown";

                    if (UpdateManager.DeploymentManifest != null)
                        lblMostRecentVersion.Text = UpdateManager.DeploymentManifest.CurrentPublishedVersion.ToString();
                    else lblMostRecentVersion.Text = "Unknown";
                }
                else
                {
                    lblTitle.Text = lblProgramTitle.Text = lblMostRecentVersion.Text = string.Empty;
                }
            }
        }

        public ConfirmDoUpdateForm(DeploymentManifest manifest)
        {
            InitializeComponent();

            DeploymentManifest = manifest;            
        }

        private void btnLater_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}