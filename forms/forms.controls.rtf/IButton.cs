/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace System.Cor3.Forms.rtf
{

	public interface IButton
	{
		int Width {get;set;}
		int Height {get;set;}
		int Top {get;set;}
		int Left {get;set;}
		Color ColorDefault {get;}
		Color ColorUp {get;}
		Color ColorDown {get;}
		PointF OffDefault {get;}
		PointF OffUp {get;}
		PointF OffDown {get;}
		string FontFam {get;set;}
		float  FontSize {get;set;}
		string FontSymbol {get;set;}
		void CallDraw(Graphics gfx);
		void HitTest(MouseButtons Buttons, PointF pt, Graphics gfx);
	}
}
