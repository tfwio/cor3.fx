/*
 * User: tfw
 * Date: 8/13/2009
 * Time: 3:57 PM
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using drawing;
//using drawing.Xml;

namespace System.Cor3.Forms
{
	public class TreeViewStyle
	{
		static public TreeViewStyle SingleRow 
		{ 
			get
			{
				Global.statY("TreeViewStyle Apply");
				return new TreeViewStyle(
					BorderStyle.None,new Size(16,16),false,true,true,false,false,true);
			}
		}

		public Font Font;
		public bool	HideSelection = true;
		public bool	FullRowSelect = true;
		public bool	ShowPlusMinus = true;
		public bool	ShowRootLines = false;
		public bool	ShowLines = true;
		public bool	ShowNodeToolTips = true;
		public Size	ImageDimensions;
		public BorderStyle BorderStyle = System.Windows.Forms.BorderStyle.None;

		public TreeViewStyle(
			BorderStyle border_style,
			Size dimenz,
			bool hide_selection,
			bool full_row_select,
			bool show_plusminus,
			bool show_root_lines,
			bool show_lines,
			bool show_tooltips)
		{
			ImageDimensions = dimenz;
			BorderStyle = border_style;
			HideSelection = hide_selection;
			FullRowSelect = full_row_select;
			ShowPlusMinus = show_plusminus;
			ShowRootLines = show_root_lines;
			ShowLines = show_lines;
			ShowNodeToolTips = show_tooltips;
		}
		static public void SetSingleRowStyle(TreeView tv)
		{
			SetStyle(tv,SingleRow);
		}
		static public void SetStyle(TreeView tv, TreeViewStyle style)
		{
//			tv.ImageList.ImageSize = style.ImageDimensions;
			tv.FullRowSelect = style.FullRowSelect;
			tv.ShowPlusMinus = style.ShowPlusMinus;
			tv.BorderStyle = style.BorderStyle;
			tv.ShowRootLines = style.ShowRootLines;
			tv.HideSelection = style.HideSelection;
			tv.ShowLines = style.ShowLines;
			tv.ShowNodeToolTips = style.ShowNodeToolTips;
		}

	}
}
