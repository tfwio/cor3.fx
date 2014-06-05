/**
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;

namespace w32.kernel
{
	public struct FONTDIRENTRY { 
		public WORD dfVersion; 
		public DWORD dfSize; 
		public char[/* 60 */] dfCopyright; 
		public WORD dfType; 
		public WORD dfPoints; 
		public WORD dfVertRes; 
		public WORD dfHorizRes; 
		public WORD dfAscent; 
		public WORD dfInternalLeading; 
		public WORD dfExternalLeading; 
		public BYTE dfItalic; 
		public BYTE dfUnderline; 
		public BYTE dfStrikeOut; 
		public WORD dfWeight; 
		public BYTE dfCharSet; 
		public WORD dfPixWidth; 
		public WORD dfPixHeight; 
		public BYTE dfPitchAndFamily; 
		public WORD dfAvgWidth; 
		public WORD dfMaxWidth; 
		public BYTE dfFirstChar; 
		public BYTE dfLastChar; 
		public BYTE dfDefaultChar; 
		public BYTE dfBreakChar; 
		public WORD dfWidthBytes; 
		public DWORD dfDevice; 
		public DWORD dfFace; 
		public DWORD dfReserved;
		public char[/* \0 */] szDeviceName; // null terminated
		public char[/* \0 */] szFaceName; // null terminated
	};
}
