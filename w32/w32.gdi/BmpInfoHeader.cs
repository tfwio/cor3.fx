/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Cor3;
using System.Cor3.Forms.io;
using System.IO;
using System.Runtime.InteropServices;

namespace w32.gdi
{
	public class BmpInfoHeader : object_manager<BITMAPINFOHEADER>
	{
		public FileReaderUtil fru;
		string file_reference = string.Empty;
		public byte[] sel;
		public const string info_string = " size: {0}\n" +
			"w/h:  {1}x{2}\n" +
			"planes: {3}\n" +
			"bits: {4}\n" +
			"Compression {5}\n" +
			"SizeImage: {6}\n" +
			"PelsPerMeter(X,Y) {7}x{8}\n" +
			"ClrUsed: {9}\n" +
			"ClrImportant {10}";
		void Cls()
		{
			if (sel!=null)
			{
				Array.Clear(sel,0,sel.Length);
				sel = null;
			}
		}
		byte[] LoadData(string file)
		{
			return LoadData(file,false);
		}
		byte[] LoadData(string file, bool raw)
		{
			if (file==null || !File.Exists(file)) return null;
			file_reference = file;
			Cls();
			int length = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
			if(File.Exists(file_reference))
			{
				using (fru = new FileReaderUtil(file_reference))
				{
					fru.fs.Seek(raw?0:14,SeekOrigin.Begin);
					sel = fru.br.ReadBytes(length);
				}
			}
			return sel;
		}
		public BmpInfoHeader(string file) : this(file,false)
		{
		}
		public BmpInfoHeader(string file, bool raw) : base()
		{
			sel = LoadData(file,raw);
			Client = BITMAPINFOHEADER.CreateMemory(sel);
		}
		public override string ToString()
		{
			return string.Format(
				info_string,
				Client.biSize,Client.biWidth,Client.biHeight,
				Client.biPlanes,Client.biBitCount,Client.biCompression,
				Client.biSizeImage,Client.biXPelsPerMeter,Client.biYPelsPerMeter,
				Client.biClrUsed,Client.biClrImportant
			);
			//return base.ToString();
		}
	}
}
