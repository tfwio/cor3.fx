/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

using drawing;

namespace System.Cor3.Forms.typography.text
{
	public class Row 
	{
		public bool IsMeasured = false;

		#region Format
		public Font Font;
		public FloatPoint LayoutPosition	= FloatPoint.Empty;
		public FloatPoint LayoutSize		= FloatPoint.Empty;
		public StringFormat Format	= StringFormat.GenericTypographic;
//		FontStyle fs = FontStyle.Regular;
		StringFormatFlags Flags = StringFormatFlags.MeasureTrailingSpaces/*|StringFormatFlags.NoWrap*/;
		public StringFormat StrFormat {
			get
			{
				StringFormat fx = Format;
				fx.FormatFlags = Flags;
				fx.Trimming = StringTrimming.Word;
				fx.SetTabStops(0f,new float[]{4f});
				return fx;
			}
		}
		#endregion
		public RectangleF LayoutRect
		{
			get { return new RectangleF(LayoutPosition,LayoutSize); }
			set { LayoutPosition = value.Location; LayoutSize = value.Size; }
		}

		public string StringValue = string.Empty;
		public Row(string value, Font fnt) { StringValue = value; Font = fnt; }

		#region GraphicsHelpers
		public CharacterRange[] MeasurableRanges
		{
			get
			{
				List<CharacterRange> CR = new List<CharacterRange>();
				int counter = 0;
				if (StringValue == string.Empty) return null;
				foreach (char c in StringValue)
				{
					CR.Add(new CharacterRange(counter++,1));
				}
				return CR.ToArray();
			}
		}
		public Region[] MeasureGraphics(Graphics fx)
		{
			IsMeasured = true;
			return fx.MeasureCharacterRanges(StringValue,Font,LayoutRect,StrFormat);
		}
		#endregion

		public GraphicsPath StringPath
		{
			get
			{
				GraphicsPath gp = new GraphicsPath();
				gp.AddString(
					StringValue,
					Font.FontFamily,
					(int)Font.Style,
					Font.SizeInPoints,
					LayoutRect,
					StrFormat
				);
				return gp;
			}
		}
		public void Render(Graphics fx)
		{
			GraphicsState gs = fx.Save();
			using (GraphicsPath gp = StringPath)
				using (Brush b = new SolidBrush(Color.FromArgb(0,127,255)))
					fx.FillPath(b,gp);
			fx.Restore(gs);
		}
		
	}
}
