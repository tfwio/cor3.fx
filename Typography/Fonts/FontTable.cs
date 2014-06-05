/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Collections;
using System.Xml.Serialization;

using Cor3;

namespace System.Cor3.Forms.typography
{
	/// Maps a font to a name entry.
	public class FontTable : DICT<string,FontTableEntry>
	{
		public Hashtable FontCollection  = new Hashtable();
	}
}
