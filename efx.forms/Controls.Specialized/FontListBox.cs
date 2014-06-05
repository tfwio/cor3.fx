/* oOo * 12/27/2007 : 2:22 PM */

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class FontListBox : LvTrack2
	{
		public enum API
		{
			InitFonts
		}
		public void fun(API fun)
		{
			switch (fun)
			{
				case API.InitFonts:
					InstalledFontCollection ifc = new InstalledFontCollection();
					foreach (FontFamily fnt in ifc.Families)
					{
						Items.Add(fnt.Name);
					}
					break;
			}
		}
		public FontListBox() : base()
		{
			OwnerDraw = true;
			fun(API.InitFonts);
		}
		protected override void OnDrawItem(DrawListViewItemEventArgs e)
		{
			base.OnDrawItem(e);
		}
		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
		{
			base.OnDrawSubItem(e);
		}
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}
	}
}
