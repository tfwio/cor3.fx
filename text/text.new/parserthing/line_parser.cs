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

namespace System.Cor3.text
{
	public class line_parser : parser_stream_base
	{
		internal bool AutoByteEnabled = false;
		internal byte AutoByte { get { return (AutoByteEnabled)?b_reader.ReadByte():(byte)0; } }
		List<long> linePositions;
		
		public line_parser(string in_file) : base(in_file)
		{
			get_line_positions();
		}
		public void get_line_positions()
		{
			AutoByteEnabled = true;
			linePositions = new List<long>();
			for (long i=0; i < b_fstream.Length; i++)
			{
				byte bit = AutoByte;
				switch (bit)
				{
				case 13: linePositions.Add(i); break;
				default: break;
				}
			}
			AutoByteEnabled = false;
		}
	}
}
