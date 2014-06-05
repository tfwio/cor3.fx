/**
 * 
 * tfw * 1/26/2009 * 1:29 AM
 * 
**/
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace efx.Forms.Controls
{
	public class DirectoryPanel : UserControl
	{
		public string DirValue { get { return tPath.Text; } set { tPath.Text = value; } }
		public string DirName { get { return (DirExists)?Path.GetDirectoryName(tPath.Text):"(directory not defined)"; } }
		public bool DirExists { get { return Directory.Exists(tPath.Text); } }

		public DirectoryPanel() : base()
		{
			InitializeComponent();
			this.btnBrowse.Click += eQuery;
		}

		FolderBrowserDialog fbd;
		public FolderBrowserDialog Fbd
		{
			get
			{
				if (fbd==null)
				{
					fbd = new FolderBrowserDialog();
					if (!DirExists) fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
					else fbd.SelectedPath = DirValue;
				}
				return fbd;
			} set { if (value==null) fbd.Dispose(); fbd = value; }
		}

		void eQuery(object sender, EventArgs val)
		{
			if (Fbd.ShowDialog()== DialogResult.OK) DirValue = fbd.SelectedPath;
			Fbd = null;
//	    	edSvc = (IWindowsFormsEditorService)GetService(typeof(IWindowsFormsEditorService));
		}

		#region Design
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
		System.ComponentModel.IContainer components = null;
		void InitializeComponent()
		{
			this.tPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tPath
			// 
			this.tPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.tPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.tPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tPath.Location = new System.Drawing.Point(0, 0);
			this.tPath.Name = "tPath";
			this.tPath.Size = new System.Drawing.Size(225, 20);
			this.tPath.TabIndex = 0;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnBrowse.Location = new System.Drawing.Point(225, 0);
			this.btnBrowse.Margin = new System.Windows.Forms.Padding(0);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(56, 20);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.Text = "&Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			// 
			// DirectoryPanel
			// 
			this.BackColor = System.Drawing.SystemColors.MenuBar;
			this.Controls.Add(this.tPath);
			this.Controls.Add(this.btnBrowse);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MaximumSize = new System.Drawing.Size(800, 20);
			this.MinimumSize = new System.Drawing.Size(120, 20);
			this.Name = "DirectoryPanel";
			this.Size = new System.Drawing.Size(281, 20);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		public System.Windows.Forms.Button btnBrowse;
		public System.Windows.Forms.TextBox tPath;
	}
}
