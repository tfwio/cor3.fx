/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Windows.Forms;
using Drawing;

namespace efx.Forms.Controls
{
	public class MovableDlg : efx.Forms.BasicForm
	{
		public bool IsDragable = true;
		bool IsDown=false;

		public HPoint mouseLocation=HPoint.Empty,downLocation = HPoint.Empty;
		virtual public HPoint ClientHPoint { get { return PointToClient(MousePosition); } }
		virtual public HPoint MouseLocation { get { return mouseLocation; } set { mouseLocation=value; } }
		virtual public HPoint DownLocation { get { return downLocation; } set { DownLocation=value; } }

		public MovableDlg() : base() { IsDown = false; }

		public void domove(MouseEventArgs e) { OnMouseMove(e); }
		public void dodown(MouseEventArgs e) { OnMouseDown(e); }
		public void doup(MouseEventArgs e) { OnMouseUp(e); }

		protected override void OnMouseMove(MouseEventArgs e)
		{
			MouseLocation = PointToClient(MousePosition);//
			base.OnMouseMove(e);
			if (!IsDragable) {base.OnMouseMove(e); return;}
			if (DownLocation==HPoint.Empty) return;
			if (IsDown) { Location = this.PointToScreen(ClientHPoint-DownLocation); }
		}
		protected override void OnMouseUp(MouseEventArgs e) { DownLocation = null; if (!IsDragable) { base.OnMouseUp(e); return; } IsDown = false; base.OnMouseUp(e); }
		protected override void OnMouseDown(MouseEventArgs e) { if (!IsDragable) {base.OnMouseDown(e); return;} DownLocation = PointToClient(MousePosition); IsDown = true; base.OnMouseDown(e); }
	}
}
