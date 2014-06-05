/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.IO;

namespace System.Cor3.Forms.io
{
	delegate void TextControlFileLoaded(TeXan sector);

	public class FileReaderUtil : IDisposable
	{
		public FileStream fs;
		public BinaryReader br;
		byte[] data;
		public string file_reference = string.Empty;
		public bool HasFile { get { return File.Exists(file_reference); } }

		virtual public string File_reference
		{
			get { return file_reference; }
			set { file_reference = LoadFile(value); }
		}
		virtual public byte[] Data { get { return data; } set { data = value; } }

		virtual public string LoadFile(string file)
		{
			if (!File.Exists(file)) return string.Empty;
			if (fs!=null) fs.Dispose();
			fs = new FileStream(file,FileMode.Open);
			br = new BinaryReader(fs);
			return file;
		}

		public FileReaderUtil(string file)
		{
			File_reference = file;
		}
		~FileReaderUtil() { Dispose(); }

		public void Dispose()
		{
			file_reference = string.Empty;
			fs.Close();
			br.Close();
			fs.Dispose();
			if (data!=null) Array.Clear(data,0,data.Length);
			data = null;
		}
	}
}
