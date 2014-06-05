#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;

namespace iface
{
	public interface IFontStyle
	{
		string FamilyName { get; }
		string FontSize { get; }
	//		string Style { get; }
		string Color { get; }
	}
}
