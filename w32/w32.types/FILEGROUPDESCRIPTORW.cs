using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

using w32.shell;
using w32.shell.contextmenu;

namespace w32
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public sealed class FILEGROUPDESCRIPTORW
	{
		public uint cItems;
		public FILEDESCRIPTORW[] fgd;
	}
}
