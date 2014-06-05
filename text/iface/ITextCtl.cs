/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;
using System.Windows.Forms;

using efx;
using Text.TextPad;

namespace Text
{
	/*******************************************************************************
	****	Text Control
	*******************************************************************************/
	public interface ITextCtl :
	ITcEvents,ITcLineInfo,IDisplayStyles,ITcTextStyle,ITcMouse
	{
	/// <summary></summary>
	LineMargin MNumbers { get;set; }
	}
}
