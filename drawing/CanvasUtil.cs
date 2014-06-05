/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/17/2007
 * Time: 2:42 AM
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace drawing.util
{

	public class CanvasUtil
	{
		public bool UseControlPadding = false, UsePadding = true;
		public Padding	ImagePadding = Padding.Empty, ControlPadding=Padding.Empty;
		public FloatPoint ClientSize;

		public Padding Padding { get { return (UseControlPadding)?ControlPadding:ImagePadding; } }
		public FloatPoint Pad { get { return new FloatPoint(Padding.Left+Padding.Right,Padding.Top+Padding.Bottom); } }
		public FloatPoint PaddedSize
		{
			get
			{
				if (!UsePadding) return ClientSize;
				if (Padding==Padding.Empty) return ClientSize;
				return ClientSize - Pad;
			}
		}
		public FloatPoint Center { get { return PaddedSize*0.5f; } }


		internal virtual void UpdateSize(object sender, EventArgs args)
		{
			Control ctl = ControlUtil.Obj2Ctl(sender);
			ControlPadding = ctl.Padding;
			ClientSize = ctl.ClientSize;
		}
		// Might want to disable these when the Control is not visible.
		public void ControlAttach(Control ctl) { ctl.SizeChanged += new EventHandler(UpdateSize); }
		public void ControlDetach(Control ctl) { ctl.SizeChanged -= new EventHandler(UpdateSize); }
		public CanvasUtil(Control ctl) { ClientSize = ctl.ClientSize; }
	}
}
