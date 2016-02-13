using System; using System.Net;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Cx.Windows.Forms
{
	/// <summary>
	/// A special button for MdiTabStrip. This button has an associated Form
	/// object that is hooked in to its events. This class overrides the OnPaint
	/// event to replace the drop-down portion of the button with a close box.
	/// </summary>
	public partial class MdiTabStripButton : ToolStripSplitButton
	{
		#region State

		private Form m_MdiChild;

		#endregion //--State


		#region Construction

		/// <summary>
		/// Constructs a new MdiTabStripButton with the given form.
		/// </summary>
		/// <param name="mdiChild"></param>
		public MdiTabStripButton(Form mdiChild)
		{
			if (null == mdiChild)
				throw new ArgumentNullException("mdiChild");

			InitializeComponent();
			SetMdiChild(mdiChild);
		}
		#endregion //--Construction


		#region Private and Protected Members

		/// <summary>
		/// Sets the form associated with this MdiTabStripButton.
		/// </summary>
		/// <param name="f"></param>
		private void SetMdiChild(Form f)
		{
			if (null == f)
				return;

			if (null != m_MdiChild)
			{
				m_MdiChild.Activated -= new EventHandler(FormActivated);
				m_MdiChild.HandleDestroyed -= new EventHandler(FormHandleDestroyed);
				m_MdiChild.TextChanged -= new EventHandler(FormTextChanged);
			}
			m_MdiChild = f;
			Text = f.Text;
			f.Activated += new EventHandler(FormActivated);
			f.HandleDestroyed += new EventHandler(FormHandleDestroyed);
			f.TextChanged += new EventHandler(FormTextChanged);
		}

		/// <summary>
		/// Event handler called when form activated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormActivated(object sender, EventArgs e)
		{
			MdiTabStrip ts = Owner as MdiTabStrip;
			if (null != ts)
				ts.SelectedTab = this;
		}

		/// <summary>
		/// Event handler called when form text changes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormTextChanged(object sender, EventArgs e)
		{
			Form f = sender as Form;
			Text = f.Text;
		}

		/// <summary>
		/// Event handler called when the form is destroyed. At this point,
		/// this button will remove itself from its Owner tab strip.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormHandleDestroyed(object sender, EventArgs e)
		{
			Form f = sender as Form;
			f.Activated -= new EventHandler(FormActivated);
			f.TextChanged -= new EventHandler(FormTextChanged);
			f.HandleDestroyed -= new EventHandler(FormHandleDestroyed);
			Owner.Items.Remove(this);
		}
		#endregion //--Private and Protected Members


		#region Overrides

		/// <summary>
		/// Overridden. Puts some space between tab buttons.
		/// </summary>
		protected override Padding DefaultMargin
		{
			get { return new Padding(0, 1, 5, 2); }
		}

		/// <summary>
		/// Overridden. Paints over the drop-down with an x.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			Rectangle blank = DropDownButtonBounds;
			int rxx = blank.X + 2;
			int rsize = blank.Width - 4;
			Rectangle r = new Rectangle(rxx, rsize, rsize, rsize);
			using (Brush b = new SolidBrush(BackColor))
			{
				g.FillRectangle(b, blank);
			}
			g.SmoothingMode = SmoothingMode.AntiAlias;
			using (Pen p = new Pen(CloseBoxColor, 2.0F))
			{
				g.DrawLine(p, r.Left, r.Top, r.Left + r.Width, r.Top + r.Height);
				g.DrawLine(p, r.Left, r.Top + r.Height, r.Left + r.Width, r.Top);
			}
			if (DrawBorder)
				DoDrawBorder(g);
		}

		/// <summary>
		/// Adds a gradient line to the top of the tab button. You can override
		/// this to do whatever you would like.
		/// </summary>
		/// <param name="g"></param>
		protected virtual void DoDrawBorder(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.Default;
			using (Pen p = new Pen(BorderColor, 2F))
			{
				p.Brush = new LinearGradientBrush(
					new Point(0, 0), new Point(Width / 2 + 2, 2),
					BackColor, BorderColor);
				g.DrawLine(p, 0, 1, Width / 2 + 2, 1);
				p.Brush = new LinearGradientBrush(
					new Point(Width / 2 - 2, 2), new Point(Width, 0),
					BorderColor, BackColor);
				g.DrawLine(p, Width / 2 - 2, 1, Width, 1);
			}
		}

		/// <summary>
		/// Overridden. Activates its Form.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnButtonClick(EventArgs e)
		{
			base.OnButtonClick(e);
			Form f = GetMdiChild();
			if (null != f)
				f.Activate();
		}

		/// <summary>
		/// Overridden. Acts as a Close() for its Form.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDropDownShow(EventArgs e)
		{
			base.OnDropDownShow(e);
			HideDropDown();
			Form f = GetMdiChild();
			if (null != f)
				f.Close();
		}

		/// <summary>
		/// Overridden to hide ForeColor.
		/// </summary>
		[
		Browsable(false)
		]
		public override Color ForeColor
		{
			get
			{
				if (IsSelectedTab)
					return ActiveForeColor;

				return InactiveForeColor;
			}
			set { }
		}
		#endregion //--Overrides


		#region Public Interface

		/// <summary>
		/// Gets the fore color if active.
		/// </summary>
		[
		Browsable(false)
		]
		public Color ActiveForeColor
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null != ts)
					return ts.ActiveForeColor;

				return MdiTabStrip.DefaultActiveForeColor;
			}
		}

		/// <summary>
		/// Gets the fore color if inactive.
		/// </summary>
		[
		Browsable(false)
		]
		public Color InactiveForeColor
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null != ts)
					return ts.InactiveForeColor;

				return MdiTabStrip.DefaultInactiveForeColor;
			}
		}

		/// <summary>
		/// Gets the current close box color.
		/// </summary>
		[
		Browsable(false)
		]
		public Color CloseBoxColor
		{
			get
			{
				if (IsSelectedTab)
					return ActiveCloseBoxColor;

				return InactiveCloseBoxColor;
			}
		}

		/// <summary>
		/// Gets the close box color if active.
		/// </summary>
		[
		Browsable(false)
		]
		public Color ActiveCloseBoxColor
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null != ts)
					return ts.ActiveCloseBoxColor;

				return MdiTabStrip.DefaultActiveCloseBoxColor;
			}
		}

		/// <summary>
		/// Gets the close box color if inactive.
		/// </summary>
		[
		Browsable(false)
		]
		public Color InactiveCloseBoxColor
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null != ts)
					return ts.InactiveCloseBoxColor;

				return MdiTabStrip.DefaultInactiveCloseBoxColor;
			}
		}

		/// <summary>
		/// Gets the current border color.
		/// </summary>
		[
		Browsable(false)
		]
		public Color BorderColor
		{
			get
			{
				if (IsSelectedTab)
					return ActiveBorderColor;

				return InactiveBorderColor;
			}
		}

		/// <summary>
		/// Gets the border color if active.
		/// </summary>
		[
		Browsable(false)
		]
		public Color ActiveBorderColor
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null != ts)
					return ts.ActiveBorderColor;

				return MdiTabStrip.DefaultActiveBorderColor;
			}
		}

		/// <summary>
		/// Gets the border color if inactive.
		/// </summary>
		[
		Browsable(false)
		]
		public Color InactiveBorderColor
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null != ts)
					return ts.InactiveBorderColor;

				return MdiTabStrip.DefaultInactiveBorderColor;
			}
		}

		/// <summary>
		/// Gets a value indicating whether to draw a border.
		/// </summary>
		[
		Browsable(false)
		]
		public bool DrawBorder
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null != ts)
					return ts.DrawBorder;

				return MdiTabStrip.DefaultDrawBorder;
			}
		}

		/// <summary>
		/// Gets whether this is the selected tab in the MdiTabStrip.
		/// </summary>
		[
		Browsable(false)
		]
		public bool IsSelectedTab
		{
			get
			{
				MdiTabStrip ts = Owner as MdiTabStrip;
				if (null == ts || !Equals(ts.SelectedTab))
					return false;

				return true;
			}
		}

		/// <summary>
		/// Gets the Form associated with this MdiTabStripButton.
		/// </summary>
		/// <returns></returns>
		public Form GetMdiChild()
		{
			return m_MdiChild;
		}
		#endregion //--Public Interface
	}
}
