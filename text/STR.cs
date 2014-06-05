/* oOo * 12/8/2007 : 1:08 PM */

using System;

namespace System.Text
{
	public class STR : System.Cor3.util.StringUtil
	{
		/// <summary>Char array to string</summary>
		/// <remarks>for strings where encoding is irrevelant</remarks>
		static public string mop (char[] inchr)
		{
			string m = "";
			for (int i=0; i< inchr.Length; i++)
				m += inchr[i]; return m;
		}

		/// <summary>reverse a bit array</summary>
		/// <param name="bits">the result is reversed (for little-endian/big-endian swapping)</param>
		/// <returns>a reversed array of bits.</returns>
		static public byte[] convb(byte[] bits){ if (BitConverter.IsLittleEndian) Array.Reverse(bits); return bits; }

		/**
		 * the following (ToArray) is generally useless
		 * considering default string functions such as string.Split()
		**/
		#region ToArray
		static public string[] ToArray(string input, char split,StringSplitOptions sso) { if (input==null || input==string.Empty) return null; if (LineRegion.GetLineCount(input)>0) return input.Split(new char[]{split},sso); return new string[]{input}; }
		static public string[] ToArray(string input,string split,StringSplitOptions sso) { if (input==null || input==string.Empty) return null; if (LineRegion.GetLineCount(input)>0) return input.Split(new string[]{split},sso); return new string[]{input}; }
		static public string[] ToArray(string input) { return ToArray(input,"\r\n",StringSplitOptions.RemoveEmptyEntries); }
		static public string[] ToArray(string input,string split) { return ToArray(input,split,StringSplitOptions.RemoveEmptyEntries); }
		static public string[] ToArray(string input, char split) { return ToArray(input,split,StringSplitOptions.RemoveEmptyEntries); }
		#endregion

	}

}
