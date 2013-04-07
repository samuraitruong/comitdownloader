namespace ComicDownoader.Forms
{
    partial class ReadOnlineForm
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
            if (disposing)
            {
                if (m_oBlankCursor != null)
                {
                    m_oBlankCursor.Dispose();
                    m_oBlankCursor = null;
                }
            }

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadOnlineForm));
            this.tim_SlideShowTimer = new System.Windows.Forms.Timer(this.components);
            this.cms_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_PlayPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Previous = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_NormalTransition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_FadeTransition = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.bntNext = new System.Windows.Forms.Button();
            this.bntPre = new System.Windows.Forms.Button();
            this.bntPlay = new System.Windows.Forms.Button();
            this.cms_Options.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tim_SlideShowTimer
            // 
            this.tim_SlideShowTimer.Interval = 10;
            this.tim_SlideShowTimer.Tick += new System.EventHandler(this.tim_SlideShowTimer_Tick);
            // 
            // cms_Options
            // 
            this.cms_Options.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_PlayPause,
            this.tss_01,
            this.tsmi_Next,
            this.tsmi_Previous,
            this.tss_02,
            this.tsmi_NormalTransition,
            this.tsmi_FadeTransition,
            this.tss_03,
            this.tsmi_Close});
            this.cms_Options.Name = "cms_Options";
            this.cms_Options.Size = new System.Drawing.Size(158, 154);
            this.cms_Options.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cms_Options_Closing);
            this.cms_Options.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Options_Opening);
            // 
            // tsmi_PlayPause
            // 
            this.tsmi_PlayPause.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_PlayPause.Image")));
            this.tsmi_PlayPause.Name = "tsmi_PlayPause";
            this.tsmi_PlayPause.Size = new System.Drawing.Size(157, 22);
            this.tsmi_PlayPause.Text = "Play";
            this.tsmi_PlayPause.Click += new System.EventHandler(this.tsmi_PlayPause_Click);
            // 
            // tss_01
            // 
            this.tss_01.Name = "tss_01";
            this.tss_01.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmi_Next
            // 
            this.tsmi_Next.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Next.Image")));
            this.tsmi_Next.Name = "tsmi_Next";
            this.tsmi_Next.Size = new System.Drawing.Size(157, 22);
            this.tsmi_Next.Text = "Next";
            this.tsmi_Next.Click += new System.EventHandler(this.tsmi_Next_Click);
            // 
            // tsmi_Previous
            // 
            this.tsmi_Previous.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Previous.Image")));
            this.tsmi_Previous.Name = "tsmi_Previous";
            this.tsmi_Previous.Size = new System.Drawing.Size(157, 22);
            this.tsmi_Previous.Text = "Previous";
            this.tsmi_Previous.Click += new System.EventHandler(this.tsmi_Previous_Click);
            // 
            // tss_02
            // 
            this.tss_02.Name = "tss_02";
            this.tss_02.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmi_NormalTransition
            // 
            this.tsmi_NormalTransition.Name = "tsmi_NormalTransition";
            this.tsmi_NormalTransition.Size = new System.Drawing.Size(157, 22);
            this.tsmi_NormalTransition.Text = "Normal Transition";
            this.tsmi_NormalTransition.Click += new System.EventHandler(this.tsmi_NormalTransition_Click);
            // 
            // tsmi_FadeTransition
            // 
            this.tsmi_FadeTransition.Name = "tsmi_FadeTransition";
            this.tsmi_FadeTransition.Size = new System.Drawing.Size(157, 22);
            this.tsmi_FadeTransition.Text = "Fade Transition";
            this.tsmi_FadeTransition.Click += new System.EventHandler(this.tsmi_FadeTransition_Click);
            // 
            // tss_03
            // 
            this.tss_03.Name = "tss_03";
            this.tss_03.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmi_Close
            // 
            this.tsmi_Close.Name = "tsmi_Close";
            this.tsmi_Close.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmi_Close.Size = new System.Drawing.Size(157, 22);
            this.tsmi_Close.Text = "&Close";
            this.tsmi_Close.Click += new System.EventHandler(this.tsmi_Close_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.bntNext);
            this.panel1.Controls.Add(this.bntPre);
            this.panel1.Controls.Add(this.bntPlay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 200);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // button3
            // 
            this.button3.Image = global::ComicDownloader.Properties.Resources._1365339875_Close;
            this.button3.Location = new System.Drawing.Point(3, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bntNext
            // 
            this.bntNext.Image = global::ComicDownloader.Properties.Resources._1365339806_Next;
            this.bntNext.Location = new System.Drawing.Point(3, 107);
            this.bntNext.Name = "bntNext";
            this.bntNext.Size = new System.Drawing.Size(25, 25);
            this.bntNext.TabIndex = 2;
            this.bntNext.UseVisualStyleBackColor = true;
            this.bntNext.Click += new System.EventHandler(this.bntNext_Click);
            // 
            // bntPre
            // 
            this.bntPre.Image = global::ComicDownloader.Properties.Resources._1365339812_Previous;
            this.bntPre.Location = new System.Drawing.Point(3, 49);
            this.bntPre.Name = "bntPre";
            this.bntPre.Size = new System.Drawing.Size(25, 25);
            this.bntPre.TabIndex = 1;
            this.bntPre.UseVisualStyleBackColor = true;
            this.bntPre.Click += new System.EventHandler(this.bntPre_Click);
            // 
            // bntPlay
            // 
            this.bntPlay.Image = global::ComicDownloader.Properties.Resources._1365339292_play;
            this.bntPlay.Location = new System.Drawing.Point(3, 78);
            this.bntPlay.Name = "bntPlay";
            this.bntPlay.Size = new System.Drawing.Size(25, 25);
            this.bntPlay.TabIndex = 0;
            this.bntPlay.UseVisualStyleBackColor = true;
            this.bntPlay.Click += new System.EventHandler(this.bntPlay_Click);
            // 
            // ReadOnlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReadOnlineForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "iView.NET Slide Show";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SlideShow_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ReadOnlineForm_MouseMove);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SlideShow_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.ReadOnlineForm_Resize);
            this.cms_Options.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tim_SlideShowTimer;
        private System.Windows.Forms.ContextMenuStrip cms_Options;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Close;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NormalTransition;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PlayPause;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Next;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Previous;
        private System.Windows.Forms.ToolStripSeparator tss_01;
        private System.Windows.Forms.ToolStripSeparator tss_02;
        private System.Windows.Forms.ToolStripSeparator tss_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_FadeTransition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bntPlay;
        private System.Windows.Forms.Button bntNext;
        private System.Windows.Forms.Button bntPre;
        private System.Windows.Forms.Button button3;
    }
}