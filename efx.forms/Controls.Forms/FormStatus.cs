
using System;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	/// <summary>
	/// this is just a placeholder for the progress-dialog which displays
	/// progress of the Image and XML Output functions
	/// <br/>
	/// FIXME: add cancel button.
	/// </summary>
	public partial class FormStatus : Form
	{
		public ProgressBar Prog { get { return this.progress; } }
		public FormStatus() { InitializeComponent(); }
	}
}
