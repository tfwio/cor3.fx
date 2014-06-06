/* [insert license here] **
 * tfw * 2/25/2009 * 2:08 PM
**/
using System;
using System.Collections.Generic;
using System.Cor3;
using System.Windows.Forms;

namespace Cor3.forms
{
	public partial class ui_fx_frm : System.Windows.Forms.Form
	{
		ui_fx_manager manager;
		public ImageList tvImages = new ImageList();
		public bool AskBeforeClear = true;

		public SimpleCollectionTrigger<string> LoadedFiles = new SimpleCollectionTrigger<string>();

		public List<TreeNode> tvItems = new List<TreeNode>();
		public List<TreeNode> tvResources = new List<TreeNode>();

		public ui_fx_frm()
		{
			InitializeComponent();
			manager = new ui_fx_manager(this);
		}
	}
}
