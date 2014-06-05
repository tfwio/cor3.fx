using System;

namespace w32.shell
{
	public class SH_ID3
	{
		public const int SIZE			= 1;
		public const int ARTIST_NAME	= 9;
		public const int SONG_TITLE		= 10;
		public const int COMMENT		= 14;
		public const int ARTIST			= 16;
		public const int ALBUM_NAME	= 17;
		public const int YEAR			= 18;
		public const int TRACK_NUMBER	= 19;
		public const int GENRE			= 20;
		public const int DURATION		= 21;
		public const int BIT_RATE		= 22;
	}
	/**
	 * SH_[etc] are simply assumption hence the comment.
	 **/
	public enum IDMap : int
	{
		//SH_FileName = 0,SH_FileType = 2,SH_DATE_MOD = 3,SH_DATE_CRD = 4,SH_Attributes = 5,SH_Owner = 6,SH_Author = 7,SH_Title = 8,
		Size = SH_ID3.SIZE,
		ArtistName = SH_ID3.ARTIST_NAME,
		SongTitle = SH_ID3.SONG_TITLE,
		Comment = SH_ID3.COMMENT,
		Artist = SH_ID3.ARTIST,
		AlbumName = SH_ID3.ALBUM_NAME,
		Year = SH_ID3.YEAR,
		TrackNumber = SH_ID3.TRACK_NUMBER,
		Genre = SH_ID3.GENRE,
		Duration = SH_ID3.DURATION,
		BitRate = SH_ID3.BIT_RATE,
	}
}
