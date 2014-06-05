/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

using drawing;

namespace drawing.forms.controls
{
	// should tabs be somewhere around here?
	public class FontSettings : OutlineSettings
	{
		public FontFamily fnt_fam;
		public FontStyle fnt_style;
		public int fnt_stylebits { get { return (int) fnt_style; } }
		public float fnt_size;
		public Color fnt_color;
		public StringFormat fnt_fmt;

		public FontSettings(Font font, float s, Color c, Color o_clr)
			: this(font,s,c,255,o_clr,200,2f,StringFormat.GenericTypographic) { }
		public FontSettings(Font font, float s)
			: this(font,s,Color.FromArgb(0,127,255),255,Color.White,200,2f,StringFormat.GenericTypographic) { }
		public FontSettings(Font font, float s, Color c, int a, Color o_clr, int o_alpha, float o_siz, StringFormat fmt)
			: base(o_clr,o_alpha,o_siz, PenAlignment.Outset)
		{
			fnt_fam = font.FontFamily;
			fnt_size = s;
			fnt_color = Color.FromArgb(a,c);
			fnt_fmt = fmt;
		}

		public GraphicsPath EmptyPath {
			get {
				return new GraphicsPath();
			}
		}
		SmoothingMode sm = SmoothingMode.HighQuality,bsm;
		InterpolationMode im = InterpolationMode.HighQualityBicubic,bim;
		
		public void RenderString(Graphics fx, string str, FloatPoint point)
		{
			bsm = fx.SmoothingMode;
			bim = fx.InterpolationMode;
			fx.SmoothingMode = sm;
			fx.InterpolationMode = im;
			using (GraphicsPath gp = EmptyPath) {
				gp.AddString(str,fnt_fam,fnt_stylebits,fnt_size,point,fnt_fmt);
				using (Pen p = new Pen(oline_color,oline_width)) fx.DrawPath(p,gp);
				using (Brush b = new SolidBrush(fnt_color)) fx.FillPath(b,gp);
			}
			fx.SmoothingMode = bsm;
			fx.InterpolationMode = bim;
		}
		public void RenderString(Graphics fx, string str, RectangleF rect)
		{
			bsm = fx.SmoothingMode;
			bim = fx.InterpolationMode;
			fx.SmoothingMode = sm;
			fx.InterpolationMode = im;
			using (GraphicsPath gp = EmptyPath) {
				gp.AddString(str,fnt_fam,fnt_stylebits,fnt_size,rect,fnt_fmt);
				using (Pen p = new Pen(oline_color,oline_width)) fx.DrawPath(p,gp);
				using (Brush b = new SolidBrush(fnt_color)) fx.FillPath(b,gp);
			}
			fx.SmoothingMode = bsm;
			fx.InterpolationMode = bim;
		}
	}
}
