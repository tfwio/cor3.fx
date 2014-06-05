/* oOo * 11/28/2007 : 5:29 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

using drawing.types;

namespace System.Drawing
{
	public class VPointD : DPoint
	{
		double _Z = 0.0f;
		public double Z { get { return _Z; } set { _Z = value; } }
		public double[] v { get { return new double[]{ X,Y,Z }; } }
		
		public VPointD(double x, double y, double z) : base(x,y) { _Z = z; }
		public VPointD(DPoint _pin, double z) : this(_pin.X,_pin.Y,z) { }
	}
	public class VPointF : FPoint
	{
		float _Z = 0.0f;
		public VPointF(float x, float y, float z) : base(x,y) { _Z = z; }
		public VPointF(FPoint _pin, float z) : this(_pin.X,_pin.Y,z) { }
	}
}
