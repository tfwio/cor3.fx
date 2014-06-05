/*
 * User: tfw
 * Date: 8/11/2008
 * Time: 5:20 AM
 */
using System;
using System.Windows.Forms;

namespace iface
{
	/// <summary></summary>
	public interface IMenuItemBuilder
	{
		/// <summary></summary>
		void InitializeMenu();
	//	void InitializeDockAreasContext();
		/// <summary></summary>
		void MenuItemBuilder();
		/// <summary></summary>
		void CheckItems();
		/// <summary></summary>
		void CheckItems(params ToolStripItemCollection[] collections);
		/// <summary></summary>
		void CheckItem(ToolStripMenuItem tsi);
		/// <summary></summary>
		void MenuItemClick(object sender, EventArgs args);
		//ToolStripMenuItem EmumMenuItem<T>(string name);
	}


}
