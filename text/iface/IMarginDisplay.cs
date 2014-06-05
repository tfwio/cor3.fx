/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;
using System.Windows.Forms;

using efx;
using Text.TextPad;

namespace Text
{
	public interface IMarginDisplay
	: IDisplayStyles
	{
	int Left { get;set; }
	Border3DSide BorderSides { get;set; }
	Rectangle ClientRect { get;set; }
	Orientation HorVert { get;set; }
	}
}
