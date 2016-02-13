using System; using System.Net;
using System.Windows.Forms;

namespace Cx.Windows.Forms
{
	public partial class NoResizeChildForm : Form
	{
		#region Construction

		/// <summary>
		/// Creates a new NoResizeChildForm.
		/// </summary>
		public NoResizeChildForm()
		{
			InitializeComponent();
		}
		#endregion //--Construction


		#region Overrides

		/// <summary>
		/// Overridden. Sets WindowState to maximized if it is the first
		/// Mdi child added to its MdiParent.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			WindowState = FormWindowState.Maximized;
		}
		#endregion //--Overrides
	}
}