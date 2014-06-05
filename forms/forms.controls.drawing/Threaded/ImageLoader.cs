/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Utilities.SuperOld;
using System.IO;
using System.Windows.Forms;

namespace drawing.forms.controls
{
	/// <summary>
	/// This class is used to create and load thumb-nails.
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// This class SHOULD take advantage of the CsShellFile item's ability
	/// to obtain an icon for a particular Shell-File (but doesn't).
	/// </remarks>
	public class ImageLoader
	{
		public delegate void AssertUpdate(int index);
		
		#region Properties
		// static public bool IsRunning = false;
		
		public Control Client;
		public string ImagePath;
		
		public event AssertUpdate ThumbsUpdated;
		readonly object threadLock = new object();
		
		/// <summary>
		/// This is the main thumbnail dictionary where images are stored.
		/// </summary>
		public DICT<FileInfo,Bitmap> Thumbnails = new DICT<FileInfo, Bitmap>();
		
		// Node
		public HPoint NodeSize = new HPoint(140,140);
		public HPoint ThumbSize = new HPoint(128);
		public HPoint RowSize { get { return new HPoint(Client.ClientSize)/NodeSize; } }
		Point PSize { get { return RowSize; } }
		
		FloatPoint InterpolMax = new FloatPoint(300);

		#endregion
		#region Files
		
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
		
		#endregion
		#region Thumb
		
		/// <summary>
		/// When triggered, indicates that a thumbnail image is ready for rendering.
		/// </summary>
		/// <param name="index"></param>
		protected virtual void OnThumbsUpdated(int index)
		{
			if (ThumbsUpdated != null)
				ThumbsUpdated(index);
		}
		
		void ReadImages(FloatPoint sizeRequest)
		{
			Global.cstat(ConsoleColor.Green,"Loading Thumbnails {0}",sizeRequest);
			
			foreach (FileInfo fi in Files)
			{
				if (Thumbnails.ContainsKey(fi)) Thumbnails[fi].Dispose();
				if (Thumbnails.ContainsKey(fi)) Thumbnails[fi] = null;
			}
			
			Thumbnails.Clear();
			
			int incr = 0;
			
			foreach (FileInfo fi in Files)
			{
				#if (CONSOLE)
				Global.stat("loading {0}",fi.Name);
				#endif
				System.Diagnostics.Debug.Print("loading {0}",fi.Name);
				
				using (Bitmap targetBitmap=new Bitmap(fi.FullName))
				{
//					try { targetBitmap = new Bitmap(fi.FullName); }
//					catch { targetBitmap = new Bitmap(famfam_silky.error); }
					
					// is this necessary?
					//Application.DoEvents();
					
					Point targetSize = FloatPoint.Fit(
						sizeRequest,
						targetBitmap.Size,
						2
					);
					
					if (targetSize.X <= 0) targetSize = sizeRequest;
					if (targetSize.Y <= 0) targetSize = sizeRequest;
					
					Bitmap renderBitmap = new Bitmap(targetSize.X,targetSize.Y);
					
					using (Graphics g = Graphics.FromImage(renderBitmap))
					{
						g.HighQuality	(InterpolMax,targetBitmap);
						g.Clear			(Color.Black);
						g.DrawImage		(targetBitmap,0,0,targetSize.X,targetSize.Y);
						
						lock (threadLock)
						{
							try
							{
								Thumbnails.Add(fi,renderBitmap);
							}
							catch (Exception exception)
							{
								System.Diagnostics.Debug.Print("{0}",exception);
							}
						}
					}
				}
				
				OnThumbsUpdated(incr++);
			}
		}
		
		#endregion
		
		public ImageLoader(string path, Point newSize, bool waitForThreadStart, AssertUpdate eHandler)
		{
			ImagePath = path;
			NodeSize = newSize;
			if (!waitForThreadStart) BeginLoading();
			ThumbsUpdated -= eHandler;
			ThumbsUpdated += eHandler;
		}
		
		#region Misc Functions

		public void GetInfo(bool begin)
		{
			ReadFileInformaion(ImagePath,NodeSize,begin);
		}
		
		void ReadFileInformaion(string path, Point newSize, bool readImages)
		{
			DInfo = new DirectoryInfo(path);
			Files = QueryFiles;
			
			Global.cstat(ConsoleColor.Yellow,NodeSize);
			
			if (readImages) ReadImages(newSize);
		}
		
		/// <summary>
		/// Apparently this is used as our thread starting point.
		/// </summary>
		public void BeginLoading()
		{
			ReadFileInformaion(ImagePath,NodeSize,true);
		}
		
		#endregion
		#region Hidden Stuff
		// public TransformLocation Tl;
		// static Random rd = new Random();
		// System.Windows.Forms.Timer t2;
		#endregion
	}

}
