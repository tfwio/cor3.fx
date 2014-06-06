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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Cor3.text
{
	public class ParserData
	{
		public QueryDictionary queries;
		virtual public void InitializeDictionary()
		{
			queries = new QueryDictionary();
		}
		internal static Encoding default_encoding = System.Text.Encoding.UTF8;
		internal Encoding encoder = default_encoding;
		public Encoding Encoder { get { return encoder; } set { encoder = value; } }

		public byte[] ByteData;
		public string StringData { get { return Encoder.GetString(ByteData); } set { ByteData = Encoder.GetBytes(value); } }
		public char[] CharData { get { return Encoder.GetChars(ByteData); } set { ByteData = Encoder.GetBytes(value); } }

		public ParserData(byte[] text) : this(text,default_encoding) {}
		public ParserData(byte[] text, bool UseEncoder) : this(text,default_encoding,UseEncoder) {}
		public ParserData(byte[] text, Encoding enc) : this(text,enc,true) {  }
		/// unnecessary to use encoder if we know encoding being used
		public ParserData(byte[] text, Encoding enc, bool UseEncoder)
		{
			InitializeDictionary();
			Encoder = enc;
			ByteData = (UseEncoder) ? encoder.GetBytes(encoder.GetString(text)) : text;
		}
		public ParserData(string text) { StringData = text; }
		public ParserData(char[] text) : this(text,default_encoding) {  }
		public ParserData(char[] text, Encoding enc) { Encoder=enc; CharData = text; }
		static public ParserData FromFile(string filename,Encoding enc,bool useEnc)
		{
			if (!File.Exists(filename)) return null;
			return new ParserData(File.ReadAllBytes(filename),enc,useEnc);
		}
	}
}
