namespace IView.Controls.Library
{
    partial class ColourPicker
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
            this.components = new System.ComponentModel.Container();
            this.cbx_Colours = new System.Windows.Forms.ComboBox();
            this.tt_Info = new System.Windows.Forms.ToolTip(this.components);
            this.sbtn_Colour = new IView.Controls.Library.SplitButton();
            this.SuspendLayout();
            // 
            // cbx_Colours
            // 
            this.cbx_Colours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Colours.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_Colours.DropDownHeight = 243;
            this.cbx_Colours.FormattingEnabled = true;
            this.cbx_Colours.IntegralHeight = false;
            this.cbx_Colours.Location = new System.Drawing.Point(24, 3);
            this.cbx_Colours.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbx_Colours.Name = "cbx_Colours";
            this.cbx_Colours.Size = new System.Drawing.Size(148, 22);
            this.cbx_Colours.TabIndex = 0;
            this.cbx_Colours.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbx_Colours_DrawItem);
            this.cbx_Colours.SelectedIndexChanged += new System.EventHandler(this.cbx_Colours_SelectedIndexChanged);
            this.cbx_Colours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbx_Colours_KeyPress);
            // 
            // sbtn_Colour
            // 
            this.sbtn_Colour.BorderColour = System.Drawing.Color.Black;
            this.sbtn_Colour.DisplayColour = System.Drawing.Color.White;
            this.sbtn_Colour.FlatAppearance.BorderSize = 0;
            this.sbtn_Colour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Goldenrod;
            this.sbtn_Colour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGoldenrod;
            this.sbtn_Colour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sbtn_Colour.Location = new System.Drawing.Point(0, 3);
            this.sbtn_Colour.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.sbtn_Colour.Name = "sbtn_Colour";
            this.sbtn_Colour.ShowDisplayColour = true;
            this.sbtn_Colour.Size = new System.Drawing.Size(21, 21);
            this.sbtn_Colour.TabIndex = 1;
            this.tt_Info.SetToolTip(this.sbtn_Colour, "Advanced Colour Picker");
            this.sbtn_Colour.UseVisualStyleBackColor = false;
            this.sbtn_Colour.Click += new System.EventHandler(this.sbtn_Colour_Click);
            // 
            // ColourPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbtn_Colour);
            this.Controls.Add(this.cbx_Colours);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ColourPicker";
            this.Size = new System.Drawing.Size(172, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Colours;
        private SplitButton sbtn_Colour;
        private System.Windows.Forms.ToolTip tt_Info;
    }
}
