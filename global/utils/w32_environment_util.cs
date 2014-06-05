/* oOo * 11/19/2007 : 8:00 AM */
using System;
using System.IO;

namespace Cor3
{
	public class w32_environment_util
	{
		static public string AppEnvironmentPath
		{
			get
			{
				return ((string)System.Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.Process)).TrimEnd(';');
			}
			set
			{
				if (!Directory.Exists(value)) return;
				System.Environment.SetEnvironmentVariable("PATH",value,EnvironmentVariableTarget.Process);
			}
		}
		static public void AddPath(string path)
		{
			if (!Directory.Exists(path)) return;
			AppEnvironmentPath = string.Format("{0};{1}",AppEnvironmentPath,path.TrimEnd(';'));
		}
	}
}
