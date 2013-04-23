using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

using DDay.Update.Configuration;
using DDay.Update.WinForms;
using System.Net;

namespace DDay.Update.ConfigurationTool.Forms
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private DeploymentManifest _DeploymentManifest;
        private OptionsForm _OptionsForm;

        #endregion

        #region Public Properties

        public DeploymentManifest DeploymentManifest
        {
            get { return _DeploymentManifest; }
            set
            {
                _DeploymentManifest = value;

                if (_DeploymentManifest != null)
                {
                    panel1.Visible = true;

                    // Show the description of the deployment manifest
                    descUC.Description = _DeploymentManifest.Description;

                    // Show the preferred update URI
                    if (_DeploymentManifest.Deployment != null &&
                        _DeploymentManifest.Deployment.DeploymentProvider != null)
                        txtUpdateURI.Text = _DeploymentManifest.Deployment.DeploymentProvider.CodeBase;
                    else txtUpdateURI.Text = _DeploymentManifest.Uri.AbsoluteUri;
                }
                else
                {
                    panel1.Visible = false;

                    // Empty some fields
                    descUC.Description = null;
                    txtUpdateURI.Text = string.Empty;                    
                    cbUpdateNotifier.SelectedIndex = -1;
                    txtDestinationFolder.Text = string.Empty;

                    _OptionsForm = new OptionsForm();
                }
            }
        }

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            _OptionsForm = new OptionsForm();

            LoadUpdateNotifiers();
            LoadRecentManifestList();
        }

        #endregion

        #region Private Methods

        private string CopyAssemblyToDestination(string assemblyName, string targetName, string targetDir, bool deleteTargetInstead)
        {
            // Get the assembly information
            Assembly assembly = Assembly.Load(assemblyName);
            if (assembly != null)
            {
                // Get the filename of the assembly
                Uri codeBase = new Uri(assembly.CodeBase);
                string srcFilename = codeBase.LocalPath;

                // Determine the target name of the assembly
                if (string.IsNullOrEmpty(targetName))
                    targetName = Path.GetFileName(srcFilename);

                // Determine the target path
                string targetFilename = Path.Combine(targetDir, targetName);

                // Create the directory if it doesn't exist
                if (!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);

                // Delete the file if it already existed
                if (File.Exists(targetFilename))
                    File.Delete(targetFilename);

                // Copy the file
                if (!deleteTargetInstead)
                    File.Copy(srcFilename, targetFilename);

                return srcFilename;
            }
            return null;
        }

        private void CopyAssemblies(string targetFilename, string targetDir)
        {
            // Copy the DDay.Update assembly to the target
            CopyAssemblyToDestination("DDay.Update", null, targetDir, false);

            // Copy the update notifier to the target
            ComboBoxItem cbi = cbUpdateNotifier.SelectedItem as ComboBoxItem;
            Type type = Type.GetType(cbi.Value.ToString());
            CopyAssemblyToDestination(type.Assembly.FullName, null, targetDir, false);

            // Copy or delete the log4net assembly, if update logging is enabled/disabled           
            CopyAssemblyToDestination("log4net", null, targetDir, !_OptionsForm.EnableUpdateLogging);

            // Try to automatically determine the entry point for the application.
            // Download it if necessary, so we can inherit the properties of the entry point.
            string
                execPath = null,
                iconPath = null;
                        
            // Determine the path where items will be downloaded if necessary
            string downloadFolder = 
                Path.Combine(
                    Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                    DeploymentManifest.Description.Product);
            
            if (!Directory.Exists(downloadFolder))
                Directory.CreateDirectory(downloadFolder);
            
            if (rbUseDistribution.Checked)                
            {
                if (DeploymentManifest != null)
                {
                    DeploymentManifest.LoadApplicationManifest();
                    
                    WindowsForms2UpdateNotifier updateNotifier = new WindowsForms2UpdateNotifier();
                    updateNotifier.BeginUpdate(DeploymentManifest);

                    AutoResetEvent evt = new AutoResetEvent(false);                    

                    Thread thread = new Thread(new ThreadStart(
                        delegate
                        {
                            List<FileDownloader> fileDownloaders = new List<FileDownloader>();
                            foreach (IDownloadableFile df in DeploymentManifest.ApplicationManifest.DownloadableFiles)
                            {
                                // If the file is the main executable, or it is an
                                // icon file, then let's download it!
                                FileDownloader fd = df.GetDownloader();

                                if (fd.DestinationName.Equals(targetFilename) ||
                                    fd.DestinationName.EndsWith(".ico") ||
                                    fd.DestinationName.EndsWith(".icl"))
                                {
                                    fileDownloaders.Add(fd);                                    
                                }
                            }

                            // Determine the total download size
                            long totalSize = 0;
                            foreach(FileDownloader fd in fileDownloaders)
                                totalSize += fd.DownloadSize;

                            // Notify of the update size
                            updateNotifier.NotifyTotalUpdateSize(totalSize);

                            foreach (FileDownloader fd in fileDownloaders)
                            {
                                AutoResetEvent downloaded = new AutoResetEvent(false);
                                fd.Completed += new EventHandler(
                                    delegate(object sender, EventArgs e)
                                    {
                                        downloaded.Set();
                                    });
                                fd.Cancelled += new EventHandler(
                                    delegate(object sender, EventArgs e)
                                    {
                                        throw new Exception("Download was cancelled.");
                                    });
                                fd.Error += new EventHandler<ExceptionEventArgs>(
                                    delegate(object sender, ExceptionEventArgs e)
                                    {
                                        throw e.Exception;
                                    });

                                fd.Download(updateNotifier);

                                downloaded.WaitOne();
                                fd.DestinationFolder = downloadFolder;
                                fd.Save();

                                if (File.Exists(fd.DestinationPath))
                                {
                                    if (fd.DestinationName.Equals(targetFilename))
                                        execPath = fd.DestinationPath;
                                    else
                                        iconPath = fd.DestinationPath;
                                }
                            }

                            evt.Set();
                        }));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();

                    evt.WaitOne();

                    updateNotifier.EndUpdate();
                }
            }
            else
            {
                execPath = txtMainExec.Text;
                iconPath = txtIconFile.Text;
            }

            // Ensure the executable path exists before passing
            // it along to the compiler.
            if (!File.Exists(execPath))
                execPath = null;

            // Ensure the icon exists at the path before passing
            // it along to the compiler
            if (!File.Exists(iconPath))
                iconPath = null;

            // Compile the bootstrap file
            string targetPath = Compiler.CompileBootstrap(
                execPath,
                targetFilename,
                targetDir,
                iconPath);

            if (targetPath != null)
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string sandboxDir = Path.Combine(dir, "Sandbox");

                // Copy bootstrap configuration files from source to destination
                string cfgFilename = "Bootstrap.exe.config";
                if (File.Exists(
                    Path.Combine(
                        sandboxDir,
                        "New.exe.config")))
                    cfgFilename = "New.exe.config";

                // Get the config filenames for source and target
                string srcConfigFilename = Path.Combine(
                    sandboxDir,
                    cfgFilename);

                string targetConfigFilename = targetPath + ".config";

                if (File.Exists(targetConfigFilename))
                    File.Delete(targetConfigFilename);

                File.Copy(srcConfigFilename, targetConfigFilename);
            }

            // Delete the download folder
            if (Directory.Exists(downloadFolder))
                Directory.Delete(downloadFolder, true);
        }

        private void WriteConfigurationValues(string exeFilename)
        {
            System.Configuration.Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(exeFilename);

            DDayUpdateConfigurationSection cfg = configuration.GetSection("DDay.Update")
                as DDayUpdateConfigurationSection;

            // Set the update notifier in the configuration file
            ComboBoxItem cbi = cbUpdateNotifier.SelectedItem as ComboBoxItem;
            cfg.NotifierString = cbi.Value.ToString();

            // Set the update uri in the configuration file
            cfg.Uri = new Uri(txtUpdateURI.Text);

            // Save the configuration file
            configuration.Save();
        }

        private void LoadUpdateNotifiers()
        {
            cbUpdateNotifier.Items.Clear();

            string[] files = Directory.GetFiles(".", "*.dll");
            foreach (string file in files)
            {
                string fullPath = Path.GetFullPath(file);

                Assembly assembly = Assembly.LoadFile(fullPath);
                if (assembly != null)
                {                    
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.IsClass &&
                            typeof(IUpdateNotifier).IsAssignableFrom(type))
                        {
                            // Determine if a [Description] attribute
                            // was placed on the class.  If so, display
                            // its value instead of the type name of the class.
                            DescriptionAttribute[] desc =
                                type.GetCustomAttributes(typeof(DescriptionAttribute), true)
                                as DescriptionAttribute[];

                            if (desc.Length > 0)
                            {
                                // A description was found, display it instead.
                                cbUpdateNotifier.Items.Add(
                                    new ComboBoxItem(desc[0].Description, type.AssemblyQualifiedName));
                            }
                            else
                            {
                                // No description was found, simply show the type name
                                // of the class.
                                cbUpdateNotifier.Items.Add(
                                    new ComboBoxItem(type.Name, type.AssemblyQualifiedName));
                            }
                        }
                    }
                }
            }
        }

        private void LoadRecentManifestList()
        {
            string localAppPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DDay.Update"
            );
            string recentManifestPath = Path.Combine(
                localAppPath,
                "RecentManifests.txt"
            );

            tsmiRecent.DropDownItems.Clear();
            List<string> lines = new List<string>();
            
            if (File.Exists(recentManifestPath))
            {   
                FileStream fs = new FileStream(recentManifestPath, FileMode.Open, FileAccess.Read);
                if (fs != null)
                {
                    StreamReader sr = new StreamReader(fs);
                    
                    while (!sr.EndOfStream)
                        lines.Add(sr.ReadLine());

                    sr.Close();
                }                
            }

            if (lines.Count > 0)
            {
                tsmiRecent.Enabled = true;
                foreach (string line in lines)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(line);
                    tsmi.Click += new EventHandler(tsmiRecentItem_Click);

                    tsmiRecent.DropDownItems.Add(tsmi);
                }
            }
            else
            {
                tsmiRecent.Enabled = false;
            }
        }

        private void AddToRecentManifests(string manifestUri)
        {
            string localAppPath = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               "DDay.Update"
            );
            string recentManifestPath = Path.Combine(
                localAppPath,
                "RecentManifests.txt"
            );

            if (!Directory.Exists(localAppPath))
                Directory.CreateDirectory(localAppPath);

            List<string> lines = new List<string>();
            FileStream fs = null;
            if (File.Exists(recentManifestPath))
            {
                // Read the contents of the current file                
                fs = new FileStream(recentManifestPath, FileMode.Open, FileAccess.Read);
                if (fs != null)
                {
                    StreamReader sr = new StreamReader(fs);

                    while (!sr.EndOfStream)
                        lines.Add(sr.ReadLine());

                    sr.Close();
                }
            }
            
            // Remove a previous matching entry, if found
            int index = lines.IndexOf(manifestUri);
            if (index >= 0)
                lines.RemoveAt(index);

            // Insert the entry as the first item in the list
            lines.Insert(0, manifestUri);

            // Only track the last 10 items
            if (lines.Count > 10)
                lines.RemoveRange(10, lines.Count - 10);

            // Write the file
            fs = new FileStream(recentManifestPath, FileMode.Create, FileAccess.Write);
            if (fs != null)
            {
                StreamWriter sw = new StreamWriter(fs);

                foreach (string line in lines)
                    sw.WriteLine(line);

                sw.Close();
            }
        }

        #endregion

        #region Event Handlers

        #region Menu Strip

        private void tsmiFileOpenDepManFromURL_Click(object sender, EventArgs e)
        {
            LoadFromURIForm loadFromURI = new LoadFromURIForm();
            if (loadFromURI.ShowDialog() == DialogResult.OK)
            {
                DeploymentManifest = loadFromURI.DeploymentManifest;
                AddToRecentManifests(DeploymentManifest.Uri.AbsoluteUri);

                LoadRecentManifestList();
            }
        }

        void tsmiRecentItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi != null)
            {
                try
                {
                    DeploymentManifest = Program.ValidateUpdateUri(null, tsmi.Text);
                    DialogResult = DialogResult.OK;
                }                
                catch
                {
                    MessageBox.Show("A valid deployment manifest could not be found at the location provided, or you did not have access to the manifest.");
                }
            }
        }

        private void tsmiFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog(this);
        }

        #endregion

        private void btnVerifyURI_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate the update uri
                if (Program.ValidateUpdateUri(DeploymentManifest, txtUpdateURI.Text) == null)
                    throw new Exception("Could not validate the update uri.");

                MessageBox.Show("Validation succeeded!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Validation failed:\n" + ex.Message, "Failure");
            }
        }

        private void btnCreateBootstrap_Click(object sender, EventArgs e)
        {            
            if (cbUpdateNotifier.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an Update Notifier.", "Choose an Update Notifier");
            }
            else if (string.IsNullOrEmpty(txtUpdateURI.Text))
            {
                MessageBox.Show("Please select an Update URI", "Choose an Update URI");
            }
            else if (
                string.IsNullOrEmpty(txtDestinationFolder.Text) ||
                !Directory.Exists(txtDestinationFolder.Text))
            {
                MessageBox.Show("Please choose a valid destination folder", "Choose a destination folder");
            }
            else
            {
                try
                {
                    Program.ValidateUpdateUri(DeploymentManifest, txtUpdateURI.Text);
                }
                catch
                {
                    if (MessageBox.Show("The Update URI does not successfully validate; are you sure you want to create a bootstrap?", "Are you sure?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                }

                if (rbManualConfig.Checked &&
                (
                    string.IsNullOrEmpty(txtMainExec.Text) ||
                    !File.Exists(txtMainExec.Text)
                ))
                {
                    if (MessageBox.Show(@"You have not provided a main executable for your application.
It is recommended that you provide a main executable for the
bootstrap to mimic, so the bootstrap looks as much like your
application as possible.

Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                }

                // Ensure we have a deployment manifest
                if (DeploymentManifest != null)
                {
                    // Make sure the application manifest is loaded
                    DeploymentManifest.LoadApplicationManifest();

                    if (DeploymentManifest.ApplicationManifest != null)
                    {
                        // Get the assembly identity for the application manifest
                        string targetFilename = DeploymentManifest.ApplicationManifest.AssemblyIdentity.Name;

                        // Copy the bootstrap assembly to the target filename
                        CopyAssemblies(targetFilename, txtDestinationFolder.Text);

                        string targetPath = Path.Combine(
                            txtDestinationFolder.Text,
                            targetFilename);

                        // Write the configuration values to the application config file
                        WriteConfigurationValues(targetPath);

                        MessageBox.Show("Bootstrap successfully written!", "Success");

                        // Open the folder after success
                        Process openFolder = new Process();
                        openFolder.StartInfo = new ProcessStartInfo(txtDestinationFolder.Text);
                        openFolder.Start();

                        DeploymentManifest = null;
                        return;
                    }
                }

                MessageBox.Show("An error occurred while creating the bootstrap.", "Failure");
            }            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                txtDestinationFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnBrowseExec_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe";

            if (DeploymentManifest != null)
            {
                try
                {
                    DeploymentManifest.LoadApplicationManifest();

                    if (DeploymentManifest.ApplicationManifest != null)
                    {
                        string entryPointName =
                            DeploymentManifest.ApplicationManifest.AssemblyIdentity.Name;

                        openFileDialog.Filter = entryPointName + "|" + entryPointName;
                    }
                }
                catch { }
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtMainExec.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Icon Files (*.ico)|*.ico|Icon Library Files (*.icl)|*.icl";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtIconFile.Text = openFileDialog.FileName;
        }

        private void rbFileInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManualConfig.Checked)
            {
                panelManualInfo.Enabled = true;
            }
            else
            {
                panelManualInfo.Enabled = false;
                txtMainExec.Text = string.Empty;
                txtIconFile.Text = string.Empty;
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsForm optForm = _OptionsForm.Clone();
            if (optForm.ShowDialog() == DialogResult.OK)
            {
                _OptionsForm = optForm;
            }
        }        

        #endregion

        #region Overrides

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // FIXME: check if everything is OK to close, prompt to save, etc.
        }

        #endregion

        #region Internal Classes

        internal class ComboBoxItem
        {
            private string _Text;
            private object _Value;

            public object Value
            {
                get { return _Value; }
                set { _Value = value; }
            }

            public string Text
            {
                get { return _Text; }
                set { _Text = value; }
            }

            public ComboBoxItem(string text, object value)
            {
                Text = text;
                Value = value;
            }
        }

        #endregion                                       
    }
}
