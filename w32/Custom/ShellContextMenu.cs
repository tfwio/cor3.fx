using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using w32.shell.platform;
using w32.user;

namespace w32.shell.contextmenu
{

	/// <summary>
	/// "Stand-alone" shell context menu
	/// 
	/// It isn't really debugged but is mostly working.
	/// Create an instance and call ShowContextMenu with a list of FileInfo for the files.
	/// Limitation is that it only handles files in the same directory but it can be fixed
	/// by changing the way files are translated into PIDLs.
	/// 
	/// Based on FileBrowser in C# from CodeProject
	/// http://www.codeproject.com/useritems/FileBrowser.asp
	/// 
	/// Hooking class taken from MSDN Magazine Cutting Edge column
	/// http://msdn.microsoft.com/msdnmag/issues/02/10/CuttingEdge/
	/// 
	/// Andreas Johansson
	/// afjohansson@hotmail.com
	/// http://afjohansson.spaces.live.com
	/// </summary>
	/// <example>
	///	ShellContextMenu scm = new ShellContextMenu();
	///	FileInfo[] files = new FileInfo[1];
	///	files[0] = new FileInfo(@"c:\windows\notepad.exe");
	///	scm.ShowContextMenu(this.Handle, files, Cursor.Position);
	/// </example>
	public class ShellContextMenu
	{
		private static Guid IID_IShellFolder = new Guid(_iid.IID_IShellFolder);
		private static Guid IID_IContextMenu = new Guid(_iid.IID_IContextMenu);
		private static Guid IID_IContextMenu2 = new Guid(_iid.IID_IContextMenu2);
		private static Guid IID_IContextMenu3 = new Guid(_iid.IID_IContextMenu3);

		private const int MAX_PATH = 260;
		private const uint CMD_FIRST = 1;
		private const uint CMD_LAST = 30000;
		private const int S_OK = 0;
		private const int S_FALSE = 1;

		private static int cbInvokeCommand = Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX));
		//./////////////////////////////////////////////////////////////////////
		private IContextMenu _oContextMenu;
		private IContextMenu2 _oContextMenu2;
		private IContextMenu3 _oContextMenu3;
		private IShellFolder _oDesktopFolder;
		private IShellFolder _oParentFolder;
		private IntPtr[] _arrPIDLs;
		private string _strParentFolder;
		//./////////////////////////////////////////////////////////////////////

	
		/// <summary>Gets the interfaces to the context menu</summary>
		/// <param name="oParentFolder">Parent folder</param>
		/// <param name="arrPIDLs">PIDLs</param>
		/// <returns>true if it got the interfaces, otherwise false</returns>
		private bool GetContextMenuInterfaces(IShellFolder oParentFolder, IntPtr[] arrPIDLs)
		{
			IntPtr pUnknownContextMenu = IntPtr.Zero;
	
			int nResult = oParentFolder.GetUIObjectOf(
				IntPtr.Zero,
				(uint)arrPIDLs.Length,
				arrPIDLs,
				ref IID_IContextMenu,
				IntPtr.Zero,
				out pUnknownContextMenu
			);
	
			if (S_OK == nResult)
			{
				_oContextMenu = (IContextMenu)Marshal.GetTypedObjectForIUnknown(pUnknownContextMenu, typeof(IContextMenu));
	
				IntPtr pUnknownContextMenu2 = IntPtr.Zero;
				if (S_OK == Marshal.QueryInterface(pUnknownContextMenu, ref IID_IContextMenu2, out pUnknownContextMenu2))
				{
					_oContextMenu2 = (IContextMenu2)Marshal.GetTypedObjectForIUnknown(pUnknownContextMenu2, typeof(IContextMenu2));
				}
				IntPtr pUnknownContextMenu3 = IntPtr.Zero;
				if (S_OK == Marshal.QueryInterface(pUnknownContextMenu, ref IID_IContextMenu3, out pUnknownContextMenu3))
				{
					_oContextMenu3 = (IContextMenu3)Marshal.GetTypedObjectForIUnknown(pUnknownContextMenu3, typeof(IContextMenu3));
				}
	
				return true;
			}
			else
			{
				return false;
			}
		}
	
		private void InvokeCommand(IContextMenu oContextMenu, uint nCmd, string strFolder, Point pointInvoke)
		{
			CMINVOKECOMMANDINFOEX invoke = new CMINVOKECOMMANDINFOEX();
			invoke.cbSize = cbInvokeCommand;
			invoke.lpVerb = (IntPtr)(nCmd - CMD_FIRST);
			invoke.lpDirectory = strFolder;
			invoke.lpVerbW = (IntPtr)(nCmd - CMD_FIRST);
			invoke.lpDirectoryW = strFolder;
			invoke.fMask = CMIC.UNICODE | CMIC.PTINVOKE |
				((Control.ModifierKeys & Keys.Control) != 0 ? CMIC.CONTROL_DOWN : 0) |
				((Control.ModifierKeys & Keys.Shift) != 0 ? CMIC.SHIFT_DOWN : 0);
			invoke.ptInvoke = new POINT(pointInvoke.X, pointInvoke.Y);
			invoke.nShow = SW.SHOWNORMAL;
			
			oContextMenu.InvokeCommand(ref invoke);
		}
	
		/// <summary>
		/// Release all allocated interfaces, PIDLs 
		/// </summary>
		private void ReleaseAll()
		{
			if (null != _oContextMenu)
			{
				Marshal.ReleaseComObject(_oContextMenu);
				_oContextMenu = null;
			}
			if (null != _oContextMenu2)
			{
				Marshal.ReleaseComObject(_oContextMenu2);
				_oContextMenu2 = null;
			}
			if (null != _oContextMenu3)
			{
				Marshal.ReleaseComObject(_oContextMenu3);
				_oContextMenu3 = null;
			}
			if (null != _oDesktopFolder)
			{
				Marshal.ReleaseComObject(_oDesktopFolder);
				_oDesktopFolder = null;
			}
			if (null != _oParentFolder)
			{
				Marshal.ReleaseComObject(_oParentFolder);
				_oParentFolder = null;
			}
			if (null != _arrPIDLs)
			{
				FreePIDLs(_arrPIDLs);
				_arrPIDLs = null;
			}
		}
	
		/// <summary>
		/// Gets the desktop folder
		/// </summary>
		/// <returns>IShellFolder for desktop folder</returns>
		private IShellFolder GetDesktopFolder()
		{
			IntPtr pUnkownDesktopFolder = IntPtr.Zero;
	
			if (null == _oDesktopFolder)
			{
				// Get desktop IShellFolder
				int nResult = Shell32.SHGetDesktopFolder(out pUnkownDesktopFolder).ToInt32();
				if (S_OK != nResult)
				{
					throw new ShellContextMenuException("Failed to get the desktop shell folder");
				}
				_oDesktopFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(pUnkownDesktopFolder, typeof(IShellFolder));
			}
	
			return _oDesktopFolder;
		}
	
		/// <summary>
		/// Gets the parent folder
		/// </summary>
		/// <param name="folderName">Folder path</param>
		/// <returns>IShellFolder for the folder (relative from the desktop)</returns>
		private IShellFolder GetParentFolder(string folderName)
		{
			if (null == _oParentFolder)
			{
				IShellFolder oDesktopFolder = GetDesktopFolder();
				if (null == oDesktopFolder)
				{
					return null;
				}
	
				// Get the PIDL for the folder file is in
				IntPtr pPIDL = IntPtr.Zero;
				uint pchEaten = 0;
				SFGAO pdwAttributes = 0;
				int nResult = oDesktopFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, folderName, ref pchEaten, out pPIDL, ref pdwAttributes);
				if (S_OK != nResult)
				{
					return null;
				}
	
				IntPtr pStrRet = Marshal.AllocCoTaskMem(MAX_PATH * 2 + 4);
				Marshal.WriteInt32(pStrRet, 0, 0);
				nResult = _oDesktopFolder.GetDisplayNameOf(pPIDL, SHGNO.FORPARSING, pStrRet);
				StringBuilder strFolder = new StringBuilder(MAX_PATH);
				Shell32.StrRetToBuf(pStrRet, pPIDL, strFolder, MAX_PATH);
				Marshal.FreeCoTaskMem(pStrRet);
				pStrRet = IntPtr.Zero;
				_strParentFolder = strFolder.ToString();
	
				// Get the IShellFolder for folder
				IntPtr pUnknownParentFolder = IntPtr.Zero;
				nResult = oDesktopFolder.BindToObject(pPIDL, IntPtr.Zero, ref IID_IShellFolder, out pUnknownParentFolder);
				// Free the PIDL first
				Marshal.FreeCoTaskMem(pPIDL);
				if (S_OK != nResult)
				{
					return null;
				}
				_oParentFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(pUnknownParentFolder, typeof(IShellFolder));
			}
	
			return _oParentFolder;
		}
	
		/// <summary>
		/// Get the PIDLs
		/// </summary>
		/// <param name="arrFI">Array of FileInfo</param>
		/// <returns>Array of PIDLs</returns>
		protected IntPtr[] GetPIDLs(FileInfo[] arrFI)
		{
			if (null == arrFI || 0 == arrFI.Length)
			{
				return null;
			}
	
			IShellFolder oParentFolder = GetParentFolder(arrFI[0].DirectoryName);
			if (null == oParentFolder)
			{
				return null;
			}
	
			IntPtr[] arrPIDLs = new IntPtr[arrFI.Length];
			int n = 0;
			foreach (FileInfo fi in arrFI)
			{
				// Get the file relative to folder
				uint pchEaten = 0;
				SFGAO pdwAttributes = 0;
				IntPtr pPIDL = IntPtr.Zero;
				int nResult = oParentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, fi.Name, ref pchEaten, out pPIDL, ref pdwAttributes);
				if (S_OK != nResult)
				{
					FreePIDLs(arrPIDLs);
					return null;
				}
				arrPIDLs[n] = pPIDL;
				n++;
			}
	
			return arrPIDLs;
		}
	
		/// <summary>
		/// Free the PIDLs
		/// </summary>
		/// <param name="arrPIDLs">Array of PIDLs (IntPtr)</param>
		protected void FreePIDLs(IntPtr[] arrPIDLs)
		{
			if (null != arrPIDLs)
			{
				for (int n = 0; n < arrPIDLs.Length; n++)
				{
					if (arrPIDLs[n] != IntPtr.Zero)
					{
						Marshal.FreeCoTaskMem(arrPIDLs[n]);
						arrPIDLs[n] = IntPtr.Zero;
					}
				}
			}
		}
	
		private void InvokeContextMenuDefault(FileInfo[] arrFI)
		{
			// Release all resources first.
			ReleaseAll();
	
			IntPtr pMenu = IntPtr.Zero;
	
			try
			{
				_arrPIDLs = GetPIDLs(arrFI);
				if (null == _arrPIDLs)
				{
					ReleaseAll();
					return;
				}
	
				if (false == GetContextMenuInterfaces(_oParentFolder, _arrPIDLs))
				{
					ReleaseAll();
					return;
				}
	
				pMenu = User32.CreatePopupMenu();
	
				int nResult = _oContextMenu.QueryContextMenu(
					pMenu,
					0,
					CMD_FIRST,
					CMD_LAST,
					CMF.DEFAULTONLY |
					((Control.ModifierKeys & Keys.Shift) != 0 ? CMF.EXTENDEDVERBS : 0));
	
				uint nDefaultCmd = (uint)User32.GetMenuDefaultItem(pMenu, false, 0);
				if (nDefaultCmd >= CMD_FIRST)
				{
					InvokeCommand(_oContextMenu, nDefaultCmd, arrFI[0].DirectoryName, Control.MousePosition);
				}
	
				User32.DestroyMenu(pMenu);
				pMenu = IntPtr.Zero;
			}
			catch
			{
				throw;
			}
			finally
			{
				if (pMenu != IntPtr.Zero)
				{
					User32.DestroyMenu(pMenu);
				}
				ReleaseAll();
			}
		}
	
		/// <summary>
		/// Shows the context menu
		/// </summary>
		/// <param name="handleOwner">Window that will get messages</param>
		/// <param name="arrFI">FileInfos (should all be in same directory)</param>
		/// <param name="pointScreen">Where to show the menu</param>
		public void ShowContextMenu(IntPtr handleOwner, FileInfo[] arrFI, Point pointScreen)
		{
			// Release all resources first.
			ReleaseAll();
	
			IntPtr pMenu = IntPtr.Zero;
			LocalWindowsHook hook = new LocalWindowsHook(HookType.WH_CALLWNDPROC);
			hook.HookInvoked += new LocalWindowsHook.HookEventHandler(WindowsHookInvoked);
	
			try
			{
				//Application.AddMessageFilter(this);
	
				_arrPIDLs = GetPIDLs(arrFI);
				if (null == _arrPIDLs)
				{
					ReleaseAll();
					return;
				}
	
				if (false == GetContextMenuInterfaces(_oParentFolder, _arrPIDLs))
				{
					ReleaseAll();
					return;
				}
				
				pMenu = User32.CreatePopupMenu();
	
				int nResult = _oContextMenu.QueryContextMenu(
					pMenu,
					0,
					CMD_FIRST,
					CMD_LAST,
					CMF.EXPLORE |
					CMF.NORMAL |
					((Control.ModifierKeys & Keys.Shift) != 0 ? CMF.EXTENDEDVERBS : 0));
	
				hook.Install();
	
				uint nSelected = User32.TrackPopupMenuEx(
					pMenu,
					TPM.RETURNCMD,
					pointScreen.X,
					pointScreen.Y,
					handleOwner,
					IntPtr.Zero);
	
				User32.DestroyMenu(pMenu);
				pMenu = IntPtr.Zero;
	
				if (nSelected != 0)
				{
					InvokeCommand(_oContextMenu, nSelected, _strParentFolder, pointScreen);
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				hook.Uninstall();
				if (pMenu != IntPtr.Zero)
				{
					User32.DestroyMenu(pMenu);
				}
				ReleaseAll();
			}
		}
		
		/// <summary>
		/// Handle messages for context menu
		/// </summary>
		private void WindowsHookInvoked(object sender, HookEventArgs e)
		{
			CWPSTRUCT cwp = (CWPSTRUCT)Marshal.PtrToStructure(e.lParam, typeof(CWPSTRUCT));
			
			if (_oContextMenu2 != null &&
				(cwp.message == (int)WM.INITMENUPOPUP ||
				 cwp.message == (int)WM.MEASUREITEM ||
				 cwp.message == (int)WM.DRAWITEM))
			{
				if (_oContextMenu2.HandleMenuMsg((uint)cwp.message, cwp.wparam, cwp.lparam) == S_OK)
				{
					return;
				}
			}
	
			if (_oContextMenu3 != null && cwp.message == (int)WM.MENUCHAR)
			{
				if (_oContextMenu3.HandleMenuMsg2((uint)cwp.message, cwp.wparam, cwp.lparam, IntPtr.Zero) == S_OK)
				{
					return;
				}
			}
	
			return;
		}
	
		/// <summary>Default constructor</summary>
		public ShellContextMenu()
		{
		}
		/// <summary>Ensure all resources get released</summary>
		~ShellContextMenu()
		{
			ReleaseAll();
		}
	
	}








}
