/** tfw * 4/21/2008.9:01 AM **/

using System;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class NumLabel : System.Windows.Forms.Label
	{
		public NumLabel() : base()
		{
			Value = _default;
		}
		public NumLabel(float val) : base()
		{
			Value = val;
		}
		#region automation
		public string strfmt = "##0.0";
		internal const float _default = 0;
		internal MouseButtons ButtonFilter = MouseButtons.Left;
		internal Drawing.HPoint pos_down,pos_move,pos_prev;
		internal bool dwn;
		internal byte wedgel = 10, wedges=100;
		float? _value = _default;
		[System.ComponentModel.BrowsableAttribute(false)]
		public float? Value
		{
			get {try { return _value; } catch { Text = ((float)_value).ToString("##0.0");} return Value;}
			set { _value=value; Text = ((float)_value).ToString("##0.0");}
		}
		public override bool PreProcessMessage(ref Message msg)
		{
			return base.PreProcessMessage(ref msg);
		}
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnMouseDown(MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left: pos_down = PointToClient(MousePosition); pos_prev = pos_down; break;
			}
			Global.stat("do");
			dwn = true;
			base.OnMouseDown(e);
		}
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			pos_move = new Drawing.HPoint(e.X,e.Y);
			switch (e.Button)
			{
				case MouseButtons.Left:
					if (dwn&pos_move!=null)
					{
						Drawing.HPoint x = -pos_move+pos_prev;
						Value+=(x*(1f/wedgel) as Drawing.HPoint).Y*.2f;
						Global.stat("{0:g}",(float)Value);
						pos_prev = pos_move;
					}
					else pos_down = null;
					break;
			}
			base.OnMouseMove(e);
		}
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnMouseUp(MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left: dwn=false; break;
			}
			Global.stat("up");
			base.OnMouseUp(e);
		}
		protected override void OnTextChanged(EventArgs e)
		{
			try {
			_value = float.Parse( Text );
			} catch {
			_value = _default;
			}
			base.OnTextChanged(e);
		}
		#endregion
	}
}
