using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

// inherited the logic of outlook-datagridview from “CodeProject.net”
namespace cor3.forms.controls.data
{

	public class grid_viewer : DataGridView
	{
//		[System.ComponentModel.TypeConverterAttribute(typeof(ExpandableObjectConverter))]
//		public new DataGridViewRow RowTemplate { get { return base.RowTemplate; } } // learned by outlook grid control on code-proj.net
		
		virtual public void InitializeStyle()
		{
			base.BackColor = SystemColors.Window;
//			base.RowTemplate = new grid_view_row<object>();
		}

		public grid_viewer() : base()
		{
			InitializeStyle();
		}
	}
}