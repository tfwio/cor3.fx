/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Cor3;
using System.IO;

namespace w32.gdi
{

	/// for humans
	public class BmpFileHeader : object_manager<BITMAPFILEHEADER>
	{
		public string file_reference = string.Empty;
		public byte[] sel;
		public const string info_string =
			"File Name: {0}\n" +
			"Actual Size: {1}\n" +
			"id: {2}\n" +
			"size: {3}\n" +
			"offbits: {4}\n" +
			"HeaderLen (should be 40): {5}";
		public const string bmp_filter = "Microsoft Bitmap (*.bmp)|*.bmp";

		public bool FileExists { get { return File.Exists(file_reference); } }
		public FileInfo Info { get { return new FileInfo(file_reference); } }
		public long FileSize { get { return Info.Length; } }
		public string ansiID { get { return System.Text.Encoding.ASCII.GetString(BitConverter.GetBytes(Client.BMType)); } }

		byte[] bmp_byte_loader()
		{
			string str_f = ControlUtil.FGet(bmp_filter);
			if (str_f != string.Empty) return bmp_byte_loader (str_f);
			return null;
		}
		byte[] bmp_byte_loader(string file)
		{
			if(File.Exists(file))
			{
				file_reference = file;
				FileStream fs = new FileStream(file,FileMode.Open);
				byte[] rv = new byte[fs.Length];
				fs.Read(rv,0,rv.Length);
				fs.Close();
				fs.Dispose();
				return rv;
			}
			return null;
		}
		public void LoadBitmapHeader()
		{
			sel = bmp_byte_loader();
			Client = BITMAPFILEHEADER.CreateMemory(sel);
		}
		public BmpFileHeader(BITMAPFILEHEADER data) : base(data)
		{
		}
		public BmpFileHeader() : base()
		{
			LoadBitmapHeader();
		}
	
		public override string ToString()
		{
			return string.Format(
				info_string,
				Info.Name,
				FileSize,
				ansiID,
				(Client.SizeOfBmp),
				(Client.BitmapOffset),
				(Client.HeaderLength)
			);
		}
	}
	

}
