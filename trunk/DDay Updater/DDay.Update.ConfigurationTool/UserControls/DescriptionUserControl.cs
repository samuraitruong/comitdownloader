using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DDay.Update.ConfigurationTool.UserControls
{
    public partial class DescriptionUserControl : UserControl
    {
        #region Private Fields

        private Description _Description;

        #endregion

        #region Public Properties

        public Description Description
        {
            get { return _Description; }
            set
            {
                if (!object.Equals(_Description, value))
                {
                    _Description = value;

                    if (_Description != null)
                    {
                        txtProductName.Text = _Description.Product;
                        txtPublisher.Text = _Description.Publisher;
                    }
                    else
                    {
                        txtProductName.Text = string.Empty;
                        txtPublisher.Text = string.Empty;
                    }
                }
            }
        }

        #endregion

        #region Constructors

        public DescriptionUserControl()
        {
            InitializeComponent();
        }

        #endregion        
    }
}
