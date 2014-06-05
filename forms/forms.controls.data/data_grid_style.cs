using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace cor3.forms.controls.data
{

	public class data_grid_style
	{
		DataGridViewCellStyle styleMain = new DataGridViewCellStyle(), styleSecondary = new DataGridViewCellStyle();
		public grid_style gs1 , gs2 ;
		public DataGridViewCellStyle StyleMain { get { return styleMain; } set { styleMain = value; } }
		public DataGridViewCellStyle StyleSecondary { get { return styleSecondary; } set { styleSecondary = value; } }

		public void Apply()
		{
			gs1.Apply(styleMain);
			gs2.Apply(styleSecondary);
		}
		public void Apply(DataGridView vieu)
		{
			Global.statR("Applying Style Info");
			vieu.DefaultCellStyle = StyleMain;
			vieu.AlternatingRowsDefaultCellStyle = StyleSecondary;
			// …
			vieu.GridColor = System.Drawing.SystemColors.Control;
//			vieu.RowTemplate.Height = 19;
			vieu.BackgroundColor = System.Drawing.SystemColors.Window;
			vieu.CellBorderStyle = DataGridViewCellBorderStyle.None;
			vieu.RowHeadersVisible = false;
			vieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			vieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//			vieu.AllowUserToAddRows = false;
//			vieu.AllowUserToDeleteRows = false;
			vieu.AllowUserToResizeRows = false;
			vieu.EditMode = DataGridViewEditMode.EditOnEnter;
		}
		public data_grid_style(DataGridView vieu) : this()
		{
			Apply(vieu);
		}
		public data_grid_style(DataGridView vieu, grid_style s1, grid_style s2) : this(s1,s2)
		{
			Apply(vieu);
		}
		public data_grid_style(grid_style s1, grid_style s2)
		{
			gs1 = s1; gs2 = s2;
		}
		public data_grid_style() : this( //140,200
			new grid_style(Color.FromArgb(230,240,255),SystemColors.WindowText,SystemColors.Highlight,SystemColors.HighlightText),
		       new grid_style(SystemColors.Window,SystemColors.ControlText,SystemColors.Highlight,SystemColors.HighlightText))
		{
			Apply();
		}

	}
}
