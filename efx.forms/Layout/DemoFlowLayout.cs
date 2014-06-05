/* oOo * 1/24/2008 : 7:23 PM */
/* oOo * 12/14/2007 : 10:02 AM */
/* oOo * 5/23/2008 : 11:02 AM */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace efx.Forms.Controls
{
	public class DemoFlowLayout : LayoutEngine
	{
	    public override bool Layout( object container, LayoutEventArgs layoutEventArgs)
	    {
	        Control parent = container as Control;
	        Rectangle parentDisplayRectangle = parent.DisplayRectangle;
	        Point nextControlLocation = parentDisplayRectangle.Location;
	        foreach (Control c in parent.Controls)
	        {
	            if (!c.Visible) { continue; }
	
	            nextControlLocation.Offset(c.Margin.Left, c.Margin.Top);
	            c.Location = nextControlLocation;
	            if (c.AutoSize) { c.Size = c.GetPreferredSize(parentDisplayRectangle.Size); }
	            nextControlLocation.X = parentDisplayRectangle.X;
	            nextControlLocation.Y += c.Height + c.Margin.Bottom;
	        }
	        return false;
	    }
	}
}
