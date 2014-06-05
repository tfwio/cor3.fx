/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Text
{
	/*******************************************************************************
	****	Base Style Info
	 * 		used(?) for forms & controls? (Text Interface 4sure)
	*******************************************************************************/
	public interface IDisplayStyles
		: IStyleDefault, IStyleSelection, IStyleBorder
	{
	}
	public interface IStyleBorder
	{
		/// <summary></summary>
		Border3DStyle Border3D { get;set; }
	}
	public interface IStyleDefault
	{
		/// <summary></summary>
		Color ForeColor { get;set; }
		/// <summary></summary>
		Color BackColor { get;set; }
	}
	public interface IStyleSelection
	{
		/// <summary></summary>
		Color SelectionFg { get;set; }
		/// <summary></summary>
		Color SelectionBg { get;set; }
	}
}
