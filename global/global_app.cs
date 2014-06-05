#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Reflection;
using System.Windows.Forms;

namespace efx
{
	public class global_app : global_shell_util
	{
		public static string _ver = "needs to be re-organized/written";
		public static string AppPath = System.IO.Path.GetDirectoryName( Application.ExecutablePath );
		/// <summary>loads a given assembly</summary>
		public class AssemblyLoader<TAsm>
		{
			/// <summary>test the dll to see if the file is in fact a plugin.</summary>
			static public void IsAsm(string filename)
			{
				Assembly asm = Assembly.LoadFile(filename);
				MessageBox.Show(asm.FullName);
				asm = null;
			}
			/// <summary>load the assembly into the global Plugin Dictionary.</summary>
			static public TAsm Asm(string filename,string baseclass)
			{
				Assembly asm = Assembly.LoadFile(filename);
				Global.cstat(ConsoleColor.Green,asm);
				return (TAsm)asm.CreateInstance(asm.GetName().Name+"."+baseclass);
				//AsmType.FullName->Namespace
			}
			/// <summary>load the assembly into the global Plugin Dictionary.</summary>
			static public TAsm Asm(Type AsmType)
			{
				return (TAsm)Assembly.GetExecutingAssembly().CreateInstance(AsmType.FullName);
				//AsmType.FullName->Namespace
			}
		}
	}
}
