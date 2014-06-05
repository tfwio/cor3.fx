﻿using System;
using System.Runtime.InteropServices;

namespace w32.shell
{
	/// as wm from comtextmenu sources, see w32nt5 for ShellCommands
	public class wm_message
	{
	    public const uint ACTIVATE = 0x6;
	    public const uint ACTIVATEAPP = 0x1C;
	    public const uint AFXFIRST = 0x360;
	    public const uint AFXLAST = 0x37F;
	    public const uint APP = 0x8000;
	    public const uint ASKCBFORMATNAME = 0x30C;
	    public const uint CANCELJOURNAL = 0x4B;
	    public const uint CANCELMODE = 0x1F;
	    public const uint CAPTURECHANGED = 0x215;
	    public const uint CHANGECBCHAIN = 0x30D;
	    public const uint CHAR = 0x102;
	    public const uint CHARTOITEM = 0x2F;
	    public const uint CHILDACTIVATE = 0x22;
	    public const uint CLEAR = 0x303;
	    public const uint CLOSE = 0x10;
	    public const uint COMMAND = 0x111;
	    public const uint COMPACTING = 0x41;
	    public const uint COMPAREITEM = 0x39;
	    public const uint CONTEXTMENU = 0x7B;
	    public const uint COPY = 0x301;
	    public const uint COPYDATA = 0x4A;
	    public const uint CREATE = 0x1;
	    public const uint CTLCOLORBTN = 0x135;
	    public const uint CTLCOLORDLG = 0x136;
	    public const uint CTLCOLOREDIT = 0x133;
	    public const uint CTLCOLORLISTBOX = 0x134;
	    public const uint CTLCOLORMSGBOX = 0x132;
	    public const uint CTLCOLORSCROLLBAR = 0x137;
	    public const uint CTLCOLORSTATIC = 0x138;
	    public const uint CUT = 0x300;
	    public const uint DEADCHAR = 0x103;
	    public const uint DELETEITEM = 0x2D;
	    public const uint DESTROY = 0x2;
	    public const uint DESTROYCLIPBOARD = 0x307;
	    public const uint DEVICECHANGE = 0x219;
	    public const uint DEVMODECHANGE = 0x1B;
	    public const uint DISPLAYCHANGE = 0x7E;
	    public const uint DRAWCLIPBOARD = 0x308;
	    public const uint DRAWITEM = 0x2B;
	    public const uint DROPFILES = 0x233;
	    public const uint ENABLE = 0xA;
	    public const uint ENDSESSION = 0x16;
	    public const uint ENTERIDLE = 0x121;
	    public const uint ENTERMENULOOP = 0x211;
	    public const uint ENTERSIZEMOVE = 0x231;
	    public const uint ERASEBKGND = 0x14;
	    public const uint EXITMENULOOP = 0x212;
	    public const uint EXITSIZEMOVE = 0x232;
	    public const uint FONTCHANGE = 0x1D;
	    public const uint GETDLGCODE = 0x87;
	    public const uint GETFONT = 0x31;
	    public const uint GETHOTKEY = 0x33;
	    public const uint GETICON = 0x7F;
	    public const uint GETMINMAXINFO = 0x24;
	    public const uint GETOBJECT = 0x3D;
	    public const uint GETSYSMENU = 0x313;
	    public const uint GETTEXT = 0xD;
	    public const uint GETTEXTLENGTH = 0xE;
	    public const uint HANDHELDFIRST = 0x358;
	    public const uint HANDHELDLAST = 0x35F;
	    public const uint HELP = 0x53;
	    public const uint HOTKEY = 0x312;
	    public const uint HSCROLL = 0x114;
	    public const uint HSCROLLCLIPBOARD = 0x30E;
	    public const uint ICONERASEBKGND = 0x27;
	    public const uint IME_CHAR = 0x286;
	    public const uint IME_COMPOSITION = 0x10F;
	    public const uint IME_COMPOSITIONFULL = 0x284;
	    public const uint IME_CONTROL = 0x283;
	    public const uint IME_ENDCOMPOSITION = 0x10E;
	    public const uint IME_KEYDOWN = 0x290;
	    public const uint IME_KEYLAST = 0x10F;
	    public const uint IME_KEYUP = 0x291;
	    public const uint IME_NOTIFY = 0x282;
	    public const uint IME_REQUEST = 0x288;
	    public const uint IME_SELECT = 0x285;
	    public const uint IME_SETCONTEXT = 0x281;
	    public const uint IME_STARTCOMPOSITION = 0x10D;
	    public const uint INITDIALOG = 0x110;
	    public const uint INITMENU = 0x116;
	    public const uint INITMENUPOPUP = 0x117;
	    public const uint INPUTLANGCHANGE = 0x51;
	    public const uint INPUTLANGCHANGEREQUEST = 0x50;
	    public const uint KEYDOWN = 0x100;
	    public const uint KEYFIRST = 0x100;
	    public const uint KEYLAST = 0x108;
	    public const uint KEYUP = 0x101;
	    public const uint KILLFOCUS = 0x8;
	    public const uint LBUTTONDBLCLK = 0x203;
	    public const uint LBUTTONDOWN = 0x201;
	    public const uint LBUTTONUP = 0x202;
	    public const uint LVM_GETEDITCONTROL = 0x1018;
	    public const uint LVM_SETIMAGELIST = 0x1003;
	    public const uint MBUTTONDBLCLK = 0x209;
	    public const uint MBUTTONDOWN = 0x207;
	    public const uint MBUTTONUP = 0x208;
	    public const uint MDIACTIVATE = 0x222;
	    public const uint MDICASCADE = 0x227;
	    public const uint MDICREATE = 0x220;
	    public const uint MDIDESTROY = 0x221;
	    public const uint MDIGETACTIVE = 0x229;
	    public const uint MDIICONARRANGE = 0x228;
	    public const uint MDIMAXIMIZE = 0x225;
	    public const uint MDINEXT = 0x224;
	    public const uint MDIREFRESHMENU = 0x234;
	    public const uint MDIRESTORE = 0x223;
	    public const uint MDISETMENU = 0x230;
	    public const uint MDITILE = 0x226;
	    public const uint MEASUREITEM = 0x2C;
	    public const uint MENUCHAR = 0x120;
	    public const uint MENUCOMMAND = 0x126;
	    public const uint MENUDRAG = 0x123;
	    public const uint MENUGETOBJECT = 0x124;
	    public const uint MENURBUTTONUP = 0x122;
	    public const uint MENUSELECT = 0x11F;
	    public const uint MOUSEACTIVATE = 0x21;
	    public const uint MOUSEFIRST = 0x200;
	    public const uint MOUSEHOVER = 0x2A1;
	    public const uint MOUSELAST = 0x20A;
	    public const uint MOUSELEAVE = 0x2A3;
	    public const uint MOUSEMOVE = 0x200;
	    public const uint MOUSEWHEEL = 0x20A;
	    public const uint MOVE = 0x3;
	    public const uint MOVING = 0x216;
	    public const uint NCACTIVATE = 0x86;
	    public const uint NCCALCSIZE = 0x83;
	    public const uint NCCREATE = 0x81;
	    public const uint NCDESTROY = 0x82;
	    public const uint NCHITTEST = 0x84;
	    public const uint NCLBUTTONDBLCLK = 0xA3;
	    public const uint NCLBUTTONDOWN = 0xA1;
	    public const uint NCLBUTTONUP = 0xA2;
	    public const uint NCMBUTTONDBLCLK = 0xA9;
	    public const uint NCMBUTTONDOWN = 0xA7;
	    public const uint NCMBUTTONUP = 0xA8;
	    public const uint NCMOUSEHOVER = 0x2A0;
	    public const uint NCMOUSELEAVE = 0x2A2;
	    public const uint NCMOUSEMOVE = 0xA0;
	    public const uint NCPAINT = 0x85;
	    public const uint NCRBUTTONDBLCLK = 0xA6;
	    public const uint NCRBUTTONDOWN = 0xA4;
	    public const uint NCRBUTTONUP = 0xA5;
	    public const uint NEXTDLGCTL = 0x28;
	    public const uint NEXTMENU = 0x213;
	    public const uint NOTIFY = 0x4E;
	    public const uint NOTIFYFORMAT = 0x55;
	    public const uint NULL = 0x0;
	    public const uint PAINT = 0xF;
	    public const uint PAINTCLIPBOARD = 0x309;
	    public const uint PAINTICON = 0x26;
	    public const uint PALETTECHANGED = 0x311;
	    public const uint PALETTEISCHANGING = 0x310;
	    public const uint PARENTNOTIFY = 0x210;
	    public const uint PASTE = 0x302;
	    public const uint PENWINFIRST = 0x380;
	    public const uint PENWINLAST = 0x38F;
	    public const uint POWER = 0x48;
	    public const uint PRINT = 0x317;
	    public const uint PRINTCLIENT = 0x318;
	    public const uint QUERYDRAGICON = 0x37;
	    public const uint QUERYENDSESSION = 0x11;
	    public const uint QUERYNEWPALETTE = 0x30F;
	    public const uint QUERYOPEN = 0x13;
	    public const uint QUEUESYNC = 0x23;
	    public const uint QUIT = 0x12;
	    public const uint RBUTTONDBLCLK = 0x206;
	    public const uint RBUTTONDOWN = 0x204;
	    public const uint RBUTTONUP = 0x205;
	    public const uint RENDERALLFORMATS = 0x306;
	    public const uint RENDERFORMAT = 0x305;
	    public const uint SETCURSOR = 0x20;
	    public const uint SETFOCUS = 0x7;
	    public const uint SETFONT = 0x30;
	    public const uint SETHOTKEY = 0x32;
	    public const uint SETICON = 0x80;
	    public const uint SETMARGINS = 0xD3;
	    public const uint SETREDRAW = 0xB;
	    public const uint SETTEXT = 0xC;
	    public const uint SETTINGCHANGE = 0x1A;
	    public const uint SHOWWINDOW = 0x18;
	    public const uint SIZE = 0x5;
	    public const uint SIZECLIPBOARD = 0x30B;
	    public const uint SIZING = 0x214;
	    public const uint SPOOLERSTATUS = 0x2A;
	    public const uint STYLECHANGED = 0x7D;
	    public const uint STYLECHANGING = 0x7C;
	    public const uint SYNCPAINT = 0x88;
	    public const uint SYSCHAR = 0x106;
	    public const uint SYSCOLORCHANGE = 0x15;
	    public const uint SYSCOMMAND = 0x112;
	    public const uint SYSDEADCHAR = 0x107;
	    public const uint SYSKEYDOWN = 0x104;
	    public const uint SYSKEYUP = 0x105;
	    public const uint TCARD = 0x52;
	    public const uint TIMECHANGE = 0x1E;
	    public const uint TIMER = 0x113;
	    public const uint TVM_GETEDITCONTROL = 0x110F;
	    public const uint TVM_SETIMAGELIST = 0x1109;
	    public const uint UNDO = 0x304;
	    public const uint UNINITMENUPOPUP = 0x125;
	    public const uint USER = 0x400;
	    public const uint USERCHANGED = 0x54;
	    public const uint VKEYTOITEM = 0x2E;
	    public const uint VSCROLL = 0x115;
	    public const uint VSCROLLCLIPBOARD = 0x30A;
	    public const uint WINDOWPOSCHANGED = 0x47;
	    public const uint WINDOWPOSCHANGING = 0x46;
	    public const uint WININICHANGE = 0x1A;
	    public const uint SH_NOTIFY = 0x0401;
	}
	// .contextmenu
}
