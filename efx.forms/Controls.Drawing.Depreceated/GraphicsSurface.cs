/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using Drawing.Events;
using Drawing.Render.Custom;
using efx;
using efx.Forms.Controls;

namespace Drawing.Forms.Controls
{
	public class GraphicsSurface : UserControlMouseTrack, ICustomPaint
	{
		#region ' GraphicsUnit Units '
		GraphicsUnit units = GraphicsUnit.Pixel;
		public GraphicsUnit Units { get { return units; } set { units = value; G(); } }
		#endregion
		#region ' TextRenderingHint RenderingHint '
		protected int textContrast=6;
		protected TextRenderingHint renderingHint = TextRenderingHint.AntiAliasGridFit;
		public TextRenderingHint RenderingHint { get { return renderingHint; } set { renderingHint = value; DoDraw(true); } }
		#endregion
		#region ' SmoothingMode Smoothing '
		protected SmoothingMode _smoothing = SmoothingMode.HighQuality;
		public SmoothingMode Smoothing { get {return _smoothing;} set { _smoothing = value; DoDraw(true);} }
		#endregion
		#region ' InterpolationMode Interpolation '
		protected InterpolationMode _interpolation = InterpolationMode.HighQualityBicubic;
		public InterpolationMode Interpolation { get {return _interpolation;} set { _interpolation = value; DoDraw(true);} }
		#endregion
		#region ' int TextContrast '
		public int TextContrast { get { return textContrast; } set { textContrast = value; DoDraw(true); } }
		#endregion
	
		#region ' TextFormatFlags TxtFmt '
		TextFormatFlags txtFmt = TextFormatFlags.Default;
		[TypeConverter(typeof(ExpandableObjectConverter))] public TextFormatFlags TxtFmt { get { return txtFmt; } set { txtFmt = value; } }
		#endregion
		#region ' float FontHalfHeight '
		[Browsable(false)] public float FontHalfHeight { get { return this.FontHeight/2; } }
		#endregion
	
		#region ' HPoint HClientSize '
		[Browsable(false)] virtual public HPoint HClientSize { get { return ClientSize; } }
		#endregion
		#region ' BufferedGraphicsContext '
		//
		[Browsable(false)] public Graphics m_gfx{ get{ if (b_gfx!=null) return b_gfx.Graphics; return null; } }
		[Browsable(false)] public BufferedGraphics b_gfx;
		internal BufferedGraphicsContext c_gfx;
		#endregion
	
		public GraphicsSurface() : base() { CPaint += DoPaint; }
	
		#region ' Graphics G() '
		public Graphics G() { return G(false); }
		public Graphics G(bool clear) {
			c_gfx = BufferedGraphicsManager.Current;
			if (ClientRectangle.Width > 0 && ClientRectangle.Height > 0) {
				c_gfx.MaximumBuffer = ClientSize;
				b_gfx = c_gfx.Allocate(CreateGraphics(),ClientRectangle);
				b_gfx.Graphics.PageUnit = units;
				if (clear) m_gfx.Clear(BackColor);
			}
			return m_gfx;
		}
		#endregion
		#region ' CustomPaint CPaint '
		[Category("DrawingEvents")] public event CustomPaint CPaint;
		#endregion
		#region ' void OnCPaint '
		virtual public void OnCPaint(Graphics gfx) { if (CPaint != null) CPaint(this, gfx); }
		#endregion
	
		#region ' void DoPaint '
		virtual public void DoPaint(Control ctl, Graphics gfx) { try { b_gfx.Render(gfx); } catch { /**/ } }
		#endregion
		#region ' void DoDraw '
		virtual public void DoDraw(bool cls) {
			G();
			if (m_gfx==null) return;
			if (cls){
				b_gfx.Graphics.SmoothingMode = Smoothing;
				b_gfx.Graphics.InterpolationMode = Interpolation;
				b_gfx.Graphics.PageUnit = units;
				b_gfx.Graphics.TextRenderingHint = RenderingHint;
				b_gfx.Graphics.TextContrast = TextContrast;
			}
			try { m_gfx.Clear(BackColor); } catch {return;}
			//ControlPaint.DrawBorder3D( m_gfx, o_rect, border3D, Border3DSide.All );
			//m_gfx.FillRectangle( new SolidBrush(bgColor), c_rect );
			OnCPaint(m_gfx);
			try { b_gfx.Render(); } catch { Global.stat("unkn buffer erro"); }
			Global.stat("GraphicContainer::DoDraw");
		}
		virtual public void DoDraw() { DoDraw(false); }
		#endregion
	
		public override HPoint MouseWheelScrollAmount { set { base.MouseWheelScrollAmount = value; DoDraw(true); } }
	
		#region ' void OnPaint '
		protected override void OnPaint(PaintEventArgs e) { try {b_gfx.Render(e.Graphics);}catch{}; }
		protected override void OnPaintBackground(PaintEventArgs pevent) { /*DoDraw(true);*/ }
		#endregion
		#region ' void OnResize '
		protected override void OnResize(EventArgs e) { DoDraw(true); }
		#endregion 
	
	}
}
