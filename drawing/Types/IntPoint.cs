/* oOo * 11/28/2007 : 5:29 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

using drawing.types;

namespace drawing
{
	/// <remarks>
	/// Only Add and Neg calls have Integer parameters when compared to the
	/// other parameter based calls (because they were most recently added).
	/// </remarks>
	public class IntPoint
	{
		static public IntPoint Empty { get { return new IntPoint(0); } }
		static public IntPoint One { get { return new IntPoint(1); } }
	
		int _X=0f, _Y=0f;
		[XmlAttribute] public int X { get { return _X; } set { _X = value; } }
		[XmlAttribute] public int Y { get { return _Y; } set { _Y = value; } }
	
		#region Properties
		[XmlIgnore] public int Bigger { get { return (X >= Y)? X: Y; } }
		[XmlIgnore] public bool IsLand { get { return X >= Y; } }
		/// <summary>zerod'</summary>
		[XmlIgnore] public double Slope { get  { return Math.Sqrt(Math.Pow(X,2)+Math.Pow(Y,2)); }  }
		#endregion
		#region Static Methods
		static public IntPoint FlattenPoint(IntPoint _pin, bool roundUp)
		{
			IntPoint newP = _pin.Clone();
			if (newP.X==newP.Y) return newP;
			if (_pin.X > _pin.Y) { if (roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
			else { if (!roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
			return newP;
		}
		static public IntPoint FlattenPoint(IntPoint _pin) { return FlattenPoint(_pin,false); }
		/// <summary>same as FlattenPoint overload without boolean</summary>
		static public IntPoint FlattenDown(IntPoint _pin) { return FlattenPoint(_pin); }
		static public IntPoint FlattenUp(IntPoint _pin) { return FlattenPoint(_pin,true); }
	
		static public IntPoint GetClientSize(Control ctl) { return ctl.ClientSize; }
		static public IntPoint GetPaddingTopLeft(Padding pad) { return new IntPoint(pad.Left,pad.Top); }
		static public IntPoint GetPaddingOffset(Padding pad) { return new IntPoint(pad.Left+pad.Right,pad.Top+pad.Bottom); }
	//
		static public FPoint Angus(int offset, int ration, float phase) { return new FPoint(-Math.Sin(cvtf(ration,offset+phase)),Math.Cos(cvtf(ration,offset+phase))); }
		static public FPoint Angus(int offset, int ration) { return Angus(offset,ration,0.0f); }
		static int cvtf(int S, int I){ return (int)((Math.PI*2)*(I/S)); }
		/// scales src to dest
		static public IntPoint Fit(IntPoint dest, IntPoint source)
		{
			return Fit(dest,source,scaleFlags.autoScale);
		}
		static public IntPoint Fit(IntPoint dest, IntPoint source, scaleFlags f)
		{
			IntPoint HX = dest/source;
			if (f== scaleFlags.autoScale) return (HX.Y > HX.X) ? source*HX.X : source * HX.Y;
			else return (f== scaleFlags.sWidth) ? source*HX.X : source*HX.Y;
		}
		#region Obsolete
	/*		/// todo: replace this with something more accurate and faster
		/// use Boxed as the default scale flag
		static public IntPoint Fit(Point dest, Point source, scaleFlags sf)
		{
			IntPoint skaler = new IntPoint();
			int tr=0;
			string omax,cmax;
			if (source.X >= source.Y) omax = "width"; else omax="height";
			if (dest.X >= dest.Y) cmax = "width"; else cmax="height";
			switch (cmax)
			{
				case "width": if (omax==cmax) sf = scaleFlags.sWidth; else sf = scaleFlags.sHeight; break;
				case "height": if (omax==cmax) sf = scaleFlags.sHeight; else sf = scaleFlags.sWidth; break;
			}
		skale:
			switch (sf)
			{
				case scaleFlags.sHeight:
					if ( source.Y > dest.Y ) { skaler.Y = dest.Y; tr = (int)((int)dest.Y / (int)source.Y); skaler.X = (int)Math.Round(source.X*tr); }
					else skaler = source; break;
				case scaleFlags.sWidth:
					if ( source.X > dest.X ) { skaler.X = dest.X; tr = (int)((int)dest.X / (int)source.X); skaler.Y = (int)Math.Round(source.Y*tr); }
					else skaler = source; break;
			}
			if ((skaler.X > dest.X) | (skaler.Y > dest.Y))
			{
				switch (sf)
				{
					case scaleFlags.sWidth: sf = scaleFlags.sHeight; goto skale;
					case scaleFlags.sHeight: sf = scaleFlags.sWidth; goto skale;
				}
			}
			return skaler;
		}*/
		#endregion
		#endregion
		#region Help
	//		public XPoint Translate(XPoint offset, XPoint zoom, bool ZoomAfterOffset, bool MultiplyOffset)
	//		{
	//			return (ZoomAfterOffset) ? (this+((MultiplyOffset) ? offset*zoom : offset ))*zoom : (this*zoom)+((MultiplyOffset) ? offset*zoom : offset );
	//		}
		/// In most scenarios (reminding my self of my application...)
		/// zoom is applied by the renderer, so we shouldn't need it?
		/// I could be wrong.  We could be zoomed in to draw.
		public IntPoint Translate(IntPoint offset, IntPoint zoom)
		{
			return (this+offset)*zoom;
		}
		public IntPoint Translate(double offset, double zoom)
		{
			return (this+new IntPoint(offset))*new IntPoint(zoom);
		}
		#endregion
		#region Helpers “Most of which are obsoltet”
		public IntPoint GetRation(IntPoint dst)
		{
			return dst/this;
		}
		public IntPoint GetScaledRation(IntPoint dst)
		{
			return this*(dst/this);
		}
		public int Dimension() { return X*Y; }
		/// <summary>Returns a new flattened point</summary>
		public IntPoint Flat(bool roundUp) { return FlattenPoint(this,roundUp); }
		/// <summary>Flattens the calling point</summary>
		public void Flatten(bool roundUp) { IntPoint f = Flat(roundUp); this.X = f.X; this.Y = f.Y; f = null; }
		/// <summary>use Flat or flatten calls.</summary>
		public IntPoint ScaleTo(IntPoint point)
		{
			if (point.X==X && point.Y==Y) throw new InvalidOperationException("you mucker");
			System.Windows.Forms.MessageBox.Show( string.Format("X: {1},Y: {0}",Y/point.Y,X/point.X) );
			if (X > point.Y)
			{
				cor3.Global.cstat(ConsoleColor.Red,"X is BIGGER");
			}
			else cor3.Global.cstat(ConsoleColor.Red,"X is SMALLER");
			return this;
		}
		#endregion
		#region Operators
		static public IntPoint operator +(IntPoint a, IntPoint b){ return new IntPoint(a.X+b.X,a.Y+b.Y); }
		static public IntPoint operator +(IntPoint a, Point b){ return new IntPoint(a.X+b.X,a.Y+b.Y); }
		static public IntPoint operator +(IntPoint a, int b){ return new IntPoint(a.X+b,a.Y+b); }
		static public IntPoint operator +(IntPoint a, float b){ return new IntPoint(a.X+b,a.Y+b); }
		static public IntPoint operator +(IntPoint a, double b){ return new IntPoint(a.X+b,a.Y+b); }
		static public IntPoint operator -(IntPoint a){ return new IntPoint(-a.X,-a.Y); }
		static public IntPoint operator -(IntPoint a, IntPoint b){ return new IntPoint(a.X-b.X,a.Y-b.Y); }
		static public IntPoint operator -(IntPoint a, Point b){ return new IntPoint(a.X-b.X,a.Y-b.Y); }
		static public IntPoint operator -(IntPoint a, int b){ return new IntPoint(a.X-b,a.Y-b); }
		static public IntPoint operator -(IntPoint a, float b){ return new IntPoint(a.X-b,a.Y-b); }
		static public IntPoint operator -(IntPoint a, double b){ return new IntPoint(a.X-b,a.Y-b); }
		static public IntPoint operator /(IntPoint a, IntPoint b){ return new IntPoint(a.X/b.X,a.Y/b.Y); }
		static public IntPoint operator /(IntPoint a, Point b){ return new IntPoint(a.X/b.X,a.Y/b.Y); }
		static public IntPoint operator /(IntPoint a, int b){ return new IntPoint(a.X/b,a.Y/b); }
		static public IntPoint operator /(IntPoint a, float b){ return new IntPoint(a.X/b,a.Y/b); }
		static public IntPoint operator /(IntPoint a, double b){ return new IntPoint(a.X/b,a.Y/b); }
		static public IntPoint operator *(IntPoint a, IntPoint b){ return new IntPoint(a.X*b.X,a.Y*b.Y); }
		static public IntPoint operator *(IntPoint a, Point b){ return new IntPoint(a.X*b.X,a.Y*b.Y); }
		static public IntPoint operator *(IntPoint a, int b){ return new IntPoint(a.X*b,a.Y*b); }
		static public IntPoint operator *(IntPoint a, float b){ return new IntPoint(a.X*b,a.Y*b); }
		static public IntPoint operator *(IntPoint a, double b){ return new IntPoint(a.X*(int)b,a.Y*(int)b); }
		static public IntPoint operator %(IntPoint a, IntPoint b){ return new IntPoint(a.X%b.X,a.Y%b.Y); }
		static public IntPoint operator %(IntPoint a, Point b){ return new IntPoint(a.X%b.X,a.Y%b.Y); }
		static public IntPoint operator ++(IntPoint a){ return new IntPoint(a.X++,a.Y++); }
		static public IntPoint operator --(IntPoint a){ return new IntPoint(a.X--,a.Y--); }
		static public bool operator >(IntPoint a,IntPoint b){ return ((a.X>b.X) & (a.Y>b.Y)); }
		static public bool operator <(IntPoint a,IntPoint b){ return ((a.X<b.X) & (a.Y<b.Y)); }
		#endregion
		#region Operators Implicit
		static public implicit operator Point(IntPoint a){ return new Point((int)a.X,(int)a.Y); }
		static public implicit operator PointF(IntPoint a){ return new PointF(a.X,a.Y); }
		static public implicit operator Size(IntPoint a){ return new Size((int)a.X,(int)a.Y); }
		static public implicit operator SizeF(IntPoint a){ return new SizeF(a.X,a.Y); }
		static public implicit operator IntPoint(Size s){ return new IntPoint(s); }
		static public implicit operator IntPoint(SizeF s){ return new IntPoint(s); }
		static public implicit operator IntPoint(Point s){ return new IntPoint(s); }
		static public implicit operator IntPoint(PointF s){ return new IntPoint(s); }
		#endregion
		#region Maths
		public bool IsXG(IntPoint P) { return X>P.X; }
		public bool IsYG(IntPoint P) { return Y>P.Y; }
		public bool IsXL(IntPoint P) { return X<P.X; }
		public bool IsYL(IntPoint P) { return Y<P.Y; }
	
		public bool IsLEq(IntPoint p) { return (X<=p.X) && (Y<=p.Y); }
		public bool IsGEq(IntPoint p) { return (X>=p.X) && (Y>=p.Y); }
		
		public bool IsXGEq(IntPoint P) { return IsXG(P)&IsXG(P); }
		public bool IsYGEq(IntPoint P) { return IsYG(P)&IsYG(P); }
		public bool IsXLEq(IntPoint P) { return IsXG(P)&IsXG(P); }
		public bool IsYLEq(IntPoint P) { return IsYG(P)&IsYG(P); }
		public bool IsXEq(IntPoint P) { return X==P.X; }
		public bool IsYEq(IntPoint P) { return Y==P.Y; }
	
		public IntPoint Multiply(params IntPoint[] P) {
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new IntPoint(X,Y)*P[0];
			IntPoint NewPoint = new IntPoint(X,Y)*P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint *= P[i];
			}
			return NewPoint;
		}
		public IntPoint Multiply(params int[] P) {
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new IntPoint(X,Y)*P[0];
			IntPoint NewPoint = new IntPoint(X,Y)*P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint *= P[i];
			}
			return NewPoint;
		}
		public IntPoint Divide(params IntPoint[] P)
		{
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new IntPoint(X,Y)/P[0];
			IntPoint NewPoint = new IntPoint(X,Y)/P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint /= P[i];
			}
			return NewPoint;
		}
	
		public IntPoint MulX(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.X *= RefPoint.X;
			return PBase;
		}
		public IntPoint MulY(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.Y *= RefPoint.Y;
			return PBase;
		}
		public IntPoint DivX(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.X /= RefPoint.X;
			return PBase;
		}
		public IntPoint DivY(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.Y /= RefPoint.Y;
			return PBase;
		}
		public IntPoint AddX(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.X += RefPoint.X;
			return PBase;
		}
		public IntPoint AddY(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.Y += RefPoint.Y;
			return PBase;
		}
		public IntPoint AddY(params int[] P)
		{
			IntPoint PBase = Clone();
			foreach (int RefPoint in P) PBase.Y += RefPoint;
			return PBase;
		}
		public IntPoint NegX(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.X -= RefPoint.X;
			return PBase;
		}
		public IntPoint NegX(params int[] P)
		{
			IntPoint PBase = Clone();
			foreach (int Ref in P) PBase.X -= Ref;
			return PBase;
		}
		public IntPoint NegY(params IntPoint[] P)
		{
			IntPoint PBase = Clone();
			foreach (IntPoint RefPoint in P) PBase.Y -= RefPoint.Y;
			return PBase;
		}
		public IntPoint NegY(params int[] P)
		{
			IntPoint PBase = Clone();
			foreach (int Ref in P) PBase.Y -= Ref;
			return PBase;
		}
		#endregion
	
		public IntPoint(){ }
		public IntPoint(int x, int y){ _X = x; _Y = y; }
		public IntPoint(int value) : this(value,value) {  }
		public IntPoint(Point P){ _X = P.X; _Y = P.Y; }
		public IntPoint(PointF P){ _X = P.X; _Y = P.Y; }
		public IntPoint(Size P){ _X = P.Width; _Y = P.Height; }
		public IntPoint(SizeF P){ _X = P.Width; _Y = P.Height; }
	
		#region Obj
		// Object ====================================
		public IntPoint Clone(){ return (IntPoint)(new IntPoint(X,Y).Clone()); }
		public void CopyPoint(IntPoint inPoint) { X=inPoint.X; Y=inPoint.Y; }
		public override string ToString() { return String.Format("IntPoint:X:{0},Y:{1}",X,Y); }
		#endregion
	
	}
}
