//
// Copyright © 2002-2004 Rui Godinho Lopes <rui@ruilopes.com>
// All rights reserved.
//
// This source file(s) may be redistributed unmodified by any means
// PROVIDING they are not sold for profit without the authors expressed
// written consent, and providing that this notice and the authors name
// and all copyright notices remain intact.
//
// Any use of the software in source or binary forms, with or without
// modification, must include, in the user documentation ("About" box and
// printed documentation) and internal comments to the code, notices to
// the end user as follows:
//
// "Portions Copyright © 2002-2004 Rui Godinho Lopes"
//
// An email letting me know that you are using it would be nice as well.
// That's not much to ask considering the amount of work that went into
// this.
//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED. USE IT AT YOUT OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//
using System;
using System.Drawing;
using System.Windows.Forms;

using efx.Forms.Controls;
namespace efx.Forms
{
	/// <para>Our test form for this sample application.  The bitmap will be displayed in this window.</para>
	public class MyPerPixelAlphaForm : PerPixelAlphaForm
	{
		public MyPerPixelAlphaForm()
		{
			TopMost = true;
			ShowInTaskbar = false;
		}
		// Let Windows drag this form for us
//		protected override void WndProc(ref Message m)
//		{
//			if (m.Msg == 0x0084 /*WM_NCHITTEST*/) {
//				m.Result= (IntPtr)2;	// HTCLIENT
//				return;
//			}
//			base.WndProc(ref m);
//		}
	}
}