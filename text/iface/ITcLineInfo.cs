/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;
using System.Windows.Forms;

using efx;
using Text.TextPad;

namespace Text
{
	public interface ITcLineInfo
	{
		/// <summary>the number of lins that can be shown on the screen</summary>
		int LinesVisible { get; }
		/// <summary>
		/// Scrolling offset
		/// </summary>
		int LineOffset { get; }
		/// <summary>
		/// same as LinesVisible?
		/// </summary>
		/// <remarks>
		/// the bottom line number.
		/// NOTE: needs to calculate for WordWrapping.
		/// </remarks>
		int LineBottom { get; }
		/// <summary>Calculated on load.</summary>
		/// <remarks>the number of lines in the buffer</remarks>
		int LinesAvail { get; }
	}
}
