using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using DDay.Update;
using System.ComponentModel;

namespace DDay
{
    public partial class ConfirmDoUpdateWindow :
        INotifyPropertyChanged
    {
        #region Private Fields

        private DeploymentManifest _DeploymentManifest; 

        #endregion

        #region Public Properties

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set
            {
                if (!object.Equals(_DeploymentManifest, value))
                {
                    _DeploymentManifest = value;

                    OnPropertyChanged("DeploymentManifest");
                    OnPropertyChanged("UpdateText");
                    OnPropertyChanged("ProgramTitle");
                    OnPropertyChanged("CurrentVersionText");
                    OnPropertyChanged("MostRecentVersionText");
                }
            }
        }

        public string UpdateText
        {
            get
            {
                if (!string.IsNullOrEmpty(ProgramTitle))
                    return ProgramTitle + " has a new version!";
                else
                    return "A new version is available!";
            }
        }

        public string ProgramTitle
        {
            get
            {
                if (DeploymentManifest != null &&
                    DeploymentManifest.Description != null)
                    return DeploymentManifest.Description.Product;
                else 
                    return string.Empty;
            }
        }

        public string CurrentVersionText
        {
            get
            {
                if (UpdateManager.LocalDeploymentManifest != null &&
                    UpdateManager.LocalDeploymentManifest.CurrentPublishedVersion != null)
                    return UpdateManager.LocalDeploymentManifest.CurrentPublishedVersion.ToString();
                return "Unknown";
            }
        }

        public string MostRecentVersionText
        {
            get
            {
                if (DeploymentManifest != null &&
                    DeploymentManifest.CurrentPublishedVersion != null)
                    return DeploymentManifest.CurrentPublishedVersion.ToString();
                return "Unknown";
            }
        }

        #endregion

        #region Constructors

        public ConfirmDoUpdateWindow(DeploymentManifest deploymentManifest)
        {
            DeploymentManifest = deploymentManifest;

            this.InitializeComponent();
        } 

        #endregion

        #region Event Handlers

        private void btnLater_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnNow_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }                

        #endregion
    }
}