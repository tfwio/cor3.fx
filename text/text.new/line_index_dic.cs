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

#if EFX
using Cor3;
#elif Cor3
using Cor3;
#endif

namespace System.Cor3.text
{

	public enum uni_bom_t
	{
		UTF32_BE,UTF32_LE,
		UTF16_BE,UTF16_LE,
		UTF8,Unknown,
	}
	public class uni_bom
	{
		static public byte[] bom_utf32_be = {0,0,0xFE,0xFF};
		static public byte[] bom_utf32_le = {0xFF,0xFF,0,0};
		static public byte[] bom_utf16_be = {0xFE,0xFF};
		static public byte[] bom_utf16_le = {0xFF,0xFE};
		static public byte[] bom_utf8 = {0xEF,0xBB,0xBF};
		static public uni_bom_t check(byte[] range)
		{
			if (range.Length < 5) return uni_bom_t.Unknown;
			else if (check(uni_bom_t.UTF32_BE,range)) return uni_bom_t.UTF32_BE;
			else if (check(uni_bom_t.UTF32_LE,range)) return uni_bom_t.UTF32_LE;
			else if (check(uni_bom_t.UTF16_BE,range)) return uni_bom_t.UTF16_BE;
			else if (check(uni_bom_t.UTF16_LE,range)) return uni_bom_t.UTF16_LE;
			else if (check(uni_bom_t.UTF8,range)) return uni_bom_t.UTF8;
			return uni_bom_t.Unknown;
		}
		static public bool check(uni_bom_t typ, byte[] range)
		{
			byte[] ck;
			switch (typ)
			{
			case uni_bom_t.UTF32_BE: return check(typ,bom_utf32_be,range);
			case uni_bom_t.UTF32_LE: return check(typ,bom_utf32_le,range);
			case uni_bom_t.UTF16_BE: return check(typ,bom_utf16_be,range);
			case uni_bom_t.UTF16_LE: return check(typ,bom_utf16_be,range);
			case uni_bom_t.UTF8: return check(typ,bom_utf8,range);
			default: return false;
			}
			
		}
		static public bool check(uni_bom_t typ, byte[] uni, byte[] range)
		{
			for (int i = 0; i<uni.Length; i++)
				if (uni[i]!=range[i]) return false;
			return true;
		}
		/// returns the default (Ansi) Encoding if no encoding is found
		static public System.Text.Encoding get_encoder(byte[] range)
		{
			uni_bom_t t = check(range);
			if (t == uni_bom_t.Unknown) return System.Text.Encoding.Default;
			switch (t)
			{
				case uni_bom_t.UTF32_BE: case uni_bom_t.UTF32_LE:
					return System.Text.Encoding.UTF32;
				case uni_bom_t.UTF16_BE: case uni_bom_t.UTF16_LE:
					return System.Text.Encoding.Unicode;
				case uni_bom_t.UTF8: return System.Text.Encoding.UTF8;
			}
			return System.Text.Encoding.Default;
		}
	}
	public class line_index_dic : DICT<long,long> { public line_index_dic() : base() { } }
}
