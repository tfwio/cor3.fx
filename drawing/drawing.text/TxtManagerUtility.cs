/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Cor3;

namespace drawing.text 
{
	public class TxtManagerUtility
	{
		#region Constants and internal Vars
		/// 
		public static RegexOptions _def_exp_opts = RegexOptions.Compiled|RegexOptions.Multiline;
		/// 
		public const string _def_str_filter = "Some Text|*.txt;*.text;*.cmd;*.bat;*.cfg;*.log;*.xml;*.htm;*.html;*.js;*.as;*.as3;*.cs;*.csproj";
		/// 
		public const string _def_str_all_files = "All Files|*.*";
		/// 
		public static string _def_filter{ get { return string.Concat(_def_str_filter,"|",_def_str_all_files); } }
		#endregion
		/// 
		static public int[] int_match(string input, string pattern, bool add_len)	{
			List<int> list = new List<int>();
			foreach (Match match in Regex.Matches(input,pattern,_def_exp_opts))
				list.Add( (add_len) ? match.Index+match.Length : match.Index );
			return list.ToArray();
		}
		/// 
		static public string[] split(string input, string pattern)					{ return split(input,pattern,_def_exp_opts); }
		/// 
		static public string[] split(string input, string pattern, RegexOptions regex_options) {
			return Regex.Split(input,pattern,regex_options);
		}
		/// Note — Does not include the CR.LF in the resulting strings
		static public string[] file_load(string fname, Encoding enc)
		{
			return File.ReadAllLines(fname,enc);
		}
		/// 
		static public void file_save(string fname, Encoding enc, string[] value) {
			File.WriteAllLines(fname,value,enc);
		}
		static public string file_get_load() { return file_get_load(_def_filter,"Save » Select a file…"); }
		static public string file_get_load(string filter) { return file_get_load(filter,"Save » Select a file…"); }
		static public string file_get_load(string filter, string caption) { return ControlUtil.FGet(filter,caption); }
		static public string file_get_save() { return file_get_save(_def_filter,"Save » Select a file name to save…"); }
		static public string file_get_save(string filter) { return file_get_save(filter,"Save » Select a file name to save…"); }
		static public string file_get_save(string filter, string caption) { return ControlUtil.FSave(filter,caption); }
	}
}
