using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ComicDownloader.Properties;
namespace IView.Controls.Library
{
    public class DropDownPanel : Panel
    {
        private Panel m_oTitleBar;
        private Panel m_oTitleBarButton;
        private Label m_oTitleLabel;

        public DropDownPanel()
        {
            m_oTitleBarButton = new Panel();
            m_oTitleBarButton.Dock = DockStyle.Right;
            m_oTitleBarButton.BackgroundImage = Resources.arrow_down_16x16;
            m_oTitleBarButton.BackgroundImageLayout = ImageLayout.Center;
            m_oTitleBarButton.Size = new Size(16, 25);
            m_oTitleBarButton.MouseEnter += delegate(object sender, EventArgs e)
            {
                m_oTitleBarButton.BackColor = Color.SkyBlue;
            };
            m_oTitleBarButton.MouseLeave += delegate(object sender, EventArgs e)
            {
                m_oTitleBarButton.BackColor = Color.Gainsboro;
            };
            m_oTitleBarButton.Click += delegate(object sender, EventArgs e)
            {
                if (this.Height > 22)
                    this.Height = 22;
                else
                    this.Height = 100;
            };

            m_oTitleLabel = new Label();
            m_oTitleLabel.AutoEllipsis = true;
            m_oTitleLabel.AutoSize = false;
            m_oTitleLabel.Dock = DockStyle.Fill;
            m_oTitleLabel.Text = "DropDownPanel";
            m_oTitleLabel.TextAlign = ContentAlignment.MiddleLeft;

            m_oTitleBar = new Panel();
            m_oTitleBar.BackColor = Color.Gainsboro;
            m_oTitleBar.Dock = DockStyle.Top;
            m_oTitleBar.Size = new Size(this.Width, 20);
            m_oTitleBar.Controls.AddRange(new Control[] { m_oTitleBarButton, m_oTitleLabel });

            this.Controls.Add(m_oTitleBar);
        }
    }
}
