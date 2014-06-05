/** tfw * 5/15/2008.10:44 AM **/

using System;
using System.Drawing;
using System.Windows.Forms;

using Drawing;
using Drawing.Forms.Controls;
using w32;

namespace efx.Forms.Controls
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class OverlayBase : MovableDlg, IOverlay
	{
		static Color default_color = Color.FromArgb(251,250,247);

		bool _showbtn = true;
		public bool ButtonVisible { get { return _showbtn; } set { _showbtn = value; } }

		Bitmap bmp = spl_rc.pike;
		virtual public Bitmap Bitmap { get {return bmp;} set {bmp = value;} }

		FormSplash _spl;
		public FormSplash Spl { get { return _spl; } set { _spl=value; } }

		public static IOverlay Create() { return new OverlayBase(); }

		public OverlayBase() { Initialize(); }

		public void Initialize()
		{
			BackColor = default_color;
			TransparencyKey = default_color;
			if (!alldone) InitializeComponent(); alldone = true;
			this.label1.Text = String.Format(
				"{3} v{1}.{2} build {0}",
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build,
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major,
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor,
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
			);
			draw();
		}
		public void SplInit() { SplInit(Spl); }
		public void SplInit(efx.Forms.Controls.FormSplash splash)
		{
			Spl = splash;
			bmp = Spl.bmpbase; this.Width = bmp.Width; this.Height = bmp.Height;
			Win32.SetWindowPos(Spl.Handle,(IntPtr)w32_const.HWND_TOPMOST,new Rectangle(new Point(Width,Height),Size),WindowFlags.SWP_SHOWWINDOW);
			Win32.SetWindowPos(Handle,(IntPtr)w32_const.HWND_TOPMOST,new Rectangle(new Point(Width,Height),Size),WindowFlags.SWP_SHOWWINDOW);
			Spl.Show();
			Show(Spl);
			Spl.Move += delegate { Location=splash.Location; };
			panel1.MouseUp += delegate(object sender, MouseEventArgs e) { Spl.doup(e); };
			panel1.MouseDown += delegate(object sender, MouseEventArgs e) { Spl.dodown(e); };
			panel1.MouseMove += delegate(object sender, MouseEventArgs e) { Spl.domove(e); };
			this.button1.Click += delegate { Spl.Close(); (efx.Globe.App as Form ).Show(); this.Close(); };
			this.Disposed += delegate { Spl.Close(); (efx.Globe.App as Form ).Show(); this.Close(); };
		}

		protected override void OnShown(EventArgs e) { base.OnShown(e); }
		protected override void OnVisibleChanged(EventArgs e) { base.OnVisibleChanged(e); }
		protected override void OnMouseDown(MouseEventArgs e) { base.OnMouseDown(e); Spl.doup(e); }
		protected override void OnMouseMove(MouseEventArgs e) { base.OnMouseMove(e); Spl.doup(e); }
		protected override void OnMouseUp(MouseEventArgs e) { base.OnMouseUp(e); Spl.doup(e); }

		public void draw() {
			bmp = new Bitmap(bmp.Width,bmp.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics bb = Graphics.FromImage(bmp);
			bb.Clear(BackColor);
			HPoint b = new HPoint(panel1.Location);
			bb.DrawImage(bmp,-b);
			panel1.BackColor = BackColor;
			if (Spl!=null) Location=Spl.Location;
		}

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
		public override void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Location = new System.Drawing.Point(152, 89);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(61, 26);
			this.button1.TabIndex = 0;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(12, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(216, 118);
			this.panel1.TabIndex = 2;
			// 
			// OverlayBase
			// 
			this.ClientSize = new System.Drawing.Size(240, 165);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "OverlayBase";
			this.Padding = new System.Windows.Forms.Padding(12);
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button button1;
		#endregion
	}
}
