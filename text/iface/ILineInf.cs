/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Text;

namespace Text
{
	public interface ILineInf
	{
		/// <summary>Line Number</summary>
		int LineNum { get; }
		/// <summary>Char offset in the buffer</summary>
		int CharFirst { get; }
		/// <summary>Length of the line</summary>
		int CharLen { get; }
		/// <summary>Number of lines if IsWordWrap</summary>
		int LinesWrapped { get; }
	}
}
