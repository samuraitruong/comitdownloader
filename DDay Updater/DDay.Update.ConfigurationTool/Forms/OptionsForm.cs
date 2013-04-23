using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DDay.Update.Configuration;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DDay.Update.ConfigurationTool.Forms
{
    public partial class OptionsForm : Form
    {
        #region Private Fields

        private System.Configuration.Configuration _Configuration;
        private DDayUpdateConfigurationSection _Cfg;

        #endregion

        #region Public Properties

        virtual public bool EnableUpdateLogging
        {
            get { return cbEnableUpdateLogging.Checked; }
            set { cbEnableUpdateLogging.Checked = value; }
        }
             
        #endregion

        #region Constructors

        private OptionsForm(bool local)
        {
            InitializeComponent();
            
            // Copy the Bootstrap.exe file to New.exe,
            // so that the configuration file will load properly
            string currentDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string sandboxDir = Path.Combine(currentDir, "Sandbox");

            if (!File.Exists(Path.Combine(sandboxDir, "New.exe")))
            {
                File.Copy(
                    Path.Combine(sandboxDir, "Bootstrap.exe"),
                    Path.Combine(sandboxDir, "New.exe")
                );
            }

            string filename = local ? "New.exe" : "Bootstrap.exe";
            string filepath = Path.Combine(sandboxDir, filename);
            _Configuration = ConfigurationManager.OpenExeConfiguration(filepath);
            
            // Get the DDay.Update configuration section
            _Cfg = _Configuration.GetSection("DDay.Update") as DDayUpdateConfigurationSection;

            // Set the default setting on which application folder to use.
            cbAppFolder.SelectedIndex = 0;

            SetValuesFromConfig();

            if (!local)
                _Configuration.SaveAs(Path.Combine(sandboxDir, "New.exe.config"));
        }

        public OptionsForm() : this(false)
        {            
        }

        #endregion

        #region Public Methods

        public OptionsForm Clone()
        {
            OptionsForm of = new OptionsForm(true);
            of.EnableUpdateLogging = EnableUpdateLogging;

            return of;
        }

        #endregion

        #region Private Methods

        private void SetValuesFromConfig()
        {
            if (_Cfg != null)
            {
                if (_Cfg.KeepVersions == null ||
                    !_Cfg.KeepVersions.HasValue)
                {
                    cbKeepPrevVersions.Checked = true;
                    rbKeepAll.Checked = true;
                }
                else if (_Cfg.KeepVersions == 0)
                {
                    cbKeepPrevVersions.Checked = false;
                }
                else
                {
                    cbKeepPrevVersions.Checked = true;
                    rbDeleteAfter.Checked = true;
                    tbNumVersions.Text = _Cfg.KeepVersions.ToString();
                }

                if (_Cfg.Preserve != null &&
                    _Cfg.Preserve.Count > 0)
                {
                    cbPreserve.Checked = true;
                    foreach (KeyValuePairConfigurationElement kvpe in _Cfg.Preserve)
                        lbPreserve.Items.Add(kvpe.Value);
                }
                else cbPreserve.Checked = false;

                if (_Cfg.Remove != null &&
                    _Cfg.Remove.Count > 0)
                {
                    cbRemove.Checked = true;
                    foreach (KeyValuePairConfigurationElement kvpe in _Cfg.Remove)
                        lbRemove.Items.Add(kvpe.Value);
                }
                else cbRemove.Checked = false;

                // Setup Automatic updates
                cbAutoUpdate.Checked = _Cfg.Automatic;
                cbUseSecurityFolder.Checked = _Cfg.UseUserFolder || _Cfg.UsePublicFolder;
                cbAppFolder.SelectedIndex =
                    _Cfg.UsePublicFolder ? 1 : 0;

                // Set credentials
                cbUseCredentials.Checked = (_Cfg.Username != null && _Cfg.Username.Length > 0);
                txtUsername.Text = _Cfg.Username;
                txtPassword.Text = _Cfg.Password;
                txtDomain.Text = _Cfg.Domain;
            }
        }

        #endregion

        #region Event Handlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_Cfg != null)
            {
                if (cbKeepPrevVersions.Checked)
                {
                    if (rbKeepAll.Checked)
                        _Cfg.KeepVersions = null;
                    else
                    {
                        int i;
                        if (Int32.TryParse(tbNumVersions.Text, out i))
                            _Cfg.KeepVersions = i;
                        else _Cfg.KeepVersions = null;
                    }
                }
                else _Cfg.KeepVersions = 0;

                if (cbPreserve.Checked)
                {
                    _Cfg.Preserve = new KeyValuePairConfigurationElementCollection();
                    int i = 0;
                    foreach (string s in lbPreserve.Items)
                    {
                        KeyValuePairConfigurationElement kvpe = new KeyValuePairConfigurationElement();
                        kvpe.Name = "p" + (i++);
                        kvpe.Value = s;
                        _Cfg.Preserve.Add(kvpe);
                    }
                }
                else if (_Cfg.Preserve != null)
                    _Cfg.Preserve.Clear();

                if (cbRemove.Checked)
                {
                    _Cfg.Remove = new KeyValuePairConfigurationElementCollection();
                    int i = 0;
                    foreach (string s in lbRemove.Items)
                    {
                        KeyValuePairConfigurationElement kvpe = new KeyValuePairConfigurationElement();
                        kvpe.Name = "r" + (i++);
                        kvpe.Value = s;
                        _Cfg.Remove.Add(kvpe);
                    }
                }
                else if (_Cfg.Remove != null)
                    _Cfg.Remove.Clear();

                // Automatic updates
                _Cfg.Automatic = cbAutoUpdate.Checked;

                // Whether or not to save updates in the user's %APPDATA% folder
                if (cbUseSecurityFolder.Checked)
                {
                    _Cfg.UseUserFolder = cbAppFolder.SelectedIndex == 0;
                    _Cfg.UsePublicFolder = cbAppFolder.SelectedIndex == 1;
                }
                else
                {
                    _Cfg.UseUserFolder = false;
                    _Cfg.UsePublicFolder = false;
                }

                // Set credentials
                _Cfg.Username = txtUsername.Text;
                _Cfg.Password = txtPassword.Text;
                _Cfg.Domain = txtDomain.Text;
            }

            _Configuration.Save();

            DialogResult = DialogResult.OK;
        }

        private void cbKeepPrevVersions_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = cbKeepPrevVersions.Checked;
            rbKeepAll.Enabled = enabled;
            rbDeleteAfter.Enabled = enabled;
            tbNumVersions.Enabled = enabled;
            label1.Enabled = enabled;
        }

        private void tbNumVersions_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (Int32.TryParse(tbNumVersions.Text, out i))
            {
                rbDeleteAfter.Checked = true;
            }
            else
            {
                rbKeepAll.Checked = true;
                tbNumVersions.Text = string.Empty;
            }
        }

        private void cbPreserve_CheckedChanged(object sender, EventArgs e)
        {
            lbPreserve.Enabled = cbPreserve.Checked;
            btnPresAdd.Enabled = cbPreserve.Checked;
            btnPresRemove.Enabled = cbPreserve.Checked;
            tbPreserve.Enabled = cbPreserve.Checked;
        }

        private void cbRemove_CheckedChanged(object sender, EventArgs e)
        {
            lbRemove.Enabled = cbRemove.Checked;
            btnRemoveAdd.Enabled = cbRemove.Checked;
            btnRemoveRemove.Enabled = cbRemove.Checked;
            tbRemove.Enabled = cbRemove.Checked;
        }

        private void btnPresAdd_Click(object sender, EventArgs e)
        {
            if (tbPreserve.Text.Trim().Length > 0)
            {
                lbPreserve.Items.Add(tbPreserve.Text);
                tbPreserve.Text = string.Empty;
            }
        }

        private void btnPresRemove_Click(object sender, EventArgs e)
        {
            if (lbPreserve.SelectedIndex >= 0)
                lbPreserve.Items.RemoveAt(lbPreserve.SelectedIndex);
        }

        private void btnRemoveAdd_Click(object sender, EventArgs e)
        {
            if (tbRemove.Text.Trim().Length > 0)
            {
                lbRemove.Items.Add(tbRemove.Text);
                tbRemove.Text = string.Empty;
            }
        }

        private void btnRemoveRemove_Click(object sender, EventArgs e)
        {
            if (lbRemove.SelectedIndex >= 0)
                lbRemove.Items.RemoveAt(lbRemove.SelectedIndex);
        }

        private void cbUseCredentials_CheckedChanged(object sender, EventArgs e)
        {
            gbCredentials.Enabled = cbUseCredentials.Checked;
            if (!cbUseCredentials.Checked)
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtDomain.Text = string.Empty;
            }
        }

        #endregion
    }
}