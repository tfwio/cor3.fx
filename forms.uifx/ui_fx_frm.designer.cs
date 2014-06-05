/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/28/2009
 * Time: 5:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Cor3.forms
{
	partial class ui_fx_frm
	{

		#region Designer
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ui_fx_frm));
			this.splitter1 = new System.Windows.Forms.SplitContainer();
			this.splitter2 = new System.Windows.Forms.SplitContainer();
			this.tab_left = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tvRes = new System.Windows.Forms.TreeView();
			this.ilRes = new System.Windows.Forms.ImageList(this.components);
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tvProperties = new System.Windows.Forms.TreeView();
			this.ilProp = new System.Windows.Forms.ImageList(this.components);
			this.pg = new System.Windows.Forms.PropertyGrid();
			this.tabctl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.Finder = new System.Cor3.Forms.SearchControl();
			this.rtfFont = new System.Cor3.Forms.FontCombo();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.lbtv = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lbl_good = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitter3 = new System.Windows.Forms.SplitContainer();
			this.toolstrip = new System.Cor3.Forms.ToolStripExtender();
			this.tsConfig = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_about = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_vres = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_vprop = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_toggleFind = new System.Windows.Forms.ToolStripMenuItem();
			this.tsAddDLL = new System.Windows.Forms.ToolStripSplitButton();
			this.btn_exe = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_msstyle = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_dll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_loadExpo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_exportXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_exportXmlandDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.exportImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsRemDLL = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_types = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsUp = new System.Windows.Forms.ToolStripButton();
			this.tsDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_preview = new System.Windows.Forms.ToolStripButton();
			this.stat = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.splitter1)).BeginInit();
			this.splitter1.Panel1.SuspendLayout();
			this.splitter1.Panel2.SuspendLayout();
			this.splitter1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitter2)).BeginInit();
			this.splitter2.Panel1.SuspendLayout();
			this.splitter2.Panel2.SuspendLayout();
			this.splitter2.SuspendLayout();
			this.tab_left.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabctl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitter3)).BeginInit();
			this.splitter3.Panel1.SuspendLayout();
			this.splitter3.Panel2.SuspendLayout();
			this.splitter3.SuspendLayout();
			this.toolstrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitter1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitter1.Location = new System.Drawing.Point(0, 20);
			this.splitter1.Name = "splitter1";
			// 
			// splitter1.Panel1
			// 
			this.splitter1.Panel1.Controls.Add(this.splitter2);
			// 
			// splitter1.Panel2
			// 
			this.splitter1.Panel2.BackColor = System.Drawing.SystemColors.Window;
			this.splitter1.Panel2.Controls.Add(this.tabctl);
			this.splitter1.Panel2.Controls.Add(this.lbtv);
			this.splitter1.Size = new System.Drawing.Size(878, 377);
			this.splitter1.SplitterDistance = 255;
			this.splitter1.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitter2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitter2.Location = new System.Drawing.Point(0, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitter2.Panel1
			// 
			this.splitter2.Panel1.Controls.Add(this.tab_left);
			// 
			// splitter2.Panel2
			// 
			this.splitter2.Panel2.Controls.Add(this.pg);
			this.splitter2.Size = new System.Drawing.Size(255, 377);
			this.splitter2.SplitterDistance = 286;
			this.splitter2.TabIndex = 4;
			// 
			// tab_left
			// 
			this.tab_left.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tab_left.Controls.Add(this.tabPage4);
			this.tab_left.Controls.Add(this.tabPage5);
			this.tab_left.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tab_left.Location = new System.Drawing.Point(0, 0);
			this.tab_left.Margin = new System.Windows.Forms.Padding(0);
			this.tab_left.Name = "tab_left";
			this.tab_left.SelectedIndex = 0;
			this.tab_left.Size = new System.Drawing.Size(255, 286);
			this.tab_left.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.tvRes);
			this.tabPage4.Location = new System.Drawing.Point(4, 4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(247, 260);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "tabPage4";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tvRes
			// 
			this.tvRes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvRes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvRes.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tvRes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tvRes.FullRowSelect = true;
			this.tvRes.HideSelection = false;
			this.tvRes.ImageIndex = 0;
			this.tvRes.ImageList = this.ilRes;
			this.tvRes.Location = new System.Drawing.Point(3, 3);
			this.tvRes.Name = "tvRes";
			this.tvRes.SelectedImageIndex = 0;
			this.tvRes.ShowLines = false;
			this.tvRes.Size = new System.Drawing.Size(241, 254);
			this.tvRes.TabIndex = 1;
			// 
			// ilRes
			// 
			this.ilRes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ilRes.ImageSize = new System.Drawing.Size(12, 12);
			this.ilRes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.tvProperties);
			this.tabPage5.Location = new System.Drawing.Point(4, 4);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(195, 178);
			this.tabPage5.TabIndex = 1;
			this.tabPage5.Text = "tabPage5";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// tvProperties
			// 
			this.tvProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvProperties.ImageIndex = 0;
			this.tvProperties.ImageList = this.ilProp;
			this.tvProperties.Location = new System.Drawing.Point(3, 3);
			this.tvProperties.Name = "tvProperties";
			this.tvProperties.SelectedImageIndex = 0;
			this.tvProperties.Size = new System.Drawing.Size(189, 172);
			this.tvProperties.TabIndex = 3;
			// 
			// ilProp
			// 
			this.ilProp.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ilProp.ImageSize = new System.Drawing.Size(12, 12);
			this.ilProp.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pg
			// 
			this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pg.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pg.HelpVisible = false;
			this.pg.Location = new System.Drawing.Point(0, 0);
			this.pg.Name = "pg";
			this.pg.PropertySort = System.Windows.Forms.PropertySort.Categorized;
			this.pg.Size = new System.Drawing.Size(255, 87);
			this.pg.TabIndex = 0;
			this.pg.ToolbarVisible = false;
			// 
			// tabctl
			// 
			this.tabctl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabctl.Controls.Add(this.tabPage1);
			this.tabctl.Controls.Add(this.tabPage2);
			this.tabctl.Controls.Add(this.tabPage3);
			this.tabctl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabctl.Location = new System.Drawing.Point(0, 23);
			this.tabctl.Name = "tabctl";
			this.tabctl.Padding = new System.Drawing.Point(0, 0);
			this.tabctl.SelectedIndex = 0;
			this.tabctl.Size = new System.Drawing.Size(619, 354);
			this.tabctl.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.richTextBox1);
			this.tabPage1.Controls.Add(this.Finder);
			this.tabPage1.Controls.Add(this.rtfFont);
			this.tabPage1.Location = new System.Drawing.Point(4, 4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(611, 328);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "TXT";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// richTextBox1
			// 
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.Location = new System.Drawing.Point(3, 24);
			this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(605, 281);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// Finder
			// 
			this.Finder.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Finder.Location = new System.Drawing.Point(3, 305);
			this.Finder.Name = "Finder";
			this.Finder.SearchText = "";
			this.Finder.Size = new System.Drawing.Size(605, 20);
			this.Finder.TabIndex = 4;
			// 
			// rtfFont
			// 
			this.rtfFont.Dock = System.Windows.Forms.DockStyle.Top;
			this.rtfFont.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.rtfFont.FormattingEnabled = true;
			this.rtfFont.Location = new System.Drawing.Point(3, 3);
			this.rtfFont.Name = "rtfFont";
			this.rtfFont.Size = new System.Drawing.Size(605, 21);
			this.rtfFont.TabIndex = 3;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(445, 246);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "HEX";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(445, 246);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "IMG";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// lbtv
			// 
			this.lbtv.BackColor = System.Drawing.SystemColors.Window;
			this.lbtv.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbtv.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbtv.ForeColor = System.Drawing.SystemColors.Control;
			this.lbtv.Location = new System.Drawing.Point(0, 0);
			this.lbtv.Name = "lbtv";
			this.lbtv.Size = new System.Drawing.Size(619, 23);
			this.lbtv.TabIndex = 5;
			this.lbtv.Text = "ResUtil";
			this.lbtv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Arial", 6.5F);
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(12, 12);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.lbl_good});
			this.statusStrip1.Location = new System.Drawing.Point(0, 397);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(878, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lbl_good
			// 
			this.lbl_good.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lbl_good.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
			this.lbl_good.Enabled = false;
			this.lbl_good.Image = ((System.Drawing.Image)(resources.GetObject("lbl_good.Image")));
			this.lbl_good.Name = "lbl_good";
			this.lbl_good.Size = new System.Drawing.Size(102, 17);
			this.lbl_good.Text = "selection properties";
			// 
			// splitter3
			// 
			this.splitter3.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter3.Location = new System.Drawing.Point(0, 0);
			this.splitter3.Name = "splitter3";
			// 
			// splitter3.Panel1
			// 
			this.splitter3.Panel1.Controls.Add(this.toolstrip);
			// 
			// splitter3.Panel2
			// 
			this.splitter3.Panel2.Controls.Add(this.stat);
			this.splitter3.Panel2Collapsed = true;
			this.splitter3.Size = new System.Drawing.Size(878, 20);
			this.splitter3.SplitterDistance = 407;
			this.splitter3.TabIndex = 7;
			// 
			// toolstrip
			// 
			this.toolstrip.AutoSize = false;
			this.toolstrip.BackColor = System.Drawing.SystemColors.Window;
			this.toolstrip.Font = new System.Drawing.Font("Arial", 6.5F);
			this.toolstrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolstrip.ImageScalingSize = new System.Drawing.Size(12, 12);
			this.toolstrip.IsSolidBackground = false;
			this.toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsConfig,
									this.tsAddDLL,
									this.tsRemDLL,
									this.toolStripSeparator1,
									this.btn_types,
									this.toolStripSeparator2,
									this.tsUp,
									this.tsDown,
									this.toolStripSeparator3,
									this.btn_preview});
			this.toolstrip.Location = new System.Drawing.Point(0, 0);
			this.toolstrip.Name = "toolstrip";
			this.toolstrip.ShowItemToolTips = false;
			this.toolstrip.Size = new System.Drawing.Size(878, 20);
			this.toolstrip.TabIndex = 5;
			this.toolstrip.Text = "menuStrip1";
			// 
			// tsConfig
			// 
			this.tsConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btn_about,
									this.toolStripMenuItem2,
									this.btn_vres,
									this.btn_vprop,
									this.toolStripMenuItem1,
									this.btn_toggleFind});
			this.tsConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsConfig.Image")));
			this.tsConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.tsConfig.Name = "tsConfig";
			this.tsConfig.Size = new System.Drawing.Size(64, 18);
			this.tsConfig.Text = "Settings";
			// 
			// btn_about
			// 
			this.btn_about.Image = ((System.Drawing.Image)(resources.GetObject("btn_about.Image")));
			this.btn_about.Name = "btn_about";
			this.btn_about.Padding = new System.Windows.Forms.Padding(0);
			this.btn_about.Size = new System.Drawing.Size(134, 20);
			this.btn_about.Text = "About";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 6);
			// 
			// btn_vres
			// 
			this.btn_vres.Name = "btn_vres";
			this.btn_vres.Size = new System.Drawing.Size(134, 22);
			this.btn_vres.Text = "Resource View";
			// 
			// btn_vprop
			// 
			this.btn_vprop.Name = "btn_vprop";
			this.btn_vprop.Size = new System.Drawing.Size(134, 22);
			this.btn_vprop.Text = "Properties View";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
			// 
			// btn_toggleFind
			// 
			this.btn_toggleFind.Name = "btn_toggleFind";
			this.btn_toggleFind.Padding = new System.Windows.Forms.Padding(0);
			this.btn_toggleFind.Size = new System.Drawing.Size(134, 20);
			this.btn_toggleFind.Text = "Find (TXT)";
			// 
			// tsAddDLL
			// 
			this.tsAddDLL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btn_exe,
									this.btn_msstyle,
									this.btn_dll,
									this.toolStripMenuItem3,
									this.btn_loadExpo,
									this.toolStripMenuItem4,
									this.btn_exportXmlToolStripMenuItem,
									this.btn_exportXmlandDumpToolStripMenuItem,
									this.toolStripMenuItem5,
									this.exportImagesToolStripMenuItem});
			this.tsAddDLL.Image = ((System.Drawing.Image)(resources.GetObject("tsAddDLL.Image")));
			this.tsAddDLL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsAddDLL.Margin = new System.Windows.Forms.Padding(0);
			this.tsAddDLL.Name = "tsAddDLL";
			this.tsAddDLL.Size = new System.Drawing.Size(62, 20);
			this.tsAddDLL.Text = "w32.pe";
			// 
			// btn_exe
			// 
			this.btn_exe.Enabled = false;
			this.btn_exe.Name = "btn_exe";
			this.btn_exe.Padding = new System.Windows.Forms.Padding(0);
			this.btn_exe.Size = new System.Drawing.Size(186, 20);
			this.btn_exe.Text = "Add Executable";
			// 
			// btn_msstyle
			// 
			this.btn_msstyle.Enabled = false;
			this.btn_msstyle.Name = "btn_msstyle";
			this.btn_msstyle.Padding = new System.Windows.Forms.Padding(0);
			this.btn_msstyle.Size = new System.Drawing.Size(186, 20);
			this.btn_msstyle.Text = "Add MSStyle";
			// 
			// btn_dll
			// 
			this.btn_dll.Enabled = false;
			this.btn_dll.Name = "btn_dll";
			this.btn_dll.Padding = new System.Windows.Forms.Padding(0);
			this.btn_dll.Size = new System.Drawing.Size(186, 20);
			this.btn_dll.Text = "Add Dll Library";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(183, 6);
			// 
			// btn_loadExpo
			// 
			this.btn_loadExpo.Name = "btn_loadExpo";
			this.btn_loadExpo.Padding = new System.Windows.Forms.Padding(0);
			this.btn_loadExpo.Size = new System.Drawing.Size(186, 20);
			this.btn_loadExpo.Text = "Load Export\t(*.xml)";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(183, 6);
			// 
			// btn_exportXmlToolStripMenuItem
			// 
			this.btn_exportXmlToolStripMenuItem.Name = "btn_exportXmlToolStripMenuItem";
			this.btn_exportXmlToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.btn_exportXmlToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
			this.btn_exportXmlToolStripMenuItem.Text = "Export Xml (no dump)";
			// 
			// btn_exportXmlandDumpToolStripMenuItem
			// 
			this.btn_exportXmlandDumpToolStripMenuItem.Name = "btn_exportXmlandDumpToolStripMenuItem";
			this.btn_exportXmlandDumpToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.btn_exportXmlandDumpToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
			this.btn_exportXmlandDumpToolStripMenuItem.Text = "Export Xml (and dump data)";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(183, 6);
			// 
			// exportImagesToolStripMenuItem
			// 
			this.exportImagesToolStripMenuItem.Name = "exportImagesToolStripMenuItem";
			this.exportImagesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.exportImagesToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
			this.exportImagesToolStripMenuItem.Text = "Export Images";
			// 
			// tsRemDLL
			// 
			this.tsRemDLL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsRemDLL.Image = ((System.Drawing.Image)(resources.GetObject("tsRemDLL.Image")));
			this.tsRemDLL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsRemDLL.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.tsRemDLL.Name = "tsRemDLL";
			this.tsRemDLL.Size = new System.Drawing.Size(23, 18);
			this.tsRemDLL.Text = "Remove DLL";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 18);
			// 
			// btn_types
			// 
			this.btn_types.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_types.Image = ((System.Drawing.Image)(resources.GetObject("btn_types.Image")));
			this.btn_types.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_types.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.btn_types.Name = "btn_types";
			this.btn_types.Size = new System.Drawing.Size(23, 18);
			this.btn_types.Text = "GetTypes";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 18);
			// 
			// tsUp
			// 
			this.tsUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsUp.Enabled = false;
			this.tsUp.Image = ((System.Drawing.Image)(resources.GetObject("tsUp.Image")));
			this.tsUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsUp.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.tsUp.Name = "tsUp";
			this.tsUp.Size = new System.Drawing.Size(23, 18);
			this.tsUp.Text = "Up";
			// 
			// tsDown
			// 
			this.tsDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsDown.Enabled = false;
			this.tsDown.Image = ((System.Drawing.Image)(resources.GetObject("tsDown.Image")));
			this.tsDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsDown.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.tsDown.Name = "tsDown";
			this.tsDown.Size = new System.Drawing.Size(23, 18);
			this.tsDown.Text = "Down";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 18);
			// 
			// btn_preview
			// 
			this.btn_preview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_preview.Checked = true;
			this.btn_preview.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btn_preview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_preview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_preview.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.btn_preview.Name = "btn_preview";
			this.btn_preview.Size = new System.Drawing.Size(62, 18);
			this.btn_preview.Text = "auto-preview";
			// 
			// stat
			// 
			this.stat.Dock = System.Windows.Forms.DockStyle.Top;
			this.stat.Location = new System.Drawing.Point(0, 0);
			this.stat.Maximum = 65563;
			this.stat.Name = "stat";
			this.stat.Size = new System.Drawing.Size(96, 20);
			this.stat.TabIndex = 7;
			// 
			// ui_fx_frm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 419);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.splitter3);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "ui_fx_frm";
			this.Text = "uitheme:fx (resource.dll reader)";
			this.splitter1.Panel1.ResumeLayout(false);
			this.splitter1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitter1)).EndInit();
			this.splitter1.ResumeLayout(false);
			this.splitter2.Panel1.ResumeLayout(false);
			this.splitter2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitter2)).EndInit();
			this.splitter2.ResumeLayout(false);
			this.tab_left.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabctl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitter3.Panel1.ResumeLayout(false);
			this.splitter3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitter3)).EndInit();
			this.splitter3.ResumeLayout(false);
			this.toolstrip.ResumeLayout(false);
			this.toolstrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem exportImagesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.TabControl tab_left;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage4;
		public System.Windows.Forms.ToolStripMenuItem btn_loadExpo;
		public System.Windows.Forms.ToolStripMenuItem btn_exportXmlToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem btn_exportXmlandDumpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		public System.Cor3.Forms.SearchControl Finder;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		public System.Cor3.Forms.FontCombo rtfFont;
		public System.Windows.Forms.ToolStripMenuItem btn_about;
		public System.Windows.Forms.ToolStripMenuItem btn_toggleFind;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		public System.Windows.Forms.ToolStripButton btn_preview;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		public System.Windows.Forms.ToolStripMenuItem btn_exe;
		public System.Windows.Forms.ToolStripMenuItem btn_msstyle;
		public System.Windows.Forms.ToolStripMenuItem btn_dll;
		public System.Windows.Forms.TabControl tabctl;
		public System.Windows.Forms.SplitContainer splitter2;
		public System.Windows.Forms.SplitContainer splitter1;
		public System.Windows.Forms.SplitContainer splitter3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		public System.Windows.Forms.ProgressBar stat;
		public System.Windows.Forms.ImageList ilProp;
		public System.Windows.Forms.ImageList ilRes;
		public System.Windows.Forms.ToolStripStatusLabel lbl_good;
		public System.Windows.Forms.Label lbtv;
		public System.Windows.Forms.ToolStripMenuItem btn_vprop;
		public System.Windows.Forms.ToolStripMenuItem btn_vres;
		public System.Windows.Forms.TreeView tvRes;
		private System.Windows.Forms.PropertyGrid pg;
		public System.Windows.Forms.TreeView tvProperties;
		public System.Windows.Forms.ToolStripButton btn_types;
		private System.Windows.Forms.StatusStrip statusStrip1;
		#endregion

		public System.Windows.Forms.ToolStripButton tsRemDLL;
		public System.Windows.Forms.ToolStripSplitButton tsAddDLL;
		public System.Windows.Forms.ToolStripButton tsDown;
		public System.Windows.Forms.ToolStripButton tsUp;
		public System.Windows.Forms.ToolStripDropDownButton tsConfig;
		public System.Cor3.Forms.ToolStripExtender toolstrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}