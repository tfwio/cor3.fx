/* oOo * 12/9/2007 : 6:29 AM */

/* oOo * 12/7/2007 : 8:39 AM */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using efx;
using Text;
using Text.TextPad;
using w32;

namespace Text.TextPad
{
	
	#if DEBUG
	/// <summary>
	/// this is an old concept.
	/// leave it at that?
	/// </summary>
	#endif
	public class TextPanelBase : Control, ITextCtl
	{
	    public TextPanelBase() : base()
	    {
			G();
			MNumbers = new LineMargin(this,40);
			PaintLine += LPaint;
		//	caretTimer = new System.Windows.Forms.Timer();
		//	caretTimer.Tick += DrawCaret;
		//	caretTimer.Interval = SystemInformation.CaretBlinkTime;
		//	caretTimer.Start();
		//	DoDraw(true);
		}
		protected override void OnEnter(EventArgs e) { if (!Focused) Focus(); base.OnEnter(e); }
		protected override void OnClick(EventArgs e) { if (!Focused) Focus(); base.OnClick(e); }
	    protected override void WndProc(ref Message m)
		{
			switch (m.Msg){
				case (int)wm_events.WM_MOUSEWHEEL:
					if ((long)m.WParam > 0) OnLineScroll(lineOffset-=mouseWheelAmt);
					else OnLineScroll(lineOffset+=mouseWheelAmt);
					return;
				case (int)wm_events.WM_INPUT:
					this.Parent.Text = m.Msg.ToString("X8");
					return;
			}
			base.WndProc(ref m);
		}

	    // Main Drawing Method
		#region DoDraw
		public virtual void DoDraw() {
			DoDraw(false);
		}

		public virtual void DoDraw(bool cls) {
				G();
			if (m_gfx==null) return;
			if (cls){
//				m_gfx.SmoothingMode = SmoothingMode.HighSpeed;
//				m_gfx.InterpolationMode = InterpolationMode.Default;
			}
			// draw margin if it's visible
			m_gfx.Clear(this.bgColor);
			ControlPaint.DrawBorder3D( m_gfx, o_rect, border3D, Border3DSide.All );
			m_gfx.FillRectangle( new SolidBrush(bgColor), c_rect );
			// this needs to be repaired to match line nums
			Image mx = mNumbers.DUpdate(this);
			if (mNumbers.IsVisible && mx !=null) m_gfx.DrawImage(mx,0,0);
			//
			PaintL(new LinePaintEvent(m_gfx,lineOffset,LinesVisible));
			b_gfx.Render();
		}
		#endregion

		#region Properties
		// Buffered Graphics
		#region Graphics Object(s)
		public Graphics m_gfx{
			get{ if (b_gfx!=null) return b_gfx.Graphics; return null; } // main graphics object
		}
		BufferedGraphics b_gfx;
		BufferedGraphicsContext c_gfx;
		#endregion

		// Graphics Initialization
		#region G()
		/// <summary>reloads the main graphics</summary>
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
		#region LineCalc
		void LineCalc(){ LineCalc(false); }
		void LineCalc(bool scrolling){
			if (!scrolling) LinesVisible = ClientSize.Height / Font.Height;
			lineBottom = lineOffset + LinesVisible;
		}
		#endregion

		// caret
		#region CaretTimer/Speed
		int caretTicks = SystemInformation.CaretBlinkTime;
		[
			Category("Caret Info"),
			Description("Default value is defined by the system.")
		]
		public int CaretTimeout {
			get { return caretTicks; }
			set { caretTicks = value; }
		}
		System.Windows.Forms.Timer caretTimer = null;
		[Browsable(false)]
		public System.Windows.Forms.Timer CaretSpeed {
			get { return caretTimer; }
		}
		#endregion

		// Control Colors
		#region Border3DStyle
		Border3DStyle border3D = Border3DStyle.Bump;
		[
			Category("Appearance"),
			DefaultValue(Border3DStyle.Bump)
		]
		public Border3DStyle Border3D {
			get { return border3D; }
			set { border3D = value; DoDraw(); }
		}
		#endregion
		#region ForeColor
		Color fgColor = SystemColors.WindowText;
		public override Color ForeColor {
			get { return fgColor; }
			set { fgColor = value; }
		}
		#endregion
		#region BackColor
		Color bgColor = SystemColors.Window;
		public override Color BackColor {
			get { return bgColor; }
			set { bgColor = value; }
		}
		#endregion
		#region SelectionFg
		Color selectionFg = SystemColors.HighlightText;
		[Category("Appearance")]
		public Color SelectionFg {
			get { return selectionFg; }
			set { selectionFg = value; }
		}
		#endregion
		#region SelectionBg
		Color selectionBg = SystemColors.Highlight;
		[Category("Appearance")]
		public Color SelectionBg {
			get { return selectionBg; }
			set { selectionBg = value; }
		}
		#endregion

		// Mouse
		#region MousePosition
		// FIXME: NO!! (MousePosition) duplicate/warning
		[Browsable(false)]
		public new Point MousePosition {
			get {
				return Point.Empty;
			}
		}
		#endregion
		#region MouseWheelAmt
		int mouseWheelAmt = System.Windows.Forms.SystemInformation.MouseWheelScrollLines;
		[Category("Mouse")]
		public int MouseWheelAmt {
			get { return mouseWheelAmt; }
			set { mouseWheelAmt = value; }
		}
		#endregion

		// Line Measurements?
		#region LinesVisible
		int maxLinesVisible;
		[Browsable(false)]
		public int LinesVisible {
			get { return maxLinesVisible; }
			set { maxLinesVisible = value; }
		}
		#endregion
		#region LineOffset
		int lineOffset = 0;
		[Browsable(false)]
		public int LineOffset {
			get { return lineOffset; }
			set { OnLineScroll(lineOffset = value); }
		}
		int lineBottom = -1;
		[Browsable(false)]
		public int LineBottom {
			get { return lineBottom; }
			set { lineBottom = value; }
		}
		#endregion
		#region LinesAvail
		/// <summary>Calculated when the buffer is loaded.</summary>
		/// <remarks>(sbuffer.lindex.Count)</remarks>
		int a_lines = -1;
		[Browsable(false)]
		/// <summary>Calculated when the buffer is loaded.</summary>
		/// <remarks>(sbuffer.lindex.Count)</remarks>
		public int LinesAvail {
			get { return a_lines; }
			set { a_lines = value; }
		}
		#endregion

		// Line-Numbers Margin
		#region Numbers Margin
		LineMargin mNumbers;
		[Browsable(false)]
		public LineMargin MNumbers {
			get { return mNumbers; } set { mNumbers = value; }
		}
		#endregion

		#region WordWrap
		bool wwrap = false;
		[
			Category("Appearance"),
			DefaultValueAttribute(false)
		]
		public bool WordWrap {
			get
			{
				return wwrap;
			}
			set
			{
				if (value==!true) strFmt.FormatFlags =
					StringFormatFlags.NoWrap |
					StringFormatFlags.DisplayFormatControl |
					StringFormatFlags.NoFontFallback;
				else strFmt.FormatFlags = 
					StringFormatFlags.DisplayFormatControl |
					StringFormatFlags.NoFontFallback;
					wwrap = value;
			}
		}
		#endregion

		#region StringFormat StrFmt (Drawing.Text)
		StringFormat strFmt = new StringFormat(
				StringFormatFlags.NoWrap |
				StringFormatFlags.DisplayFormatControl |
				StringFormatFlags.NoFontFallback | 0
		);
		public StringFormat StrFmt {
			get {
				TrySetTabStops();
				WordWrap = wwrap; return strFmt;  }
			set { strFmt = value; TrySetTabStops(); }
		}
		#endregion
		// Measurements
		#region TabChars
		int tabChars = 4;
		public int TabChars {
			get { return tabChars; }
			set { tabChars = value; TrySetTabStops(); }
		}
		#endregion
		#region units,DrawingUnits
		GraphicsUnit units = GraphicsUnit.Pixel;
		public GraphicsUnit DrawingUnits {
			get { return units; }
			set { units = value; }
		}
		#endregion
		// Rectangles
		#region c_rect, o_rect
		public Rectangle c_rect{
			get {
				Rectangle trect = new Rectangle(
					Point.Empty,
					ClientRectangle.Size
				);
				if (mNumbers.IsVisible)
				{
					trect.Location = Point.Empty;
					trect.Inflate(-(int)mNumbers.Left,0);
				}
				return trect;
			}
		}
		int tpadding = 2;
		public Rectangle o_rect{
			get {
				int pad = tpadding*2;
				Rectangle mrect = new Rectangle(
					c_rect.Location,
					c_rect.Size
				);
				mrect.Inflate(pad,pad);
				mrect.Offset(tpadding,tpadding);
				return mrect;
			}
		}
		#endregion

		#endregion

		void TrySetTabStops()
		{
			if (m_gfx!=null)
			{
				float[] tsts = new float[20];
				int wid = (int)m_gfx.MeasureString("".PadLeft(this.tabChars,'_'),Font).Width;
				for (int i=0; i<20;i++) tsts[i] = (float)(int)(wid);
				strFmt.SetTabStops(wid,tsts);
			}
		}
		
		// Events
		#region LineScrolling Event
		public event LineScroll LineScrolling;
		protected void OnLineScroll(int linenum){
			LineCalc(true);
			if (LineScrolling!=null) LineScrolling(linenum);
			DoDraw();
		}
		#endregion
		#region PaintL
		public event LinePaint PaintLine;
		virtual public void LPaint(LinePaintEvent lpe) {}
		virtual public void PaintL(LinePaintEvent le){ if (PaintLine!=null) PaintLine(le); }
		#endregion

		// Paint Overrides
		#region OnPaint
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnPaint(PaintEventArgs e) { DoDraw(true);  }
		#endregion
		#region OnResize
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnResize(EventArgs e)
		{
			LineCalc();
			DoDraw(true);
		}
		#endregion
		#region OnPaintBackground (nullified)
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnPaintBackground(PaintEventArgs pevent) {}
		#endregion

		// CaretTimer/Focus Overrides
		#region OnGotFocus (start caretTimer)
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnGotFocus(EventArgs e) {
			DoDraw(true);
			if (caretTimer!=null) caretTimer.Start();	// TODO:caretTimer (check me)
		}
		#endregion
		#region OnLostFocus (stops caretTimer)
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnLostFocus(EventArgs e)
		{
			if (caretTimer!=null) this.caretTimer.Stop();	// TODO:caretTimer (check me)
			//base.OnLostFocus(e);
		}
		#endregion
		#region Caret Drawing Virtual(tick handler)
		virtual public void DrawCaret(object sender, EventArgs e) { }
		#endregion

	}

}
