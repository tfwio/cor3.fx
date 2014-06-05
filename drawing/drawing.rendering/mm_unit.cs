/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;

namespace drawing.metrics
{
	public class mm_unit : DICT<string,double> // as defined for css.  It apparently is based on a mm which in the case of css2 is defined as a macro
	{
		public double INCH { get { return (25.4D * MM); } }
		public double CM { get { return (10D * MM); } }
		public double MM { get { return 1D; } }
		public double PICA { get { return (12D * INCH/72D * MM); } }
		public double POINT { get { return (INCH/72D * MM); } }
		public double PixelT { get { return MM/92D; } }
		public mm_unit() : base()
		{
			Add("INCH",INCH);
			Add("CM",CM);
			Add("MM",MM);
			Add("PICA",PICA);
			Add("POINT",POINT);
			Add("PixelT",PixelT);
		}
	}
}
