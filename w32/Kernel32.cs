using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

using Cor3;
using w32.gdi;
using w32.user;

namespace w32.kernel
{
////////////////////////////////////////////////////////////////////////////////
	public partial class Kernel32 : Win32
	{
		#region New
		[DllImport(kernl32)] static public extern IntPtr GlobalLock(IntPtr hMem);
		#endregion
	
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr BeginUpdateResource(string pFileName,[MarshalAs(UnmanagedType.Bool)]bool bDeleteExistingResources);
		[DllImport(kernl32,SetLastError=true),] static public extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

		[DllImport(kernl32,SetLastError=true),] static public extern void CopyMemory(IntPtr Destination, IntPtr Source, uint Length);
		[DllImport(kernl32,SetLastError=true),] static public extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);


		public delegate bool EnumResLangProc(/*HANDLE*/ IntPtr hModule,string lpszType,string lpszName,ushort wIDLanguage,/*LONG_PTR*/IntPtr lParam);
		public delegate bool EnumResLangLpProc(/*HANDLE*/ IntPtr hModule,IntPtr lpszType, IntPtr lpszName,ushort wIDLanguage,/*LONG_PTR*/IntPtr lParam);
		/// Enumerates language-specific resources, of the specified type and name, associated with a binary module.
		[DllImport(kernl32,SetLastError=true),] static public extern bool EnumResourceLanguages(IntPtr hModule, string lpszType,string lpName, EnumResLangProc lpEnumFunc, IntPtr lParam);
		[DllImport(kernl32,SetLastError=true),] static public extern bool EnumResourceLanguages(IntPtr hModule, IntPtr lpszType,IntPtr lpName, EnumResLangLpProc lpEnumFunc, IntPtr lParam);

		public delegate bool EnumResNameProc(IntPtr hModule,string lpszType,string lpszName,IntPtr lParam);
		public delegate bool EnumResNameLpProc(IntPtr hModule,IntPtr lpszType,IntPtr lpszName,IntPtr lParam);
		[DllImport(kernl32,SetLastError=true),] static public extern bool EnumResourceNames(IntPtr hModule,string lpszType,EnumResNameProc lpEnumFunc,IntPtr lParam);
		[DllImport(kernl32,SetLastError=true),] static public extern bool EnumResourceNames(IntPtr hModule,IntPtr lpszType,EnumResNameLpProc lpEnumFunc,IntPtr lParam);
		[DllImport(kernl32,SetLastError=true),] static public extern bool EnumResourceNamesEx(IntPtr hModule,string lpszType,EnumResNameProc lpEnumFunc,IntPtr lParam,Int32 dwFlags,UInt16 LANID);

		public delegate bool EnumResTypeProc(IntPtr hModule,/*LPTSTR*/ string lpszType, System.IntPtr lParam);
		public delegate bool EnumResTypeLpProc(IntPtr hModule,/*LPTSTR*/ IntPtr lpszType, System.IntPtr lParam);
		[DllImport(kernl32,SetLastError=true),] static public extern bool EnumResourceTypes(IntPtr hModule, EnumResTypeProc lpEnumFunc, IntPtr lParam);
		[DllImport(kernl32,SetLastError=true),] static public extern bool EnumResourceTypes(IntPtr hModule, EnumResTypeLpProc lpEnumFunc, IntPtr lParam);
	
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, string lpType);
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr FindResource(IntPtr hModule, string lpName, IntPtr lpType);
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr FindResource(IntPtr hModule, string lpName, string lpType);
		/// Since windows uses 'LocalAlloc' WINAPI, you should call LocalFree
		/// to free the memory stored in the 'buffer'
		[DllImport(kernl32,SetLastError=true),] static public extern int FormatMessage(int flags,IntPtr src,int msg_id,int lang_id, IntPtr buffer,int size, IntPtr va_opts);
		
		[DllImport(kernl32,SetLastError=true),] static public extern void FreeLibraryAndExitThread(IntPtr hModule, uint dwExitCode);
		[DllImport(kernl32,SetLastError=true),] static public extern bool FreeLibrary(IntPtr hModule);
		[DllImport(kernl32,SetLastError=true),] static public extern bool FreeResource(IntPtr hglbResource);

		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr LoadLibrary( string file );
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr LoadLibraryEx( string file, int reserved, int dwFlags );
		/// <summary>Frees the specified local memory object and invalidates its handle.</summary>
		/// <param name="hMem">A handle to the local memory object. This handle is returned by either the LocalAlloc or LocalReAlloc function. It is not safe to free memory allocated with GlobalAlloc.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NULL.</para>
		/// <para>
		/// If the function fails, the return value is equal to a handle to the local memory object. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr LocalFree(IntPtr hMem);

		[DllImport(user32,SetLastError=true),] static public extern IntPtr CopyImage(IntPtr hImage, uint uType, int cxDesired, int cyDesired, uint fuFlags);
		[DllImport(user32,SetLastError=true),] static public extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);
		[DllImport(user32,SetLastError=true),] static public extern IntPtr LoadImage(IntPtr hinst, IntPtr lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);
		[DllImport(kernl32,SetLastError=true),] static public extern IntPtr LockResource(IntPtr hResData);
		[DllImport(kernl32,SetLastError=true),] static public extern int SizeofResource(IntPtr hModule, IntPtr hResInfo);
		[DllImport(kernl32,SetLastError=true),] static public extern bool UpdateResource(IntPtr hUpdate, string lpType, string lpName, ushort wLanguage, IntPtr lpData, uint cbData);
	}
////////////////////////////////////////////////////////////////////////////////
}
