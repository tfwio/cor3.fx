/* oOo * 11/28/2007 : 5:29 PM */
using System;
using System.Windows.Forms;
using System.Xml.Serialization;

using drawing.types;

namespace System.Drawing
{
	/// <remarks>
	/// Only Add and Neg calls have Integer parameters when compared to the
	/// other parameter based calls (because they were most recently added).
	/// </remarks>
	public class FPoint : IComparable
	{
		static public FPoint Empty { get { return new FPoint(0f); } }
		static public FPoint One { get { return new FPoint(1f); } }
	
		float _X=0f, _Y=0f;
		[XmlAttribute] public float X { get { return _X; } set { _X = value; } }
		[XmlAttribute] public float Y { get { return _Y; } set { _Y = value; } }
	
		#region Properties
		[XmlIgnore] public float Bigger { get { return (X >= Y)? X: Y; } }
		[XmlIgnore] public bool IsLand { get { return X >= Y; } }
		/// <summary>zerod'</summary>
		[XmlIgnore] public double Slope { get  { return Math.Sqrt(Math.Pow(X,2)+Math.Pow(Y,2)); }  }
		#endregion
		#region Static Methods
		static public FPoint Average(params FPoint[] xp)
		{
			FPoint p = new FPoint(0);
			foreach (FPoint pt in xp) p += pt;
			return p/xp.Length;
		}
		static public FPoint FlattenPoint(FPoint _pin, bool roundUp)
		{
			FPoint newP = _pin.Clone();
			if (newP.X==newP.Y) return newP;
			if (_pin.X > _pin.Y) { if (roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
			else { if (!roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
			return newP;
		}
		static public FPoint FlattenPoint(FPoint _pin) { return FlattenPoint(_pin,false); }
		/// <summary>same as FlattenPoint overload without boolean</summary>
		static public FPoint FlattenDown(FPoint _pin) { return FlattenPoint(_pin); }
		static public FPoint FlattenUp(FPoint _pin) { return FlattenPoint(_pin,true); }
	
		static public FPoint GetClientSize(Control ctl) { return ctl.ClientSize; }
		static public FPoint GetPaddingTopLeft(Padding pad) { return new FPoint(pad.Left,pad.Top); }
		static public FPoint GetPaddingOffset(Padding pad) { return new FPoint(pad.Left+pad.Right,pad.Top+pad.Bottom); }
	//
		static public FPoint Angus(float offset, float ration, float phase) { return new FPoint(-Math.Sin(cvtf(ration,offset+phase)),Math.Cos(cvtf(ration,offset+phase))); }
		static public FPoint Angus(float offset, float ration) { return Angus(offset,ration,0.0f); }
		static float cvtf(float S, float I){ return (float)((Math.PI*2)*(I/S)); }
		/// scales src to dest
		static public FPoint Fit(FPoint dest, FPoint source)
		{
			return Fit(dest,source,scaleFlags.autoScale);
		}
		static public FPoint Fit(FPoint dest, FPoint source, scaleFlags f)
		{
			FPoint HX = dest/source;
			if (f== scaleFlags.autoScale) return (HX.Y > HX.X) ? source*HX.X : source * HX.Y;
			else return (f== scaleFlags.sWidth) ? source*HX.X : source*HX.Y;
		}
		#region Obsolete
	/*		/// todo: replace this with something more accurate and faster
		/// use Boxed as the default scale flag
		static public HPoint Fit(Point dest, Point source, scaleFlags sf)
		{
			HPoint skaler = new HPoint();
			float tr=0;
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
					if ( source.Y > dest.Y ) { skaler.Y = dest.Y; tr = (float)((float)dest.Y / (float)source.Y); skaler.X = (int)Math.Round(source.X*tr); }
					else skaler = source; break;
				case scaleFlags.sWidth:
					if ( source.X > dest.X ) { skaler.X = dest.X; tr = (float)((float)dest.X / (float)source.X); skaler.Y = (int)Math.Round(source.Y*tr); }
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
		public FPoint Translate(FPoint offset, FPoint zoom)
		{
			return (this+offset)*zoom;
		}
		public FPoint Translate(double offset, double zoom)
		{
			return (this+new FPoint(offset))*new FPoint(zoom);
		}
		#endregion
		#region Helpers “Most of which are obsoltet”
		public FPoint GetRation(FPoint dst)
		{
			return dst/this;
		}
		public FPoint GetScaledRation(FPoint dst)
		{
			return this*(dst/this);
		}
		public float Dimension() { return X*Y; }
		/// <summary>Returns a new flattened point</summary>
		public FPoint Flat(bool roundUp) { return FlattenPoint(this,roundUp); }
		/// <summary>Flattens the calling point</summary>
		public void Flatten(bool roundUp) { FPoint f = Flat(roundUp); this.X = f.X; this.Y = f.Y; f = null; }
		/// <summary>use Flat or flatten calls.</summary>
		public FPoint ScaleTo(FPoint point)
		{
			if (point.X==X && point.Y==Y) throw new InvalidOperationException("you mucker");
			System.Windows.Forms.MessageBox.Show( string.Format("X: {1},Y: {0}",Y/point.Y,X/point.X) );
			if (X > point.Y)
			{
				Global.cstat(ConsoleColor.Red,"X is BIGGER");
			}
			else Global.cstat(ConsoleColor.Red,"X is SMALLER");
			return this;
		}
		#endregion
		#region Operators
		static public FPoint operator +(FPoint a, FPoint b){ return new FPoint(a.X+b.X,a.Y+b.Y); }
		static public FPoint operator +(FPoint a, Point b){ return new FPoint(a.X+b.X,a.Y+b.Y); }
		static public FPoint operator +(FPoint a, int b){ return new FPoint(a.X+b,a.Y+b); }
		static public FPoint operator +(FPoint a, float b){ return new FPoint(a.X+b,a.Y+b); }
		static public FPoint operator +(FPoint a, double b){ return new FPoint(a.X+b,a.Y+b); }
		static public FPoint operator -(FPoint a){ return new FPoint(-a.X,-a.Y); }
		static public FPoint operator -(FPoint a, FPoint b){ return new FPoint(a.X-b.X,a.Y-b.Y); }
		static public FPoint operator -(FPoint a, Point b){ return new FPoint(a.X-b.X,a.Y-b.Y); }
		static public FPoint operator -(FPoint a, int b){ return new FPoint(a.X-b,a.Y-b); }
		static public FPoint operator -(FPoint a, float b){ return new FPoint(a.X-b,a.Y-b); }
		static public FPoint operator -(FPoint a, double b){ return new FPoint(a.X-b,a.Y-b); }
		static public FPoint operator /(FPoint a, FPoint b){ return new FPoint(a.X/b.X,a.Y/b.Y); }
		static public FPoint operator /(FPoint a, Point b){ return new FPoint(a.X/b.X,a.Y/b.Y); }
		static public FPoint operator /(FPoint a, int b){ return new FPoint(a.X/b,a.Y/b); }
		static public FPoint operator /(FPoint a, float b){ return new FPoint(a.X/b,a.Y/b); }
		static public FPoint operator /(FPoint a, double b){ return new FPoint(a.X/b,a.Y/b); }
		static public FPoint operator *(FPoint a, FPoint b){ return new FPoint(a.X*b.X,a.Y*b.Y); }
		static public FPoint operator *(FPoint a, Point b){ return new FPoint(a.X*b.X,a.Y*b.Y); }
		static public FPoint operator *(FPoint a, int b){ return new FPoint(a.X*b,a.Y*b); }
		static public FPoint operator *(FPoint a, float b){ return new FPoint(a.X*b,a.Y*b); }
		static public FPoint operator *(FPoint a, double b){ return new FPoint(a.X*(float)b,a.Y*(float)b); }
		static public FPoint operator %(FPoint a, FPoint b){ return new FPoint(a.X%b.X,a.Y%b.Y); }
		static public FPoint operator %(FPoint a, Point b){ return new FPoint(a.X%b.X,a.Y%b.Y); }
		static public FPoint operator ++(FPoint a){ return new FPoint(a.X++,a.Y++); }
		static public FPoint operator --(FPoint a){ return new FPoint(a.X--,a.Y--); }
		static public bool operator >(FPoint a,FPoint b){ return ((a.X>b.X) & (a.Y>b.Y)); }
		static public bool operator <(FPoint a,FPoint b){ return ((a.X<b.X) & (a.Y<b.Y)); }
		#endregion
		
		#region Operators Implicit
		static public implicit operator Point(FPoint a){ return new Point((int)a.X,(int)a.Y); }
		static public implicit operator PointF(FPoint a){ return new PointF(a.X,a.Y); }
		static public implicit operator Size(FPoint a){ return new Size((int)a.X,(int)a.Y); }
		static public implicit operator SizeF(FPoint a){ return new SizeF(a.X,a.Y); }
		static public implicit operator FPoint(Size s){ return new FPoint(s); }
		static public implicit operator FPoint(SizeF s){ return new FPoint(s); }
		static public implicit operator FPoint(Point s){ return new FPoint(s); }
		static public implicit operator FPoint(PointF s){ return new FPoint(s); }
		static public implicit operator FPoint(DPoint s){ return new FPoint(s); }
		#endregion
		#region Maths
		public bool IsXG(FPoint P) { return X>P.X; }
		public bool IsYG(FPoint P) { return Y>P.Y; }
		public bool IsXL(FPoint P) { return X<P.X; }
		public bool IsYL(FPoint P) { return Y<P.Y; }
	
		public bool IsLEq(FPoint p) { return (X<=p.X) && (Y<=p.Y); }
		public bool IsGEq(FPoint p) { return (X>=p.X) && (Y>=p.Y); }
		
		public bool IsXGEq(FPoint P) { return IsXG(P)&IsXG(P); }
		public bool IsYGEq(FPoint P) { return IsYG(P)&IsYG(P); }
		public bool IsXLEq(FPoint P) { return IsXG(P)&IsXG(P); }
		public bool IsYLEq(FPoint P) { return IsYG(P)&IsYG(P); }
		public bool IsXEq(FPoint P) { return X==P.X; }
		public bool IsYEq(FPoint P) { return Y==P.Y; }
	
		public FPoint Multiply(params FPoint[] P) {
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new FPoint(X,Y)*P[0];
			FPoint NewPoint = new FPoint(X,Y)*P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint *= P[i];
			}
			return NewPoint;
		}
		public FPoint Multiply(params float[] P) {
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new FPoint(X,Y)*P[0];
			FPoint NewPoint = new FPoint(X,Y)*P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint *= P[i];
			}
			return NewPoint;
		}
		public FPoint Divide(params FPoint[] P)
		{
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new FPoint(X,Y)/P[0];
			FPoint NewPoint = new FPoint(X,Y)/P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint /= P[i];
			}
			return NewPoint;
		}
	
		public FPoint MulX(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.X *= RefPoint.X;
			return PBase;
		}
		public FPoint MulY(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.Y *= RefPoint.Y;
			return PBase;
		}
		public FPoint DivX(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.X /= RefPoint.X;
			return PBase;
		}
		public FPoint DivY(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.Y /= RefPoint.Y;
			return PBase;
		}
		public FPoint AddX(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.X += RefPoint.X;
			return PBase;
		}
		public FPoint AddY(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.Y += RefPoint.Y;
			return PBase;
		}
		public FPoint AddY(params int[] P)
		{
			FPoint PBase = Clone();
			foreach (int RefPoint in P) PBase.Y += RefPoint;
			return PBase;
		}
		public FPoint NegX(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.X -= RefPoint.X;
			return PBase;
		}
		public FPoint NegX(params int[] P)
		{
			FPoint PBase = Clone();
			foreach (int Ref in P) PBase.X -= Ref;
			return PBase;
		}
		public FPoint NegY(params FPoint[] P)
		{
			FPoint PBase = Clone();
			foreach (FPoint RefPoint in P) PBase.Y -= RefPoint.Y;
			return PBase;
		}
		public FPoint NegY(params int[] P)
		{
			FPoint PBase = Clone();
			foreach (int Ref in P) PBase.Y -= Ref;
			return PBase;
		}
		#endregion
	
		public FPoint(){ }
		public FPoint(FPoint y){ X = y.X; Y = y.Y; }
		public FPoint(float x, float y){ _X = x; _Y = y; }
		public FPoint(int value) : this(value,value) {  }
		public FPoint(float value) : this(value,value) {  }
		public FPoint(double value) : this(value,value) {  }
		public FPoint(double x, double y) : this((float)x,(float)y) {  }
		public FPoint(DPoint P) : this(P.X,P.Y) {}
		public FPoint(Point P){ _X = P.X; _Y = P.Y; }
		public FPoint(PointF P){ _X = P.X; _Y = P.Y; }
		public FPoint(Size P){ _X = P.Width; _Y = P.Height; }
		public FPoint(SizeF P){ _X = P.Width; _Y = P.Height; }
	
		#region Obj
		// Object ====================================
		public FPoint Clone(){ return (new FPoint(X,Y)); }
		public void CopyPoint(FPoint inPoint) { X=inPoint.X; Y=inPoint.Y; }
		public override string ToString() { return String.Format("HPoint:X:{0},Y:{1}",X,Y); }
		#endregion
	
		public int CompareTo(object obj)
		{
			FPoint o = FPoint.Empty;
			if (!(obj is FPoint)) return 0;
			else
			{
				o = (FPoint) obj;
			}
			if (o.Equals(FPoint.Empty)) return 0;
			if (this < o) return -1;
			if (this > o) return 1;
			return 0;
		}
	}
}
