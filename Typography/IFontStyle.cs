/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using drawing;

namespace System.Cor3.Forms.typography
{
	public interface IFontStyle: IFontEntry
	{
		ColourEntry Colour { get;set; }
	}
}
