#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Xml.Serialization;

namespace iface
{
	public interface ITextStyle
	{
		bool Bold {get;}
		bool Italic {get;}
		bool Strikeout {get;}
		bool Underline {get;}
	}


}
