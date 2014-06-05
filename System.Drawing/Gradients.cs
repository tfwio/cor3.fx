/**
 * 
 * User: tfw
 * Date: 11/12/2008
 * Time: 9:37 PM
 * 
**/
using System;
using System.Drawing.Drawing2D;
using System.Drawing.Utilities;

namespace System.Drawing
{
	public class Gradients
	{
		static FPoint _def0 = new FPoint(0,0);
		static FPoint _def1 = new FPoint(0,40);
		static public LinearGradientBrush GetLinearGradient(string c1, string c2) { return GetLinearGradient(_def0,_def1,ColourUtil.HexStr2Clr(c1),ColourUtil.HexStr2Clr(c2)); }
		static public LinearGradientBrush GetLinearGradient(FPoint p1, FPoint p2,string c1, string c2) { return GetLinearGradient(p1,p2,ColourUtil.HexStr2Clr(c1),ColourUtil.HexStr2Clr(c2)); }
		static public LinearGradientBrush GetLinearGradient(Color c1, Color c2) { return GetLinearGradient(_def0,_def1,c1,c2); }
		static public LinearGradientBrush GetLinearGradient(FPoint p1, FPoint p2, Color c1, Color c2) { return new LinearGradientBrush(p1,p2,c1,c2); }
		static public LinearGradientBrush GradientDarkBackground { get { return new LinearGradientBrush( _def0,_def1,SystemColors.Control,Color.FromArgb(0,SystemColors.ControlDarkDark)); } }
		//static public LinearGradientBrush GradientDarkBackground { get { return new LinearGradientBrush( _def0,_def1,Color.FromArgb(127,Color.FromArgb(0x7FFF)),Color.FromArgb(127,Color.Black)); } }
		static public LinearGradientBrush DocumentActive { get { return new LinearGradientBrush( _def0,_def1,SystemColors.AppWorkspace,Color.FromArgb(0,SystemColors.Control)); } }
		//static public LinearGradientBrush GradientRedDark { get { return new LinearGradientBrush( _def0,_def1,Color.FromArgb(127,Color.FromArgb(0x7F0000)),Color.FromArgb(127,Color.Black)); } }
		static public LinearGradientBrush ActiveCaption { get { return new LinearGradientBrush( _def0,_def1,SystemColors.ActiveCaption,Color.FromArgb(0,SystemColors.ActiveCaption)); } }
		static public LinearGradientBrush InactiveCaption { get { return new LinearGradientBrush( _def0,_def1,SystemColors.InactiveCaption,Color.FromArgb(0,SystemColors.InactiveCaption)); } }
		//static public LinearGradientBrush GradientBlueControl { get { return new LinearGradientBrush( _def0,_def1,Color.FromArgb(255,Color.FromArgb(0x7FFF)),Color.FromArgb(255,SystemColors.Control)); } }
	}
}