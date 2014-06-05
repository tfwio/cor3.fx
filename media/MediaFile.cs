using System;
namespace media
{
	public class MediaFile
	{
		internal protected string filePath,artistName,albumName,songTitle;
		internal protected int trackNumber;

		public System.IO.FileInfo FileInfo { get { return new System.IO.FileInfo(filePath); } }

		public string FilePath { get{return this.filePath;} set{this.filePath = value;} }
		public string Extension { get { return FileInfo.Extension; }  }
		public string FileName { get{return FileInfo.Name;} }

		public string ArtistName { get{return this.artistName;} set{this.artistName = value;} }
		public string AlbumName { get{return this.albumName;} set{this.albumName = value;} }
		public int TrackNumber { get{return this.trackNumber;} set{this.trackNumber = value;} }
		public string SongTitle { get{return this.songTitle;} set{this.songTitle = value;} }

		public MediaFile() { }
	}
}