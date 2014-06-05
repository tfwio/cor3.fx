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
using Apple.QTOLibrary;

// Change the following attribute values to modify
// the information associated with an assembly.
//[assembly: AssemblyTitle("Apple.QTOControlLib")]
//[assembly: AssemblyDescription("Apple QuickTime Control 2.0 (translated by Aurigma COM to .NET)")]
//[assembly: AssemblyVersion("1.0")]
//[assembly: AssemblyConfiguration("Retail")]
//[assembly: AssemblyCompany("Aurigma Inc.")]
//[assembly: AssemblyProduct("QTOControlLib translated by Aurigma COM to .NET")]
//[assembly: AssemblyCopyright("Copyright (c) 2003 by Aurigma Inc.")]
//[assembly: AssemblyTrademark("Aurigma COM to .NET")]

// Type library name: QTOControlLib
// Type library description: Apple QuickTime Control 2.0
// Type library version: 1.0
// Type library language: Neutral
// Type library guid: {7B92F833-027D-402B-BFF9-A67697366F4E}
// Type library source file name: C:\Program Files\QuickTime\QTOControl.dll

namespace Apple.QTOControlLib
{
	[TypeLibType((short)0)]
	public enum BorderStylesEnum
	{
		bsNone = 0,
		bsPlain = 1,
		bs3D = 2
	}

	[TypeLibType((short)0)]
	public enum InitializeQTMLOptionsEnum
	{
		qtocInitializeQTMLStandard = 0
	}

	[TypeLibType((short)0)]
	public enum QTErrorEventOriginEnum
	{
		qtErrorEventOriginControl = 0,
		qtErrorEventOriginMovie = 1,
		qtErrorEventOriginQuickTime = 2
	}

	[TypeLibType((short)0)]
	public enum QTFullScreenFlagsEnum
	{
		qtFullScreenFlagHideCursor = 1,
		qtFullScreenFlagAllowEvents = 2,
		qtFullScreenFlagDontChangeMenuBar = 4,
		qtFullScreenDefaultFlags = 6
	}

	[TypeLibType((short)0)]
	public enum QTFullScreenSizingModeEnum
	{
		qtFullScreenMovieFitsMonitor = 1,
		qtFullScreenMovieFitsMonitorMaintainAspectRatio = 2,
		qtFullScreenMovieCenteredInMonitor = 3,
		qtFullScreenManualSizing = 4
	}

	[TypeLibType((short)0)]
	public enum QTInitializeQTMLFlagsEnum
	{
		qtInitializeQTMLFlagNoSound = 1,
		qtInitializeQTMLFlagUseGDI = 2,
		qtInitializeQTMLFlagDisableDirectSound = 4,
		qtInitializeQTMLFlagUseExclusiveFullScreenMode = 8
	}

	[TypeLibType((short)0)]
	public enum QTOpenMovieFlagsEnum
	{
		qtOpenMovieFlagActive = 1,
		qtOpenMovieFlagDontResolveDataRefs = 2,
		qtOpenMovieFlagDontAskUnresolvedDataRefs = 4,
		qtOpenMovieFlagDontAutoAlternates = 8,
		qtOpenMovieFlagAsyncOK = 256,
		qtOpenMovieFlagIdleImportOK = 1024,
		qtOpenMovieFlagDontInteractWithUser = 2048,
		qtOpenMovieDefaultFlags = 1025
	}

	[TypeLibType((short)0)]
	public enum QTSizingModeEnum
	{
		qtControlFitsMovie = 0,
		qtMovieFitsControl = 1,
		qtMovieFitsControlMaintainAspectRatio = 2,
		qtMovieCenteredInControl = 3,
		qtManualSizing = 4
	}

	[TypeLibType((short)0)]
	public enum QTStatusCodesEnum
	{
		qtStatusNone = 0,
		qtStatusConnecting = 2,
		qtStatusNegotiating = 5,
		qtStatusRequestedData = 11,
		qtStatusBuffering = 12,
		qtStatusURLChanged = 4096,
		qtStatusFullScreenBegin = 4097,
		qtStatusFullScreenEnd = 4098,
		qtStatusMovieLoadFinalize = 4099,
		qtMovieLoadStateError = -1,
		qtMovieLoadStateLoading = 1000,
		qtMovieLoadStateLoaded = 2000,
		qtMovieLoadStatePlayable = 10000,
		qtMovieLoadStatePlaythroughOK = 20000,
		qtMovieLoadStateComplete = 100000
	}

	[TypeLibType((short)0)]
	public enum QTStatusCodeTypesEnum
	{
		qtStatusCodeTypeControl = 0,
		qtStatusCodeTypeMovieLoadState = 2
	}

	[Guid("614E1495-1014-44F8-B350-5344C0770C1E")]
	[ComImport]
	[TypeLibType((short)4096)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface _IQTControlEvents
	{
		[DispId(1)]
		void QTEvent (int EventClass, int EventID, int Phase, Apple.QTOLibrary.IQTEventObject EventObject, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);
		[DispId(2)]
		void SizeChanged (int Width, int Height);
		[DispId(3)]
		void Error (int ErrorCode, int Origin);
		[DispId(4)]
		void StatusUpdate (int StatusCodeType, int StatusCode, [MarshalAs(UnmanagedType.BStr)] string StatusMessage);
		[DispId(5)]
		void MouseDown (short Button, short Shift, short x, short y);
		[DispId(6)]
		void MouseUp (short Button, short Shift, short x, short y);
		[DispId(7)]
		void MouseMove (short Button, short Shift, short x, short y);
	}

	public delegate void _IQTControlEvents_QTEventEventHandler (int EventClass, int EventID, int Phase, Apple.QTOLibrary.IQTEventObject EventObject, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);
	public delegate void _IQTControlEvents_SizeChangedEventHandler (int Width, int Height);
	public delegate void _IQTControlEvents_ErrorEventHandler (int ErrorCode, int Origin);
	public delegate void _IQTControlEvents_StatusUpdateEventHandler (int StatusCodeType, int StatusCode, [MarshalAs(UnmanagedType.BStr)] string StatusMessage);
	public delegate void _IQTControlEvents_MouseDownEventHandler (short Button, short Shift, short x, short y);
	public delegate void _IQTControlEvents_MouseUpEventHandler (short Button, short Shift, short x, short y);
	public delegate void _IQTControlEvents_MouseMoveEventHandler (short Button, short Shift, short x, short y);
	[ComEventInterface(typeof(_IQTControlEvents),typeof(_IQTControlEvents_EventProvider))]
	[ComVisible(false)]
	public interface _IQTControlEvents_Event
	{
		event _IQTControlEvents_QTEventEventHandler QTEvent;
		event _IQTControlEvents_SizeChangedEventHandler SizeChanged;
		event _IQTControlEvents_ErrorEventHandler Error;
		event _IQTControlEvents_StatusUpdateEventHandler StatusUpdate;
		event _IQTControlEvents_MouseDownEventHandler MouseDown;
		event _IQTControlEvents_MouseUpEventHandler MouseUp;
		event _IQTControlEvents_MouseMoveEventHandler MouseMove;
	}

	[ClassInterface(ClassInterfaceType.None)]
	internal class _IQTControlEvents_SinkHelper: _IQTControlEvents
	{
		public int Cookie = 0;

		public event _IQTControlEvents_QTEventEventHandler QTEventDelegate = null;
		public void Set_QTEventDelegate(_IQTControlEvents_QTEventEventHandler deleg)
		{
			QTEventDelegate = deleg;
		}
		public bool Is_QTEventDelegate(_IQTControlEvents_QTEventEventHandler deleg)
		{
			return (QTEventDelegate == deleg);
		}
		public void Clear_QTEventDelegate()
		{
			QTEventDelegate = null;
		}
		void _IQTControlEvents.QTEvent (int EventClass, int EventID, int Phase, Apple.QTOLibrary.IQTEventObject EventObject, ref bool Cancel)
		{
			if (QTEventDelegate!=null)
				QTEventDelegate(EventClass, EventID, Phase, EventObject, ref Cancel);
		}

		public event _IQTControlEvents_SizeChangedEventHandler SizeChangedDelegate = null;
		public void Set_SizeChangedDelegate(_IQTControlEvents_SizeChangedEventHandler deleg)
		{
			SizeChangedDelegate = deleg;
		}
		public bool Is_SizeChangedDelegate(_IQTControlEvents_SizeChangedEventHandler deleg)
		{
			return (SizeChangedDelegate == deleg);
		}
		public void Clear_SizeChangedDelegate()
		{
			SizeChangedDelegate = null;
		}
		void _IQTControlEvents.SizeChanged (int Width, int Height)
		{
			if (SizeChangedDelegate!=null)
				SizeChangedDelegate(Width, Height);
		}

		public event _IQTControlEvents_ErrorEventHandler ErrorDelegate = null;
		public void Set_ErrorDelegate(_IQTControlEvents_ErrorEventHandler deleg)
		{
			ErrorDelegate = deleg;
		}
		public bool Is_ErrorDelegate(_IQTControlEvents_ErrorEventHandler deleg)
		{
			return (ErrorDelegate == deleg);
		}
		public void Clear_ErrorDelegate()
		{
			ErrorDelegate = null;
		}
		void _IQTControlEvents.Error (int ErrorCode, int Origin)
		{
			if (ErrorDelegate!=null)
				ErrorDelegate(ErrorCode, Origin);
		}

		public event _IQTControlEvents_StatusUpdateEventHandler StatusUpdateDelegate = null;
		public void Set_StatusUpdateDelegate(_IQTControlEvents_StatusUpdateEventHandler deleg)
		{
			StatusUpdateDelegate = deleg;
		}
		public bool Is_StatusUpdateDelegate(_IQTControlEvents_StatusUpdateEventHandler deleg)
		{
			return (StatusUpdateDelegate == deleg);
		}
		public void Clear_StatusUpdateDelegate()
		{
			StatusUpdateDelegate = null;
		}
		void _IQTControlEvents.StatusUpdate (int StatusCodeType, int StatusCode, string StatusMessage)
		{
			if (StatusUpdateDelegate!=null)
				StatusUpdateDelegate(StatusCodeType, StatusCode, StatusMessage);
		}

		public event _IQTControlEvents_MouseDownEventHandler MouseDownDelegate = null;
		public void Set_MouseDownDelegate(_IQTControlEvents_MouseDownEventHandler deleg)
		{
			MouseDownDelegate = deleg;
		}
		public bool Is_MouseDownDelegate(_IQTControlEvents_MouseDownEventHandler deleg)
		{
			return (MouseDownDelegate == deleg);
		}
		public void Clear_MouseDownDelegate()
		{
			MouseDownDelegate = null;
		}
		void _IQTControlEvents.MouseDown (short Button, short Shift, short x, short y)
		{
			if (MouseDownDelegate!=null)
				MouseDownDelegate(Button, Shift, x, y);
		}

		public event _IQTControlEvents_MouseUpEventHandler MouseUpDelegate = null;
		public void Set_MouseUpDelegate(_IQTControlEvents_MouseUpEventHandler deleg)
		{
			MouseUpDelegate = deleg;
		}
		public bool Is_MouseUpDelegate(_IQTControlEvents_MouseUpEventHandler deleg)
		{
			return (MouseUpDelegate == deleg);
		}
		public void Clear_MouseUpDelegate()
		{
			MouseUpDelegate = null;
		}
		void _IQTControlEvents.MouseUp (short Button, short Shift, short x, short y)
		{
			if (MouseUpDelegate!=null)
				MouseUpDelegate(Button, Shift, x, y);
		}

		public event _IQTControlEvents_MouseMoveEventHandler MouseMoveDelegate = null;
		public void Set_MouseMoveDelegate(_IQTControlEvents_MouseMoveEventHandler deleg)
		{
			MouseMoveDelegate = deleg;
		}
		public bool Is_MouseMoveDelegate(_IQTControlEvents_MouseMoveEventHandler deleg)
		{
			return (MouseMoveDelegate == deleg);
		}
		public void Clear_MouseMoveDelegate()
		{
			MouseMoveDelegate = null;
		}
		void _IQTControlEvents.MouseMove (short Button, short Shift, short x, short y)
		{
			if (MouseMoveDelegate!=null)
				MouseMoveDelegate(Button, Shift, x, y);
		}
	}

	internal class _IQTControlEvents_EventProvider: IDisposable, _IQTControlEvents_Event
	{
		UCOMIConnectionPointContainer ConnectionPointContainer;
		UCOMIConnectionPoint ConnectionPoint;
		_IQTControlEvents_SinkHelper EventSinkHelper;
		int ConnectionCount;

		// Constructor: remember ConnectionPointContainer
		_IQTControlEvents_EventProvider(object CPContainer) : base()
		{
			ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
		}

		// Force disconnection from ActiveX event source
		~_IQTControlEvents_EventProvider()
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
				Guid g = new Guid("614E1495-1014-44F8-B350-5344C0770C1E");
				ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
				EventSinkHelper = new _IQTControlEvents_SinkHelper();
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

		event _IQTControlEvents_QTEventEventHandler _IQTControlEvents_Event.QTEvent
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.QTEventDelegate += value;
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
						EventSinkHelper.QTEventDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event _IQTControlEvents_SizeChangedEventHandler _IQTControlEvents_Event.SizeChanged
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.SizeChangedDelegate += value;
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
						EventSinkHelper.SizeChangedDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event _IQTControlEvents_ErrorEventHandler _IQTControlEvents_Event.Error
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.ErrorDelegate += value;
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
						EventSinkHelper.ErrorDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event _IQTControlEvents_StatusUpdateEventHandler _IQTControlEvents_Event.StatusUpdate
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.StatusUpdateDelegate += value;
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
						EventSinkHelper.StatusUpdateDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event _IQTControlEvents_MouseDownEventHandler _IQTControlEvents_Event.MouseDown
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.MouseDownDelegate += value;
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
						EventSinkHelper.MouseDownDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event _IQTControlEvents_MouseUpEventHandler _IQTControlEvents_Event.MouseUp
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.MouseUpDelegate += value;
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
						EventSinkHelper.MouseUpDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event _IQTControlEvents_MouseMoveEventHandler _IQTControlEvents_Event.MouseMove
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.MouseMoveDelegate += value;
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
						EventSinkHelper.MouseMoveDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}
	}

	[Guid("89F5E74B-641D-48BD-BF81-DADCE7DC83FC")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTControl
	{
		[DispId(-552)]
		void ShowAboutBox ();

		[DispId(1)]
		int QuickTimeInitialize (object InitOptions, object InitFlags);

		[DispId(2)]
		void QuickTimeTerminate ();

		[DispId(36)]
		void _get_DataRef ([Out] out int pDataRef, [Out] out int pDataRefType);

		[DispId(35)]
		void _put_DataRef (int inDataRef, int inDataRefType, object inNewMovieFlags);

		[DispId(37)]
		void CreateNewMovie (object movieIsActive);

		[DispId(38)]
		void CreateNewMovieFromImages ([MarshalAs(UnmanagedType.BStr)] string bstrFirstFilePath, float rate, [MarshalAs(UnmanagedType.VariantBool)] bool rateIsFramesPerSecond);

		[DispId(39)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(39)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(8)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool IsQuickTimeAvailable (int howToCheck) /* property get method */;

		[DispId(15)]
		void SetScale (float x, object y);

		[DispId(40)]
		void MovieResizingLock ();

		[DispId(41)]
		void MovieResizingUnlock ();

		[DispId(48)]
		void SetSizing (QTSizingModeEnum sizingOption, [MarshalAs(UnmanagedType.VariantBool)] bool forceSizeUpdate);

		int _MovieControllerHandle
		{
			[DispId(11)]
			get;
		}

		int _MovieHandle
		{
			[DispId(10)]
			get;
			[DispId(10)]
			set;
		}

		string AutoPlay
		{
			[DispId(4099)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(4099)]
			set;
		}

		uint BackColor
		{
			[DispId(-501)]
			get;
			[DispId(-501)]
			set;
		}

		string BaseURL
		{
			[DispId(34)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(34)]
			set;
		}

		uint BorderColor
		{
			[DispId(-503)]
			get;
			[DispId(-503)]
			set;
		}

		BorderStylesEnum BorderStyle
		{
			[DispId(-504)]
			get;
			[DispId(-504)]
			set;
		}

		int ErrorCode
		{
			[DispId(6)]
			get;
		}

		int ErrorHandling
		{
			[DispId(19)]
			get;
			[DispId(19)]
			set;
		}

		string FileName
		{
			[DispId(52)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(52)]
			set;
		}

		bool FullScreen
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(18)]
			set;
		}

		int FullScreenEndKeyCode
		{
			[DispId(24)]
			get;
			[DispId(24)]
			set;
		}

		int FullScreenFlags
		{
			[DispId(23)]
			get;
			[DispId(23)]
			set;
		}

		int FullScreenHWND
		{
			[DispId(25)]
			get;
		}

		int FullScreenMonitorNumber
		{
			[DispId(50)]
			get;
			[DispId(50)]
			set;
		}

		QTFullScreenSizingModeEnum FullScreenSizing
		{
			[DispId(51)]
			get;
			[DispId(51)]
			set;
		}

		int hWnd
		{
			[DispId(-515)]
			get;
		}

		Apple.QTOLibrary.IQTMovie Movie
		{
			[DispId(4)]
			get;
		}

		bool MovieControllerVisible
		{
			[DispId(12)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(12)]
			set;
		}

		int NewMovieFlags
		{
			[DispId(49)]
			get;
			[DispId(49)]
			set;
		}

		Apple.QTOLibrary.IQTQuickTime QuickTime
		{
			[DispId(5)]
			get;
		}

		int QuickTimeVersion
		{
			[DispId(9)]
			get;
		}

		float ScaleX
		{
			[DispId(13)]
			get;
			[DispId(13)]
			set;
		}

		float ScaleY
		{
			[DispId(14)]
			get;
			[DispId(14)]
			set;
		}

		QTSizingModeEnum Sizing
		{
			[DispId(21)]
			get;
			[DispId(21)]
			set;
		}

		string URL
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			set;
		}

		string Version
		{
			[DispId(22)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("9B1B71F6-6C61-463E-ABDB-88667073D16B")]
	[ComImport]
	[TypeLibType((short)0)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IQTControlParams
	{
	}

	[Guid("89F5E74B-641D-48BD-BF81-DADCE7DC83FC")]
	[ComImport]
	[CoClass(typeof(QTControlClass))]
	public interface QTControl: IQTControl
	{
	}

	[Guid("24BA3CAF-4BE8-4AEC-A7C8-6F47D5684602")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("_IQTControlEvents")]
	public class QTControlClass // : Apple.QTOLibrary._IQTControlFireEvent, IQTControl, QTControl, _IQTControlEvents_Event
	{
	}

	// [ComImport, Guid( <Undefined> )]
	[CoClass(typeof(QTControlPropPageClass))]
	public interface QTControlPropPage
	{
	}

	[Guid("A6C538C6-4A26-4839-B0D2-BF0406A4B299")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTControlPropPageClass // : QTControlPropPage
	{
	}
}
