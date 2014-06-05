/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Drawing.Render.Surface;

namespace efx.Forms.Controls.rtf
{
	
	public class RulerPanelBase : UserControl
	{
		const float PixelUnit = 1f/96f,
					PixelDPI  = 96f;
		
		public List<IButton> ibtn;
		public List<int> _marker;
		public int[] Marker { get { return _marker.ToArray(); } }
		public List<int> _tabs;
		public int[] Tabs { get { return _tabs.ToArray(); } }
		public PointF _mousePoint;
		public PointF MousePoint { get { return _mousePoint; } }
//		public float PixelUnit { get { return 1/m_gfx.DpiX; } }
		public double _vth { get { return PixelDPI/Threshold; } }
		public int _xth { get { return (int)(xwalk()*_vth); } }
		public int Threshold = 16;
		void updatethreshold(object sender,EventArgs e)
		{
			Threshold = ControlUtil.ToTag<int>(sender as System.ComponentModel.IComponent);
		}

		public RulerPanelBase(RTFEdit obj) : base()
		{
			ibtn = new List<IButton>();
//			ibtn.Add(new XButton(this,"hi mom! - ",new RectangleF(0,0,16,16)));
			_marker = new List<int>();
			_tabs = new List<int>();
//			ToolStripMenuItem _snap;
//			ContextMenuStrip cmx = new ContextMenuStrip();
//			cmx.Items.AddRange(
//					new ToolStripItem[]
//					{
//						ControlUtil.TSItem("Left-Indent",RtfEdit.EditAPI.LeftIndent,new EventHandler(obj.CallAPI)),
//						ControlUtil.TSItem("Hang-Indent",RtfEdit.EditAPI.HangIndent,new EventHandler(obj.CallAPI)),
//						ControlUtil.TSItem("Right-Indent",RtfEdit.EditAPI.RightIndent,new EventHandler(obj.CallAPI)),
//						ControlUtil.TSItem(),
//						_snap = ControlUtil.TSItem("Snap"),
//					}
//			);
//				_snap.DropDownItems.AddRange(
//					new ToolStripItem[]
//					{
//						ControlUtil.TSItem("1",1,new EventHandler(updatethreshold)),
//						ControlUtil.TSItem("1/2",2,new EventHandler(updatethreshold)),
//						ControlUtil.TSItem("1/4",4,new EventHandler(updatethreshold)),
//						ControlUtil.TSItem("1/8",8,new EventHandler(updatethreshold)),
//						ControlUtil.TSItem("1/16",16,new EventHandler(updatethreshold)),
//						ControlUtil.TSItem("1/32",32,new EventHandler(updatethreshold))
//					}
//				);
//				ContextMenuStrip = cmx;
		}


		public double xwalk() { return xwalk(Threshold); }
		public double xwalk(int threshold) { return (double)(int)(_mousePoint.X/(_vth)); }
		public double xwalk(int val, int threshold)
		{
			// assume threshold to be quadrant
			//int w = m_gfx.DpiX/(ruler._mousePoint.X);
			return (double)(int)(val/(m_gfx.DpiX/threshold));
		}

		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			_mousePoint = new PointF(e.X,e.Y);
			foreach (IButton btn in ibtn) btn.HitTest(MouseButtons.None,_mousePoint,m_gfx);
//			base.DoDraw(true);
			base.OnMouseMove(e);
		}

	}

}
