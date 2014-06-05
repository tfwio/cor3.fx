/**
 * tfw * 2/25/2009 * 2:08 PM
**/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

using w32.kernel;

namespace Cor3.forms
{
	[Serializable,XmlRootAttribute("uifx-settings")]
	public class ui_fx_settings
	{
		[XmlElement("editor-font",typeof(ui_fx_settings_font))]
		public ui_fx_settings_font font_settings;
	}
	public class ui_fx_settings_font
	{
		[XmlAttribute("family")] public string Family;
		[XmlAttribute("size")] public float Size;
		[XmlIgnore] public Color ColourData = Color.Black;
		[XmlAttribute("colour")] public int Colour
		{
			get { return ColourData.ToArgb(); }
			set { ColourData = Color.FromArgb(0xff,Color.FromArgb(value)); }
		}
		public ui_fx_settings_font() {}
		public ui_fx_settings_font(Font fnt, Color clr) {}
	}
}
