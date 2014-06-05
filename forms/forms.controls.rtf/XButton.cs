/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using Drawing.Render.Custom;

namespace efx.Forms.Controls.rtf
{
	public class XButton : IButton
	{
		ICustomPaint Obj;
		public enum Act { Default, Up, Down, }
	
		/// <summary>FontFam and FontSize are used to provide this</summary>
		int _width,_height,_top,_left;
		public int Width { get { return _width; } set { _width = value; } }
		public int Height { get { return _height; } set { _height = value; } }
		public int Top { get { return _top; } set { _top = value; } }
		public int Left { get { return _left; } set { _left = value; } }
	
		public Act _act;
		public Act CurAct { get { return _act; } set {
				_act = value;
//				(Obj as RulerPanelBase).DoDraw();
			} }

		string _title = "default";
		public string Title{ get { return _title; } set { _title = value; } }
	
		public PointF Mesaure(Graphics gfx, PointF Pos)
		{
			PointF mck = gfx.MeasureString(_sym,Font).ToPointF();
			PointF dck = new PointF((float)(mck.X*.5),(float)(mck.Y*.5));
			return dck;
		}
		public PointF Center(Graphics gfx, PointF Pos)
		{
			return new PointF((float)(Width*.5),(float)(Height*.5));
		}
	
		Hashtable Colors = new Hashtable();
		Hashtable Offsets = new Hashtable();
		public Color ColorDefault { get {return (Color)Colors[Act.Default];} }
		public Color ColorUp { get {return (Color)Colors[Act.Up];} }
		public Color ColorDown { get {return (Color)Colors[Act.Down];} }
	
		public PointF OffDefault { get {return (PointF)Offsets[Act.Default];} }
		public PointF OffUp { get {return (PointF)Offsets[Act.Up];} }
		public PointF OffDown { get {return (PointF)Offsets[Act.Down];} }
	
		Font _font; string _fam = "Arial"; float _fsiz = 11;
		public Font Font { get { if (_font==null) _font = new Font(FontFam,FontSize); return _font; } }
		public string FontFam { get { return _fam; } set { _fam = value; } }
		public float FontSize { get { return _fsiz; } set { _fsiz = value; } }

		string _sym = "T";
		public string FontSymbol { get { return _sym; } set { _sym = value; } }

		public XButton(ICustomPaint obj, string title, RectangleF coord)
		{
			Obj = obj;
			Width = (int)coord.Width;
			Height = (int)coord.Height;
			Left = (int)coord.X;
			Top = (int)coord.Y;
			Title = title;
			Colors = new Hashtable();
			Colors.Add(Act.Default,Color.FromArgb(0,127,255));
			Colors.Add(Act.Up,Color.FromArgb(0,255,255));
			Colors.Add(Act.Down,Color.FromArgb(0,0,0));
			Offsets.Add(Act.Default,new PointF(0,0));
			Offsets.Add(Act.Up,new PointF(0,0));
			Offsets.Add(Act.Down,new PointF(-2,-2));
			CurAct = Act.Default;
		}
	
		virtual public void HitTest(MouseButtons Buttons,PointF pt, Graphics gfx)
		{
			_act = Act.Default;
			switch (Buttons)
			{
				case MouseButtons.None:
					if ( (pt.X > Left && pt.X < Left+Width) &&  (pt.Y > Top && pt.Y < Top+Height)) CurAct = Act.Up;
					else CurAct = Act.Default;
					CallDraw(gfx);
					break;
				case MouseButtons.Left:
					if ((pt.X > Left && pt.X < Left+Width) && (pt.Y > Top && pt.Y < Top+Height)) CurAct = Act.Down;
					CallDraw(gfx);
					break;
			}
		}
		virtual public void CallDraw(Graphics gfx)
		{
			try
			{
				gfx.DrawString(
					Title+FontSymbol,
					Font,
					new SolidBrush((Color)Colors[CurAct]),
					(Obj as RulerPanelBase).MousePoint.X,
					(Obj as RulerPanelBase).MousePoint.Y
				);
			}
			catch
			{
				
			}
		}
	}
}
