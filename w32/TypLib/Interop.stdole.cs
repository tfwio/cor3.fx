//*****************************************************************//
//                                                                 //
// This file is generated automatically by Aurigma COM to .NET 1.0 //
//                                                                 //
//*****************************************************************//

using System;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace stdole
{
	[Guid("E6C8FA08-BD9F-11D0-985E-00C04FC29993")]
	[TypeLibType((short)0)]
	public enum LoadPictureConstants
	{
		Default = 0,

		Monochrome = 1,

		VgaColor = 2,

		Color = 4
	}

	[Guid("6650430A-BE0F-101A-8BBB-00AA00300CAB")]
	[TypeLibType((short)0)]
	public enum OLE_TRISTATE
	{
		Unchecked = 0,

		Checked = 1,

		Gray = 2
	}

	[TypeLibType((short)512)]
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct DISPPARAMS // RECORD
	{
		public void** rgvarg;

		public int* rgdispidNamedArgs;

		public uint cArgs;

		public uint cNamedArgs;
	}

	[TypeLibType((short)512)]
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct EXCEPINFO // RECORD
	{
		public ushort wCode;

		public ushort wReserved;

		[MarshalAs(UnmanagedType.BStr)]
		public string bstrSource;

		[MarshalAs(UnmanagedType.BStr)]
		public string bstrDescription;

		[MarshalAs(UnmanagedType.BStr)]
		public string bstrHelpFile;

		public uint dwHelpContext;

		[MarshalAs(UnmanagedType.I4)]
		public void* pvReserved;

		[MarshalAs(UnmanagedType.I4)]
		public void* pfnDeferredFillIn;

		public int scode;
	}

	[TypeLibType((short)16)]
	[StructLayout(LayoutKind.Sequential)]
	public struct GUID // RECORD
	{
		public uint Data1;

		public ushort Data2;

		public ushort Data3;

		[MarshalAs(UnmanagedType.LPArray, SizeConst = 8)]
		public byte[] Data4;
	}

	[Guid("BEF6E003-A874-101A-8BBA-00AA00300CAB")]
	[ComImport]
	[TypeLibType((short)4096)]
	[DefaultMember("Name")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IFontDisp
	{
		[DispId(0)]
		string Name
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[ComConversionLoss]
		[DispId(2)]
		double Size
		{
			[return: MarshalAs(UnmanagedType.Currency)]
			get;
			[param: MarshalAs(UnmanagedType.Currency)]
			set;
		}

		[DispId(3)]
		bool Bold
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(4)]
		bool Italic
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(5)]
		bool Underline
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(6)]
		bool Strikethrough
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(7)]
		short Weight
		{
			get;
			set;
		}

		[DispId(8)]
		short Charset
		{
			get;
			set;
		}
	}

	[Guid("4EF6100A-AF88-11D0-9846-00C04FC29993")]
	[ComImport]
	[TypeLibType((short)4112)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IFontEventsDisp
	{
		[DispId(9)]
		void FontChanged ([MarshalAs(UnmanagedType.BStr)] string PropertyName);
	}

	[Guid("7BF80981-BF32-101A-8BBB-00AA00300CAB")]
	[ComImport]
	[TypeLibType((short)4096)]
	[DefaultMember("Handle")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	unsafe public interface IPictureDisp
	{
		[DispId(6)]
		void Render (int hdc, int x, int y, int cx, int cy, int xSrc, int ySrc, int cxSrc, int cySrc, [MarshalAs(UnmanagedType.I4)] void* prcWBounds);

		[DispId(0)]
		int Handle
		{
			get;
		}

		[DispId(2)]
		int hPal
		{
			get;
			set;
		}

		[DispId(3)]
		short Type
		{
			get;
		}

		[DispId(4)]
		int Width
		{
			get;
		}

		[DispId(5)]
		int Height
		{
			get;
		}
	}

	[Guid("BEF6E003-A874-101A-8BBA-00AA00300CAB")]
	[ComImport]
	[TypeLibType((short)4096)]
	[DefaultMember("Name")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface Font
	{
		[DispId(0)]
		string Name
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[ComConversionLoss]
		[DispId(2)]
		double Size
		{
			[return: MarshalAs(UnmanagedType.Currency)]
			get;
			[param: MarshalAs(UnmanagedType.Currency)]
			set;
		}

		[DispId(3)]
		bool Bold
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(4)]
		bool Italic
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(5)]
		bool Underline
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(6)]
		bool Strikethrough
		{
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[param: MarshalAs(UnmanagedType.VariantBool)]
			set;
		}

		[DispId(7)]
		short Weight
		{
			get;
			set;
		}

		[DispId(8)]
		short Charset
		{
			get;
			set;
		}
	}

	// Event interface for the Font object
	[Guid("4EF6100A-AF88-11D0-9846-00C04FC29993")]
	[ComImport]
	[TypeLibType((short)4112)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FontEvents
	{
		[DispId(9)]
		void FontChanged ([MarshalAs(UnmanagedType.BStr)] string PropertyName);
	}

	public delegate void FontEvents_FontChangedEventHandler ([MarshalAs(UnmanagedType.BStr)] string PropertyName);

	// Event interface for the Font object
	[ComEventInterface(typeof(FontEvents),typeof(FontEvents_EventProvider))]
	[ComVisible(false)]
	public interface FontEvents_Event
	{
		event FontEvents_FontChangedEventHandler FontChanged;
	}

	[ClassInterface(ClassInterfaceType.None)]
	internal class FontEvents_SinkHelper: FontEvents
	{
		public int Cookie = 0;

		public event FontEvents_FontChangedEventHandler FontChangedDelegate = null;
		public void Set_FontChangedDelegate(FontEvents_FontChangedEventHandler deleg)
		{
			FontChangedDelegate = deleg;
		}
		public bool Is_FontChangedDelegate(FontEvents_FontChangedEventHandler deleg)
		{
			return (FontChangedDelegate == deleg);
		}
		public void Clear_FontChangedDelegate()
		{
			FontChangedDelegate = null;
		}
		void FontEvents.FontChanged (string PropertyName)
		{
			if (FontChangedDelegate!=null)
				FontChangedDelegate(PropertyName);
		}
	}

	internal class FontEvents_EventProvider: IDisposable, FontEvents_Event
	{
		UCOMIConnectionPointContainer ConnectionPointContainer;
		UCOMIConnectionPoint ConnectionPoint;
		FontEvents_SinkHelper EventSinkHelper;
		int ConnectionCount;

		// Constructor: remember ConnectionPointContainer
		FontEvents_EventProvider(object CPContainer) : base()
		{
			ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
		}

		// Force disconnection from ActiveX event source
		~FontEvents_EventProvider()
		{
			Disconnect();
			ConnectionPointContainer = null;
		}

		// Aletnative to destructor
		void IDisposable.Dispose()
		{
			Disconnect();
			ConnectionPointContainer = null;
			System.GC.SuppressFinalize(this);
		}

		// Connect to ActiveX event source
		void Connect()
		{
			if (ConnectionPoint == null)
			{
				ConnectionCount = 0;
				Guid g = new Guid("4EF6100A-AF88-11D0-9846-00C04FC29993");
				ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
				EventSinkHelper = new FontEvents_SinkHelper();
				ConnectionPoint.Advise(EventSinkHelper, out EventSinkHelper.Cookie);
			}
		}

		// Disconnect from ActiveX event source
		void Disconnect()
		{
			System.Threading.Monitor.Enter(this);
			try {
				if (EventSinkHelper != null)
					ConnectionPoint.Unadvise(EventSinkHelper.Cookie);
				ConnectionPoint = null;
				EventSinkHelper = null;
			} catch { }
			System.Threading.Monitor.Exit(this);
		}

		// If no event handler present then disconnect from ActiveX event source
		void CheckDisconnect()
		{
			ConnectionCount--;
			if (ConnectionCount <= 0)
				Disconnect();
		}

		event FontEvents_FontChangedEventHandler FontEvents_Event.FontChanged
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.FontChangedDelegate += value;
					ConnectionCount++;
				} catch { }
				System.Threading.Monitor.Exit(this);
			}
			remove
			{
				if (EventSinkHelper != null)
				{
					System.Threading.Monitor.Enter(this);
					try {
						EventSinkHelper.FontChangedDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}
	}

	[Guid("7BF80981-BF32-101A-8BBB-00AA00300CAB")]
	[ComImport]
	[TypeLibType((short)4096)]
	[DefaultMember("Handle")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	unsafe public interface Picture
	{
		[DispId(6)]
		void Render (int hdc, int x, int y, int cx, int cy, int xSrc, int ySrc, int cxSrc, int cySrc, [MarshalAs(UnmanagedType.I4)] void* prcWBounds);

		[DispId(0)]
		int Handle
		{
			get;
		}

		[DispId(2)]
		int hPal
		{
			get;
			set;
		}

		[DispId(3)]
		short Type
		{
			get;
		}

		[DispId(4)]
		int Width
		{
			get;
		}

		[DispId(5)]
		int Height
		{
			get;
		}
	}

	[Guid("00020400-0000-0000-C000-000000000046")]
	[ComImport]
	[TypeLibType((short)512)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	unsafe public interface IDispatch
	{
		[PreserveSig]
		uint GetTypeInfoCount ([Out] out uint pctinfo);

		[PreserveSig]
		uint GetTypeInfo (uint itinfo, uint lcid, void** pptinfo);

		[PreserveSig]
		uint GetIDsOfNames ([In] ref GUID riid, sbyte** rgszNames, uint cNames, uint lcid, [Out] out int rgdispid);

		[PreserveSig]
		uint Invoke (int dispidMember, [In] ref GUID riid, uint lcid, ushort wFlags, [In] ref DISPPARAMS pdispparams, [Out] out object pvarResult, [Out] out EXCEPINFO pexcepinfo, [Out] out uint puArgErr);
	}

	[Guid("00020404-0000-0000-C000-000000000046")]
	[ComImport]
	[TypeLibType((short)16)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumVARIANT
	{
		[PreserveSig]
		uint Next (uint celt, [In] ref object rgvar, [Out] out uint pceltFetched);

		[PreserveSig]
		uint Skip (uint celt);

		[PreserveSig]
		uint Reset ();

		[PreserveSig]
		uint Clone ([Out] out IEnumVARIANT ppenum);
	}

	// Font Object
	[Guid("BEF6E002-A874-101A-8BBA-00AA00300CAB")]
	[ComImport]
	[TypeLibType((short)16)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFont
	{
		[return: MarshalAs(UnmanagedType.BStr)]
		string Name () /* property get method */;

		void put_Name ([MarshalAs(UnmanagedType.BStr)] string pname) /* property put method */;

		[return: MarshalAs(UnmanagedType.Currency)]
		double Size () /* property get method */;

		void put_Size ([ComConversionLoss, MarshalAs(UnmanagedType.Currency)] double psize) /* property put method */;

		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool Bold () /* property get method */;

		void put_Bold ([MarshalAs(UnmanagedType.VariantBool)] bool pbold) /* property put method */;

		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool Italic () /* property get method */;

		void put_Italic ([MarshalAs(UnmanagedType.VariantBool)] bool pitalic) /* property put method */;

		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool Underline () /* property get method */;

		void put_Underline ([MarshalAs(UnmanagedType.VariantBool)] bool punderline) /* property put method */;

		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool Strikethrough () /* property get method */;

		void put_Strikethrough ([MarshalAs(UnmanagedType.VariantBool)] bool pstrikethrough) /* property put method */;

		short Weight () /* property get method */;

		void put_Weight (short pweight) /* property put method */;

		short Charset () /* property get method */;

		void put_Charset (short pcharset) /* property put method */;

		int hFont () /* property get method */;

		[PreserveSig]
		uint Clone ([Out] out IFont ppfont);

		[PreserveSig]
		uint IsEqual (IFont pfontOther);

		[PreserveSig]
		uint SetRatio (int cyLogical, int cyHimetric);

		[PreserveSig]
		uint AddRefHfont (int hFont);

		[PreserveSig]
		uint ReleaseHfont (int hFont);
	}

	// Picture Object
	[Guid("7BF80980-BF32-101A-8BBB-00AA00300CAB")]
	[ComImport]
	[TypeLibType((short)16)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	unsafe public interface IPicture
	{
		int Handle () /* property get method */;

		int hPal () /* property get method */;

		short Type () /* property get method */;

		int Width () /* property get method */;

		int Height () /* property get method */;

		[PreserveSig]
		uint Render (int hdc, int x, int y, int cx, int cy, int xSrc, int ySrc, int cxSrc, int cySrc, [MarshalAs(UnmanagedType.I4)] void* prcWBounds);

		void put_hPal (int phpal) /* property put method */;

		int CurDC () /* property get method */;

		[PreserveSig]
		uint SelectPicture (int hdcIn, [Out] out int phdcOut, [Out] out int phbmpOut);

		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool KeepOriginalFormat () /* property get method */;

		void put_KeepOriginalFormat ([MarshalAs(UnmanagedType.VariantBool)] bool pfkeep) /* property put method */;

		[PreserveSig]
		uint PictureChanged ();

		[PreserveSig]
		uint SaveAsFile ([MarshalAs(UnmanagedType.I4)] void* pstm, [MarshalAs(UnmanagedType.VariantBool)] bool fSaveMemCopy, [Out] out int pcbSize);

		int Attributes () /* property get method */;

		[PreserveSig]
		uint SetHdc (int hdc);
	}

	[Guid("00000000-0000-0000-C000-000000000046")]
	[ComImport]
	[TypeLibType((short)16)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUnknown
	{
	}

	[Guid("BEF6E003-A874-101A-8BBA-00AA00300CAB")]
	[ComImport]
	[CoClass(typeof(StdFontClass))]
	public interface StdFont: Font
	{
	}

	[Guid("0BE35203-8F91-11CE-9DE3-00AA004BB851")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("FontEvents")]
	public class StdFontClass // : IFont, Font, StdFont, FontEvents_Event
	{
	}

	[Guid("7BF80981-BF32-101A-8BBB-00AA00300CAB")]
	[ComImport]
	[CoClass(typeof(StdPictureClass))]
	public interface StdPicture: Picture
	{
	}

	[Guid("0BE35204-8F91-11CE-9DE3-00AA004BB851")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class StdPictureClass // : IPicture, Picture, StdPicture
	{
	}

	// Functions for Standard OLE Objects
	[Guid("91209AC0-60F6-11CF-9C5D-00AA00C1489E")]
	public sealed class StdFunctions // MODULE
	{
		// Loads a picture from a file
		[DllImport("oleaut32.dll", EntryPoint="OleLoadPictureFileEx", ExactSpelling=true, SetLastError=true)]
		public static extern uint LoadPicture (object filename, int widthDesired, int heightDesired, LoadPictureConstants flags, out Picture ReturnValue);

		// Saves a picture to a file
		[DllImport("oleaut32.dll", EntryPoint="OleSavePictureFile", ExactSpelling=true, SetLastError=true)]
		public static extern uint SavePicture (Picture Picture, [MarshalAs(UnmanagedType.BStr)] string filename);
	}
}
