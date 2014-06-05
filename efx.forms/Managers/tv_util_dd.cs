/*
 * User: tfw
 * Date: 8/13/2009
 * Time: 3:57 PM
 * 
 */
using System;
using System.Windows.Forms;
using Drawing.Xml;

namespace efx.Forms.Managers
{
	public class tv_util_dd : treeview_node_mover
	{
		
		public void dDrop(object s, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TreeNode)))
			{
				;
			}
		}
		public void dEnter(object s, DragEventArgs e)
		{
			
		}
		public void dLeave(object s, EventArgs e)
		{
			
		}
		public void dOver(object s, DragEventArgs e)
		{
		}
		public void dQuery(object s, QueryContinueDragEventArgs e)
		{
		}
	
	
		void nDown(object s, TreeNodeMouseClickEventArgs e)
		{
			Client.DoDragDrop(e.Node, DragDropEffects.Move);
		}
		void mMove(object sender, MouseEventArgs e) {}
		void mUp(object sender, MouseEventArgs e) {}
	
		public override void AddEvents()
		{
			base.AddEvents();
			Client.NodeMouseClick += nDown;
			Client.MouseMove += mMove;
			Client.MouseUp += mUp;
	
			Client.AllowDrop=true;
			Client.DragDrop += dDrop;
			Client.DragEnter += dEnter;
			Client.DragLeave += dLeave;
			Client.DragOver += dOver;
			Client.QueryContinueDrag += dQuery;
		}
		
		public tv_util_dd(TreeView ctl) : base(ctl) {  }
		public tv_util_dd(TreeView ctl, ToolStripItem up, ToolStripItem down) : base(ctl,up,down)
		{
		}
		
	}
}
