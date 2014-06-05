/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Windows.Forms;
using Drawing;

namespace efx.Forms.Controls
{
	////////////////////////////////////////
	// 
	public class MovableWindowUtil
	{
		Control control;
		////////////////////////////////////////
		// 
		public HPoint MouseLocation=HPoint.Empty,DownLocation = HPoint.Empty;
		bool IsDown = false, IsDragable = true;
		////////////////////////////////////////
		// 
		public HPoint ClientHPoint { get { return PointToClient(Control.MousePosition); } }
		public HPoint Position { get { return PointToScreen(ClientHPoint-DownLocation); } }
		public HPoint ControlPosition { get { return control.Location; } set { control.Location = value; } }
		////////////////////////////////////////
		// 
		internal HPoint PointToClient(HPoint point) { return control.PointToClient(point); }
		internal HPoint PointToScreen(HPoint point) { return control.PointToScreen(point); }
		////////////////////////////////////////
		// 
		void MouseDown(object sender, MouseEventArgs args) { if (!IsDragable) return; DownLocation = ClientHPoint; IsDown = true; }
		void MouseUp(object sender, MouseEventArgs args) { if (!IsDragable) return; IsDown = false; DownLocation = HPoint.Empty; }
		void MouseMove(object sender, MouseEventArgs args) { if ((!IsDragable) || (DownLocation==HPoint.Empty)) return; Move(); }
		////////////////////////////////////////
		// 
		void Move() { if (IsDown) ControlPosition = Position; }

		internal virtual void AttachEvents()
		{
			control.MouseDown += new MouseEventHandler(MouseDown);
			control.MouseUp += new MouseEventHandler(MouseUp);
			control.MouseMove += new MouseEventHandler(MouseMove);
		}
		internal virtual void DetachEvents()
		{
			control.MouseDown -= new MouseEventHandler(MouseDown);
			control.MouseUp -= new MouseEventHandler(MouseUp);
			control.MouseMove -= new MouseEventHandler(MouseMove);
		}
		////////////////////////////////////////
		// 
		public MovableWindowUtil(Control ctl) { control = ctl; AttachEvents(); }
	}
}
