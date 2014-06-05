/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;

namespace System.Cor3.Forms.typography
{
	public interface IFontEntry
	{
		string		FamilyName	{ get; }
		float 		Size		{ get;set; }
		FontStyle	Style		{ get; set; }
	}
}
