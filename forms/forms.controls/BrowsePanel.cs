/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

namespace System.Cor3.Forms
{

	public delegate void ValueUpdateEvent(string value);
	
	/// <summary>
	/// This UserControl class is simply a configurable File-Browser
	/// panel.
	/// </summary>
	public class BrowsePanel : System.Windows.Forms.UserControl
	{
		OpenFileDialog ofd = new OpenFileDialog();
		SaveFileDialog sfd = new SaveFileDialog();
		
		protected virtual void OnValueUpdated(string value)
		{
			if (ValueUpdated != null) { ValueUpdated(value); }
		}
		public event ValueUpdateEvent ValueUpdated;
		
		
		string fileFilter = string.Empty;
		public string FileFilter { get { return fileFilter; } set { fileFilter = value; } }
		[
			System.ComponentModel.Browsable(false)
		] bool HasFileFilter { get { return !((FileFilter == string.Empty) && ( FileFilter == null )); } }
		
		bool browseEnabled = true;
		public bool BrowseEnabled {
			get { return browseEnabled; }
			set { browseEnabled = value; }
		}
		
		bool fixSize = true;
		[System.ComponentModel.Category("Design")]
		public bool FixSize { get { return fixSize; } set { fixSize = value; } }
		
		int BottomHeight
		{
			get
			{
				return tbInput.Location.Y + tbInput.Height + this.Padding.Bottom;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			//base.OnResize(e);
			if (FixSize)
			{
				this.Height = BottomHeight;
				btnBrowse.Height = this.lblCaption.Height + this.tbInput.Height;
			}
		}
		
		public bool IsDirectoryMode = false;
		public bool isSaveMode = false;

		public bool IsSaveMode { get { return isSaveMode; } set { isSaveMode = value; } }

		public string CaptionText
		{
			get { return lblCaption.Text; }
			set{ lblCaption.Text = value; }
		}
		public string TextBoxText
		{
			get { return tbInput.Text; }
			set { tbInput.Text = value; }
		}

		[
			System.ComponentModel.Browsable(false)
		] public bool HasValue { get { return TextBoxText!=null | TextBoxText != string.Empty; } }
		[
			System.ComponentModel.Browsable(false)
		] public bool Exists {
			get
			{
				if (!HasValue) return false;
				if (IsDirectoryMode) return Directory.Exists(TextBoxText);
				else return File.Exists(TextBoxText);
			}
		}
		[
			System.ComponentModel.Browsable(false)
		] public string CurrentDirectory
		{
			get {
				if (!Exists) return string.Empty;
				if (IsDirectoryMode) return Path.GetFullPath(TextBoxText);
				else return Directory.GetParent(TextBoxText).FullName;
			}
		} [
			System.ComponentModel.Browsable(false)
		] public bool CurrentDirExists { get { return Directory.Exists(CurrentDirectory); } }

		public string BrowseItem()
		{
			string titem = string.Empty;
			//  fileMode:
			//if (!Exists) return string.Empty;
			if (IsDirectoryMode) goto dirMode;
			if (!IsSaveMode)
			{
				if (HasValue && CurrentDirExists) ofd.InitialDirectory = CurrentDirectory;
				if (HasFileFilter) ofd.Filter = FileFilter;
				if (ofd.ShowDialog()== DialogResult.OK)
				{
					titem = ofd.FileName.Clone() as string;
				}
				
				ofd.Dispose(); ofd = null;
				return titem;
			}
			else
			{
				if (HasValue && CurrentDirExists) sfd.InitialDirectory = CurrentDirectory;
				if (HasFileFilter) sfd.Filter = FileFilter;
				if (sfd.ShowDialog()== DialogResult.OK)
				{
					titem = sfd.FileName.Clone() as string;
				}
				sfd.Dispose(); sfd = null;
				return titem;
			}
		dirMode:
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (HasValue&&CurrentDirExists) fbd.SelectedPath = CurrentDirectory;
			if (fbd.ShowDialog()== DialogResult.OK)
			{
				titem = fbd.SelectedPath.Clone() as string;
			}
			fbd.Dispose();
			fbd = null;
			return titem;
		}
		
		void eBrowseItem(object sender, EventArgs e)
		{
			if (!browseEnabled) return /*string.Empty*/;
			string tex = BrowseItem();
			if (tex!=string.Empty) TextBoxText = tex;
		}

		public BrowsePanel()
		{
			InitializeComponent();
			btnBrowse.Click += eBrowseItem;
			this.tbInput.TextChanged += delegate { OnValueUpdated(TextBoxText); };
		}
		#region System.System.Cor3.Forms.Design
		public void InitializeComponent()
		{
			this.tbInput = new System.Windows.Forms.TextBox();
			this.lblCaption = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbInput
			// 
			this.tbInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.tbInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbInput.Location = new System.Drawing.Point(6, 25);
			this.tbInput.Name = "tbInput";
			this.tbInput.Size = new System.Drawing.Size(315, 20);
			this.tbInput.TabIndex = 14;
			// 
			// lblCaption
			// 
			this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCaption.Location = new System.Drawing.Point(6, 6);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(394, 19);
			this.lblCaption.TabIndex = 16;
			this.lblCaption.Text = "Output File-Name";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnBrowse.Location = new System.Drawing.Point(321, 25);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(79, 21);
			this.btnBrowse.TabIndex = 15;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			// 
			// BrowsePanel
			// 
			this.AutoSize = true;
			this.Controls.Add(this.tbInput);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.lblCaption);
			this.Name = "BrowsePanel";
			this.Padding = new System.Windows.Forms.Padding(6);
			this.Size = new System.Drawing.Size(406, 52);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.Label lblCaption;
		#endregion
	}
}
