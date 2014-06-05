/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using System.Xml.Serialization;

namespace System.Cor3.Forms.typography
{
	public class ColourEntry : StyleEntryBase
	{
		public Color Background, Foreground;

		public ColourEntry(Color bg, Color fg) : base() { Background = bg; Foreground = fg; }
		public ColourEntry(string name, Color bg, Color fg) : base(name) { Background = bg; Foreground = fg; }
		public ColourEntry() : this(string.Empty,SystemColors.Window,SystemColors.WindowText) { }
		public ColourEntry(System.Windows.Forms.Control ctl)
		{
			Background = ctl.BackColor;
			Foreground = ctl.ForeColor;
		}

		static public ColourEntry Window { get { return new ColourEntry(); } }
		static public ColourEntry ActiveCaption { get { return new ColourEntry(SystemColors.ActiveCaption,SystemColors.ActiveCaptionText); } }
		static public ColourEntry Highlight { get { return new ColourEntry(SystemColors.Highlight,SystemColors.HighlightText); } }
		static public ColourEntry Info { get { return new ColourEntry(SystemColors.Info,SystemColors.InfoText); } }
		static public ColourEntry Menu { get { return new ColourEntry(SystemColors.Menu,SystemColors.MenuText); } }
		static public ColourEntry MenuBar { get { return new ColourEntry(SystemColors.MenuBar,SystemColors.MenuText); } }
//		static implicit operator Color(ColourStyle style) { return style.Normal; }
	
	}
}
