/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using System.Cor3;
using System.Drawing;
using System.Windows.Forms;

namespace drawing.text
{

	public class TxtLayoutManager : object_manager<TxtControl>
	{

		public VScrollBar vscroll;
		protected int _overscroll = 0, _underscroll = 0;
		/// The number of lines that can be skipped before the first visible line
		public int Overscroll	{ get { return _overscroll; } set { _overscroll = value; } }
		/// The number of (empty) lines beyond the maximum number of rows avaliable
		public int Underscroll	{ get { return _underscroll; } set { _underscroll = value; } }

		public Rectangle PaddedRect
		{
			get { return new Rectangle( Client.Padding.Left, Client.Padding.Top, Client.Width - Client.Padding.Horizontal-1, Client.Height - Client.Padding.Vertical-1); }
		}

		internal int CalculatedLineHeight
		{
			get {
				int ival = 0;
				using (Graphics fx = Client.CreateGraphics())
					ival = (int)Client.Font.GetHeight();
				return ival;
			}
		}
		public int LinesMaximum { get { return (int)(PaddedRect.Height/CalculatedLineHeight); } }

		void eResize(object sender, EventArgs e) { Measure(); }
		void Measure() { if (vscroll!=null) vscroll.LargeChange = LinesMaximum; }

		public override void AddEvents()
		{
			base.AddEvents();
			Client.Resize += eResize;
		}

		public TxtLayoutManager(TxtControl ctl, VScrollBar vs) : base(ctl)
		{
			vscroll = vs;
		}
		public TxtLayoutManager(TxtControl ctl) : this(ctl,null) {  }
	}
}
