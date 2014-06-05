using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

using Cor3;
using w32.gdi;
using w32.user;

namespace w32.kernel
{
	////////////////////////////////////////////////////////////////////////////////
	public class BasicFileDialog
	{
		const string dll_ext = @"dll";
		const string sys_ux_dll = @"UXTheme or DLL file|*.uxtheme;*.dll;|All|*";
		const string sys_themes = @"c:/windows/resources/themes";
	
		static public OpenFileDialog Init(string title)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = title;
			ofd.Filter = sys_ux_dll;
			ofd.DefaultExt = dll_ext;
			ofd.InitialDirectory = sys_themes;
			ofd.RestoreDirectory = true;
			ofd.CustomPlaces.Clear();
			return ofd;
		}
		static public OpenFileDialog DoOpen(string msg) { return Init(msg); }
		static public OpenFileDialog DoOpen(string msg, string caption)
		{
			OpenFileDialog bfd = DoOpen(msg);
			bfd.Title = caption;
			return bfd;
		}
	}
}
