/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using System.Xml.Serialization;

using drawing;

namespace System.Cor3.Forms.typography
{
	public class FontTableEntry : FontFormatSettings,IFontTableEntry
	{
		public FontFamily			Family;
		public Font				FontGet		{ get { return new Font(Family,Size,Style); } }
		/// ¡ uses the font as a reference point to create a font entry !
		public FontTableEntry(Font font) : base(StringFormatFlags.MeasureTrailingSpaces)
		{
			Family = font.FontFamily;
			if (SupportsStyle(font.Style)) Style = font.Style;
			Size = font.Size;
		}
		/// Indirect ¡ FontFamily.IsStyleAvailable( FontStyle style )
		public bool SupportsStyle(FontStyle fstyle) { return Family.IsStyleAvailable( fstyle ); }
		public FloatRect MeasureLayout(Graphics fx, RectangleF lrect, string str)
		{
			FloatPoint size = FloatPoint.Empty; int chars_fitted=0,lines_filled=0;
			// See: “PageUnit” resolution 
			using (Font f = FontGet) size = fx.MeasureString(str, f, (SizeF)lrect.Size, Format, out chars_fitted, out lines_filled);
			return new FloatRect(new FloatPoint(chars_fitted,lines_filled),size);
		}
	}
}
