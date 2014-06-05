#region tfw * 8/1/2009 * 4:24 PM ** 'LICENSE & File Header'
/** [insert license here] **
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

namespace System.Cor3.text
{
	public class parser_stream_base
	{
		public BinaryReader b_reader = null;
		public FileStream   b_fstream = null;
		public bool IsFileStreamNull { get { return b_fstream==null; } }

		public parser_stream_base(string input_file)
		{
			b_fstream = System.IO.File.Open(input_file,System.IO.FileMode.Open);
			b_reader = new System.IO.BinaryReader(b_fstream);
		}
		public void Close()
		{
			if (!IsFileStreamNull) 
			{
				b_fstream.Dispose(); b_fstream = null;
			}
		}
	}

}
