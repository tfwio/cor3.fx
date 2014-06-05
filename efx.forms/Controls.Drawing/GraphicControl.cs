/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Text;
using Drawing;
using efx;

namespace Drawing.Forms.Controls
{

	public class GraphicControl : UserControl /* , GraphicContainer, IGraphicControl*/
	{
		#region Properties
		public enum BackgroundStyle
		{
			/// <summary>Solid</summary>
			Default,
			Gradient,
			/// <summary>*todo</summary>
		}

		[Browsable(true),TypeConverter(typeof(ExpandableObjectConverter))]
		public Drawing.Forms.Controls.GraphicControl.BackgroundStyle BackStyle = BackgroundStyle.Gradient;

		HGradient bgrad = new HGradient(HGradient.Alignment.Vertical);
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public HGradient BackGradient { get { return bgrad; } set { bgrad=value; } }

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Rectangle Position { get { return new Rectangle(Location,Size); } }

		[Browsable(false)] public Brush BackgroundBrush { get { return (BackStyle==BackgroundStyle.Gradient)?BackGradient.GradientBrush:new SolidBrush(BackColor); } }
		#endregion

		public bool TrackMouse = true;
		public bool IsMouseDown = false;
		public HPoint MouseLocation;

		public GraphicControl() : base() { BackStyle=BackgroundStyle.Gradient; }
		public GraphicControl(HGradient dg) : base() { BackGradient = dg; }

		virtual public void Render(Graphics gfx)
		{
			
		}
		virtual protected void RenderBackground(Graphics gfx)
		{
			if (BackStyle==BackgroundStyle.Gradient) gfx.FillRectangle(BackgroundBrush,Position);
			else gfx.FillRectangle(BackgroundBrush,Position);
		}

		
		#region Overrides
		protected override void OnMouseMove(MouseEventArgs e) { if (Focused) MouseLocation = new HPoint(e.X,e.Y); base.OnMouseMove(e); }
		protected override void OnMouseUp(MouseEventArgs e) { IsMouseDown = false; base.OnMouseUp(e); }
		protected override void OnResize(EventArgs e) { base.OnResize(e); BackGradient.HSpread = (HPoint)ClientSize; RenderBackground(CreateGraphics()); }
		protected override void OnPaintBackground(PaintEventArgs e) { RenderBackground(e.Graphics); }
		#endregion
		#region Designer
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) { components.Dispose(); }
			}
			base.Dispose(disposing);
		}
		virtual public void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// GraphicControl
			// 
			this.Name = "GraphicControl";
			this.ResumeLayout(false);
		}
		#endregion

	}
}
