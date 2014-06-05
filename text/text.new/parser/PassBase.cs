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
using System.Text;
using System.Windows.Forms;

namespace newparser
{
	public delegate void PassComplete(TextRange[] ranger);

	/// just finds line index regions
	public class PassBase : APass
	{
		public QueryDictionary queries;
		virtual public void InitializeDictionaray()
		{
			queries = new QueryDictionary();
		}
		public PassComplete PassCompleted;
		protected void DoPassCompleted(TextRange[] ranges)
		{
			if (PassCompleted != null) {
				OnPassComplete(this, ranges);
				PassCompleted(ranges);
			}
		}
		public override void OnPassComplete(object sender, TextRange[] ranges)
		{
			Array.Copy(ranges, TextRanges, ranges.Length);
		}

		public TextRange[] TextRanges;

		static Encoding def_encoder = System.Text.Encoding.Default;
		Encoding encoding = def_encoder;
		public virtual Encoding Encoder {
			get { return encoding; }
			set { encoding = value; }
		}

		public override PassType PassMode {
			get { return PassType.CharMode; }
		}

		byte[] bits;
		public override byte[] Bits {
			get { return bits; }
			set { bits = value; }
		}
		public override string stringvalue {
			get { return Encoder.GetString(Bits); }
			set { bits = Encoder.GetBytes(value); }
		}

		public virtual char parse_char { get { return '\n'; } }
		public virtual char[] parse_chars { get { return null; } }
		public virtual string parse_string { get { return "\n"; } }
		public virtual string[] parse_strings { get { return null; } }

		List<long> innerIndexes;
		public override long[] Indexes {
			get { return innerIndexes.ToArray(); }
			set { innerIndexes = new List<long>(value); }
		}

		public override void FindIndexes()
		{
			string str = stringvalue;
			innerIndexes = search.match_str_l(parse_string, str);
			str = null;
			FindRegions();
		}
		public override void FindRegions()
		{
			PassCompleted(IndexesToRange(bits, Indexes));
		}

		public PassBase(string filename) : this(get_text_bytes(filename))
		{
		}
		public PassBase(byte[] bit_string)
		{
			InitializeDictionaray();
			bits = bit_string;
		}
		public PassBase(char[] bit_string) : this(def_encoder.GetBytes(bit_string))
		{
		}
		public PassBase()
		{
			InitializeDictionaray();
		}

		public static PassBase FromRichText(RichTextBox rtb)
		{
			PassBase pb = new PassBase();
			pb.stringvalue = rtb.Text;
			return pb;
		}

		public static byte[] get_text_bytes(string file_path)
		{
			if (!System.IO.File.Exists(file_path))
				throw new ArgumentException("file does not exist");
			return System.IO.File.ReadAllBytes(file_path);
		}
		public static TextRange[] IndexesToRange(byte[] src, params long[] values)
		{
			long offset = 0;
			List<TextRange> range = new List<TextRange>();
			range.Add(new TextRange(0, values[0]));
			offset = values[0] + 1;
			for (int i = 1; i < values.Length; i++) {
				long toffset = values[i];
				range.Add(new TextRange(values[i - 1] + 1, 				/*(i<values.Length-1)?*/					/*:src.Length-values[i-1]*/values[i])				);
				offset = toffset;
			}
			range.Add(new TextRange(offset + 1, src.Length));
			return range.ToArray();
		}
	}
}
