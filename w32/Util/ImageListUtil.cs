using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using w32.kernel;
using w32.user;

namespace Cor3
{
	public class ImageListUtil : Kernel32
	{
		public delegate IntPtr ImageList_GetIconDelegate(IntPtr hList, int index, int flags);
		public delegate int ImageList_GetImageCountDelegate(IntPtr hList);
		public static ImageList_GetIconDelegate ImageList_GetIcon;
		public static ImageList_GetImageCountDelegate ImageList_GetImageCount; 
		public ImageListUtil()
		{
			// Retrieve entrypoints in side-by-side loaded comctl32.dll
			Process prc = Process.GetCurrentProcess();
			foreach (ProcessModule module in prc.Modules)
			{
				if (module.FileName.EndsWith("comctl32.dll"))
				{
					IntPtr hModule = LoadLibrary(module.FileName);
					if (hModule == IntPtr.Zero) throw new ApplicationException("Could not load required DLL");
					try {
						IntPtr addr = GetProcAddress(hModule, "ImageList_GetIcon");
						if (addr == IntPtr.Zero) throw new ApplicationException("Could not retrieve required entrypoint");
						ImageList_GetIcon = (ImageList_GetIconDelegate)
						Marshal.GetDelegateForFunctionPointer(addr, typeof(ImageList_GetIconDelegate));
						addr = GetProcAddress(hModule, "ImageList_GetImageCount");
						if (addr == IntPtr.Zero) throw new ApplicationException("Could not retrieve required entrypoint");
						ImageList_GetImageCount = (ImageList_GetImageCountDelegate)
						Marshal.GetDelegateForFunctionPointer(addr, typeof(ImageList_GetImageCountDelegate));
					}
					finally { FreeLibrary(hModule); }
					return;  // We're happy
				}
			}
			throw new ApplicationException("Required DLL not found");
			} 
	}
}
