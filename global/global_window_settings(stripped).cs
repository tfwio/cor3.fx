#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;

using efx.Design;
using efx.Environment.Namespace;
using efx.Forms.Main;

namespace efx
{
	// FIXME: Strip these features and create specialized Form implementation.
	// Stripped: global_window<efx_dlg,TAsm>
	public class global_window_settings<TAsm> : global_window<Form,TAsm>
	{
		
		public static string windowconfigfile { get { return Path.Combine(GlobalSettings.app_data_efx,@"\cfg.cfg"); } }

		static GlobalSettings wSettings = null;

		[Category("App"),Description("Application Defined Window Settings."),EditorAttribute(typeof(UITypeEditor),typeof(UITypeEditor)),TypeConverter(typeof(ConstantCollectionConverter))]
		static public GlobalSettings WindowSettings { get { return GlobalSettings.Generate(); } set { wSettings = value; } }
		static public void WindowConfigurationFile()
		{
			if (!System.IO.File.Exists(windowconfigfile)) return;
			GlobalSettings ws  = new GlobalSettings(windowconfigfile);
			if (ws.IsMaximized)
			{
				AppForm.SetBounds(ws.RestoreBounds.X,ws.RestoreBounds.Y,ws.RestoreBounds.Width,ws.RestoreBounds.Height,BoundsSpecified.All);
				AppForm.WindowState = FormWindowState.Maximized;
			}
			else
			{
				AppForm.WindowState = FormWindowState.Normal;
				AppForm.SetBounds(ws.RestoreBounds.X,ws.RestoreBounds.Y,ws.RestoreBounds.Width,ws.RestoreBounds.Height,BoundsSpecified.All);
			}
			//Globe.Lib.Call();
			AppForm.Refresh();
			AppForm.Visible = true;
		}
		static public void WinKill()
		{
			WindowSettings.Save(windowconfigfile);
		}
	
		static bool isfullscreen;
		static public bool FullScreenMode { get { return isfullscreen; } set { isfullscreen=WindowMode(value); } }
	
		static bool WindowMode(bool value)
		{
			if (value)
			{
				AppForm.FormBorderStyle = FormBorderStyle.None;
				AppForm.WindowState = FormWindowState.Maximized;
			}
			else
			{
				AppForm.FormBorderStyle = FormBorderStyle.Sizable;
				AppForm.WindowState = FormWindowState.Normal;
			}
			return value;
		}
	}
}
