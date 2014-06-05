/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace drawing.util
{
	public class TextFormat
	{
		public const StringFormatFlags FlagsBasic = StringFormatFlags.FitBlackBox;
		static public StringFormat Base { get { return new StringFormat(); } }
		static public StringFormat DefaultBox
		{
			get
			{
				StringFormat format = Base;
				format.Alignment = StringAlignment.Near;
				format.FormatFlags = FlagsBasic;
				//format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.
				format.LineAlignment = StringAlignment.Near;
				format.Trimming = StringTrimming.Word;
				return format;
			}
		}
	}
}
