/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

using w32;
using w32.user;

namespace efx.Forms.Controls.rtf
{
	public class RTFEdit : System.Windows.Forms.RichTextBox
	{
//		const string msg = "{0} only supports 1 drag-drop file.";
//		const string msg_title = "Too many files dropped";

		public enum API { GetScrollPosition, SetScrollPosition, }
//		public override bool AllowDrop { get { return true; } } 
//		static public bool IsProcessing = false;

//		public Dictionary<Keys,RtfEdit.EditAPI> Shorty;
//		public Dictionary<int,RtfEdit.EditAPI> Shortie;

		public RTFEdit() : base() { }
//		public RTFEdit(RtfEdit ctl) : base()
//		{
//			ContextMenuStrip = new ContextMenuStrip();
//			this.ContextMenuStrip.Items.AddRange(RtfEdit.SimpleMenu(ctl,true));
//			AddKeys(ctl);
//		}

//		public void AddKeys(RtfEdit ctl)
//		{
//			Shorty = new Dictionary<Keys,RtfEdit.EditAPI>();
//			Shortie = new Dictionary<int,RtfEdit.EditAPI>();
//			foreach (ToolStripItem tsi in RtfEdit.SimpleMenu(ctl,true))
//			{
//				if (tsi is ToolStripSeparator) goto skip;
//				if (tsi.Tag is RtfEdit.EditAPI)
//					Shorty.Add((tsi as ToolStripMenuItem).ShortcutKeys,(RtfEdit.EditAPI)tsi.Tag);
//				skip:;
//			}
//			foreach (KeyValuePair<Keys,RtfEdit.EditAPI> kp in Shorty) Shortie.Add((int)kp.Key,kp.Value);
//		}

//		protected override bool ProcessCmdKey(ref Message m, Keys keyData)
//		{
//			Globe.cstat(ConsoleColor.Yellow,m.Msg.ToString("X8"));
//			return base.ProcessCmdKey(ref m, keyData);
//		}

//		public override bool PreProcessMessage(ref Message m)
//		{
//			switch (m.Msg)
//			{
//				case (int)0x0100:
//				{
//					if (Shortie.ContainsKey((int)Control.ModifierKeys + (int)m.WParam))
//					{
//						IsProcessing = true;
//						/*rnull = true;*/
////						(this.Parent as RtfEdit).CallAPI(Shortie[(int)Control.ModifierKeys + (int)m.WParam]);
//						IsProcessing = false;
//						
//					}
//				}
//				break;
//			}
//			if (/*rnull || */!IsProcessing) return false;
//			return base.PreProcessMessage(ref m);
////			return base.PreProcessMessage(ref msg);
//		}

		public void Execute(API api)
		{
			IntPtr wp = IntPtr.Zero, lp = IntPtr.Zero;
			switch (api)
			{
				case API.GetScrollPosition:
					//POINT peet = new POINT();
					//lp = Marshal.AllocHGlobal(Marshal.SizeOf(peet));
					int rv = 0;
					try 
					{
						//peet = (POINT)Marshal.PtrToStructure(lp,typeof(POINT));
						rv = User32.SendMessage(this.Handle,(uint)EM_MSG.EM_GETFIRSTVISIBLELINE,IntPtr.Zero,IntPtr.Zero);
					}
					finally{
						//Marshal.FreeHGlobal(lp);
					}

//					Globe.stat(string.Format("{0},{1}",rv,rv));
					break;
				case API.SetScrollPosition:
					this.ScrollToCaret();
					break;
			}
		}

		//<para>Accepts only Drops of windows explorer files.</para>
//		protected override void OnDragEnter(DragEventArgs e)
//		{
//			if (e.Data.GetDataPresent(DataFormats.FileDrop))
//				e.Effect = DragDropEffects.Copy;
//			base.OnDragEnter(e);
//		}

		//<para>Just loads the dropped file from windows explorer.</para>
//		protected override void OnDragDrop(DragEventArgs e)
//		{
//			handledd(e.Data.GetData(DataFormats.FileDrop) as string[]);
//			base.OnDragDrop(e);
//		}
//		void handledd(params string[] value)
//		{
//			if (value == null) return;
//			if (value.Length == 1) { Main._inst.Create(value[0]); return; }
//			else MessageBox.Show(this, string.Format(msg,this.Name,value), msg_title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
//		}
	}

}
