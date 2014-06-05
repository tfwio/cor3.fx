/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using w32;
using w32.gdi;
namespace w32.user
{
	public class EC_EM
	{
		public const int EC_LEFTMARGIN = 0x1;
		public const int EC_RIGHTMARGIN = 0x2;
		public const int EC_USEFONTINFO = 0xFFFF;
		public const int EM_SETMARGINS = 0xD3;
		public const int EM_GETMARGINS = 0xD4;
	}
	public enum _EC_EM : uint
	{
		EC_LEFTMARGIN=EC_EM.EC_LEFTMARGIN,
		EC_RIGHTMARGIN=EC_EM.EC_RIGHTMARGIN,
		EC_USEFONTINFO=EC_EM.EC_USEFONTINFO,
		EM_SETMARGINS=EC_EM.EM_SETMARGINS,
		EM_GETMARGINS=EC_EM.EM_GETMARGINS,
	}
}
