/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.engines
{
	public class RowHelperList<TList> : List<TList>
	{
		public RowHelperList() : base()
		{
			
		}
		/// <summary>
		/// <para>returns -1 for null values</para>
		/// </summary>
		static public int _int(DataRow row, string name) { return RowHelper._int(row,name); }
		/// <summary>
		/// <para>this should be tested (with negatives) before we're sure its good</p>
		/// <para>does not handle null values</para>
		/// </summary>
		static public uint _uint(DataRow row, string name) { return RowHelper._uint(row,name); }
		static public string _str(DataRow row, string name) { return RowHelper._str(row,name); }
		/// <summary>
		/// <para>returns false for null values</para>
		/// </summary>
		static public bool _bool(DataRow row, string name) { return RowHelper._bool(row,name); }
		static public KeyType _key(DataRow row, string name) { return RowHelper._key(row,name); }
		/// <summary>
		/// this is particularly so that any element can be easily added to a tree-node.
		/// It's expected that this function be overridden to append child elements.
		/// </summary>
		/// <returns></returns>
		virtual public TreeNode GetTreeNode(string name)
		{
			TreeNode tn = new TreeNode(name);
			tn.Tag = this;
			tn.ToolTipText = ItemToolTip;
			return tn;
		}
		/// <summary>(See the overload) This overload uses “ToString()” to get the name for the node.</summary>
		/// <returns></returns>
		virtual public TreeNode GetTreeNode() { return GetTreeNode(ToString()); }
		/// <summary>Designated for use in GetTreeNode</summary>
		virtual public string ItemToolTip { get { return ToString(); } }
	}
}
