/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

using Cor3;
using drawing;
using drawing.types;
using fam3;

namespace drawing.forms.controls
{
	/// <summary>
	/// Another Scaffolding Utility
	/// </summary>
	public class ListImageThumbs
	{
		public delegate void AssertUpdate(int index);
		
		public event AssertUpdate ThumbsUpdated;
		
		protected virtual void OnThumbsUpdated(int index) { if (ThumbsUpdated != null) ThumbsUpdated(index); }
		
		public DICT<FileInfo,Bitmap> Thumbnails = new DICT<FileInfo, Bitmap>();
		
		bool HasThumb(FileInfo Key) { return Thumbnails.ContainsKey(Key); }
		
		FloatPoint InterpolMax = new FloatPoint(300);
		
		public FloatPoint NodeSize = new FloatPoint(140,140);
		
		public FloatPoint ThumbSize = new FloatPoint(128);
		
		public DirectoryInfo DInfo;
		public List<FileInfo> Files;
		public List<FileInfo> QueryFiles
		{
			get
			{
				List<FileInfo> list = new List<FileInfo>();
				if (DInfo.GetFiles().Length==0) return list;
				foreach (FileInfo fi in DInfo.GetFiles())
				{
					if (fi.Extension==".jpg") list.Add(fi);
					if (fi.Extension==".png") list.Add(fi);
					if (fi.Extension==".bmp") list.Add(fi);
					if (fi.Extension==".cur") list.Add(fi);
					if (fi.Extension==".gif") list.Add(fi);
				}
				return list;
			}
		}
		
		public string ImagePath;
		static public bool IsRunning = false;
	}
}
