/** tfw * 2/14/2008.4:31 PM **/
using System;
namespace efx.Utility
{
	public class CmdParse
	{
		public static void ckCommands(string[] args)
		{
			if (args!=null) 
			{
				foreach (string arg in args)
				{
				//.	UNDONE: !!!CHECK AGAINST GLOBAL EXTENSIONS!!!
					if (FileUtil.FInfo(arg)!=null)
						switch (FileUtil.FInfo(arg).Extension.ToLower())
						{
							case ".vdproject": Globe.DocMan.OpenWorkspace(arg);break;
							case ".efx-proj": Globe.DocMan.OpenWorkspace(arg);break;
							default: efx.Globe.Plug("Scintilla").Create(arg);break;
						}
				}
			}
		}
	}
}
