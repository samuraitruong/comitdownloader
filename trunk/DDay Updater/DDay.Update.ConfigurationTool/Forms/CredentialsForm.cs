using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DDay.Update.ConfigurationTool.Forms
{
    public partial class CredentialsForm : Form
    {
        #region Private Fields

        private string _Username;
        private string _Password;
        private string _Domain;

        #endregion

        #region Public Properties

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }

        #endregion

        #region Constructors

        public CredentialsForm()
        {
            InitializeComponent();
        } 

        #endregion

        #region Event Handlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            Username = tbUsername.Text;
            Password = tbPassword.Text;
            Domain = tbDomain.Text;
            DialogResult = DialogResult.OK;
        } 

        #endregion
    }
}
