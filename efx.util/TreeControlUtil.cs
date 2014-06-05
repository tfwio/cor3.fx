/* oOo * 11/14/2007 : 9:53 PM */
/**
 * NameSpace Description:
 * 	this class is to generally encapsulate classes which are to contain
 * 	redundant 'library' functions to 'help'.
 */
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace efx.Utility
{
	public class TreeControlUtil : ControlUtil
	{
		public class TreeCall
		{
			internal const int def_incr = -1;
			internal int incr;
	
			internal const bool def_path = true;
			public bool BuildPathList = def_path;
	
			internal const bool def_dbg = true;
			public bool ShowDebug = def_dbg;
	
			internal TreeView tview;
			internal ToolStripProgressBar pbar = null;
			public bool ShowProgress { get { return (pbar!=null)?true:false; } }
			internal int TreeNodeMax { get { return (tview==null)?0:tview.GetNodeCount(true); } }
	
			[Flags] public enum LoopEventType : int
			{
				/// <summary>default</summary>
				None = 0x0,
				/// <summary>intended only for internal use</summary>
				ListPath = 0x1,
				/// <summary>intended only for internal use</summary>
				ShowProgress = 0x2,
				/// <summary>don't know if I actually am using this</summary>
				CountItems = 0x4,
				/// <summary>intended only for internal use</summary>
				ShowDebug = 0x8,
				/// <summary>(Not Implemented) Set this to call Application.DoEvents</summary>
				LowPriority = 0x10,
			}
	
			LoopEventType eventType = LoopEventType.None;
			public LoopEventType EventType {
				get
				{
					LoopEventType let = eventType;
					if (BuildPathList) let = let | LoopEventType.ListPath;
					if (ShowProgress) let = let | LoopEventType.ShowProgress;
					if (ShowDebug) let = let | LoopEventType.ShowDebug;
					return let;
				}
				set { eventType = value; }
			}
	
			public class TnEventArgs : EventArgs
			{
				public TreeNode tn;
				public LoopEventType Flags = LoopEventType.None;
				public TnEventArgs() : base() { }
				public TnEventArgs(TreeNode tnx) : this() { tn = tnx; }
				public TnEventArgs(TreeNode tnx, LoopEventType flags) : this(tnx) { Flags = flags; }
			}
	
			public delegate void TvEvent(object obj, TnEventArgs args);
			public event TvEvent OnIncr;
			protected void DoIncr(object obj, TnEventArgs args) { if (OnIncr!=null) OnIncr(obj,args); }
	
			virtual public void Initialize(bool doperform)
			{
				incr = def_incr;
				OnIncr += new TvEvent(Loop);
				if (doperform) PerformLoop();
			}
	
			virtual public void PerformLoop()
			{
				bool pv = pbar.Visible;
				if (ShowProgress) { pbar.Visible = true; pbar.Maximum = TreeNodeMax; }
				Globe.AppForm.Cursor = Cursors.WaitCursor;
				PerformLoop(tview.Nodes);
				if (ShowProgress) pbar.Visible = pv;
				Globe.AppForm.Cursor = Cursors.Default;
			}
			virtual public void PerformLoop(TreeNodeCollection nodes)
			{
				if (nodes==null) return;
				if (nodes.Count==0) return;
				foreach (TreeNode tn in nodes)
				{
					TnEventArgs tea = new TnEventArgs(tn,EventType);
					DoIncr(null,tea);
					PerformLoop(tn.Nodes);
				}
			}
			virtual public void Loop(object obj, TnEventArgs args)
			{
				LoopEventType lex = args.Flags;
	//				Globe.stat(args.Flags);
				Globe.cstat(ConsoleColor.Red,args.Flags);
	//				Globe.cstat(ConsoleColor.Red,args.tn.Text);
				if ((uint)(args.Flags^LoopEventType.ListPath)==1) {}
				if ((uint)(args.Flags^LoopEventType.CountItems)==1) { incr++; }
				if ((uint)(args.Flags^LoopEventType.ShowProgress)==1) { pbar.Value=incr+1; }
				if ((uint)(args.Flags^LoopEventType.ShowDebug)==1) { Globe.cstat(ConsoleColor.DarkYellow,"{0}",args.tn.Text); }
				if ((args.Flags^LoopEventType.LowPriority)==LoopEventType.ListPath) { Application.DoEvents(); }
			//	DoIncr(obj,args);
				switch (args.Flags)
				{
					case LoopEventType.ListPath: ; break;
					case LoopEventType.CountItems: incr++; break;
					case LoopEventType.ShowProgress: pbar.Value=incr+1; break;
					case LoopEventType.ShowDebug: Globe.cstat(ConsoleColor.DarkYellow,"{0}",args.tn.Text); ; break;
					default: Globe.stat(incr);break;
				}
				return;
			}
	
			public TreeCall(TreeView tv, ToolStripProgressBar pgbar, TreeCall.LoopEventType etype) : this(tv,pgbar) { eventType = etype; }
			public TreeCall(TreeView tv, ToolStripProgressBar pgbar) : this(tv) { pbar = pgbar; }
			public TreeCall(TreeView tv)
			{
				tview = tv;
				OnIncr += new TvEvent(Loop);
			}
	
		}
	}
}
