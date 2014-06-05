/** tfw * 2/9/2008.12:32 PM **/

using System;
using System.IO;

namespace efx.Forms.Controls
{
	[System.Drawing.ToolboxBitmapAttribute(@"D:\dev\win\cs\src\efex\FORK\Resources\flaico.ico")]
	public class ListViewFoo : LvTrack2
	{
		#region Properties
		string activePath = @"c:\";
		public string ActivePath {
			get { return activePath; }
			set {
				if (Directory.Exists(value)) activePath = value;
				else throw new ArgumentException(string.Format("{0} is not a valid directory",value)); }
		}
		#endregion

		public virtual void ListFiles(string path) {  }
		public ListViewFoo() : base() {  }
	}
}
