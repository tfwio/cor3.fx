#region tfw * 8/1/2009 * 4:24 PM ** 'LICENSE & File Header'
/* [insert license here] **
 * if no license is mentioned above
 * you are to assume a HYBRID GPL/MIT license which in general allows you to use
 * the code without limitation (commercially or not) provided that if there are
 * any alterations made to the code, you must supply us with a copy.  Also you
 * are to credit the authors and include a respective MIT/GPL license on each
 * respective script and supply each respective and/or applicable license(s) 
 * with and binaries produced as a result of this property.
***
 * -- thanks
**/
#endregion
using System;

namespace System.Cor3.text
{
	public class DeltaRange
	{
		/// this is not meant to do any more then provide a comple error for now.
//		static public int CompareTwo(DeltaRange r0, DeltaColorRange r1)
//		{
//			return r0.Length.CompareTo(r1.Length);
//		}
		public int Level;
		public int Length;
		public DeltaRange(int lvl, int len)
		{
			Level = lvl;
			Length = len;
		}
	}
	public class DeltaColorRange : DeltaRange
	{
		public TextStyle ColorSettings;
		public DeltaColorRange(int len) : this(0,len)
		{
		}
		public DeltaColorRange(int lvl, int len) : this(lvl,len,new TextStyle())
		{
		}
		public DeltaColorRange(int lvl, int len, TextStyle cs) : base(lvl,len)
		{
			ColorSettings = cs;
		}
	}
	
}
