/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Drawing.Render;
using efx;
using iface;
using w32;

namespace Drawing.Forms.Controls
{
	public abstract class PaneBase : GraphicContainer, IApi<BoxBase.PaneLayout>
	{
		const uint MouseWheelUp = 0xff880000u;
		const uint MouseWheelDown = (0x780000);
		const GraphicContainer.PaneLayout defaultLayout = GraphicContainer.PaneLayout.Vertical;

		List<List<string>> ItemCollection = new List<List<string>>();
		Dictionary<string, Header> Headers = new Dictionary<string, Header>();

		HPoint
			_min = new HPoint(0, 0),
			_max = new HPoint(20, 6),
			_offset = new HPoint(0, 0),
			_glyphOffset = new HPoint(48, 0),
			_textOffset = new HPoint(0, 32),
			_captionOffset = new HPoint(0, 32),
			_item = new HPoint(48, 48);

		IPaneRenderer renderer;
		virtual public IPaneRenderer Renderer { get { return renderer; } }

		#region Props
		[Category("Bounds"), TypeConverter(typeof(ExpandableObjectConverter))]
		public HPoint Min { get { return _min; } set { _min = value; } }
		[Category("Bounds"), TypeConverter(typeof(ExpandableObjectConverter))]
		public HPoint Max { get { return /*_max*/new HPoint(ItemCollection.Count, ItemCollection.Count); } }

		[Category("Misc"), TypeConverter(typeof(ExpandableObjectConverter))]
		public HPoint Offset { get { return _offset; } set { _offset = value; DoDraw(true); } }

		[Category("Text-Format"), TypeConverter(typeof(ExpandableObjectConverter))]
		public HPoint GlyphOffset { get { return _glyphOffset; } set { _glyphOffset = value; DoDraw(true); } }
		[Category("Text-Format"), TypeConverter(typeof(ExpandableObjectConverter))]
		public HPoint TextOffset { get { return _textOffset; } set { _textOffset = value; DoDraw(true); } }  
		[Category("Text-Format"), TypeConverter(typeof(ExpandableObjectConverter))]
		public HPoint CaptionOffset { get { return _captionOffset; } set { _captionOffset = value; DoDraw(true); } }

		[Category("Bounds"), TypeConverter(typeof(ExpandableObjectConverter))]
		public HPoint ItemSize {
			get { return _item; }
			set { _item = value; if (value.Y < 2) _item.Y = 2;  if (value.X < 2) _item.X = 2;  DoDraw(true); }
		}

		public HPoint Scalar { get { return HClientSize / _item; } }
		public HPoint ItemMax { get { return _item / HClientSize; } }
		public IList<Header> HeaderCollection
		{
			get
			{
				List<Header> hdrs = new List<Header>();
				foreach (KeyValuePair<string, Header> kvp in Headers) hdrs.Add(kvp.Value);
				return hdrs;
			}
		}
		#endregion
	
		#region HeaderItems
		public void RemoveHeader(string name) { if (Headers.ContainsKey(name)) Headers.Remove(name);  }
		public void AddHeader(string name) { Headers.Add(name, new Header(this, name)); }
		public void InitCols() { AddHeader("###"); AddHeader("name"); AddHeader("boot"); }
		#endregion

		#region InnerItems
		public void AddItem(params string[] val)
		{
			List<string> newitem = new List<string>(val);
			int i = newitem.Count;
			while (i++ < Headers.Count) newitem.Add(string.Empty);
			ItemCollection.Add(newitem);
		}
		public new List<string> this[int Index]
		{
			get { return ItemCollection[Index]; }
			set { ItemCollection[Index] = new List<string>(value); }
		}
		#endregion

		public virtual void Call(PaneLayout api, params object[] data) { }
		public virtual void Call(DefaultAPI api, params object[] data) { }
		internal bool ShftKey = false, CtrlKey = false;
	
		#region Overrides
		protected override void OnKeyDown(KeyEventArgs e)
		{
			CtrlKey = e.Control;
			ShftKey = e.Shift;
			base.OnKeyDown(e);
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			CtrlKey = false;
			ShftKey = false;
			base.OnKeyUp(e);
		}
		protected override void WndProc(ref Message wm)
		{
			switch (wm.Msg) {
				case (int)wm_events.WM_MOUSEWHEEL:
					HPoint newitem = new HPoint(0, 0);
					if (CtrlKey) {
						if ((int)wm.WParam > (int)IntPtr.Zero) {
							Global.cstat(System.ConsoleColor.Yellow, "{1:X6},{0}", _item, wm.WParam);
							newitem = new HPoint(ItemSize.X, ItemSize.Y + 1);
							ItemSize = newitem;
						} else if ((int)wm.WParam < (int)IntPtr.Zero) {
							Global.cstat(System.ConsoleColor.Yellow, "{1:X6},{0}", _item, wm.WParam);
							newitem = new HPoint(ItemSize.X, ItemSize.Y - 1);
							ItemSize = newitem;
						}
						base.DoDraw(true);
						base.WndProc(ref wm);
						return;
					}
	
					if (ShftKey) {
						Global.stat("{1:h},{0}", _item, wm.WParam);
					}
	
					if (LayoutMode == PaneLayout.Horizontal) {
						if (wm.WParam.ToString("X") == MouseWheelUp.ToString("X")) Offset.X -= MouseWheelScrollAmount.X; 						else if (wm.WParam == (IntPtr)MouseWheelDown)
						Offset.X += MouseWheelScrollAmount.X;
						DoDraw(true);
						//	if (wm.WParam.ToString("X")==0xFF880000.ToString("X")) Offset.X-=MouseWheelScrollAmount;
						//	else if (wm.WParam==(IntPtr)0x780000) Offset.X+=MouseWheelScrollAmount;
					}
					if (LayoutMode == PaneLayout.Vertical) {
						if (wm.WParam.ToString("X") == MouseWheelUp.ToString("X")) Offset.Y -= MouseWheelScrollAmount.Y; 						else if (wm.WParam == (IntPtr)MouseWheelDown)
							Offset.Y += MouseWheelScrollAmount.Y;
						//	if (wm.WParam.ToString("X")==0xFF880000.ToString("X")) Offset.Y-=MouseWheelScrollAmount;
						//	else if (wm.WParam==(IntPtr)0x780000) Offset.Y+=MouseWheelScrollAmount;
						DoDraw(true);
					}
	
					break;
			}
			base.WndProc(ref wm);
		}
		#endregion
	
		public PaneBase() : base()
		{
			renderer = new PaneRenderer(this); InitCols();
		}
		public PaneBase(PaneLayout mode) : base()
		{
			renderer = new PaneRenderer(this);
			InitCols();
		}
	
		public override void DoPaint(Control ctl, Graphics gfx)
		{
			try { renderer.RenderGrid(gfx); } catch {}
			b_gfx.Render();
		}

		#region ' Header Class '
				public class Header
		{
			string text = string.Empty;
			int size = 200;
			PaneBase parent;
			public int Size {
				get { return size; }
				set { size = value; }
			}
			public string Text {
				get { return text; }
				set { text = value; }
			}
			public PaneBase Parent {
				get { return parent; }
				set { parent = value; }
			}
			public Header(PaneBase par, string title)
			{
				Parent = par;
				text = title;
			}
			public void Measure()
			{
				if (parent.LayoutMode == PaneLayout.Horizontal)
					size = System.Windows.Forms.TextRenderer.MeasureText(text, parent.Font).Height;
				else if (parent.LayoutMode == PaneLayout.Vertical)
					size = System.Windows.Forms.TextRenderer.MeasureText(text, parent.Font).Width;
			}
		}

		#endregion
	}
}
