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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace drawing.Ren
{
	public interface ILayerInfo
	{
		string Caption { get;set; }
		FloatPoint Size { get;set; }
	}
}
