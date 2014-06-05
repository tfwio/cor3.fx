/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;
using System.Windows.Forms;

using efx;
using Text.TextPad;

namespace Text
{
	/*******************************************************************************
	****	Margins
	*******************************************************************************/
	public interface IMarginInfo
	: IMarginDraw 
	{
	bool IsVisible { get;set; }
	}
}
