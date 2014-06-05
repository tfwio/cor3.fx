/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace System.Cor3.Forms
{
	////////////////////////////////////////
	// 
	public class MovableWindowUtil
	{
		Control control;
		////////////////////////////////////////
		// 
		public FloatPoint MouseLocation=FloatPoint.Empty,DownLocation = FloatPoint.Empty;
		bool IsDown = false, IsDragable = true;
		////////////////////////////////////////
		// 
		public FloatPoint ClientHPoint { get { return PointToClient(Control.MousePosition); } }
		public FloatPoint Position { get { return PointToScreen(ClientHPoint-DownLocation); } }
		public FloatPoint ControlPosition { get { return control.Location; } set { control.Location = value; } }
		////////////////////////////////////////
		// 
		internal FloatPoint PointToClient(FloatPoint point) { return control.PointToClient(point); }
		internal FloatPoint PointToScreen(FloatPoint point) { return control.PointToScreen(point); }
		////////////////////////////////////////
		// 
		void MouseDown(object sender, MouseEventArgs args) { if (!IsDragable) return; DownLocation = ClientHPoint; IsDown = true; }
		void MouseUp(object sender, MouseEventArgs args) { if (!IsDragable) return; IsDown = false; DownLocation = FloatPoint.Empty; }
		void MouseMove(object sender, MouseEventArgs args) { if ((!IsDragable) || (DownLocation==FloatPoint.Empty)) return; Move(); }
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
