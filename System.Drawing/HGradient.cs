/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.ComponentModel;

namespace System.Drawing
{
	public class HGradient
	{
		public enum Alignment { Horizontal,Vertical }
		static Color def_color0 = Color.Black, def_color1 = Color.White;
		const float def_spread_distance = 12;
		const float def_spread_offset = 0; // probably not be used yet

		public Color Gra0, Gra1;
		public Alignment Align;
		public float Spread
		{
			get { return (Align==Alignment.Horizontal)?this.hpSpread.X:this.hpSpread.Y;}
			set { hpSpread=(Align==Alignment.Horizontal)?new FPoint(value,0):new FPoint(0,value); }
		}

		FPoint hpSpread;
		[TypeConverter(typeof(ExpandableObjectConverter))]
		/// <summary>
		/// note: the point is scaled down by a value of 'new Point(-1,-1)' so
		/// that drawing can happen within borders as this is designated for
		/// drawing backgrounds within the borders of a control.
		/// I expect to have a control using this to perhaps utilize a padding factor.
		/// </summary>
		public FPoint HSpread { get { return hpSpread; } set { hpSpread=value-1; } }
		/// <summary>Default alignment is Alignment.Horizontal</summary>
		public HGradient() : this(def_color0,def_color1,Alignment.Horizontal,def_spread_distance) { }
		public HGradient(Alignment align) : this(def_color0,def_color1,align,40f) { }
		public HGradient(Color g0, Color g1, Alignment align, FPoint spread) { Gra0=g0; Gra1=g1; Align=Alignment.Horizontal; hpSpread=spread; }
		public HGradient(Color g0, Color g1, Alignment align, float spread) { Gra0=g0; Gra1=g1; Align=Alignment.Horizontal; Spread=spread; }
		public Brush LinearGradientBrush { get { return Gradients.GetLinearGradient(FPoint.One,hpSpread,Gra0,Gra1);} }
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Brush GradientBrush { get { return (Brush)Gradients.GetLinearGradient(FPoint.One,hpSpread,Gra0,Gra1);} }
	}
}
