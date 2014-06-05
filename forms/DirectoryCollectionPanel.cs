/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace efx.as3
{
	public class DirectoryCollectionPanel : System.Windows.Forms.UserControl
	{
		public event EventHandler LibsUpdated;
		public virtual void OnLibsUpdated(EventArgs e)
		{
			if (LibsUpdated != null) { LibsUpdated(this, e); }
		}
		public DirectoryCollectionManager manager;

		public DirectoryCollectionPanel()
		{
			InitializeComponent();
			manager = new DirectoryCollectionManager(this);
		}

		void InitializeComponent()
		{
			this.dirList = new efx.Forms.Specialized.DirListBox();
			this.sc_libs = new System.Windows.Forms.SplitContainer();
			this.comboBox3 = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_refresh = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_save = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_dir_down = new System.Windows.Forms.ToolStripButton();
			this.btn_dir_up = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.btn_dir_add = new System.Windows.Forms.ToolStripButton();
			this.btn_dir_remove = new System.Windows.Forms.ToolStripButton();
			this.sc_libs.Panel1.SuspendLayout();
			this.sc_libs.Panel2.SuspendLayout();
			this.sc_libs.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dirList
			// 
			this.dirList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dirList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dirList.Font = new System.Drawing.Font("Bitstream Vera Sans", 7F);
			this.dirList.FormattingEnabled = true;
			this.dirList.IntegralHeight = false;
			this.dirList.ItemHeight = 10;
			this.dirList.Location = new System.Drawing.Point(0, 0);
			this.dirList.Margin = new System.Windows.Forms.Padding(2);
			this.dirList.Name = "dirList";
			this.dirList.Size = new System.Drawing.Size(418, 249);
			this.dirList.TabIndex = 9;
			// 
			// sc_libs
			// 
			this.sc_libs.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.sc_libs.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sc_libs.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.sc_libs.Location = new System.Drawing.Point(0, 249);
			this.sc_libs.Margin = new System.Windows.Forms.Padding(0);
			this.sc_libs.Name = "sc_libs";
			// 
			// sc_libs.Panel1
			// 
			this.sc_libs.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.sc_libs.Panel1.Controls.Add(this.comboBox3);
			this.sc_libs.Panel1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 0);
			// 
			// sc_libs.Panel2
			// 
			this.sc_libs.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.sc_libs.Panel2.Controls.Add(this.toolStrip1);
			this.sc_libs.Panel2MinSize = 80;
			this.sc_libs.Size = new System.Drawing.Size(418, 20);
			this.sc_libs.SplitterDistance = 202;
			this.sc_libs.SplitterWidth = 3;
			this.sc_libs.TabIndex = 10;
			// 
			// comboBox3
			// 
			this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.comboBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBox3.Font = new System.Drawing.Font("Bitstream Vera Sans", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox3.Location = new System.Drawing.Point(2, 1);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(200, 18);
			this.comboBox3.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(12, 12);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripDropDownButton1,
									this.btn_dir_down,
									this.btn_dir_up,
									this.toolStripButton1,
									this.btn_dir_add,
									this.btn_dir_remove});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(213, 20);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btn_refresh,
									this.btn_save});
			this.toolStripDropDownButton1.Image = global::efx.efx_ico.Light_Grey_Gear_16x16;
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(25, 17);
			this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
			// 
			// btn_refresh
			// 
			this.btn_refresh.Image = global::efx.famfam_silky.arrow_refresh_small;
			this.btn_refresh.Name = "btn_refresh";
			this.btn_refresh.Size = new System.Drawing.Size(133, 22);
			this.btn_refresh.Text = "Refresh List";
			// 
			// btn_save
			// 
			this.btn_save.Image = global::efx.famfam_silky.bullet_disk;
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(133, 22);
			this.btn_save.Text = "Save";
			// 
			// btn_dir_down
			// 
			this.btn_dir_down.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_dir_down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_dir_down.Font = new System.Drawing.Font("Marlett", 10F);
			this.btn_dir_down.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.btn_dir_down.Image = global::efx.famfam_silky.bullet_arrow_down;
			this.btn_dir_down.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_dir_down.Name = "btn_dir_down";
			this.btn_dir_down.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.btn_dir_down.Size = new System.Drawing.Size(23, 17);
			this.btn_dir_down.Text = "6";
			// 
			// btn_dir_up
			// 
			this.btn_dir_up.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_dir_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_dir_up.Font = new System.Drawing.Font("Marlett", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.btn_dir_up.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.btn_dir_up.Image = global::efx.famfam_silky.bullet_arrow_up;
			this.btn_dir_up.Name = "btn_dir_up";
			this.btn_dir_up.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.btn_dir_up.Size = new System.Drawing.Size(23, 17);
			this.btn_dir_up.Text = "5";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::efx.famfam_silky.folder_edit;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 17);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// btn_dir_add
			// 
			this.btn_dir_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_dir_add.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.btn_dir_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
			this.btn_dir_add.Image = global::efx.famfam_silky.folder_add;
			this.btn_dir_add.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_dir_add.Name = "btn_dir_add";
			this.btn_dir_add.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.btn_dir_add.Size = new System.Drawing.Size(23, 17);
			this.btn_dir_add.Text = "Add Directory";
			// 
			// btn_dir_remove
			// 
			this.btn_dir_remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_dir_remove.Image = global::efx.famfam_silky.folder_delete;
			this.btn_dir_remove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_dir_remove.Name = "btn_dir_remove";
			this.btn_dir_remove.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.btn_dir_remove.Size = new System.Drawing.Size(23, 17);
			this.btn_dir_remove.Text = "toolStripButton1";
			// 
			// DirectoryCollectionPanel
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.dirList);
			this.Controls.Add(this.sc_libs);
			this.Name = "DirectoryCollectionPanel";
			this.Size = new System.Drawing.Size(418, 269);
			this.sc_libs.Panel1.ResumeLayout(false);
			this.sc_libs.Panel1.PerformLayout();
			this.sc_libs.Panel2.ResumeLayout(false);
			this.sc_libs.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
		}

		public System.Windows.Forms.SplitContainer sc_libs;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		public System.Windows.Forms.TextBox comboBox3;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		public System.Windows.Forms.ToolStripMenuItem btn_refresh;
		public System.Windows.Forms.ToolStripMenuItem btn_save;

		public System.Windows.Forms.ToolStripButton btn_dir_down;
		public System.Windows.Forms.ToolStripButton btn_dir_up;
		public System.Windows.Forms.ToolStripButton btn_dir_add;
		public System.Windows.Forms.ToolStripButton btn_dir_remove;
		public System.Windows.Forms.ToolStrip toolStrip1;
		public efx.Forms.Specialized.DirListBox dirList;
	}
}
