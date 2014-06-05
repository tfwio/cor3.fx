/**
 * oOo * 12/19/2007 : 7:56 PM *
**/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace drawing.forms.controls
{
	/// <summary>
	/// used for per-pixel overlay forms
	/// or OverlayBase form particularly.
	/// </summary>
	public interface IOverlay
	{
		IntPtr Handle { get; }
	//	spl Spl {get;set;}
		bool ButtonVisible { get; set; }
		bool Visible { get; set; }
		bool IsDisposed {get;}
		FormBorderStyle FormBorderStyle { get;set; }
		Color BackColor { get;set;}
		Size Size {get;set;}
		Point Location {get;set;}
		void Initialize();
		void Show(IWin32Window win);
		void Show();
		void Close();
		void Dispose();
	}
}
