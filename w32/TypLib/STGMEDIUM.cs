using System;
using System.Runtime.InteropServices;

namespace w32.shell.contextmenu
{
	// A generalized global memory handle used for data transfer operations by the 
	// IAdviseSink, IDataObject, and IOleCache interfaces
	[StructLayout(LayoutKind.Sequential)]
	public struct STGMEDIUM
	{
	    public TYMED tymed;
	    public IntPtr hBitmap;
	    public IntPtr hMetaFilePict;
	    public IntPtr hEnhMetaFile;
	    public IntPtr hGlobal;
	    public IntPtr lpszFileName;
	    public IntPtr pstm;
	    public IntPtr pstg;
	    public IntPtr pUnkForRelease;
	}
}
