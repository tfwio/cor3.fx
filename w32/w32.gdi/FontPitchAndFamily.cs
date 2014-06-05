/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Runtime.InteropServices;

namespace w32.gdi
{
	[Flags]
	public enum FontPitchAndFamily : byte
	{
	    DEFAULT_PITCH = 0,
	    FIXED_PITCH = 1,
	    VARIABLE_PITCH = 2,
	    FF_DONTCARE = (0 << 4),
	    FF_ROMAN = (1 << 4),
	    FF_SWISS = (2 << 4),
	    FF_MODERN = (3 << 4),
	    FF_SCRIPT = (4 << 4),
	    FF_DECORATIVE = (5 << 4),
	}
}
