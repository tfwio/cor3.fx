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

// Change the following attribute values to modify
// the information associated with an assembly.
//[assembly: AssemblyTitle("Shell32")]
//[assembly: AssemblyDescription("Microsoft Shell Controls And Automation (translated by Aurigma COM to .NET)")]
//[assembly: AssemblyVersion("1.0")]
//[assembly: AssemblyConfiguration("Retail")]
//[assembly: AssemblyCompany("Aurigma Inc.")]
//[assembly: AssemblyProduct("Shell32 translated by Aurigma COM to .NET")]
//[assembly: AssemblyCopyright("Copyright (c) 2003 by Aurigma Inc.")]
//[assembly: AssemblyTrademark("Aurigma COM to .NET")]

// Type library name: Shell32
// Type library description: Microsoft Shell Controls And Automation
// Type library version: 1.0
// Type library language: Neutral
// Type library guid: {50A7E9B0-70EF-11D1-B75A-00A0C90564FE}
// Type library source file name: C:\WINDOWS\system32\SHELL32.dll

namespace Shell32
{
	[Guid("35F1A0D0-3E9A-11D2-8499-005345000000")]
	[TypeLibType((short)0)]
	public enum OfflineFolderStatus
	{
		OFS_INACTIVE = -1,

		OFS_ONLINE = 0,

		OFS_OFFLINE = 1,

		OFS_SERVERBACK = 2,

		OFS_DIRTYCACHE = 3
	}

	[Guid("418F4E6A-B903-11D1-B0A6-00C04FC33AA5")]
	[TypeLibType((short)0)]
	public enum SearchCommandExecuteErrors
	{
		SCEE_PATHNOTFOUND = 1,
		SCEE_MAXFILESFOUND = 2,
		SCEE_INDEXSEARCH = 3,
		SCEE_CONSTRAINT = 4,
		SCEE_SCOPEMISMATCH = 5,
		SCEE_CASESENINDEX = 6,
		SCEE_INDEXNOTCOMPLETE = 7
	}

	[Guid("742A99A0-C77E-11D0-A32C-00A0C91EEDBA")]
	[TypeLibType((short)0)]
	public enum ShellFolderViewOptions
	{
		SFVVO_SHOWALLOBJECTS = 1,
		SFVVO_SHOWEXTENSIONS = 2,
		SFVVO_SHOWCOMPCOLOR = 8,
		SFVVO_SHOWSYSFILES = 32,
		SFVVO_WIN95CLASSIC = 64,
		SFVVO_DOUBLECLICKINWEBVIEW = 128,
		SFVVO_DESKTOPHTML = 512
	}

	[Guid("CA31EA20-48D0-11CF-8350-444553540000")]
	[TypeLibType((short)0)]
	public enum ShellSpecialFolderConstants
	{
		ssfDESKTOP = 0,
		ssfPROGRAMS = 2,
		ssfCONTROLS = 3,
		ssfPRINTERS = 4,
		ssfPERSONAL = 5,
		ssfFAVORITES = 6,
		ssfSTARTUP = 7,
		ssfRECENT = 8,
		ssfSENDTO = 9,
		ssfBITBUCKET = 10,
		ssfSTARTMENU = 11,
		ssfDESKTOPDIRECTORY = 16,
		ssfDRIVES = 17,
		ssfNETWORK = 18,
		ssfNETHOOD = 19,
		ssfFONTS = 20,
		ssfTEMPLATES = 21,
		ssfCOMMONSTARTMENU = 22,
		ssfCOMMONPROGRAMS = 23,
		ssfCOMMONSTARTUP = 24,
		ssfCOMMONDESKTOPDIR = 25,
		ssfAPPDATA = 26,
		ssfPRINTHOOD = 27,
		ssfLOCALAPPDATA = 28,
		ssfALTSTARTUP = 29,
		ssfCOMMONALTSTARTUP = 30,
		ssfCOMMONFAVORITES = 31,
		ssfINTERNETCACHE = 32,
		ssfCOOKIES = 33,
		ssfHISTORY = 34,
		ssfCOMMONAPPDATA = 35,
		ssfWINDOWS = 36,
		ssfSYSTEM = 37,
		ssfPROGRAMFILES = 38,
		ssfMYPICTURES = 39,
		ssfPROFILE = 40,
		ssfSYSTEMx86 = 41,
		ssfPROGRAMFILESx86 = 48
	}

	[Guid("4A3DF050-23BD-11D2-939F-00A0C91EEDBA")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface DFConstraint
	{
		string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		object Value
		{
			[DispId(1610743809)]
			get;
		}
	}

	[Guid("60890160-69F0-11D1-B758-00A0C90564FE")]
	[ComImport]
	[TypeLibType((short)4096)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface DSearchCommandEvents
	{
		[DispId(1)]
		void SearchStart ();

		[DispId(2)]
		void SearchComplete ();

		[DispId(3)]
		void SearchAbort ();

		[DispId(4)]
		void RecordsetUpdate ();

		[DispId(5)]
		void ProgressTextChanged ();

		[DispId(6)]
		void SearchError ();

		[DispId(7)]
		void SearchRestored ();
	}

	public delegate void DSearchCommandEvents_SearchStartEventHandler ();

	public delegate void DSearchCommandEvents_SearchCompleteEventHandler ();

	public delegate void DSearchCommandEvents_SearchAbortEventHandler ();

	public delegate void DSearchCommandEvents_RecordsetUpdateEventHandler ();

	public delegate void DSearchCommandEvents_ProgressTextChangedEventHandler ();

	public delegate void DSearchCommandEvents_SearchErrorEventHandler ();

	public delegate void DSearchCommandEvents_SearchRestoredEventHandler ();

	[ComEventInterface(typeof(DSearchCommandEvents),typeof(DSearchCommandEvents_EventProvider))]
	[ComVisible(false)]
	public interface DSearchCommandEvents_Event
	{
		event DSearchCommandEvents_SearchStartEventHandler SearchStart;

		event DSearchCommandEvents_SearchCompleteEventHandler SearchComplete;

		event DSearchCommandEvents_SearchAbortEventHandler SearchAbort;

		event DSearchCommandEvents_RecordsetUpdateEventHandler RecordsetUpdate;

		event DSearchCommandEvents_ProgressTextChangedEventHandler ProgressTextChanged;

		event DSearchCommandEvents_SearchErrorEventHandler SearchError;

		event DSearchCommandEvents_SearchRestoredEventHandler SearchRestored;
	}

	[ClassInterface(ClassInterfaceType.None)]
	internal class DSearchCommandEvents_SinkHelper: DSearchCommandEvents
	{
		public int Cookie = 0;

		public event DSearchCommandEvents_SearchStartEventHandler SearchStartDelegate = null;
		public void Set_SearchStartDelegate(DSearchCommandEvents_SearchStartEventHandler deleg)
		{
			SearchStartDelegate = deleg;
		}
		public bool Is_SearchStartDelegate(DSearchCommandEvents_SearchStartEventHandler deleg)
		{
			return (SearchStartDelegate == deleg);
		}
		public void Clear_SearchStartDelegate()
		{
			SearchStartDelegate = null;
		}
		void DSearchCommandEvents.SearchStart ()
		{
			if (SearchStartDelegate!=null)
				SearchStartDelegate();
		}

		public event DSearchCommandEvents_SearchCompleteEventHandler SearchCompleteDelegate = null;
		public void Set_SearchCompleteDelegate(DSearchCommandEvents_SearchCompleteEventHandler deleg)
		{
			SearchCompleteDelegate = deleg;
		}
		public bool Is_SearchCompleteDelegate(DSearchCommandEvents_SearchCompleteEventHandler deleg)
		{
			return (SearchCompleteDelegate == deleg);
		}
		public void Clear_SearchCompleteDelegate()
		{
			SearchCompleteDelegate = null;
		}
		void DSearchCommandEvents.SearchComplete ()
		{
			if (SearchCompleteDelegate!=null)
				SearchCompleteDelegate();
		}

		public event DSearchCommandEvents_SearchAbortEventHandler SearchAbortDelegate = null;
		public void Set_SearchAbortDelegate(DSearchCommandEvents_SearchAbortEventHandler deleg)
		{
			SearchAbortDelegate = deleg;
		}
		public bool Is_SearchAbortDelegate(DSearchCommandEvents_SearchAbortEventHandler deleg)
		{
			return (SearchAbortDelegate == deleg);
		}
		public void Clear_SearchAbortDelegate()
		{
			SearchAbortDelegate = null;
		}
		void DSearchCommandEvents.SearchAbort ()
		{
			if (SearchAbortDelegate!=null)
				SearchAbortDelegate();
		}

		public event DSearchCommandEvents_RecordsetUpdateEventHandler RecordsetUpdateDelegate = null;
		public void Set_RecordsetUpdateDelegate(DSearchCommandEvents_RecordsetUpdateEventHandler deleg)
		{
			RecordsetUpdateDelegate = deleg;
		}
		public bool Is_RecordsetUpdateDelegate(DSearchCommandEvents_RecordsetUpdateEventHandler deleg)
		{
			return (RecordsetUpdateDelegate == deleg);
		}
		public void Clear_RecordsetUpdateDelegate()
		{
			RecordsetUpdateDelegate = null;
		}
		void DSearchCommandEvents.RecordsetUpdate ()
		{
			if (RecordsetUpdateDelegate!=null)
				RecordsetUpdateDelegate();
		}

		public event DSearchCommandEvents_ProgressTextChangedEventHandler ProgressTextChangedDelegate = null;
		public void Set_ProgressTextChangedDelegate(DSearchCommandEvents_ProgressTextChangedEventHandler deleg)
		{
			ProgressTextChangedDelegate = deleg;
		}
		public bool Is_ProgressTextChangedDelegate(DSearchCommandEvents_ProgressTextChangedEventHandler deleg)
		{
			return (ProgressTextChangedDelegate == deleg);
		}
		public void Clear_ProgressTextChangedDelegate()
		{
			ProgressTextChangedDelegate = null;
		}
		void DSearchCommandEvents.ProgressTextChanged ()
		{
			if (ProgressTextChangedDelegate!=null)
				ProgressTextChangedDelegate();
		}

		public event DSearchCommandEvents_SearchErrorEventHandler SearchErrorDelegate = null;
		public void Set_SearchErrorDelegate(DSearchCommandEvents_SearchErrorEventHandler deleg)
		{
			SearchErrorDelegate = deleg;
		}
		public bool Is_SearchErrorDelegate(DSearchCommandEvents_SearchErrorEventHandler deleg)
		{
			return (SearchErrorDelegate == deleg);
		}
		public void Clear_SearchErrorDelegate()
		{
			SearchErrorDelegate = null;
		}
		void DSearchCommandEvents.SearchError ()
		{
			if (SearchErrorDelegate!=null)
				SearchErrorDelegate();
		}

		public event DSearchCommandEvents_SearchRestoredEventHandler SearchRestoredDelegate = null;
		public void Set_SearchRestoredDelegate(DSearchCommandEvents_SearchRestoredEventHandler deleg)
		{
			SearchRestoredDelegate = deleg;
		}
		public bool Is_SearchRestoredDelegate(DSearchCommandEvents_SearchRestoredEventHandler deleg)
		{
			return (SearchRestoredDelegate == deleg);
		}
		public void Clear_SearchRestoredDelegate()
		{
			SearchRestoredDelegate = null;
		}
		void DSearchCommandEvents.SearchRestored ()
		{
			if (SearchRestoredDelegate!=null)
				SearchRestoredDelegate();
		}
	}

	internal class DSearchCommandEvents_EventProvider: IDisposable, DSearchCommandEvents_Event
	{
		UCOMIConnectionPointContainer ConnectionPointContainer;
		UCOMIConnectionPoint ConnectionPoint;
		DSearchCommandEvents_SinkHelper EventSinkHelper;
		int ConnectionCount;

		// Constructor: remember ConnectionPointContainer
		DSearchCommandEvents_EventProvider(object CPContainer) : base()
		{
			ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
		}

		// Force disconnection from ActiveX event source
		~DSearchCommandEvents_EventProvider()
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
				Guid g = new Guid("60890160-69F0-11D1-B758-00A0C90564FE");
				ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
				EventSinkHelper = new DSearchCommandEvents_SinkHelper();
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

		event DSearchCommandEvents_SearchStartEventHandler DSearchCommandEvents_Event.SearchStart
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.SearchStartDelegate += value;
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
						EventSinkHelper.SearchStartDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DSearchCommandEvents_SearchCompleteEventHandler DSearchCommandEvents_Event.SearchComplete
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.SearchCompleteDelegate += value;
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
						EventSinkHelper.SearchCompleteDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DSearchCommandEvents_SearchAbortEventHandler DSearchCommandEvents_Event.SearchAbort
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.SearchAbortDelegate += value;
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
						EventSinkHelper.SearchAbortDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DSearchCommandEvents_RecordsetUpdateEventHandler DSearchCommandEvents_Event.RecordsetUpdate
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.RecordsetUpdateDelegate += value;
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
						EventSinkHelper.RecordsetUpdateDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DSearchCommandEvents_ProgressTextChangedEventHandler DSearchCommandEvents_Event.ProgressTextChanged
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.ProgressTextChangedDelegate += value;
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
						EventSinkHelper.ProgressTextChangedDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DSearchCommandEvents_SearchErrorEventHandler DSearchCommandEvents_Event.SearchError
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.SearchErrorDelegate += value;
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
						EventSinkHelper.SearchErrorDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DSearchCommandEvents_SearchRestoredEventHandler DSearchCommandEvents_Event.SearchRestored
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.SearchRestoredDelegate += value;
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
						EventSinkHelper.SearchRestoredDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}
	}

	[Guid("62112AA2-EBE4-11CF-A5FB-0020AFE7292D")]
	[ComImport]
	[TypeLibType((short)4096)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface DShellFolderViewEvents
	{
		[DispId(200)]
		void SelectionChanged ();

		[DispId(201)]
		void EnumDone ();

		[DispId(202)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool VerbInvoked ();

		[DispId(203)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool DefaultVerbInvoked ();

		[DispId(204)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool BeginDrag ();
	}

	public delegate void DShellFolderViewEvents_SelectionChangedEventHandler ();

	public delegate void DShellFolderViewEvents_EnumDoneEventHandler ();

	[return: MarshalAs(UnmanagedType.VariantBool)]
	public delegate bool DShellFolderViewEvents_VerbInvokedEventHandler ();

	[return: MarshalAs(UnmanagedType.VariantBool)]
	public delegate bool DShellFolderViewEvents_DefaultVerbInvokedEventHandler ();

	[return: MarshalAs(UnmanagedType.VariantBool)]
	public delegate bool DShellFolderViewEvents_BeginDragEventHandler ();

	[ComEventInterface(typeof(DShellFolderViewEvents),typeof(DShellFolderViewEvents_EventProvider))]
	[ComVisible(false)]
	public interface DShellFolderViewEvents_Event
	{
		event DShellFolderViewEvents_SelectionChangedEventHandler SelectionChanged;

		event DShellFolderViewEvents_EnumDoneEventHandler EnumDone;

		event DShellFolderViewEvents_VerbInvokedEventHandler VerbInvoked;

		event DShellFolderViewEvents_DefaultVerbInvokedEventHandler DefaultVerbInvoked;

		event DShellFolderViewEvents_BeginDragEventHandler BeginDrag;
	}

	[ClassInterface(ClassInterfaceType.None)]
	internal class DShellFolderViewEvents_SinkHelper: DShellFolderViewEvents
	{
		public int Cookie = 0;

		public event DShellFolderViewEvents_SelectionChangedEventHandler SelectionChangedDelegate = null;
		public void Set_SelectionChangedDelegate(DShellFolderViewEvents_SelectionChangedEventHandler deleg)
		{
			SelectionChangedDelegate = deleg;
		}
		public bool Is_SelectionChangedDelegate(DShellFolderViewEvents_SelectionChangedEventHandler deleg)
		{
			return (SelectionChangedDelegate == deleg);
		}
		public void Clear_SelectionChangedDelegate()
		{
			SelectionChangedDelegate = null;
		}
		public // HACK
		void /*DShellFolderViewEvents.*/SelectionChanged ()
		{
			if (SelectionChangedDelegate!=null)
				SelectionChangedDelegate();
		}

		public event DShellFolderViewEvents_EnumDoneEventHandler EnumDoneDelegate = null;
		public void Set_EnumDoneDelegate(DShellFolderViewEvents_EnumDoneEventHandler deleg)
		{
			EnumDoneDelegate = deleg;
		}
		public bool Is_EnumDoneDelegate(DShellFolderViewEvents_EnumDoneEventHandler deleg)
		{
			return (EnumDoneDelegate == deleg);
		}
		public void Clear_EnumDoneDelegate()
		{
			EnumDoneDelegate = null;
		}
		public // HACK
		void /*DShellFolderViewEvents.*/EnumDone ()
		{
			if (EnumDoneDelegate!=null)
				EnumDoneDelegate();
		}

		public event DShellFolderViewEvents_VerbInvokedEventHandler VerbInvokedDelegate = null;
		public void Set_VerbInvokedDelegate(DShellFolderViewEvents_VerbInvokedEventHandler deleg)
		{
			VerbInvokedDelegate = deleg;
		}
		public bool Is_VerbInvokedDelegate(DShellFolderViewEvents_VerbInvokedEventHandler deleg)
		{
			return (VerbInvokedDelegate == deleg);
		}
		public void Clear_VerbInvokedDelegate()
		{
			VerbInvokedDelegate = null;
		}
		public // added with commenting the bottom
		// HACK: was void. Implemented RETURN VALUES
		bool /*DShellFolderViewEvents.*/
			VerbInvoked ()
		{
			if (VerbInvokedDelegate!=null)
				return VerbInvokedDelegate();
			return false;
		}

		public event DShellFolderViewEvents_DefaultVerbInvokedEventHandler DefaultVerbInvokedDelegate = null;
		public void Set_DefaultVerbInvokedDelegate(DShellFolderViewEvents_DefaultVerbInvokedEventHandler deleg)
		{
			DefaultVerbInvokedDelegate = deleg;
		}
		public bool Is_DefaultVerbInvokedDelegate(DShellFolderViewEvents_DefaultVerbInvokedEventHandler deleg)
		{
			return (DefaultVerbInvokedDelegate == deleg);
		}
		public void Clear_DefaultVerbInvokedDelegate()
		{
			DefaultVerbInvokedDelegate = null;
		}
		public // added with commenting the bottom
		bool /*DShellFolderViewEvents.*/
			// HACK: was void. Implemented RETURN VALUES
			DefaultVerbInvoked ()
		{
			if (DefaultVerbInvokedDelegate!=null)
				return DefaultVerbInvokedDelegate();
			return false;
		}

		public event DShellFolderViewEvents_BeginDragEventHandler BeginDragDelegate = null;
		public void Set_BeginDragDelegate(DShellFolderViewEvents_BeginDragEventHandler deleg)
		{
			BeginDragDelegate = deleg;
		}
		public bool Is_BeginDragDelegate(DShellFolderViewEvents_BeginDragEventHandler deleg)
		{
			return (BeginDragDelegate == deleg);
		}
		public void Clear_BeginDragDelegate()
		{
			BeginDragDelegate = null;
		}
		public // added with commenting the bottom
			// HACK: was void. Implemented RETURN VALUES
		bool /*DShellFolderViewEvents.*/BeginDrag ()
		{
			if (BeginDragDelegate!=null)
				return BeginDragDelegate();
			return false;
		}
	}

	internal class DShellFolderViewEvents_EventProvider: IDisposable, DShellFolderViewEvents_Event
	{
		UCOMIConnectionPointContainer ConnectionPointContainer;
		UCOMIConnectionPoint ConnectionPoint;
		DShellFolderViewEvents_SinkHelper EventSinkHelper;
		int ConnectionCount;

		// Constructor: remember ConnectionPointContainer
		DShellFolderViewEvents_EventProvider(object CPContainer) : base()
		{
			ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
		}

		// Force disconnection from ActiveX event source
		~DShellFolderViewEvents_EventProvider()
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
				Guid g = new Guid("62112AA2-EBE4-11CF-A5FB-0020AFE7292D");
				ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
				EventSinkHelper = new DShellFolderViewEvents_SinkHelper();
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

		event DShellFolderViewEvents_SelectionChangedEventHandler DShellFolderViewEvents_Event.SelectionChanged
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.SelectionChangedDelegate += value;
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
						EventSinkHelper.SelectionChangedDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DShellFolderViewEvents_EnumDoneEventHandler DShellFolderViewEvents_Event.EnumDone
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.EnumDoneDelegate += value;
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
						EventSinkHelper.EnumDoneDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DShellFolderViewEvents_VerbInvokedEventHandler DShellFolderViewEvents_Event.VerbInvoked
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.VerbInvokedDelegate += value;
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
						EventSinkHelper.VerbInvokedDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DShellFolderViewEvents_DefaultVerbInvokedEventHandler DShellFolderViewEvents_Event.DefaultVerbInvoked
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.DefaultVerbInvokedDelegate += value;
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
						EventSinkHelper.DefaultVerbInvokedDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}

		event DShellFolderViewEvents_BeginDragEventHandler DShellFolderViewEvents_Event.BeginDrag
		{
			add
			{
				System.Threading.Monitor.Enter(this);
				try {
					Connect();
					EventSinkHelper.BeginDragDelegate += value;
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
						EventSinkHelper.BeginDragDelegate -= value;
						CheckDisconnect();
					} catch { }
					System.Threading.Monitor.Exit(this);
				}
			}
		}
	}

	[Guid("BBCBDE60-C3FF-11CE-8350-444553540000")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Title")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface Folder
	{
		[DispId(1610743812)]
		FolderItems Items ();

		[DispId(1610743813)]
		FolderItem ParseName ([MarshalAs(UnmanagedType.BStr)] string bName);

		[DispId(1610743814)]
		void NewFolder ([MarshalAs(UnmanagedType.BStr)] string bName, object vOptions);

		[DispId(1610743815)]
		void MoveHere (object vItem, object vOptions);

		[DispId(1610743816)]
		void CopyHere (object vItem, object vOptions);

		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetDetailsOf (object vItem, int iColumn);

		object Application
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object Parent
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		Folder ParentFolder
		{
			[DispId(1610743811)]
			get;
		}

		string Title
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("F0D2D8EF-3890-11D2-BF8B-00C04FB93661")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Title")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface Folder2
	{
		[DispId(1610743812)]
		FolderItems Items ();

		[DispId(1610743813)]
		FolderItem ParseName ([MarshalAs(UnmanagedType.BStr)] string bName);

		[DispId(1610743814)]
		void NewFolder ([MarshalAs(UnmanagedType.BStr)] string bName, object vOptions);

		[DispId(1610743815)]
		void MoveHere (object vItem, object vOptions);

		[DispId(1610743816)]
		void CopyHere (object vItem, object vOptions);

		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetDetailsOf (object vItem, int iColumn);

		[DispId(1610809346)]
		void Synchronize ();

		[DispId(1610809348)]
		void DismissedWebViewBarricade ();

		object Application
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		bool HaveToShowWebViewBarricade
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		int OfflineStatus
		{
			[DispId(1610809345)]
			get;
		}

		object Parent
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		Folder ParentFolder
		{
			[DispId(1610743811)]
			get;
		}

		FolderItem Self
		{
			[DispId(1610809344)]
			get;
		}

		string Title
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("A7AE5F64-C4D7-4D7F-9307-4D24EE54B841")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Title")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface Folder3
	{
		[DispId(1610743812)]
		FolderItems Items ();

		[DispId(1610743813)]
		FolderItem ParseName ([MarshalAs(UnmanagedType.BStr)] string bName);

		[DispId(1610743814)]
		void NewFolder ([MarshalAs(UnmanagedType.BStr)] string bName, object vOptions);

		[DispId(1610743815)]
		void MoveHere (object vItem, object vOptions);

		[DispId(1610743816)]
		void CopyHere (object vItem, object vOptions);

		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetDetailsOf (object vItem, int iColumn);

		[DispId(1610809346)]
		void Synchronize ();

		[DispId(1610809348)]
		void DismissedWebViewBarricade ();

		object Application
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		bool HaveToShowWebViewBarricade
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		int OfflineStatus
		{
			[DispId(1610809345)]
			get;
		}

		object Parent
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		Folder ParentFolder
		{
			[DispId(1610743811)]
			get;
		}

		FolderItem Self
		{
			[DispId(1610809344)]
			get;
		}

		bool ShowWebViewBarricade
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(2)]
			set;
		}

		string Title
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("FAC32C80-CBE4-11CE-8350-444553540000")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Name")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FolderItem
	{
		[DispId(1610743823)]
		FolderItemVerbs Verbs ();

		[DispId(1610743824)]
		void InvokeVerb (object vVerb);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object GetFolder
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object GetLink
		{
			[DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		bool IsBrowsable
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		bool IsFileSystem
		{
			[DispId(1610743817)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		bool IsFolder
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		bool IsLink
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		System.DateTime ModifyDate
		{
			[DispId(1610743819)]
			get;
			[DispId(1610743819)]
			set;
		}

		string Name
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(0)]
			set;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		string Path
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Size
		{
			[DispId(1610743821)]
			get;
		}

		string Type
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("EDC817AA-92B8-11D1-B075-00C04FC33AA5")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Name")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FolderItem2
	{
		[DispId(1610743823)]
		FolderItemVerbs Verbs ();

		[DispId(1610743824)]
		void InvokeVerb (object vVerb);

		[DispId(1610809344)]
		void InvokeVerbEx (object vVerb, object vArgs);

		[DispId(1610809345)]
		object ExtendedProperty ([MarshalAs(UnmanagedType.BStr)] string bstrPropName);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object GetFolder
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object GetLink
		{
			[DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		bool IsBrowsable
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		bool IsFileSystem
		{
			[DispId(1610743817)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		bool IsFolder
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		bool IsLink
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		System.DateTime ModifyDate
		{
			[DispId(1610743819)]
			get;
			[DispId(1610743819)]
			set;
		}

		string Name
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(0)]
			set;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		string Path
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Size
		{
			[DispId(1610743821)]
			get;
		}

		string Type
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("744129E0-CBE5-11CE-8350-444553540000")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FolderItems: System.Collections.IEnumerable
	{
		[DispId(1610743811)]
		FolderItem Item (object index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object _NewEnum ();

		object Application
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		int Count
		{
			[DispId(1610743808)]
			get;
		}

		object Parent
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("C94F0AD0-F363-11D2-A327-00C04F8EEC7F")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FolderItems2: System.Collections.IEnumerable
	{
		[DispId(1610743811)]
		FolderItem Item (object index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object _NewEnum ();

		[DispId(1610809344)]
		void InvokeVerbEx (object vVerb, object vArgs);

		object Application
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		int Count
		{
			[DispId(1610743808)]
			get;
		}

		object Parent
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("EAA7C309-BBEC-49D5-821D-64D966CB667F")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Verbs")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FolderItems3: System.Collections.IEnumerable
	{
		[DispId(1610743811)]
		FolderItem Item (object index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object _NewEnum ();

		[DispId(1610809344)]
		void InvokeVerbEx (object vVerb, object vArgs);

		[DispId(1610874880)]
		void Filter (int grfFlags, [MarshalAs(UnmanagedType.BStr)] string bstrFileSpec);

		object Application
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		int Count
		{
			[DispId(1610743808)]
			get;
		}

		object Parent
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		FolderItemVerbs Verbs
		{
			[DispId(0)]
			get;
		}
	}

	[Guid("08EC3E00-50B0-11CF-960C-0080C7F4EE85")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Name")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FolderItemVerb
	{
		[DispId(1610743811)]
		void DoIt ();

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		string Name
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("1F8352C0-50B0-11CF-960C-0080C7F4EE85")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface FolderItemVerbs: System.Collections.IEnumerable
	{
		[DispId(1610743811)]
		FolderItemVerb Item (object index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object _NewEnum ();

		object Application
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		int Count
		{
			[DispId(1610743808)]
			get;
		}

		object Parent
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("2D91EEA1-9932-11D2-BE86-00A0C9A83DA1")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IFileSearchBand
	{
		[DispId(1)]
		void SetFocus ();

		[DispId(2)]
		void SetSearchParameters ([In, MarshalAs(UnmanagedType.BStr)] ref string pbstrSearchID, [MarshalAs(UnmanagedType.VariantBool)] bool bNavToResults, [In] ref object pvarScope, [In] ref object pvarQueryFile);

		object QueryFile
		{
			[DispId(5)]
			get;
		}

		object Scope
		{
			[DispId(4)]
			get;
		}

		string SearchID
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("9BA05970-F6A8-11CF-A442-00A0C90A8F39")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IFolderViewOC
	{
		[DispId(1610743808)]
		void SetFolderView ([MarshalAs(UnmanagedType.IDispatch)] object pdisp);
	}

	[Guid("0751C551-7568-41C9-8E5B-E22E38919236")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("FinalBack")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface INewWDEvents
	{
		[DispId(0)]
		void FinalBack ();

		[DispId(1)]
		void FinalNext ();

		[DispId(2)]
		void Cancel ();

		[DispId(4)]
		void Property ([MarshalAs(UnmanagedType.BStr)] string bstrPropertyName, [In] ref object value) /* property put method */;

		[DispId(4)]
		object Property ([MarshalAs(UnmanagedType.BStr)] string bstrPropertyName) /* property get method */;

		[DispId(5)]
		void SetWizardButtons ([MarshalAs(UnmanagedType.VariantBool)] bool vfEnableBack, [MarshalAs(UnmanagedType.VariantBool)] bool vfEnableNext, [MarshalAs(UnmanagedType.VariantBool)] bool vfLastPage);

		[DispId(6)]
		void SetHeaderText ([MarshalAs(UnmanagedType.BStr)] string bstrHeaderTitle, [MarshalAs(UnmanagedType.BStr)] string bstrHeaderSubtitle);

		[DispId(7)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool PassportAuthenticate ([MarshalAs(UnmanagedType.BStr)] string bstrSignInUrl);

		string Caption
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			set;
		}
	}

	[Guid("B30F7305-5967-45D1-B7BC-D6EB7163D770")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("MemberExists")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IPassportClientServices
	{
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool MemberExists ([MarshalAs(UnmanagedType.BStr)] string bstrUser, [MarshalAs(UnmanagedType.BStr)] string bstrPassword);
	}

	[Guid("1D2EFD50-75CE-11D1-B75A-00A0C90564FE")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ISearchCommandExt
	{
		[DispId(1)]
		void ClearResults ();

		[DispId(2)]
		void NavigateToSearchResults ();

		[DispId(4)]
		void SaveSearch ();

		[DispId(5)]
		int GetErrorInfo ([Out, MarshalAs(UnmanagedType.BStr)] out string pbs);

		[DispId(6)]
		void SearchFor (int iFor);

		[DispId(7)]
		void GetScopeInfo ([MarshalAs(UnmanagedType.BStr)] string bsScope, [Out] out int pdwScopeInfo);

		[DispId(8)]
		void RestoreSavedSearch ([In] ref object pvarFile);

		[DispId(100)]
		void Execute ([In] ref object RecordsAffected, [In] ref object Parameters, int Options);

		[DispId(101)]
		void AddConstraint ([MarshalAs(UnmanagedType.BStr)] string Name, object Value);

		[DispId(102)]
		DFConstraint GetNextConstraint ([MarshalAs(UnmanagedType.VariantBool)] bool fReset);

		string ProgressText
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("D8F015C0-C278-11CE-A49E-444553540000")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellDispatch
	{
		[DispId(1610743810)]
		Folder NameSpace (object vDir);

		[DispId(1610743811)]
		Folder BrowseForFolder (int Hwnd, [MarshalAs(UnmanagedType.BStr)] string Title, int Options, object RootFolder);

		[DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Windows ();

		[DispId(1610743813)]
		void Open (object vDir);

		[DispId(1610743814)]
		void Explore (object vDir);

		[DispId(1610743815)]
		void MinimizeAll ();

		[DispId(1610743816)]
		void UndoMinimizeALL ();

		[DispId(1610743817)]
		void FileRun ();

		[DispId(1610743818)]
		void CascadeWindows ();

		[DispId(1610743819)]
		void TileVertically ();

		[DispId(1610743820)]
		void TileHorizontally ();

		[DispId(1610743821)]
		void ShutdownWindows ();

		[DispId(1610743822)]
		void Suspend ();

		[DispId(1610743823)]
		void EjectPC ();

		[DispId(1610743824)]
		void SetTime ();

		[DispId(1610743825)]
		void TrayProperties ();

		[DispId(1610743826)]
		void Help ();

		[DispId(1610743827)]
		void FindFiles ();

		[DispId(1610743828)]
		void FindComputer ();

		[DispId(1610743829)]
		void RefreshMenu ();

		[DispId(1610743830)]
		void ControlPanelItem ([MarshalAs(UnmanagedType.BStr)] string szDir);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("A4C6892C-3BA9-11D2-9DEA-00C04FB16162")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellDispatch2
	{
		[DispId(1610743810)]
		Folder NameSpace (object vDir);

		[DispId(1610743811)]
		Folder BrowseForFolder (int Hwnd, [MarshalAs(UnmanagedType.BStr)] string Title, int Options, object RootFolder);

		[DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Windows ();

		[DispId(1610743813)]
		void Open (object vDir);

		[DispId(1610743814)]
		void Explore (object vDir);

		[DispId(1610743815)]
		void MinimizeAll ();

		[DispId(1610743816)]
		void UndoMinimizeALL ();

		[DispId(1610743817)]
		void FileRun ();

		[DispId(1610743818)]
		void CascadeWindows ();

		[DispId(1610743819)]
		void TileVertically ();

		[DispId(1610743820)]
		void TileHorizontally ();

		[DispId(1610743821)]
		void ShutdownWindows ();

		[DispId(1610743822)]
		void Suspend ();

		[DispId(1610743823)]
		void EjectPC ();

		[DispId(1610743824)]
		void SetTime ();

		[DispId(1610743825)]
		void TrayProperties ();

		[DispId(1610743826)]
		void Help ();

		[DispId(1610743827)]
		void FindFiles ();

		[DispId(1610743828)]
		void FindComputer ();

		[DispId(1610743829)]
		void RefreshMenu ();

		[DispId(1610743830)]
		void ControlPanelItem ([MarshalAs(UnmanagedType.BStr)] string szDir);

		[DispId(1610809344)]
		int IsRestricted ([MarshalAs(UnmanagedType.BStr)] string Group, [MarshalAs(UnmanagedType.BStr)] string Restriction);

		[DispId(1610809345)]
		void ShellExecute ([MarshalAs(UnmanagedType.BStr)] string File, object vArgs, object vDir, object vOperation, object vShow);

		[DispId(1610809346)]
		void FindPrinter ([MarshalAs(UnmanagedType.BStr)] string Name, [MarshalAs(UnmanagedType.BStr)] string location, [MarshalAs(UnmanagedType.BStr)] string model);

		[DispId(1610809347)]
		object GetSystemInformation ([MarshalAs(UnmanagedType.BStr)] string Name);

		[DispId(1610809348)]
		object ServiceStart ([MarshalAs(UnmanagedType.BStr)] string ServiceName, object Persistent);

		[DispId(1610809349)]
		object ServiceStop ([MarshalAs(UnmanagedType.BStr)] string ServiceName, object Persistent);

		[DispId(1610809350)]
		object IsServiceRunning ([MarshalAs(UnmanagedType.BStr)] string ServiceName);

		[DispId(1610809351)]
		object CanStartStopService ([MarshalAs(UnmanagedType.BStr)] string ServiceName);

		[DispId(1610809352)]
		object ShowBrowserBar ([MarshalAs(UnmanagedType.BStr)] string bstrClsid, object bShow);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("177160CA-BB5A-411C-841D-BD38FACDEAA0")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellDispatch3
	{
		[DispId(1610743810)]
		Folder NameSpace (object vDir);

		[DispId(1610743811)]
		Folder BrowseForFolder (int Hwnd, [MarshalAs(UnmanagedType.BStr)] string Title, int Options, object RootFolder);

		[DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Windows ();

		[DispId(1610743813)]
		void Open (object vDir);

		[DispId(1610743814)]
		void Explore (object vDir);

		[DispId(1610743815)]
		void MinimizeAll ();

		[DispId(1610743816)]
		void UndoMinimizeALL ();

		[DispId(1610743817)]
		void FileRun ();

		[DispId(1610743818)]
		void CascadeWindows ();

		[DispId(1610743819)]
		void TileVertically ();

		[DispId(1610743820)]
		void TileHorizontally ();

		[DispId(1610743821)]
		void ShutdownWindows ();

		[DispId(1610743822)]
		void Suspend ();

		[DispId(1610743823)]
		void EjectPC ();

		[DispId(1610743824)]
		void SetTime ();

		[DispId(1610743825)]
		void TrayProperties ();

		[DispId(1610743826)]
		void Help ();

		[DispId(1610743827)]
		void FindFiles ();

		[DispId(1610743828)]
		void FindComputer ();

		[DispId(1610743829)]
		void RefreshMenu ();

		[DispId(1610743830)]
		void ControlPanelItem ([MarshalAs(UnmanagedType.BStr)] string szDir);

		[DispId(1610809344)]
		int IsRestricted ([MarshalAs(UnmanagedType.BStr)] string Group, [MarshalAs(UnmanagedType.BStr)] string Restriction);

		[DispId(1610809345)]
		void ShellExecute ([MarshalAs(UnmanagedType.BStr)] string File, object vArgs, object vDir, object vOperation, object vShow);

		[DispId(1610809346)]
		void FindPrinter ([MarshalAs(UnmanagedType.BStr)] string Name, [MarshalAs(UnmanagedType.BStr)] string location, [MarshalAs(UnmanagedType.BStr)] string model);

		[DispId(1610809347)]
		object GetSystemInformation ([MarshalAs(UnmanagedType.BStr)] string Name);

		[DispId(1610809348)]
		object ServiceStart ([MarshalAs(UnmanagedType.BStr)] string ServiceName, object Persistent);

		[DispId(1610809349)]
		object ServiceStop ([MarshalAs(UnmanagedType.BStr)] string ServiceName, object Persistent);

		[DispId(1610809350)]
		object IsServiceRunning ([MarshalAs(UnmanagedType.BStr)] string ServiceName);

		[DispId(1610809351)]
		object CanStartStopService ([MarshalAs(UnmanagedType.BStr)] string ServiceName);

		[DispId(1610809352)]
		object ShowBrowserBar ([MarshalAs(UnmanagedType.BStr)] string bstrClsid, object bShow);

		[DispId(1610874880)]
		void AddToRecent (object varFile, [MarshalAs(UnmanagedType.BStr)] string bstrCategory);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("EFD84B2D-4BCF-4298-BE25-EB542A59FBDA")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellDispatch4
	{
		[DispId(1610743810)]
		Folder NameSpace (object vDir);

		[DispId(1610743811)]
		Folder BrowseForFolder (int Hwnd, [MarshalAs(UnmanagedType.BStr)] string Title, int Options, object RootFolder);

		[DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Windows ();

		[DispId(1610743813)]
		void Open (object vDir);

		[DispId(1610743814)]
		void Explore (object vDir);

		[DispId(1610743815)]
		void MinimizeAll ();

		[DispId(1610743816)]
		void UndoMinimizeALL ();

		[DispId(1610743817)]
		void FileRun ();

		[DispId(1610743818)]
		void CascadeWindows ();

		[DispId(1610743819)]
		void TileVertically ();

		[DispId(1610743820)]
		void TileHorizontally ();

		[DispId(1610743821)]
		void ShutdownWindows ();

		[DispId(1610743822)]
		void Suspend ();

		[DispId(1610743823)]
		void EjectPC ();

		[DispId(1610743824)]
		void SetTime ();

		[DispId(1610743825)]
		void TrayProperties ();

		[DispId(1610743826)]
		void Help ();

		[DispId(1610743827)]
		void FindFiles ();

		[DispId(1610743828)]
		void FindComputer ();

		[DispId(1610743829)]
		void RefreshMenu ();

		[DispId(1610743830)]
		void ControlPanelItem ([MarshalAs(UnmanagedType.BStr)] string szDir);

		[DispId(1610809344)]
		int IsRestricted ([MarshalAs(UnmanagedType.BStr)] string Group, [MarshalAs(UnmanagedType.BStr)] string Restriction);

		[DispId(1610809345)]
		void ShellExecute ([MarshalAs(UnmanagedType.BStr)] string File, object vArgs, object vDir, object vOperation, object vShow);

		[DispId(1610809346)]
		void FindPrinter ([MarshalAs(UnmanagedType.BStr)] string Name, [MarshalAs(UnmanagedType.BStr)] string location, [MarshalAs(UnmanagedType.BStr)] string model);

		[DispId(1610809347)]
		object GetSystemInformation ([MarshalAs(UnmanagedType.BStr)] string Name);

		[DispId(1610809348)]
		object ServiceStart ([MarshalAs(UnmanagedType.BStr)] string ServiceName, object Persistent);

		[DispId(1610809349)]
		object ServiceStop ([MarshalAs(UnmanagedType.BStr)] string ServiceName, object Persistent);

		[DispId(1610809350)]
		object IsServiceRunning ([MarshalAs(UnmanagedType.BStr)] string ServiceName);

		[DispId(1610809351)]
		object CanStartStopService ([MarshalAs(UnmanagedType.BStr)] string ServiceName);

		[DispId(1610809352)]
		object ShowBrowserBar ([MarshalAs(UnmanagedType.BStr)] string bstrClsid, object bShow);

		[DispId(1610874880)]
		void AddToRecent (object varFile, [MarshalAs(UnmanagedType.BStr)] string bstrCategory);

		[DispId(1610940416)]
		void WindowsSecurity ();

		[DispId(1610940417)]
		void ToggleDesktop ();

		[DispId(1610940418)]
		object ExplorerPolicy ([MarshalAs(UnmanagedType.BStr)] string bstrPolicyName);

		[DispId(1610940419)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool GetSetting (int lSetting);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[Guid("E7A1AF80-4D96-11CF-960C-0080C7F4EE85")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellFolderViewDual
	{
		[DispId(1610743811)]
		FolderItems SelectedItems ();

		[DispId(1610743813)]
		void SelectItem ([In] ref object pvfi, int dwFlags);

		[DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string PopupItemMenu (FolderItem pfi, object vx, object vy);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		FolderItem FocusedItem
		{
			[DispId(1610743812)]
			get;
		}

		Folder Folder
		{
			[DispId(1610743810)]
			get;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object Script
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		int ViewOptions
		{
			[DispId(1610743816)]
			get;
		}
	}

	[Guid("31C147B6-0ADE-4A3C-B514-DDF932EF6D17")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellFolderViewDual2
	{
		[DispId(1610743811)]
		FolderItems SelectedItems ();

		[DispId(1610743813)]
		void SelectItem ([In] ref object pvfi, int dwFlags);

		[DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string PopupItemMenu (FolderItem pfi, object vx, object vy);

		[DispId(1610809346)]
		void SelectItemRelative (int iRelative);

		object Application
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		uint CurrentViewMode
		{
			[DispId(1610809344)]
			get;
			[DispId(1610809344)]
			set;
		}

		FolderItem FocusedItem
		{
			[DispId(1610743812)]
			get;
		}

		Folder Folder
		{
			[DispId(1610743810)]
			get;
		}

		object Parent
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		object Script
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}

		int ViewOptions
		{
			[DispId(1610743816)]
			get;
		}
	}

	[Guid("88A05C00-F000-11CE-8350-444553540000")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellLinkDual
	{
		[DispId(1610743820)]
		void Resolve (int fFlags);

		[DispId(1610743821)]
		int GetIconLocation ([Out, MarshalAs(UnmanagedType.BStr)] out string pbs);

		[DispId(1610743822)]
		void SetIconLocation ([MarshalAs(UnmanagedType.BStr)] string bs, int iIcon);

		[DispId(1610743823)]
		void Save (object vWhere);

		string Arguments
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			set;
		}

		string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			set;
		}

		int Hotkey
		{
			[DispId(1610743816)]
			get;
			[DispId(1610743816)]
			set;
		}

		string Path
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			set;
		}

		int ShowCommand
		{
			[DispId(1610743818)]
			get;
			[DispId(1610743818)]
			set;
		}

		string WorkingDirectory
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			set;
		}
	}

	[Guid("317EE249-F12E-11D2-B1E4-00C04F8EEB3E")]
	[ComImport]
	[TypeLibType((short)4176)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IShellLinkDual2
	{
		[DispId(1610743820)]
		void Resolve (int fFlags);

		[DispId(1610743821)]
		int GetIconLocation ([Out, MarshalAs(UnmanagedType.BStr)] out string pbs);

		[DispId(1610743822)]
		void SetIconLocation ([MarshalAs(UnmanagedType.BStr)] string bs, int iIcon);

		[DispId(1610743823)]
		void Save (object vWhere);

		string Arguments
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			set;
		}

		string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			set;
		}

		int Hotkey
		{
			[DispId(1610743816)]
			get;
			[DispId(1610743816)]
			set;
		}

		string Path
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			set;
		}

		int ShowCommand
		{
			[DispId(1610743818)]
			get;
			[DispId(1610743818)]
			set;
		}

		FolderItem Target
		{
			[DispId(1610809344)]
			get;
		}

		string WorkingDirectory
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			set;
		}
	}

	[Guid("18BCC359-4990-4BFB-B951-3C83702BE5F9")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("FinalBack")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IWebWizardHost
	{
		[DispId(0)]
		void FinalBack ();

		[DispId(1)]
		void FinalNext ();

		[DispId(2)]
		void Cancel ();

		[DispId(4)]
		void Property ([MarshalAs(UnmanagedType.BStr)] string bstrPropertyName, [In] ref object value) /* property put method */;

		[DispId(4)]
		object Property ([MarshalAs(UnmanagedType.BStr)] string bstrPropertyName) /* property get method */;

		[DispId(5)]
		void SetWizardButtons ([MarshalAs(UnmanagedType.VariantBool)] bool vfEnableBack, [MarshalAs(UnmanagedType.VariantBool)] bool vfEnableNext, [MarshalAs(UnmanagedType.VariantBool)] bool vfLastPage);

		[DispId(6)]
		void SetHeaderText ([MarshalAs(UnmanagedType.BStr)] string bstrHeaderTitle, [MarshalAs(UnmanagedType.BStr)] string bstrHeaderSubtitle);

		string Caption
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			set;
		}
	}

	[Guid("2D91EEA1-9932-11D2-BE86-00A0C9A83DA1")]
	[ComImport]
	[CoClass(typeof(FileSearchBandClass))]
	public interface FileSearchBand: IFileSearchBand
	{
	}

	[Guid("C4EE31F3-4768-11D2-BE5C-00A0C9A83DA1")]
	[ComImport]
	[TypeLibType((short)18)]
	[ClassInterface(ClassInterfaceType.None)]
	public class FileSearchBandClass // : IFileSearchBand, FileSearchBand
	{
	}

	[Guid("B30F7305-5967-45D1-B7BC-D6EB7163D770")]
	[ComImport]
	[CoClass(typeof(PassportClientServicesClass))]
	public interface PassportClientServices: IPassportClientServices
	{
	}

	[Guid("2D2307C8-7DB4-40D6-9100-D52AF4F97A5B")]
	[ComImport]
	[TypeLibType((short)18)]
	[ClassInterface(ClassInterfaceType.None)]
	public class PassportClientServicesClass // : IPassportClientServices, PassportClientServices
	{
	}

	// [ComImport, Guid( <Undefined> )]
	[CoClass(typeof(SearchCommandClass))]
	public interface SearchCommand
	{
	}

	[Guid("B005E690-678D-11D1-B758-00A0C90564FE")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("DSearchCommandEvents")]
	public class SearchCommandClass // : SearchCommand, DSearchCommandEvents_Event
	{
	}

	[Guid("D8F015C0-C278-11CE-A49E-444553540000")]
	[ComImport]
	[CoClass(typeof(ShellClass))]
	public interface Shell: IShellDispatch
	{
	}

	[Guid("13709620-C279-11CE-A49E-444553540000")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class ShellClass // : IShellDispatch, Shell
	{
	}

	// [ComImport, Guid( <Undefined> )]
	[CoClass(typeof(ShellDispatchInprocClass))]
	public interface ShellDispatchInproc
	{
	}

	[Guid("0A89A860-D7B1-11CE-8350-444553540000")]
	[ComImport]
	[TypeLibType((short)18)]
	[ClassInterface(ClassInterfaceType.None)]
	public class ShellDispatchInprocClass // : ShellDispatchInproc
	{
	}

	[Guid("EDC817AA-92B8-11D1-B075-00C04FC33AA5")]
	[ComImport]
	[CoClass(typeof(ShellFolderItemClass))]
	public interface ShellFolderItem: FolderItem2
	{
	}

	[Guid("2FE352EA-FD1F-11D2-B1F4-00C04F8EEB3E")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class ShellFolderItemClass // : FolderItem2, ShellFolderItem
	{
	}

	[Guid("31C147B6-0ADE-4A3C-B514-DDF932EF6D17")]
	[ComImport]
	[CoClass(typeof(ShellFolderViewClass))]
	public interface ShellFolderView: IShellFolderViewDual2
	{
	}

	[Guid("62112AA1-EBE4-11CF-A5FB-0020AFE7292D")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("DShellFolderViewEvents")]
	public class ShellFolderViewClass // : IShellFolderViewDual2, ShellFolderView, DShellFolderViewEvents_Event
	{
	}

	[Guid("9BA05970-F6A8-11CF-A442-00A0C90A8F39")]
	[ComImport]
	[CoClass(typeof(ShellFolderViewOCClass))]
	public interface ShellFolderViewOC: IFolderViewOC
	{
	}

	[Guid("9BA05971-F6A8-11CF-A442-00A0C90A8F39")]
	[ComImport]
	[TypeLibType((short)18)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("DShellFolderViewEvents")]
	public class ShellFolderViewOCClass // : IFolderViewOC, ShellFolderViewOC, DShellFolderViewEvents_Event
	{
	}

	[Guid("88A05C00-F000-11CE-8350-444553540000")]
	[ComImport]
	[CoClass(typeof(ShellLinkObjectClass))]
	public interface ShellLinkObject: IShellLinkDual
	{
	}

	[Guid("11219420-1768-11D1-95BE-00609797EA4F")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class ShellLinkObjectClass // : IShellLinkDual, ShellLinkObject
	{
	}

	[Guid("E7A1AF80-4D96-11CF-960C-0080C7F4EE85")]
	[ComImport]
	[CoClass(typeof(WebViewFolderContentsClass))]
	public interface WebViewFolderContents: IShellFolderViewDual
	{
	}

	[Guid("1820FED0-473E-11D0-A96C-00C04FD705A2")]
	[ComImport]
	[TypeLibType((short)18)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("DShellFolderViewEvents")]
	public class WebViewFolderContentsClass // : IShellFolderViewDual, WebViewFolderContents, DShellFolderViewEvents_Event
	{
	}
}
