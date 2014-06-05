/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace w32.user
{
	#region helper
	/// <summary>
	/// this class is intended to be used primarily from the ClipboardDummyForm.
	/// </summary>
	public class ClipboardHelper
	{
		static public int NumFormats {
			get { return u32.CountClipboardFormats(); }
		}
		static public uint[] EnumerateFormats()
		{
			//uint count = (uint)NumFormats;
			int nfm = NumFormats;
			if (nfm==0) return null;
			uint[] formats = new uint[NumFormats];
			formats[0] = u32.EnumClipboardFormats(0);

			for (int i=1; i<nfm; i++)
			{
				formats[i] = u32.EnumClipboardFormats(formats[i-1]);
			}
			return formats;
		}
	}
	#endregion
	
	public class ClipboardFormats
	{
		/*
		 * Predefined Clipboard Formats
		 */
		public const int  CF_TEXT             = 1;
		public const int  CF_BITMAP           = 2;
		public const int  CF_METAFILEPICT     = 3;
		public const int  CF_SYLK             = 4;
		public const int  CF_DIF              = 5;
		public const int  CF_TIFF             = 6;
		public const int  CF_OEMTEXT          = 7;
		public const int  CF_DIB              = 8;
		public const int  CF_PALETTE          = 9;
		public const int  CF_PENDATA          = 10;
		public const int  CF_RIFF             = 11;
		public const int  CF_WAVE             = 12;
		public const int  CF_UNICODETEXT      = 13;
		public const int  CF_ENHMETAFILE      = 14;
		//#if(WINVER >= 0x0400)
		public const int  CF_HDROP            = 15;
		public const int  CF_LOCALE           = 16;
		//#endif /* WINVER >= 0x0400 */
		//#if(WINVER >= 0x0500)
		public const int  CF_DIBV5            = 17;
		//#endif /* WINVER >= 0x0500 */
		//#if(WINVER >= 0x0500)
		public const int  CF_MAX              = 18;
//		#elif(WINVER >= 0x0400)
//		public const int  CF_MAX              = 17;
		//#else
//		public const int  CF_MAX              = 15;
		//#endif
		
		public const int  CF_OWNERDISPLAY     = 0x0080;
		public const int  CF_DSPTEXT          = 0x0081;
		public const int  CF_DSPBITMAP        = 0x0082;
		public const int  CF_DSPMETAFILEPICT  = 0x0083;
		public const int  CF_DSPENHMETAFILE   = 0x008E;
		/*
		 * "Private" formats don't get GlobalFree()'d
		 */
		public const int  CF_PRIVATEFIRST     = 0x0200;
		public const int  CF_PRIVATELAST      = 0x02FF;
		/*
		 * "GDIOBJ" formats do get DeleteObject()'d
		 */
		public const int  CF_GDIOBJFIRST      = 0x0300;
		public const int  CF_GDIOBJLAST       = 0x03FF;
	}
	public enum CF_Enu : uint
	{
		CF_TEXT             = (uint)ClipboardFormats.CF_TEXT,
		CF_BITMAP           = (uint)ClipboardFormats.CF_BITMAP,
		CF_METAFILEPICT     = (uint)ClipboardFormats.CF_METAFILEPICT,
		CF_SYLK             = (uint)ClipboardFormats.CF_SYLK,
		CF_DIF              = (uint)ClipboardFormats.CF_DIF,
		CF_TIFF             = (uint)ClipboardFormats.CF_TIFF,
		CF_OEMTEXT          = (uint)ClipboardFormats.CF_OEMTEXT,
		CF_DIB              = (uint)ClipboardFormats.CF_DIB,
		CF_PALETTE          = (uint)ClipboardFormats.CF_PALETTE,
		CF_PENDATA          = (uint)ClipboardFormats.CF_PENDATA,
		CF_RIFF             = (uint)ClipboardFormats.CF_RIFF,
		CF_WAVE             = (uint)ClipboardFormats.CF_WAVE,
		CF_UNICODETEXT      = (uint)ClipboardFormats.CF_UNICODETEXT,
		CF_ENHMETAFILE      = (uint)ClipboardFormats.CF_ENHMETAFILE,
		CF_HDROP            = (uint)ClipboardFormats.CF_HDROP,
		CF_LOCALE           = (uint)ClipboardFormats.CF_LOCALE,
		CF_DIBV5            = (uint)ClipboardFormats.CF_DIBV5,
		CF_MAX              = (uint)ClipboardFormats.CF_MAX,
		CF_OWNERDISPLAY     = (uint)ClipboardFormats.CF_OWNERDISPLAY,
		CF_DSPTEXT          = (uint)ClipboardFormats.CF_DSPTEXT,
		CF_DSPBITMAP        = (uint)ClipboardFormats.CF_DSPBITMAP,
		CF_DSPMETAFILEPICT  = (uint)ClipboardFormats.CF_DSPMETAFILEPICT,
		CF_DSPENHMETAFILE   = (uint)ClipboardFormats.CF_DSPENHMETAFILE,
	}
}
