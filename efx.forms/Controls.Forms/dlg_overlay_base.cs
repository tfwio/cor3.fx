/** tfw * 5/15/2008.10:44 AM **/

using System;
using System.Drawing;
using System.Windows.Forms;

using Drawing;
using Drawing.Forms.Controls;
using w32;

namespace efx.Forms.Controls
{
	/// <summary>empty overlay crap for use in 'PerPixel Forms'</summary>
	public class dlg_overlay_base : MovableDlg, IOverlay
	{
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button button1;

		#region ' Bitmap bmp '
		Bitmap bmp = spl_rc.pike;
		#endregion
		#region ' dlg_splash _spl '
		dlg_splash _spl;
		#endregion
		#region ' bool _showbtn '
		bool _showbtn = true;
		#endregion
		#region ' Bitmap Bitmap '
		virtual public Bitmap Bitmap { get {return bmp;} set {bmp = value;} }
		#endregion
		#region ' bool ButtonVisible '
		public bool ButtonVisible { get { return _showbtn; } set { _showbtn = value; } }
		#endregion
		#region ' dlg_splash Spl '
		public dlg_splash Spl { get { return _spl; } set { _spl=value; } }
		#endregion

		public dlg_overlay_base() { Initialize(); }

		#region ' IOverlay Create '
		/// <summary>
		/// Don't know why this is static.</br>
		/// It's only known use is in dlg_splash (during initialization).</summary>
		public static IOverlay Create() { return new dlg_overlay_base(); }
		#endregion
		#region ' void Initialize '
		public void Initialize()
		{
			BackColor = System.Drawing.Color.FromArgb(251,250,247);
			TransparencyKey = System.Drawing.Color.FromArgb(251,250,247);

			if (!alldone) InitializeComponent();
			alldone = true;

			this.label1.Text = efx.Globe.GetAsmNfoStr();
			draw();
		}
		#endregion
		#region ' void SplInit '
		public void SplInit() { SplInit(Spl); }
		public void SplInit(efx.Forms.Controls.dlg_splash splash)
		{
			Spl = splash;
			bmp = Spl.bmpbase;
			this.Width = bmp.Width; this.Height = bmp.Height;
			Spl.Move += delegate { Location=splash.Location; };
			MouseUp += delegate(object sender, MouseEventArgs e) { Spl.doup(e); };
			MouseDown += delegate(object sender, MouseEventArgs e) { Spl.dodown(e); };
			MouseMove += delegate(object sender, MouseEventArgs e) { Spl.domove(e); };

			panel1.MouseUp += delegate(object sender, MouseEventArgs e) { Spl.doup(e); };
			panel1.MouseDown += delegate(object sender, MouseEventArgs e) { Spl.dodown(e); };
			panel1.MouseMove += delegate(object sender, MouseEventArgs e) { Spl.domove(e); };

			this.button1.Click += delegate {
				Spl.Dispose();
				this.Dispose();
			};
			this.Disposed += delegate {
				Spl.Dispose(); this.Dispose();
			};
			Location = Location;
			Win32.SetWindowPos(Spl.Handle,(IntPtr)w32_const.HWND_TOPMOST,new Rectangle(new Point(Width,Height),Size),WindowFlags.SWP_SHOWWINDOW);
			Win32.SetWindowPos(Handle,(IntPtr)w32_const.HWND_TOPMOST/*Spl.Handle*/,new Rectangle(new Point(Width,Height),Size),WindowFlags.SWP_SHOWWINDOW);
			Show(Spl);
		}
		#endregion
		#region ' void draw '
		public void draw() { //rc_draw.pike
			Globe.stat("OverlayBase : draw()");
			bmp = new Bitmap(bmp.Width,bmp.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics bb = Graphics.FromImage(bmp);
			bb.Clear(BackColor);
			HPoint b = new HPoint(panel1.Location);
			Globe.stat(b.ToString());
			bb.DrawImage(bmp,-b);
			panel1.BackColor = BackColor;
			panel1.BackgroundImage = bmp;
			if (Spl!=null) Location=Spl.Location;
		}
		#endregion

		#region ' form designer '
		
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
			this.label1.Location = new System.Drawing.Point(12, 12);
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
			// dlg_overlay_base
			// 
			this.AcceptButton = this.button1;
			this.ClientSize = new System.Drawing.Size(240, 165);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "dlg_overlay_base";
			this.Padding = new System.Windows.Forms.Padding(12);
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion

	}
}
