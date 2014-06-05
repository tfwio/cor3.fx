/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.IO;

namespace System.Cor3.Forms.io
{
	public class FileReaderMan : FileReaderUtil
	{
		int buff_length = 128;
		//	Buffer Properties
		// =======================================
		public byte[] this[long start,int len]
		{
			get
			{
				if (this.Position!=start) Position = start;
				Global.cstat(ConsoleColor.Yellow,CheckLength(start,len));
				return br.ReadBytes(CalculateLength(start,len));
			}
		}
		public long PositionR { get { return buff_length; } set { UpdateLength(value); } }
		public long PositionB { get { return Position+buff_length; } }
		public long Position { get { return fs.Position; } set { UpdateBuffer(value); } }
		public int BufferSize { get { return buff_length; } set { buff_length = value; } }
		public int BufferSizeC { get { return (BufferExceeds)?(int)(LengthOfStream-Position):BufferSize; } }
		public bool BufferExceeds { get { return PositionB > LengthOfStream; } }
		public TeXan TeXBuffer { get { return new TeXan(this); } }
		//	Stream Properties
		// =======================================
		public long LengthOfStream { get { return fs.Length; } }
		//	Methods
		// =======================================
		public void UpdateBuffer(long value) { fs.Seek(value,SeekOrigin.Begin); }
		public void UpdateLength(long value) { fs.Seek(value,SeekOrigin.Begin); }
		bool CheckLength(long start, int len) { return (start+len) >= LengthOfStream; }
		int CalculateLength(long start, int len)
		{
			return (int)((CheckLength(start,len))?(LengthOfStream-start):len);
		}
		
		public FileReaderMan(string fname) : this(fname,256)
		{
		}
		public FileReaderMan(string fname, int buffersize) : base(fname)
		{
			this.File_reference = fname;
			BufferSize = buffersize;
		}
	}
}
