using System;
using System.Data;

namespace media
{
	public class MediaData
	{
		public const string mi = "Music Info";
		static public DataSet ds;
		static public DataTable Table { get { return ds.Tables[mi]; } }

		static public void InitData()
		{
			ds = new DataSet();
			ds.Tables.Add(mi);
			Table.Columns.Add(new DataColumn("SongTitle",typeof(string)));
			Table.Columns.Add(new DataColumn("ArtistName",typeof(string)));
			Table.Columns.Add(new DataColumn("AlbumName",typeof(string)));
			Table.Columns.Add(new DataColumn("#",typeof(int)));
			Table.Columns.Add(new DataColumn("FileName",typeof(string)));
			//Table.Columns.Add(new DataColumn("Extension",typeof(string)));
			Table.Columns.Add(new DataColumn("Directory",typeof(string)));
		}
		static public void ClearInfo()
		{
			Table.Clear();
		}
		static public DataRow Add(string title,string aname,string alname,int trackn,string fname,string fdir)
		{
			return Table.Rows.Add(title==string.Empty?fname:title,aname,alname,trackn,fname,fdir);
		}
		static public DataRow Add(MediaFile file)
		{
			return Add( file.SongTitle, file.ArtistName, file.AlbumName, file.TrackNumber, file.FileName, file.FilePath );
		}
	}
}
