/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Collections.Generic;
using System.Cor3;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace System.Cor3.Forms.typography
{
	public class FontList : ThreadClass
	{
		public InstalledFontCollection IFC;
		public List<string> ListFontFamily = new List<string>();
		public int InstalledFonts = -1;
		public override void Begin()
		{
			base.Begin();
			using (IFC = new InstalledFontCollection())
			{
				int count = 0;
				InstalledFonts = IFC.Families.Length;
				foreach (FontFamily ff in IFC.Families)
				{
					ListFontFamily.Add(ff.Name);
					count++;
					OnProgress(count,InstalledFonts);
				}
			}
		}

		public FontList(bool AutoLoad,ToolStripProgressBar bar) : base(AutoLoad)
		{
		}
	}
}
