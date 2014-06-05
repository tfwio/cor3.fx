/*
 * User: tfw
 * Date: 8/29/2009
 * Time: 9:04 PM
 */
using System;
using System.Text.RegularExpressions;

namespace System.Cor3.text
{
	public class rex : Regex
	{
		static RegexOptions default_options = RegexOptions.IgnoreCase|RegexOptions.Multiline;
		const string x_iniheader = @"\[(?<word>[^\]]*)\]";
		const string xid = "word";
		string data = string.Empty;

		public class MatchDIC : DICT<int,string>
		{
			public void Add(Match m) { Add(m.Groups[xid].Index,m.Groups[xid].Value); }
			public MatchDIC(MatchCollection nodes) : base() { foreach (Match m in nodes) Add(m); }
		}
		public MatchDIC dic_matches;

		public rex(string input) : this(input,x_iniheader,default_options) { }
		public rex(string input, string expression, RegexOptions options) : base(expression,options) { data = input; dic_matches = new MatchDIC(Matches(data)); }

	}
}
