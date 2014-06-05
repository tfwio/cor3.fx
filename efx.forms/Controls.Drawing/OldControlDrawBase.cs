/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using Drawing.Events;
using Drawing.Render.Custom;
using w32;

namespace efx.Forms.Controls
{
	public class OldControlDrawBase : System.Windows.Forms.Control, ICustomPaint
	{
		TextRenderingHint RenderingHint = TextRenderingHint.AntiAliasGridFit;
		SmoothingMode _smoothing = SmoothingMode.HighQuality;
		InterpolationMode _interpolation = InterpolationMode.HighQualityBicubic;
		public SmoothingMode Smoothing { get {return _smoothing;} set { _smoothing = value;} }
		public InterpolationMode Interpolation { get {return _interpolation;} set { _interpolation = value;} }

		public OldControlDrawBase() : base()
		{
			CPaint += DoPaint;
		}
		public event CustomPaint CPaint;
		virtual public void OnCPaint(Graphics gfx) { if (CPaint != null) CPaint(this, gfx); }
		virtual public void DoPaint(Control ctl, Graphics gfx) {}
		virtual public void DoDraw(bool cls) {
			G();
			if (m_gfx==null) return;
			if (cls){
				b_gfx.Graphics.SmoothingMode = Smoothing;
				b_gfx.Graphics.InterpolationMode = Interpolation;
				b_gfx.Graphics.PageUnit = units;
				b_gfx.Graphics.TextRenderingHint = RenderingHint;
				b_gfx.Graphics.TextContrast = 6;
			}
			try { m_gfx.Clear(BackColor); } catch {return;}
			//ControlPaint.DrawBorder3D( m_gfx, o_rect, border3D, Border3DSide.All );
			//m_gfx.FillRectangle( new SolidBrush(bgColor), c_rect );
			OnCPaint(m_gfx);
			try { b_gfx.Render(); } catch { Global.stat("unkn buffer erro"); }
		}
		virtual public void DoDraw() { DoDraw(false); }
		// Graphics Initialization

		#region G()
		/// <summary>
		/// reloads the main graphics (again?)
		/// Maybe this here should get some more attention?
		/// </summary>
		public Graphics G() { return G(false); }
		public Graphics G(bool clear) {
			c_gfx = BufferedGraphicsManager.Current;
			if (ClientRectangle.Width > 0 && ClientRectangle.Height > 0)
			{
				c_gfx.MaximumBuffer = ClientSize;
				b_gfx = c_gfx.Allocate(CreateGraphics(),ClientRectangle);
				b_gfx.Graphics.PageUnit = units;
				
				if (clear) m_gfx.Clear(BackColor);
			}
			return m_gfx;
		}
		#endregion
		#region Graphics Object(s)
		[
			System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never),
			BrowsableAttribute(false)
		]
		public Graphics m_gfx{
			get{ if (b_gfx!=null) return b_gfx.Graphics; return null; } // main graphics object
		}
		public BufferedGraphics b_gfx;
		BufferedGraphicsContext c_gfx;
		#endregion
		#region Units
		GraphicsUnit units = GraphicsUnit.Pixel;
		public GraphicsUnit Units
		{
			get { return units; }
			set { units = value; G(); }
		}
		#endregion
		#region Paint Overrrides
		protected override void OnPaint(PaintEventArgs e) { b_gfx.Render(e.Graphics); }
		protected override void OnPaintBackground(PaintEventArgs pevent) { DoDraw(true); }
		#endregion

		protected override void OnResize(EventArgs e) { DoDraw(true); }
		public override bool PreProcessMessage(ref Message wm)
		{
			try{
				switch (wm.Msg)
			{
				case (int)wm_events.WM_MOUSEWHEEL :
					if (wm.WParam.ToString("X")==0xFF880000.ToString("X")) this.OnMouseClick(new MouseEventArgs(MouseButtons.Middle,13,0,0,0));
					if (wm.WParam==(IntPtr)0x780000) this.OnMouseClick(new MouseEventArgs(MouseButtons.Middle,12,0,0,0));
					break;
			}
			} catch{
			}
			return base.PreProcessMessage(ref wm);
		}
	}
}
