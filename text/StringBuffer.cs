/* oOo * 12/8/2007 : 1:08 PM */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Cor3;

namespace Text
{
	/// <summary>
	/// Much of this might be considered obsolete considering
	/// it does not make use of regular expressions.
	/// </summary>
	public class StringBuffer : IStringBuffer
	{
		ITcTextStyle tstyle = null;
		public List<LineRegion> lindex;

		public StringBuffer() { }

		public StringBuffer(ITcTextStyle style, string filename)
		{
			fname = filename;
			buffer = File.ReadAllText(filename,defaultEncoder);
			lindex = LineRegion.GetCount(buffer);
			tstyle = style;
		}

		public StringBuffer(string filename){
			fname = filename;
			buffer = File.ReadAllText(filename,defaultEncoder);
			lindex = LineRegion.GetCount(buffer);
		}

		/// <summary>
		/// does this return integer-strings?
		/// Nononno - returns the length of the word?
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public int[] WordAt(int pos)
		{
			int start = pos,end = 1;
			for (int i = pos; i >= 0; i--)
			{
				if (char.IsLetterOrDigit(buffer[i])
				    && !char.IsPunctuation(buffer[i])
				    && buffer[i]!='_')
				{
					start = i;
				}
				else if (char.IsWhiteSpace(buffer[i])) i = 0;
				else if (buffer[i]=='\r'||buffer[i]=='\n') i = 0;
				else i=0;
			}
			for (int i = start; i < buffer.Length-1; i++)
			{
				if (char.IsLetterOrDigit(buffer[i])
				    && !char.IsPunctuation(buffer[i])
				    && buffer[i]!='_')
				{
					end = i+1;
				}
				else if (char.IsWhiteSpace(buffer[i])) i = buffer.Length;
				else if (buffer[i]=='\r'||buffer[i]=='\n') i = buffer.Length;
				else i = buffer.Length-1;
			};
			return new int[]{start,end};
		}

		public int LineAt(int pos)
		{
			for (int i=0; i<lindex.Count; i++)
			{
				if (pos > lindex[i].Start) return i;
			}
			return -1;
		}

		public string LineFromPos(int pos)
		{
			for (int i=0; i<lindex.Count; i++)
			{
				if (pos > lindex[i].Start) return this[i];
			}
			return string.Empty;
		}
		/// <summary>
		/// just finds linefeeds
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		public int PositionFromLine(int line)
		{
			Regex bob = new Regex(
				"\n",RegexOptions.Compiled|RegexOptions.Multiline
			);
			MatchCollection matches = bob.Matches(buffer);
//	        this.crng = new List<CharacterRange>();
//	        fmts.Add(new StringFormat());
//	        Globe.stat("begin:");
			foreach (Match match in matches)
			{
				if (match.Index > line) 
				{
					Global.stat(string.Format("shit-matched@:{0}",match.Index,match.Value));
					return match.Index;
				}
			}
			return -1;
		}
		
		/// <summary>neither  supported</summary>
		public string GetLines(int lineNum, int lineCount){
			
			return string.Empty;
		}
		/// <summary>neither  supported</summary>
		public string GetLine(int lineNum, int lineCount){
			return string.Empty;
		}

		#region GetString (region)
		public string[] GetStrings()
		{
			List<string> ret = new List<string>();
			foreach (LineRegion lr in lindex) ret.Add(GetStrings(lr));
			return ret.ToArray();
		}
		public string[] GetStrings(int start, int count)
		{
			List<string> ret = new List<string>();
			if (start < 0) start = 0;
			for (int i = start; i <= count; i++)
			{
				if (i >= lindex.Count) goto endr;
				#if DEBUG
				try
				{
				#endif
					ret.Add(GetStrings(lindex[i]));
				#if DEBUG
				}
				catch
				{
					Trace.WriteLine(
						"i: "+i.ToString()+ ", " +
						"count: "+i.ToString()+ ", " +
						"s: "+lindex[i].Start.ToString()+ ", " +
						"l: "+lindex[i].Length.ToString() + ", " +
						"bl: "+buffer.Length.ToString()
					);
				}
				#endif
			}
		endr:
			if (ret.Count==0) return new string[]{string.Empty};
			return ret.ToArray();
		}
		public string GetStrings(int index)
		{
			if (index < 0) return string.Empty;
			if (index >= lindex.Count) return string.Empty;
			return GetStrings(lindex[index]);
		}
		public string GetStrings(LineRegion lr)
		{
			return buffer.Substring(lr.Start,lr.Length);
		}
		#endregion

		/// <summary>
		/// returns -1 if the lines list does not exist.
		/// </summary>
		public int NumLines {
			get
			{
				if (lindex!=null) return lindex.Count;
				return -1;
			}
		}

		#region Measure
		/// <summary>
		/// Counts the number of lines a single line is broken into if 
		/// word-wrap is enabled.
		/// </summary>
		/// <returns>
		/// the total number of measured lines or 1 if there isn't text.
		/// </returns>
		public int[] Measure(ITcTextStyle style, string[] str)
		{
			List<int> lin = new List<int>();
			if (str==null) goto fin;
			if (str.Length==0) goto fin;
			// calculate line heights (handle stopping this is the line
			// boundary gets to be too much)
			foreach(string sx in str) lin.Add(Measure(style,sx));
		fin:
			if (lin.Count==0) return new int[]{1};
			return lin.ToArray();
		}
		/// <summary>
		/// Counts the number of lines a single line is broken into when 
		/// word-wrapping is enabled
		/// </summary>
		/// <returns>
		/// the total number of measured lines or 1 if there isn't text.
		/// </returns>
		public int[] Measure(ITcTextStyle style)
		{
			List<int> lin = new List<int>();
			string[] tstr = GetStrings();
			if (tstr==null) goto fin;
			if (tstr.Length==0) goto fin;
			// calculate line heights (handle stopping this is the line
			// boundary gets to be too much)
			foreach(string srr in tstr) lin.Add(Measure(style,srr));
		fin:
			if (lin.Count==0) return new int[]{1};
			return lin.ToArray();
		}
		/// <summary>
		/// Counts the number of lines a single line is broken into when 
		/// word-wrapping is enabled
		/// </summary>
		public int Measure(ITcTextStyle style, string[] str, int i){
			return Measure(style,str[i]);
		}
		/// <summary>
		/// Counts the number of lines a single line is broken into when 
		/// word-wrapping is enabled
		/// </summary>
		public int Measure(ITcTextStyle style, string str){
			int c,d;
			style.m_gfx.MeasureString(
				str, style.Font, style.o_rect.Size, style.StrFmt,
				out c, out d );
			return d;
		}
		#endregion

		#region StringBuffer[int index], [int start, int end]
		/// <summary> easier retrieval of a particular line. </summary>
		public string this[int index] {
			get { return GetStrings(index); }
		}
		/// <summary> easier retrieval of a particular line. </summary>
		public string[] this[int start, int count] {
			get { return GetStrings(start,count); }
		}
		#endregion

		#region Text
		/// <summary>the entire string </summary>
		public string buffer;
		/// <summary> Get/Set the entire string </summary>
		public string Text {
			get { return buffer; }
			set { buffer = value; }
		}

		#endregion

		#region ITcEncoder
		#region CodePage
		public CodePages CodePage
		{
			get { return cp; }
			set
			{
				cp = value;
				switch (cp)
				{
					case CodePages.Ascii: defaultEncoder = Encoding.ASCII; return;
					case CodePages.Unicode: defaultEncoder = Encoding.Unicode; return;
					case CodePages.Utf7: defaultEncoder = Encoding.UTF7; return;
					case CodePages.Utf8: defaultEncoder = Encoding.UTF8; return;
					case CodePages.Default: defaultEncoder = Encoding.Default; return;
				}
			}
		} CodePages cp = CodePages.Default;
		#endregion
		#region DefaultEncoder
		Encoding defaultEncoder = Encoding.Default;
		/// We'll get a little into codepages later
		public Encoding DefaultEncoder {
			get { return defaultEncoder; }
			set { defaultEncoder = value; }
		}
		#endregion
		#region FileName
		/// <summary>the name of the file</summary>
		string fname = string.Empty;
		/// <summary>the name of the file</summary>
		/// <remarks>
		/// if the filename is empty, then we should probably 
		/// save the file if DoSave occurs (or exists)
		/// </remarks>
		public string FileName {
			get { return fname; }
			set { fname = value; }
		}
		#endregion
		#endregion

	}
	
}
