using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace cor3.forms.controls.data
{
	public class grid_style
	{
		const string default_font_family_name = "Arial";
		const float default_font_size = 6F;
		const int default_font_style = (int)FontStyle.Regular;
		const int default_graphics_unit = (int)GraphicsUnit.Point;
		const byte default_font_bits_set = 0;
		Color _back,_fore,_sback,_sfore;
		Font _font = new Font(default_font_family_name, default_font_size,(FontStyle)default_font_style,(GraphicsUnit)default_graphics_unit,default_font_bits_set);
	
		public Color Background { get { return _back; } set { _back = value; } }
		public Color ForeGround { get { return _fore; } set { _fore = value; } }
		public Color BackgroundSecondary { get { return _sback; } set { _sback = value; } }
		public Color ForeGroundSecondary { get { return _sfore; } set { _sfore = value; } }
		public Font Font { get { return _font; } set { _font=value; } }

		public void Apply( DataGridViewCellStyle obj )
		{
			obj.Font = Font;
			obj.BackColor = Background;
			obj.ForeColor = ForeGround;
			obj.SelectionBackColor = BackgroundSecondary;
			obj.SelectionForeColor = ForeGroundSecondary;
		}
		public grid_style() : this(SystemColors.Desktop,SystemColors.WindowText,SystemColors.Highlight,SystemColors.HighlightText )
		{
		}
		public grid_style(Color b, Color f, Color sb, Color sf) : this(null,b,f,sb,sf)
		{
		}
		public grid_style(Font fnt, Color b, Color f, Color sb, Color sf)
		{
			if (fnt!=null) Font = fnt;
			Background = b;
			ForeGround = f;
			BackgroundSecondary = sb;
			ForeGroundSecondary = sf;
		}
	}
}
