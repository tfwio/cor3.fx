/**
 * User: tfw * Date: 12/28/2008 * Time: 9:32 PM
**/
using System.Drawing;
using System.Drawing.Imaging;
namespace Drawing
{
	/// <summary>
	/// the goal being a 'managed' user interface listing image codecs, and their user dialogs, and etc...
	/// </summary>
	public class ImageDecoder : CodecUtil
	{
		ImageCodecInfo activeCodec = null;
		public ImageDecoder(string mimeid) { activeCodec = this[mimeid]; }
		ImageCodecInfo this[string mime] { get { return this[mime]; } }
		public ImageDecoder()
		{
//			Encoder myEncoder;
//			EncoderParameter myEncoderParameter;
//			EncoderParameters myEncoderParameters;
//			myImageCodecInfo = GetEncoderInfo("image/jpeg");
		}
	}
	public class ImageEncoder : CodecUtil
	{
		ImageCodecInfo this[string mime] { get { return this[mime]; } }
		public ImageEncoder() {}
		public ImageEncoder(string mimeid) {}
	}
	public class CodecUtil
	{
		static public ImageCodecInfo[] Decoders { get { return ImageCodecInfo.GetImageDecoders(); } }
		static public ImageCodecInfo[] Encoders { get { return ImageCodecInfo.GetImageEncoders(); } }
		/// <summary>must be overridden</summary>
		virtual public ImageCodecInfo this[string mime] { get { throw new System.NotImplementedException(); } set { throw new System.NotImplementedException(); } }
	}
}