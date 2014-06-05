/* oOo * 12/7/2007 : 8:39 AM */

using System;
using System.Drawing;
using Text;

namespace Text.TextPad
{
	public class LineMargin : MarginBase
	{
		public LineMargin(TextPanelBase parent, int lef) : base(parent,lef) {}
		#region PaintLine (PLine)
		public override void LPaint(MarginBase x, MarginPaintEvent me)
		{
			int ip =  me.line + P.LineOffset+1;
			if (ip>0 && ip <= (P as TextPanelBase).LinesAvail) me.gfx.DrawString(
					(ip).ToString(),
					P.Font,
					SystemBrushes.FromSystemColor(ForeColor),
					4,me.line*P.Font.Height
				);
			else 
			{
				me.gfx.DrawString(
					(0).ToString(),
					P.Font,
					SystemBrushes.FromSystemColor(SystemColors.ButtonHighlight),
					4,me.line*P.Font.Height
				);
				
			}
		}

		#endregion
	}
}
