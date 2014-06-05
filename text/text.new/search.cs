#region tfw * 8/1/2009 * 4:24 PM ** 'LICENSE & File Header'
/** [insert license here] **
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
using System.IO;

namespace System.Cor3.text
{
	public class search
	{
		static public List<int> match_str(string cha, string text)
		{
			List<int> list = new List<int>();
			int boo = 0;
			while ((boo = text.IndexOf(cha,boo))>=0) { list.Add(boo); boo++; }
			return list;
		}
		static public List<long> match_str_l(string cha, string text)
		{
			List<long> list = new List<long>();
			int boo = 0;
			while ((boo = text.IndexOf(cha,boo))>=0) { list.Add(boo); boo++; }
			return list;
		}

		static public List<int> match_delta_str(string cha, string text)
		{
			List<int> list = new List<int>();
			int boo = 0, lastindex=0;
			while ((boo = text.IndexOf(cha,boo))>=0) { list.Add(boo-lastindex); boo++; lastindex=boo; }
			return list;
		}

		static public List<int> match_char(char cha, string text)
		{
			List<int> list = new List<int>();
			int boo = 0;
			while ((boo = text.IndexOf(cha,boo))>=0) { list.Add(boo); boo++; }
			return list;
		}
		static public List<long> match_char_l(char cha, string text)
		{
			List<long> list = new List<long>();
			int boo = 0;
			while ((boo = text.IndexOf(cha,boo))>=0) { list.Add(boo); boo++; }
			return list;
		}

		static public List<long> match_chars_l(char[] cha, string text)
		{
			List<long> list = new List<long>();
			foreach (char c in cha)
			{
				List<long> ist = new List<long>();
				list.AddRange(match_char_l(c,text));
			}
			list.Sort();
			return list;
		}
		static public List<int> match_chars(char[] cha, string text)
		{
			List<int> list = new List<int>();
			foreach (char c in cha)
			{
				List<int> ist = new List<int>();
				list.AddRange(match_char(c,text));
			}
			list.Sort();
			return list;
		}

		static public List<long> next_str_l(long offset, string cha, string text)
		{
			List<long> list = new List<long>();
			long boo = offset;
			while ((boo = text.IndexOf(cha,(int)offset,StringComparison.CurrentCulture))>=0) { list.Add(boo); boo++; }
			return list;
		}
	}
}
