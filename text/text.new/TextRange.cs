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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace System.Cor3.text
{
	public struct TextRange
	{
		public Color color_fg;
		public Color color_bg;
		public string storage;
		public string StoredValue { get { return (!HasStorage) ? null : storage; } }
		public bool HasStorage { get { return storage != null && storage != string.Empty; } }

		public bool flagx;
		public long offset;
		public long length;

		public long endpos { get { return offset+length; } }

		public int Compare(TextRange range)
		{
			return offset.CompareTo(range.offset);
		}
		static public int CompareTwo(TextRange range0, TextRange range1)
		{
			return range0.offset.CompareTo(range1.offset);
		}
		public bool IsContent(long i)
		{
			return ((i >= offset)&&(i<=(offset+length))) ? true:false;
		}

		public TextRange(Match m) : this(m,"word", SystemColors.WindowText) {}
		public TextRange(Match m, string xid, Color fg) : this(m,xid,fg, SystemColors.Window) {}
		public TextRange(Match m, string xid, Color fg, Color bg)
		{
			offset = m.Groups[xid].Index;
			storage = m.Groups[xid].Value;
			length = storage.Length; flagx=false;
			color_bg = bg;
			color_fg = fg;
		}
		public TextRange(long off, long off2) : this(off,off2,SystemColors.WindowText, SystemColors.Window) {}
		public TextRange(long off, long off2, Color fg) : this(off,off2,fg, SystemColors.Window) {}
		public TextRange(long off, long off2, Color fg, Color bg) { this.color_bg=bg; this.color_fg=fg; offset = off; length = Math.Abs(off2-off); flagx = false; storage = null; }
//		note that these are not tested hence it's unknown if they are working.
		static public implicit operator long(TextRange r) { return r.offset; }
		static public bool operator <(long i, TextRange r) { return i < (r.offset); }
		static public bool operator <(int i, TextRange r) { return i < (r.offset); }
		static public bool operator >(long i, TextRange r) { return i > (r.offset); }
		static public bool operator >(int i, TextRange r) { return i > (r.offset); }
	}
}
