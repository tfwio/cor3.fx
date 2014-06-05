#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Collections.Generic;
using iface;

namespace efx
{

	public class efx_global_plughost : global_window_settings<IExt>
	{
		public static PluginDic Plugins;
		public IExt this[string Key] { get { return Plugins[Key]; } }
		static public IExt Plug(string Title) { return Plugins[Title]; }

		/// <summary>
		/// 'Main' by default.<br/>
		/// Override this class to reset.
		/// </summary>
		static internal string plug_main = "Main";

		public static string PlgPath = System.IO.Path.Combine(AppPath,"Plugins");

		static public Type[] PluginTypes
		{
			get
			{
				return new Type[]
				{
					typeof(PlugIns.WinDesktop.Main),
					typeof(PlugIns.DockView.Main),
					typeof(PlugIns.Opoo.Main),
					typeof(PlugIns.SciPlugin.Main),
					typeof(RichEdit.Main),
					typeof(PlugIns.Imager.Main),
					typeof(PlugIns.GalleryThing.Main),
					typeof(GenWav.Main),
					typeof(sndlib.midi.Main),
				//	typeof(PlugIns.SkyboundGecko.Main)
					/*typeof(PlugIns.fmodlib.Main),*/
					/*,typeof(PlugIns.CSFlex.Main)*/
				};
			}
		}

		public class PluginDic : DICT<string,IExt>
		{
			public PluginDic() { }
			public void AddRange(params Type[] path_collection)
			{
				foreach(Type exte in path_collection) 
				{
					IExt extension = Loader.Asm(exte);
					Add(extension.Info.Title,extension);
					AlignEvent( extension );
				}
			}
			public void AddRange(params string[] path_collection)
			{
				foreach(string path in path_collection) 
				{
					IExt extension = Loader.Asm(path,plug_main);
					Add(extension.Info.Title,extension);
					AlignEvent( extension );
				}
			}
			void AlignEvent(IExt ext)
			{
				Globe.AppForm.ActMain -= ext.OnMainEvent;
				Globe.AppForm.ActMain += ext.OnMainEvent;
			}
			void AlignEvents(MainEvent mevent)
			{
				foreach (KeyValuePair<string,IExt> kvp in this)
					kvp.Value.AlignEvent(mevent);
			}
		}
		static public string GetOwner(string Title)
		{
			if (Plugins.ContainsKey(Title)) return (Title!=string.Empty) ? Plugins[Title].Info.Title : string.Empty;
			return string.Empty;
		}
	}
}
