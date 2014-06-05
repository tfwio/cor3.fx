/**

 * oOo * 12/19/2007 : 7:56 PM *

**/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Utilities.SuperOld;

namespace drawing.types
{
	/// <summary>
	/// it looks like mode can stand for two things.
	/// my current understanding is that it stands for the mode
	/// to act on (Thumb, Expo).
	/// this class is obsolete being used in obsolete classes.
	/// </summary>
	public struct ImageSettings
	{
		/// <summary> 1 = thum, 2 = expo </summary>
		public byte					mode;
		public Format				format;
		public InterpolationMode	interpolation;
		public SmoothingMode		smoothing;
		public Color				matte;
		/// <summary>
		/// if set to jpg, then the percent such as 99 would equal 99 percent.
		/// </summary>
		public int					quality;
		public SizeFlags			sizing;
		
		public ImageSettings(byte _mode)
		{
			mode=_mode;
			format = Format.png;
			interpolation = InterpolationMode.Default;
			smoothing = SmoothingMode.Default;
			matte = Color.Black;
			quality = 100;
			sizing = SizeFlags.scaledBoxed;
		}
		/// <summary>All settings initialization</summary>
		public ImageSettings(Format fmt,byte m,InterpolationMode ip,SmoothingMode sm,int qual,Color mat,SizeFlags size)
		{
			this.mode			= m;
			this.format			= fmt;
			this.interpolation	= ip;
			this.smoothing		= sm;
			this.quality		= qual;
			this.matte			= mat;
			this.sizing			= size;
		}
		/// <summary>
		/// With some default quality settings
		/// </summary>
		public ImageSettings(
			Format fmt,
			byte m,
			InterpolationMode ip,
			SmoothingMode sm,
			int qual
		)
		{
			this.mode			= m;
			this.format			= fmt;
			this.interpolation	= ip;
			this.smoothing		= sm;
			this.quality		= qual;
			this.matte			= Color.Transparent;
			this.sizing			= SizeFlags.scaledSize;
			
		}
	}
}
