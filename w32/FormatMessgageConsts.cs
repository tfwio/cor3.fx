using System;

namespace w32.kernel
{
	/// <summary>
	/// It didn't really occur to me to use string.format until I trans-coded
	/// all these FormatMessageRelated things...<br/> Let's see if it comes in handy
	/// some day...
	/// </summary>
	public class FormatMessgageConsts
	{
		/// <summary>
		/// If the low-order byte is a nonzero value other than 
		/// FORMAT_MESSAGE_MAX_WIDTH_MASK, it specifies the maximum number 
		/// of characters in an output line. The function ignores regular 
		/// line breaks in the message definition text. The function never 
		/// splits a string delimited by white space across a line break. 
		/// The function stores hard-coded line breaks in the message 
		/// definition text into the output buffer. Hard-coded line breaks 
		/// are coded with the %n escape sequence.
		/// </summary>
		public const int FORMAT_MESSAGE_MAX_WIDTH_MASK = 0x000000FF;
		public const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
		public const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
		public const int FORMAT_MESSAGE_FROM_STRING = 0x00000400;
		public const int FORMAT_MESSAGE_FROM_HMODULE = 0x00000800;
		public const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
		public const int FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000;
	}
	public enum FORMAT_MESSAGE : int
	{
		MAX_WIDTH_MASK = FormatMessgageConsts.FORMAT_MESSAGE_MAX_WIDTH_MASK,
		ALLOCATE_BUFFER = FormatMessgageConsts.FORMAT_MESSAGE_ALLOCATE_BUFFER,
		IGNORE_INSERTS = FormatMessgageConsts.FORMAT_MESSAGE_IGNORE_INSERTS,
		FROM_STRING = FormatMessgageConsts.FORMAT_MESSAGE_FROM_STRING,
		FROM_HMODULE = FormatMessgageConsts.FORMAT_MESSAGE_FROM_HMODULE,
		FROM_SYSTEM = FormatMessgageConsts.FORMAT_MESSAGE_FROM_SYSTEM,
		ARGUMENT_ARRAY = FormatMessgageConsts.FORMAT_MESSAGE_ARGUMENT_ARRAY,
	}

}
