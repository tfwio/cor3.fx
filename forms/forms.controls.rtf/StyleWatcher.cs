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
	public class StyleWatcher
	{
		Dictionary<object,ToolStripItem> Items = new Dictionary<object, ToolStripItem>();
		RichTextControl RTF;
		public rtf_info_typ RtfInfo { get { return new rtf_info_typ(RTF); } }

		public void eSelChanged(object sender, EventArgs e)
		{
			DoCk();
		}

		public void DoCk()
		{
			if (RTF.SelectionFont==null) return;
			if (has(Bold)) Bold.Checked = RTF.SelectionFont.Bold;
			if (has(Underline)) Underline.Checked = RTF.SelectionFont.Underline;
			if (has(Oblique)) Oblique.Checked = RTF.SelectionFont.Italic;
			if (has(Bullet)) Bullet.Checked = RTF.SelectionBullet;
			if (has(Strike)) Strike.Checked = RTF.SelectionFont.Strikeout;
			
//			RTF.SelectionFont = new Font(RTF.SelectionFont, (tsFmt_Bold.Checked) ? RTF.SelectionFont.Style & FontStyle.Bold : RTF.SelectionFont.Style|FontStyle.Bold);
		}

		bool has(ToolStripItem itm) { return itm!=null; }
		public ToolStripItem this[string key]{ get { return (!Items.ContainsKey(key)) ? null : Items[key];  } }
		public ToolStripButton Bold { get { return (ToolStripButton)this["bold"]; } }
		public ToolStripButton Underline { get { return (ToolStripButton)this["underline"]; } }
		public ToolStripButton Oblique { get { return (ToolStripButton)this["oblique"]; } }
		public ToolStripButton Bullet { get { return (ToolStripButton)this["bullet"]; } }
		public ToolStripButton Strike { get { return (ToolStripButton)this["strike"]; } }
		public ToolStripMenuItem AlignLeft { get { return (ToolStripMenuItem)this["aleft"]; } }
		public ToolStripMenuItem AlignCenter { get { return (ToolStripMenuItem)this["acenter"]; } }
		public ToolStripMenuItem AlignRight { get { return (ToolStripMenuItem)this["aright"]; } }
		public ToolStripButton Indent { get { return (ToolStripButton)this["indent"]; } }
		public ToolStripButton Indent_Less { get { return (ToolStripButton)this["indent_dec"]; } }
		public ToolStripButton FSizDec { get { return (ToolStripButton)this["f-"]; } }
		public ToolStripButton FSizInc { get { return (ToolStripButton)this["f+"]; } }
//		public ToolStripItem Bold { get { return this["font-name"]; } }

		void IndentMore() { RTF.SelectionIndent = RTF.SelectionIndent + 20; }
		void IndentLess() { RTF.SelectionIndent = (RTF.SelectionIndent==0)? 0 : RTF.SelectionIndent - 20; }
		void FontSizMod() { FontSizMod(false); }
		void FontSizMod(bool is_increase)
		{
			float fsiz = is_increase ? this.RTF.Font.Size+1 : this.RTF.Font.Size-1;
			RTF.SelectionFont = new Font(this.RTF.SelectionFont.FontFamily,fsiz,this.RTF.Font.Style,this.RTF.Font.Unit);
		}
		public void eClick(object Sender, EventArgs a)
		{
			if (RTF.SelectionFont==null) return;
			string tg = (string)(Sender as ToolStripItem).Tag;
			int style = (int)RTF.SelectionFont.Style;
			switch (tg)
			{
				case "bold": style = style ^ (int)FontStyle.Bold  ; break;
				case "underline": style = style ^ (int)FontStyle.Underline  ; break;
				case "oblique": style = style ^ (int)FontStyle.Italic  ; break;
				case "strike": style = style ^ (int)FontStyle.Strikeout  ; break;
				case "bullet": RTF.SelectionBullet = ! RTF.SelectionBullet ; break;
				case "aleft": RTF.SelectionAlignment = HorizontalAlignment.Left ; break;
				case "acenter": RTF.SelectionAlignment = HorizontalAlignment.Center ; break;
				case "aright": RTF.SelectionAlignment = HorizontalAlignment.Right ; break;
				case "indent": IndentMore() ; break;
				case "indent_dec": IndentLess() ; break;
				case "f-": FontSizMod() ; break;
				case "f+": FontSizMod(true) ; break;
			}
			RTF.SelectionFont = new Font(RTF.SelectionFont,(FontStyle)style);
			DoCk();
			fsi();
		}

		public void AddEvents()
		{
			if (has(Bold)) Bold.Click += eClick;
			if (has(Underline)) Underline.Click += eClick;
			if (has(Oblique)) Oblique.Click += eClick;
			if (has(Bullet)) Bullet.Click += eClick;
			if (has(Strike)) Strike.Click += eClick;
			if (has(AlignLeft)) AlignLeft.Click += eClick;
			if (has(AlignRight)) AlignRight.Click += eClick;
			if (has(AlignCenter)) AlignCenter.Click += eClick;
			if (has(Indent)) Indent.Click += eClick;
			if (has(Indent_Less)) Indent_Less.Click += eClick;
			if (has(FSizInc)) FSizInc.Click += eClick;
			if (has(FSizDec)) FSizDec.Click += eClick;
		}

		public StyleWatcher( )
		{
		}
		public StyleWatcher( RichTextControl rtf, params ToolStripItem[] tsis)
		{
			foreach (ToolStripItem tsi in tsis) Items.Add(tsi.Tag,tsi);
			RTF = rtf;
			rtf.SelectionChanged += eSelChanged;
			AddEvents();
		}

		public bool HasStyle(Font f, FontStyle fs)
		{
			return ((int)f.Style & (int)fs) == (int)fs;
		}
		public bool HasStyle(FontStyle f, FontStyle checkfor)
		{
			return ((int)f & (int)checkfor) == (int)checkfor;
		}
		public void fsi()
		{
			foreach (string str in Enum.GetNames(RTF.SelectionFont.Style.GetType()))
			{
				if (str=="Regular") continue;
				Global.cstat(
					ConsoleColor.Cyan,
					"{0} hasStyle={1} = {2:X2}",
					str,
					HasStyle(
						RTF.SelectionFont.Style,
						(FontStyle)Enum.Parse(typeof(FontStyle),str)
					),
					(int)Enum.Parse(typeof(FontStyle),str)
				);
			}
		}

	}
}
