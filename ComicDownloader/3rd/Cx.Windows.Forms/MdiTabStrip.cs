using System; using System.Net;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Cx.Windows.Forms
{
	/// <summary>
	/// A special ToolStrip for tracking Mdi children in an Mdi parent form.
	/// </summary>
	public partial class MdiTabStrip : ToolStrip
	{
		#region State

		private static Color s_ActiveForeColor = DefaultForeColor;
		private static Color s_InactiveForeColor = Color.Gray;
		private static Color s_ActiveCloseBoxColor = Color.DarkOrange;
		private static Color s_InactiveCloseBoxColor = Color.Gray;
		private static Color s_ActiveBorderColor = Color.Silver;
		private static Color s_InactiveBorderColor = Color.White;
		private static bool s_ActiveIsBold = true;
		private static bool s_DrawBorder;
		private Color m_ActiveForeColor;
		private Color m_InactiveForeColor;
		private Color m_ActiveCloseBoxColor;
		private Color m_InactiveCloseBoxColor;
		private Color m_ActiveBorderColor;
		private Color m_InactiveBorderColor;
		private bool m_ActiveIsBold;
		private bool m_DrawBorder;
		private MdiTabStripButton m_SelectedTab;

		#endregion //--State


		#region Construction

		/// <summary>
		/// Constructs a new TabStrip with default values.
		/// </summary>
		public MdiTabStrip()
		{
			m_ActiveForeColor = DefaultActiveForeColor;
			m_InactiveCloseBoxColor = DefaultInactiveCloseBoxColor;
			m_ActiveCloseBoxColor = DefaultActiveCloseBoxColor;
			m_InactiveForeColor = DefaultInactiveForeColor;
			m_ActiveBorderColor = DefaultActiveBorderColor;
			m_InactiveBorderColor = DefaultInactiveBorderColor;
			m_ActiveIsBold = DefaultActiveIsBold;
			m_DrawBorder = DefaultDrawBorder;
			InitializeComponent();
			Renderer = new ToolStripSystemRenderer();
		}
		#endregion //--Construction


		#region Default Properties

		/// <summary>
		/// Gets or sets the default fore color for the active tab.
		/// </summary>
		public static Color DefaultActiveForeColor
		{
			get { return s_ActiveForeColor; }
			set { s_ActiveForeColor = value; }
		}

		/// <summary>
		/// Gets or sets the default fore color for inactive tabs.
		/// </summary>
		public static Color DefaultInactiveForeColor
		{
			get { return s_InactiveForeColor; }
			set { s_InactiveForeColor = value; }
		}

		/// <summary>
		/// Gets or sets the default close box color for the active tab.
		/// </summary>
		public static Color DefaultActiveCloseBoxColor
		{
			get { return s_ActiveCloseBoxColor; }
			set { s_ActiveCloseBoxColor = value; }
		}

		/// <summary>
		/// Gets or sets the default close box color for inactive tabs.
		/// </summary>
		public static Color DefaultInactiveCloseBoxColor
		{
			get { return s_InactiveCloseBoxColor; }
			set { s_InactiveCloseBoxColor = value; }
		}

		/// <summary>
		/// Gets or sets the default border color for the active tab.
		/// </summary>
		public static Color DefaultActiveBorderColor
		{
			get { return s_ActiveBorderColor; }
			set { s_ActiveBorderColor = value; }
		}

		/// <summary>
		/// Get or sets the default border color for inactive tabs.
		/// </summary>
		public static Color DefaultInactiveBorderColor
		{
			get { return s_InactiveBorderColor; }
			set { s_InactiveBorderColor = value; }
		}

		/// <summary>
		/// Gets or sets the default bold text property.
		/// </summary>
		public static bool DefaultActiveIsBold
		{
			get { return s_ActiveIsBold; }
			set { s_ActiveIsBold = value; }
		}

		/// <summary>
		/// Gets or sets the default draw border property.
		/// </summary>
		public static bool DefaultDrawBorder
		{
			get { return s_DrawBorder; }
			set { s_DrawBorder = value; }
		}
		#endregion //--Default Properties


		#region Private and Protected Members

		/// <summary>
		/// Creates and returns a new MdiTabStripButton. You can override
		/// this method to return a derived version of MdiTabStripButton if
		/// you wish.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		protected virtual MdiTabStripButton CreateMdiButton(Form f)
		{
			return new MdiTabStripButton(f);
		}

		/// <summary>
		/// Event handler hooked to MdiChildActivate event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMdiChildActivate(object sender, EventArgs e)
		{
			Form f = sender as Form;
			AddMdiChild(f.ActiveMdiChild);
			OnFormMdiChildActivate(f.ActiveMdiChild);
		}

		/// <summary>
		/// Called when a form is activated by the Mdi parent form.
		/// </summary>
		/// <param name="activeForm"></param>
		protected virtual void OnFormMdiChildActivate(Form activeForm)
		{
		}
		#endregion //--Private and Protected Members


		#region Overrides

		/// <summary>
		/// Overridden. Hooks to the Mdi form's MdiChildActivate event.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			Form mdiForm = FindForm();
			if (null != mdiForm && mdiForm.IsMdiContainer)
				mdiForm.MdiChildActivate += new EventHandler(FormMdiChildActivate);
		}

		/// <summary>
		/// Overridden. Unhooks the Mdi form when destroyed.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			Form mdiForm = FindForm();
			if (null != mdiForm && mdiForm.IsMdiContainer)
				mdiForm.MdiChildActivate -= new EventHandler(FormMdiChildActivate);
		}

		/// <summary>
		/// Overridden. Disallows anything but TabStripButton.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnItemAdded(ToolStripItemEventArgs e)
		{
			if (!(e.Item is MdiTabStripButton))
			{
				Items.Remove(e.Item);

				return;
			}
			base.OnItemAdded(e);
		}

		/// <summary>
		/// Shadowed to disallow property setter.
		/// </summary>
		[
		Browsable(false)
		]
		public new ToolStripRenderMode RenderMode
		{
			get { return ToolStripRenderMode.Custom; }
			set { }
		}

		/// <summary>
		/// Shadowed to disallow property setter.
		/// </summary>
		[
		Browsable(false)
		]
		public new ToolStripGripStyle GripStyle
		{
			get { return ToolStripGripStyle.Hidden; }
			set { base.GripStyle = ToolStripGripStyle.Hidden; }
		}

		/// <summary>
		/// Overridden to hide from property browser.
		/// </summary>
		[
		Browsable(false)
		]
		public override ToolStripItemCollection Items
		{
			get { return base.Items; }
		}

		/// <summary>
		/// Shadowed to disallow property setter.
		/// </summary>
		[
		Browsable(false)
		]
		public new bool ShowItemToolTips
		{
			get { return false; }
			set { base.ShowItemToolTips = false; }
		}
		#endregion //--Overrides


		#region Public Interface

		/// <summary>
		/// Gets or sets the fore color for the active tab.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(typeof(Color), "ControlText")
		]
		public Color ActiveForeColor
		{
			get { return m_ActiveForeColor; }
			set
			{
				if (value == ActiveForeColor)
					return;

				m_ActiveForeColor = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the fore color for inactive tabs.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(typeof(Color), "Gray")
		]
		public Color InactiveForeColor
		{
			get { return m_InactiveForeColor; }
			set
			{
				if (value == InactiveForeColor)
					return;

				m_InactiveForeColor = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the close box color for the active tab.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(typeof(Color), "DarkOrange")
		]
		public Color ActiveCloseBoxColor
		{
			get { return m_ActiveCloseBoxColor; }
			set
			{
				if (value == ActiveCloseBoxColor)
					return;

				m_ActiveCloseBoxColor = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the close box color for inactive tabs.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(typeof(Color), "Gray")
		]
		public Color InactiveCloseBoxColor
		{
			get { return m_InactiveCloseBoxColor; }
			set
			{
				if (value == InactiveCloseBoxColor)
					return;

				m_InactiveCloseBoxColor = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the border color for the active tab.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(typeof(Color), "Silver")
		]
		public Color ActiveBorderColor
		{
			get { return m_ActiveBorderColor; }
			set
			{
				if (value == ActiveBorderColor)
					return;

				m_ActiveBorderColor = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the border color for inactive tabs.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(typeof(Color), "White")
		]
		public Color InactiveBorderColor
		{
			get { return m_InactiveBorderColor; }
			set
			{
				if (value == InactiveBorderColor)
					return;

				m_InactiveBorderColor = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets whether to use bold text for active tab.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(true)
		]
		public bool ActiveIsBold
		{
			get { return m_ActiveIsBold; }
			set
			{
				if (value == ActiveIsBold)
					return;

				m_ActiveIsBold = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets whether to draw a border on the tab.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(false)
		]
		public bool DrawBorder
		{
			get { return m_DrawBorder; }
			set
			{
				if (value == DrawBorder)
					return;

				m_DrawBorder = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Gets or sets the selected tab.
		/// </summary>
		[
		Browsable(false)
		]
		public MdiTabStripButton SelectedTab
		{
			get { return m_SelectedTab; }
			set
			{
				if (null == value || !Equals(value.Owner))
					return;

				if (value.Equals(m_SelectedTab))
					return;

				m_SelectedTab = value;
				foreach (MdiTabStripButton tsb in Items)
				{
					tsb.Font = Font;
					tsb.Invalidate();
				}
				if (ActiveIsBold)
					m_SelectedTab.Font = new Font(Font, FontStyle.Bold);
				OnItemClicked(new ToolStripItemClickedEventArgs(value));
			}
		}

		/// <summary>
		/// Finds a tab from a Form.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public MdiTabStripButton FindTab(Form f)
		{
			if (null == f)
				return null;

			foreach (MdiTabStripButton tsb in Items)
			{
				if (f.Equals(tsb.GetMdiChild()))
					return tsb;
			}

			return null;
		}

		/// <summary>
		/// Gets a value indicating if the Form can be found in any of the tabs.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public bool ContainsMdiChild(Form f)
		{
			if (null == f)
				return false;

			foreach (MdiTabStripButton tsb in Items)
			{
				if (f.Equals(tsb.GetMdiChild()))
					return true;
			}

			return false;
		}

		/// <summary>
		/// Adds a tab with the given Form. If the Form is already in the
		/// tab collection, it just selects the tab.
		/// </summary>
		/// <param name="f"></param>
		public void AddMdiChild(Form f)
		{
			if (null == f)
				return;

			MdiTabStripButton tsb = FindTab(f);
			if (null != tsb)
				SelectedTab = tsb;
			else
			{
				tsb = CreateMdiButton(f);
				Items.Add(tsb);
				SelectedTab = tsb;
			}
		}
		#endregion //--Public Interface
	}
}
