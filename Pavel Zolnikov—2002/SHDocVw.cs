//*****************************************************************//
//                                                                 //
// This file is generated automatically by Aurigma COM to .NET 1.0 //
//                                                                 //
//*****************************************************************//
#pragma warning disable 618

using System;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
/*
// Change the following attribute values to modify
// the information associated with an assembly.
[assembly: AssemblyTitle("SHDocVw")]
[assembly: AssemblyDescription("Microsoft Internet Controls (translated by Aurigma COM to .NET)")]
[assembly: AssemblyVersion("1.1")]
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyCompany("Aurigma Inc.")]
[assembly: AssemblyProduct("SHDocVw translated by Aurigma COM to .NET")]
[assembly: AssemblyCopyright("Copyright (c) 2003 by Aurigma Inc.")]
[assembly: AssemblyTrademark("Aurigma COM to .NET")]
*/
// Type library name: SHDocVw
// Type library description: Microsoft Internet Controls
// Type library version: 1.1
// Type library language: Neutral
// Type library guid: {EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}
// Type library source file name: C:\WINDOWS\system32\ieframe.dll

namespace SHDocVw
{

  public enum BrowserNavConstants {
    navOpenInNewWindow = 0x1,
    navNoHistory = 0x2,
    navNoReadFromCache = 0x4,
    navNoWriteToCache = 0x8,
    navAllowAutosearch = 0x10,
    navBrowserBar = 0x20,
    navHyperlink = 0x40,
    navEnforceRestricted = 0x80,
    navNewWindowsManaged = 0x0100,
    navUntrustedForDownload = 0x0200,
    navTrustedForActiveX = 0x0400,
    navOpenInNewTab = 0x0800,
    navOpenInBackgroundTab = 0x1000,
    navKeepWordWheelText = 0x2000,
    navVirtualTab = 0x4000,
    navBlockRedirectsXDomain = 0x8000,
    navOpenNewForegroundTab = 0x10000
}/* BrowserNavConstants;*/
	
  [Guid("34A226E0-DF30-11CF-89A9-00A0C9054129")]
  [TypeLibType((short)0)]
  public enum CommandStateChangeConstants
  {
    CSC_UPDATECOMMANDS = -1,

    CSC_NAVIGATEFORWARD = 1,

    CSC_NAVIGATEBACK = 2
  }

  [Guid("A8317D46-03CB-4975-AE94-85E9F2E1D020")]
  [TypeLibType((short)0)]
  public enum NewProcessCauseConstants
  {
    ProtectedModeRedirect = 1
  }

  [TypeLibType((short)0)]
  public enum OLECMDEXECOPT
  {
    OLECMDEXECOPT_DODEFAULT = 0,

    OLECMDEXECOPT_PROMPTUSER = 1,

    OLECMDEXECOPT_DONTPROMPTUSER = 2,

    OLECMDEXECOPT_SHOWHELP = 3
  }

  [TypeLibType((short)0)]
  public enum OLECMDF
  {
    OLECMDF_SUPPORTED = 1,

    OLECMDF_ENABLED = 2,

    OLECMDF_LATCHED = 4,

    OLECMDF_NINCHED = 8,

    OLECMDF_INVISIBLE = 16,

    OLECMDF_DEFHIDEONCTXTMENU = 32
  }

  [TypeLibType((short)0)]
  public enum OLECMDID
  {
    OLECMDID_OPEN = 1,

    OLECMDID_NEW = 2,

    OLECMDID_SAVE = 3,

    OLECMDID_SAVEAS = 4,

    OLECMDID_SAVECOPYAS = 5,

    OLECMDID_PRINT = 6,

    OLECMDID_PRINTPREVIEW = 7,

    OLECMDID_PAGESETUP = 8,

    OLECMDID_SPELL = 9,

    OLECMDID_PROPERTIES = 10,

    OLECMDID_CUT = 11,

    OLECMDID_COPY = 12,

    OLECMDID_PASTE = 13,

    OLECMDID_PASTESPECIAL = 14,

    OLECMDID_UNDO = 15,

    OLECMDID_REDO = 16,

    OLECMDID_SELECTALL = 17,

    OLECMDID_CLEARSELECTION = 18,

    OLECMDID_ZOOM = 19,

    OLECMDID_GETZOOMRANGE = 20,

    OLECMDID_UPDATECOMMANDS = 21,

    OLECMDID_REFRESH = 22,

    OLECMDID_STOP = 23,

    OLECMDID_HIDETOOLBARS = 24,

    OLECMDID_SETPROGRESSMAX = 25,

    OLECMDID_SETPROGRESSPOS = 26,

    OLECMDID_SETPROGRESSTEXT = 27,

    OLECMDID_SETTITLE = 28,

    OLECMDID_SETDOWNLOADSTATE = 29,

    OLECMDID_STOPDOWNLOAD = 30,

    OLECMDID_ONTOOLBARACTIVATED = 31,

    OLECMDID_FIND = 32,

    OLECMDID_DELETE = 33,

    OLECMDID_HTTPEQUIV = 34,

    OLECMDID_HTTPEQUIV_DONE = 35,

    OLECMDID_ENABLE_INTERACTION = 36,

    OLECMDID_ONUNLOAD = 37,

    OLECMDID_PROPERTYBAG2 = 38,

    OLECMDID_PREREFRESH = 39,

    OLECMDID_SHOWSCRIPTERROR = 40,

    OLECMDID_SHOWMESSAGE = 41,

    OLECMDID_SHOWFIND = 42,

    OLECMDID_SHOWPAGESETUP = 43,

    OLECMDID_SHOWPRINT = 44,

    OLECMDID_CLOSE = 45,

    OLECMDID_ALLOWUILESSSAVEAS = 46,

    OLECMDID_DONTDOWNLOADCSS = 47,

    OLECMDID_UPDATEPAGESTATUS = 48,

    OLECMDID_PRINT2 = 49,

    OLECMDID_PRINTPREVIEW2 = 50,

    OLECMDID_SETPRINTTEMPLATE = 51,

    OLECMDID_GETPRINTTEMPLATE = 52,

    OLECMDID_PAGEACTIONBLOCKED = 55,

    OLECMDID_PAGEACTIONUIQUERY = 56,

    OLECMDID_FOCUSVIEWCONTROLS = 57,

    OLECMDID_FOCUSVIEWCONTROLSQUERY = 58,

    OLECMDID_SHOWPAGEACTIONMENU = 59,

    OLECMDID_ADDTRAVELENTRY = 60,

    OLECMDID_UPDATETRAVELENTRY = 61,

    OLECMDID_UPDATEBACKFORWARDSTATE = 62,

    OLECMDID_OPTICAL_ZOOM = 63,

    OLECMDID_OPTICAL_GETZOOMRANGE = 64,

    OLECMDID_WINDOWSTATECHANGED = 65,

    OLECMDID_ACTIVEXINSTALLSCOPE = 66,

    OLECMDID_UPDATETRAVELENTRY_DATARECOVERY = 67
  }

  [Guid("65507BE0-91A8-11D3-A845-009027220E6D")]
  [TypeLibType((short)0)]
  public enum SecureLockIconConstants
  {
    secureLockIconUnsecure = 0,

    secureLockIconMixed = 1,

    secureLockIconSecureUnknownBits = 2,

    secureLockIconSecure40Bit = 3,

    secureLockIconSecure56Bit = 4,

    secureLockIconSecureFortezza = 5,

    secureLockIconSecure128Bit = 6
  }

  [Guid("7716A370-38CA-11D0-A48B-00A0C90A8F39")]
  [TypeLibType((short)16)]
  public enum ShellWindowFindWindowOptions
  {
    SWFO_NEEDDISPATCH = 1,

    SWFO_INCLUDEPENDING = 2,

    SWFO_COOKIEPASSED = 4
  }

  [Guid("F41E6981-28E5-11D0-82B4-00A0C90C29C5")]
  [TypeLibType((short)0)]
  public enum ShellWindowTypeConstants
  {
    SWC_EXPLORER = 0,

    SWC_BROWSER = 1,

    SWC_3RDPARTY = 2,

    SWC_CALLBACK = 4,

    SWC_DESKTOP = 8
  }

  [TypeLibType((short)0)]
  public enum tagREADYSTATE
  {
    READYSTATE_UNINITIALIZED = 0,

    READYSTATE_LOADING = 1,

    READYSTATE_LOADED = 2,

    READYSTATE_INTERACTIVE = 3,

    READYSTATE_COMPLETE = 4
  }

  [Guid("55136806-B2DE-11D1-B9F2-00A0C98BC547")]
  [ComImport]
  [TypeLibType((short)4096)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface DShellNameSpaceEvents
  {
    [DispId(1)]
    void FavoritesSelectionChange (int cItems, int hItem, [MarshalAs(UnmanagedType.BStr)] string strName, [MarshalAs(UnmanagedType.BStr)] string strUrl, int cVisits, [MarshalAs(UnmanagedType.BStr)] string strDate, int fAvailableOffline);

    [DispId(2)]
    void SelectionChange ();

    [DispId(3)]
    void DoubleClick ();

    [DispId(4)]
    void Initialized ();
  }

  public delegate void DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler (int cItems, int hItem, [MarshalAs(UnmanagedType.BStr)] string strName, [MarshalAs(UnmanagedType.BStr)] string strUrl, int cVisits, [MarshalAs(UnmanagedType.BStr)] string strDate, int fAvailableOffline);

  public delegate void DShellNameSpaceEvents_SelectionChangeEventHandler ();

  public delegate void DShellNameSpaceEvents_DoubleClickEventHandler ();

  public delegate void DShellNameSpaceEvents_InitializedEventHandler ();

  [ComEventInterface(typeof(DShellNameSpaceEvents),typeof(DShellNameSpaceEvents_EventProvider))]
  [ComVisible(false)]
  public interface DShellNameSpaceEvents_Event
  {
    event DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler FavoritesSelectionChange;

    event DShellNameSpaceEvents_SelectionChangeEventHandler SelectionChange;

    event DShellNameSpaceEvents_DoubleClickEventHandler DoubleClick;

    event DShellNameSpaceEvents_InitializedEventHandler Initialized;
  }

  [ClassInterface(ClassInterfaceType.None)]
  internal class DShellNameSpaceEvents_SinkHelper: DShellNameSpaceEvents
  {
    public int Cookie = 0;

    public event DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler FavoritesSelectionChangeDelegate = null;
    public void Set_FavoritesSelectionChangeDelegate(DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler deleg)
    {
      FavoritesSelectionChangeDelegate = deleg;
    }
    public bool Is_FavoritesSelectionChangeDelegate(DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler deleg)
    {
      return (FavoritesSelectionChangeDelegate == deleg);
    }
    public void Clear_FavoritesSelectionChangeDelegate()
    {
      FavoritesSelectionChangeDelegate = null;
    }
    void DShellNameSpaceEvents.FavoritesSelectionChange (int cItems, int hItem, string strName, string strUrl, int cVisits, string strDate, int fAvailableOffline)
    {
      if (FavoritesSelectionChangeDelegate!=null)
        FavoritesSelectionChangeDelegate(cItems, hItem, strName, strUrl, cVisits, strDate, fAvailableOffline);
    }

    public event DShellNameSpaceEvents_SelectionChangeEventHandler SelectionChangeDelegate = null;
    public void Set_SelectionChangeDelegate(DShellNameSpaceEvents_SelectionChangeEventHandler deleg)
    {
      SelectionChangeDelegate = deleg;
    }
    public bool Is_SelectionChangeDelegate(DShellNameSpaceEvents_SelectionChangeEventHandler deleg)
    {
      return (SelectionChangeDelegate == deleg);
    }
    public void Clear_SelectionChangeDelegate()
    {
      SelectionChangeDelegate = null;
    }
    void DShellNameSpaceEvents.SelectionChange ()
    {
      if (SelectionChangeDelegate!=null)
        SelectionChangeDelegate();
    }

    public event DShellNameSpaceEvents_DoubleClickEventHandler DoubleClickDelegate = null;
    public void Set_DoubleClickDelegate(DShellNameSpaceEvents_DoubleClickEventHandler deleg)
    {
      DoubleClickDelegate = deleg;
    }
    public bool Is_DoubleClickDelegate(DShellNameSpaceEvents_DoubleClickEventHandler deleg)
    {
      return (DoubleClickDelegate == deleg);
    }
    public void Clear_DoubleClickDelegate()
    {
      DoubleClickDelegate = null;
    }
    void DShellNameSpaceEvents.DoubleClick ()
    {
      if (DoubleClickDelegate!=null)
        DoubleClickDelegate();
    }

    public event DShellNameSpaceEvents_InitializedEventHandler InitializedDelegate = null;
    public void Set_InitializedDelegate(DShellNameSpaceEvents_InitializedEventHandler deleg)
    {
      InitializedDelegate = deleg;
    }
    public bool Is_InitializedDelegate(DShellNameSpaceEvents_InitializedEventHandler deleg)
    {
      return (InitializedDelegate == deleg);
    }
    public void Clear_InitializedDelegate()
    {
      InitializedDelegate = null;
    }
    void DShellNameSpaceEvents.Initialized ()
    {
      if (InitializedDelegate!=null)
        InitializedDelegate();
    }
  }

  internal class DShellNameSpaceEvents_EventProvider: IDisposable, DShellNameSpaceEvents_Event
  {
    UCOMIConnectionPointContainer ConnectionPointContainer;
    UCOMIConnectionPoint ConnectionPoint;
    DShellNameSpaceEvents_SinkHelper EventSinkHelper;
    int ConnectionCount;

    // Constructor: remember ConnectionPointContainer
    DShellNameSpaceEvents_EventProvider(object CPContainer) : base()
    {
      ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
    }

    // Force disconnection from ActiveX event source
    ~DShellNameSpaceEvents_EventProvider()
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
        Guid g = new Guid("55136806-B2DE-11D1-B9F2-00A0C98BC547");
        ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
        EventSinkHelper = new DShellNameSpaceEvents_SinkHelper();
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

    event DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler DShellNameSpaceEvents_Event.FavoritesSelectionChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.FavoritesSelectionChangeDelegate += value;
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
            EventSinkHelper.FavoritesSelectionChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DShellNameSpaceEvents_SelectionChangeEventHandler DShellNameSpaceEvents_Event.SelectionChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.SelectionChangeDelegate += value;
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
            EventSinkHelper.SelectionChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DShellNameSpaceEvents_DoubleClickEventHandler DShellNameSpaceEvents_Event.DoubleClick
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.DoubleClickDelegate += value;
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
            EventSinkHelper.DoubleClickDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DShellNameSpaceEvents_InitializedEventHandler DShellNameSpaceEvents_Event.Initialized
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.InitializedDelegate += value;
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
            EventSinkHelper.InitializedDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }
  }

  [Guid("FE4106E0-399A-11D0-A48C-00A0C90A8F39")]
  [ComImport]
  [TypeLibType((short)4096)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface DShellWindowsEvents
  {
    [DispId(200)]
    void WindowRegistered (int lCookie);

    [DispId(201)]
    void WindowRevoked (int lCookie);
  }

  public delegate void DShellWindowsEvents_WindowRegisteredEventHandler (int lCookie);

  public delegate void DShellWindowsEvents_WindowRevokedEventHandler (int lCookie);

  [ComEventInterface(typeof(DShellWindowsEvents),typeof(DShellWindowsEvents_EventProvider))]
  [ComVisible(false)]
  public interface DShellWindowsEvents_Event
  {
    event DShellWindowsEvents_WindowRegisteredEventHandler WindowRegistered;

    event DShellWindowsEvents_WindowRevokedEventHandler WindowRevoked;
  }

  [ClassInterface(ClassInterfaceType.None)]
  internal class DShellWindowsEvents_SinkHelper: DShellWindowsEvents
  {
    public int Cookie = 0;

    public event DShellWindowsEvents_WindowRegisteredEventHandler WindowRegisteredDelegate = null;
    public void Set_WindowRegisteredDelegate(DShellWindowsEvents_WindowRegisteredEventHandler deleg)
    {
      WindowRegisteredDelegate = deleg;
    }
    public bool Is_WindowRegisteredDelegate(DShellWindowsEvents_WindowRegisteredEventHandler deleg)
    {
      return (WindowRegisteredDelegate == deleg);
    }
    public void Clear_WindowRegisteredDelegate()
    {
      WindowRegisteredDelegate = null;
    }
    void DShellWindowsEvents.WindowRegistered (int lCookie)
    {
      if (WindowRegisteredDelegate!=null)
        WindowRegisteredDelegate(lCookie);
    }

    public event DShellWindowsEvents_WindowRevokedEventHandler WindowRevokedDelegate = null;
    public void Set_WindowRevokedDelegate(DShellWindowsEvents_WindowRevokedEventHandler deleg)
    {
      WindowRevokedDelegate = deleg;
    }
    public bool Is_WindowRevokedDelegate(DShellWindowsEvents_WindowRevokedEventHandler deleg)
    {
      return (WindowRevokedDelegate == deleg);
    }
    public void Clear_WindowRevokedDelegate()
    {
      WindowRevokedDelegate = null;
    }
    void DShellWindowsEvents.WindowRevoked (int lCookie)
    {
      if (WindowRevokedDelegate!=null)
        WindowRevokedDelegate(lCookie);
    }
  }

  public class DShellWindowsEvents_EventProvider: IDisposable, DShellWindowsEvents_Event
  {
    UCOMIConnectionPointContainer ConnectionPointContainer;
    UCOMIConnectionPoint ConnectionPoint;
    DShellWindowsEvents_SinkHelper EventSinkHelper;
    int ConnectionCount;

    // Constructor: remember ConnectionPointContainer
    DShellWindowsEvents_EventProvider(object CPContainer) : base()
    {
      ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
    }

    // Force disconnection from ActiveX event source
    ~DShellWindowsEvents_EventProvider()
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
        Guid g = new Guid("FE4106E0-399A-11D0-A48C-00A0C90A8F39");
        ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
        EventSinkHelper = new DShellWindowsEvents_SinkHelper();
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

    event DShellWindowsEvents_WindowRegisteredEventHandler DShellWindowsEvents_Event.WindowRegistered
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowRegisteredDelegate += value;
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
            EventSinkHelper.WindowRegisteredDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DShellWindowsEvents_WindowRevokedEventHandler DShellWindowsEvents_Event.WindowRevoked
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowRevokedDelegate += value;
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
            EventSinkHelper.WindowRevokedDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }
  }

  [Guid("EAB22AC2-30C1-11CF-A7EB-0000C05BAE0B")]
  [ComImport]
  [TypeLibType((short)4112)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface DWebBrowserEvents
  {
    [DispId(100)]
    void BeforeNavigate ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(101)]
    void NavigateComplete ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(102)]
    void StatusTextChange ([MarshalAs(UnmanagedType.BStr)] string Text);

    [DispId(108)]
    void ProgressChange (int Progress, int ProgressMax);

    [DispId(104)]
    void DownloadComplete ();

    [DispId(105)]
    void CommandStateChange (int Command, [MarshalAs(UnmanagedType.VariantBool)] bool Enable);

    [DispId(106)]
    void DownloadBegin ();

    [DispId(107)]
    void NewWindow ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Processed);

    [DispId(113)]
    void TitleChange ([MarshalAs(UnmanagedType.BStr)] string Text);

    [DispId(200)]
    void FrameBeforeNavigate ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(201)]
    void FrameNavigateComplete ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(204)]
    void FrameNewWindow ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Processed);

    [DispId(103)]
    void Quit ([In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(109)]
    void WindowMove ();

    [DispId(110)]
    void WindowResize ();

    [DispId(111)]
    void WindowActivate ();

    [DispId(112)]
    void PropertyChange ([MarshalAs(UnmanagedType.BStr)] string Property);
  }

  public delegate void DWebBrowserEvents_BeforeNavigateEventHandler ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents_NavigateCompleteEventHandler ([MarshalAs(UnmanagedType.BStr)] string URL);

  public delegate void DWebBrowserEvents_StatusTextChangeEventHandler ([MarshalAs(UnmanagedType.BStr)] string Text);

  public delegate void DWebBrowserEvents_ProgressChangeEventHandler (int Progress, int ProgressMax);

  public delegate void DWebBrowserEvents_DownloadCompleteEventHandler ();

  public delegate void DWebBrowserEvents_CommandStateChangeEventHandler (int Command, [MarshalAs(UnmanagedType.VariantBool)] bool Enable);

  public delegate void DWebBrowserEvents_DownloadBeginEventHandler ();

  public delegate void DWebBrowserEvents_NewWindowEventHandler ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Processed);

  public delegate void DWebBrowserEvents_TitleChangeEventHandler ([MarshalAs(UnmanagedType.BStr)] string Text);

  public delegate void DWebBrowserEvents_FrameBeforeNavigateEventHandler ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents_FrameNavigateCompleteEventHandler ([MarshalAs(UnmanagedType.BStr)] string URL);

  public delegate void DWebBrowserEvents_FrameNewWindowEventHandler ([MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Processed);

  public delegate void DWebBrowserEvents_QuitEventHandler ([In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents_WindowMoveEventHandler ();

  public delegate void DWebBrowserEvents_WindowResizeEventHandler ();

  public delegate void DWebBrowserEvents_WindowActivateEventHandler ();

  public delegate void DWebBrowserEvents_PropertyChangeEventHandler ([MarshalAs(UnmanagedType.BStr)] string Property);

  [ComEventInterface(typeof(DWebBrowserEvents),typeof(DWebBrowserEvents_EventProvider))]
  [ComVisible(false)]
  public interface DWebBrowserEvents_Event
  {
    event DWebBrowserEvents_BeforeNavigateEventHandler BeforeNavigate;

    event DWebBrowserEvents_NavigateCompleteEventHandler NavigateComplete;

    event DWebBrowserEvents_StatusTextChangeEventHandler StatusTextChange;

    event DWebBrowserEvents_ProgressChangeEventHandler ProgressChange;

    event DWebBrowserEvents_DownloadCompleteEventHandler DownloadComplete;

    event DWebBrowserEvents_CommandStateChangeEventHandler CommandStateChange;

    event DWebBrowserEvents_DownloadBeginEventHandler DownloadBegin;

    event DWebBrowserEvents_NewWindowEventHandler NewWindow;

    event DWebBrowserEvents_TitleChangeEventHandler TitleChange;

    event DWebBrowserEvents_FrameBeforeNavigateEventHandler FrameBeforeNavigate;

    event DWebBrowserEvents_FrameNavigateCompleteEventHandler FrameNavigateComplete;

    event DWebBrowserEvents_FrameNewWindowEventHandler FrameNewWindow;

    event DWebBrowserEvents_QuitEventHandler Quit;

    event DWebBrowserEvents_WindowMoveEventHandler WindowMove;

    event DWebBrowserEvents_WindowResizeEventHandler WindowResize;

    event DWebBrowserEvents_WindowActivateEventHandler WindowActivate;

    event DWebBrowserEvents_PropertyChangeEventHandler PropertyChange;
  }

  [ClassInterface(ClassInterfaceType.None)]
  internal class DWebBrowserEvents_SinkHelper: DWebBrowserEvents
  {
    public int Cookie = 0;

    public event DWebBrowserEvents_BeforeNavigateEventHandler BeforeNavigateDelegate = null;
    public void Set_BeforeNavigateDelegate(DWebBrowserEvents_BeforeNavigateEventHandler deleg)
    {
      BeforeNavigateDelegate = deleg;
    }
    public bool Is_BeforeNavigateDelegate(DWebBrowserEvents_BeforeNavigateEventHandler deleg)
    {
      return (BeforeNavigateDelegate == deleg);
    }
    public void Clear_BeforeNavigateDelegate()
    {
      BeforeNavigateDelegate = null;
    }
    void DWebBrowserEvents.BeforeNavigate (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Cancel)
    {
      if (BeforeNavigateDelegate!=null)
        BeforeNavigateDelegate(URL, Flags, TargetFrameName, ref PostData, Headers, ref Cancel);
    }

    public event DWebBrowserEvents_NavigateCompleteEventHandler NavigateCompleteDelegate = null;
    public void Set_NavigateCompleteDelegate(DWebBrowserEvents_NavigateCompleteEventHandler deleg)
    {
      NavigateCompleteDelegate = deleg;
    }
    public bool Is_NavigateCompleteDelegate(DWebBrowserEvents_NavigateCompleteEventHandler deleg)
    {
      return (NavigateCompleteDelegate == deleg);
    }
    public void Clear_NavigateCompleteDelegate()
    {
      NavigateCompleteDelegate = null;
    }
    void DWebBrowserEvents.NavigateComplete (string URL)
    {
      if (NavigateCompleteDelegate!=null)
        NavigateCompleteDelegate(URL);
    }

    public event DWebBrowserEvents_StatusTextChangeEventHandler StatusTextChangeDelegate = null;
    public void Set_StatusTextChangeDelegate(DWebBrowserEvents_StatusTextChangeEventHandler deleg)
    {
      StatusTextChangeDelegate = deleg;
    }
    public bool Is_StatusTextChangeDelegate(DWebBrowserEvents_StatusTextChangeEventHandler deleg)
    {
      return (StatusTextChangeDelegate == deleg);
    }
    public void Clear_StatusTextChangeDelegate()
    {
      StatusTextChangeDelegate = null;
    }
    void DWebBrowserEvents.StatusTextChange (string Text)
    {
      if (StatusTextChangeDelegate!=null)
        StatusTextChangeDelegate(Text);
    }

    public event DWebBrowserEvents_ProgressChangeEventHandler ProgressChangeDelegate = null;
    public void Set_ProgressChangeDelegate(DWebBrowserEvents_ProgressChangeEventHandler deleg)
    {
      ProgressChangeDelegate = deleg;
    }
    public bool Is_ProgressChangeDelegate(DWebBrowserEvents_ProgressChangeEventHandler deleg)
    {
      return (ProgressChangeDelegate == deleg);
    }
    public void Clear_ProgressChangeDelegate()
    {
      ProgressChangeDelegate = null;
    }
    void DWebBrowserEvents.ProgressChange (int Progress, int ProgressMax)
    {
      if (ProgressChangeDelegate!=null)
        ProgressChangeDelegate(Progress, ProgressMax);
    }

    public event DWebBrowserEvents_DownloadCompleteEventHandler DownloadCompleteDelegate = null;
    public void Set_DownloadCompleteDelegate(DWebBrowserEvents_DownloadCompleteEventHandler deleg)
    {
      DownloadCompleteDelegate = deleg;
    }
    public bool Is_DownloadCompleteDelegate(DWebBrowserEvents_DownloadCompleteEventHandler deleg)
    {
      return (DownloadCompleteDelegate == deleg);
    }
    public void Clear_DownloadCompleteDelegate()
    {
      DownloadCompleteDelegate = null;
    }
    void DWebBrowserEvents.DownloadComplete ()
    {
      if (DownloadCompleteDelegate!=null)
        DownloadCompleteDelegate();
    }

    public event DWebBrowserEvents_CommandStateChangeEventHandler CommandStateChangeDelegate = null;
    public void Set_CommandStateChangeDelegate(DWebBrowserEvents_CommandStateChangeEventHandler deleg)
    {
      CommandStateChangeDelegate = deleg;
    }
    public bool Is_CommandStateChangeDelegate(DWebBrowserEvents_CommandStateChangeEventHandler deleg)
    {
      return (CommandStateChangeDelegate == deleg);
    }
    public void Clear_CommandStateChangeDelegate()
    {
      CommandStateChangeDelegate = null;
    }
    void DWebBrowserEvents.CommandStateChange (int Command, bool Enable)
    {
      if (CommandStateChangeDelegate!=null)
        CommandStateChangeDelegate(Command, Enable);
    }

    public event DWebBrowserEvents_DownloadBeginEventHandler DownloadBeginDelegate = null;
    public void Set_DownloadBeginDelegate(DWebBrowserEvents_DownloadBeginEventHandler deleg)
    {
      DownloadBeginDelegate = deleg;
    }
    public bool Is_DownloadBeginDelegate(DWebBrowserEvents_DownloadBeginEventHandler deleg)
    {
      return (DownloadBeginDelegate == deleg);
    }
    public void Clear_DownloadBeginDelegate()
    {
      DownloadBeginDelegate = null;
    }
    void DWebBrowserEvents.DownloadBegin ()
    {
      if (DownloadBeginDelegate!=null)
        DownloadBeginDelegate();
    }

    public event DWebBrowserEvents_NewWindowEventHandler NewWindowDelegate = null;
    public void Set_NewWindowDelegate(DWebBrowserEvents_NewWindowEventHandler deleg)
    {
      NewWindowDelegate = deleg;
    }
    public bool Is_NewWindowDelegate(DWebBrowserEvents_NewWindowEventHandler deleg)
    {
      return (NewWindowDelegate == deleg);
    }
    public void Clear_NewWindowDelegate()
    {
      NewWindowDelegate = null;
    }
    void DWebBrowserEvents.NewWindow (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
    {
      if (NewWindowDelegate!=null)
        NewWindowDelegate(URL, Flags, TargetFrameName, ref PostData, Headers, ref Processed);
    }

    public event DWebBrowserEvents_TitleChangeEventHandler TitleChangeDelegate = null;
    public void Set_TitleChangeDelegate(DWebBrowserEvents_TitleChangeEventHandler deleg)
    {
      TitleChangeDelegate = deleg;
    }
    public bool Is_TitleChangeDelegate(DWebBrowserEvents_TitleChangeEventHandler deleg)
    {
      return (TitleChangeDelegate == deleg);
    }
    public void Clear_TitleChangeDelegate()
    {
      TitleChangeDelegate = null;
    }
    void DWebBrowserEvents.TitleChange (string Text)
    {
      if (TitleChangeDelegate!=null)
        TitleChangeDelegate(Text);
    }

    public event DWebBrowserEvents_FrameBeforeNavigateEventHandler FrameBeforeNavigateDelegate = null;
    public void Set_FrameBeforeNavigateDelegate(DWebBrowserEvents_FrameBeforeNavigateEventHandler deleg)
    {
      FrameBeforeNavigateDelegate = deleg;
    }
    public bool Is_FrameBeforeNavigateDelegate(DWebBrowserEvents_FrameBeforeNavigateEventHandler deleg)
    {
      return (FrameBeforeNavigateDelegate == deleg);
    }
    public void Clear_FrameBeforeNavigateDelegate()
    {
      FrameBeforeNavigateDelegate = null;
    }
    void DWebBrowserEvents.FrameBeforeNavigate (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Cancel)
    {
      if (FrameBeforeNavigateDelegate!=null)
        FrameBeforeNavigateDelegate(URL, Flags, TargetFrameName, ref PostData, Headers, ref Cancel);
    }

    public event DWebBrowserEvents_FrameNavigateCompleteEventHandler FrameNavigateCompleteDelegate = null;
    public void Set_FrameNavigateCompleteDelegate(DWebBrowserEvents_FrameNavigateCompleteEventHandler deleg)
    {
      FrameNavigateCompleteDelegate = deleg;
    }
    public bool Is_FrameNavigateCompleteDelegate(DWebBrowserEvents_FrameNavigateCompleteEventHandler deleg)
    {
      return (FrameNavigateCompleteDelegate == deleg);
    }
    public void Clear_FrameNavigateCompleteDelegate()
    {
      FrameNavigateCompleteDelegate = null;
    }
    void DWebBrowserEvents.FrameNavigateComplete (string URL)
    {
      if (FrameNavigateCompleteDelegate!=null)
        FrameNavigateCompleteDelegate(URL);
    }

    public event DWebBrowserEvents_FrameNewWindowEventHandler FrameNewWindowDelegate = null;
    public void Set_FrameNewWindowDelegate(DWebBrowserEvents_FrameNewWindowEventHandler deleg)
    {
      FrameNewWindowDelegate = deleg;
    }
    public bool Is_FrameNewWindowDelegate(DWebBrowserEvents_FrameNewWindowEventHandler deleg)
    {
      return (FrameNewWindowDelegate == deleg);
    }
    public void Clear_FrameNewWindowDelegate()
    {
      FrameNewWindowDelegate = null;
    }
    void DWebBrowserEvents.FrameNewWindow (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
    {
      if (FrameNewWindowDelegate!=null)
        FrameNewWindowDelegate(URL, Flags, TargetFrameName, ref PostData, Headers, ref Processed);
    }

    public event DWebBrowserEvents_QuitEventHandler QuitDelegate = null;
    public void Set_QuitDelegate(DWebBrowserEvents_QuitEventHandler deleg)
    {
      QuitDelegate = deleg;
    }
    public bool Is_QuitDelegate(DWebBrowserEvents_QuitEventHandler deleg)
    {
      return (QuitDelegate == deleg);
    }
    public void Clear_QuitDelegate()
    {
      QuitDelegate = null;
    }
    void DWebBrowserEvents.Quit (ref bool Cancel)
    {
      if (QuitDelegate!=null)
        QuitDelegate(ref Cancel);
    }

    public event DWebBrowserEvents_WindowMoveEventHandler WindowMoveDelegate = null;
    public void Set_WindowMoveDelegate(DWebBrowserEvents_WindowMoveEventHandler deleg)
    {
      WindowMoveDelegate = deleg;
    }
    public bool Is_WindowMoveDelegate(DWebBrowserEvents_WindowMoveEventHandler deleg)
    {
      return (WindowMoveDelegate == deleg);
    }
    public void Clear_WindowMoveDelegate()
    {
      WindowMoveDelegate = null;
    }
    void DWebBrowserEvents.WindowMove ()
    {
      if (WindowMoveDelegate!=null)
        WindowMoveDelegate();
    }

    public event DWebBrowserEvents_WindowResizeEventHandler WindowResizeDelegate = null;
    public void Set_WindowResizeDelegate(DWebBrowserEvents_WindowResizeEventHandler deleg)
    {
      WindowResizeDelegate = deleg;
    }
    public bool Is_WindowResizeDelegate(DWebBrowserEvents_WindowResizeEventHandler deleg)
    {
      return (WindowResizeDelegate == deleg);
    }
    public void Clear_WindowResizeDelegate()
    {
      WindowResizeDelegate = null;
    }
    void DWebBrowserEvents.WindowResize ()
    {
      if (WindowResizeDelegate!=null)
        WindowResizeDelegate();
    }

    public event DWebBrowserEvents_WindowActivateEventHandler WindowActivateDelegate = null;
    public void Set_WindowActivateDelegate(DWebBrowserEvents_WindowActivateEventHandler deleg)
    {
      WindowActivateDelegate = deleg;
    }
    public bool Is_WindowActivateDelegate(DWebBrowserEvents_WindowActivateEventHandler deleg)
    {
      return (WindowActivateDelegate == deleg);
    }
    public void Clear_WindowActivateDelegate()
    {
      WindowActivateDelegate = null;
    }
    void DWebBrowserEvents.WindowActivate ()
    {
      if (WindowActivateDelegate!=null)
        WindowActivateDelegate();
    }

    public event DWebBrowserEvents_PropertyChangeEventHandler PropertyChangeDelegate = null;
    public void Set_PropertyChangeDelegate(DWebBrowserEvents_PropertyChangeEventHandler deleg)
    {
      PropertyChangeDelegate = deleg;
    }
    public bool Is_PropertyChangeDelegate(DWebBrowserEvents_PropertyChangeEventHandler deleg)
    {
      return (PropertyChangeDelegate == deleg);
    }
    public void Clear_PropertyChangeDelegate()
    {
      PropertyChangeDelegate = null;
    }
    void DWebBrowserEvents.PropertyChange (string Property)
    {
      if (PropertyChangeDelegate!=null)
        PropertyChangeDelegate(Property);
    }
  }

  internal class DWebBrowserEvents_EventProvider: IDisposable, DWebBrowserEvents_Event
  {
    UCOMIConnectionPointContainer ConnectionPointContainer;
    UCOMIConnectionPoint ConnectionPoint;
    DWebBrowserEvents_SinkHelper EventSinkHelper;
    int ConnectionCount;

    // Constructor: remember ConnectionPointContainer
    DWebBrowserEvents_EventProvider(object CPContainer) : base()
    {
      ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
    }

    // Force disconnection from ActiveX event source
    ~DWebBrowserEvents_EventProvider()
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
        Guid g = new Guid("EAB22AC2-30C1-11CF-A7EB-0000C05BAE0B");
        ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
        EventSinkHelper = new DWebBrowserEvents_SinkHelper();
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

    event DWebBrowserEvents_BeforeNavigateEventHandler DWebBrowserEvents_Event.BeforeNavigate
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.BeforeNavigateDelegate += value;
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
            EventSinkHelper.BeforeNavigateDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_NavigateCompleteEventHandler DWebBrowserEvents_Event.NavigateComplete
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.NavigateCompleteDelegate += value;
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
            EventSinkHelper.NavigateCompleteDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_StatusTextChangeEventHandler DWebBrowserEvents_Event.StatusTextChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.StatusTextChangeDelegate += value;
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
            EventSinkHelper.StatusTextChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_ProgressChangeEventHandler DWebBrowserEvents_Event.ProgressChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.ProgressChangeDelegate += value;
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
            EventSinkHelper.ProgressChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_DownloadCompleteEventHandler DWebBrowserEvents_Event.DownloadComplete
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.DownloadCompleteDelegate += value;
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
            EventSinkHelper.DownloadCompleteDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_CommandStateChangeEventHandler DWebBrowserEvents_Event.CommandStateChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.CommandStateChangeDelegate += value;
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
            EventSinkHelper.CommandStateChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_DownloadBeginEventHandler DWebBrowserEvents_Event.DownloadBegin
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.DownloadBeginDelegate += value;
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
            EventSinkHelper.DownloadBeginDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_NewWindowEventHandler DWebBrowserEvents_Event.NewWindow
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.NewWindowDelegate += value;
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
            EventSinkHelper.NewWindowDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_TitleChangeEventHandler DWebBrowserEvents_Event.TitleChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.TitleChangeDelegate += value;
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
            EventSinkHelper.TitleChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_FrameBeforeNavigateEventHandler DWebBrowserEvents_Event.FrameBeforeNavigate
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.FrameBeforeNavigateDelegate += value;
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
            EventSinkHelper.FrameBeforeNavigateDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_FrameNavigateCompleteEventHandler DWebBrowserEvents_Event.FrameNavigateComplete
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.FrameNavigateCompleteDelegate += value;
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
            EventSinkHelper.FrameNavigateCompleteDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_FrameNewWindowEventHandler DWebBrowserEvents_Event.FrameNewWindow
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.FrameNewWindowDelegate += value;
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
            EventSinkHelper.FrameNewWindowDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_QuitEventHandler DWebBrowserEvents_Event.Quit
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.QuitDelegate += value;
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
            EventSinkHelper.QuitDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_WindowMoveEventHandler DWebBrowserEvents_Event.WindowMove
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowMoveDelegate += value;
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
            EventSinkHelper.WindowMoveDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_WindowResizeEventHandler DWebBrowserEvents_Event.WindowResize
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowResizeDelegate += value;
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
            EventSinkHelper.WindowResizeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_WindowActivateEventHandler DWebBrowserEvents_Event.WindowActivate
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowActivateDelegate += value;
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
            EventSinkHelper.WindowActivateDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents_PropertyChangeEventHandler DWebBrowserEvents_Event.PropertyChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.PropertyChangeDelegate += value;
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
            EventSinkHelper.PropertyChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }
  }

  [Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
  [ComImport]
  [TypeLibType((short)4112)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface DWebBrowserEvents2
  {
    [DispId(102)]
    void StatusTextChange ([MarshalAs(UnmanagedType.BStr)] string Text);

    [DispId(108)]
    void ProgressChange (int Progress, int ProgressMax);

    [DispId(105)]
    void CommandStateChange (int Command, [MarshalAs(UnmanagedType.VariantBool)] bool Enable);

    [DispId(106)]
    void DownloadBegin ();

    [DispId(104)]
    void DownloadComplete ();

    [DispId(113)]
    void TitleChange ([MarshalAs(UnmanagedType.BStr)] string Text);

    [DispId(112)]
    void PropertyChange ([MarshalAs(UnmanagedType.BStr)] string szProperty);

    [DispId(250)]
    void BeforeNavigate2 ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(251)]
    void NewWindow2 ([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(252)]
    void NavigateComplete2 ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);

    [DispId(259)]
    void DocumentComplete ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);

    [DispId(253)]
    void OnQuit ();

    [DispId(254)]
    void OnVisible ([MarshalAs(UnmanagedType.VariantBool)] bool Visible);

    [DispId(255)]
    void OnToolBar ([MarshalAs(UnmanagedType.VariantBool)] bool ToolBar);

    [DispId(256)]
    void OnMenuBar ([MarshalAs(UnmanagedType.VariantBool)] bool MenuBar);

    [DispId(257)]
    void OnStatusBar ([MarshalAs(UnmanagedType.VariantBool)] bool StatusBar);

    [DispId(258)]
    void OnFullScreen ([MarshalAs(UnmanagedType.VariantBool)] bool FullScreen);

    [DispId(260)]
    void OnTheaterMode ([MarshalAs(UnmanagedType.VariantBool)] bool TheaterMode);

    [DispId(262)]
    void WindowSetResizable ([MarshalAs(UnmanagedType.VariantBool)] bool Resizable);

    [DispId(264)]
    void WindowSetLeft (int Left);

    [DispId(265)]
    void WindowSetTop (int Top);

    [DispId(266)]
    void WindowSetWidth (int Width);

    [DispId(267)]
    void WindowSetHeight (int Height);

    [DispId(263)]
    void WindowClosing ([MarshalAs(UnmanagedType.VariantBool)] bool IsChildWindow, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(268)]
    void ClientToHostWindow ([In, Out] ref int CX, [In, Out] ref int CY);

    [DispId(269)]
    void SetSecureLockIcon (int SecureLockIcon);

    [DispId(270)]
    void FileDownload ([MarshalAs(UnmanagedType.VariantBool)] bool ActiveDocument, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(271)]
    void NavigateError ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object Frame, [In] ref object StatusCode, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(225)]
    void PrintTemplateInstantiation ([MarshalAs(UnmanagedType.IDispatch)] object pDisp);

    [DispId(226)]
    void PrintTemplateTeardown ([MarshalAs(UnmanagedType.IDispatch)] object pDisp);

    [DispId(227)]
    void UpdatePageStatus ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object nPage, [In] ref object fDone);

    [DispId(272)]
    void PrivacyImpactedStateChange ([MarshalAs(UnmanagedType.VariantBool)] bool bImpacted);

    [DispId(273)]
    void NewWindow3 ([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel, uint dwFlags, [MarshalAs(UnmanagedType.BStr)] string bstrUrlContext, [MarshalAs(UnmanagedType.BStr)] string bstrUrl);

    [DispId(282)]
    void SetPhishingFilterStatus (int PhishingFilterStatus);

    [DispId(283)]
    void WindowStateChanged (uint dwWindowStateFlags, uint dwValidFlagsMask);

    [DispId(284)]
    void NewProcess (int lCauseFlag, [MarshalAs(UnmanagedType.IDispatch)] object pWB2, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

    [DispId(285)]
    void ThirdPartyUrlBlocked ([In] ref object URL, uint dwCount);

    [DispId(286)]
    void RedirectXDomainBlocked ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object StartURL, [In] ref object RedirectURL, [In] ref object Frame, [In] ref object StatusCode);
  }

  public delegate void DWebBrowserEvents2_StatusTextChangeEventHandler ([MarshalAs(UnmanagedType.BStr)] string Text);

  public delegate void DWebBrowserEvents2_ProgressChangeEventHandler (int Progress, int ProgressMax);

  public delegate void DWebBrowserEvents2_CommandStateChangeEventHandler (int Command, [MarshalAs(UnmanagedType.VariantBool)] bool Enable);

  public delegate void DWebBrowserEvents2_DownloadBeginEventHandler ();

  public delegate void DWebBrowserEvents2_DownloadCompleteEventHandler ();

  public delegate void DWebBrowserEvents2_TitleChangeEventHandler ([MarshalAs(UnmanagedType.BStr)] string Text);

  public delegate void DWebBrowserEvents2_PropertyChangeEventHandler ([MarshalAs(UnmanagedType.BStr)] string szProperty);

  public delegate void DWebBrowserEvents2_BeforeNavigate2EventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents2_NewWindow2EventHandler ([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents2_NavigateComplete2EventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);

  public delegate void DWebBrowserEvents2_DocumentCompleteEventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);

  public delegate void DWebBrowserEvents2_OnQuitEventHandler ();

  public delegate void DWebBrowserEvents2_OnVisibleEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool Visible);

  public delegate void DWebBrowserEvents2_OnToolBarEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool ToolBar);

  public delegate void DWebBrowserEvents2_OnMenuBarEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool MenuBar);

  public delegate void DWebBrowserEvents2_OnStatusBarEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool StatusBar);

  public delegate void DWebBrowserEvents2_OnFullScreenEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool FullScreen);

  public delegate void DWebBrowserEvents2_OnTheaterModeEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool TheaterMode);

  public delegate void DWebBrowserEvents2_WindowSetResizableEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool Resizable);

  public delegate void DWebBrowserEvents2_WindowSetLeftEventHandler (int Left);

  public delegate void DWebBrowserEvents2_WindowSetTopEventHandler (int Top);

  public delegate void DWebBrowserEvents2_WindowSetWidthEventHandler (int Width);

  public delegate void DWebBrowserEvents2_WindowSetHeightEventHandler (int Height);

  public delegate void DWebBrowserEvents2_WindowClosingEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool IsChildWindow, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents2_ClientToHostWindowEventHandler ([In, Out] ref int CX, [In, Out] ref int CY);

  public delegate void DWebBrowserEvents2_SetSecureLockIconEventHandler (int SecureLockIcon);

  public delegate void DWebBrowserEvents2_FileDownloadEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool ActiveDocument, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents2_NavigateErrorEventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object Frame, [In] ref object StatusCode, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents2_PrintTemplateInstantiationEventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp);

  public delegate void DWebBrowserEvents2_PrintTemplateTeardownEventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp);

  public delegate void DWebBrowserEvents2_UpdatePageStatusEventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object nPage, [In] ref object fDone);

  public delegate void DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler ([MarshalAs(UnmanagedType.VariantBool)] bool bImpacted);

  public delegate void DWebBrowserEvents2_NewWindow3EventHandler ([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel, uint dwFlags, [MarshalAs(UnmanagedType.BStr)] string bstrUrlContext, [MarshalAs(UnmanagedType.BStr)] string bstrUrl);

  public delegate void DWebBrowserEvents2_SetPhishingFilterStatusEventHandler (int PhishingFilterStatus);

  public delegate void DWebBrowserEvents2_WindowStateChangedEventHandler (uint dwWindowStateFlags, uint dwValidFlagsMask);

  public delegate void DWebBrowserEvents2_NewProcessEventHandler (int lCauseFlag, [MarshalAs(UnmanagedType.IDispatch)] object pWB2, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

  public delegate void DWebBrowserEvents2_ThirdPartyUrlBlockedEventHandler ([In] ref object URL, uint dwCount);

  public delegate void DWebBrowserEvents2_RedirectXDomainBlockedEventHandler ([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object StartURL, [In] ref object RedirectURL, [In] ref object Frame, [In] ref object StatusCode);

  [ComEventInterface(typeof(DWebBrowserEvents2),typeof(DWebBrowserEvents2_EventProvider))]
  [ComVisible(false)]
  public interface DWebBrowserEvents2_Event
  {
    event DWebBrowserEvents2_StatusTextChangeEventHandler StatusTextChange;

    event DWebBrowserEvents2_ProgressChangeEventHandler ProgressChange;

    event DWebBrowserEvents2_CommandStateChangeEventHandler CommandStateChange;

    event DWebBrowserEvents2_DownloadBeginEventHandler DownloadBegin;

    event DWebBrowserEvents2_DownloadCompleteEventHandler DownloadComplete;

    event DWebBrowserEvents2_TitleChangeEventHandler TitleChange;

    event DWebBrowserEvents2_PropertyChangeEventHandler PropertyChange;

    event DWebBrowserEvents2_BeforeNavigate2EventHandler BeforeNavigate2;

    event DWebBrowserEvents2_NewWindow2EventHandler NewWindow2;

    event DWebBrowserEvents2_NavigateComplete2EventHandler NavigateComplete2;

    event DWebBrowserEvents2_DocumentCompleteEventHandler DocumentComplete;

    event DWebBrowserEvents2_OnQuitEventHandler OnQuit;

    event DWebBrowserEvents2_OnVisibleEventHandler OnVisible;

    event DWebBrowserEvents2_OnToolBarEventHandler OnToolBar;

    event DWebBrowserEvents2_OnMenuBarEventHandler OnMenuBar;

    event DWebBrowserEvents2_OnStatusBarEventHandler OnStatusBar;

    event DWebBrowserEvents2_OnFullScreenEventHandler OnFullScreen;

    event DWebBrowserEvents2_OnTheaterModeEventHandler OnTheaterMode;

    event DWebBrowserEvents2_WindowSetResizableEventHandler WindowSetResizable;

    event DWebBrowserEvents2_WindowSetLeftEventHandler WindowSetLeft;

    event DWebBrowserEvents2_WindowSetTopEventHandler WindowSetTop;

    event DWebBrowserEvents2_WindowSetWidthEventHandler WindowSetWidth;

    event DWebBrowserEvents2_WindowSetHeightEventHandler WindowSetHeight;

    event DWebBrowserEvents2_WindowClosingEventHandler WindowClosing;

    event DWebBrowserEvents2_ClientToHostWindowEventHandler ClientToHostWindow;

    event DWebBrowserEvents2_SetSecureLockIconEventHandler SetSecureLockIcon;

    event DWebBrowserEvents2_FileDownloadEventHandler FileDownload;

    event DWebBrowserEvents2_NavigateErrorEventHandler NavigateError;

    event DWebBrowserEvents2_PrintTemplateInstantiationEventHandler PrintTemplateInstantiation;

    event DWebBrowserEvents2_PrintTemplateTeardownEventHandler PrintTemplateTeardown;

    event DWebBrowserEvents2_UpdatePageStatusEventHandler UpdatePageStatus;

    event DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChange;

    event DWebBrowserEvents2_NewWindow3EventHandler NewWindow3;

    event DWebBrowserEvents2_SetPhishingFilterStatusEventHandler SetPhishingFilterStatus;

    event DWebBrowserEvents2_WindowStateChangedEventHandler WindowStateChanged;

    event DWebBrowserEvents2_NewProcessEventHandler NewProcess;

    event DWebBrowserEvents2_ThirdPartyUrlBlockedEventHandler ThirdPartyUrlBlocked;

    event DWebBrowserEvents2_RedirectXDomainBlockedEventHandler RedirectXDomainBlocked;
  }

  [ClassInterface(ClassInterfaceType.None)]
  internal class DWebBrowserEvents2_SinkHelper: DWebBrowserEvents2
  {
    public int Cookie = 0;

    public event DWebBrowserEvents2_StatusTextChangeEventHandler StatusTextChangeDelegate = null;
    public void Set_StatusTextChangeDelegate(DWebBrowserEvents2_StatusTextChangeEventHandler deleg)
    {
      StatusTextChangeDelegate = deleg;
    }
    public bool Is_StatusTextChangeDelegate(DWebBrowserEvents2_StatusTextChangeEventHandler deleg)
    {
      return (StatusTextChangeDelegate == deleg);
    }
    public void Clear_StatusTextChangeDelegate()
    {
      StatusTextChangeDelegate = null;
    }
    void DWebBrowserEvents2.StatusTextChange (string Text)
    {
      if (StatusTextChangeDelegate!=null)
        StatusTextChangeDelegate(Text);
    }

    public event DWebBrowserEvents2_ProgressChangeEventHandler ProgressChangeDelegate = null;
    public void Set_ProgressChangeDelegate(DWebBrowserEvents2_ProgressChangeEventHandler deleg)
    {
      ProgressChangeDelegate = deleg;
    }
    public bool Is_ProgressChangeDelegate(DWebBrowserEvents2_ProgressChangeEventHandler deleg)
    {
      return (ProgressChangeDelegate == deleg);
    }
    public void Clear_ProgressChangeDelegate()
    {
      ProgressChangeDelegate = null;
    }
    void DWebBrowserEvents2.ProgressChange (int Progress, int ProgressMax)
    {
      if (ProgressChangeDelegate!=null)
        ProgressChangeDelegate(Progress, ProgressMax);
    }

    public event DWebBrowserEvents2_CommandStateChangeEventHandler CommandStateChangeDelegate = null;
    public void Set_CommandStateChangeDelegate(DWebBrowserEvents2_CommandStateChangeEventHandler deleg)
    {
      CommandStateChangeDelegate = deleg;
    }
    public bool Is_CommandStateChangeDelegate(DWebBrowserEvents2_CommandStateChangeEventHandler deleg)
    {
      return (CommandStateChangeDelegate == deleg);
    }
    public void Clear_CommandStateChangeDelegate()
    {
      CommandStateChangeDelegate = null;
    }
    void DWebBrowserEvents2.CommandStateChange (int Command, bool Enable)
    {
      if (CommandStateChangeDelegate!=null)
        CommandStateChangeDelegate(Command, Enable);
    }

    public event DWebBrowserEvents2_DownloadBeginEventHandler DownloadBeginDelegate = null;
    public void Set_DownloadBeginDelegate(DWebBrowserEvents2_DownloadBeginEventHandler deleg)
    {
      DownloadBeginDelegate = deleg;
    }
    public bool Is_DownloadBeginDelegate(DWebBrowserEvents2_DownloadBeginEventHandler deleg)
    {
      return (DownloadBeginDelegate == deleg);
    }
    public void Clear_DownloadBeginDelegate()
    {
      DownloadBeginDelegate = null;
    }
    void DWebBrowserEvents2.DownloadBegin ()
    {
      if (DownloadBeginDelegate!=null)
        DownloadBeginDelegate();
    }

    public event DWebBrowserEvents2_DownloadCompleteEventHandler DownloadCompleteDelegate = null;
    public void Set_DownloadCompleteDelegate(DWebBrowserEvents2_DownloadCompleteEventHandler deleg)
    {
      DownloadCompleteDelegate = deleg;
    }
    public bool Is_DownloadCompleteDelegate(DWebBrowserEvents2_DownloadCompleteEventHandler deleg)
    {
      return (DownloadCompleteDelegate == deleg);
    }
    public void Clear_DownloadCompleteDelegate()
    {
      DownloadCompleteDelegate = null;
    }
    void DWebBrowserEvents2.DownloadComplete ()
    {
      if (DownloadCompleteDelegate!=null)
        DownloadCompleteDelegate();
    }

    public event DWebBrowserEvents2_TitleChangeEventHandler TitleChangeDelegate = null;
    public void Set_TitleChangeDelegate(DWebBrowserEvents2_TitleChangeEventHandler deleg)
    {
      TitleChangeDelegate = deleg;
    }
    public bool Is_TitleChangeDelegate(DWebBrowserEvents2_TitleChangeEventHandler deleg)
    {
      return (TitleChangeDelegate == deleg);
    }
    public void Clear_TitleChangeDelegate()
    {
      TitleChangeDelegate = null;
    }
    void DWebBrowserEvents2.TitleChange (string Text)
    {
      if (TitleChangeDelegate!=null)
        TitleChangeDelegate(Text);
    }

    public event DWebBrowserEvents2_PropertyChangeEventHandler PropertyChangeDelegate = null;
    public void Set_PropertyChangeDelegate(DWebBrowserEvents2_PropertyChangeEventHandler deleg)
    {
      PropertyChangeDelegate = deleg;
    }
    public bool Is_PropertyChangeDelegate(DWebBrowserEvents2_PropertyChangeEventHandler deleg)
    {
      return (PropertyChangeDelegate == deleg);
    }
    public void Clear_PropertyChangeDelegate()
    {
      PropertyChangeDelegate = null;
    }
    void DWebBrowserEvents2.PropertyChange (string szProperty)
    {
      if (PropertyChangeDelegate!=null)
        PropertyChangeDelegate(szProperty);
    }

    public event DWebBrowserEvents2_BeforeNavigate2EventHandler BeforeNavigate2Delegate = null;
    public void Set_BeforeNavigate2Delegate(DWebBrowserEvents2_BeforeNavigate2EventHandler deleg)
    {
      BeforeNavigate2Delegate = deleg;
    }
    public bool Is_BeforeNavigate2Delegate(DWebBrowserEvents2_BeforeNavigate2EventHandler deleg)
    {
      return (BeforeNavigate2Delegate == deleg);
    }
    public void Clear_BeforeNavigate2Delegate()
    {
      BeforeNavigate2Delegate = null;
    }
    void DWebBrowserEvents2.BeforeNavigate2 (object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
    {
      if (BeforeNavigate2Delegate!=null)
        BeforeNavigate2Delegate(pDisp, ref URL, ref Flags, ref TargetFrameName, ref PostData, ref Headers, ref Cancel);
    }

    public event DWebBrowserEvents2_NewWindow2EventHandler NewWindow2Delegate = null;
    public void Set_NewWindow2Delegate(DWebBrowserEvents2_NewWindow2EventHandler deleg)
    {
      NewWindow2Delegate = deleg;
    }
    public bool Is_NewWindow2Delegate(DWebBrowserEvents2_NewWindow2EventHandler deleg)
    {
      return (NewWindow2Delegate == deleg);
    }
    public void Clear_NewWindow2Delegate()
    {
      NewWindow2Delegate = null;
    }
    void DWebBrowserEvents2.NewWindow2 (ref object ppDisp, ref bool Cancel)
    {
      if (NewWindow2Delegate!=null)
        NewWindow2Delegate(ref ppDisp, ref Cancel);
    }

    public event DWebBrowserEvents2_NavigateComplete2EventHandler NavigateComplete2Delegate = null;
    public void Set_NavigateComplete2Delegate(DWebBrowserEvents2_NavigateComplete2EventHandler deleg)
    {
      NavigateComplete2Delegate = deleg;
    }
    public bool Is_NavigateComplete2Delegate(DWebBrowserEvents2_NavigateComplete2EventHandler deleg)
    {
      return (NavigateComplete2Delegate == deleg);
    }
    public void Clear_NavigateComplete2Delegate()
    {
      NavigateComplete2Delegate = null;
    }
    void DWebBrowserEvents2.NavigateComplete2 (object pDisp, ref object URL)
    {
      if (NavigateComplete2Delegate!=null)
        NavigateComplete2Delegate(pDisp, ref URL);
    }

    public event DWebBrowserEvents2_DocumentCompleteEventHandler DocumentCompleteDelegate = null;
    public void Set_DocumentCompleteDelegate(DWebBrowserEvents2_DocumentCompleteEventHandler deleg)
    {
      DocumentCompleteDelegate = deleg;
    }
    public bool Is_DocumentCompleteDelegate(DWebBrowserEvents2_DocumentCompleteEventHandler deleg)
    {
      return (DocumentCompleteDelegate == deleg);
    }
    public void Clear_DocumentCompleteDelegate()
    {
      DocumentCompleteDelegate = null;
    }
    void DWebBrowserEvents2.DocumentComplete (object pDisp, ref object URL)
    {
      if (DocumentCompleteDelegate!=null)
        DocumentCompleteDelegate(pDisp, ref URL);
    }

    public event DWebBrowserEvents2_OnQuitEventHandler OnQuitDelegate = null;
    public void Set_OnQuitDelegate(DWebBrowserEvents2_OnQuitEventHandler deleg)
    {
      OnQuitDelegate = deleg;
    }
    public bool Is_OnQuitDelegate(DWebBrowserEvents2_OnQuitEventHandler deleg)
    {
      return (OnQuitDelegate == deleg);
    }
    public void Clear_OnQuitDelegate()
    {
      OnQuitDelegate = null;
    }
    void DWebBrowserEvents2.OnQuit ()
    {
      if (OnQuitDelegate!=null)
        OnQuitDelegate();
    }

    public event DWebBrowserEvents2_OnVisibleEventHandler OnVisibleDelegate = null;
    public void Set_OnVisibleDelegate(DWebBrowserEvents2_OnVisibleEventHandler deleg)
    {
      OnVisibleDelegate = deleg;
    }
    public bool Is_OnVisibleDelegate(DWebBrowserEvents2_OnVisibleEventHandler deleg)
    {
      return (OnVisibleDelegate == deleg);
    }
    public void Clear_OnVisibleDelegate()
    {
      OnVisibleDelegate = null;
    }
    void DWebBrowserEvents2.OnVisible (bool Visible)
    {
      if (OnVisibleDelegate!=null)
        OnVisibleDelegate(Visible);
    }

    public event DWebBrowserEvents2_OnToolBarEventHandler OnToolBarDelegate = null;
    public void Set_OnToolBarDelegate(DWebBrowserEvents2_OnToolBarEventHandler deleg)
    {
      OnToolBarDelegate = deleg;
    }
    public bool Is_OnToolBarDelegate(DWebBrowserEvents2_OnToolBarEventHandler deleg)
    {
      return (OnToolBarDelegate == deleg);
    }
    public void Clear_OnToolBarDelegate()
    {
      OnToolBarDelegate = null;
    }
    void DWebBrowserEvents2.OnToolBar (bool ToolBar)
    {
      if (OnToolBarDelegate!=null)
        OnToolBarDelegate(ToolBar);
    }

    public event DWebBrowserEvents2_OnMenuBarEventHandler OnMenuBarDelegate = null;
    public void Set_OnMenuBarDelegate(DWebBrowserEvents2_OnMenuBarEventHandler deleg)
    {
      OnMenuBarDelegate = deleg;
    }
    public bool Is_OnMenuBarDelegate(DWebBrowserEvents2_OnMenuBarEventHandler deleg)
    {
      return (OnMenuBarDelegate == deleg);
    }
    public void Clear_OnMenuBarDelegate()
    {
      OnMenuBarDelegate = null;
    }
    void DWebBrowserEvents2.OnMenuBar (bool MenuBar)
    {
      if (OnMenuBarDelegate!=null)
        OnMenuBarDelegate(MenuBar);
    }

    public event DWebBrowserEvents2_OnStatusBarEventHandler OnStatusBarDelegate = null;
    public void Set_OnStatusBarDelegate(DWebBrowserEvents2_OnStatusBarEventHandler deleg)
    {
      OnStatusBarDelegate = deleg;
    }
    public bool Is_OnStatusBarDelegate(DWebBrowserEvents2_OnStatusBarEventHandler deleg)
    {
      return (OnStatusBarDelegate == deleg);
    }
    public void Clear_OnStatusBarDelegate()
    {
      OnStatusBarDelegate = null;
    }
    void DWebBrowserEvents2.OnStatusBar (bool StatusBar)
    {
      if (OnStatusBarDelegate!=null)
        OnStatusBarDelegate(StatusBar);
    }

    public event DWebBrowserEvents2_OnFullScreenEventHandler OnFullScreenDelegate = null;
    public void Set_OnFullScreenDelegate(DWebBrowserEvents2_OnFullScreenEventHandler deleg)
    {
      OnFullScreenDelegate = deleg;
    }
    public bool Is_OnFullScreenDelegate(DWebBrowserEvents2_OnFullScreenEventHandler deleg)
    {
      return (OnFullScreenDelegate == deleg);
    }
    public void Clear_OnFullScreenDelegate()
    {
      OnFullScreenDelegate = null;
    }
    void DWebBrowserEvents2.OnFullScreen (bool FullScreen)
    {
      if (OnFullScreenDelegate!=null)
        OnFullScreenDelegate(FullScreen);
    }

    public event DWebBrowserEvents2_OnTheaterModeEventHandler OnTheaterModeDelegate = null;
    public void Set_OnTheaterModeDelegate(DWebBrowserEvents2_OnTheaterModeEventHandler deleg)
    {
      OnTheaterModeDelegate = deleg;
    }
    public bool Is_OnTheaterModeDelegate(DWebBrowserEvents2_OnTheaterModeEventHandler deleg)
    {
      return (OnTheaterModeDelegate == deleg);
    }
    public void Clear_OnTheaterModeDelegate()
    {
      OnTheaterModeDelegate = null;
    }
    void DWebBrowserEvents2.OnTheaterMode (bool TheaterMode)
    {
      if (OnTheaterModeDelegate!=null)
        OnTheaterModeDelegate(TheaterMode);
    }

    public event DWebBrowserEvents2_WindowSetResizableEventHandler WindowSetResizableDelegate = null;
    public void Set_WindowSetResizableDelegate(DWebBrowserEvents2_WindowSetResizableEventHandler deleg)
    {
      WindowSetResizableDelegate = deleg;
    }
    public bool Is_WindowSetResizableDelegate(DWebBrowserEvents2_WindowSetResizableEventHandler deleg)
    {
      return (WindowSetResizableDelegate == deleg);
    }
    public void Clear_WindowSetResizableDelegate()
    {
      WindowSetResizableDelegate = null;
    }
    void DWebBrowserEvents2.WindowSetResizable (bool Resizable)
    {
      if (WindowSetResizableDelegate!=null)
        WindowSetResizableDelegate(Resizable);
    }

    public event DWebBrowserEvents2_WindowSetLeftEventHandler WindowSetLeftDelegate = null;
    public void Set_WindowSetLeftDelegate(DWebBrowserEvents2_WindowSetLeftEventHandler deleg)
    {
      WindowSetLeftDelegate = deleg;
    }
    public bool Is_WindowSetLeftDelegate(DWebBrowserEvents2_WindowSetLeftEventHandler deleg)
    {
      return (WindowSetLeftDelegate == deleg);
    }
    public void Clear_WindowSetLeftDelegate()
    {
      WindowSetLeftDelegate = null;
    }
    void DWebBrowserEvents2.WindowSetLeft (int Left)
    {
      if (WindowSetLeftDelegate!=null)
        WindowSetLeftDelegate(Left);
    }

    public event DWebBrowserEvents2_WindowSetTopEventHandler WindowSetTopDelegate = null;
    public void Set_WindowSetTopDelegate(DWebBrowserEvents2_WindowSetTopEventHandler deleg)
    {
      WindowSetTopDelegate = deleg;
    }
    public bool Is_WindowSetTopDelegate(DWebBrowserEvents2_WindowSetTopEventHandler deleg)
    {
      return (WindowSetTopDelegate == deleg);
    }
    public void Clear_WindowSetTopDelegate()
    {
      WindowSetTopDelegate = null;
    }
    void DWebBrowserEvents2.WindowSetTop (int Top)
    {
      if (WindowSetTopDelegate!=null)
        WindowSetTopDelegate(Top);
    }

    public event DWebBrowserEvents2_WindowSetWidthEventHandler WindowSetWidthDelegate = null;
    public void Set_WindowSetWidthDelegate(DWebBrowserEvents2_WindowSetWidthEventHandler deleg)
    {
      WindowSetWidthDelegate = deleg;
    }
    public bool Is_WindowSetWidthDelegate(DWebBrowserEvents2_WindowSetWidthEventHandler deleg)
    {
      return (WindowSetWidthDelegate == deleg);
    }
    public void Clear_WindowSetWidthDelegate()
    {
      WindowSetWidthDelegate = null;
    }
    void DWebBrowserEvents2.WindowSetWidth (int Width)
    {
      if (WindowSetWidthDelegate!=null)
        WindowSetWidthDelegate(Width);
    }

    public event DWebBrowserEvents2_WindowSetHeightEventHandler WindowSetHeightDelegate = null;
    public void Set_WindowSetHeightDelegate(DWebBrowserEvents2_WindowSetHeightEventHandler deleg)
    {
      WindowSetHeightDelegate = deleg;
    }
    public bool Is_WindowSetHeightDelegate(DWebBrowserEvents2_WindowSetHeightEventHandler deleg)
    {
      return (WindowSetHeightDelegate == deleg);
    }
    public void Clear_WindowSetHeightDelegate()
    {
      WindowSetHeightDelegate = null;
    }
    void DWebBrowserEvents2.WindowSetHeight (int Height)
    {
      if (WindowSetHeightDelegate!=null)
        WindowSetHeightDelegate(Height);
    }

    public event DWebBrowserEvents2_WindowClosingEventHandler WindowClosingDelegate = null;
    public void Set_WindowClosingDelegate(DWebBrowserEvents2_WindowClosingEventHandler deleg)
    {
      WindowClosingDelegate = deleg;
    }
    public bool Is_WindowClosingDelegate(DWebBrowserEvents2_WindowClosingEventHandler deleg)
    {
      return (WindowClosingDelegate == deleg);
    }
    public void Clear_WindowClosingDelegate()
    {
      WindowClosingDelegate = null;
    }
    void DWebBrowserEvents2.WindowClosing (bool IsChildWindow, ref bool Cancel)
    {
      if (WindowClosingDelegate!=null)
        WindowClosingDelegate(IsChildWindow, ref Cancel);
    }

    public event DWebBrowserEvents2_ClientToHostWindowEventHandler ClientToHostWindowDelegate = null;
    public void Set_ClientToHostWindowDelegate(DWebBrowserEvents2_ClientToHostWindowEventHandler deleg)
    {
      ClientToHostWindowDelegate = deleg;
    }
    public bool Is_ClientToHostWindowDelegate(DWebBrowserEvents2_ClientToHostWindowEventHandler deleg)
    {
      return (ClientToHostWindowDelegate == deleg);
    }
    public void Clear_ClientToHostWindowDelegate()
    {
      ClientToHostWindowDelegate = null;
    }
    void DWebBrowserEvents2.ClientToHostWindow (ref int CX, ref int CY)
    {
      if (ClientToHostWindowDelegate!=null)
        ClientToHostWindowDelegate(ref CX, ref CY);
    }

    public event DWebBrowserEvents2_SetSecureLockIconEventHandler SetSecureLockIconDelegate = null;
    public void Set_SetSecureLockIconDelegate(DWebBrowserEvents2_SetSecureLockIconEventHandler deleg)
    {
      SetSecureLockIconDelegate = deleg;
    }
    public bool Is_SetSecureLockIconDelegate(DWebBrowserEvents2_SetSecureLockIconEventHandler deleg)
    {
      return (SetSecureLockIconDelegate == deleg);
    }
    public void Clear_SetSecureLockIconDelegate()
    {
      SetSecureLockIconDelegate = null;
    }
    void DWebBrowserEvents2.SetSecureLockIcon (int SecureLockIcon)
    {
      if (SetSecureLockIconDelegate!=null)
        SetSecureLockIconDelegate(SecureLockIcon);
    }

    public event DWebBrowserEvents2_FileDownloadEventHandler FileDownloadDelegate = null;
    public void Set_FileDownloadDelegate(DWebBrowserEvents2_FileDownloadEventHandler deleg)
    {
      FileDownloadDelegate = deleg;
    }
    public bool Is_FileDownloadDelegate(DWebBrowserEvents2_FileDownloadEventHandler deleg)
    {
      return (FileDownloadDelegate == deleg);
    }
    public void Clear_FileDownloadDelegate()
    {
      FileDownloadDelegate = null;
    }
    void DWebBrowserEvents2.FileDownload (bool ActiveDocument, ref bool Cancel)
    {
      if (FileDownloadDelegate!=null)
        FileDownloadDelegate(ActiveDocument, ref Cancel);
    }

    public event DWebBrowserEvents2_NavigateErrorEventHandler NavigateErrorDelegate = null;
    public void Set_NavigateErrorDelegate(DWebBrowserEvents2_NavigateErrorEventHandler deleg)
    {
      NavigateErrorDelegate = deleg;
    }
    public bool Is_NavigateErrorDelegate(DWebBrowserEvents2_NavigateErrorEventHandler deleg)
    {
      return (NavigateErrorDelegate == deleg);
    }
    public void Clear_NavigateErrorDelegate()
    {
      NavigateErrorDelegate = null;
    }
    void DWebBrowserEvents2.NavigateError (object pDisp, ref object URL, ref object Frame, ref object StatusCode, ref bool Cancel)
    {
      if (NavigateErrorDelegate!=null)
        NavigateErrorDelegate(pDisp, ref URL, ref Frame, ref StatusCode, ref Cancel);
    }

    public event DWebBrowserEvents2_PrintTemplateInstantiationEventHandler PrintTemplateInstantiationDelegate = null;
    public void Set_PrintTemplateInstantiationDelegate(DWebBrowserEvents2_PrintTemplateInstantiationEventHandler deleg)
    {
      PrintTemplateInstantiationDelegate = deleg;
    }
    public bool Is_PrintTemplateInstantiationDelegate(DWebBrowserEvents2_PrintTemplateInstantiationEventHandler deleg)
    {
      return (PrintTemplateInstantiationDelegate == deleg);
    }
    public void Clear_PrintTemplateInstantiationDelegate()
    {
      PrintTemplateInstantiationDelegate = null;
    }
    void DWebBrowserEvents2.PrintTemplateInstantiation (object pDisp)
    {
      if (PrintTemplateInstantiationDelegate!=null)
        PrintTemplateInstantiationDelegate(pDisp);
    }

    public event DWebBrowserEvents2_PrintTemplateTeardownEventHandler PrintTemplateTeardownDelegate = null;
    public void Set_PrintTemplateTeardownDelegate(DWebBrowserEvents2_PrintTemplateTeardownEventHandler deleg)
    {
      PrintTemplateTeardownDelegate = deleg;
    }
    public bool Is_PrintTemplateTeardownDelegate(DWebBrowserEvents2_PrintTemplateTeardownEventHandler deleg)
    {
      return (PrintTemplateTeardownDelegate == deleg);
    }
    public void Clear_PrintTemplateTeardownDelegate()
    {
      PrintTemplateTeardownDelegate = null;
    }
    void DWebBrowserEvents2.PrintTemplateTeardown (object pDisp)
    {
      if (PrintTemplateTeardownDelegate!=null)
        PrintTemplateTeardownDelegate(pDisp);
    }

    public event DWebBrowserEvents2_UpdatePageStatusEventHandler UpdatePageStatusDelegate = null;
    public void Set_UpdatePageStatusDelegate(DWebBrowserEvents2_UpdatePageStatusEventHandler deleg)
    {
      UpdatePageStatusDelegate = deleg;
    }
    public bool Is_UpdatePageStatusDelegate(DWebBrowserEvents2_UpdatePageStatusEventHandler deleg)
    {
      return (UpdatePageStatusDelegate == deleg);
    }
    public void Clear_UpdatePageStatusDelegate()
    {
      UpdatePageStatusDelegate = null;
    }
    void DWebBrowserEvents2.UpdatePageStatus (object pDisp, ref object nPage, ref object fDone)
    {
      if (UpdatePageStatusDelegate!=null)
        UpdatePageStatusDelegate(pDisp, ref nPage, ref fDone);
    }

    public event DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChangeDelegate = null;
    public void Set_PrivacyImpactedStateChangeDelegate(DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler deleg)
    {
      PrivacyImpactedStateChangeDelegate = deleg;
    }
    public bool Is_PrivacyImpactedStateChangeDelegate(DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler deleg)
    {
      return (PrivacyImpactedStateChangeDelegate == deleg);
    }
    public void Clear_PrivacyImpactedStateChangeDelegate()
    {
      PrivacyImpactedStateChangeDelegate = null;
    }
    void DWebBrowserEvents2.PrivacyImpactedStateChange (bool bImpacted)
    {
      if (PrivacyImpactedStateChangeDelegate!=null)
        PrivacyImpactedStateChangeDelegate(bImpacted);
    }

    public event DWebBrowserEvents2_NewWindow3EventHandler NewWindow3Delegate = null;
    public void Set_NewWindow3Delegate(DWebBrowserEvents2_NewWindow3EventHandler deleg)
    {
      NewWindow3Delegate = deleg;
    }
    public bool Is_NewWindow3Delegate(DWebBrowserEvents2_NewWindow3EventHandler deleg)
    {
      return (NewWindow3Delegate == deleg);
    }
    public void Clear_NewWindow3Delegate()
    {
      NewWindow3Delegate = null;
    }
    void DWebBrowserEvents2.NewWindow3 (ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
    {
      if (NewWindow3Delegate!=null)
        NewWindow3Delegate(ref ppDisp, ref Cancel, dwFlags, bstrUrlContext, bstrUrl);
    }

    public event DWebBrowserEvents2_SetPhishingFilterStatusEventHandler SetPhishingFilterStatusDelegate = null;
    public void Set_SetPhishingFilterStatusDelegate(DWebBrowserEvents2_SetPhishingFilterStatusEventHandler deleg)
    {
      SetPhishingFilterStatusDelegate = deleg;
    }
    public bool Is_SetPhishingFilterStatusDelegate(DWebBrowserEvents2_SetPhishingFilterStatusEventHandler deleg)
    {
      return (SetPhishingFilterStatusDelegate == deleg);
    }
    public void Clear_SetPhishingFilterStatusDelegate()
    {
      SetPhishingFilterStatusDelegate = null;
    }
    void DWebBrowserEvents2.SetPhishingFilterStatus (int PhishingFilterStatus)
    {
      if (SetPhishingFilterStatusDelegate!=null)
        SetPhishingFilterStatusDelegate(PhishingFilterStatus);
    }

    public event DWebBrowserEvents2_WindowStateChangedEventHandler WindowStateChangedDelegate = null;
    public void Set_WindowStateChangedDelegate(DWebBrowserEvents2_WindowStateChangedEventHandler deleg)
    {
      WindowStateChangedDelegate = deleg;
    }
    public bool Is_WindowStateChangedDelegate(DWebBrowserEvents2_WindowStateChangedEventHandler deleg)
    {
      return (WindowStateChangedDelegate == deleg);
    }
    public void Clear_WindowStateChangedDelegate()
    {
      WindowStateChangedDelegate = null;
    }
    void DWebBrowserEvents2.WindowStateChanged (uint dwWindowStateFlags, uint dwValidFlagsMask)
    {
      if (WindowStateChangedDelegate!=null)
        WindowStateChangedDelegate(dwWindowStateFlags, dwValidFlagsMask);
    }

    public event DWebBrowserEvents2_NewProcessEventHandler NewProcessDelegate = null;
    public void Set_NewProcessDelegate(DWebBrowserEvents2_NewProcessEventHandler deleg)
    {
      NewProcessDelegate = deleg;
    }
    public bool Is_NewProcessDelegate(DWebBrowserEvents2_NewProcessEventHandler deleg)
    {
      return (NewProcessDelegate == deleg);
    }
    public void Clear_NewProcessDelegate()
    {
      NewProcessDelegate = null;
    }
    void DWebBrowserEvents2.NewProcess (int lCauseFlag, object pWB2, ref bool Cancel)
    {
      if (NewProcessDelegate!=null)
        NewProcessDelegate(lCauseFlag, pWB2, ref Cancel);
    }

    public event DWebBrowserEvents2_ThirdPartyUrlBlockedEventHandler ThirdPartyUrlBlockedDelegate = null;
    public void Set_ThirdPartyUrlBlockedDelegate(DWebBrowserEvents2_ThirdPartyUrlBlockedEventHandler deleg)
    {
      ThirdPartyUrlBlockedDelegate = deleg;
    }
    public bool Is_ThirdPartyUrlBlockedDelegate(DWebBrowserEvents2_ThirdPartyUrlBlockedEventHandler deleg)
    {
      return (ThirdPartyUrlBlockedDelegate == deleg);
    }
    public void Clear_ThirdPartyUrlBlockedDelegate()
    {
      ThirdPartyUrlBlockedDelegate = null;
    }
    void DWebBrowserEvents2.ThirdPartyUrlBlocked (ref object URL, uint dwCount)
    {
      if (ThirdPartyUrlBlockedDelegate!=null)
        ThirdPartyUrlBlockedDelegate(ref URL, dwCount);
    }

    public event DWebBrowserEvents2_RedirectXDomainBlockedEventHandler RedirectXDomainBlockedDelegate = null;
    public void Set_RedirectXDomainBlockedDelegate(DWebBrowserEvents2_RedirectXDomainBlockedEventHandler deleg)
    {
      RedirectXDomainBlockedDelegate = deleg;
    }
    public bool Is_RedirectXDomainBlockedDelegate(DWebBrowserEvents2_RedirectXDomainBlockedEventHandler deleg)
    {
      return (RedirectXDomainBlockedDelegate == deleg);
    }
    public void Clear_RedirectXDomainBlockedDelegate()
    {
      RedirectXDomainBlockedDelegate = null;
    }
    void DWebBrowserEvents2.RedirectXDomainBlocked (object pDisp, ref object StartURL, ref object RedirectURL, ref object Frame, ref object StatusCode)
    {
      if (RedirectXDomainBlockedDelegate!=null)
        RedirectXDomainBlockedDelegate(pDisp, ref StartURL, ref RedirectURL, ref Frame, ref StatusCode);
    }
  }

  internal class DWebBrowserEvents2_EventProvider: IDisposable, DWebBrowserEvents2_Event
  {
    UCOMIConnectionPointContainer ConnectionPointContainer;
    UCOMIConnectionPoint ConnectionPoint;
    DWebBrowserEvents2_SinkHelper EventSinkHelper;
    int ConnectionCount;

    // Constructor: remember ConnectionPointContainer
    DWebBrowserEvents2_EventProvider(object CPContainer) : base()
    {
      ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
    }

    // Force disconnection from ActiveX event source
    ~DWebBrowserEvents2_EventProvider()
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
        Guid g = new Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D");
        ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
        EventSinkHelper = new DWebBrowserEvents2_SinkHelper();
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

    event DWebBrowserEvents2_StatusTextChangeEventHandler DWebBrowserEvents2_Event.StatusTextChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.StatusTextChangeDelegate += value;
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
            EventSinkHelper.StatusTextChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_ProgressChangeEventHandler DWebBrowserEvents2_Event.ProgressChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.ProgressChangeDelegate += value;
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
            EventSinkHelper.ProgressChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_CommandStateChangeEventHandler DWebBrowserEvents2_Event.CommandStateChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.CommandStateChangeDelegate += value;
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
            EventSinkHelper.CommandStateChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_DownloadBeginEventHandler DWebBrowserEvents2_Event.DownloadBegin
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.DownloadBeginDelegate += value;
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
            EventSinkHelper.DownloadBeginDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_DownloadCompleteEventHandler DWebBrowserEvents2_Event.DownloadComplete
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.DownloadCompleteDelegate += value;
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
            EventSinkHelper.DownloadCompleteDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_TitleChangeEventHandler DWebBrowserEvents2_Event.TitleChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.TitleChangeDelegate += value;
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
            EventSinkHelper.TitleChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_PropertyChangeEventHandler DWebBrowserEvents2_Event.PropertyChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.PropertyChangeDelegate += value;
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
            EventSinkHelper.PropertyChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_BeforeNavigate2EventHandler DWebBrowserEvents2_Event.BeforeNavigate2
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.BeforeNavigate2Delegate += value;
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
            EventSinkHelper.BeforeNavigate2Delegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_NewWindow2EventHandler DWebBrowserEvents2_Event.NewWindow2
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.NewWindow2Delegate += value;
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
            EventSinkHelper.NewWindow2Delegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_NavigateComplete2EventHandler DWebBrowserEvents2_Event.NavigateComplete2
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.NavigateComplete2Delegate += value;
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
            EventSinkHelper.NavigateComplete2Delegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_DocumentCompleteEventHandler DWebBrowserEvents2_Event.DocumentComplete
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.DocumentCompleteDelegate += value;
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
            EventSinkHelper.DocumentCompleteDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_OnQuitEventHandler DWebBrowserEvents2_Event.OnQuit
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.OnQuitDelegate += value;
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
            EventSinkHelper.OnQuitDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_OnVisibleEventHandler DWebBrowserEvents2_Event.OnVisible
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.OnVisibleDelegate += value;
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
            EventSinkHelper.OnVisibleDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_OnToolBarEventHandler DWebBrowserEvents2_Event.OnToolBar
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.OnToolBarDelegate += value;
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
            EventSinkHelper.OnToolBarDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_OnMenuBarEventHandler DWebBrowserEvents2_Event.OnMenuBar
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.OnMenuBarDelegate += value;
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
            EventSinkHelper.OnMenuBarDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_OnStatusBarEventHandler DWebBrowserEvents2_Event.OnStatusBar
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.OnStatusBarDelegate += value;
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
            EventSinkHelper.OnStatusBarDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_OnFullScreenEventHandler DWebBrowserEvents2_Event.OnFullScreen
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.OnFullScreenDelegate += value;
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
            EventSinkHelper.OnFullScreenDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_OnTheaterModeEventHandler DWebBrowserEvents2_Event.OnTheaterMode
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.OnTheaterModeDelegate += value;
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
            EventSinkHelper.OnTheaterModeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_WindowSetResizableEventHandler DWebBrowserEvents2_Event.WindowSetResizable
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowSetResizableDelegate += value;
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
            EventSinkHelper.WindowSetResizableDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_WindowSetLeftEventHandler DWebBrowserEvents2_Event.WindowSetLeft
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowSetLeftDelegate += value;
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
            EventSinkHelper.WindowSetLeftDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_WindowSetTopEventHandler DWebBrowserEvents2_Event.WindowSetTop
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowSetTopDelegate += value;
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
            EventSinkHelper.WindowSetTopDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_WindowSetWidthEventHandler DWebBrowserEvents2_Event.WindowSetWidth
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowSetWidthDelegate += value;
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
            EventSinkHelper.WindowSetWidthDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_WindowSetHeightEventHandler DWebBrowserEvents2_Event.WindowSetHeight
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowSetHeightDelegate += value;
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
            EventSinkHelper.WindowSetHeightDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_WindowClosingEventHandler DWebBrowserEvents2_Event.WindowClosing
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowClosingDelegate += value;
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
            EventSinkHelper.WindowClosingDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_ClientToHostWindowEventHandler DWebBrowserEvents2_Event.ClientToHostWindow
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.ClientToHostWindowDelegate += value;
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
            EventSinkHelper.ClientToHostWindowDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_SetSecureLockIconEventHandler DWebBrowserEvents2_Event.SetSecureLockIcon
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.SetSecureLockIconDelegate += value;
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
            EventSinkHelper.SetSecureLockIconDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_FileDownloadEventHandler DWebBrowserEvents2_Event.FileDownload
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.FileDownloadDelegate += value;
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
            EventSinkHelper.FileDownloadDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_NavigateErrorEventHandler DWebBrowserEvents2_Event.NavigateError
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.NavigateErrorDelegate += value;
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
            EventSinkHelper.NavigateErrorDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_PrintTemplateInstantiationEventHandler DWebBrowserEvents2_Event.PrintTemplateInstantiation
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.PrintTemplateInstantiationDelegate += value;
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
            EventSinkHelper.PrintTemplateInstantiationDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_PrintTemplateTeardownEventHandler DWebBrowserEvents2_Event.PrintTemplateTeardown
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.PrintTemplateTeardownDelegate += value;
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
            EventSinkHelper.PrintTemplateTeardownDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_UpdatePageStatusEventHandler DWebBrowserEvents2_Event.UpdatePageStatus
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.UpdatePageStatusDelegate += value;
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
            EventSinkHelper.UpdatePageStatusDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler DWebBrowserEvents2_Event.PrivacyImpactedStateChange
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.PrivacyImpactedStateChangeDelegate += value;
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
            EventSinkHelper.PrivacyImpactedStateChangeDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_NewWindow3EventHandler DWebBrowserEvents2_Event.NewWindow3
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.NewWindow3Delegate += value;
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
            EventSinkHelper.NewWindow3Delegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_SetPhishingFilterStatusEventHandler DWebBrowserEvents2_Event.SetPhishingFilterStatus
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.SetPhishingFilterStatusDelegate += value;
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
            EventSinkHelper.SetPhishingFilterStatusDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_WindowStateChangedEventHandler DWebBrowserEvents2_Event.WindowStateChanged
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.WindowStateChangedDelegate += value;
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
            EventSinkHelper.WindowStateChangedDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_NewProcessEventHandler DWebBrowserEvents2_Event.NewProcess
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.NewProcessDelegate += value;
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
            EventSinkHelper.NewProcessDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_ThirdPartyUrlBlockedEventHandler DWebBrowserEvents2_Event.ThirdPartyUrlBlocked
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.ThirdPartyUrlBlockedDelegate += value;
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
            EventSinkHelper.ThirdPartyUrlBlockedDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }

    event DWebBrowserEvents2_RedirectXDomainBlockedEventHandler DWebBrowserEvents2_Event.RedirectXDomainBlocked
    {
      add
      {
        System.Threading.Monitor.Enter(this);
        try {
          Connect();
          EventSinkHelper.RedirectXDomainBlockedDelegate += value;
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
            EventSinkHelper.RedirectXDomainBlockedDelegate -= value;
            CheckDisconnect();
          } catch { }
          System.Threading.Monitor.Exit(this);
        }
      }
    }
  }

  [Guid("F3470F24-15FD-11D2-BB2E-00805FF7EFCA")]
  [ComImport]
  [TypeLibType((short)4176)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IScriptErrorList
  {
    [DispId(10)]
    void advanceError ();

    [DispId(11)]
    void retreatError ();

    [DispId(12)]
    int canAdvanceError ();

    [DispId(13)]
    int canRetreatError ();

    [DispId(14)]
    int getErrorLine ();

    [DispId(15)]
    int getErrorChar ();

    [DispId(16)]
    int getErrorCode ();

    [DispId(17)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string getErrorMsg ();

    [DispId(18)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string getErrorUrl ();

    [DispId(23)]
    int getAlwaysShowLockState ();

    [DispId(19)]
    int getDetailsPaneOpen ();

    [DispId(20)]
    void setDetailsPaneOpen (int fDetailsPaneOpen);

    [DispId(21)]
    int getPerErrorDisplay ();

    [DispId(22)]
    void setPerErrorDisplay (int fPerErrorDisplay);
  }

  [Guid("55136804-B2DE-11D1-B9F2-00A0C98BC547")]
  [ComImport]
  [TypeLibType((short)4176)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IShellFavoritesNameSpace
  {
    [DispId(1)]
    void MoveSelectionUp ();

    [DispId(2)]
    void MoveSelectionDown ();

    [DispId(3)]
    void ResetSort ();

    [DispId(4)]
    void NewFolder ();

    [DispId(5)]
    void Synchronize ();

    [DispId(6)]
    void Import ();

    [DispId(7)]
    void Export ();

    [DispId(8)]
    void InvokeContextMenuCommand ([MarshalAs(UnmanagedType.BStr)] string strCommand);

    [DispId(9)]
    void MoveSelectionTo ();

    [DispId(11)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool CreateSubscriptionForSelection ();

    [DispId(12)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool DeleteSubscriptionForSelection ();

    [DispId(13)]
    void SetRoot ([MarshalAs(UnmanagedType.BStr)] string bstrFullPath);

    bool SubscriptionsEnabled
    {
      [DispId(10)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }
  }

  [Guid("E572D3C9-37BE-4AE2-825D-D521763E3108")]
  [ComImport]
  [TypeLibType((short)4176)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IShellNameSpace
  {
    [DispId(1)]
    void MoveSelectionUp ();

    [DispId(2)]
    void MoveSelectionDown ();

    [DispId(3)]
    void ResetSort ();

    [DispId(4)]
    void NewFolder ();

    [DispId(5)]
    void Synchronize ();

    [DispId(6)]
    void Import ();

    [DispId(7)]
    void Export ();

    [DispId(8)]
    void InvokeContextMenuCommand ([MarshalAs(UnmanagedType.BStr)] string strCommand);

    [DispId(9)]
    void MoveSelectionTo ();

    [DispId(11)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool CreateSubscriptionForSelection ();

    [DispId(12)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool DeleteSubscriptionForSelection ();

    [DispId(13)]
    void SetRoot ([MarshalAs(UnmanagedType.BStr)] string bstrFullPath);

    [DispId(23)]
    void SetViewType (int iType);

    [DispId(24)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object SelectedItems ();

    [DispId(25)]
    void Expand (object var, int iDepth);

    [DispId(26)]
    void UnselectAll ();

    string Columns
    {
      [DispId(21)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [DispId(21)]
      set;
    }

    int CountViewTypes
    {
      [DispId(22)]
      get;
    }

    int Depth
    {
      [DispId(17)]
      get;
      [DispId(17)]
      set;
    }

    int EnumOptions
    {
      [DispId(14)]
      get;
      [DispId(14)]
      set;
    }

    uint Flags
    {
      [DispId(19)]
      get;
      [DispId(19)]
      set;
    }

    uint Mode
    {
      [DispId(18)]
      get;
      [DispId(18)]
      set;
    }

    object Root
    {
      [DispId(16)]
      get;
      [DispId(16)]
      set;
    }

    object SelectedItem
    {
      [DispId(15)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
      [DispId(15)]
      set;
    }

    bool SubscriptionsEnabled
    {
      [DispId(10)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }

    uint TVFlags
    {
      [DispId(20)]
      get;
      [DispId(20)]
      set;
    }
  }

  [Guid("729FE2F8-1EA8-11D1-8F85-00C04FC2FBE1")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IShellUIHelper
  {
    [DispId(1)]
    void ResetFirstBootMode ();

    [DispId(2)]
    void ResetSafeMode ();

    [DispId(3)]
    void RefreshOfflineDesktop ();

    [DispId(4)]
    void AddFavorite ([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Title);

    [DispId(5)]
    void AddChannel ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(6)]
    void AddDesktopComponent ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string Type, [In] ref object Left, [In] ref object Top, [In] ref object Width, [In] ref object Height);

    [DispId(7)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool IsSubscribed ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(8)]
    void NavigateAndFind ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string strQuery, [In] ref object varTargetFrame);

    [DispId(9)]
    void ImportExportFavorites ([MarshalAs(UnmanagedType.VariantBool)] bool fImport, [MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

    [DispId(10)]
    void AutoCompleteSaveForm ([In] ref object Form);

    [DispId(11)]
    void AutoScan ([MarshalAs(UnmanagedType.BStr)] string strSearch, [MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In] ref object pvarTargetFrame);

    [DispId(12)]
    void AutoCompleteAttach ([In] ref object Reserved);

    [DispId(13)]
    object ShowBrowserUI ([MarshalAs(UnmanagedType.BStr)] string bstrName, [In] ref object pvarIn);
  }

  [Guid("A7FE6EDA-1932-4281-B881-87B31B8BC52C")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IShellUIHelper2
  {
    [DispId(1)]
    void ResetFirstBootMode ();

    [DispId(2)]
    void ResetSafeMode ();

    [DispId(3)]
    void RefreshOfflineDesktop ();

    [DispId(4)]
    void AddFavorite ([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Title);

    [DispId(5)]
    void AddChannel ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(6)]
    void AddDesktopComponent ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string Type, [In] ref object Left, [In] ref object Top, [In] ref object Width, [In] ref object Height);

    [DispId(7)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool IsSubscribed ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(8)]
    void NavigateAndFind ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string strQuery, [In] ref object varTargetFrame);

    [DispId(9)]
    void ImportExportFavorites ([MarshalAs(UnmanagedType.VariantBool)] bool fImport, [MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

    [DispId(10)]
    void AutoCompleteSaveForm ([In] ref object Form);

    [DispId(11)]
    void AutoScan ([MarshalAs(UnmanagedType.BStr)] string strSearch, [MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In] ref object pvarTargetFrame);

    [DispId(12)]
    void AutoCompleteAttach ([In] ref object Reserved);

    [DispId(13)]
    object ShowBrowserUI ([MarshalAs(UnmanagedType.BStr)] string bstrName, [In] ref object pvarIn);

    [DispId(14)]
    void AddSearchProvider ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(15)]
    void RunOnceShown ();

    [DispId(16)]
    void SkipRunOnce ();

    [DispId(17)]
    void CustomizeSettings ([MarshalAs(UnmanagedType.VariantBool)] bool fSQM, [MarshalAs(UnmanagedType.VariantBool)] bool fPhishing, [MarshalAs(UnmanagedType.BStr)] string bstrLocale);

    [DispId(18)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool SqmEnabled ();

    [DispId(19)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool PhishingEnabled ();

    [DispId(20)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string BrandImageUri ();

    [DispId(21)]
    void SkipTabsWelcome ();

    [DispId(22)]
    void DiagnoseConnection ();

    [DispId(23)]
    void CustomizeClearType ([MarshalAs(UnmanagedType.VariantBool)] bool fSet);

    [DispId(24)]
    uint IsSearchProviderInstalled ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(25)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool IsSearchMigrated ();

    [DispId(26)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string DefaultSearchProvider ();

    [DispId(27)]
    void RunOnceRequiredSettingsComplete ([MarshalAs(UnmanagedType.VariantBool)] bool fComplete);

    [DispId(28)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool RunOnceHasShown ();

    [DispId(29)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string SearchGuideUrl ();
  }

  [Guid("528DF2EC-D419-40BC-9B6D-DCDBF9C1B25D")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IShellUIHelper3
  {
    [DispId(1)]
    void ResetFirstBootMode ();

    [DispId(2)]
    void ResetSafeMode ();

    [DispId(3)]
    void RefreshOfflineDesktop ();

    [DispId(4)]
    void AddFavorite ([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Title);

    [DispId(5)]
    void AddChannel ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(6)]
    void AddDesktopComponent ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string Type, [In] ref object Left, [In] ref object Top, [In] ref object Width, [In] ref object Height);

    [DispId(7)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool IsSubscribed ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(8)]
    void NavigateAndFind ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string strQuery, [In] ref object varTargetFrame);

    [DispId(9)]
    void ImportExportFavorites ([MarshalAs(UnmanagedType.VariantBool)] bool fImport, [MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

    [DispId(10)]
    void AutoCompleteSaveForm ([In] ref object Form);

    [DispId(11)]
    void AutoScan ([MarshalAs(UnmanagedType.BStr)] string strSearch, [MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In] ref object pvarTargetFrame);

    [DispId(12)]
    void AutoCompleteAttach ([In] ref object Reserved);

    [DispId(13)]
    object ShowBrowserUI ([MarshalAs(UnmanagedType.BStr)] string bstrName, [In] ref object pvarIn);

    [DispId(14)]
    void AddSearchProvider ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(15)]
    void RunOnceShown ();

    [DispId(16)]
    void SkipRunOnce ();

    [DispId(17)]
    void CustomizeSettings ([MarshalAs(UnmanagedType.VariantBool)] bool fSQM, [MarshalAs(UnmanagedType.VariantBool)] bool fPhishing, [MarshalAs(UnmanagedType.BStr)] string bstrLocale);

    [DispId(18)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool SqmEnabled ();

    [DispId(19)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool PhishingEnabled ();

    [DispId(20)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string BrandImageUri ();

    [DispId(21)]
    void SkipTabsWelcome ();

    [DispId(22)]
    void DiagnoseConnection ();

    [DispId(23)]
    void CustomizeClearType ([MarshalAs(UnmanagedType.VariantBool)] bool fSet);

    [DispId(24)]
    uint IsSearchProviderInstalled ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(25)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool IsSearchMigrated ();

    [DispId(26)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string DefaultSearchProvider ();

    [DispId(27)]
    void RunOnceRequiredSettingsComplete ([MarshalAs(UnmanagedType.VariantBool)] bool fComplete);

    [DispId(28)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool RunOnceHasShown ();

    [DispId(29)]
    [return: MarshalAs(UnmanagedType.BStr)]
    string SearchGuideUrl ();

    [DispId(30)]
    void AddService ([MarshalAs(UnmanagedType.BStr)] string URL);

    [DispId(31)]
    uint IsServiceInstalled ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string Verb);

    [DispId(37)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool InPrivateFilteringEnabled ();

    [DispId(32)]
    void AddToFavoritesBar ([MarshalAs(UnmanagedType.BStr)] string URL, [MarshalAs(UnmanagedType.BStr)] string Title, [In] ref object Type);

    [DispId(33)]
    void BuildNewTabPage ();

    [DispId(34)]
    void SetRecentlyClosedVisible ([MarshalAs(UnmanagedType.VariantBool)] bool fVisible);

    [DispId(35)]
    void SetActivitiesVisible ([MarshalAs(UnmanagedType.VariantBool)] bool fVisible);

    [DispId(36)]
    void ContentDiscoveryReset ();

    [DispId(38)]
    [return: MarshalAs(UnmanagedType.VariantBool)]
    bool IsSuggestedSitesEnabled ();

    [DispId(39)]
    void EnableSuggestedSites ([MarshalAs(UnmanagedType.VariantBool)] bool fEnable);

    [DispId(40)]
    void NavigateToSuggestedSites ([MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

    [DispId(41)]
    void ShowTabsHelp ();

    [DispId(42)]
    void ShowInPrivateHelp ();
  }

  [Guid("85CB6900-4D95-11CF-960C-0080C7F4EE85")]
  [ComImport]
  [TypeLibType((short)4160)]
  [DefaultMember("Item")]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IShellWindows: System.Collections.IEnumerable
  {
    [DispId(0)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object Item (object index);

    [DispId(-4)]
    [return: MarshalAs(UnmanagedType.IUnknown)]
    object _NewEnum ();

    [DispId(1610743811)]
    void Register ([MarshalAs(UnmanagedType.IDispatch)] object pid, int HWND, int swClass, [Out] out int plCookie);

    [DispId(1610743812)]
    void RegisterPending (int lThreadId, [In] ref object pvarloc, [In] ref object pvarlocRoot, int swClass, [Out] out int plCookie);

    [DispId(1610743813)]
    void Revoke (int lCookie);

    [DispId(1610743814)]
    void OnNavigate (int lCookie, [In] ref object pvarloc);

    [DispId(1610743815)]
    void OnActivated (int lCookie, [MarshalAs(UnmanagedType.VariantBool)] bool fActive);

    [DispId(1610743816)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object FindWindowSW ([In] ref object pvarloc, [In] ref object pvarlocRoot, int swClass, [Out] out int pHWND, int swfwOptions);

    [DispId(1610743817)]
    void OnCreated (int lCookie, [MarshalAs(UnmanagedType.IUnknown)] object punk);

    [DispId(1610743818)]
    void ProcessAttachDetach ([MarshalAs(UnmanagedType.VariantBool)] bool fAttach);

    int Count
    {
      [DispId(1610743808)]
      get;
    }
  }

  [Guid("EAB22AC1-30C1-11CF-A7EB-0000C05BAE0B")]
  [ComImport]
  [TypeLibType((short)4176)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IWebBrowser
  {
    [DispId(100)]
    void GoBack ();

    [DispId(101)]
    void GoForward ();

    [DispId(102)]
    void GoHome ();

    [DispId(103)]
    void GoSearch ();

    [DispId(104)]
    void Navigate ([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);

    [DispId(-550)]
    void Refresh ();

    [DispId(105)]
    void Refresh2 ([In] ref object Level);

    [DispId(106)]
    void Stop ();

    object Application
    {
      [DispId(200)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    bool Busy
    {
      [DispId(212)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }

    object Container
    {
      [DispId(202)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    object Document
    {
      [DispId(203)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    int Height
    {
      [DispId(209)]
      get;
      [DispId(209)]
      set;
    }

    int Left
    {
      [DispId(206)]
      get;
      [DispId(206)]
      set;
    }

    string LocationName
    {
      [DispId(210)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    string LocationURL
    {
      [DispId(211)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    object Parent
    {
      [DispId(201)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    int Top
    {
      [DispId(207)]
      get;
      [DispId(207)]
      set;
    }

    bool TopLevelContainer
    {
      [DispId(204)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }

    string Type
    {
      [DispId(205)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    int Width
    {
      [DispId(208)]
      get;
      [DispId(208)]
      set;
    }
  }

  [Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E")]
  [ComImport]
  [TypeLibType((short)4176)]
  [DefaultMember("Name")]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IWebBrowser2
  {
    [DispId(100)]
    void GoBack ();

    [DispId(101)]
    void GoForward ();

    [DispId(102)]
    void GoHome ();

    [DispId(103)]
    void GoSearch ();

    [DispId(104)]
    void Navigate ([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref BrowserNavConstants Flags, [In] ref string TargetFrameName, [In] ref object PostData, [In] ref object Headers);

    [DispId(-550)]
    void Refresh ();

    [DispId(105)]
    void Refresh2 ([In] ref object Level);

    [DispId(106)]
    void Stop ();

    [DispId(300)]
    void Quit ();

    [DispId(301)]
    void ClientToWindow ([In, Out] ref int pcx, [In, Out] ref int pcy);

    [DispId(302)]
    void PutProperty ([MarshalAs(UnmanagedType.BStr)] string Property, object vtValue);

    [DispId(303)]
    object GetProperty ([MarshalAs(UnmanagedType.BStr)] string Property);

    [DispId(500)]
    void Navigate2 ([In] ref object URL, [In] ref object Flags, [In] ref string TargetFrameName, [In] ref object PostData, [In] ref object Headers);

    [DispId(501)]
    OLECMDF QueryStatusWB (OLECMDID cmdID);

    [DispId(502)]
    void ExecWB (OLECMDID cmdID, OLECMDEXECOPT cmdexecopt, [In] ref object pvaIn, [In, Out] ref object pvaOut);

    [DispId(503)]
    void ShowBrowserBar ([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);

    bool AddressBar
    {
      [DispId(555)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(555)]
      set;
    }

    object Application
    {
      [DispId(200)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    bool Busy
    {
      [DispId(212)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }

    object Container
    {
      [DispId(202)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    object Document
    {
      [DispId(203)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    string FullName
    {
      [DispId(400)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool FullScreen
    {
      [DispId(407)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(407)]
      set;
    }

    int Height
    {
      [DispId(209)]
      get;
      [DispId(209)]
      set;
    }

    int HWND
    {
      [DispId(-515)]
      get;
    }

    int Left
    {
      [DispId(206)]
      get;
      [DispId(206)]
      set;
    }

    string LocationName
    {
      [DispId(210)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    string LocationURL
    {
      [DispId(211)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool MenuBar
    {
      [DispId(406)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(406)]
      set;
    }

    string Name
    {
      [DispId(0)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool Offline
    {
      [DispId(550)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(550)]
      set;
    }

    object Parent
    {
      [DispId(201)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    string Path
    {
      [DispId(401)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    tagREADYSTATE ReadyState
    {
      [DispId(-525)]
      get;
    }

    bool RegisterAsBrowser
    {
      [DispId(552)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(552)]
      set;
    }

    bool RegisterAsDropTarget
    {
      [DispId(553)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(553)]
      set;
    }

    bool Resizable
    {
      [DispId(556)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(556)]
      set;
    }

    bool Silent
    {
      [DispId(551)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(551)]
      set;
    }

    bool StatusBar
    {
      [DispId(403)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(403)]
      set;
    }

    string StatusText
    {
      [DispId(404)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [DispId(404)]
      set;
    }

    bool TheaterMode
    {
      [DispId(554)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(554)]
      set;
    }

    int ToolBar
    {
      [DispId(405)]
      get;
      [DispId(405)]
      set;
    }

    int Top
    {
      [DispId(207)]
      get;
      [DispId(207)]
      set;
    }

    bool TopLevelContainer
    {
      [DispId(204)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }

    string Type
    {
      [DispId(205)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool Visible
    {
      [DispId(402)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(402)]
      set;
    }

    int Width
    {
      [DispId(208)]
      get;
      [DispId(208)]
      set;
    }
  }

  [Guid("0002DF05-0000-0000-C000-000000000046")]
  [ComImport]
  [TypeLibType((short)4176)]
  [DefaultMember("Name")]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IWebBrowserApp
  {
    [DispId(100)]
    void GoBack ();

    [DispId(101)]
    void GoForward ();

    [DispId(102)]
    void GoHome ();

    [DispId(103)]
    void GoSearch ();

    [DispId(104)]
    void Navigate ([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);

    [DispId(-550)]
    void Refresh ();

    [DispId(105)]
    void Refresh2 ([In] ref object Level);

    [DispId(106)]
    void Stop ();

    [DispId(300)]
    void Quit ();

    [DispId(301)]
    void ClientToWindow ([In, Out] ref int pcx, [In, Out] ref int pcy);

    [DispId(302)]
    void PutProperty ([MarshalAs(UnmanagedType.BStr)] string Property, object vtValue);

    [DispId(303)]
    object GetProperty ([MarshalAs(UnmanagedType.BStr)] string Property);

    object Application
    {
      [DispId(200)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    bool Busy
    {
      [DispId(212)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }

    object Container
    {
      [DispId(202)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    object Document
    {
      [DispId(203)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    string FullName
    {
      [DispId(400)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool FullScreen
    {
      [DispId(407)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(407)]
      set;
    }

    int Height
    {
      [DispId(209)]
      get;
      [DispId(209)]
      set;
    }

    int HWND
    {
      [DispId(-515)]
      get;
    }

    int Left
    {
      [DispId(206)]
      get;
      [DispId(206)]
      set;
    }

    string LocationName
    {
      [DispId(210)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    string LocationURL
    {
      [DispId(211)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool MenuBar
    {
      [DispId(406)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(406)]
      set;
    }

    string Name
    {
      [DispId(0)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    object Parent
    {
      [DispId(201)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    string Path
    {
      [DispId(401)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool StatusBar
    {
      [DispId(403)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(403)]
      set;
    }

    string StatusText
    {
      [DispId(404)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [DispId(404)]
      set;
    }

    int ToolBar
    {
      [DispId(405)]
      get;
      [DispId(405)]
      set;
    }

    int Top
    {
      [DispId(207)]
      get;
      [DispId(207)]
      set;
    }

    bool TopLevelContainer
    {
      [DispId(204)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
    }

    string Type
    {
      [DispId(205)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    bool Visible
    {
      [DispId(402)]
      [return: MarshalAs(UnmanagedType.VariantBool)]
      get;
      [DispId(402)]
      set;
    }

    int Width
    {
      [DispId(208)]
      get;
      [DispId(208)]
      set;
    }
  }

  [Guid("F3470F24-15FD-11D2-BB2E-00805FF7EFCA")]
  [ComImport]
  [CoClass(typeof(CScriptErrorListClass))]
  public interface CScriptErrorList: IScriptErrorList
  {
  }

  [Guid("EFD01300-160F-11D2-BB2E-00805FF7EFCA")]
  [ComImport]
  [TypeLibType((short)16)]
  [ClassInterface(ClassInterfaceType.None)]
  public class CScriptErrorListClass // : IScriptErrorList, CScriptErrorList
  {
  }

  [Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E")]
  [ComImport]
  [CoClass(typeof(InternetExplorerClass))]
  public interface InternetExplorer: IWebBrowser2
  {
  }

  [Guid("0002DF01-0000-0000-C000-000000000046")]
  [ComImport]
  [TypeLibType((short)2)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DWebBrowserEvents2, DWebBrowserEvents")]
  public class InternetExplorerClass // : IWebBrowserApp, IWebBrowser2, InternetExplorer, , DWebBrowserEvents2_EventDWebBrowserEvents_Event
  {
  }

  [Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E")]
  [ComImport]
  [CoClass(typeof(InternetExplorerMediumClass))]
  public interface InternetExplorerMedium: IWebBrowser2
  {
  }

  [Guid("D5E8041D-920F-45E9-B8FB-B1DEB82C6E5E")]
  [ComImport]
  [TypeLibType((short)2)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DWebBrowserEvents2, DWebBrowserEvents")]
  public class InternetExplorerMediumClass // : IWebBrowserApp, IWebBrowser2, InternetExplorerMedium, , DWebBrowserEvents2_EventDWebBrowserEvents_Event
  {
  }

  [Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E")]
  [ComImport]
  [CoClass(typeof(ShellBrowserWindowClass))]
  public interface ShellBrowserWindow: IWebBrowser2
  {
  }

  [Guid("C08AFD90-F2A1-11D1-8455-00A0C91F3880")]
  [ComImport]
  [TypeLibType((short)16)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DWebBrowserEvents2, DWebBrowserEvents")]
  public class ShellBrowserWindowClass // : IWebBrowserApp, IWebBrowser2, ShellBrowserWindow, , DWebBrowserEvents2_EventDWebBrowserEvents_Event
  {
  }

  [Guid("E572D3C9-37BE-4AE2-825D-D521763E3108")]
  [ComImport]
  [CoClass(typeof(ShellNameSpaceClass))]
  public interface ShellNameSpace: IShellNameSpace
  {
  }

  [Guid("55136805-B2DE-11D1-B9F2-00A0C98BC547")]
  [ComImport]
  [TypeLibType((short)2)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DShellNameSpaceEvents")]
  public class ShellNameSpaceClass // : IShellNameSpace, ShellNameSpace, DShellNameSpaceEvents_Event
  {
  }

  [Guid("E572D3C9-37BE-4AE2-825D-D521763E3108")]
  [ComImport]
  [CoClass(typeof(ShellShellNameSpaceClass))]
  public interface ShellShellNameSpace: IShellNameSpace
  {
  }

  [Guid("2F2F1F96-2BC1-4B1C-BE28-EA3774F4676A")]
  [ComImport]
  [TypeLibType((short)2)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DShellNameSpaceEvents")]
  public class ShellShellNameSpaceClass // : IShellNameSpace, ShellShellNameSpace, DShellNameSpaceEvents_Event
  {
  }

  [Guid("528DF2EC-D419-40BC-9B6D-DCDBF9C1B25D")]
  [ComImport]
  [CoClass(typeof(ShellUIHelperClass))]
  public interface ShellUIHelper: IShellUIHelper3
  {
  }

  [Guid("64AB4BB7-111E-11D1-8F79-00C04FC2FBE1")]
  [ComImport]
  [TypeLibType((short)2)]
  [ClassInterface(ClassInterfaceType.None)]
  public class ShellUIHelperClass // : IShellUIHelper3, ShellUIHelper
  {
  }

  [Guid("85CB6900-4D95-11CF-960C-0080C7F4EE85")]
  [ComImport]
  [CoClass(typeof(ShellWindowsClass))]
  public interface ShellWindows: IShellWindows
  {
  }

  [Guid("9BA05972-F6A8-11CF-A442-00A0C90A8F39")]
  [ComImport]
  [TypeLibType((short)2)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DShellWindowsEvents")]
  public class ShellWindowsClass // : IShellWindows, ShellWindows, IEnumerable, DShellWindowsEvents_Event
  {
  }

  [Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E")]
  [ComImport]
  [CoClass(typeof(WebBrowserClass))]
  public interface WebBrowser: IWebBrowser2
  {
  }

  [Guid("8856F961-340A-11D0-A96B-00C04FD705A2")]
  [ComImport]
  [TypeLibType((short)34)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DWebBrowserEvents2, DWebBrowserEvents,DWebBrowserEvents2_EventDWebBrowserEvents_Event")]
  public class WebBrowserClass  //: IWebBrowser, IWebBrowser2, WebBrowser ,, DWebBrowserEvents2_EventDWebBrowserEvents_Event
  {
  	
  }

  [Guid("EAB22AC1-30C1-11CF-A7EB-0000C05BAE0B")]
  [ComImport]
  [CoClass(typeof(WebBrowser_V1Class))]
  public interface WebBrowser_V1: IWebBrowser
  {
  }

  [Guid("EAB22AC3-30C1-11CF-A7EB-0000C05BAE0B")]
  [ComImport]
  [TypeLibType((short)34)]
  [ClassInterface(ClassInterfaceType.None)]
  [ComSourceInterfaces("DWebBrowserEvents2, DWebBrowserEvents")]
  public class WebBrowser_V1Class // : IWebBrowser2, IWebBrowser, WebBrowser_V1, , DWebBrowserEvents2_EventDWebBrowserEvents_Event
  {
  }
}
#pragma warning restore 618
