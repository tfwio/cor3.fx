/* oOo * 11/20/2007 : 4:41 PM */
using System;

namespace w32
{

	////////////////////////////////////////////////////////////////////////////
	// Edit Control Messages ?
	public class EditControlMessage : UserControlMessage
	{
		public const int EM_GETSEL = 0x00B0;
		public const int EM_SETSEL = 0x00B1;
		public const int EM_GETRECT = 0x00B2;
		public const int EM_SETRECT = 0x00B3;
		public const int EM_SETRECTNP = 0x00B4;
		public const int EM_SCROLL = 0x00B5;
		public const int EM_LINESCROLL = 0x00B6;
		public const int EM_SCROLLCARET = 0x00B7;
		public const int EM_GETMODIFY = 0x00B8;
		public const int EM_SETMODIFY = 0x00B9;
		public const int EM_GETLINECOUNT = 0x00BA;
		public const int EM_LINEINDEX = 0x00BB;
		public const int EM_SETHANDLE = 0x00BC;
		public const int EM_GETHANDLE = 0x00BD;
		public const int EM_GETTHUMB = 0x00BE;
		public const int EM_LINELENGTH = 0x00C1;
		public const int EM_REPLACESEL = 0x00C2;
		public const int EM_GETLINE = 0x00C4;
		public const int EM_LIMITTEXT = 0x00C5;
		public const int EM_CANUNDO = 0x00C6;
		public const int EM_UNDO = 0x00C7;
		public const int EM_FMTLINES = 0x00C8;
		public const int EM_LINEFROMCHAR = 0x00C9;
		public const int EM_SETTABSTOPS = 0x00CB;
		public const int EM_SETPASSWORDCHAR = 0x00CC;
		public const int EM_EMPTYUNDOBUFFER = 0x00CD;
		public const int EM_GETFIRSTVISIBLELINE = 0x00CE;
		public const int EM_SETREADONLY = 0x00CF;
		public const int EM_SETWORDBREAKPROC = 0x00D0;
		public const int EM_GETWORDBREAKPROC = 0x00D1;
		public const int EM_GETPASSWORDCHAR = 0x00D2;
		//#if(WINVER >= 0x0400)
		public const int EM_SETMARGINS = 0x00D3;
		public const int EM_GETMARGINS = 0x00D4;
		public const int EM_SETLIMITTEXT = EM_LIMITTEXT;
		/* ;win40 Name change */
		public const int EM_GETLIMITTEXT = 0x00D5;
		public const int EM_POSFROMCHAR = 0x00D6;
		public const int EM_CHARFROMPOS = 0x00D7;
		//#endif /* WINVER >= 0x0400
		//#if(WINVER >= 0x0500)
		public const int EM_SETIMESTATUS = 0x00D8;
		public const int EM_GETIMESTATUS = 0x00D9;
		//#endif /* WINVER >= 0x0500 */
		// Outline mode message
		public const int EM_OUTLINE = (WM_USER + 220);
		// Message for getting and restoring scroll pos
		public const int EM_GETSCROLLPOS = (WM_USER + 221);
		public const int EM_SETSCROLLPOS = (WM_USER + 222);
		// Change fontsize in current selection by wParam
		public const int EM_SETFONTSIZE = (WM_USER + 223);
		public const int EM_GETZOOM = (WM_USER + 224);
		public const int EM_SETZOOM = (WM_USER + 225);
		public const int EM_GETVIEWKIND = (WM_USER + 226);
		public const int EM_SETVIEWKIND = (WM_USER + 227);
		// RichEdit 4.0 messages
		public const int EM_GETPAGE = (WM_USER + 228);
		public const int EM_SETPAGE = (WM_USER + 229);
		public const int EM_GETHYPHENATEINFO = (WM_USER + 230);
		public const int EM_SETHYPHENATEINFO = (WM_USER + 231);
		public const int EM_GETPAGEROTATE = (WM_USER + 235);
		public const int EM_SETPAGEROTATE = (WM_USER + 236);
		public const int EM_GETCTFMODEBIAS = (WM_USER + 237);
		public const int EM_SETCTFMODEBIAS = (WM_USER + 238);
		public const int EM_GETCTFOPENSTATUS = (WM_USER + 240);
		public const int EM_SETCTFOPENSTATUS = (WM_USER + 241);
		public const int EM_GETIMECOMPTEXT = (WM_USER + 242);
		public const int EM_ISIME = (WM_USER + 243);
		public const int EM_GETIMEPROPERTY = (WM_USER + 244);
	}
	////////////////////////////////////////////////////////////////////////////
	// Edit Control Messages ?
	////////////////////////////////////////////////////////////////////////////
	public enum EM_MSG : uint
	{
		WM_USER = EditControlMessage.WM_USER,
		EM_GETSEL = EditControlMessage.EM_GETSEL,
		EM_SETSEL = EditControlMessage.EM_SETSEL,
		EM_GETRECT = EditControlMessage.EM_GETRECT,
		EM_SETRECT = EditControlMessage.EM_SETRECT,
		EM_SETRECTNP = EditControlMessage.EM_SETRECTNP,
		EM_SCROLL = EditControlMessage.EM_SCROLL,
		EM_LINESCROLL = EditControlMessage.EM_LINESCROLL,
		EM_SCROLLCARET = EditControlMessage.EM_SCROLLCARET,
		EM_GETMODIFY = EditControlMessage.EM_GETMODIFY,
		EM_SETMODIFY = EditControlMessage.EM_SETMODIFY,
		EM_GETLINECOUNT = EditControlMessage.EM_GETLINECOUNT,
		EM_LINEINDEX = EditControlMessage.EM_LINEINDEX,
		EM_SETHANDLE = EditControlMessage.EM_SETHANDLE,
		EM_GETHANDLE = EditControlMessage.EM_GETHANDLE,
		EM_GETTHUMB = EditControlMessage.EM_GETTHUMB,
		EM_LINELENGTH = EditControlMessage.EM_LINELENGTH,
		EM_REPLACESEL = EditControlMessage.EM_REPLACESEL,
		EM_GETLINE = EditControlMessage.EM_GETLINE,
		EM_LIMITTEXT = EditControlMessage.EM_LIMITTEXT,
		EM_CANUNDO = EditControlMessage.EM_CANUNDO,
		EM_UNDO = EditControlMessage.EM_UNDO,
		EM_FMTLINES = EditControlMessage.EM_FMTLINES,
		EM_LINEFROMCHAR = EditControlMessage.EM_LINEFROMCHAR,
		EM_SETTABSTOPS = EditControlMessage.EM_SETTABSTOPS,
		EM_SETPASSWORDCHAR = EditControlMessage.EM_SETPASSWORDCHAR,
		EM_EMPTYUNDOBUFFER = EditControlMessage.EM_EMPTYUNDOBUFFER,
		EM_GETFIRSTVISIBLELINE = EditControlMessage.EM_GETFIRSTVISIBLELINE,
		EM_SETREADONLY = EditControlMessage.EM_SETREADONLY,
		EM_SETWORDBREAKPROC = EditControlMessage.EM_SETWORDBREAKPROC,
		EM_GETWORDBREAKPROC = EditControlMessage.EM_GETWORDBREAKPROC,
		EM_GETPASSWORDCHAR = EditControlMessage.EM_GETPASSWORDCHAR,
		EM_SETMARGINS = EditControlMessage.EM_SETMARGINS,
		EM_GETMARGINS = EditControlMessage.EM_GETMARGINS,
		EM_SETLIMITTEXT = EditControlMessage.EM_SETLIMITTEXT,
		EM_GETLIMITTEXT = EditControlMessage.EM_GETLIMITTEXT,
		EM_POSFROMCHAR = EditControlMessage.EM_POSFROMCHAR,
		EM_CHARFROMPOS = EditControlMessage.EM_CHARFROMPOS,
		EM_SETIMESTATUS = EditControlMessage.EM_SETIMESTATUS,
		EM_GETIMESTATUS = EditControlMessage.EM_GETIMESTATUS,
		EM_OUTLINE = EditControlMessage.EM_OUTLINE,
		EM_GETSCROLLPOS = EditControlMessage.EM_GETSCROLLPOS,
		EM_SETSCROLLPOS = EditControlMessage.EM_SETSCROLLPOS,
		EM_SETFONTSIZE = EditControlMessage.EM_SETFONTSIZE,
		EM_GETZOOM = EditControlMessage.EM_GETZOOM,
		EM_SETZOOM = EditControlMessage.EM_SETZOOM,
		EM_GETVIEWKIND = EditControlMessage.EM_GETVIEWKIND,
		EM_SETVIEWKIND = EditControlMessage.EM_SETVIEWKIND,
		EM_GETPAGE = EditControlMessage.EM_GETPAGE,
		EM_SETPAGE = EditControlMessage.EM_SETPAGE,
		EM_GETHYPHENATEINFO = EditControlMessage.EM_GETHYPHENATEINFO,
		EM_SETHYPHENATEINFO = EditControlMessage.EM_SETHYPHENATEINFO,
		EM_GETPAGEROTATE = EditControlMessage.EM_GETPAGEROTATE,
		EM_SETPAGEROTATE = EditControlMessage.EM_SETPAGEROTATE,
		EM_GETCTFMODEBIAS = EditControlMessage.EM_GETCTFMODEBIAS,
		EM_SETCTFMODEBIAS = EditControlMessage.EM_SETCTFMODEBIAS,
		EM_GETCTFOPENSTATUS = EditControlMessage.EM_GETCTFOPENSTATUS,
		EM_SETCTFOPENSTATUS = EditControlMessage.EM_SETCTFOPENSTATUS,
		EM_GETIMECOMPTEXT = EditControlMessage.EM_GETIMECOMPTEXT,
		EM_ISIME = EditControlMessage.EM_ISIME,
		EM_GETIMEPROPERTY = EditControlMessage.EM_GETIMEPROPERTY,
	}
}
