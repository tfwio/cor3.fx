#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Diagnostics;

namespace efx
{
	#region ConsoleUtil
	public class ConsoleUtility
	{
		static public ConsoleColor[] CClr(params ConsoleColor[] clr) { return clr; }
	
		#region CSTAT
		[Conditional("CONSOLE")] public static void Cls(){Console.Clear();}
		[Conditional("CONSOLE")] static void colorstat(ConsoleColor clr, string filter, object data) { colorstat(true,clr,filter,data); }
		[Conditional("CONSOLE")] static void colorstat(bool endl,ConsoleColor clr, string filter, object data)
		{
			Console.ForegroundColor=clr;
			//if (filter==null) filter="{0}";
			Console.Write(
				string.Format(
					filter,
					data
				)
			);
			if (endl) Console.Write('\n');
		}
		[Conditional("CONSOLE")] public static void cstat(ConsoleColor clr, string filter, params object[] data) { colorstat(true,clr,filter,data); }
		[Conditional("CONSOLE")] public static void cstat(ConsoleColor clr, params object[] data) { colorstat(true,clr,"{0}",data);}
		[Conditional("CONSOLE")] public static void cstat(ConsoleColor[] clr, string filter, params object[] data) { cstat(true,clr,new string[]{filter},data);}
		[Conditional("CONSOLE")] public static void cstat(bool endl, ConsoleColor[] clr, string[] filter, params object[] data)
		{
			ConsoleColor clx = Console.ForegroundColor;
			int i=0,j=0;
			foreach (object obj in data) {
				string fltr;
				if (j<filter.Length) fltr=filter[j];
				else fltr = filter[filter.Length-1];
				colorstat(false, clr[i],fltr,obj);
				if (j < filter.Length-1) j++;
				if (i < clr.Length-1) i++;
			}
			if (endl) Console.Write('\n');
			Console.ForegroundColor=clx;
		}
		#endregion
		#region STAT
		public static void stat(string filter, object data)
		{
			#if (CONSOLE)
			Console.WriteLine(string.Format(filter,new object[] {data})); return;
			#endif
			PlugIns.Opoo.Main.pop(string.Format(filter,new object[] {data}));
		}
		public static void stat(bool endl, string filter, params object[] data)
		{
			#if (CONSOLE)
			Console.Write(string.Format(filter,data));
			if (endl) Console.Write('\n');
			#endif
	//.FIXME
			PlugIns.Opoo.Main.pop(string.Format(filter,data),false);
		}
		public static void stat(string filter, params object[] data) { stat(true,filter,data);}
		public static void stat(object msg) { Console.WriteLine(msg); }
		public static void stat(string msg, bool Activate) { stat(false,"{0}",new object[]{msg}); PlugIns.Opoo.Main.pop(msg,Activate); }
		#endregion

		public enum clx : uint { r=0xF00,y=0xFF0,g=0x0F0,c=0x0FF,b=0x00F,m=0xF0F,gray=0x777,W=0xFFF,  }
		public enum cly : uint { r=ConsoleColor.Red,y=ConsoleColor.Yellow,g=ConsoleColor.Green,c=ConsoleColor.Cyan,b=ConsoleColor.Blue,m=(uint)ConsoleColor.Magenta,gr=(uint)ConsoleColor.Gray,w=(uint)ConsoleColor.White }
		public uint[] mo = new uint[] {
			(uint)ConsoleColor.Red,(uint)ConsoleColor.Yellow,(uint)ConsoleColor.Green,
			(uint)ConsoleColor.Cyan, (uint)ConsoleColor.Blue,(uint)ConsoleColor.Magenta,
			(uint)ConsoleColor.Gray,(uint)ConsoleColor.White,
		};
	}
	#endregion
}
