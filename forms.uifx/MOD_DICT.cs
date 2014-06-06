/* [insert license here] **
 * tfw * 2/25/2009 * 2:08 PM
**/
using System;
using System.IO;
using System.Windows.Forms;

using w32.kernel;

namespace Cor3.forms
{
	public class MOD_DICT : DICT<string,LibLoader2> 
	{
		public void AddModule(string module_path)
		{
			string modName = Path.GetFileName(module_path);
			if (!File.Exists(module_path))
			{
				MessageBox.Show(
					"File does not exist","Error",
					MessageBoxButtons.OK,MessageBoxIcon.Error
				);
				return;
			}
			Add(module_path,new LibLoader2(module_path));
		}
		public MOD_DICT(params MOD_DICT.DictNode[] modules) : base(modules)
		{
			
		}
	}
}
