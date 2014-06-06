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
using System.Collections.Generic;

namespace Cor3
{
	public enum ctyp { none,upper,lower }
	public class tutil
	{
		/// object to string
		static public string _s(object obj) { return string.Format("{0}",obj); }
		static public string _case(string instr, ctyp flag)
		{
			switch (flag)
			{
			case ctyp.upper: return instr.ToUpper();
			case ctyp.lower: return instr.ToLower();
			default: return instr;
			}
		}
		static public object _l(string str) { return _l(str,true); }
		static public object _l(string str,bool lower) { return _case(str,lower?ctyp.lower:ctyp.none); }
		static public object _u(string str) { return _u(str,true); }
		static public object _u(string str,bool upper) { return _case(str,upper?ctyp.upper:ctyp.none); }
	}
	public class tex_util
	{
		static public List<int> match_char(char cha, string text)
		{
			List<int> list = new List<int>();
			int boo = 0;
			while ((boo = text.IndexOf(cha,boo))>=0) { list.Add(boo); boo++; }
			return list;
		}
	}
}
