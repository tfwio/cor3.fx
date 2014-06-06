/* oOo * 11/14/2007 : 9:53 PM */
/* [insert license here] **
 * NameSpace Description:
 * 	this class is to generally encapsulate classes which are to contain
 * 	redundant 'library' functions to aid in PlugIn Controls and Application
 * 	Routines/Abilities.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;


namespace System.Cor3.util
{
	/**
	 * most of this really is depreceated in concept most likely by REGEX
	 **/
	[Obsolete("Moved to System.Core3 library (not sure what namespace)")]
	public class StringUtil
	{
		public enum eol { Cr, Lf, CrLf, Ignore, AddSpace, CommaDelimit, }

		
		static public string Repeat(string str, int count)
		{
			string outp = "";
			for (int i=0;i<count; i++) outp+=str;
			return outp;
		}

		/// Checks a extension against a group of extensions.</br>
		/// Requisites </br>
		/// • Get the extension from a file</br>
		/// • You have a list of extensions</br>
		/// <remarks>I'm not sure if this was tested</remarks>
		/// <param name="ext"></param>
		/// <param name="Extentions"></param>
		/// <returns></returns>
		static public bool testext (string ext, params string[] Extentions)
		{
			foreach (string exten in Extentions) if (exten.Trim()==ext) return true;
			return false;
		}

		#region / CountX / this is old as hell.
		/// <summary>
		/// counts the number of endlines (char)10 and sends each position
		/// (starting with -1).
		/// </summary>
		/// <returns>
		/// a <code>integer List</code> containing line-end positions. <br/>
		/// if string is <code>null</code>, list is <code>null</code>.<br/>
		/// if string is empty list contains a single value of <code>-1</code>.
		/// </returns>
		static public List<int> CountX(string sbuff)
		{
			if (sbuff==null) return null;
			List<int> tlist = new List<int>();
			int ndx = 0;
			tlist.Add(-1);
			if (sbuff==string.Empty) return tlist;
			while (ndx!=-1)
			{
				ndx=sbuff.IndexOf((char)10,ndx);
				
				tlist.Add(ndx);
				if (ndx==-1) break;
				ndx++;
			}
			return tlist;
		}

		#endregion
		#region static properties
		static public byte[] Cr = {0x0D};
		static public byte[] Lf = {0x0A};
		static public byte[] CrLf = {0x0D,0x0A};
		static public byte[] Space = {0x0E};
		static Encoding DefaultEncoding = Encoding.Default;
		#endregion
		#region fromStrArray (unused)
		static public string FromStrArray(params string[] input){ return FromStrArray(eol.CrLf,input); }
		static public string FromStrArray(eol emode, params string[] input){
			if (input == null) return null;
			if (input.Length==0) return null;
			string ret = "", endl = LineEnd(emode);
			foreach (string str in input){
				ret += str+endl;
			}
			endl = null; return ret;
		}
		static public string FromStrArray(string endl, params string[] input){
			if (input == null) return null; if (input.Length==0) return null;
			string ret = ""; foreach (string str in input) if (str!=string.Empty) ret += str+endl;
			return ret;
		}
		static public string FromStrArray(char endl, params string[] input){
			if (input == null) return null; if (input.Length==0) return null;
			string ret = "";
			foreach (string str in input){ if (str!=string.Empty) ret += str+endl; }
			return ret;
		}
		static public string FromStrArray(string Expression, params object[] input) { return string.Format(Expression,input); }
		#endregion
		#region LineEnd
		static public string LineEnd(eol mode, Encoding enc){
			switch (mode) {
					case eol.Cr: return getStr(Cr,enc);
					case eol.Lf: return getStr(Lf,enc);
					case eol.CrLf: return getStr(CrLf,enc);
					case eol.AddSpace: return " ";
					case eol.CommaDelimit: return ",";
					case eol.Ignore: return string.Empty;
			}
			return null;
		}
		static public string LineEnd(eol mode){ return LineEnd(mode,DefaultEncoding); }
		#endregion
		#region strep (unused)
		/// <summary>
		/// Strips a string to be a particular length?
		/// I believe this was handy in a Hex-Viewer that I'd written.
		/// It was probably was sent something that was padded?
		/// it would probably be a better idea to string.Format("{D:2}",etc);
		/// </summary>
		static public string strep(int ti, string xi) { string sout = ""; for (int i=0; i< ti;i++) sout += xi; return sout; }
		#endregion
		#region ValueFilter (URL Decoding/Text Encoding)
		/***********************************************************************
		 * DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED
		 * WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING
		 ***********************************************************************
		 * I believe that this class is/was a work in progress when I had created
		 * it.  Used in a DockContent panel causes some bugs possibly in the way
		 * the data is used.
		 ***********************************************************************
		 * WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING
		 * DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED
		 ***********************************************************************
		 * the code is also outdated/depreceated (to my personal standards)
		 ***********************************************************************
		 * WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING
		 * DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED
		 ***********************************************************************
		 ***/
		/// <summary>
		/// WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING
		/// if the content is byte[] or of a specific char-encoding
		/// An overload is required to provide a requested byte/char enc/dec
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		static public string valueFilter(object val) {

			string valtype		= val.GetType().ToString();
			Encoding ascii		= Encoding.ASCII;
			Encoding utfx		= Encoding.UTF8;
			Encoding unicode	= Encoding.Unicode;
			Encoding def		= Encoding.Default;

			string temp; byte[] text;

			switch (valtype) {
				case "System.Byte[]":
					return "BLOB["+((byte[])val).Length.ToString("##,###,###,###,##0")+"]";
				case "System.String":
					try
					{
						text = def.GetBytes((string)val);
						temp = System.Uri.UnescapeDataString(def.GetString(text));
					}
					catch
					{
						text = def.GetBytes((string)val);
						temp = def.GetString(text);
						if (temp==null) temp = "";
					}
					text = ascii.GetBytes(temp);
					text = Encoding.Convert(ascii,utfx,text);
					return utfx.GetString(text);
					default: return val.ToString();
			}

		}
		/// <summary>
		/// WARNING DEPRECEATED WARNING DEPRECEATED WARNING DEPRECEATED WARNING
		/// </summary>
		/// <param name="val"></param>
		/// <param name="showBlob"></param>
		/// <returns></returns>
		static public string valueFilter(object val, bool showBlob) {
			string valtype		= val.GetType().Name;
			Encoding ascii		= Encoding.ASCII;
			Encoding utfx		= Encoding.UTF8;
			Encoding unicode	= Encoding.Unicode;

			string temp; byte[] text;
			switch (valtype) {
				case "Byte[]":
					if (!showBlob)
						return "BLOB["+((byte[])val).Length.ToString("##,###,###,###,##0")+"]";
					else {
						temp = HttpUtility.UrlDecode((byte[])val,System.Text.Encoding.Default);
						return HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(temp));
					}
				case "String":
					temp = System.Uri.UnescapeDataString(((string)val));
					text = ascii.GetBytes(temp);
					text = Encoding.Convert(ascii,utfx,text);
					return utfx.GetString(text);
				default:
					return val.ToString();
			}
		}
		#endregion

		#region / filterStr /
		static public string filterPath(string file)
		{
			return filterPath(file,new string[]{"/"});
		}
		static public string filterPath(string file,string[] val)
		{
			string go = "";
			string[] fo = file.Split(val, StringSplitOptions.None);
			foreach (string mo in fo)
			{
				go+=StringUtil.filterStr(mo)+"/";
			}
			return go;
		}
		/// <summary>
		/// Filter underscore to space (used to make enumerations more easily
		/// human-readable).
		/// </summary>
		/// <param name="stringin">string to be 'filtered'</param>
		/// <returns></returns>
		static public string filterStr(string stringin) {
			string expo="";
			byte[] test = getBit(stringin.Replace(" ","_"));
			foreach (byte bits in test) {
				if ((bits >= 48) && (bits <= 57)) expo += (char)bits;
				if ((bits >= 65) && (bits <= 90)) expo += (char)bits;
				if ((bits >= 97) && (bits <= 122)) expo += (char)bits;
				if ((bits == 95)) expo += (char)bits;
			}
			return expo;
		}
		#endregion
		#region / GetChar /
		static public char[] GetChar(string str){ return GetChar(getBit(str,DefaultEncoding)); }
		static public char[] GetChar(string str, Encoding Enc){ return GetChar(getBit(str,Enc),Enc); }
		static public char[] GetChar(byte[] bytes, bool IsAscii){ if (IsAscii) GetChar(bytes,Encoding.ASCII); return GetChar(bytes); }
		static public char[] GetChar(byte[] bytes){ return GetChar(bytes,DefaultEncoding); }
		static public char[] GetChar(byte[] bytes, Encoding Enc){ return Enc.GetChars(bytes); }
		#endregion

		#region / getStr /
		static public string getIntString(string fmt,int[] str) { return getIntString(fmt,str,StringUtil.GetChar(",")); }
		static public string getIntString(int[] str) { return getIntString(str,StringUtil.GetChar(",")); }
		static public string getIntString(int[] str, char[] seperator) { string retern=""; foreach (int i in str) retern+= string.Format("{0:000#}",i.ToString("000#"))+StringUtil.getStr(Encoding.Default.GetBytes(seperator)); return retern.TrimEnd(seperator); }
		static public string getIntString(string fmt, int[] str, char[] seperator) { string retern=""; foreach (int i in str) retern+= string.Format(fmt,i.ToString("000#"))+StringUtil.getStr(Encoding.Default.GetBytes(seperator)); return retern.TrimEnd(seperator); }
		/// <summary>Converts char[] to Default String object</summary>
		/// <param name="inchr">[in] char[]</param>
		/// <returns>Default (encoding) string</returns>
		static public string getStr (char[] inchr) { string m = ""; for (int i=0; i< inchr.Length; i++) m += inchr[i]; return m; }		/// <summary>byte[] to string conversion</summary>
		static public string getStr(byte[] inByte) { return getStr(inByte,Encoding.Default); }
		/// <summary>byte[] to string conversion</summary>
		static public string getStr(byte[] inByte,Encoding enc) { return enc.GetString(inByte); }
		#endregion

		#region GetBit
		[Obsolete("this call has been moved to System.Cor3 (System) namespace.")]
		/// <summary>string to byte[] conversion</summary>
		static public byte[] getBit(string inpoo) { return DefaultEncoding.GetBytes(inpoo); }
		[Obsolete("this call has been moved to System.Cor3 (System) namespace.")]
		/// <summary>byte[] to string conversion</summary>
		static public byte[] getBit(string inpoo,Encoding Enc) { return Enc.GetBytes(inpoo); }
		#endregion

		#region Static (BOM)
		/**
		 * this is duplicated in Classes.Parser2
		 */
//		public enum BOM {
//			UTF16 = 0xFFFE,
//			UTF16M = 0xFEFF,
//			UTF8 = 0xEFBBBF
//		}
		/// <summary>
		/// *** see System.Text.Encoding.GetPreamble Method
		/// returns an array containing encoding info for two scenarios and
		/// also Big/Little-Endian (processor) fmt... <br/>
		/// [0]=either UTF8, or UTF16,[1] = a hex (string) interpretation,
		/// [3] = lE(little) | bE(big)
		/// </summary>
		/// <param name="fname"></param>
		/// <returns></returns>
		static public string[] BomInfo(string fname) {

			string[] ret = null;
			ushort bs;
			string r;

			if (!File.Exists(fname)) return null;

			FileStream fs = File.Open(fname, FileMode.Open);
			if (fs.Length < 3) return null;
			BinaryReader br = new BinaryReader(fs);

			if (System.BitConverter.IsLittleEndian) r = "LittleEndian";
			else r = "BigEndian";

			bs = BitConverter.ToUInt16(br.ReadBytes(2),0);

			if (bs==(ushort)0xFEFF) ret = new string[]{"UTF16","0xFEFF",r};
			else if (bs==(ushort)0xFFFE) ret = new string[]{"UTF16","0xFFFE",r};
			else if (bs==((ushort)0xEFB8)) {
				if ( br.ReadByte() == (byte)0xBF )
					ret = new string[]{"UTF8","0xEFB88F",r};
			}

			fs.Close(); fs.Dispose(); fs = null;
			br.Close(); br = null;

			return ret;
		}
		static public string[] BomInfo(FileStream fs) {

			long pos = fs.Position;
			fs.Seek(0, SeekOrigin.Begin);
			string[] ret = null;
			ushort bs;
			string r;

			if (fs.Length < 3) return null;
			BinaryReader br = new BinaryReader(fs);

			if (System.BitConverter.IsLittleEndian) r = "LittleEndian";
			else r = "BigEndian";

			bs = BitConverter.ToUInt16(br.ReadBytes(2),0);

			if (bs==(ushort)0xFEFF) ret = new string[]{"UTF16","0xFEFF",r};
			else if (bs==(ushort)0xFFFE) ret = new string[]{"UTF16","0xFFFE",r};
			else if (bs==((ushort)0xEFB8)) {
				if ( br.ReadByte() == (byte)0xBF )
					ret = new string[]{"UTF8","0xEFB88F",r};
			}

			br.Close(); br = null;
			fs.Seek(pos, SeekOrigin.Begin);

			return ret;
		}
		#endregion

	}
}
