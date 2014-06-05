using System;

namespace w32.user
{
	public class w32nt5
	{
		public const int APPCOMMAND_BROWSER_BACKWARD = 1;
		public const int APPCOMMAND_BROWSER_FORWARD = 2;
		public const int APPCOMMAND_BROWSER_REFRESH = 3;
		public const int APPCOMMAND_BROWSER_STOP = 4;
		public const int APPCOMMAND_BROWSER_SEARCH = 5;
		public const int APPCOMMAND_BROWSER_FAVORITES = 6;
		public const int APPCOMMAND_BROWSER_HOME = 7;
		public const int APPCOMMAND_VOLUME_MUTE = 8;
		public const int APPCOMMAND_VOLUME_DOWN = 9;
		public const int APPCOMMAND_VOLUME_UP = 10;
		public const int APPCOMMAND_MEDIA_NEXTTRACK = 11;
		public const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 12;
		public const int APPCOMMAND_MEDIA_STOP = 13;
		public const int APPCOMMAND_MEDIA_PLAY_PAUSE = 14;
		public const int APPCOMMAND_LAUNCH_MAIL = 15;
		public const int APPCOMMAND_LAUNCH_MEDIA_SELECT = 16;
		public const int APPCOMMAND_LAUNCH_APP1 = 17;
		public const int APPCOMMAND_LAUNCH_APP2 = 18;
		public const int APPCOMMAND_BASS_DOWN = 19;
		public const int APPCOMMAND_BASS_BOOST = 20;
		public const int APPCOMMAND_BASS_UP = 21;
		public const int APPCOMMAND_TREBLE_DOWN = 22;
		public const int APPCOMMAND_TREBLE_UP = 23;
		public w32nt5() {
		}
	}
	public class w32nt51 : w32nt5
	{
		public const int APPCOMMAND_MICROPHONE_VOLUME_MUTE = 24;
		public const int APPCOMMAND_MICROPHONE_VOLUME_DOWN = 25;
		public const int APPCOMMAND_MICROPHONE_VOLUME_UP = 26;
		public const int APPCOMMAND_HELP = 27;
		public const int APPCOMMAND_FIND = 28;
		public const int APPCOMMAND_NEW = 29;
		public const int APPCOMMAND_OPEN = 30;
		public const int APPCOMMAND_CLOSE = 31;
		public const int APPCOMMAND_SAVE = 32;
		public const int APPCOMMAND_PRINT = 33;
		public const int APPCOMMAND_UNDO = 34;
		public const int APPCOMMAND_REDO = 35;
		public const int APPCOMMAND_COPY = 36;
		public const int APPCOMMAND_CUT = 37;
		public const int APPCOMMAND_PASTE = 38;
		public const int APPCOMMAND_REPLY_TO_MAIL = 39;
		public const int APPCOMMAND_FORWARD_MAIL = 40;
		public const int APPCOMMAND_SEND_MAIL = 41;
		public const int APPCOMMAND_SPELL_CHECK = 42;
		public const int APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE = 43;
		public const int APPCOMMAND_MIC_ON_OFF_TOGGLE = 44;
		public const int APPCOMMAND_CORRECTION_LIST = 45;
		public const int APPCOMMAND_MEDIA_PLAY = 46;
		public const int APPCOMMAND_MEDIA_PAUSE = 47;
		public const int APPCOMMAND_MEDIA_RECORD = 48;
		public const int APPCOMMAND_MEDIA_FAST_FORWARD = 49;
		public const int APPCOMMAND_MEDIA_REWIND = 50;
		public const int APPCOMMAND_MEDIA_CHANNEL_UP = 51;
		public const int APPCOMMAND_MEDIA_CHANNEL_DOWN = 52;
		public w32nt51() {
		}
	}
	public class w32nt6 : w32nt51 {
		public const int APPCOMMAND_DELETE = 53;
		public const int APPCOMMAND_DWM_FLIP3D = 54;
		
	}
	// Hook Types
	public enum HookType : int
	{
	    WH_JOURNALRECORD = 0,
	    WH_JOURNALPLAYBACK = 1,
	    WH_KEYBOARD = 2,
	    WH_GETMESSAGE = 3,
	    WH_CALLWNDPROC = 4,
	    WH_CBT = 5,
	    WH_SYSMSGFILTER = 6,
	    WH_MOUSE = 7,
	    WH_HARDWARE = 8,
	    WH_DEBUG = 9,
	    WH_SHELL = 10,
	    WH_FOREGROUNDIDLE = 11,
	    WH_CALLWNDPROCRET = 12,
	    WH_KEYBOARD_LL = 13,
	    WH_MOUSE_LL = 14
	}
}
