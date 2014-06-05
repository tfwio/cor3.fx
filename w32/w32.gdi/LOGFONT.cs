/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Runtime.InteropServices;

namespace w32.gdi
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LOGFONT
	{
	    public int lfHeight;
	    public int lfWidth;
	    public int lfEscapement;
	    public int lfOrientation;
	    public int lfWeight;
	    public byte lfItalic;
	    public byte lfUnderline;
	    public byte lfStrikeOut;
	    public byte lfCharSet;
	    public byte lfOutPrecision;
	    public byte lfClipPrecision;
	    public byte lfQuality;
	    public byte lfPitchAndFamily;
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
	    /* [FieldOffset(28)] */
	    public string lfFaceName;
		public override string ToString()
		{
			return string.Format(
				"{0},{2},{1}",
				lfCharSet,
				lfFaceName,
				((int)lfPitchAndFamily & (int)FontPitchAndFamily.FIXED_PITCH) == (int)FontPitchAndFamily.FIXED_PITCH
			);
		}
	}
}
