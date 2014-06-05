/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;
using System.Windows.Forms;

using efx;
using Text.TextPad;

namespace Text
{
	public interface ITcMouse
	{
		/// <summary>MouseWheel Scroll Amount</summary>
		int MouseWheelAmt { get;set; }
		/// <summary>
		/// a static function might be necessary to read the current line
		/// to tell where in the string the mouse is actually located?
		/// </summary>
		/// <remarks>not yet implemented. (reserved for future use)</remarks>
		Point MousePosition {get;}
	}
}
