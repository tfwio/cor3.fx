using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

using w32.shell;
using w32.shell.contextmenu;

namespace w32
{
	public sealed class ole32
	{
		[DllImport("ole32.dll", PreserveSig = false)]
		public static extern ILockBytes CreateILockBytesOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease);
	
		
		[DllImport("OLE32.DLL", CharSet = CharSet.Auto, PreserveSig = false)]
		public static extern IntPtr GetHGlobalFromILockBytes(ILockBytes pLockBytes);
	
		[DllImport("OLE32.DLL", CharSet = CharSet.Unicode, PreserveSig = false)]
		public static extern IStorage StgCreateDocfileOnILockBytes(ILockBytes plkbyt, uint grfMode, uint reserved);
	
	}
}
