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
	public class LoadLibFlags
	{
		// ms-help://MS.LHSMSSDK.1033/MS.LHSWinSDK.1033/dllproc/base/loadlibraryex.htm
		public const int DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
		public const int LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;
		public const int LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
		public const int LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040;
		public const int LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020;
		public const int LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008;
	}
		[Flags]
	/// ms-help://MS.LHSMSSDK.1033/MS.LHSWinSDK.1033/dllproc/base/loadlibraryex.htm
	public enum LOAD_LIB_FLAGS
	{
		/// <summary>
		/// <para>If you are planning only to access data or resources in the DLL, it is better to use LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE or LOAD_LIBRARY_AS_IMAGE_RESOURCE or both.</para>
		/// </summary>
		DONT_RESOLVE_DLL_REFERENCES = LoadLibFlags.DONT_RESOLVE_DLL_REFERENCES,
		/// <summary>
		/// <para>If this value is used, the system does not perform automatic trust comparisons on the DLL or its dependents when they are loaded.</para>
		/// Windows 2000:  This value is not supported.
		/// </summary>
		LOAD_IGNORE_CODE_AUTHZ_LEVEL = LoadLibFlags.LOAD_IGNORE_CODE_AUTHZ_LEVEL,
		/// <summary>
		/// <para>If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file. Nothing is done to execute or prepare to execute the mapped file. Therefore, you cannot call functions like GetModuleHandle or GetProcAddress with this DLL. Using this value causes writes to read-only memory to raise an access violation. Use this flag when you want to load a DLL only to extract messages or resources from it.</para>
		/// <para>This value can be used with LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.</para>
		/// </summary>
		LOAD_LIBRARY_AS_DATAFILE = LoadLibFlags.LOAD_LIBRARY_AS_DATAFILE,
		/// <summary>
		/// <para>Similar to LOAD_LIBRARY_AS_DATAFILE, except that the DLL file on the disk is opened for exclusive write access. Therefore, other processes cannot open the DLL file for write access while it is in use. However, the DLL can still be opened by other processes.</para>
		/// <para>This value can be used with LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.</para>
		/// <remarks>Windows Server 2003 and Windows XP/2000:  This value is not supported until Windows Vista.</remarks>
		/// </summary>
		LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = LoadLibFlags.LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE,
		/// <summary>
		/// <para>If this value is used, the system maps the file into the process's virtual address space as an image file. However, the loader does not load the static imports or perform the other usual initialization steps. Use this flag when you want to load a DLL only to extract messages or resources from it.</para>
		/// <para>Unless the application depends on the image layout, this value should be used with either LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE or LOAD_LIBRARY_AS_DATAFILE. For more information, see the Remarks section.</para>
		/// <remarks>Windows Server 2003 and Windows XP/2000:  This value is not supported until Windows Vista.</remarks>
		/// </summary>
		LOAD_LIBRARY_AS_IMAGE_RESOURCE = LoadLibFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE,
		
		LOAD_WITH_ALTERED_SEARCH_PATH = LoadLibFlags.LOAD_WITH_ALTERED_SEARCH_PATH,
	}

}
