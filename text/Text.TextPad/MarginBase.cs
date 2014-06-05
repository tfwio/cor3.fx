/* oOo * 12/8/2007 : 6:19 AM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Text;

namespace Text.TextPad
{

	/// <summary></summary>
	public class MarginBase : IMarginInfo {

		/// <summary></summary>
		public MarginBase(TextPanelBase parent, int lef){
			left = lef;
			P = parent;
			PaintL += LPaint;
		}

		#region Drawing
		#region DUpdate
		/// <summary></summary>
		public Image DUpdate(TextPanelBase C) { P = C; return DUpdate(false); }
		/// <summary></summary>
		public Image DUpdate() { return DUpdate(false); }
		/// <summary></summary>
		public Image DUpdate(bool dispose){
			if (!(P.Size.Width > 0) || !(P.Size.Height > 0)) return bmp;
			if (dispose) { if (bmp!=null) bmp.Dispose(); if (gfx!=null) gfx.Dispose(); }
			if (IsVisible)
			{
				cRect = new Rectangle(
					0, 0,
					left, P.ClientSize.Height
				);
				bmp = new Bitmap(left,P.ClientRectangle.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				gfx = Graphics.FromImage(bmp);
				gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
			//	gfx.TextRenderingHint  = TextRenderingHint.ClearTypeGridFit;
				gfx.Clear(SystemColors.Control);
				int lh = P.ClientRectangle.Height / P.Font.Height;
				ControlPaint.DrawBorder3D( gfx, cRect, P.Border3D, Border3DSide.Right );
				for (int i = 0; i < lh; i++) OnPaintL(new MarginPaintEvent(gfx,i,lh));
				}
			return bmp;
		}
		#endregion
		#region LPaint, PaintLine, OnPaintL
		/// <summary></summary>
		public event MarginPaint PaintL;
		/// <summary></summary>
		virtual public void LPaint(MarginBase x, MarginPaintEvent me) {}
		/// <summary></summary>
		virtual public void OnPaintL(MarginPaintEvent me){
			if (PaintL!=null) PaintL(this,me);
		}
		#endregion
		#endregion

		Graphics gfx;
		Bitmap bmp;

		#region Properties
		#region Parent
		/// <summary></summary>
		public TextPanelBase P;
		#endregion
		#region IsVisible
		bool isVisible = true;
		/// <summary></summary>
		public bool IsVisible {
			get { return isVisible; }
			set { isVisible = value; }
		}
		#endregion
		#region Alignment & Display Properties
		#region Size
		int left = 16;
		/// <summary></summary>
		public int Left {
			get { return left; }
			set { left = value; }
		}
		
		Rectangle cRect;
		/// <summary></summary>
		public Rectangle ClientRect {
			get { return cRect; }
			set { cRect = value; }
		}
		#endregion
		System.Windows.Forms.Border3DSide borders;
		/// <summary></summary>
		public Border3DSide BorderSides {
			get { return borders; }
			set { borders = value; }
		}
		System.Windows.Forms.Border3DStyle borderstyle;
		/// <summary></summary>
		public System.Windows.Forms.Border3DStyle Border3D {
			get { return borderstyle; }
			set { borderstyle = value; }
		}
		AnchorStyles anchor;
		/// <summary></summary>
		public AnchorStyles Anchor {
			get { return anchor; }
			set { anchor = value; }
		}
		System.Windows.Forms.Orientation horVert;
		/// <summary></summary>
		public Orientation HorVert {
			get { return horVert; }
			set { horVert = value; }
		}
		#endregion
		#region Colors
		Color bgColor = SystemColors.Control;
		/// <summary></summary>
		public Color BackColor {
			get { return bgColor; }
			set { bgColor = value; }
		}
		Color fgColor = SystemColors.ControlText;
		/// <summary></summary>
		public Color ForeColor {
			get { return fgColor; }
			set { fgColor = value; }
		}
		Color bgActive = SystemColors.ActiveCaption;
		/// <summary></summary>
		public Color SelectionBg {
			get { return bgActive; }
			set { bgActive = value; }
		}
		Color fgActive = SystemColors.ActiveCaptionText;
		/// <summary></summary>
		public Color SelectionFg {
			get { return fgActive; }
			set { fgActive = value; }
		}
		#endregion
		#endregion

	}
}
