/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

using System.Cor3.man;

namespace drawing.text
{
	/// <summary>
	/// Description of TxtManager.
	/// </summary>
	public class TxtManager : TxtReader, ITxtInput
	{
		/// 
		public TxtManager()
		{
			txt_caret_init();
		}

		#region Caret — @important!
		long _caret_offset = -1, _caret_length = -1, _caret_line = 0;
		public CharacterRange txt_sel_range { get { return new CharacterRange((int)txt_caret,(int)txt_caret_len); } }
		/// 
		public long txt_caret { get { return _caret_offset; } set { _caret_offset = value; } }
		public long txt_caret_line { get { return _caret_line; } set { _caret_line = value; } }
		public long txt_caret_len { get { return _caret_length; } set { _caret_length = value; } }
		/// txt_caret_init
		virtual public void txt_caret_init()
		{
			txt_caret = txt_caret_line = txt_caret_len = 0;
		}
		/// Reserved — For future use
		virtual public void txt_caret_reset()
		{
			
		}
		/// Reserved — For future use (calls txt_caret_reset)
		virtual public void InvalidateCaret() { txt_caret_reset(); }
		/// Sets Caret info
		public int txt_caret_set(int line, int offset)
		{
			txt_caret = offset; txt_caret_len = 0; return offset;
		}
		#endregion

		// returns (and resets) the new caret position within the active line
		virtual public int txt_insert(string value) { return txt_insert((int)txt_caret_line,(int)txt_caret,value); }
		virtual public int txt_insert(int line, int offset, string value)
		{
			text_value[line].Insert(offset,value);
			return txt_caret_set(line,offset+value.Length);
		}
		
		public bool txt_has_selection
		{
			get
			{
				return txt_selection_range!=null;
			}
		}
		public CharacterRange? txt_selection_range {
			get {
				return null;
			}
			set {
				
			}
		}
	}

}
