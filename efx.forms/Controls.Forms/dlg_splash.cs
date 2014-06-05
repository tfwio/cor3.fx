/*
 * Created by SharpDevelop.
 * User: tfooo
 * Date: 1/4/2007
 * Time: 2:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace efx.Forms.Controls
{
	/// <summary>
	/// Description of spl.
	/// </summary>
	public partial class dlg_splash : efx.Forms.Controls.PerPixelMovable /*//  System.Windows.Forms.Form/*/
	{
		bool _showbtn = true;
		public bool ButtonVisible { get { return _showbtn; } set { _showbtn = value; } }
		public void DoMove() { OnMove(null); }

		public dlg_overlay_base overlay;

		public dlg_splash() { }
		public dlg_splash(int color, Bitmap bmp, dlg_overlay_base over) {
			Visible = false;
			InitializeComponent();
			SetBitmap(bmp);
			overlay = over;
			if (over==null) {
				over = new dlg_overlay_base();
				overlay = over;
				over = dlg_overlay_base.Create() as dlg_overlay_base; overlay = over;
			}
			overlay.Initialize();
			overlay.Spl = this;
			overlay.SplInit(this);
			Visible = true;
			Graphics joe = Graphics.FromImage(bmp);
			joe.Clear(Color.FromArgb(color));
			joe.Dispose();
		}
		public dlg_splash(Bitmap bmp, dlg_overlay_base over) : base()
		{
			Visible = false;
			InitializeComponent();
			SetBitmap(bmp);
			overlay = over;
			if (over==null) {
				over = new dlg_overlay_base(); overlay = over;
				over = dlg_overlay_base.Create() as dlg_overlay_base; overlay = over;
			}
			overlay.Initialize();
			overlay.Spl = this;
			overlay.SplInit(this);
			Visible = true;
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			if (!(overlay).IsDisposed) (overlay).Dispose();
			base.OnClosing(e);
		}
		protected override void OnResize(EventArgs e)
		{
			if (overlay!=null) (overlay).Size = this.Size;
			base.OnResize(e);
		}
		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			if ((overlay)!=null && overlay.Visible) (overlay).Location = this.Location;
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}
		#region FormDesigner
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
			//Globe.stat("spl:Dispose(bool disposing)");
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			if (overlay !=null ) overlay.Dispose();
			base.Dispose(disposing);
		}
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		public override void InitializeComponent()
		{
			//Globe.stat("spl:InitializeComponent()");
			this.SuspendLayout();
			// 
			// spl
			// 
			this.ClientSize = new System.Drawing.Size(347, 119);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "spl";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "spl";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		#endregion
	}

}
