/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Drawing;

namespace drawing.util
{

	/// <summary>
	/// the core of this thing was taken from a dotnet tutorial somewhere in the
	/// 2.x documentaion from microsoft.  I assume that you can find it in the 
	/// 3.x documentations as well in the System.System.Cor3.Forms.Design-time painting category
	/// somewhere perhaps.
	/// </summary>
	/// <remarks>
	/// don't ask me why, but this algo is considered uniquely obsolete.
	/// </remarks>
	public class AngleUtil : IDisposable
	{ // not that disposing is necessary
		const double pi2 = (float)Math.PI*2f;
		public double Value = double.NaN;
		public AngleUtil(int x1, int y1, int x2, int y2) { Value = GetAngle(x1,y1,x2,y2); }
		public AngleUtil(double x1, double y1, double x2, double y2) { Value = GetAngle(x1,y1,x2,y2); }
		~AngleUtil() { Dispose(false); }

		#region GetAngle
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "0#P")]
		static public double GetAngle(Point[] P)
		{
			return GetAngle(P[0].X,P[0].Y,P[1].X,P[1].Y);
		}
		static public double GetAngle(Point[] P, bool invert)
		{
			return GetAngle(P[1].X,P[1].Y,P[0].X,P[0].Y);
		}
		// ms-help://MS.NETFramework.v20.en/cpref8/html/T_System_Drawing_Design_UITypeEditor.htm
		// from "UITypeEditor Class" reference example source/demo
		static public double GetAngle(int x1, int y1, int x2, int y2) {
			double degrees;
			// Avoid divide by zero run values.
			if( x2-x1 == 0 ) {
				if( y2 > y1 ) degrees = Quads[0];
				else degrees = Quads[2];
			} else {
				// Calculate angle from offset.
				double riseoverrun = (double)(y2-y1)/(double)(x2-x1);
				double radians = Math.Atan( riseoverrun );
				degrees = radians * ((double)Quads[1]/Math.PI);
				// Handle quadrant specific transformations.
				if( (x2-x1) < 0 || (y2-y1) < 0 ) degrees += Quads[1];
				if( (x2-x1) > 0 && (y2-y1) < 0 ) degrees -= Quads[1];
				if( degrees < 0 ) degrees += max;
			}
			return degrees;
		}

		static public double GetAngle(double x1, double y1, double x2, double y2) {
			double degrees;
			// Avoid divide by zero run values.
			if( x2-x1 == 0 ) {
				if( y2 > y1 ) degrees = Quads[0];
				else degrees = Quads[2];
			} else {
				// Calculate angle from offset.
				double riseoverrun = (double)(y2-y1)/(double)(x2-x1);
				double radians = Math.Atan( riseoverrun );
				degrees = radians * ((double)Quads[1]/Math.PI);
				// Handle quadrant specific transformations.
				if( (x2-x1) < 0 || (y2-y1) < 0 ) degrees += Quads[1];
				if( (x2-x1) > 0 && (y2-y1) < 0 ) degrees -= Quads[1];
				if( degrees < 0 ) degrees += max;
			}
			return degrees;
		}
		static public double GetAngle(float x1, float y1, float x2, float y2) {
			double degrees;
			// Avoid divide by zero run values.
			if( x2-x1 == 0 ) {
				if( y2 > y1 ) degrees = Quads[0];
				else degrees = Quads[2];
			} else {
				// Calculate angle from offset.
				double riseoverrun = (double)(y2-y1)/(double)(x2-x1);
				double radians = Math.Atan( riseoverrun );
				degrees = radians * ((double)Quads[1]/Math.PI);
				// Handle quadrant specific transformations.
				if( (x2-x1) < 0 || (y2-y1) < 0 ) degrees += Quads[1];
				if( (x2-x1) > 0 && (y2-y1) < 0 ) degrees -= Quads[1];
				if( degrees < 0 ) degrees += max;
			}
			return degrees;
		}
		static int max = 360;
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		static int Max {
			set {
				max = value;
				double qu = value * 0.25;
				int[] Quads = new int[4];
				Quads[0] = (int)qu;
				Quads[1] = (int)qu*2;
				Quads[2] = (int)qu*3;
				Quads[3] = (int)Max;
			}
			get {
				return max;
			}
		}
		static int[] Quads = {90,180,270,360};
		#endregion

		/// <summary></summary>
		static public int CirclePercision = 12;
		/// <summary></summary>
		static public int CircleOffset = 0;
		//
		static public Point[] CirclePath(Graphics G, Point C, int Radius){
			Point[] result = new Point[CirclePercision];
			for (int i=0; i< CirclePercision; i++){
				result[i] = new Point(
					(int)-Math.Sin(i)*CirclePercision,
					(int)Math.Cos(i)*CirclePercision
				);
			}
			return result;
		}

		#region Disposal
		bool disposed = false;

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		void Dispose(bool Disposing){
			if(!this.disposed) {
			//	if(disposing) component.Dispose();
				Value = double.NaN;
			} disposed = true;
		}
		#endregion

	}
}
