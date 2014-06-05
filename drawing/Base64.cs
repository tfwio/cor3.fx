/*

 * oOo * 12/19/2007 : 7:56 PM *

 ** placeholder ** now outdated
this used to be compiled into 'pgal' project.
That was the old gallery ui in .Net v2.x
otherwise depreceated, I guess this is generally a gallery image.
right now the only reason that I want to mess with it is because it is used by 
ImgThumb to generate thumbnails I think?
**/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace drawing.util
{
	public class Base64Image : Base64
	{
		public static byte[] ImgToBytes(Image image)
		{
			return ImgToBytes(image,System.Drawing.Imaging.ImageFormat.Png);
		}
		public static byte[] ImgToBytes(Image image, System.Drawing.Imaging.ImageFormat fmt)
		{
	        MemoryStream stream = new MemoryStream();
	        image.Save(stream,ImageFormat.Png);
	        byte[] converted = stream.ToArray();
	        stream.Close();
	        return converted;
		}
		public static string Serialize(Image image, System.Drawing.Imaging.ImageFormat fmt)
		{
	        MemoryStream stream = new MemoryStream();
	        image.Save(stream,fmt);
	       // string converted = Convert.ToBase64String(stream.ToArray(),Base64FormattingOptions.InsertLineBreaks);
	        string converted = Convert.ToBase64String(stream.ToArray(),Base64FormattingOptions.InsertLineBreaks);
	        stream.Close();
	        return converted;
		}
		public static string Serialize(Image image)
		{
			return Serialize(image,System.Drawing.Imaging.ImageFormat.Png);
		}
		public static string SerializeCDATA(Image image)
		{
			return Format(Serialize(image,System.Drawing.Imaging.ImageFormat.Png));
		}
	}

	public class Base64
	{
	    // This method can be used to retrieve an Image from a block of Base64-encoded text.
	    // (ps: a snip from windows-sdk)
	    public static MemoryStream GetMemoryStream(string text)
	    {
	        byte[] memBytes = Convert.FromBase64String(text);
	        return new MemoryStream(memBytes);
	    }
	    /// <summary>
	    /// calles the overloaded version with Base64FormattingOptions.InsertLineBreaks as the 
	    /// formatting-options.
	    /// </summary>
	    public static string GetString(Stream ms)
	    {
	    	return GetString(ms,Base64FormattingOptions.InsertLineBreaks);
	    }
	    public static string GetString(Stream ms,Base64FormattingOptions breaks)
	    {
	    	byte[] mem = new byte[ms.Length];
	    	long pos = ms.Position; ms.Seek(0,SeekOrigin.Begin);
	    	BinaryReader joe = new BinaryReader(ms);
	    	joe.Read(mem,0,(int)ms.Length);
	    	string sam = Convert.ToBase64String(mem,breaks);
	    	ms.Seek(pos, SeekOrigin.Begin);
	    	joe = null; mem = null;
	    	return sam;
	    }
		public static string Format(object output)
		{
			return string.Format(@"<![CDATA[{0}]]>",output);
		}
		public static string CleanFormat(string output)
		{
			return output.Replace(@"<![CDATA[","").Replace(@"]]>","");
		}
		public static T DeserializeCDATA<T>(string text)
		{
			return Deserialize<T>(CleanFormat(text));
		}
	    // This method can be used to retrieve an Image from a block of Base64-encoded text.
	    // (ps: a snip from windows-sdk)
	    public static T Deserialize<T>(string text)
	    {
	        T img;
	        byte[] memBytes = Convert.FromBase64String(text);
	        
	        IFormatter formatter = new BinaryFormatter();
	        MemoryStream stream = new MemoryStream(memBytes);
	        img = (T)formatter.Deserialize(stream);
	        stream.Close();
	        return img;
	    }
	    // This method can be used to retrieve an Image from a block of Base64-encoded text.
	    // (ps: a snip from windows-sdk)
	    public static T Deserialize<T>(byte[] memBytes)
	    {
	        T img;
	        IFormatter formatter = new BinaryFormatter();
	        MemoryStream stream = new MemoryStream(memBytes);
	        img = (T)formatter.Deserialize(stream);
	        stream.Close();
	        return img;
	    }
	}
}
