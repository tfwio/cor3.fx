/** tfw * 4/21/2008.9:01 AM **/

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace efx.Forms.Controls
{

	public delegate void NumberChanged(float number);
	/*public class ToolStripNumberManager : ObjectManager<ToolStripTextBox>
	{
		internal const string def_strfmt = "{0:d3}";
		internal const float
			_default = 0,
			def_min = 0,
			def_max = 255;
		//
		public event NumberChanged NumberChange;
		//
		internal string strfmt = def_strfmt;
		internal Drawing.HPoint pos_down,pos_move,pos_prev;
		internal MouseButtons ButtonFilter = MouseButtons.Left;
		internal bool dwn;
		internal float wedgel = 10, wedges=100;
		internal float min = def_min,max=def_max;
		internal float? _value = _default;
		//./////////////////////////////////////////////////////////////////////
		public float? Value
		{
			get {
				try { return _value; } catch { Text = ((float)_value.Value).ToString(strfmt); }
				return _value;
			}
			set
			{
				_value=value;
				if (_value > max) _value = max;
				if (_value < min) _value = min;
				Text = ((float)_value).ToString(strfmt); DoNumChange((float)_value.Value);
			}
		}
		public float Min {get{return min;}set{min=value;}}
		public float Max {get{return max;}set{max=value;}}

		internal void DoNumChange(float val){ if(NumberChange!=null) NumberChange(val); }
		virtual public void NumberC(float val){  }
		
		public ToolStripNumberManager(ToolStripTextBoxNumber ctl) : base(ctl,true)
		{
			
		}
	}*/
	public class ToolStripTextBoxNumber : System.Windows.Forms.ToolStripTextBox
	{
		internal const string def_strfmt = "{0:d3}";
		internal const float _default = 0, def_min = 0, def_max = 255;
	
		internal string strfmt = def_strfmt;
		internal Drawing.HPoint pos_down,pos_move,pos_prev;
		internal MouseButtons ButtonFilter = MouseButtons.Left;
		internal bool dwn;
		internal float wedgel = 10, wedges=100;
		internal float min = def_min,max=def_max;
	
		#region ' float? Value '
		internal float? _value = _default;
		public float? Value
		{
			get {
				try { return _value; } catch { Text = ((float)_value).ToString(strfmt); }
				return _value;
			}
			set
			{
				_value=value;
				if (_value > max) _value = max;
				if (_value < min) _value = min;
				Text = ((float)_value).ToString(strfmt); DoNumChange((float)_value);
			}
		}
		#endregion
	
		public float Min {get{return min;}set{min=value;}}
		public float Max {get{return max;}set{max=value;}}
	
		public event NumberChanged NumberChange;
		internal void DoNumChange(float val){ if(NumberChange!=null) NumberChange(val); }
		virtual public void NumberC(float val){  }
	
		public ToolStripTextBoxNumber() : base() { NumberChange += NumberC; Value = _default; }
		public ToolStripTextBoxNumber(string name) : base(name) { NumberChange += NumberC; Value = _default; }
		public ToolStripTextBoxNumber(string name, float val) : this(name) { Value = val; }
		public ToolStripTextBoxNumber(string name, float nmin, float nmax, float val) : this(name) { Value = val; min = nmin; max = nmax; }
		public ToolStripTextBoxNumber(
			string name, float nmin, float nmax, float val,
			float wl, float ws, string fmt, System.Drawing.Size s, string tt)
			: this(name,val,nmin,nmax)
		{
			this.BorderStyle = BorderStyle.None;
			strfmt = fmt; wedges = ws; wedgel = wl;
			if (s!=null) AutoSize = false;
			Size = s;  ToolTipText = tt;
			NumberChange += NumberC;
			Value = val;
		}
	
		public ToolStripTextBoxNumber(string name, float val, EventHandler e) : base(name) { if (e!=null) Click += e; NumberChange += NumberC; Value = val; }
	
		#region ' void OnMouseMove '
		protected override void OnMouseMove(MouseEventArgs e)
		{
			pos_move = new Drawing.HPoint(e.X,e.Y);
			switch (e.Button)
			{
				case MouseButtons.Left:
					if ( dwn & ( pos_move != null ) )
					{
						Drawing.HPoint x = pos_prev-pos_move;
						Value += ( ( x * ( 1f/ wedgel ) ) as Drawing.HPoint).Y*.2f;
						pos_prev = pos_move;
					}
					else pos_down = null;
					break;
			}
			base.OnMouseMove(e);
		}
		#endregion
		#region ' void OnMouseDown '
		protected override void OnMouseDown(MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left: pos_down = new Drawing.HPoint(e.X,e.Y); pos_prev = pos_down; break;
			}
			Global.stat("do");
			dwn = true;
			base.OnMouseDown(e);
		}
		#endregion
		#region ' void OnMouseUp '
		protected override void OnMouseUp(MouseEventArgs e) { switch (e.Button) { case MouseButtons.Left: dwn=false; break; } base.OnMouseUp(e); }
		#endregion
		#region ' void OnTextChanged '
		protected override void OnTextChanged(EventArgs e) { try { _value = float.Parse( Text ); } catch { _value = _default; } base.OnTextChanged(e); }
		#endregion
	
	}
}
