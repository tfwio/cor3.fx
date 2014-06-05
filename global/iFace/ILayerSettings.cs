/**

 * oOo * 12/19/2007 : 7:56 PM *

 ** placeholder **

 * Angle.cs
 * Circle.cs
 * Font.cs
 * HPoint.cs
 * IGfxLayer.cs
 * ControlDrawBase.cs
 * ColorPanel.cs

**/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace drawing.Ren
{
	/// <remarks>experimental specs</remarks>
	public interface ILayerSettings
	{
		bool IsVisible { get;set; }
		LineCap LineCap { get;set; }
		LineJoin LineJoin { get;set; }
		byte Opacity { get;set; }
		Color ForeColor { get;set; }
		Color BackColor { get;set; }
		PixelFormat ImageFormat { get;set; }
	}
}
