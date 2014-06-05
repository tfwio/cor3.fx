/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.engines
{

	public class RowHelper
	{
		/// <summary>
		/// <para>returns -1 for null values</para>
		/// </summary>
		static public int _int(DataRow row, string name)
		{
			object value = row[name];
			if (value == null) return 0;
			try { return int.Parse(value.ToString()); } catch { return 0; }
		}
		/// <summary>
		/// <para>this should be tested (with negatives) before we're sure its good</p>
		/// <para>does not handle null values</para>
		/// </summary>
		static public uint _uint(DataRow row, string name) { return uint.Parse(row[name].ToString()); }
		static public string _str(DataRow row, string name) { return row[name].ToString(); }
		/// <summary>
		/// <para>returns false for null values</para>
		/// </summary>
		static public bool _bool(DataRow row, string name) { return row[name].ToString() == "YES" ? true : false; }
		static public KeyType _key(DataRow row, string name)
		{
			string value = _str(row,name);
			switch (value)
			{
				case "MUL": return KeyType.MULTIPLE;
				case "PRI": return KeyType.PRIMARY;
				default: return KeyType.NONE;
			}
		}
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
		/// <summary>
		/// (See the overload) This overload uses “ToString()” to get the name for the node.
		/// </summary>
		/// <returns></returns>
		virtual public TreeNode GetTreeNode()
		{
			return GetTreeNode(ToString());
		}

		/// <summary>
		/// Designated for use in GetTreeNode
		/// </summary>
		virtual public string ItemToolTip { get { return ToString(); } }
	}
}
