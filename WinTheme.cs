#region User/License
// oio * 8/14/2012 * 9:18 PM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
#endregion
using System;
using System.Windows.Forms;

namespace System
{
	partial class WindowsInterop
	{
		/// <summary>
		/// Transclude this class (File-&gt;Link).
		/// </summary>
		class WindowsTheme
		{
			const int BS_COMMANDLINK	= 0x0000000E;
			const int BCM_SETNOTE			= 0x00001609;
			// see article ‘Fully Themed Windows Vista Controls’ for implementation detail
			const int BS_SPLITBUTTON	= 0x0000000C;
//		const int BS_COMMANDLINK = 0x0000000E;
			static public void HandleTheme(Control controlWithHandle)
			{
				SetWindowTheme(controlWithHandle.Handle, "explorer", null);
				if (controlWithHandle is TreeView)
				{
					(controlWithHandle as TreeView).HotTracking = true;
					(controlWithHandle as TreeView).FullRowSelect = true;
				}
			}
			
			
			[System.Runtime.InteropServices.DllImport("user32.dll",CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
			static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);
			
			/// <summary>
			/// Native interop method, be sure to include the  System.Runtime.InteropServices
			/// name space
			/// </summary>
			/// <param name="hWnd"></param>
			/// <param name="appName"></param>
			/// <param name="partList"></param>
			/// <returns></returns>
			[System.Runtime.InteropServices.DllImport("uxtheme.dll",CharSet = System.Runtime.InteropServices.CharSet.Unicode,ExactSpelling = true)]
			private static extern int SetWindowTheme(IntPtr hWnd, string appName, string partList);
		}
	}
}
