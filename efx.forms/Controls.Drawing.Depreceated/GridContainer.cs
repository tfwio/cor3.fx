/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Drawing;
using System.Windows.Forms;

using Drawing.Render;
using Drawing.Render.Custom;
using sndlib;

namespace Drawing.Forms.Controls
{

	public class GridContainer : GraphicContainer
	{
		virtual public IGridRenderer Renderer { get { return new DefaultGridRenderer(); } set {  } }

		public const int def_pixels_per_quarter = 4;
		internal int px_perQuarter = def_pixels_per_quarter;
		public int pixels_per_quarter { get { return px_perQuarter; } set { px_perQuarter=value; } }
		public int pixels_per_note { get { return (int)(pixels_per_quarter*post_scale); } }
		public int pixels_per_bar { get { return (int)(pixels_per_note*post_scale); } }
		public int pixels_per_measure { get { return (int)(pixels_per_bar*post_scale); } }
		public int pheight { get { return (int)((2)*post_scale); } }

		public const int c_left_off = 40, c_top_off = 16;
		public int OffsetLeft { get { return c_left_off; } }

		public double zoom = 1;
		public double post_scale = 6;

		NoteNumbers smule = new NoteNumbers();
		internal string[] Notes { get {
				string[] iv = new string[128];
				for (int i=0; i < iv.Length; i++) iv[i] = string.Format("{0}:{1}",GetOctave(i),smule[i]);
				return iv; } }

		string[] itemLabels;
		virtual public string[] ItemLabels { get { return itemLabels; } set { itemLabels=value; } }
		int GetOctave(int notenum) { return (int)(notenum/12); }

		public GridContainer() : base() { Initialize(); }
		public GridContainer(GraphicContainer container) : base(container) { Initialize(); }

		virtual public void Initialize() { ItemLabels = Notes; }

		#region \ void DoPaint \
		public override void DoPaint(Control ctl, Graphics gfx)
		{
			try {
				Pen p = new Pen(new SolidBrush(Color.Gray),1f);
				gfx.Clear(Color.White);
				HPoint offsss = new HPoint(c_left_off,c_top_off);
				HPoint siz2 = ClientSize;
				HPoint sub = new HPoint(c_left_off,c_top_off);
				siz2 -= sub;
				Rectangle rct = new Rectangle(offsss,siz2);
				Renderer.DrawBox(gfx,rct,Color.Red,8);
				Renderer.RenderVLine(gfx,rct,pheight,Color.Black);
				Renderer.RenderVLine(gfx,rct,pheight*12,Color.FromArgb(0,127,255));
				Renderer.RenderHLine(gfx,rct,pixels_per_quarter,Color.Gray);
				Renderer.RenderHLine(gfx,rct,pixels_per_note,Color.Red);
			b_gfx.Render(gfx);
			p.Dispose();
			} catch {/*return;*/}
		}
		#endregion
	}

}
