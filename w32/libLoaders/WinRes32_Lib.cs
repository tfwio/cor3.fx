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
    //http://www.codeproject.com/KB/miscctrl/XPTaskBar/XPExplorerBar_src_v3_3_VS2005.zip
    //http://www.codeproject.com/KB/miscctrl/XPTaskBar.aspx?fid=55377&df=90&mpp=25&noise=3&sort=Position&view=Quick&fr=226
    public class WinRes32_Lib : LibLoader2
    {
        
        List<string> FileData;
        public List<string> KeyNames;
        
        public string FileName
        {
            get {
                return lib_path;
            } set {
                lib_path = value;
            }
        } string lib_path = string.Empty;

        public WinRes32_Lib(string dllName) : base(dllName)
        {
            FileData = new List<string>();
            KeyNames = new List<string>();
        }
        ~WinRes32_Lib()
        {
            FileData.Clear();
            KeyNames.Clear();
            GC.Collect();
        }

        public string LoadAnsi(string key/*"#1"*/, string name/*UIFILE*/)
        {
            IntPtr hResource = FindResource(hModule,key,name);
            int resourceSize =  SizeofResource(hModule,hResource);
            IntPtr resourceData =  LoadResource(hModule,hResource);
            byte[] uiBytes = new byte[resourceSize];
            GCHandle gcHandle = GCHandle.Alloc(uiBytes, GCHandleType.Pinned);
            IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(uiBytes, 0);
            CopyMemory(firstCopyElement,resourceData,resourceSize);
            gcHandle.Free();
            FreeResource(resourceData);
            return Marshal.PtrToStringAnsi(firstCopyElement,resourceSize);
        }

        public Bitmap GetResourceBMP(string resourceName)
        {
            IntPtr hBitmap = User32.LoadBitmap(hModule, Int32.Parse(resourceName));
            Bitmap bitmap = Bitmap.FromHbitmap(hBitmap);
            return bitmap;
        }
		
        ///<summary>Returns a Png Bitmap from the currently loaded ShellStyle.dll</summary>
        public Bitmap GetResourcePNG(string resourceName)
        {
            // the resource size includes some header information
            const int FILE_HEADER_BYTES = 40;
            Bitmap tmpNoAlpha = Bitmap.FromResource (hModule, "#" + resourceName);

            IntPtr hResource =  this["#" + resourceName, (IntPtr) RC_ENUM.RT_BITMAP];
            int resourceSize =  SizeofResource (hModule, hResource);
            Bitmap bitmap = new Bitmap(tmpNoAlpha.Width,tmpNoAlpha.Height,PixelFormat.Format32bppArgb);

            IntPtr hLoadedResource =  LoadResource(hModule, hResource);
            byte[] bitmapBytes = new byte[resourceSize];
            GCHandle gcHandle = GCHandle.Alloc(bitmapBytes, GCHandleType.Pinned);

            IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(bitmapBytes, 0);
            CopyMemory (firstCopyElement, hLoadedResource, resourceSize);

            FreeResource (hLoadedResource);

            Rectangle copyArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData alphaBits = bitmap.LockBits(copyArea,ImageLockMode.WriteOnly,PixelFormat.Format32bppArgb);

            firstCopyElement =
                Marshal.UnsafeAddrOfPinnedArrayElement(
                    bitmapBytes,
                    FILE_HEADER_BYTES
                );
            CopyMemory (
                alphaBits.Scan0,
                firstCopyElement,
                resourceSize - FILE_HEADER_BYTES
            );

            gcHandle.Free ();
            bitmap.UnlockBits (alphaBits);
            Gdi32.GdiFlush ();
            // flip bits (not sure why this is needed at the moment..)
            bitmap.RotateFlip (RotateFlipType.RotateNoneFlipY);
            return bitmap;
        }
    }
}
