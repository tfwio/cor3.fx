/* oOo * 11/20/2007 : 4:41 PM */
using System;

namespace w32.shell
{
	public class _SHGFI
	{
		public const int SHGFI_LARGEICON			= 0x00000000;
		public const int SHGFI_SMALLICON			= 0x00000001;
		public const int SHGFI_OPENICON				= 0x00000002;
		public const int SHGFI_SHELLICONSIZE		= 0x00000004;
		public const int SHGFI_PIDL					= 0x00000008;
		public const int SHGFI_USEFILEATTRIBUTES	= 0x00000010;
		public const int SHGFI_ICON					= 0x00000100;
		public const int SHGFI_DISPLAYNAME			= 0x00000200;
		public const int SHGFI_TYPENAME				= 0x00000400;
		public const int SHGFI_ATTRIBUTES			= 0x00000800;
		public const int SHGFI_ICONLOCATION			= 0x00001000;
		public const int SHGFI_EXETYPE				= 0x00002000;
		public const int SHGFI_SYSICONINDEX			= 0x00004000;
		public const int SHGFI_LINKOVERLAY			= 0x00008000;
		public const int SHGFI_SELECTED				= 0x00010000;
		/// NTDDI_VERSION >= NTDDI_WIN2K
		public const int SHGFI_ATTR_SPECIFIED		= 0x00020000;
		/// <summary>
		/// just added this... Still have to look up the value
		/// </summary>
		public const int SHGFI_ADDOVERLAYS			= 0x00000020;
		public const int SHGFI_OVERLAYINDEX			= 0x00000040;
	}
	
	/// <summary>
	/// Used in ShellGetFileInfo() WINAPI
	/// Flags that specify file information to retrieve.
	/// </summary>
	[Flags] public enum SHGFI : int
	{
		/// Modify SHGFI_ICON, causing the function to retrieve the file's large icon. The SHGFI_ICON flag must also be set.
		LARGEICON			= _SHGFI.SHGFI_LARGEICON,
		/// Modify SHGFI_ICON, causing the function to retrieve the file's small icon. Also used to modify SHGFI_SYSICONINDEX, causing the function to return the handle to the system image list that contains small icon images. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
		SMALLICON			= _SHGFI.SHGFI_SMALLICON,
		/// Modify SHGFI_ICON, causing the function to retrieve the file's open icon. Also used to modify SHGFI_SYSICONINDEX, causing the function to return the handle to the system image list that contains the file's small open icon. A container object displays an open icon to indicate that the container is open. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
		OPENICON			= _SHGFI.SHGFI_OPENICON,
		/// Modify SHGFI_ICON, causing the function to retrieve a Shell-sized icon. If this flag is not specified the function sizes the icon according to the system metric values. The SHGFI_ICON flag must also be set.
		SHELLICONSIZE		= _SHGFI.SHGFI_SHELLICONSIZE,
		/// Indicate that pszPath is the address of an ITEMIDLIST structure rather than a path name.
		PIDL				= _SHGFI.SHGFI_PIDL,
		/// Indicates that the function should not attempt to access the file specified by pszPath. Rather, it should act as if the file specified by pszPath exists with the file attributes passed in dwFileAttributes. This flag cannot be combined with the SHGFI_ATTRIBUTES, SHGFI_EXETYPE, or SHGFI_PIDL flags.
		USEFILEATTRIBUTES	= _SHGFI.SHGFI_USEFILEATTRIBUTES,
		/// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list. The handle is copied to the hIcon member of the structure specified by psfi, and the index is copied to the iIcon member.
		ICON				= _SHGFI.SHGFI_ICON,
		/// Retrieve the display name for the file. The name is copied to the szDisplayName member of the structure specified in psfi. The returned display name uses the long file name, if there is one, rather than the 8.3 form of the file name.
		DISPLAYNAME			= _SHGFI.SHGFI_DISPLAYNAME,
		/// Retrieve the string that describes the file's type. The string is copied to the szTypeName member of the structure specified in psfi.
		TYPENAME			= _SHGFI.SHGFI_TYPENAME,
		/// Retrieve the item attributes. The attributes are copied to the dwAttributes member of the structure specified in the psfi parameter. These are the same attributes that are obtained from IShellFolder::GetAttributesOf.
		ATTRIBUTES			= _SHGFI.SHGFI_ATTRIBUTES,
		/// 
		ICONLOCATION		= _SHGFI.SHGFI_ICONLOCATION,
		/// Retrieve the type of the executable file if pszPath identifies an executable file. The information is packed into the return value. This flag cannot be specified with any other flags.
		EXETYPE				= _SHGFI.SHGFI_EXETYPE,
		/// Retrieve the index of a system image list icon. If successful, the index is copied to the iIcon member of psfi. The return value is a handle to the system image list. Only those images whose indices are successfully copied to iIcon are valid. Attempting to access other images in the system image list will result in undefined behavior.
		SYSICONINDEX		= _SHGFI.SHGFI_SYSICONINDEX,
		/// Modify SHGFI_ICON, causing the function to add the link overlay to the file's icon. The SHGFI_ICON flag must also be set.
		LINKOVERLAY			= _SHGFI.SHGFI_LINKOVERLAY,
		/// Modify SHGFI_ICON, causing the function to blend the file's icon with the system highlight color. The SHGFI_ICON flag must also be set.
		SELECTED			= _SHGFI.SHGFI_SELECTED,
		/// Modify SHGFI_ATTRIBUTES to indicate that the dwAttributes member of the SHFILEINFO structure at psfi contains the specific attributes that are desired. These attributes are passed to IShellFolder::GetAttributesOf. If this flag is not specified, 0xFFFFFFFF is passed to IShellFolder::GetAttributesOf, requesting all attributes. This flag cannot be specified with the SHGFI_ICON flag.
		ATTR_SPECIFIED		= _SHGFI.SHGFI_ATTR_SPECIFIED,
		/// just added this... Still have to look up the value
		OVERLAYINDEX		= _SHGFI.SHGFI_OVERLAYINDEX,
		/// just added this... Still have to look up the value
		ADDOVERLAYS			= _SHGFI.SHGFI_ADDOVERLAYS,
	}
}
