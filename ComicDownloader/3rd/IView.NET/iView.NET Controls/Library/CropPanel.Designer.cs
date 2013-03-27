namespace IView.Controls.Library
{
    partial class CropPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scrollLabel1 = new IView.Controls.Library.ScrollLabel();
            this.scrollLabel2 = new IView.Controls.Library.ScrollLabel();
            this.scrollLabel3 = new IView.Controls.Library.ScrollLabel();
            this.scrollLabel4 = new IView.Controls.Library.ScrollLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(37, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 94);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 32);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(170, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // scrollLabel1
            // 
            this.scrollLabel1.AutoSize = true;
            this.scrollLabel1.Location = new System.Drawing.Point(3, 115);
            this.scrollLabel1.Maximum = 100;
            this.scrollLabel1.Minimum = 0;
            this.scrollLabel1.Name = "scrollLabel1";
            this.scrollLabel1.Size = new System.Drawing.Size(57, 13);
            this.scrollLabel1.TabIndex = 3;
            this.scrollLabel1.Text = "X Position:";
            this.scrollLabel1.Value = 0;
            // 
            // scrollLabel2
            // 
            this.scrollLabel2.AutoSize = true;
            this.scrollLabel2.Location = new System.Drawing.Point(3, 142);
            this.scrollLabel2.Maximum = 100;
            this.scrollLabel2.Minimum = 0;
            this.scrollLabel2.Name = "scrollLabel2";
            this.scrollLabel2.Size = new System.Drawing.Size(57, 13);
            this.scrollLabel2.TabIndex = 4;
            this.scrollLabel2.Text = "Y Position:";
            this.scrollLabel2.Value = 0;
            // 
            // scrollLabel3
            // 
            this.scrollLabel3.AutoSize = true;
            this.scrollLabel3.Location = new System.Drawing.Point(3, 169);
            this.scrollLabel3.Maximum = 100;
            this.scrollLabel3.Minimum = 0;
            this.scrollLabel3.Name = "scrollLabel3";
            this.scrollLabel3.Size = new System.Drawing.Size(39, 13);
            this.scrollLabel3.TabIndex = 5;
            this.scrollLabel3.Text = "Width:";
            this.scrollLabel3.Value = 0;
            // 
            // scrollLabel4
            // 
            this.scrollLabel4.AutoSize = true;
            this.scrollLabel4.Location = new System.Drawing.Point(3, 196);
            this.scrollLabel4.Maximum = 100;
            this.scrollLabel4.Minimum = 0;
            this.scrollLabel4.Name = "scrollLabel4";
            this.scrollLabel4.Size = new System.Drawing.Size(42, 13);
            this.scrollLabel4.TabIndex = 6;
            this.scrollLabel4.Text = "Height:";
            this.scrollLabel4.Value = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(66, 113);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(66, 140);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(66, 194);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown3.TabIndex = 10;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(66, 167);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown4.TabIndex = 9;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CropPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.scrollLabel4);
            this.Controls.Add(this.scrollLabel3);
            this.Controls.Add(this.scrollLabel2);
            this.Controls.Add(this.scrollLabel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CropPanel";
            this.Size = new System.Drawing.Size(170, 349);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ScrollLabel scrollLabel1;
        private ScrollLabel scrollLabel2;
        private ScrollLabel scrollLabel3;
        private ScrollLabel scrollLabel4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
    }
}
