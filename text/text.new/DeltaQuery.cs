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

namespace System.Cor3.text
{
	public class DeltaQuery
	{
		static RegexOptions def_exopts = RegexOptions.Multiline;
		public RegexOptions regex_options = def_exopts;
	
		public TextStyle TextColor = new TextStyle();
		public Color ColorBg { get { return TextColor.Background; } set { TextColor.Background = value;} }
		public Color ColorFg { get { return TextColor.Foreground; } set { TextColor.Foreground = value;} }

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
		virtual public int[] FindIndexes(string input)
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
		virtual public DeltaColorRange[] GetRanges(string input)
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

		int[] GetIndexes(string reference, params string[] input)
		{
			List<int> ind = new List<int>();
			int offx=0;
			if (query_type == PassType.StringMode)
			{
				foreach (string str in input)
				{
					ind.AddRange(search.match_str(str,reference).ToArray());
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
		int[] GetIndexes(string reference, params char[] input)
		{
			List<int> ind = search.match_chars(input,reference);
			return ind.ToArray();
		}
		DeltaColorRange[] GetRanges(string reference, params string[] input)
		{
			List<DeltaColorRange> ind = new List<DeltaColorRange>();
			if (query_type == PassType.StringMode)
			{
				foreach (string str in input)
				{
					List<DeltaColorRange> list = new List<DeltaColorRange>();
					int boo = 0;
//					while ((boo = reference.IndexOf(str,boo))>=0) { list.Add(new DeltaColorRange(boo,boo+str.Length,ColorFg)); boo++; }
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
//						ind.Add(new DeltaColorRange(m.Groups["word"].Index,m.Index+m.Groups["word"].Length,ColorFg));
					}
				}
				
			}
			
//			ind.Sort(DeltaColorRange.CompareTwo);
	//			Global.cstat(ConsoleColor.Red,ind.Count);
			return ind.ToArray();
		}
		DeltaColorRange[] GetRanges(string reference, params char[] input)
		{
			List<DeltaColorRange> ind = new List<DeltaColorRange>();
			foreach (char ch in input)
			{
				int ix = reference.IndexOf(ch);
//				ind.Add(new DeltaColorRange(ix,ix+1));
			}
			return ind.ToArray();
		}

		public DeltaQuery(PassType mode, object str) : this(mode,str,PassCategory.DefaultRange) {}
		public DeltaQuery(PassType mode, object str, PassCategory cat) :this (mode,str,cat,new TextStyle()) {}
		public DeltaQuery(PassType mode, object str, PassCategory cat, Color cfg) : this(mode,str,cat,new TextStyle(cfg)) {}
		public DeltaQuery(PassType mode, object str, PassCategory cat, TextStyle style)
		{
			TextColor = style;
			query_mode = cat;
			query_type = mode;
			query_value = str;
		}
	}
}
