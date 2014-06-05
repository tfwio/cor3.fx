/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using cor3.xml;

namespace cor3.design
{
	public class uc_filter_edit : UserControl
	{
		public file_filter Filter;
		public file_filter TempFilter;

		public ListViewItem Selection
		{
			get
			{
				return lv.SelectedItems[0];
			}
		}

		public uc_filter_edit(file_filter text, IWindowsFormsEditorService edSvc)
		{
			Filter = text;
			InitializeComponent();
		}
		void InitializeComponent()
		{
			this.lv = new System.Windows.Forms.ListView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnOkay = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cName = new System.Windows.Forms.ColumnHeader();
			this.cExt = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cName,
									this.cExt});
			this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv.Location = new System.Drawing.Point(6, 6);
			this.lv.Name = "listView1";
			this.lv.Size = new System.Drawing.Size(296, 158);
			this.lv.TabIndex = 0;
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.View = System.Windows.Forms.View.Details;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnOkay);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(6, 164);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(296, 34);
			this.panel1.TabIndex = 2;
			// 
			// btnOkay
			// 
			this.btnOkay.AutoSize = true;
			this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOkay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnOkay.Location = new System.Drawing.Point(50, 0);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new System.Drawing.Size(246, 34);
			this.btnOkay.TabIndex = 3;
			this.btnOkay.Text = "Okay";
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCancel.Location = new System.Drawing.Point(0, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(50, 34);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			// 
			// cName
			// 
			this.cName.Text = "Name";
			this.cName.Width = 224;
			// 
			// cExt
			// 
			this.cExt.Text = "Extension";
			this.cExt.Width = 76;
			// 
			// filteredit
			// 
			this.Controls.Add(this.lv);
			this.Controls.Add(this.panel1);
			this.Name = "filteredit";
			this.Padding = new System.Windows.Forms.Padding(6);
			this.Size = new System.Drawing.Size(308, 204);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.ColumnHeader cExt;
		private System.Windows.Forms.ColumnHeader cName;
		public System.Windows.Forms.Button btnOkay;
		public System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView lv;
	}
}
