/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using drawing;
using drawing.render.surface;

namespace System.Cor3.Forms.rtf
{
	public delegate void ApplyClicked(string control_name, string TextRendered);
	public struct rtf_info_typ
	{
		public RichTextBox RTF;
		public bool HasSelection
		{
			get { if (RTF==null) return false; return RTF.SelectedText!=string.Empty; }
		}
		public bool HasCharIndex
		{
			get
			{
				int l = RTF.GetCharIndexFromPosition(RTF.PointToClient(Control.MousePosition));
				return l > 0;
			}
		}
		public int CharIndex
		{
			get
			{
				return RTF.GetCharIndexFromPosition(RTF.PointToClient(Control.MousePosition));
			}
		}
		public int[] SelectionTabs
		{
			get
			{
				List<int> tbs = new List<int>();
				if (HasSelection) tbs.AddRange(RTF.SelectionTabs);
				return tbs.ToArray();
			}
		}
		public int BulletIndent { get { return (RTF.SelectionBullet) ? RTF.BulletIndent : 0; } }
		public int SelectionIndent { get { return (HasSelection) ? RTF.SelectionIndent : 0; } }
		public int SelectionHang { get { return (HasSelection) ? RTF.SelectionHangingIndent : 0; } }
		public int SelectionRightIndent { get { return (HasSelection) ? RTF.SelectionRightIndent : 0; } }
		public rtf_info_typ(RichTextBox rtf) { this.RTF = rtf; }
	}
}
