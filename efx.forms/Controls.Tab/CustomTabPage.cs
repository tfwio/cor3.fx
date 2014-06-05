/* oOo * 12/12/2007 : 9:18 AM
 * AKA: DocumentManager
**/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class CustomTabPage : TabPage
	{
		public CustomTabPage() : base() {}
		public CustomTabPage(string txt) : base(txt) {}

		public override Font Font { get { return new Font(SystemFonts.MenuFont.FontFamily.Name,6.5f); } }
		protected override Padding DefaultPadding { get { return new Padding(0); } }
		protected override Padding DefaultMargin { get { return new Padding(0); } }
	}
}
