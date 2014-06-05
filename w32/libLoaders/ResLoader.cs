using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using Cor3;
using w32.gdi;
using w32.user;

namespace w32.kernel
{
	public enum ImageType
	{	//d:\dev\win\lib\Microsoft SDKs\WSDK\Include\winuser.h
		bitmap = 0,
		icon = 1,
		cursor = 2,
		srcbitmap = 3,
	}
	public enum ExportType
	{	//d:\dev\win\lib\Microsoft SDKs\WSDK\Include\winuser.h
		any,
		bitmap,
		png,
		icon,
		cursor,
		binary,
	}
	[Flags] public enum iflags
	{
		LR_DEFAULTCOLOR     = 0x00000000,
		LR_MONOCHROME       = 0x00000001,
		LR_COLOR            = 0x00000002,
		LR_COPYRETURNORG    = 0x00000004,
		LR_COPYDELETEORG    = 0x00000008,
		LR_LOADFROMFILE     = 0x00000010,
		LR_LOADTRANSPARENT  = 0x00000020,
		LR_DEFAULTSIZE      = 0x00000040,
		LR_VGACOLOR         = 0x00000080,
		LR_LOADMAP3DCOLORS  = 0x00001000,
		LR_CREATEDIBSECTION = 0x00002000,
		LR_COPYFROMRESOURCE = 0x00004000,
		LR_SHARED           = 0x00008000,
	}

	public class ResLoader : LibLoader2
	{
		static RT_STR rt;
		static public byte[] GetResData(object name, object type, ushort lang)
		{
			throw new NotImplementedException();
			//return null;
		}

		static public bool _isint(object o)
		{
			int i;
			if (int.TryParse(o.ToString(),out i)) return true;
			return false;
		}
		static public bool _isres(object o)
		{
			return RT_STR.has_value(o.ToString());
		}
		static public IntPtr _i(string o)
		{
			return new IntPtr(int.Parse(o));
		}
		/// assumes you allready checked if this is a resource id
		static public IntPtr _i(object o)
		{
			Global.cstat(ConsoleColor.Yellow,(RC_ENUM)RT_STR.get_int(o.ToString()));
			return new IntPtr(RT_STR.get_int(o.ToString()));
		}
		/// attempts to reverse restable to a newly found pointer
		static public IntPtr FindData(thought? rt) { return FindData(rt.GetValueOrDefault().loader,rt.GetValueOrDefault().table); }
		/// attempts to reverse restable to a newly found pointer
		static public IntPtr FindData(LibLoader2 lib, res_table tdata)
		{
			Mart type,name;
			IntPtr res;
			using (type = (_isres(tdata._t)) ? new Mart(_i(tdata._t),false) : new Mart(tdata.type,false,true))
			{
				using (name = (_isint(tdata._n)) ? new Mart(_i(tdata.name),false) : new Mart(tdata.name,false,true))
				{
//				nam = _isint(tdata._n) ? "#"+tdata.name : tdata.name;
				res = FindResource(lib.hModule,(IntPtr)name,(IntPtr)type);
//				Global.cstat(ConsoleColor.Green,"{0}:{1}",(IntPtr)type,nam);
				}
			}
			return res;
		}
		static public byte[] FindData(LibLoader2 lib, res_table tdata, bool tobyte)
		{
			IntPtr res = FindData(lib,tdata);
			int siz = SizeofResource(lib.hModule,res);
			byte[] newmemory = new byte[siz];
			IntPtr lr = LoadResource(lib.hModule,res);
			IntPtr lo = LockResource(lr);
			using (Mart newmem = new Mart(new byte[siz]))
			{
				Kernel32.CopyMemory((IntPtr)newmem,lo,siz);
				newmemory = newmem.GetByteData(siz);
			}
			FreeResource(lr);
			lr = IntPtr.Zero;
//			Global.cstat(ConsoleColor.Green,"{0}:{1}",(IntPtr)type,nam);
			return newmemory;
		}
		static public IntPtr FindData(LibLoader2 lib, res_table tdata, ImageType tobyte)
		{
			IntPtr hImage;
			IntPtr res = FindData(lib,tdata);
			IntPtr lr = LoadResource(lib.hModule,res);
			IntPtr lo = LockResource(lr);
			using (Mart name = (_isint(tdata._n)) ? new Mart(_i(tdata.name),false) : new Mart(tdata.name,false,true))
			{
				if (tobyte== ImageType.bitmap) 
				{
					hImage = User32.LoadBitmap(lib.hModule,(IntPtr)name);
				}
				else if (tobyte== ImageType.srcbitmap) 
				{
					Bitmap bmp = Bitmap.FromResource(lib.hModule,name);
					hImage = bmp.GetHbitmap();
					//hImage = User32.LoadBitmap(lib.hModule,(IntPtr)name);
					//hImage = LoadImage(lib.hModule,(IntPtr)name,(uint)tobyte,0,0,(uint)iflags.LR_COPYFROMRESOURCE);
				}
				else hImage = LoadImage(lib.hModule,(IntPtr)name,(uint)tobyte,0,0,(uint)iflags.LR_VGACOLOR);
			}
			FreeResource(lr);
			return hImage;
		}
		static public IntPtr FindData(int width, int height, LibLoader2 lib, res_table tdata, ImageType tobyte)
		{
			IntPtr hImage;
			IntPtr res = FindData(lib,tdata);
			IntPtr lr = LoadResource(lib.hModule,res);
			IntPtr lo = LockResource(lr);
			using (Mart name = (_isint(tdata._n)) ? new Mart(_i(tdata.name),false) : new Mart(tdata.name,false,true))
			{
				if (tobyte== ImageType.bitmap) 
				{
					hImage = User32.LoadBitmap(lib.hModule,(IntPtr)name);
				}
				else if (tobyte== ImageType.srcbitmap) 
				{
					//hImage = User32.LoadBitmap(lib.hModule,(IntPtr)name);
					hImage = LoadImage(lib.hModule,(IntPtr)name,(uint)tobyte,width,height,(uint)iflags.LR_COPYFROMRESOURCE);
				}
				else hImage = LoadImage(lib.hModule,(IntPtr)name,(uint)tobyte,0,0,(uint)iflags.LR_VGACOLOR);
			}
			FreeResource(lr);
			return hImage;
		}
//		static public IntPtr FindData(LibLoader2 lib, res_table tdata)
//		{
//			Mart type;
//			string nam;
//			IntPtr res;
//			using (type = (_isres(tdata._t)) ? new Mart(_i(tdata._t),false) : new Mart(tdata.type+"\0",false)) {
//				nam = _isint(tdata._n) ? "#"+tdata.name+"\0": tdata.name+"\0";
//				IntPtr libr = LoadLibrary(lib.LibraryPath);
//				res = FindResource(libr,(IntPtr)type,nam);
//			}
//			return res;
//		}

		static public byte[] GetResData(res_table tdata)
		{
			throw new NotImplementedException();
		}
		static public byte[] GetResData(string name, object type, ushort lang)
		{
			throw new NotImplementedException();
			//return null;
		}
		static public byte[] GetResData(string name, string type, ushort lang)
		{
			throw new NotImplementedException();
			//return null;
		}
		static public byte[] GetResData(string name, RC_ENUM type, ushort lang)
		{
			throw new NotImplementedException();
			//return null;
		}

		//http://www.codeproject.com/KB/miscctrl/XPTaskBar.aspx?fid=55377&df=90&mpp=25&noise=3&sort=Position&view=Quick&fr=226
		public string LoadAnsi(string key/*"#1"*/, string name/*UIFILE*/)
		{
			IntPtr hResource = this[key,name];
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
			BitmapData alphaBits = bitmap.LockBits(
				copyArea,
				ImageLockMode.WriteOnly,
				PixelFormat.Format32bppArgb
			);

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
		public ResLoader(string lib_path) : base(lib_path) { EnumTypes(); }

	}
}
