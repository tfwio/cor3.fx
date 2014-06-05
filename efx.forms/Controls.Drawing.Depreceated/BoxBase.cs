/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Drawing;
using Drawing.Render;

namespace Drawing.Forms.Controls
{
	public class BoxBase : GraphicContainer
	{
		#region Variables
		HPoint
			item = new HPoint(32,32),
			textOffset = new HPoint(4,0),
			captionTextOffset = new HPoint(),
			glyphOffset = new HPoint(48,0),
			offset = new HPoint(0,0),
			minimumValue = new HPoint(0,0),
			maximumValue = new HPoint(255,255),
			dimensions = new HPoint(0,0);
		[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
		public HPoint Item { get { return item; } set { item = value; } }
		[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
		public HPoint TextOffset { get { return textOffset; } set { textOffset = value; DoDraw(true); } }
		[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
		public HPoint CaptionTextOffset { get { return captionTextOffset; } set { captionTextOffset = value; DoDraw(true); } }
		[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
		public HPoint GlyphOffset { get { return glyphOffset; } set { glyphOffset = value; DoDraw(true); } }
		[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
		public HPoint Offset { get { return offset; } set { offset = value; DoDraw(true); } }
		[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
		public HPoint MinimumValue { get { return minimumValue; } set { minimumValue = value; } }
		[TypeConverterAttribute(typeof(ExpandableObjectConverter))]
		public HPoint MaximumValue { get { return maximumValue; } set { maximumValue = value; } }
		public HPoint Dimensions { get { return HClientSize/Item; } }
		// colors
		Color defaultItemColor=SystemColors.ActiveBorder,textHighlight=Color.Yellow,glyphHighlight=Color.Yellow,glyphColor=Color.Silver, glyphShadow=Color.Gray,lineColor=SystemColors.ButtonShadow,textColor=SystemColors.ButtonFace,textShadowColor=SystemColors.ControlDark;
		//
		public Color DefaultItemColor { get { return defaultItemColor; } set { defaultItemColor = value; } }
		public Color TextHighlight { get { return textHighlight; } set { textHighlight = value; DoDraw(true); } }
		public Color GlyphHighlight { get { return glyphHighlight; } set { glyphHighlight = value; DoDraw(true); } }
		public Color GlyphColor { get { return glyphColor; } set { glyphColor = value; DoDraw(true); } }
		public Color GlyphShadow { get { return glyphShadow; } set { glyphShadow = value; DoDraw(true); } }
		public Color LineColor { get { return lineColor; } set { lineColor = value; DoDraw(true); } }
		public Color TextColor { get { return textColor; } set { textColor = value; DoDraw(true); } }
		public Color TextShadowColor { get { return textShadowColor; } set { textShadowColor = value; DoDraw(true); } }
		#endregion
		
		public BoxBase() : base() { }
	
		public override void DoPaint(Control ctl, Graphics gfx) { base.DoPaint(ctl, gfx); RenderGrid(gfx); }
		
		// more functions
		virtual public void DrawGlyph(Graphics gfx, HPoint hp, int M, int R)
		{
			Pen drawingpen = new Pen(GlyphColor,0.125f),shadow = new Pen(GlyphShadow,0.125f);
			DrawGlyph(shadow,gfx,hp+1,M,R);
			DrawGlyph(drawingpen,gfx,hp,M,R);
			drawingpen.Dispose();
			shadow.Dispose();
		}
		virtual public void DrawGlyph(Pen drawingpen, Graphics gfx, HPoint hp, int M, int R) { Circle.DoCircle(gfx,drawingpen,hp,M,R); }
		virtual public void DrawText(Graphics gfx, string format, object text, HPoint pos)
		{
			SolidBrush sb = new SolidBrush(this.TextColor);
			SolidBrush sb2 = new SolidBrush(this.TextShadowColor);
			HPoint shade = pos+1;
			gfx.DrawString(string.Format(format,text),Font,sb2,TextOffset.X+pos.X+1,pos.Y+1);
			gfx.DrawString(string.Format(format,text),Font,sb,TextOffset.X+shade.X,shade.Y);
			gfx.DrawString("Something",Font,sb2,CaptionTextOffset.X+pos.X+1,pos.Y+1);
			gfx.DrawString("Something",Font,sb,CaptionTextOffset.X+shade.X,shade.Y);
			sb.Dispose();
			sb2.Dispose();
		}
		virtual public void RenderGrid(Graphics gfx)
		{
			gfx.Clear(BackColor);
			if (LayoutMode== PaneLayout.Vertical) for (float i = 0; i < Dimensions.Y+1; i++)
			{
				int offs = (int)(i*Item.Y);
				Pen dp = new Pen(LineColor,.125f);
				gfx.DrawLine(dp,0,offs,ClientSize.Width,offs);
				if (i+Offset.Y > MaximumValue.Y || i+Offset.Y < MinimumValue.Y) continue;
				DrawText(gfx,"{0:00#}",i+Offset.Y+1,new HPoint(TextOffset.X,(offs-FontHalfHeight+(Item.Y*.5f))));
				DrawGlyph(gfx,new HPoint(GlyphOffset.X,(float)(offs+(Item.Y*.5))),4,(int)(Item.Y*.25));
				DrawGlyph(gfx,new HPoint(GlyphOffset.X,(float)(offs+(Item.Y*.5))),4,(int)(Item.Y*.125));
				DrawGlyph(gfx,new HPoint(GlyphOffset.X,(float)(offs+(Item.Y*.5))),4,(int)(Item.Y*.5));
				//gfx.DrawString((i+ScalarOffset).ToString("00#"),Font,sb,DefaultTextOffsetX,(float)(offs-(ItemLength*.5)-FontHalfHeight));
				//if (LayoutMode==PaneLayout.Horizontal) gfx.DrawLine(dp,offs,0,offs,ClientSize.Height)
				dp.Dispose();
			}
	
		}
	
		#region Designer
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) { if (components != null) { components.Dispose(); } }
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		public override void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// BoxBase
			// 
			this.Name = "BoxBase";
			this.Size = new System.Drawing.Size(237, 313);
			this.ResumeLayout(false);
		}
		#endregion
	}
}
