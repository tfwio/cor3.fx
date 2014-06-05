/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;

namespace System.Text
{
	/*******************************************************************************
	****	String Buffer
	*******************************************************************************/
	/// <summary>represents our buffer</summary>
	public interface IStringBuffer
	: ISbStream, ISbLine, ISbDescriptor
	{
	}
	public interface ISbLine
	{
		/// <summary>gets a string at the specified line-index</summary>
		string this[int index] { get; }
		/// <summary>gets the text between two lines</summary>
		string[] this[int line1, int line2] { get; }
	}
	/// <summary>to be updated</summary>
	public interface ISbDescriptor
	{
		/// <summary>represents the number of lines in the buffer</summary>
		int NumLines { get; }
		/// <summary>the string buffer</summary>
		string Text {get;}
	}
	public interface ISbStream
	{
		/// <summary>
		/// should convert the encoder to the preferred codepage.
		/// </summary>
		/// <remarks>
		/// by default, uses the default setting represented by Encoding.Default.
		/// there also should be some form of showing the current codepage which
		/// should be a string value that can be in a status-bar.
		/// </remarks>
		CodePages CodePage { get; set; }
		/// <summary>you know</summary>
		string FileName { get; }
		/// <summary>
		/// will handle some default (pre-ordained) codepages.
		/// </summary>
		/// <remarks>reserved for future use</remarks>
		Encoding DefaultEncoder { get;set; }
	}
	public interface ITcTextStyle
	{
	//	Font DefaultFont { get;set; }
	//	int LineHeight { get;set; }
		Graphics m_gfx { get; }
		/// <summary>Should be pixel by default</summary>
		GraphicsUnit DrawingUnits { get;set; }
		/// <summary></summary>
		StringFormat StrFmt { get;set; }
		/// 
		int TabChars { get;set; }
		/// <summary></summary>
		bool WordWrap { get;set; }
		Font Font { get; }
		Graphics G();
		Graphics G(bool clear);
		Rectangle c_rect { get; }
		Rectangle o_rect { get; }
	}
	/*
	/// <summary>simple (emulated) codepage support</summary> 
	public enum CodePages { Ascii,Unicode,Utf7,Utf8,Default,}
	*/

}
