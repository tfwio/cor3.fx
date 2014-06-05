/*
 * User: tfw
 * Date: 8/13/2009
 * Time: 3:57 PM
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Drawing;
using Drawing.Xml;

namespace efx.Forms.Managers
{

	public class treeview_node_mover : ObjectManager<TreeView>
	{
		TreeNodeCollection SelectedParent
		{
			get
			{
				return (Client.SelectedNode.Level==0) ? 
					Client.Nodes : Client.SelectedNode.Parent.Nodes;
			}
		}

		//int SelectedLevel { return Client.SelectedNode.Level; }
		TreeNode SelectedClone { get { return Client.SelectedNode.Clone() as TreeNode; } }
		internal int SelectedIndex { get { return Client.SelectedNode.Index; } }
		internal int SelectedCount { get { return SelectedParent.Count; } }
		internal bool IsFirst { get { return Client.SelectedNode.Index == 0; } }
		internal bool IsLast { get { return SelectedIndex == SelectedCount-1; } }
		internal bool IsDeletable
		{
			get
			{
				return SelectedCount>0;
			}
		}

		internal bool CanMoveUp
		{
			get
			{
				if (SelectedCount<= 1) return false;
				if (IsFirst) return false;
				return true;
			}
		}
		internal bool CanMoveDown
		{
			get
			{
				if (IsLast) return false;
				if (SelectedCount<=1) return false;
				return true;
			}
		}

		public ToolStripItem BtnUp = null,BtnDown=null,BtnDel=null;
		internal bool HasUp { get { return BtnUp!=null; } }
		internal bool HasDown { get { return BtnDown!=null; } }
		internal bool CanDelete { get { return BtnDown!=null; } }

		internal void MoveNode(bool move_up)
		{
			int ndx = SelectedIndex;
			TreeNodeCollection ParentN = SelectedParent;
			TreeNode tn = SelectedClone;
			ParentN.Remove(Client.SelectedNode);
			ParentN.Insert((move_up)?ndx-1:ndx+1,tn);
			Client.SelectedNode = tn;
		}

		public TreeNode AddNode(string name, object tag)
		{
			TreeNode tn = NodeFromObject(name,tag);
			Client.Nodes.Add(tn);
			return tn;
		}
		public void RemoveByKey(string Key)
		{
			Client.Nodes.RemoveByKey(Key);
		}
		public TreeNode FromKey(string Key)
		{
			TreeNode[] tn = Client.Nodes.Find(Key,true);
			if (tn.Length==0) return null;
			if (tn[0]==null) return null;
			return tn[0];
		}
		public void RemoveNode(string name,object tag)
		{
			Client.Nodes.Remove(NodeFromObject(name,tag));
		}

		public bool SameNode(params TreeNode[] node)
		{
			return ( (node[0].Tag == node[1].Tag) && (node[0].Text == node[1].Text));
		}
		/// based on treeview.ContainsKey()
		public bool HasKey(TreeNode tn)
		{
			return Client.Nodes.ContainsKey(tn.Name);
		}
		/// based on treeview.Contains()
		public bool HasNode(TreeNode tn)
		{
			return Client.Nodes.Contains(tn);
		}

		public TreeNode NodeFromObject(string name, object tag)
		{
			TreeNode tn = new TreeNode(name);
			tn.Name = (tn.Tag = tag).ToString();
			return tn;
		}

		internal void eUp(object sen, EventArgs arg) { if (CanMoveUp) MoveNode(true); }
		internal void eDwn(object sen, EventArgs arg) { if (CanMoveDown) MoveNode(false); }
		internal void eAfterSel(object s, TreeViewEventArgs e)
		{
			Application.DoEvents();
			if (CanDelete!=null&&BtnDel!=null) BtnDel.Enabled=true;
			if (HasUp) BtnUp.Enabled = CanMoveUp;
			if (HasDown) BtnDown.Enabled = CanMoveDown;
		}
		public void eDelete(object s, EventArgs e)
		{
			Client.SelectedNode.Remove();
		}
		
		public void AddNodeBefore(TreeNode sel, params TreeNode[] nodes)
		{
			foreach (TreeNode node in nodes)
				sel.Parent.Nodes.Insert(sel.PrevNode.Index,node);
		}
		public void AddNodeAfter(TreeNode sel, params TreeNode[] nodes)
		{
			foreach (TreeNode node in nodes)
				sel.Parent.Nodes.Insert(sel.Index,node);
		}
		public void AddChildNodes(TreeNode sel, params TreeNode[] nodes)
		{
			foreach (TreeNode node in nodes)
				sel.Nodes.Add(node);
		}

		public void SetButtons(ToolStripItem up, ToolStripItem down, ToolStripItem del)
		{
			BtnUp = up; BtnDown = down; BtnDel=del;
			BtnUp.MouseDown -= eUp; BtnUp.MouseDown += eUp;
			BtnDown.MouseDown -= eDwn; BtnDown.MouseDown += eDwn;
			if (BtnDel!=null) { BtnDel.Click -= eDelete; BtnDel.Click += eDelete;BtnDel.Enabled = false; }
			
		}
		void eenter(object s, DragEventArgs e) // eenter
		{
//			e.AllowedEffect = DragDropEffects.All;
			e.Effect = DragDropEffects.Move;
			Global.cstat(ConsoleColor.Red,"eenter sender: {0}",s);
		}
		void eover(object s, DragEventArgs e) // DragOver
		{
			if (NodeAtPoint.Node!=null) Global.cstat(ConsoleColor.Green,"DragOver NODE: {0}",NodeAtPoint.Node);
			else Global.cstat(ConsoleColor.Red,"DragOver sender: {0}",s);
		
		}
		void edrag(object s, EventArgs e) // DragLeave
		{
			Global.cstat(ConsoleColor.Red,"DragLeave sender: {0}",s);
		}
		void edrag(object s, ItemDragEventArgs e) // ItemDragEventArgs
		{
			Client.DoDragDrop(e.Item, DragDropEffects.All);
		}
		void edrop(object s, DragEventArgs e) // Drop
		{
			Global.cstat(ConsoleColor.Red,"Drop\rsender: {0}",s);
		}
		void edrag(object s, DragEventArgs e) // DragEventArgs
		{
			if (NodeAtPoint.Node!=null)
			{
				Global.cstat(ConsoleColor.Green,"DragEventArgs sender: {0}",s);
				Client.SelectedNode = NodeAtPoint.Node;
			}
			Global.cstat(ConsoleColor.Red,"DragEventArgs sender: {0}",s);
		}
		void eqdrag(object s, QueryContinueDragEventArgs e)
		{
			if (NodeAtPoint.Node!=null)
			{
				Global.cstat(ConsoleColor.Green,"Query sender: {0}",s);
				Client.SelectedNode = NodeAtPoint.Node;
			}
		}
		public TreeViewHitTestInfo NodeAtPoint { get { return Client.HitTest(Client.PointToClient(MousePosition)); } }
		public HPoint MousePosition { get { return new HPoint(Control.MousePosition.X,Control.MousePosition.Y); } }
		public bool drag = false;
		
		public override void AddEvents()
		{
			base.AddEvents();
			Client.DragEnter += new DragEventHandler(eenter);
			Client.DragOver += new DragEventHandler(eover);
			Client.DragLeave += new EventHandler(edrag);
			Client.ItemDrag += new ItemDragEventHandler(edrag);
			Client.DragDrop += new DragEventHandler(edrag);
			Client.QueryContinueDrag += new QueryContinueDragEventHandler(edrag);
//			Client.MouseDown += emoused;
//			Client.MouseUp += emouseu;
//			Client.MouseMove += emousem;
			Client.FullRowSelect = true;
			Client.AllowDrop = true;
		}
		
		public treeview_node_mover(TreeView ctl) : base(ctl) { Client.AfterSelect += eAfterSel; }
		public treeview_node_mover(TreeView ctl, ToolStripItem up, ToolStripItem down) : this(ctl,up,down,null)
		{
		}
		public treeview_node_mover(TreeView ctl, ToolStripItem up, ToolStripItem down, ToolStripItem dlete) : this(ctl)
		{
			SetButtons(up,down,dlete);
		}
	}
}
