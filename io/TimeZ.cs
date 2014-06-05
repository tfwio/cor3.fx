/* oOo * 11/14/2007 : 9:53 PM */
/**
 * NameSpace Description:
 * 	this class is to generally encapsulate classes which are to contain
 * 	redundant 'library' functions to 'help'.
 */

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Cor3
{
	public class TimeZ
	{
//			public enum dtFmt { UNX,MAC,W32, }
//		//DatePrototype.getMilliseconds
//		static public long dateShowFmt(dtFmt fmt, long timeval)
//		{
//			DateTime sMAC_DATE = (new DateTime(1904,1,1));
//			DateTime sUNIXDATE = (new DateTime(1970,1,1));
//			DateTime sWIN_DATE = (new DateTime(0));
//			DateTime shout = new DateTime();
//			switch (fmt)
//			{
//				case dtFmt.UNX: shout = sUNIXDATE.AddSeconds(timeval); break;
//				case dtFmt.MAC: shout = sMAC_DATE.AddSeconds(timeval); break;
//				default: shout = sWIN_DATE; break;
//			}
//			return shout.ToBinary();
//		}
		public enum dtFmt : byte
		{
			UNX = 0,
			WIN = 1,
			MAC = 2
		}
		
		//DatePrototype.getMilliseconds
		public long dateShowFmt(dtFmt fmt, long timeval)
		{
			DateTime sMAC_DATE = (new DateTime(1904,1,1));
			DateTime sUNIXDATE = (new DateTime(1970,1,1));
			DateTime sWIN_DATE = (new DateTime(0));
			DateTime shout = new DateTime();
			switch (fmt)
			{
				case dtFmt.UNX: shout = sUNIXDATE.AddSeconds(timeval); break;
				case dtFmt.MAC: shout = sMAC_DATE.AddSeconds(timeval); break;
				default: shout = sWIN_DATE; break;
			}
			return shout.ToBinary();
		}
		
	}
}
