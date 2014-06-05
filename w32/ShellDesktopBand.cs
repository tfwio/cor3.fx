using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace w32.shell
{
	public class ShellDesktopBand : Shell32
	{
		public enum DBIM : uint
		{
			DBIM_MINSIZE    = 0x0001, 
			DBIM_MAXSIZE    = 0x0002,
			DBIM_INTEGRAL   = 0x0004,
			DBIM_ACTUAL     = 0x0008,
			DBIM_TITLE      = 0x0010,
			DBIM_MODEFLAGS  = 0x0020,
			DBIM_BKCOLOR    = 0x0040,
		}
		public enum DBIMF : uint {
		/// This member is ignored if dwModeFlags does not contain DBIMF_VARIABLEHEIGHT. 
	         DBIMF_NORMAL,
	         DBIMF_VARIABLEHEIGHT,
	         DBIMF_DEBOSSED,
	         DBIMF_BKCOLOR
		}
	
		/// This member is ignored if dwModeFlags does not contain the DBIMF_BKCOLOR flag.
	    public DBIMF dwModeFlags;
	    [
			StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)
		]
		public struct DESKBANDINFO {
		    /// <summary>
		    /// Set of flags that determine which members of this structure are being requested. 
		    /// </summary>
		    /// <remarks>
		    /// This will be a combination of the following values:
		    ///     DBIM_MINSIZE    ptMinSize is being requested.
		    ///     DBIM_MAXSIZE    ptMaxSize is being requested.
		    ///     DBIM_INTEGRAL   ptIntegral is being requested.
		    ///     DBIM_ACTUAL     ptActual is being requested.
		    ///     DBIM_TITLE      wszTitle is being requested.
		    ///     DBIM_MODEFLAGS  dwModeFlags is being requested.
		    ///     DBIM_BKCOLOR    crBkgnd is being requested.
		    /// </remarks>
		    public DBIM dwMask;
		    /// <summary>
		    /// Point structure that receives the minimum size of the band object. 
		    /// The minimum width is placed in the x member and the minimum height 
		    /// is placed in the y member. 
		    /// </summary>
		    public Point ptMinSize;
		    /// <summary>
		    /// Point structure that receives the maximum size of the band object. 
		    /// The maximum height is placed in the y member and the x member is ignored. 
		    /// If there is no limit for the maximum height, (LONG)-1 should be used. 
		    /// </summary>
		    public Point ptMaxSize;
		    /// <summary>
		    /// Point structure that receives the sizing step value of the band object. 
		    /// The vertical step value is placed in the y member, and the x member is ignored. 
		    /// The step value determines in what increments the band will be resized. 
		    /// </summary>
		    /// <remarks>
		    /// This member is ignored if dwModeFlags does not contain DBIMF_VARIABLEHEIGHT. 
		    /// </remarks>
		    public Point ptIntegral;
		    /// <summary>
		    /// Point structure that receives the ideal size of the band object. 
		    /// The ideal width is placed in the x member and the ideal height is placed in the y member. 
		    /// The band container will attempt to use these values, but the band is not guaranteed to be this size.
		    /// </summary>
		    public Point ptActual;
		    /// <summary>
		    /// The title of the band.
		    /// </summary>
		    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
		    public String wszTitle;
		    /// <summary>
		    /// A value that receives a set of flags that define the mode of operation for the band object. 
		    /// </summary>
		    /// <remarks>
		    /// This must be one or a combination of the following values.
		    ///     DBIMF_NORMAL
		    ///     The band is normal in all respects. The other mode flags modify this flag.
		    ///     DBIMF_VARIABLEHEIGHT
		    ///     The height of the band object can be changed. The ptIntegral member defines the 
		    ///     step value by which the band object can be resized. 
		    ///     DBIMF_DEBOSSED
		    ///     The band object is displayed with a sunken appearance.
		    ///     DBIMF_BKCOLOR
		    ///     The band will be displayed with the background color specified in crBkgnd.
		    /// </remarks>
		    public DBIMF dwModeFlags;
		    /// <summary>
		    /// The background color of the band.
		    /// </summary>
		    /// <remarks>
		    /// This member is ignored if dwModeFlags does not contain the DBIMF_BKCOLOR flag. 
		    /// </remarks>
		    public Int32 crBkgnd; 
		}
		
		[
			ComImport,
			InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
			Guid ("EB0FE172-1A3A-11D0-89B3-00A0C90A90AC")
		]
		public interface IDeskBand
		{
		    // IOleWindow methods
		    [PreserveSig] int GetWindow (out IntPtr phwnd);
		    [PreserveSig] int ContextSensitiveHelp (
		        [In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
		
		    // IDockingWindow methods''
		    [PreserveSig] int ShowDW ([In, MarshalAs (UnmanagedType.Bool)] bool fShow);
		    [PreserveSig] int CloseDW([In] Int32 dwReserved); 
		    [PreserveSig] int ResizeBorderDW (ref System.Drawing.Rectangle rcBorder, 
		        [In, MarshalAs (UnmanagedType.IUnknown)] ref object punkToolbarSite, [MarshalAs (UnmanagedType.Bool)] bool fReserved);
		
		    // IDeskBand method''
		    [PreserveSig] int GetBandInfo ([In] Int32 dwBandID, [In] Int32 dwViewMode, /*[In, Out]*/ ref DESKBANDINFO pdbi);
		}
	
		[
			ComImport,
			InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
			Guid("79D16DE4-ABEE-4021-8D9D-9169B261D657")
		]
	    public interface IDeskBand2
	    {
	        // IOleWindow methods
	        [PreserveSig] int GetWindow(out IntPtr phwnd);
	        [PreserveSig] int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
	        // IDockingWindow methods
	        [PreserveSig] int ShowDW([In, MarshalAs(UnmanagedType.Bool)] bool fShow);
	        [PreserveSig] int CloseDW([In] Int32 dwReserved);
	        [PreserveSig] int ResizeBorderDW(ref System.Drawing.Rectangle rcBorder, [In, MarshalAs(UnmanagedType.IUnknown)] ref object punkToolbarSite, [MarshalAs(UnmanagedType.Bool)] bool fReserved);
	        // IDeskBand methods
	        [PreserveSig] int GetBandInfo([In] Int32 dwBandID, [In] Int32 dwViewMode, [In, Out] ref DESKBANDINFO pdbi);
	        // IDeskband2 methods
	        void CanRenderComposited(ref bool pfCanRenderComposited);
	        void SetCompositionState([MarshalAs(UnmanagedType.Bool)] bool fCompositionEnabled);
	        void GetCompositionState(ref bool pfCompositionEnabled);
	    }
	
	    public enum DeskBandInfoModes : uint
		{
		    /// <summary>The band is normal in all respects. The other mode flags modify this flag.</summary>
		    Normal = 0x0000,
		    /// <summary>TBD</summary>
		    Fixed = 0x0001,
		    /// <summary>a fixed background bitmap (if supported)</summary>
		    FixedBMP = 0x0004,
		    /// <summary>The height of the band object can be changed. </summary>
		    /// <remarks>The ptIntegral member defines the step value by which the band object can be resized. </remarks>
		    VariableHeight = 0x0008,
		    /// <summary>TBD</summary>
		    Undeleteable = 0x0010,
		    /// <summary>The band object is displayed with a sunken appearance.</summary>
		    Debossed = 0x0020,
		    /// <summary>The band will be displayed with the background color specified in crBkgnd. </summary>
		    BackColor = 0x0040,
		    /// <summary>Displays a chevron when the toolbar requires overflow.</summary>
		    UseChevron = 0x0080,
		    /// <summary>Display the toolbar in a new break</summary>
		    Break = 0x0100,
		    /// <summary>Adds the toolbar before the first toolbar in the frame</summary>
		    AddToFront = 0x0200,
		    /// <summary>Aligns the toolbar with the top of the frame</summary>
		    TopAlign = 0x0400
		} 
	
		[Flags] public enum DeskBandInfoViewMode : int
		{
		     DBIF_VIEWMODE_NORMAL		= 0x0000,
		     DBIF_VIEWMODE_VERTICAL		= 0x0001,
		     DBIF_VIEWMODE_FLOATING		= 0x0002,
		     DBIF_VIEWMODE_TRANSPARENT	= 0x0004
		}
	}
}
