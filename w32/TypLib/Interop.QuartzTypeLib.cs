//*****************************************************************//
//                                                                 //
// This file is generated automatically by Aurigma COM to .NET 1.0 //
//                                                                 //
//*****************************************************************//

using System;
using System.Runtime.InteropServices;

namespace QuartzTypeLib
{

  /// <summary><para><c>IAMCollection</c> interface.  </para><para>Collection</para></summary>
  [Guid("56A868B9-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IAMCollection
  {
    /// <summary><para><c>Item</c> method of <c>IAMCollection</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Item</c> method was the following:  <c>HRESULT Item (long lItem, [out] IUnknown** ppUnk)</c>;</para></remarks>
    [DispId(1610743809)]
    void Item (int lItem, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppUnk);

    /// <summary><para><c>_NewEnum</c> property of <c>IAMCollection</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>_NewEnum</c> property was the following:  <c>IUnknown* _NewEnum</c>;</para></remarks>
    object _NewEnum
    {
      [DispId(1610743810)]
      [return: MarshalAs(UnmanagedType.IUnknown)]
      get;
    }

    /// <summary><para><c>Count</c> property of <c>IAMCollection</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Count</c> property was the following:  <c>long Count</c>;</para></remarks>
    int Count
    {
      [DispId(1610743808)]
      get;
    }
  }

  /// <summary><para><c>IAMStats</c> interface.  </para><para>Statistics</para></summary>
  [Guid("BC9BCF80-DCD2-11D2-ABF6-00A0C905F375")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IAMStats
  {
    /// <summary><para><c>Reset</c> method of <c>IAMStats</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Reset</c> method was the following:  <c>HRESULT Reset (void)</c>;</para></remarks>
    [DispId(1610743808)]
    void Reset ();

    /// <summary><para><c>GetValueByIndex</c> method of <c>IAMStats</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetValueByIndex</c> method was the following:  <c>HRESULT GetValueByIndex (long lIndex, [out] BSTR* szName, [out] long* lCount, [out] double* dLast, [out] double* dAverage, [out] double* dStdDev, [out] double* dMin, [out] double* dMax)</c>;</para></remarks>
    [DispId(1610743810)]
    void GetValueByIndex (int lIndex, [Out, MarshalAs(UnmanagedType.BStr)] out string szName, [Out] out int lCount, [Out] out double dLast, [Out] out double dAverage, [Out] out double dStdDev, [Out] out double dMin, [Out] out double dMax);

    /// <summary><para><c>GetValueByName</c> method of <c>IAMStats</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetValueByName</c> method was the following:  <c>HRESULT GetValueByName (BSTR szName, [out] long* lIndex, [out] long* lCount, [out] double* dLast, [out] double* dAverage, [out] double* dStdDev, [out] double* dMin, [out] double* dMax)</c>;</para></remarks>
    [DispId(1610743811)]
    void GetValueByName ([MarshalAs(UnmanagedType.BStr)] string szName, [Out] out int lIndex, [Out] out int lCount, [Out] out double dLast, [Out] out double dAverage, [Out] out double dStdDev, [Out] out double dMin, [Out] out double dMax);

    /// <summary><para><c>GetIndex</c> method of <c>IAMStats</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetIndex</c> method was the following:  <c>HRESULT GetIndex (BSTR szName, long lCreate, [out] long* plIndex)</c>;</para></remarks>
    [DispId(1610743812)]
    void GetIndex ([MarshalAs(UnmanagedType.BStr)] string szName, int lCreate, [Out] out int plIndex);

    /// <summary><para><c>AddValue</c> method of <c>IAMStats</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>AddValue</c> method was the following:  <c>HRESULT AddValue (long lIndex, double dValue)</c>;</para></remarks>
    [DispId(1610743813)]
    void AddValue (int lIndex, double dValue);

    /// <summary><para><c>Count</c> property of <c>IAMStats</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Count</c> property was the following:  <c>long Count</c>;</para></remarks>
    int Count
    {
      [DispId(1610743809)]
      get;
    }
  }

  /// <summary><para><c>IBasicAudio</c> interface.  </para><para>IBasicAudio interface</para></summary>
  [Guid("56A868B3-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IBasicAudio
  {
    /// <summary><para><c>Balance</c> property of <c>IBasicAudio</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Balance</c> property was the following:  <c>long Balance</c>;</para></remarks>
    int Balance
    {
      [DispId(1610743810)]
      get;
      [DispId(1610743810)]
      set;
    }

    /// <summary><para><c>Volume</c> property of <c>IBasicAudio</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Volume</c> property was the following:  <c>long Volume</c>;</para></remarks>
    int Volume
    {
      [DispId(1610743808)]
      get;
      [DispId(1610743808)]
      set;
    }
  }

  /// <summary><para><c>IBasicVideo</c> interface.  </para><para>IBasicVideo interface</para></summary>
  [Guid("56A868B5-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IBasicVideo
  {
    /// <summary><para><c>SetSourcePosition</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetSourcePosition</c> method was the following:  <c>HRESULT SetSourcePosition (long Left, long Top, long Width, long Height)</c>;</para></remarks>
    [DispId(1610743829)]
    void SetSourcePosition (int Left, int Top, int Width, int Height);

    /// <summary><para><c>GetSourcePosition</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetSourcePosition</c> method was the following:  <c>HRESULT GetSourcePosition ([out] long* pLeft, [out] long* pTop, [out] long* pWidth, [out] long* pHeight)</c>;</para></remarks>
    [DispId(1610743830)]
    void GetSourcePosition ([Out] out int pLeft, [Out] out int pTop, [Out] out int pWidth, [Out] out int pHeight);

    /// <summary><para><c>SetDefaultSourcePosition</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetDefaultSourcePosition</c> method was the following:  <c>HRESULT SetDefaultSourcePosition (void)</c>;</para></remarks>
    [DispId(1610743831)]
    void SetDefaultSourcePosition ();

    /// <summary><para><c>SetDestinationPosition</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetDestinationPosition</c> method was the following:  <c>HRESULT SetDestinationPosition (long Left, long Top, long Width, long Height)</c>;</para></remarks>
    [DispId(1610743832)]
    void SetDestinationPosition (int Left, int Top, int Width, int Height);

    /// <summary><para><c>GetDestinationPosition</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetDestinationPosition</c> method was the following:  <c>HRESULT GetDestinationPosition ([out] long* pLeft, [out] long* pTop, [out] long* pWidth, [out] long* pHeight)</c>;</para></remarks>
    [DispId(1610743833)]
    void GetDestinationPosition ([Out] out int pLeft, [Out] out int pTop, [Out] out int pWidth, [Out] out int pHeight);

    /// <summary><para><c>SetDefaultDestinationPosition</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetDefaultDestinationPosition</c> method was the following:  <c>HRESULT SetDefaultDestinationPosition (void)</c>;</para></remarks>
    [DispId(1610743834)]
    void SetDefaultDestinationPosition ();

    /// <summary><para><c>GetVideoSize</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetVideoSize</c> method was the following:  <c>HRESULT GetVideoSize ([out] long* pWidth, [out] long* pHeight)</c>;</para></remarks>
    [DispId(1610743835)]
    void GetVideoSize ([Out] out int pWidth, [Out] out int pHeight);

    /// <summary><para><c>GetVideoPaletteEntries</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetVideoPaletteEntries</c> method was the following:  <c>HRESULT GetVideoPaletteEntries (long StartIndex, long Entries, [out] long* pRetrieved, [out] long* pPalette)</c>;</para></remarks>
    [DispId(1610743836)]
    void GetVideoPaletteEntries (int StartIndex, int Entries, [Out] out int pRetrieved, [Out] out int pPalette);

    /// <summary><para><c>GetCurrentImage</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetCurrentImage</c> method was the following:  <c>HRESULT GetCurrentImage ([in, out] long* pBufferSize, [out] long* pDIBImage)</c>;</para></remarks>
    [DispId(1610743837)]
    void GetCurrentImage ([In, Out] ref int pBufferSize, [Out] out int pDIBImage);

    /// <summary><para><c>IsUsingDefaultSource</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>IsUsingDefaultSource</c> method was the following:  <c>HRESULT IsUsingDefaultSource (void)</c>;</para></remarks>
    [DispId(1610743838)]
    void IsUsingDefaultSource ();

    /// <summary><para><c>IsUsingDefaultDestination</c> method of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>IsUsingDefaultDestination</c> method was the following:  <c>HRESULT IsUsingDefaultDestination (void)</c>;</para></remarks>
    [DispId(1610743839)]
    void IsUsingDefaultDestination ();

    /// <summary><para><c>AvgTimePerFrame</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>AvgTimePerFrame</c> property was the following:  <c>double AvgTimePerFrame</c>;</para></remarks>
    double AvgTimePerFrame
    {
      [DispId(1610743808)]
      get;
    }

    /// <summary><para><c>BitErrorRate</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>BitErrorRate</c> property was the following:  <c>long BitErrorRate</c>;</para></remarks>
    int BitErrorRate
    {
      [DispId(1610743810)]
      get;
    }

    /// <summary><para><c>BitRate</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>BitRate</c> property was the following:  <c>long BitRate</c>;</para></remarks>
    int BitRate
    {
      [DispId(1610743809)]
      get;
    }

    /// <summary><para><c>DestinationHeight</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>DestinationHeight</c> property was the following:  <c>long DestinationHeight</c>;</para></remarks>
    int DestinationHeight
    {
      [DispId(1610743827)]
      get;
      [DispId(1610743827)]
      set;
    }

    /// <summary><para><c>DestinationLeft</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>DestinationLeft</c> property was the following:  <c>long DestinationLeft</c>;</para></remarks>
    int DestinationLeft
    {
      [DispId(1610743821)]
      get;
      [DispId(1610743821)]
      set;
    }

    /// <summary><para><c>DestinationTop</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>DestinationTop</c> property was the following:  <c>long DestinationTop</c>;</para></remarks>
    int DestinationTop
    {
      [DispId(1610743825)]
      get;
      [DispId(1610743825)]
      set;
    }

    /// <summary><para><c>DestinationWidth</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>DestinationWidth</c> property was the following:  <c>long DestinationWidth</c>;</para></remarks>
    int DestinationWidth
    {
      [DispId(1610743823)]
      get;
      [DispId(1610743823)]
      set;
    }

    /// <summary><para><c>SourceHeight</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SourceHeight</c> property was the following:  <c>long SourceHeight</c>;</para></remarks>
    int SourceHeight
    {
      [DispId(1610743819)]
      get;
      [DispId(1610743819)]
      set;
    }

    /// <summary><para><c>SourceLeft</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SourceLeft</c> property was the following:  <c>long SourceLeft</c>;</para></remarks>
    int SourceLeft
    {
      [DispId(1610743813)]
      get;
      [DispId(1610743813)]
      set;
    }

    /// <summary><para><c>SourceTop</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SourceTop</c> property was the following:  <c>long SourceTop</c>;</para></remarks>
    int SourceTop
    {
      [DispId(1610743817)]
      get;
      [DispId(1610743817)]
      set;
    }

    /// <summary><para><c>SourceWidth</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SourceWidth</c> property was the following:  <c>long SourceWidth</c>;</para></remarks>
    int SourceWidth
    {
      [DispId(1610743815)]
      get;
      [DispId(1610743815)]
      set;
    }

    /// <summary><para><c>VideoHeight</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>VideoHeight</c> property was the following:  <c>long VideoHeight</c>;</para></remarks>
    int VideoHeight
    {
      [DispId(1610743812)]
      get;
    }

    /// <summary><para><c>VideoWidth</c> property of <c>IBasicVideo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>VideoWidth</c> property was the following:  <c>long VideoWidth</c>;</para></remarks>
    int VideoWidth
    {
      [DispId(1610743811)]
      get;
    }
  }

  /// <summary><para><c>IFilterInfo</c> interface.  </para><para>FilterInfo</para></summary>
  [Guid("56A868BA-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IFilterInfo
  {
    /// <summary><para><c>FindPin</c> method of <c>IFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>FindPin</c> method was the following:  <c>HRESULT FindPin (BSTR strPinID, [out] IDispatch** ppUnk)</c>;</para></remarks>
    [DispId(1610743808)]
    void FindPin ([MarshalAs(UnmanagedType.BStr)] string strPinID, [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

    /// <summary><para><c>Filename</c> property of <c>IFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Filename</c> property was the following:  <c>BSTR Filename</c>;</para></remarks>
    string Filename
    {
      [DispId(1610743814)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [DispId(1610743814)]
      set;
    }

    /// <summary><para><c>Filter</c> property of <c>IFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Filter</c> property was the following:  <c>IUnknown* Filter</c>;</para></remarks>
    object Filter
    {
      [DispId(1610743811)]
      [return: MarshalAs(UnmanagedType.IUnknown)]
      get;
    }

    /// <summary><para><c>IsFileSource</c> property of <c>IFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>IsFileSource</c> property was the following:  <c>long IsFileSource</c>;</para></remarks>
    int IsFileSource
    {
      [DispId(1610743813)]
      get;
    }

    /// <summary><para><c>Name</c> property of <c>IFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Name</c> property was the following:  <c>BSTR Name</c>;</para></remarks>
    string Name
    {
      [DispId(1610743809)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    /// <summary><para><c>Pins</c> property of <c>IFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Pins</c> property was the following:  <c>IDispatch* Pins</c>;</para></remarks>
    object Pins
    {
      [DispId(1610743812)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    /// <summary><para><c>VendorInfo</c> property of <c>IFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>VendorInfo</c> property was the following:  <c>BSTR VendorInfo</c>;</para></remarks>
    string VendorInfo
    {
      [DispId(1610743810)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }
  }

  /// <summary><para><c>IMediaControl</c> interface.  </para><para>IMediaControl interface</para></summary>
  [Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IMediaControl
  {
    /// <summary><para><c>Run</c> method of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Run</c> method was the following:  <c>HRESULT Run (void)</c>;</para></remarks>
    [DispId(1610743808)]
    void Run ();

    /// <summary><para><c>Pause</c> method of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Pause</c> method was the following:  <c>HRESULT Pause (void)</c>;</para></remarks>
    [DispId(1610743809)]
    void Pause ();

    /// <summary><para><c>Stop</c> method of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Stop</c> method was the following:  <c>HRESULT Stop (void)</c>;</para></remarks>
    [DispId(1610743810)]
    void Stop ();

    /// <summary><para><c>GetState</c> method of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetState</c> method was the following:  <c>HRESULT GetState (long msTimeout, [out] long* pfs)</c>;</para></remarks>
    [DispId(1610743811)]
    void GetState (int msTimeout, [Out] out int pfs);

    /// <summary><para><c>RenderFile</c> method of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>RenderFile</c> method was the following:  <c>HRESULT RenderFile (BSTR strFilename)</c>;</para></remarks>
    [DispId(1610743812)]
    void RenderFile ([MarshalAs(UnmanagedType.BStr)] string strFilename);

    /// <summary><para><c>AddSourceFilter</c> method of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>AddSourceFilter</c> method was the following:  <c>HRESULT AddSourceFilter (BSTR strFilename, [out] IDispatch** ppUnk)</c>;</para></remarks>
    [DispId(1610743813)]
    void AddSourceFilter ([MarshalAs(UnmanagedType.BStr)] string strFilename, [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

    /// <summary><para><c>StopWhenReady</c> method of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>StopWhenReady</c> method was the following:  <c>HRESULT StopWhenReady (void)</c>;</para></remarks>
    [DispId(1610743816)]
    void StopWhenReady ();

    /// <summary><para><c>FilterCollection</c> property of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>FilterCollection</c> property was the following:  <c>IDispatch* FilterCollection</c>;</para></remarks>
    object FilterCollection
    {
      [DispId(1610743814)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    /// <summary><para><c>RegFilterCollection</c> property of <c>IMediaControl</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>RegFilterCollection</c> property was the following:  <c>IDispatch* RegFilterCollection</c>;</para></remarks>
    object RegFilterCollection
    {
      [DispId(1610743815)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }
  }

  /// <summary><para><c>IMediaEvent</c> interface.  </para><para>IMediaEvent interface</para></summary>
  [Guid("56A868B6-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IMediaEvent
  {
    /// <summary><para><c>GetEventHandle</c> method of <c>IMediaEvent</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetEventHandle</c> method was the following:  <c>HRESULT GetEventHandle ([out] long* hEvent)</c>;</para></remarks>
    [DispId(1610743808)]
    void GetEventHandle ([Out] out int hEvent);

    /// <summary><para><c>GetEvent</c> method of <c>IMediaEvent</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetEvent</c> method was the following:  <c>HRESULT GetEvent ([out] long* lEventCode, [out] long* lParam1, [out] long* lParam2, long msTimeout)</c>;</para></remarks>
    [DispId(1610743809)]
    void GetEvent ([Out] out int lEventCode, [Out] out int lParam1, [Out] out int lParam2, int msTimeout);

    /// <summary><para><c>WaitForCompletion</c> method of <c>IMediaEvent</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>WaitForCompletion</c> method was the following:  <c>HRESULT WaitForCompletion (long msTimeout, [out] long* pEvCode)</c>;</para></remarks>
    [DispId(1610743810)]
    void WaitForCompletion (int msTimeout, [Out] out int pEvCode);

    /// <summary><para><c>CancelDefaultHandling</c> method of <c>IMediaEvent</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>CancelDefaultHandling</c> method was the following:  <c>HRESULT CancelDefaultHandling (long lEvCode)</c>;</para></remarks>
    [DispId(1610743811)]
    void CancelDefaultHandling (int lEvCode);

    /// <summary><para><c>RestoreDefaultHandling</c> method of <c>IMediaEvent</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>RestoreDefaultHandling</c> method was the following:  <c>HRESULT RestoreDefaultHandling (long lEvCode)</c>;</para></remarks>
    [DispId(1610743812)]
    void RestoreDefaultHandling (int lEvCode);

    /// <summary><para><c>FreeEventParams</c> method of <c>IMediaEvent</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>FreeEventParams</c> method was the following:  <c>HRESULT FreeEventParams (long lEvCode, long lParam1, long lParam2)</c>;</para></remarks>
    [DispId(1610743813)]
    void FreeEventParams (int lEvCode, int lParam1, int lParam2);
  }

  /// <summary><para><c>IMediaPosition</c> interface.  </para><para>IMediaPosition interface</para></summary>
  [Guid("56A868B2-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IMediaPosition
  {
    /// <summary><para><c>CanSeekForward</c> method of <c>IMediaPosition</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>CanSeekForward</c> method was the following:  <c>HRESULT CanSeekForward ([out, retval] long* ReturnValue)</c>;</para></remarks>
    [DispId(1610743817)]
    int CanSeekForward ();

    /// <summary><para><c>CanSeekBackward</c> method of <c>IMediaPosition</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>CanSeekBackward</c> method was the following:  <c>HRESULT CanSeekBackward ([out, retval] long* ReturnValue)</c>;</para></remarks>
    [DispId(1610743818)]
    int CanSeekBackward ();

    /// <summary><para><c>CurrentPosition</c> property of <c>IMediaPosition</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>CurrentPosition</c> property was the following:  <c>double CurrentPosition</c>;</para></remarks>
    double CurrentPosition
    {
      [DispId(1610743809)]
      get;
      [DispId(1610743809)]
      set;
    }

    /// <summary><para><c>Duration</c> property of <c>IMediaPosition</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Duration</c> property was the following:  <c>double Duration</c>;</para></remarks>
    double Duration
    {
      [DispId(1610743808)]
      get;
    }

    /// <summary><para><c>PrerollTime</c> property of <c>IMediaPosition</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>PrerollTime</c> property was the following:  <c>double PrerollTime</c>;</para></remarks>
    double PrerollTime
    {
      [DispId(1610743813)]
      get;
      [DispId(1610743813)]
      set;
    }

    /// <summary><para><c>Rate</c> property of <c>IMediaPosition</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Rate</c> property was the following:  <c>double Rate</c>;</para></remarks>
    double Rate
    {
      [DispId(1610743815)]
      get;
      [DispId(1610743815)]
      set;
    }

    /// <summary><para><c>StopTime</c> property of <c>IMediaPosition</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>StopTime</c> property was the following:  <c>double StopTime</c>;</para></remarks>
    double StopTime
    {
      [DispId(1610743811)]
      get;
      [DispId(1610743811)]
      set;
    }
  }

  /// <summary><para><c>IMediaTypeInfo</c> interface.  </para><para>Media Type</para></summary>
  [Guid("56A868BC-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IMediaTypeInfo
  {
    /// <summary><para><c>Subtype</c> property of <c>IMediaTypeInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Subtype</c> property was the following:  <c>BSTR Subtype</c>;</para></remarks>
    string Subtype
    {
      [DispId(1610743809)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    /// <summary><para><c>Type</c> property of <c>IMediaTypeInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Type</c> property was the following:  <c>BSTR Type</c>;</para></remarks>
    string Type
    {
      [DispId(1610743808)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }
  }

  /// <summary><para><c>IPinInfo</c> interface.  </para><para>Pin Info</para></summary>
  [Guid("56A868BD-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IPinInfo
  {
    /// <summary><para><c>Connect</c> method of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Connect</c> method was the following:  <c>HRESULT Connect (IUnknown* pPin)</c>;</para></remarks>
    [DispId(1610743816)]
    void Connect ([MarshalAs(UnmanagedType.IUnknown)] object pPin);

    /// <summary><para><c>ConnectDirect</c> method of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>ConnectDirect</c> method was the following:  <c>HRESULT ConnectDirect (IUnknown* pPin)</c>;</para></remarks>
    [DispId(1610743817)]
    void ConnectDirect ([MarshalAs(UnmanagedType.IUnknown)] object pPin);

    /// <summary><para><c>ConnectWithType</c> method of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>ConnectWithType</c> method was the following:  <c>HRESULT ConnectWithType (IUnknown* pPin, IDispatch* pMediaType)</c>;</para></remarks>
    [DispId(1610743818)]
    void ConnectWithType ([MarshalAs(UnmanagedType.IUnknown)] object pPin, [MarshalAs(UnmanagedType.IDispatch)] object pMediaType);

    /// <summary><para><c>Disconnect</c> method of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Disconnect</c> method was the following:  <c>HRESULT Disconnect (void)</c>;</para></remarks>
    [DispId(1610743819)]
    void Disconnect ();

    /// <summary><para><c>Render</c> method of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Render</c> method was the following:  <c>HRESULT Render (void)</c>;</para></remarks>
    [DispId(1610743820)]
    void Render ();

    /// <summary><para><c>ConnectedTo</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>ConnectedTo</c> property was the following:  <c>IDispatch* ConnectedTo</c>;</para></remarks>
    object ConnectedTo
    {
      [DispId(1610743809)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    /// <summary><para><c>ConnectionMediaType</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>ConnectionMediaType</c> property was the following:  <c>IDispatch* ConnectionMediaType</c>;</para></remarks>
    object ConnectionMediaType
    {
      [DispId(1610743810)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    /// <summary><para><c>Direction</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Direction</c> property was the following:  <c>long Direction</c>;</para></remarks>
    int Direction
    {
      [DispId(1610743813)]
      get;
    }

    /// <summary><para><c>FilterInfo</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>FilterInfo</c> property was the following:  <c>IDispatch* FilterInfo</c>;</para></remarks>
    object FilterInfo
    {
      [DispId(1610743811)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    /// <summary><para><c>MediaTypes</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>MediaTypes</c> property was the following:  <c>IDispatch* MediaTypes</c>;</para></remarks>
    object MediaTypes
    {
      [DispId(1610743815)]
      [return: MarshalAs(UnmanagedType.IDispatch)]
      get;
    }

    /// <summary><para><c>Name</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Name</c> property was the following:  <c>BSTR Name</c>;</para></remarks>
    string Name
    {
      [DispId(1610743812)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }

    /// <summary><para><c>Pin</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Pin</c> property was the following:  <c>IUnknown* Pin</c>;</para></remarks>
    object Pin
    {
      [DispId(1610743808)]
      [return: MarshalAs(UnmanagedType.IUnknown)]
      get;
    }

    /// <summary><para><c>PinID</c> property of <c>IPinInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>PinID</c> property was the following:  <c>BSTR PinID</c>;</para></remarks>
    string PinID
    {
      [DispId(1610743814)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }
  }

  /// <summary><para><c>IRegFilterInfo</c> interface.  </para><para>Registry Filter Info</para></summary>
  [Guid("56A868BB-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IRegFilterInfo
  {
    /// <summary><para><c>Filter</c> method of <c>IRegFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Filter</c> method was the following:  <c>HRESULT Filter ([out] IDispatch** ppUnk)</c>;</para></remarks>
    [DispId(1610743809)]
    void Filter ([Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

    /// <summary><para><c>Name</c> property of <c>IRegFilterInfo</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Name</c> property was the following:  <c>BSTR Name</c>;</para></remarks>
    string Name
    {
      [DispId(1610743808)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
    }
  }

  /// <summary><para><c>IVideoWindow</c> interface.  </para><para>IVideoWindow interface</para></summary>
  [Guid("56A868B4-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4160)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IVideoWindow
  {
    /// <summary><para><c>SetWindowForeground</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetWindowForeground</c> method was the following:  <c>HRESULT SetWindowForeground (long Focus)</c>;</para></remarks>
    [DispId(1610743838)]
    void SetWindowForeground (int Focus);

    /// <summary><para><c>NotifyOwnerMessage</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>NotifyOwnerMessage</c> method was the following:  <c>HRESULT NotifyOwnerMessage (long hwnd, long uMsg, long wParam, long lParam)</c>;</para></remarks>
    [DispId(1610743839)]
    void NotifyOwnerMessage (int hwnd, int uMsg, int wParam, int lParam);

    /// <summary><para><c>SetWindowPosition</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetWindowPosition</c> method was the following:  <c>HRESULT SetWindowPosition (long Left, long Top, long Width, long Height)</c>;</para></remarks>
    [DispId(1610743840)]
    void SetWindowPosition (int Left, int Top, int Width, int Height);

    /// <summary><para><c>GetWindowPosition</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetWindowPosition</c> method was the following:  <c>HRESULT GetWindowPosition ([out] long* pLeft, [out] long* pTop, [out] long* pWidth, [out] long* pHeight)</c>;</para></remarks>
    [DispId(1610743841)]
    void GetWindowPosition ([Out] out int pLeft, [Out] out int pTop, [Out] out int pWidth, [Out] out int pHeight);

    /// <summary><para><c>GetMinIdealImageSize</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetMinIdealImageSize</c> method was the following:  <c>HRESULT GetMinIdealImageSize ([out] long* pWidth, [out] long* pHeight)</c>;</para></remarks>
    [DispId(1610743842)]
    void GetMinIdealImageSize ([Out] out int pWidth, [Out] out int pHeight);

    /// <summary><para><c>GetMaxIdealImageSize</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetMaxIdealImageSize</c> method was the following:  <c>HRESULT GetMaxIdealImageSize ([out] long* pWidth, [out] long* pHeight)</c>;</para></remarks>
    [DispId(1610743843)]
    void GetMaxIdealImageSize ([Out] out int pWidth, [Out] out int pHeight);

    /// <summary><para><c>GetRestorePosition</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetRestorePosition</c> method was the following:  <c>HRESULT GetRestorePosition ([out] long* pLeft, [out] long* pTop, [out] long* pWidth, [out] long* pHeight)</c>;</para></remarks>
    [DispId(1610743844)]
    void GetRestorePosition ([Out] out int pLeft, [Out] out int pTop, [Out] out int pWidth, [Out] out int pHeight);

    /// <summary><para><c>HideCursor</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>HideCursor</c> method was the following:  <c>HRESULT HideCursor (long HideCursor)</c>;</para></remarks>
    [DispId(1610743845)]
    void HideCursor (int HideCursor);

    /// <summary><para><c>IsCursorHidden</c> method of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>IsCursorHidden</c> method was the following:  <c>HRESULT IsCursorHidden ([out] long* CursorHidden)</c>;</para></remarks>
    [DispId(1610743846)]
    void IsCursorHidden ([Out] out int CursorHidden);

    /// <summary><para><c>AutoShow</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>AutoShow</c> property was the following:  <c>long AutoShow</c>;</para></remarks>
    int AutoShow
    {
      [DispId(1610743814)]
      get;
      [DispId(1610743814)]
      set;
    }

    /// <summary><para><c>BackgroundPalette</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>BackgroundPalette</c> property was the following:  <c>long BackgroundPalette</c>;</para></remarks>
    int BackgroundPalette
    {
      [DispId(1610743818)]
      get;
      [DispId(1610743818)]
      set;
    }

    /// <summary><para><c>BorderColor</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>BorderColor</c> property was the following:  <c>long BorderColor</c>;</para></remarks>
    int BorderColor
    {
      [DispId(1610743834)]
      get;
      [DispId(1610743834)]
      set;
    }

    /// <summary><para><c>Caption</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Caption</c> property was the following:  <c>BSTR Caption</c>;</para></remarks>
    string Caption
    {
      [DispId(1610743808)]
      [return: MarshalAs(UnmanagedType.BStr)]
      get;
      [DispId(1610743808)]
      set;
    }

    /// <summary><para><c>FullScreenMode</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>FullScreenMode</c> property was the following:  <c>long FullScreenMode</c>;</para></remarks>
    int FullScreenMode
    {
      [DispId(1610743836)]
      get;
      [DispId(1610743836)]
      set;
    }

    /// <summary><para><c>Height</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Height</c> property was the following:  <c>long Height</c>;</para></remarks>
    int Height
    {
      [DispId(1610743828)]
      get;
      [DispId(1610743828)]
      set;
    }

    /// <summary><para><c>Left</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Left</c> property was the following:  <c>long Left</c>;</para></remarks>
    int Left
    {
      [DispId(1610743822)]
      get;
      [DispId(1610743822)]
      set;
    }

    /// <summary><para><c>MessageDrain</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>MessageDrain</c> property was the following:  <c>long MessageDrain</c>;</para></remarks>
    int MessageDrain
    {
      [DispId(1610743832)]
      get;
      [DispId(1610743832)]
      set;
    }

    /// <summary><para><c>Owner</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Owner</c> property was the following:  <c>long Owner</c>;</para></remarks>
    int Owner
    {
      [DispId(1610743830)]
      get;
      [DispId(1610743830)]
      set;
    }

    /// <summary><para><c>Top</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Top</c> property was the following:  <c>long Top</c>;</para></remarks>
    int Top
    {
      [DispId(1610743826)]
      get;
      [DispId(1610743826)]
      set;
    }

    /// <summary><para><c>Visible</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Visible</c> property was the following:  <c>long Visible</c>;</para></remarks>
    int Visible
    {
      [DispId(1610743820)]
      get;
      [DispId(1610743820)]
      set;
    }

    /// <summary><para><c>Width</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Width</c> property was the following:  <c>long Width</c>;</para></remarks>
    int Width
    {
      [DispId(1610743824)]
      get;
      [DispId(1610743824)]
      set;
    }

    /// <summary><para><c>WindowState</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>WindowState</c> property was the following:  <c>long WindowState</c>;</para></remarks>
    int WindowState
    {
      [DispId(1610743816)]
      get;
      [DispId(1610743816)]
      set;
    }

    /// <summary><para><c>WindowStyle</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>WindowStyle</c> property was the following:  <c>long WindowStyle</c>;</para></remarks>
    int WindowStyle
    {
      [DispId(1610743810)]
      get;
      [DispId(1610743810)]
      set;
    }

    /// <summary><para><c>WindowStyleEx</c> property of <c>IVideoWindow</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>WindowStyleEx</c> property was the following:  <c>long WindowStyleEx</c>;</para></remarks>
    int WindowStyleEx
    {
      [DispId(1610743812)]
      get;
      [DispId(1610743812)]
      set;
    }
  }

  /// <summary><para><c>IBasicVideo2</c> interface.  </para><para>IBasicVideo2</para></summary>
  [Guid("329BB360-F6EA-11D1-9038-00A0C9697298")]
  [ComImport]
  [TypeLibType((short)4096)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IBasicVideo2 : IBasicVideo
  {
    /// <summary><para><c>GetPreferredAspectRatio</c> method of <c>IBasicVideo2</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetPreferredAspectRatio</c> method was the following:  <c>HRESULT GetPreferredAspectRatio ([out] long* plAspectX, [out] long* plAspectY)</c>;</para></remarks>
    [DispId(1610809344)]
    void GetPreferredAspectRatio ([Out] out int plAspectX, [Out] out int plAspectY);
  }

  /// <summary><para><c>IDeferredCommand</c> interface.  </para><para>IDeferredCommand</para></summary>
  [Guid("56A868B8-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)0)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
  public interface IDeferredCommand
  {
    /// <summary><para><c>Cancel</c> method of <c>IDeferredCommand</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Cancel</c> method was the following:  <c>HRESULT Cancel (void)</c>;</para></remarks>
    void Cancel ();

    /// <summary><para><c>Confidence</c> method of <c>IDeferredCommand</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Confidence</c> method was the following:  <c>HRESULT Confidence ([out] long* pConfidence)</c>;</para></remarks>
    void Confidence ([Out] out int pConfidence);

    /// <summary><para><c>Postpone</c> method of <c>IDeferredCommand</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>Postpone</c> method was the following:  <c>HRESULT Postpone (double newtime)</c>;</para></remarks>
    void Postpone (double newtime);

    /// <summary><para><c>GetHResult</c> method of <c>IDeferredCommand</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetHResult</c> method was the following:  <c>HRESULT GetHResult ([out] HRESULT* phrResult)</c>;</para></remarks>
    void GetHResult ([Out] out uint phrResult);
  }

  /// <summary><para><c>IMediaEventEx</c> interface.  </para><para>IMediaEventEx interface</para></summary>
  [Guid("56A868C0-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)4096)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
  public interface IMediaEventEx : IMediaEvent
  {
    /// <summary><para><c>SetNotifyWindow</c> method of <c>IMediaEventEx</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetNotifyWindow</c> method was the following:  <c>HRESULT SetNotifyWindow (long hwnd, long lMsg, long lInstanceData)</c>;</para></remarks>
    [DispId(1610809344)]
    void SetNotifyWindow (int hwnd, int lMsg, int lInstanceData);

    /// <summary><para><c>SetNotifyFlags</c> method of <c>IMediaEventEx</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>SetNotifyFlags</c> method was the following:  <c>HRESULT SetNotifyFlags (long lNoNotifyFlags)</c>;</para></remarks>
    [DispId(1610809345)]
    void SetNotifyFlags (int lNoNotifyFlags);

    /// <summary><para><c>GetNotifyFlags</c> method of <c>IMediaEventEx</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>GetNotifyFlags</c> method was the following:  <c>HRESULT GetNotifyFlags ([out] long* lplNoNotifyFlags)</c>;</para></remarks>
    [DispId(1610809346)]
    void GetNotifyFlags ([Out] out int lplNoNotifyFlags);
  }

  /// <summary><para><c>IQueueCommand</c> interface.  </para><para>IQueueCommand</para></summary>
  [Guid("56A868B7-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)0)]
  [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
  public interface IQueueCommand
  {
    /// <summary><para><c>InvokeAtStreamTime</c> method of <c>IQueueCommand</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>InvokeAtStreamTime</c> method was the following:  <c>HRESULT InvokeAtStreamTime ([out] IDeferredCommand** pCmd, double time, [in] stdole.GUID* iid, long dispidMethod, short wFlags, long cArgs, [in] VARIANT* pDispParams, [in, out] VARIANT* pvarResult, [out] short* puArgErr)</c>;</para></remarks>
    void InvokeAtStreamTime ([Out] out IDeferredCommand pCmd, double time, [In] ref stdole.GUID iid, int dispidMethod, short wFlags, int cArgs, [In] ref object pDispParams, [In, Out] ref object pvarResult, [Out] out short puArgErr);

    /// <summary><para><c>InvokeAtPresentationTime</c> method of <c>IQueueCommand</c> interface.</para></summary>
    /// <remarks><para>An original IDL definition of <c>InvokeAtPresentationTime</c> method was the following:  <c>HRESULT InvokeAtPresentationTime ([out] IDeferredCommand** pCmd, double time, [in] stdole.GUID* iid, long dispidMethod, short wFlags, long cArgs, [in] VARIANT* pDispParams, [in, out] VARIANT* pvarResult, [out] short* puArgErr)</c>;</para></remarks>
    void InvokeAtPresentationTime ([Out] out IDeferredCommand pCmd, double time, [In] ref stdole.GUID iid, int dispidMethod, short wFlags, int cArgs, [In] ref object pDispParams, [In, Out] ref object pvarResult, [Out] out short puArgErr);
  }

  /// <summary><para><c>FilgraphManager</c> interface.Filtergraph type info</para></summary>
  [Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770")]
  [ComImport]
  [CoClass(typeof(FilgraphManagerClass))]
  public interface FilgraphManager: IMediaEvent, IMediaPosition, IBasicAudio, IBasicVideo, IVideoWindow, IMediaControl
  {
  }

  /// <summary><para><c>FilgraphManagerClass</c> class.  </para><para>Filtergraph type info</para></summary>
  /// <remarks>The following sample shows how to use FilgraphManagerClass class.  You should simply create new class instance and cast it to FilgraphManager interface.  After this you can call interface methods and access its properties: <code>
  /// FilgraphManager A = (FilgraphManager) new FilgraphManagerClass();
  /// A.[method name]();  A.[property name] = [value]; [variable] = A.[property name];
  /// </code></remarks>
  [Guid("E436EBB3-524F-11CE-9F53-0020AF0BA770")]
  [ComImport]
  [TypeLibType((short)2)]
  [ClassInterface(ClassInterfaceType.None)]
  public class FilgraphManagerClass // : FilgraphManager  : IMediaEvent, IMediaPosition, IBasicAudio, IBasicVideo, IVideoWindow, IMediaControl, FilgraphManager
  {
  }
}
