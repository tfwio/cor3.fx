#region tfw * 8/9/2009 * 11:05 PM ** 'LICENSE & File Header'
/** [insert license here] **
 * if no license is mentioned above
 * you are to assume a HYBRID GPL/MIT license which in general allows you to use
 * the code without limitation (commercially or not) provided that if there are
 * any alterations made to the code, you must supply us with a copy.  Also you
 * are to credit the authors and include a respective MIT/GPL license on each
 * respective script and supply each respective and/or applicable license(s) 
 * with and binaries produced as a result of this property.
***
 * -- thanks
**/
#endregion
using System;
using Drawing;
using Drawing.Render;
using iface.Forms;

namespace efx.Forms.Managers
{
	public class FormOverlayInspector : GenericManager<iOverlay,IFormInfo>
	{
		internal IClientInspector	Inspector;
		public void Refresh() { Overlay.Position = new HRect(Inspector.TopLeft,Inspector.PaddedClient.Size); }
	
		virtual protected void Move(object sender, EventArgs args) { Refresh(); }
	
		public FormOverlayInspector(IFormInfo parent, iOverlay client) : base(parent,client)
		{
			Inspector = new ClientInspector(parent);
			Refresh();
			
			Parent.Shown += new EventHandler(Move);
			Parent.SizeChanged += new EventHandler(Move);
			Parent.Move += new EventHandler(Move);
		}
	}
}
