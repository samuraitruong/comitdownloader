using System;
namespace DDay.Update.ConfigurationTool.Forms
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbEnableUpdateLogging = new System.Windows.Forms.CheckBox();
            this.cbDebugLog = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumVersions = new System.Windows.Forms.TextBox();
            this.rbDeleteAfter = new System.Windows.Forms.RadioButton();
            this.rbKeepAll = new System.Windows.Forms.RadioButton();
            this.cbKeepPrevVersions = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPreserve = new System.Windows.Forms.TextBox();
            this.lbPreserve = new System.Windows.Forms.ListBox();
            this.btnPresRemove = new System.Windows.Forms.Button();
            this.btnPresAdd = new System.Windows.Forms.Button();
            this.cbPreserve = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbAppFolder = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUseSecurityFolder = new System.Windows.Forms.CheckBox();
            this.cbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gbCredentials = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUseCredentials = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbRemove = new System.Windows.Forms.TextBox();
            this.lbRemove = new System.Windows.Forms.ListBox();
            this.btnRemoveRemove = new System.Windows.Forms.Button();
            this.btnRemoveAdd = new System.Windows.Forms.Button();
            this.cbRemove = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gbCredentials.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(222, 369);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(141, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbEnableUpdateLogging
            // 
            this.cbEnableUpdateLogging.AutoSize = true;
            this.cbEnableUpdateLogging.Location = new System.Drawing.Point(6, 19);
            this.cbEnableUpdateLogging.Name = "cbEnableUpdateLogging";
            this.cbEnableUpdateLogging.Size = new System.Drawing.Size(151, 18);
            this.cbEnableUpdateLogging.TabIndex = 2;
            this.cbEnableUpdateLogging.Text = "Enable Update &Logging";
            this.cbEnableUpdateLogging.UseVisualStyleBackColor = true;
            // 
            // cbDebugLog
            // 
            this.cbDebugLog.AutoSize = true;
            this.cbDebugLog.Enabled = false;
            this.cbDebugLog.Location = new System.Drawing.Point(6, 43);
            this.cbDebugLog.Name = "cbDebugLog";
            this.cbDebugLog.Size = new System.Drawing.Size(130, 18);
            this.cbDebugLog.TabIndex = 3;
            this.cbDebugLog.Text = "Include Debug Info";
            this.cbDebugLog.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbEnableUpdateLogging);
            this.groupBox1.Controls.Add(this.cbDebugLog);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Logging";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbNumVersions);
            this.groupBox2.Controls.Add(this.rbDeleteAfter);
            this.groupBox2.Controls.Add(this.rbKeepAll);
            this.groupBox2.Controls.Add(this.cbKeepPrevVersions);
            this.groupBox2.Location = new System.Drawing.Point(6, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 92);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Previous Versions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "previous versions";
            // 
            // tbNumVersions
            // 
            this.tbNumVersions.Location = new System.Drawing.Point(132, 66);
            this.tbNumVersions.Name = "tbNumVersions";
            this.tbNumVersions.Size = new System.Drawing.Size(43, 20);
            this.tbNumVersions.TabIndex = 3;
            this.tbNumVersions.TextChanged += new System.EventHandler(this.tbNumVersions_TextChanged);
            // 
            // rbDeleteAfter
            // 
            this.rbDeleteAfter.AutoSize = true;
            this.rbDeleteAfter.Location = new System.Drawing.Point(38, 67);
            this.rbDeleteAfter.Name = "rbDeleteAfter";
            this.rbDeleteAfter.Size = new System.Drawing.Size(95, 18);
            this.rbDeleteAfter.TabIndex = 2;
            this.rbDeleteAfter.TabStop = true;
            this.rbDeleteAfter.Text = "Keep at most";
            this.rbDeleteAfter.UseVisualStyleBackColor = true;
            // 
            // rbKeepAll
            // 
            this.rbKeepAll.AutoSize = true;
            this.rbKeepAll.Location = new System.Drawing.Point(38, 43);
            this.rbKeepAll.Name = "rbKeepAll";
            this.rbKeepAll.Size = new System.Drawing.Size(118, 18);
            this.rbKeepAll.TabIndex = 1;
            this.rbKeepAll.TabStop = true;
            this.rbKeepAll.Text = "Keep all versions";
            this.rbKeepAll.UseVisualStyleBackColor = true;
            // 
            // cbKeepPrevVersions
            // 
            this.cbKeepPrevVersions.AutoSize = true;
            this.cbKeepPrevVersions.Checked = true;
            this.cbKeepPrevVersions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepPrevVersions.Location = new System.Drawing.Point(6, 19);
            this.cbKeepPrevVersions.Name = "cbKeepPrevVersions";
            this.cbKeepPrevVersions.Size = new System.Drawing.Size(154, 18);
            this.cbKeepPrevVersions.TabIndex = 0;
            this.cbKeepPrevVersions.Text = "Keep Previous Versions";
            this.cbKeepPrevVersions.UseVisualStyleBackColor = true;
            this.cbKeepPrevVersions.CheckedChanged += new System.EventHandler(this.cbKeepPrevVersions_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbPreserve);
            this.groupBox3.Controls.Add(this.lbPreserve);
            this.groupBox3.Controls.Add(this.btnPresRemove);
            this.groupBox3.Controls.Add(this.btnPresAdd);
            this.groupBox3.Controls.Add(this.cbPreserve);
            this.groupBox3.Location = new System.Drawing.Point(7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 324);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preserve Files";
            // 
            // tbPreserve
            // 
            this.tbPreserve.Location = new System.Drawing.Point(6, 71);
            this.tbPreserve.Name = "tbPreserve";
            this.tbPreserve.Size = new System.Drawing.Size(192, 20);
            this.tbPreserve.TabIndex = 8;
            // 
            // lbPreserve
            // 
            this.lbPreserve.FormattingEnabled = true;
            this.lbPreserve.ItemHeight = 14;
            this.lbPreserve.Location = new System.Drawing.Point(6, 98);
            this.lbPreserve.Name = "lbPreserve";
            this.lbPreserve.Size = new System.Drawing.Size(192, 214);
            this.lbPreserve.TabIndex = 7;
            // 
            // btnPresRemove
            // 
            this.btnPresRemove.Location = new System.Drawing.Point(204, 97);
            this.btnPresRemove.Name = "btnPresRemove";
            this.btnPresRemove.Size = new System.Drawing.Size(75, 23);
            this.btnPresRemove.TabIndex = 2;
            this.btnPresRemove.Text = "&Remove";
            this.btnPresRemove.UseVisualStyleBackColor = true;
            this.btnPresRemove.Click += new System.EventHandler(this.btnPresRemove_Click);
            // 
            // btnPresAdd
            // 
            this.btnPresAdd.Location = new System.Drawing.Point(204, 68);
            this.btnPresAdd.Name = "btnPresAdd";
            this.btnPresAdd.Size = new System.Drawing.Size(75, 23);
            this.btnPresAdd.TabIndex = 1;
            this.btnPresAdd.Text = "&Add";
            this.btnPresAdd.UseVisualStyleBackColor = true;
            this.btnPresAdd.Click += new System.EventHandler(this.btnPresAdd_Click);
            // 
            // cbPreserve
            // 
            this.cbPreserve.Location = new System.Drawing.Point(6, 19);
            this.cbPreserve.Name = "cbPreserve";
            this.cbPreserve.Size = new System.Drawing.Size(273, 46);
            this.cbPreserve.TabIndex = 0;
            this.cbPreserve.Text = "Preserve (don\'t overwrite) files that match the following pattern(s).  These file" +
                "s will not receive updates!";
            this.cbPreserve.UseVisualStyleBackColor = true;
            this.cbPreserve.CheckedChanged += new System.EventHandler(this.cbPreserve_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(309, 363);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(301, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.cbAppFolder);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.cbUseSecurityFolder);
            this.groupBox5.Controls.Add(this.cbAutoUpdate);
            this.groupBox5.Location = new System.Drawing.Point(6, 177);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(287, 99);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Updates";
            // 
            // cbAppFolder
            // 
            this.cbAppFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppFolder.FormattingEnabled = true;
            this.cbAppFolder.Items.AddRange(new object[] {
            "User\'s",
            "Public"});
            this.cbAppFolder.Location = new System.Drawing.Point(118, 39);
            this.cbAppFolder.Name = "cbAppFolder";
            this.cbAppFolder.Size = new System.Drawing.Size(91, 22);
            this.cbAppFolder.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(22, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "application folder (Helps to avoid some permission-based problems).";
            // 
            // cbUseSecurityFolder
            // 
            this.cbUseSecurityFolder.AutoSize = true;
            this.cbUseSecurityFolder.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbUseSecurityFolder.Checked = true;
            this.cbUseSecurityFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseSecurityFolder.Location = new System.Drawing.Point(6, 43);
            this.cbUseSecurityFolder.Name = "cbUseSecurityFolder";
            this.cbUseSecurityFolder.Size = new System.Drawing.Size(115, 18);
            this.cbUseSecurityFolder.TabIndex = 1;
            this.cbUseSecurityFolder.Text = "Store updates in";
            this.cbUseSecurityFolder.UseVisualStyleBackColor = true;
            // 
            // cbAutoUpdate
            // 
            this.cbAutoUpdate.AutoSize = true;
            this.cbAutoUpdate.Checked = true;
            this.cbAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoUpdate.Location = new System.Drawing.Point(6, 19);
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.Size = new System.Drawing.Size(203, 18);
            this.cbAutoUpdate.TabIndex = 0;
            this.cbAutoUpdate.Text = "Automatically update application";
            this.cbAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gbCredentials);
            this.tabPage4.Controls.Add(this.cbUseCredentials);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(301, 336);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Security";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gbCredentials
            // 
            this.gbCredentials.Controls.Add(this.label5);
            this.gbCredentials.Controls.Add(this.txtDomain);
            this.gbCredentials.Controls.Add(this.label4);
            this.gbCredentials.Controls.Add(this.txtPassword);
            this.gbCredentials.Controls.Add(this.txtUsername);
            this.gbCredentials.Controls.Add(this.label3);
            this.gbCredentials.Controls.Add(this.label2);
            this.gbCredentials.Enabled = false;
            this.gbCredentials.Location = new System.Drawing.Point(31, 39);
            this.gbCredentials.Name = "gbCredentials";
            this.gbCredentials.Size = new System.Drawing.Size(233, 116);
            this.gbCredentials.TabIndex = 1;
            this.gbCredentials.TabStop = false;
            this.gbCredentials.Text = "Credentials";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "(if applicable)";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(93, 72);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(126, 20);
            this.txtDomain.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Domain";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(93, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(126, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username";
            // 
            // cbUseCredentials
            // 
            this.cbUseCredentials.Location = new System.Drawing.Point(7, 7);
            this.cbUseCredentials.Margin = new System.Windows.Forms.Padding(7);
            this.cbUseCredentials.Name = "cbUseCredentials";
            this.cbUseCredentials.Size = new System.Drawing.Size(286, 32);
            this.cbUseCredentials.TabIndex = 0;
            this.cbUseCredentials.Text = "Use security credentials to access updates.";
            this.cbUseCredentials.UseVisualStyleBackColor = true;
            this.cbUseCredentials.CheckedChanged += new System.EventHandler(this.cbUseCredentials_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(301, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Preserve";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(301, 336);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Remove";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tbRemove);
            this.groupBox4.Controls.Add(this.lbRemove);
            this.groupBox4.Controls.Add(this.btnRemoveRemove);
            this.groupBox4.Controls.Add(this.btnRemoveAdd);
            this.groupBox4.Controls.Add(this.cbRemove);
            this.groupBox4.Location = new System.Drawing.Point(7, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 324);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remove Files";
            // 
            // tbRemove
            // 
            this.tbRemove.Location = new System.Drawing.Point(6, 58);
            this.tbRemove.Name = "tbRemove";
            this.tbRemove.Size = new System.Drawing.Size(192, 20);
            this.tbRemove.TabIndex = 8;
            // 
            // lbRemove
            // 
            this.lbRemove.FormattingEnabled = true;
            this.lbRemove.ItemHeight = 14;
            this.lbRemove.Location = new System.Drawing.Point(6, 84);
            this.lbRemove.Name = "lbRemove";
            this.lbRemove.Size = new System.Drawing.Size(192, 228);
            this.lbRemove.TabIndex = 7;
            // 
            // btnRemoveRemove
            // 
            this.btnRemoveRemove.Location = new System.Drawing.Point(204, 84);
            this.btnRemoveRemove.Name = "btnRemoveRemove";
            this.btnRemoveRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRemove.TabIndex = 2;
            this.btnRemoveRemove.Text = "&Remove";
            this.btnRemoveRemove.UseVisualStyleBackColor = true;
            this.btnRemoveRemove.Click += new System.EventHandler(this.btnRemoveRemove_Click);
            // 
            // btnRemoveAdd
            // 
            this.btnRemoveAdd.Location = new System.Drawing.Point(204, 55);
            this.btnRemoveAdd.Name = "btnRemoveAdd";
            this.btnRemoveAdd.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAdd.TabIndex = 1;
            this.btnRemoveAdd.Text = "&Add";
            this.btnRemoveAdd.UseVisualStyleBackColor = true;
            this.btnRemoveAdd.Click += new System.EventHandler(this.btnRemoveAdd_Click);
            // 
            // cbRemove
            // 
            this.cbRemove.Location = new System.Drawing.Point(6, 19);
            this.cbRemove.Name = "cbRemove";
            this.cbRemove.Size = new System.Drawing.Size(273, 41);
            this.cbRemove.TabIndex = 0;
            this.cbRemove.Text = "Remove files that match the following pattern(s)";
            this.cbRemove.UseVisualStyleBackColor = true;
            this.cbRemove.CheckedChanged += new System.EventHandler(this.cbRemove_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 84);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(192, 225);
            this.listBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "&Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(273, 41);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Preserve (don\'t overwrite) files that match the following pattern(s)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 404);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.gbCredentials.ResumeLayout(false);
            this.gbCredentials.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbEnableUpdateLogging;
        private System.Windows.Forms.CheckBox cbDebugLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbKeepPrevVersions;
        private System.Windows.Forms.RadioButton rbKeepAll;
        private System.Windows.Forms.RadioButton rbDeleteAfter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumVersions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbPreserve;
        private System.Windows.Forms.Button btnPresRemove;
        private System.Windows.Forms.Button btnPresAdd;
        private System.Windows.Forms.CheckBox cbPreserve;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbPreserve;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbRemove;
        private System.Windows.Forms.ListBox lbRemove;
        private System.Windows.Forms.Button btnRemoveRemove;
        private System.Windows.Forms.Button btnRemoveAdd;
        private System.Windows.Forms.CheckBox cbRemove;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbAutoUpdate;
        private System.Windows.Forms.CheckBox cbUseSecurityFolder;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox gbCredentials;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbUseCredentials;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAppFolder;
        private System.Windows.Forms.Label label6;
    }
}