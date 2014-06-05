/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Windows.Forms;
using Drawing;
using efx.Forms.Managers;

namespace efx.Forms.Controls
{
	public class MovableDlgManager : ObjectManager<MovableDlg>
	{
		public bool IsDragable = true;
		bool IsDown=false;
		
		static public HPoint MousePosition { get { return Form.MousePosition; } }
		public HPoint ClientMousePosition { get { return Client.PointToClient(MousePosition); } }
		public HPoint ClientLocation { get { return Client.Location; } set { Client.Location = value; } }
		
		public HPoint mouseLocation=HPoint.Empty, downLocation = HPoint.Empty;
		virtual public HPoint MouseLocation { get { return mouseLocation; } set { mouseLocation=value; } }
		virtual public HPoint DownLocation { get { return downLocation; } set { downLocation=value; } }
		
		public void eMouseMove(object s, MouseEventArgs e)
		{
			if ((!IsDragable) || (DownLocation==null)) return;
			MouseLocation = ClientMousePosition;
			if (IsDown) ClientLocation = Client.PointToScreen(ClientMousePosition-DownLocation);
		}
		public void eMouseUp(object s, MouseEventArgs e)
		{
			DownLocation = null;
			if (!IsDragable) return;
			IsDown = false;
		}
		public void eMouseDown(object s, MouseEventArgs e)
		{
			if (!IsDragable) return;
			DownLocation = ClientMousePosition;
			IsDown = true;
		}

		const string status = "candrag:{0}, isdown:{1}, down:{2}, m:{3}";
		void print()
		{
			Global.cstat(ConsoleColor.Blue,status,IsDragable,IsDown,DownLocation,ClientMousePosition);
		}
		
		public override void AddEvents()
		{
			base.AddEvents();
			Client.MouseMove += eMouseMove;
			Client.MouseUp += eMouseUp;
			Client.MouseDown += eMouseDown;
		}

		public MovableDlgManager(MovableDlg dlg) : base(dlg,true)
		{
		}
	}
	public class MovableDlg : efx.Forms.BasicForm
	{
		public MovableDlgManager manager;

		public void doup(MouseEventArgs e) { manager.eMouseUp(this,e); }
		public void dodown(MouseEventArgs e) { manager.eMouseUp(this,e); }
		public void domove(MouseEventArgs e) { manager.eMouseUp(this,e); }
		
		public MovableDlg() : base()
		{
			InitializeComponent();
			manager = new MovableDlgManager(this);
		}
	}
}
