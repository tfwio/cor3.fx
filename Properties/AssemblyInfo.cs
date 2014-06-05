#region Using directives

using System;
using System.Reflection;
using System.Runtime.InteropServices;

#endregion


[assembly: AssemblyTitle("System.Cor3.Fx")]
[assembly: AssemblyDescription("A old mess of utilities and forms" +
	"that simply haven't a place to go?\r\n" +
	"Too many Windows System Calls are exposed ? for teh record.")]
[assembly: AssemblyProduct("System.Cor3.Fx")]

[assembly: ComVisible(false)]
	static class res
	{
		public const string err_pe_load = "you've got to select a PE file (root tree-node)";
		public const string err_arg_filter = "arg: '{0}' didn't exist";
	}
