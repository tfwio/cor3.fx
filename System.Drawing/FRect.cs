/* oOo * 11/28/2007 : 5:29 PM */
/* THIS CALSS HAS NOT YET FULLY BEEN TESTED */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace System.Drawing
{
	#region “ FRect ”
	public class FRect {
		static public FRect Zero { get { return new FRect(0,0,0,0); } }
		////////////////////////////////////////////////////////////////////////
		//
		[XmlIgnore] public FPoint Location = FPoint.Empty;
		[XmlIgnore] public FPoint Size = FPoint.Empty;
		////////////////////////////////////////////////////////////////////////
		//
		[XmlIgnore] public FPoint Center { get { return Size*0.5f; } }
		[XmlIgnore] public FPoint BottomRight { get { return Location+Size; } }
		////////////////////////////////////////////////////////////////////////
		//
		[XmlAttribute] public float X { get { return Location.X; } set { Location.X=value; } }
		[XmlAttribute] public float Y { get { return Location.Y; } set { Location.Y=value; } }
		/// <summary> (read only) </summary>
		[XmlIgnore] public float Top { get { return Location.Y; } /*set { Location.Y = value; }*/ }
		/// <summary> (read only) </summary>
		[XmlIgnore] public float Bottom { get { return Location.Y + Size.Y; } /*set { Size.Y = value-Location.Y; }*/ }
		[XmlIgnore] public float Left { get { return Location.X; } set { Location.X = value; } }
		/// <summary> (read only) </summary>
		[XmlIgnore] public float Right { get { return (Location.AddX(Size)).X; } /*set { Size.X = value-Location.X; }*/ }
		////////////////////////////////////////////////////////////////////////
		/// <summary> (read only) </summary>
		[XmlAttribute] public float Width { get {return Size.X; } set { Size.X = value; } }
		[XmlAttribute] public float Height { get { return Size.Y; } set { Size.Y = value; } }
		////////////////////////////////////////////////////////////////////////
		//	operator
		#region Standard +,-,*,/,++,--
		static public FRect operator +(FRect a, FRect b) { return new FRect(a.X+b.X,a.Y+b.Y,a.Width+b.Width,a.Height+b.Height); }
		static public FRect operator -(FRect a, FRect b){ return new FRect(a.X-b.X,a.Y-b.Y,a.Width-b.Width,a.Height-b.Height); }
		static public FRect operator /(FRect a, FRect b){ return new FRect(a.X/b.X,a.Y/b.Y,a.Width/b.Width,a.Height/b.Height); }
		static public FRect operator *(FRect a, FRect b){ return new FRect(a.X*b.X,a.Y*b.Y,a.Width*b.Width,a.Height*b.Height); }
		static public FRect operator %(FRect a, FRect b){ return new FRect(a.X%b.X,a.Y%b.Y,a.Width%b.Width,a.Height%b.Height); }
		static public FRect operator ++(FRect a) { return new FRect(a.X++,a.Y++,a.Width++,a.Height++); }
		static public FRect operator --(FRect a) { return new FRect(a.X--,a.Y--,a.Width--,a.Height--); }
		#endregion
		#region implicit operator Point,PointF
		static public implicit operator Rectangle(FRect a){ return new Rectangle((int)a.X,(int)a.Y,(int)a.Width,(int)a.Height); }
		static public implicit operator RectangleF(FRect a){ return new RectangleF(a.X,a.Y,a.Width,a.Height); }
		static public implicit operator Padding(FRect a){ return new Padding((int)a.X,(int)a.Y,(int)a.Width,(int)a.Height); }
		static public implicit operator FRect(Rectangle a){ return new FRect(a.X,a.Y,a.Right,a.Bottom); }
		static public implicit operator FRect(RectangleF a){ return new FRect(a.X,a.Y,a.Right,a.Bottom); }
		#endregion
		public FRect Clone(){ return new FRect(); }
		///	static FromControl Methods (relative to the control)
		static public FRect FromClientInfo(FPoint ClientSize, Padding pad){ return new FRect(FPoint.GetPaddingTopLeft(pad),ClientSize-FPoint.GetPaddingOffset(pad)); }
		///	static FromControl Methods (relative to the control)
		static public FRect FromControl(Control ctl, bool usepadding){ return FromControl(ctl,(usepadding)?ctl.Padding:Padding.Empty); }
		///	static FromControl Methods (relative to the control)
		static public FRect FromControl(Control ctl, Padding pad){ return new FRect(FPoint.GetPaddingTopLeft(pad),FPoint.GetClientSize(ctl)-FPoint.GetPaddingOffset(pad)); }
		/// <para>• p.Top,p.Right,p.Bottom,p.Left</para>
		static public FRect FromPadding(Padding p) { return new FRect(p.Left,p.Top,p.Right,p.Bottom); }
		//
		public FRect() {}
		public FRect(float x, float y, float width, float height) { Location = new FPoint(x,y); Size = new FPoint(width,height); }
		public FRect(int x, int y, int width, int height) : this((float)x,(float)y,(float)width,(float)height) {}
		public FRect(FPoint L, FPoint S) : this(L.X,L.Y,S.X,S.Y) {}
		public FRect(Rectangle R) : this(R.X,R.Y,R.Width,R.Height) { }
		public FRect(PointF Loc, SizeF Siz) : this(Loc.X,Loc.Y,Siz.Width,Siz.Height) {}
		
		public override bool Equals(object obj)
		{
			return obj.ToString()==ToString();
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override string ToString()
		{
			return string.Format("FRect: X:{0},Y:{1},Width:{2},Height:{3}", X,Y,Width,Height);
		}
	}
	#endregion
	

}
