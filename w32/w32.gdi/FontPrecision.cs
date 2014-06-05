/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Runtime.InteropServices;

namespace w32.gdi
{
	public enum FontPrecision : byte
	{
	    OUT_DEFAULT_PRECIS = 0,
	    OUT_STRING_PRECIS = 1,
	    OUT_CHARACTER_PRECIS = 2,
	    OUT_STROKE_PRECIS = 3,
	    OUT_TT_PRECIS = 4,
	    OUT_DEVICE_PRECIS = 5,
	    OUT_RASTER_PRECIS = 6,
	    OUT_TT_ONLY_PRECIS = 7,
	    OUT_OUTLINE_PRECIS = 8,
	    OUT_SCREEN_OUTLINE_PRECIS = 9,
	    OUT_PS_ONLY_PRECIS = 10,
	}
}
