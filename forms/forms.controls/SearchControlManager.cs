/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Collections.Generic;
using System.Cor3.man;
using System.Drawing;
using System.Windows.Forms;

namespace System.Cor3.Forms
{
	public class TextParserUI : UserControl
	{
		public TextParserUI() : base()
		{
			
		}
	}
	public class SearchControlManager : object_manager<SearchControl>
	{
		static Color
			clr_bad = Color.FromArgb(245,209,186),
			clr_good = SystemColors.Window;
		//

		List<int> inner_query = new List<int>();
		int list_index;

		object query_obj;
		public object QueryObject { get { return query_obj; } set { query_obj = value; } }
		public bool HasQueryObject { get { return QueryObject!=null; } }
		public bool IsRichText { get { return QueryObject is RichTextBox; } }
		public bool IsTextBox { get { return QueryObject is TextBox; } }

		public RichTextBox RichText { get { return (IsRichText) ? (RichTextBox)QueryObject : null ; } }
		public TextBox TextBox { get { return (IsTextBox) ? (TextBox)QueryObject:null; } }

		public bool HasNext {
			get
			{
				if (!HasResults) return false;
				if (CurrentIndex < QueryLength) return true;
				return false;
			}
		}
		public bool HasFirst
		{
			get
			{
				if (!HasResults) return false;
				return true;
			}
		}
		
		public int QueryCaret
		{
			get
			{
				if (!HasQueryObject) return -1;
				if (IsRichText) return RichText.SelectionStart;
				else return TextBox.SelectionStart;
			}
		}
		public int CurrentIndex { get { return list_index; } }
		public bool HasResults { get { return inner_query.Count>0; } }
		public int QueryLength { get { return inner_query.Count; } }
		public int QueryIndex { get { return list_index; } }

		public bool Query()
		{
			list_index = 0;
			inner_query = System.Cor3.text.search.match_str(
				Client.SearchText,
				( IsRichText ) ?
				RichText.Text : TextBox.Text
			);
			Global.cstat(ConsoleColor.Yellow,"numresults: {0}",inner_query.Count);
//			if (HasResults)// Client
				return HasResults;
		}
		public void eCheck(object sender, EventArgs e)
		{
			if (!HasQueryObject) return;
			if (Client.SearchText.Length>0) Query();
		}
		public override void AddEvents()
		{
			Client.text_field.TextChanged += eCheck;
		}

		public SearchControlManager(SearchControl ctl) : base(ctl,true)
		{
			
		}
	}
}
