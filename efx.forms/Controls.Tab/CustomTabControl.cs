/* oOo * 12/12/2007 : 9:18 AM
 * AKA: DocumentManager
**/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class CustomTabControl : System.Windows.Forms.TabControl 
	{
		protected override Padding DefaultMargin {
			get { return new Padding(0); }
		}
		protected override Padding DefaultPadding {
			get { return new Padding(0); }
		}
		public CustomTabControl() : base() {}
		public override Font Font { get { return new Font(SystemFonts.MenuFont.FontFamily.Name,6.5f); } }
	}
}
