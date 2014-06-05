/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/29/2009
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Cor3.text;
using System.Drawing;
using System.Text.RegularExpressions;

//using Cor3.xml;

namespace System.Cor3.text
{

	public class QueryCriteria
	{
		static RegexOptions def_exopts = RegexOptions.Multiline;
		static Color def_bg = SystemColors.WindowText;
		static Color def_fg = SystemColors.Window;
		public Color clr_bg,clr_fg;
		
		public RegexOptions regex_options = def_exopts;

		public Color ColorBg { get { return clr_bg; } set {clr_bg = value;} }
		public Color ColorFg { get { return clr_fg; } set {clr_fg = value;} }

		public PassCategory query_mode;
		public PassType query_type;

		// Query Automation
		//======================================================================
		public object query_value;
		public string query_string
		{
			get
			{
				if (query_value==null) return null;
				else if (query_type == PassType.StringMode) return (string)query_value;
				else if (query_type == PassType.RegularExpressionMode) return (string)query_value;
				return null;
			}
			set { query_value=value; }
		}
		public string[] query_stray
		{
			get {
				if (query_value==null) return null;
				else if (query_type == PassType.StringArrayMode) return (string[])query_value;
				else if (query_type == PassType.RegularExpressionMode) return (string[])query_value;
				return null;
			}
			set { query_value=value; }
		}
		public char query_char
		{
			get {
				if (query_value==null) return (char)0;
				return (query_type != PassType.CharMode) ? (char)0 : (char)query_value;
			}
			set { query_value=value; }
		}
		/// the only one that works for StringMode or CharArrayMode
		public char[] query_chars
		{
			get {
				if (query_value==null) return null;
				if (query_type == PassType.CharArrayMode) return (char[])query_value;
				else if (query_type == PassType.StringMode) return (query_value as string).ToCharArray();
				return null;
			}
			set { query_value=value; }
		}

		// Search
		//======================================================================
		virtual public long[] FindIndexes(string input)
		{
			switch (query_mode)
			{
			case PassCategory.Block: return GetIndexes(input,query_chars);
			case PassCategory.White: return GetIndexes(input,query_char);
			case PassCategory.Word:
			case PassCategory.DefaultRange: return GetIndexes(input,query_string);
			case PassCategory.Operators:
			case PassCategory.CarrageReturn:
			case PassCategory.LineFeed: return GetIndexes(input,query_chars);
			default: return GetIndexes(input,new string[]{query_string});
			}
		}
		virtual public TextRange[] GetRanges(string input)
		{
			switch (query_mode)
			{
			case PassCategory.Block: return GetRanges(input,query_chars);
			case PassCategory.White: return GetRanges(input,query_char);
			case PassCategory.Word:
			case PassCategory.DefaultRange: return GetRanges(input,query_string);
			case PassCategory.Operators:
			case PassCategory.CarrageReturn:
			case PassCategory.LineFeed: return GetRanges(input,query_chars);
			default: return GetRanges(input,query_string);
			}
		}
//		long[] SingleIndex(string ref, string inp)
//		{
//			foreach (Match m in Regex.Matches(reference,str,regex_options))
//				ind.Add(m.Index);
//		}
		long[] GetIndexes(string reference, params string[] input)
		{
			List<long> ind = new List<long>();
			if (query_type == PassType.StringMode)
			{
				foreach (string str in input)
				{
					ind.AddRange(search.match_str_l(str,reference).ToArray());
				}
				ind.Sort();
			}
			else if (query_type == PassType.RegularExpressionMode)
			{
				foreach (string str in input)
				{
					foreach (Match m in Regex.Matches(reference,str,regex_options))
						ind.Add(m.Index);
				}
			}
			return ind.ToArray();
		}
		long[] GetIndexes(string reference, params char[] input)
		{
			List<long> ind = search.match_chars_l(input,reference);
			return ind.ToArray();
		}
		TextRange[] GetRanges(string reference, params string[] input)
		{
			List<TextRange> ind = new List<TextRange>();
			if (query_type == PassType.StringMode)
			{
				foreach (string str in input)
				{
					List<TextRange> list = new List<TextRange>();
					int boo = 0;
					while ((boo = reference.IndexOf(str,boo))>=0) { list.Add(new TextRange(boo,boo+str.Length,clr_fg)); boo++; }
					ind.AddRange(list.ToArray());
					list.Clear(); list = null;
				}
			}
			else if (query_type == PassType.RegularExpressionMode)
			{
				foreach (string str in input)
				{
					Global.cstat(ConsoleColor.Yellow,"regex: {0}",str);
					foreach (Match m in Regex.Matches(reference,str,regex_options))
					{
						ind.Add(new TextRange(m.Groups["word"].Index,m.Index+m.Groups["word"].Length,clr_fg));
					}
				}
				
			}
			
			ind.Sort(TextRange.CompareTwo);
//			Global.cstat(ConsoleColor.Red,ind.Count);
			return ind.ToArray();
		}
		TextRange[] GetRanges(string reference, params char[] input)
		{
			List<TextRange> ind = new List<TextRange>();
			foreach (char ch in input)
			{
				long ix = reference.IndexOf(ch);
				ind.Add(new TextRange(ix,ix+1));
			}
			return ind.ToArray();
		}

		public QueryCriteria(PassType mode, object str)
			: this(mode,str,PassCategory.DefaultRange,def_fg)
		{
		}
		public QueryCriteria(PassType mode, object str, PassCategory cat) :this (mode,str,cat,def_fg,def_bg) {}
		public QueryCriteria(PassType mode, object str, PassCategory cat, Color cfg) :this (mode,str,cat,cfg,def_bg) {}
		public QueryCriteria(PassType mode, object str, PassCategory cat, Color cfg, Color cbg)
		{
			ColorFg = cfg;
			ColorBg = cfg;
			query_mode = cat;
			query_type = mode;
			query_value = str;
		}
	}
}
