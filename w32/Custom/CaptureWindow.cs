/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

using w32.gdi;
using w32.shell;
using w32.user;

namespace w32
{
	public class CaptureWindow : User32 // re:constrewn: ImageCapture http://www.codeproject.com/KB/graphics/imagecapture.aspx
	{
		HBITMAP hdc;
		[Browsable(false)] public HBITMAP hDc { get { return hdc; } set { hdc = value; } }
		[Browsable(false)] static public IntPtr DesktopFolder { get { return GetDesktopWindow()/*Shell.SHGetDesktopFolder(out rp);*/;; } }
		[Browsable(false)] virtual public Size Size { get { return new Size(GetSystemMetrics(0),User32.GetSystemMetrics(1)); } }
		[Browsable(false)] virtual public Rectangle Rect { get { return new Rectangle(0,0,GetSystemMetrics(0),GetSystemMetrics(1)); } }
		[Browsable(false)] virtual public Bitmap this[IntPtr hWnd] { get { return this[hWnd,0,0,Size.Width,Size.Height]; } }//IntPtr	desktopHWND = GetDesktopWindow();// window handle for desktop
		virtual public Bitmap this[IntPtr handle,Rectangle r] { get { return this[handle,r.X,r.Y,r.Width,r.Height]; } }
		virtual public Bitmap this[Rectangle r] { get { return this[hDc,r.X,r.Y,r.Width,r.Height]; } }
		virtual public Bitmap this[int x,int y,int w,int h] { get { return this[hDc,x,y,w,h]; } }
		virtual public Bitmap this[IntPtr hWnd, int x, int y, int width, int height]
		{
			get{
				IntPtr	wndHDC = GetDC(hWnd);
				IntPtr	capHDC = Gdi32.CreateCompatibleDC(wndHDC);
				IntPtr	capBMP = Gdi32.CreateCompatibleBitmap(wndHDC, width, height);
				if (capBMP == IntPtr.Zero)
				{
					ReleaseDC(hWnd,wndHDC);
					Gdi32.DeleteDC(capHDC); return null;
				}
				IntPtr prvHDC = (IntPtr)Gdi32.SelectObject(capHDC,capBMP);
				Gdi32.BitBlt(capHDC,0,0,width,height,wndHDC,x,y,Gdi32.SRCCOPY); // managed: CompositeMode
				Gdi32.SelectObject(capHDC,prvHDC);
				Bitmap	bmp = System.Drawing.Image.FromHbitmap(capBMP); 
				ReleaseDC(hWnd,wndHDC);	// release window context
				Gdi32.DeleteDC(capHDC);			// delete capture context
				Gdi32.DeleteObject(capBMP);		// delete capture bitmap
				return bmp;						// return bitmap
			}
		}
		public CaptureWindow() { }
		virtual public Bitmap Dc2Bmp(IntPtr hWnd, int Bit)
		{
			IntPtr	wndHDC = GetDC(hWnd);
			IntPtr	capHDC = Gdi32.CreateCompatibleDC(wndHDC);
			HBITMAP	capBMP = Gdi32.CreateCompatibleBitmap(wndHDC, Size.Width, Size.Height);
			if (capBMP == IntPtr.Zero)
			{
				ReleaseDC(hWnd,wndHDC);
				Gdi32.DeleteDC(capHDC); return null;
			}
			IntPtr prvHDC = (IntPtr)Gdi32.SelectObject(capHDC,capBMP);
			Gdi32.BitBlt(capHDC,0,0,Size.Width,Size.Height,wndHDC,Rect.X,Rect.Y,Bit); // managed: CompositeModeGDI.SRCCOPY
			Gdi32.SelectObject(capHDC,prvHDC);
			Bitmap	bmp = System.Drawing.Image.FromHbitmap(capBMP); 
			ReleaseDC(hWnd,wndHDC);	// release window context
			Gdi32.DeleteDC(capHDC);			// delete capture context
			Gdi32.DeleteObject(capBMP);		// delete capture bitmap
			return bmp;						// return bitmap
		}
	}
}
