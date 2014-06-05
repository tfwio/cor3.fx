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
//[assembly: AssemblyTitle("Apple.QTOLibrary")]
//[assembly: AssemblyDescription("Apple QuickTime Library 2.0 (translated by Aurigma COM to .NET)")]
//[assembly: AssemblyVersion("1.0")]
//[assembly: AssemblyConfiguration("Retail")]
//[assembly: AssemblyCompany("Aurigma Inc.")]
//[assembly: AssemblyProduct("QTOLibrary translated by Aurigma COM to .NET")]
//[assembly: AssemblyCopyright("Copyright (c) 2003 by Aurigma Inc.")]
//[assembly: AssemblyTrademark("Aurigma COM to .NET")]

// Type library name: QTOLibrary
// Type library description: Apple QuickTime Library 2.0
// Type library version: 1.0
// Type library language: Neutral
// Type library guid: {29866AED-1E14-417D-BA0F-1A2BE6F5A19E}
// Type library source file name: C:\Program Files\QuickTime\QTOLibrary.dll

namespace Apple.QTOLibrary
{
	[TypeLibType((short)0)]
	public enum CFObjectTypesEnum
	{
		CFObjectTypeInvalid = 0,

		CFObjectTypeBoolean = 1,

		CFObjectTypeString = 2,

		CFObjectTypeNumber = 3,

		CFObjectTypeArray = 4,

		CFObjectTypeDictionary = 5,

		CFObjectTypeData = 6
	}

	[TypeLibType((short)0)]
	public enum QTAnnotationsEnum
	{
		qtAnnotationAlbum = 1634493037,

		qtAnnotationArtist = 1634890867,

		qtAnnotationArtwork = 1634890871,

		qtAnnotationAuthor = 1635087464,

		qtAnnotationComments = 1668115828,

		qtAnnotationComposer = 1668246896,

		qtAnnotationCopyright = 1668313716,

		qtAnnotationDescription = 1684370275,

		qtAnnotationDirector = 1685352306,

		qtAnnotationFullName = 1851878757,

		qtAnnotationGenre = 1734700658,

		qtAnnotationInformation = 1768842863,

		qtAnnotationOriginalFormat = 1869769062,

		qtAnnotationOriginalSource = 1869769075,

		qtAnnotationPerformers = 1885696614,

		qtAnnotationProducer = 1886547812,

		qtAnnotationSoftware = 1936680564,

		qtAnnotationWriter = 2003989618
	}

	[TypeLibType((short)0)]
	public enum QTConnectionsSpeedsEnum
	{
		qtConnectionSpeed28_8Kbps = 2800,

		qtConnectionSpeed56Kbps = 5600,

		qtConnectionSpeed112Kbps = 11200,

		qtConnectionSpeed256Kbps = 25600,

		qtConnectionSpeed384Kbps = 38400,

		qtConnectionSpeed512Kbps = 51200,

		qtConnectionSpeed768Kbps = 76800,

		qtConnectionSpeed1Mbps = 100000,

		qtConnectionSpeed1_5Mbps = 150000,

		qtConnectionSpeedIntranet = 2147483647
	}

	[TypeLibType((short)0)]
	public enum QTErrorHandlingOptionsEnum
	{
		qtErrorHandlingSetErrorCodeOnly = 0,

		qtErrorHandlingFireErrorEvent = 1,

		qtErrorHandlingRaiseException = 2,

		qtErrorHandlingReturnErrorCode = 3
	}

	[TypeLibType((short)0)]
	public enum QTEventClassesEnum
	{
		qtEventClassAudio = 1635083369,

		qtEventClassSpatial = 1936745317,

		qtEventClassStateChange = 1937006964,

		qtEventClassTemporal = 1953066341,

		qtEventClassApplicationRequest = 1634758764,

		qtEventClassProgress = 1886545779
	}

	[TypeLibType((short)0)]
	public enum QTEventIDsEnum
	{
		qtEventAudioVolumeDidChange = 1668706156,

		qtEventAudioMuteDidChange = 1836414053,

		qtEventAudioBalanceDidChange = 1650551923,

		qtEventSizeDidChange = 1936292453,

		qtEventRateWillChange = 1918989413,

		qtEventChapterListDidChange = 1667785072,

		qtEventCurrentChapterDidChange = 1668183405,

		qtEventLoadStateDidChange = 1819238756,

		qtEventMovieDidEnd = 1835363940,

		qtEventMovieSelectionDidChange = 1936024424,

		qtEventMovieWasEdited = 1701079412,

		qtEventTimeWillChange = 1668573549,

		qtEventEnterFullScreenRequest = 1718839151,

		qtEventExitFullScreenRequest = 1718838648,

		qtEventCloseWindowRequest = 1668050803,

		qtEventLinkToURLRequest = 1819636332,

		qtEventShowStatusStringRequest = 1937011827,

		qtEventShowMessageStringRequest = 1936552807,

		qtEventGetNextURLRequest = 1852143732,

		qtEventExportProgress = 1702391924
	}

	[TypeLibType((short)0)]
	public enum QTEventObjectParametersEnum
	{
		qtEventParamAudioVolume = 1987013741,

		qtEventParamAudioMute = 1836414053,

		qtEventParamAudioBalance = 1650551923,

		qtEventParamMovieTime = 1953066341,

		qtEventParamMovieRate = 1918989413,

		qtEventParamStatusString = 1937012083,

		qtEventParamStatusCode = 1935896420,

		qtEventParamMessageString = 1836282994,

		qtEventParamURL = 1970433119,

		qtEventParamLoadState = 1937006964,

		qtEventParamSelectionStart = 1936026739,

		qtEventParamSelectionDuration = 1936026724,

		qtEventParamChapterIndex = 1853189474,

		qtEventParamAmount = 1634561652
	}

	[TypeLibType((short)0)]
	public enum QTFindTextFlagsEnum
	{
		qtFindTextFlagCaseSensitive = 2,

		qtFindTextFlagReverseSearch = 4,

		qtFindTextFlagWrapAround = 8,

		qtFindTextDontGoToFoundTime = 65536,

		qtFindTextDontHiliteFoundText = 131072,

		qtFindTextOneTrackOnly = 262144,

		qtFindTextEnabledTracksOnly = 524288,

		qtFindTextDefaultFlags = 0
	}

	[TypeLibType((short)0)]
	public enum QTMatrixTypes
	{
		qtIdentityMatrixType = 0,

		qtTranslateMatrixType = 1,

		qtScaleMatrixType = 2,

		qtScaleTranslateMatrixType = 3,

		qtLinearMatrixType = 4,

		qtLinearTranslateMatrixType = 5,

		qtPerspectiveMatrixType = 6
	}

	[TypeLibType((short)0)]
	public enum QTMovieCharacteristicsEnum
	{
		qtMovieCharacteristicIsVRMovie = 1769174642,

		qtMovieCharacteristicIsFastStart = 1718842431,

		qtMovieCharacteristicIsStreaming = 1937011263,

		qtMovieCharacteristicIsLiveStream = 1819505727,

		qtMovieCharacteristicIsStoredStream = 1936946239,

		qtMovieCharacteristicIsLocal = 1819239231,

		qtMovieCharacteristicHasAlternateLanguages = 1818324543,

		qtMovieCharacteristicHasChapters = 1667788863,

		qtMovieCharacteristicHasVideo = 1702454643,

		qtMovieCharacteristicIsInteractive = 1064595321,

		qtMovieCharacteristicHasAudio = 1700885107,

		qtMovieCharacteristicHasDuration = 1685418559,

		qtMovieCharacteristicHasText = 1954051135,

		qtMovieCharacteristicCanSendVideo = 1937138751,

		qtMovieCharacteristicNonLinear = 1852598591,

		qtMovieCharacteristicCanStep = 1937010751,

		qtMovieCharacteristicHasSkinData = 1936420415,

		qtMovieCharacteristicProvidesKeyFocus = 1801812287,

		qtMovieCharacteristicHasVideoFrameRate = 1986425407,

		qtMovieCharacteristicHasMPEG = 1835495487
	}

	[TypeLibType((short)0)]
	public enum QTMovieControllerTypesEnum
	{
		qtMovieControllerTypeStandard = 7566436,

		qtMovieControllerTypeQTVR = 1903457906,

		qtMovieControllerTypeQTVR1_0Panorama = 1398042734,

		qtMovieControllerTypeQTVR1_0Object = 1937010273,

		qtMovieControllerTypeNone = 1852796517,

		qtMovieControllerTypeDefault = 0
	}

	[TypeLibType((short)0)]
	public enum QTObjectClassesEnum
	{
		qtObjectClassQuickTime = 1903454573,

		qtObjectClassMovie = 1836019574,

		qtObjectClassTrack = 1953653099,

		qtObjectClassStream = 1937011309,

		qtObjectClassHotSpot = 1752395892,

		qtObjectClassNode = 1852793957,

		qtObjectClassExporter = 1702391924,

		qtObjectClassSettings = 1886545254
	}

	[TypeLibType((short)0)]
	public enum QTTrackCharacteristicsEnum
	{
		qtTrackCharacteristicHasVideo = 1702454643,

		qtTrackCharacteristicIsInteractive = 1064595321,

		qtTrackCharacteristicIsStreaming = 1937011263,

		qtTrackCharacteristicHasAudio = 1700885107,

		qtTrackCharacteristicHasDuration = 1685418559,

		qtTrackCharacteristicHasText = 1954051135,

		qtTrackCharacteristicCanSendVideo = 1937138751,

		qtTrackCharacteristicNonLinear = 1852598591,

		qtTrackCharacteristicCanStep = 1937010751,

		qtTrackCharacteristicHasSkinData = 1936420415,

		qtTrackCharacteristicProvidesKeyFocus = 1801812287,

		qtTrackCharacteristicHasVideoFrameRate = 1986425407,

		qtTrackCharacteristicHasMPEG = 1835495487
	}

	[TypeLibType((short)0)]
	public enum QTTransferModesEnum
	{
		qtTransferModeNone = 0,

		qtTransferModeBlend = 32,

		qtTransferModeDitherCopy = 64,

		qtTransferModeStraightAlpha = 256,

		qtTransferModePreWhiteAlpha = 257,

		qtTransferModePreBlackAlpha = 258,

		qtTransferModeComposition = 259,

		qtTransferModeStraightAlphaBlend = 260,

		qtTransferModePreMulColorAlpha = 261
	}

	[Guid("41CB181D-5877-4D2A-81F3-85CAB5306DB9")]
	[TypeLibType((short)0)]
	[StructLayout(LayoutKind.Sequential)]
	public struct QTEventListener // RECORD
	{
		public int EventClass;

		public int EventID;

		public int Flags;

		public int Context;
	}

	[Guid("334BEC9E-5090-429F-B976-A3762FC8A27A")]
	[TypeLibType((short)0)]
	[StructLayout(LayoutKind.Sequential)]
	public struct QTPOINT // RECORD
	{
		public int x;

		public int y;
	}

	[Guid("AA2F3A0A-92D7-49CE-AFD6-60F74EE92D36")]
	[TypeLibType((short)0)]
	[StructLayout(LayoutKind.Sequential)]
	public struct QTRECT // RECORD
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	[Guid("706BC692-B613-4B6E-97E7-2C2104C1D06E")]
	[ComImport]
	[TypeLibType((short)4096)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface _IQTObjectEvents
	{
		[DispId(1)]
		void QTEvent (int EventClass, int EventID, int Flags, IQTEventObject EventObject, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

		[DispId(2)]
		void Error (int ErrorCode);
	}

	public delegate void _IQTObjectEvents_QTEventEventHandler (int EventClass, int EventID, int Flags, IQTEventObject EventObject, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

	public delegate void _IQTObjectEvents_ErrorEventHandler (int ErrorCode);

	[ComEventInterface(typeof(_IQTObjectEvents),typeof(_IQTObjectEvents_EventProvider))]
	[ComVisible(false)]
	public interface _IQTObjectEvents_Event
	{
		event _IQTObjectEvents_QTEventEventHandler QTEvent;

		event _IQTObjectEvents_ErrorEventHandler Error;
	}

	[ClassInterface(ClassInterfaceType.None)]
	internal class _IQTObjectEvents_SinkHelper: _IQTObjectEvents
	{
		public int Cookie = 0;

		public event _IQTObjectEvents_QTEventEventHandler QTEventDelegate = null;
		public void Set_QTEventDelegate(_IQTObjectEvents_QTEventEventHandler deleg)
		{
			QTEventDelegate = deleg;
		}
		public bool Is_QTEventDelegate(_IQTObjectEvents_QTEventEventHandler deleg)
		{
			return (QTEventDelegate == deleg);
		}
		public void Clear_QTEventDelegate()
		{
			QTEventDelegate = null;
		}
		void _IQTObjectEvents.QTEvent (int EventClass, int EventID, int Flags, IQTEventObject EventObject, ref bool Cancel)
		{
			if (QTEventDelegate!=null)
				QTEventDelegate(EventClass, EventID, Flags, EventObject, ref Cancel);
		}

		public event _IQTObjectEvents_ErrorEventHandler ErrorDelegate = null;
		public void Set_ErrorDelegate(_IQTObjectEvents_ErrorEventHandler deleg)
		{
			ErrorDelegate = deleg;
		}
		public bool Is_ErrorDelegate(_IQTObjectEvents_ErrorEventHandler deleg)
		{
			return (ErrorDelegate == deleg);
		}
		public void Clear_ErrorDelegate()
		{
			ErrorDelegate = null;
		}
		void _IQTObjectEvents.Error (int ErrorCode)
		{
			if (ErrorDelegate!=null)
				ErrorDelegate(ErrorCode);
		}
	}

	internal class _IQTObjectEvents_EventProvider: IDisposable, _IQTObjectEvents_Event
	{
		UCOMIConnectionPointContainer ConnectionPointContainer;
		UCOMIConnectionPoint ConnectionPoint;
		_IQTObjectEvents_SinkHelper EventSinkHelper;
		int ConnectionCount;

		// Constructor: remember ConnectionPointContainer
		_IQTObjectEvents_EventProvider(object CPContainer) : base()
		{
			ConnectionPointContainer = (UCOMIConnectionPointContainer)CPContainer;
		}

		// Force disconnection from ActiveX event source
		~_IQTObjectEvents_EventProvider()
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
				Guid g = new Guid("706BC692-B613-4B6E-97E7-2C2104C1D06E");
				ConnectionPointContainer.FindConnectionPoint(ref g, out ConnectionPoint);
				EventSinkHelper = new _IQTObjectEvents_SinkHelper();
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

		event _IQTObjectEvents_QTEventEventHandler _IQTObjectEvents_Event.QTEvent
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

		event _IQTObjectEvents_ErrorEventHandler _IQTObjectEvents_Event.Error
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
	}

	[Guid("47ECAC10-2F4B-4F79-8702-ECE38A887E8A")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Value")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ICFObject
	{
		[DispId(659460)]
		void AddItem (object newItem, object KeyOrIndex);

		[DispId(659461)]
		void RemoveItem (object KeyOrIndex);

		[DispId(659462)]
		void RemoveAllItems ();

		ICFObjects ChildItems
		{
			[DispId(659457)]
			get;
		}

		object Key
		{
			[DispId(659459)]
			get;
		}

		CFObjectTypesEnum Type
		{
			[DispId(659458)]
			get;
			[DispId(659458)]
			set;
		}

		object Value
		{
			[DispId(0)]
			get;
			[DispId(0)]
			set;
		}

		string XML
		{
			[DispId(659463)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(659463)]
			set;
		}
	}

	[Guid("A3732EA4-F490-4F30-8C7B-37750215D11F")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ICFObjects
	{
		[DispId(0)]
		ICFObject Item (object itemIndex) /* property get method */;

		[DispId(659464)]
		ICFObject ItemByKey (object itemKey) /* property get method */;

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("2A7BCC60-AE86-4707-81A9-CD2227BBD97A")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTChapter
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		int Duration
		{
			[DispId(4102)]
			get;
		}

		int EndTime
		{
			[DispId(4103)]
			get;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		string Name
		{
			[DispId(4104)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Number
		{
			[DispId(4105)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		int StartTime
		{
			[DispId(4106)]
			get;
		}
	}

	[Guid("F0B2D3E8-7B9C-407A-9F82-C56E3F9533D0")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTChapters: System.Collections.IEnumerable
	{
		[DispId(0)]
		IQTChapter Item (object Item) /* property get method */;

		object _NewEnum
		{
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
		}

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("70E6D439-F975-4969-83C5-855534600B3A")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTError
	{
		[DispId(786441)]
		void Clear ();

		[DispId(786433)]
		void _SetErrorInfo (int ErrorCode, int SourceClass, int SourceReferenceType, [MarshalAs(UnmanagedType.BStr)] string SourceReference);

		string Description
		{
			[DispId(786440)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int ErrorCode
		{
			[DispId(786434)]
			get;
		}

		int QTErrorCode
		{
			[DispId(786439)]
			get;
		}

		int SourceClass
		{
			[DispId(786435)]
			get;
		}

		string SourceReference
		{
			[DispId(786437)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int SourceReferenceType
		{
			[DispId(786436)]
			get;
		}
	}

	[Guid("D464A8C3-5BC8-48FB-B1F6-7EA0A32E9BB8")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTEventListeners
	{
		[DispId(0)]
		QTEventListener Item (int Index) /* property get method */;

		[DispId(659457)]
		void Add (QTEventClassesEnum EventClass, QTEventIDsEnum EventID, object Flags, object Context);

		[DispId(659458)]
		void Remove (QTEventClassesEnum EventClass, QTEventIDsEnum EventID);

		[DispId(659459)]
		void RemoveAll ();

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("F10FB760-2AFB-48B4-AD2E-800865A23232")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTEventObject
	{
		[DispId(659464)]
		object GetParam (QTEventObjectParametersEnum ParameterID);

		[DispId(659465)]
		ICFObject GetParams ();

		bool CanBeCanceled
		{
			[DispId(659468)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		int Context
		{
			[DispId(659466)]
			get;
		}

		int EventClass
		{
			[DispId(659457)]
			get;
		}

		int EventID
		{
			[DispId(659458)]
			get;
		}

		bool HasBeenCanceled
		{
			[DispId(659469)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		int ParamCount
		{
			[DispId(659467)]
			get;
		}
	}

	[Guid("0CCD18D4-4DE3-4CB6-9DB7-4232A8A066D3")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTExporter
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		[DispId(659458)]
		void SetDataSource (IQTObject pDataSource);

		[DispId(8193)]
		void ShowSettingsDialog ();

		[DispId(8194)]
		void ShowExportDialog ();

		[DispId(8195)]
		void BeginExport ();

		[DispId(8196)]
		void CancelExport ();

		string DestinationFileName
		{
			[DispId(4110)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(4110)]
			set;
		}

		int EndTime
		{
			[DispId(4103)]
			get;
			[DispId(4103)]
			set;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		ICFObject Settings
		{
			[DispId(4106)]
			get;
			[DispId(4106)]
			set;
		}

		bool ShowProgressDialog
		{
			[DispId(4111)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(4111)]
			set;
		}

		int StartTime
		{
			[DispId(4107)]
			get;
			[DispId(4107)]
			set;
		}

		int Type
		{
			[DispId(4108)]
			get;
			[DispId(4108)]
			set;
		}

		string TypeName
		{
			[DispId(4104)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(4104)]
			set;
		}
	}

	[Guid("88B370F8-683E-4403-855E-0783E2A7CE34")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTExporters: System.Collections.IEnumerable
	{
		[DispId(0)]
		IQTExporter Item (object Item) /* property get method */;

		[DispId(659458)]
		void Remove (object Item);

		[DispId(659457)]
		void Add ();

		object _NewEnum
		{
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
		}

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("F6EE34D2-FDA8-40EF-BF7A-C28E04D2A6F1")]
	[ComImport]
	[TypeLibType((short)4288)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTFrequencyMeter
	{
		int BandCount
		{
			[DispId(659460)]
			get;
			[DispId(659460)]
			set;
		}

		object BandLevels
		{
			[DispId(659461)]
			get;
		}

		int ChannelCount
		{
			[DispId(659459)]
			get;
		}
	}

	[Guid("7F9B97B0-D0D0-4036-815B-4E2A874CCD4B")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTHotspot
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		string Comments
		{
			[DispId(4102)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		bool Enabled
		{
			[DispId(4103)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(4103)]
			set;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		string LinkDestination
		{
			[DispId(4105)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		string Name
		{
			[DispId(4106)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Number
		{
			[DispId(4107)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		int Type
		{
			[DispId(4108)]
			get;
		}

		int UniqueID
		{
			[DispId(4104)]
			get;
		}
	}

	[Guid("C210E589-6B11-41F3-BFD6-79FDF3A206D6")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTHotspots: System.Collections.IEnumerable
	{
		[DispId(0)]
		IQTHotspot Item (object Item) /* property get method */;

		object _NewEnum
		{
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
		}

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("516DB716-A2D9-4E0C-B724-3B70A2724DE9")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTMatrix
	{
		[DispId(659465)]
		float Element (short row, short col) /* property get method */;

		[DispId(659465)]
		void Element (short row, short col, float value) /* property put method */;

		[DispId(659457)]
		void SetIdentity ();

		[DispId(659458)]
		void Translate (float OffsetX, float OffsetY);

		[DispId(659459)]
		void Rotate (float Degrees, float AboutX, float AboutY);

		[DispId(659460)]
		void SetScale (float ScaleX, float ScaleY, float AboutX, float AboutY);

		[DispId(659461)]
		void Skew (float SkewX, float SkewY, float AboutX, float AboutY);

		[DispId(659462)]
		void RectToRect ([In] ref QTRECT SourceRect, [In] ref QTRECT DestRect);

		[DispId(659463)]
		object GetElements ();

		[DispId(659464)]
		void SetElements (object pArray);

		QTMatrixTypes Type
		{
			[DispId(721156)]
			get;
		}
	}

	[Guid("4ADDED78-C61F-4530-86BE-EE3E2E28B0F3")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTMovie
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		[DispId(1004)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string Annotation (int annotationID) /* property get method */;

		[DispId(1004)]
		void Annotation (int annotationID, [MarshalAs(UnmanagedType.BStr)] string value) /* property put method */;

		[DispId(1038)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool HasCharacteristic (QTMovieCharacteristicsEnum characteristicID) /* property get method */;

		[DispId(10001)]
		void Add ();

		[DispId(10002)]
		void AddScaled ();

		[DispId(10003)]
		void Copy ();

		[DispId(10004)]
		void CopyFrame (object Time);

		[DispId(10005)]
		void Cut ();

		[DispId(10007)]
		void DeleteSelection (object StartTime, object EndTime);

		[DispId(10008)]
		void Draw ();

		[DispId(10010)]
		void SaveSelfContained ([MarshalAs(UnmanagedType.BStr)] string filePath, object compressMovieResource);

		[DispId(10011)]
		void GoToPreviousNode ();

		[DispId(10012)]
		void GoToChapter (object chapterIndex);

		[DispId(10013)]
		void GotoEnd ();

		[DispId(10014)]
		void GoToNextSelectionPoint ();

		[DispId(10015)]
		void GoToPreviousSelectionPoint ();

		[DispId(10016)]
		void Idle ();

		[DispId(10017)]
		void InsertSegment (IQTMovie srcMovie, object srcStartTime, object srcDuration, object insertionTime);

		[DispId(10018)]
		void InsertEmptySegment (int StartTime, int Duration);

		[DispId(10019)]
		void NavigateTo (object destPanAngle, object destTiltAngle, object destFieldOfView, object coordinatesAreRelative, object withTransition, object transitionDirection, object transitionSpeed);

		[DispId(10020)]
		void Nudge (object direction);

		[DispId(10021)]
		void Paste ();

		[DispId(10022)]
		void Pause ();

		[DispId(10023)]
		void Play (object movieRate);

		[DispId(10024)]
		void Preroll ();

		[DispId(10025)]
		void RemoveAnnotation (int id);

		[DispId(10026)]
		void ReplaceSelection ();

		[DispId(10027)]
		void Reverse ();

		[DispId(10028)]
		void Rewind ();

		[DispId(10029)]
		void Rotate (float val);

		[DispId(10030)]
		void Save (object filePath, object fileOffset);

		[DispId(10031)]
		void ScaleSegment (int newSegmentDuration, object oldSegmentStart, object oldSegmentDuration);

		[DispId(10032)]
		void SelectAll ();

		[DispId(10033)]
		void SetSelection (object inStartSelectionTime, object inSelectionDurationTime);

		[DispId(10034)]
		void ShowPoster ();

		[DispId(10035)]
		void Step (object stepCount);

		[DispId(10036)]
		void StepFwd ();

		[DispId(10037)]
		void StepRev ();

		[DispId(10038)]
		void Stop ();

		[DispId(10039)]
		void TrimToSelection ();

		[DispId(10040)]
		void Undo ();

		[DispId(10041)]
		void UpdateMovie ();

		[DispId(10042)]
		void Zoom (int direction);

		[DispId(659736)]
		void QTFindText ([MarshalAs(UnmanagedType.BStr)] string SearchString, object StartTime, object StartOffset, object SearchFlags);

		[DispId(659458)]
		void Connect (int hMovie, int inMovieResourceID);

		[DispId(659459)]
		void Disconnect ();

		bool Active
		{
			[DispId(1001)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1001)]
			set;
		}

		bool AllowDynamicResize
		{
			[DispId(1002)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1002)]
			set;
		}

		bool AllowEditing
		{
			[DispId(1003)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1003)]
			set;
		}

		ICFObject Annotations
		{
			[DispId(1005)]
			get;
		}

		float AudioBalance
		{
			[DispId(1006)]
			get;
			[DispId(1006)]
			set;
		}

		float AudioBass
		{
			[DispId(1007)]
			get;
			[DispId(1007)]
			set;
		}

		bool AudioMute
		{
			[DispId(1008)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1008)]
			set;
		}

		float AudioTreble
		{
			[DispId(1009)]
			get;
			[DispId(1009)]
			set;
		}

		float AudioVolume
		{
			[DispId(1010)]
			get;
			[DispId(1010)]
			set;
		}

		bool AutoClose
		{
			[DispId(1011)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1011)]
			set;
		}

		bool AutoPlay
		{
			[DispId(1012)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1012)]
			set;
		}

		bool AutoQuit
		{
			[DispId(1013)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1013)]
			set;
		}

		int bottom
		{
			[DispId(1014)]
			get;
			[DispId(1014)]
			set;
		}

		bool CanClear
		{
			[DispId(1016)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1016)]
			set;
		}

		bool CanCopy
		{
			[DispId(1017)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1017)]
			set;
		}

		bool CanCut
		{
			[DispId(1018)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1018)]
			set;
		}

		bool CanExport
		{
			[DispId(1019)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1019)]
			set;
		}

		bool CanFlatten
		{
			[DispId(1020)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1020)]
			set;
		}

		bool CanModify
		{
			[DispId(1021)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1021)]
			set;
		}

		bool CanPaste
		{
			[DispId(1022)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1022)]
			set;
		}

		bool CanSave
		{
			[DispId(1023)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1023)]
			set;
		}

		bool CanUndo
		{
			[DispId(1024)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1024)]
			set;
		}

		bool CanUpdateMovieFile
		{
			[DispId(1025)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		IQTChapters Chapters
		{
			[DispId(659731)]
			get;
		}

		string Copyright
		{
			[DispId(1026)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1026)]
			set;
		}

		int CurrentChapterIndex
		{
			[DispId(1027)]
			get;
			[DispId(1027)]
			set;
		}

		int CurrentNodeID
		{
			[DispId(1028)]
			get;
			[DispId(1028)]
			set;
		}

		int DataRate
		{
			[DispId(1029)]
			get;
		}

		int DefaultNodeID
		{
			[DispId(1030)]
			get;
		}

		QTPOINT Dimensions
		{
			[DispId(1031)]
			get;
			[DispId(1031)]
			set;
		}

		int Duration
		{
			[DispId(1032)]
			get;
		}

		float DynamicFrameRate
		{
			[DispId(1033)]
			get;
		}

		int EndTime
		{
			[DispId(1034)]
			get;
		}

		IQTError Error
		{
			[DispId(721168)]
			get;
		}

		int ErrorHandling
		{
			[DispId(721169)]
			get;
			[DispId(721169)]
			set;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		float FieldOfView
		{
			[DispId(1035)]
			get;
			[DispId(1035)]
			set;
		}

		float FieldOfViewMax
		{
			[DispId(1036)]
			get;
			[DispId(1036)]
			set;
		}

		float FieldOfViewMin
		{
			[DispId(1037)]
			get;
			[DispId(1037)]
			set;
		}

		QTFindTextFlagsEnum FindTextFlags
		{
			[DispId(659734)]
			get;
			[DispId(659734)]
			set;
		}

		int FindTextOffset
		{
			[DispId(659733)]
			get;
			[DispId(659733)]
			set;
		}

		int FindTextTime
		{
			[DispId(659732)]
			get;
			[DispId(659732)]
			set;
		}

		int FindTextTrackIndex
		{
			[DispId(659735)]
			get;
			[DispId(659735)]
			set;
		}

		IQTFrequencyMeter FrequencyMeter
		{
			[DispId(659742)]
			get;
		}

		bool HasChanged
		{
			[DispId(1039)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1039)]
			set;
		}

		int Height
		{
			[DispId(1040)]
			get;
			[DispId(1040)]
			set;
		}

		bool HotspotsVisible
		{
			[DispId(1041)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1041)]
			set;
		}

		string HREF
		{
			[DispId(1042)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1042)]
			set;
		}

		bool IsVRMovie
		{
			[DispId(1044)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		bool KeysEnabled
		{
			[DispId(1045)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1045)]
			set;
		}

		int Language
		{
			[DispId(1046)]
			get;
			[DispId(1046)]
			set;
		}

		int left
		{
			[DispId(1047)]
			get;
			[DispId(1047)]
			set;
		}

		int LoadState
		{
			[DispId(1048)]
			get;
		}

		bool Loop
		{
			[DispId(1049)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1049)]
			set;
		}

		bool LoopIsPalindrome
		{
			[DispId(1050)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1050)]
			set;
		}

		IQTMatrix Matrix
		{
			[DispId(1051)]
			get;
			[DispId(1051)]
			set;
		}

		int MaxTimeLoaded
		{
			[DispId(1052)]
			get;
		}

		string MIMEType
		{
			[DispId(1053)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int MovieControllerType
		{
			[DispId(1054)]
			get;
			[DispId(1054)]
			set;
		}

		int MovieHandle
		{
			[DispId(659715)]
			get;
		}

		string Name
		{
			[DispId(1055)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1055)]
			set;
		}

		QTRECT NaturalRect
		{
			[DispId(1056)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		float PanAngle
		{
			[DispId(1057)]
			get;
			[DispId(1057)]
			set;
		}

		float PanAngleMax
		{
			[DispId(1058)]
			get;
			[DispId(1058)]
			set;
		}

		float PanAngleMin
		{
			[DispId(1059)]
			get;
			[DispId(1059)]
			set;
		}

		int PanTiltSpeed
		{
			[DispId(1060)]
			get;
			[DispId(1060)]
			set;
		}

		bool PlaySelectionOnly
		{
			[DispId(1061)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1061)]
			set;
		}

		int PosterTime
		{
			[DispId(1062)]
			get;
			[DispId(1062)]
			set;
		}

		ICFObject PotentialExporters
		{
			[DispId(1063)]
			get;
		}

		float PreferredAudioVolume
		{
			[DispId(1065)]
			get;
			[DispId(1065)]
			set;
		}

		float PreferredRate
		{
			[DispId(1064)]
			get;
			[DispId(1064)]
			set;
		}

		float Rate
		{
			[DispId(1066)]
			get;
			[DispId(1066)]
			set;
		}

		QTRECT Rectangle
		{
			[DispId(1067)]
			get;
			[DispId(1067)]
			set;
		}

		int right
		{
			[DispId(1068)]
			get;
			[DispId(1068)]
			set;
		}

		bool SeeAllFrames
		{
			[DispId(1069)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1069)]
			set;
		}

		int SelectionDuration
		{
			[DispId(1070)]
			get;
			[DispId(1070)]
			set;
		}

		int SelectionEnd
		{
			[DispId(1071)]
			get;
			[DispId(1071)]
			set;
		}

		int SelectionStart
		{
			[DispId(1072)]
			get;
			[DispId(1072)]
			set;
		}

		int Size
		{
			[DispId(1073)]
			get;
		}

		int StartTime
		{
			[DispId(1074)]
			get;
		}

		float StaticFrameRate
		{
			[DispId(1075)]
			get;
		}

		string StreamingStatus
		{
			[DispId(1076)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int StreamingStatusCode
		{
			[DispId(1077)]
			get;
		}

		float TiltAngle
		{
			[DispId(1078)]
			get;
			[DispId(1078)]
			set;
		}

		float TiltAngleMax
		{
			[DispId(1079)]
			get;
			[DispId(1079)]
			set;
		}

		float TiltAngleMin
		{
			[DispId(1080)]
			get;
			[DispId(1080)]
			set;
		}

		int Time
		{
			[DispId(1081)]
			get;
			[DispId(1081)]
			set;
		}

		int TimeScale
		{
			[DispId(1082)]
			get;
			[DispId(1082)]
			set;
		}

		int top
		{
			[DispId(1083)]
			get;
			[DispId(1083)]
			set;
		}

		IQTTracks Tracks
		{
			[DispId(659457)]
			get;
		}

		string URL
		{
			[DispId(1085)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		IQTVRNodes VRNodes
		{
			[DispId(659724)]
			get;
		}

		int Width
		{
			[DispId(1086)]
			get;
			[DispId(1086)]
			set;
		}

		int ZoomRate
		{
			[DispId(1087)]
			get;
			[DispId(1087)]
			set;
		}
	}

	[Guid("508F76F6-A356-4779-A592-89AA398670BA")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTObject
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}
	}

	[Guid("6D307784-BE9F-46D9-A8DA-21EFD156F3CA")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTQuickTime
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		[DispId(4103)]
		int ComponentVersion (int Type, int SubType, int Manufacturer) /* property get method */;

		IQTError Error
		{
			[DispId(721168)]
			get;
		}

		int ErrorHandling
		{
			[DispId(721169)]
			get;
			[DispId(721169)]
			set;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		IQTExporters Exporters
		{
			[DispId(659460)]
			get;
		}

		bool IsRegistered
		{
			[DispId(4104)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		string ObjectsLibraryVersion
		{
			[DispId(659458)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		ICFObject PotentialExporters
		{
			[DispId(4107)]
			get;
		}

		IQTSettings Settings
		{
			[DispId(659459)]
			get;
		}

		int Version
		{
			[DispId(4105)]
			get;
		}

		string VersionAsString
		{
			[DispId(659461)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[Guid("7C1139DF-A316-4C15-AD77-E32381887D08")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTSettings
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		[DispId(659475)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string MediaKey ([MarshalAs(UnmanagedType.BStr)] string keyName) /* property get method */;

		[DispId(659475)]
		void MediaKey ([MarshalAs(UnmanagedType.BStr)] string keyName, [MarshalAs(UnmanagedType.BStr)] string value) /* property put method */;

		[DispId(659477)]
		void DeleteMediaKey ([MarshalAs(UnmanagedType.BStr)] string keyName);

		[DispId(659476)]
		void EmptyDownloadCache (object inFlags);

		bool AutomaticConnectionSpeedEnabled
		{
			[DispId(659458)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(659458)]
			set;
		}

		bool BrowserPluginAutoplay
		{
			[DispId(659467)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(659467)]
			set;
		}

		bool BrowserPluginKioskMode
		{
			[DispId(659468)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(659468)]
			set;
		}

		QTConnectionsSpeedsEnum ConnectionSpeed
		{
			[DispId(659457)]
			get;
			[DispId(659457)]
			set;
		}

		int DownloadCacheSize
		{
			[DispId(659459)]
			get;
			[DispId(659459)]
			set;
		}

		QTConnectionsSpeedsEnum DownloadSpeedOverride
		{
			[DispId(659464)]
			get;
			[DispId(659464)]
			set;
		}

		bool DownloadSpeedOverrideEnabled
		{
			[DispId(659463)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(659463)]
			set;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		int InstantOnDelay
		{
			[DispId(659465)]
			get;
			[DispId(659465)]
			set;
		}

		bool InstantOnEnabled
		{
			[DispId(659466)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(659466)]
			set;
		}

		int Language
		{
			[DispId(659473)]
			get;
		}

		string Locale
		{
			[DispId(659474)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		bool NotifyUserIfFileAssociationsChange
		{
			[DispId(659461)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(659461)]
			set;
		}

		bool NotifyUserIfMIMEAssociationsChange
		{
			[DispId(659462)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(659462)]
			set;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}
	}

	[Guid("BEE6A65B-92EB-4F66-8793-749905A024F4")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTStream
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		int AudioChannelCount
		{
			[DispId(2001)]
			get;
		}

		string AudioChannelLayoutString
		{
			[DispId(2002)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int AudioConstBytesPerPacket
		{
			[DispId(2003)]
			get;
		}

		int AudioConstFramesPerPacket
		{
			[DispId(2004)]
			get;
		}

		string AudioFormatSummaryString
		{
			[DispId(2005)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		double AudioSampleRate
		{
			[DispId(2006)]
			get;
		}

		string AudioSampleRateString
		{
			[DispId(2007)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int AudioSampleSize
		{
			[DispId(2008)]
			get;
		}

		string AudioSampleSizeString
		{
			[DispId(2009)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		float AverageFrameRate
		{
			[DispId(1001)]
			get;
		}

		int ChunksPlayed
		{
			[DispId(1002)]
			get;
		}

		int ChunksReceived
		{
			[DispId(1003)]
			get;
		}

		int ChunksSkipped
		{
			[DispId(1004)]
			get;
		}

		float ChunksSkippedPercent
		{
			[DispId(1005)]
			get;
		}

		int Depth
		{
			[DispId(3001)]
			get;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		float ExpectedFrameRate
		{
			[DispId(1006)]
			get;
		}

		string Format
		{
			[DispId(1007)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		string Kind
		{
			[DispId(1008)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Number
		{
			[DispId(1009)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		int QueueDuration
		{
			[DispId(1010)]
			get;
		}

		int QueueSize
		{
			[DispId(1011)]
			get;
		}

		ICFObject Statistics
		{
			[DispId(1012)]
			get;
		}

		int Type
		{
			[DispId(1014)]
			get;
		}
	}

	[Guid("D75A4EFE-6E14-4338-8800-2E7A91C07BE4")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTStreams: System.Collections.IEnumerable
	{
		[DispId(0)]
		IQTStream Item (object Item) /* property get method */;

		object _NewEnum
		{
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
		}

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("7B63E33C-76F2-4891-A920-FBF4D91EE33F")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTTrack
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		[DispId(1001)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string Annotation (int annotationID) /* property get method */;

		[DispId(1001)]
		void Annotation (int annotationID, [MarshalAs(UnmanagedType.BStr)] string value) /* property put method */;

		[DispId(1015)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool HasCharacteristic (QTTrackCharacteristicsEnum characteristicID) /* property get method */;

		[DispId(1035)]
		void RemoveAnnotation (int id);

		ICFObject Annotations
		{
			[DispId(1002)]
			get;
		}

		float AudioBass
		{
			[DispId(3001)]
			get;
			[DispId(3001)]
			set;
		}

		int AudioChannelCount
		{
			[DispId(3002)]
			get;
		}

		string AudioChannelLayoutString
		{
			[DispId(3003)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int AudioConstBytesPerPacket
		{
			[DispId(3004)]
			get;
		}

		int AudioConstFramesPerPacket
		{
			[DispId(3005)]
			get;
		}

		string AudioFormatSummaryString
		{
			[DispId(3006)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		double AudioSampleRate
		{
			[DispId(3007)]
			get;
		}

		string AudioSampleRateString
		{
			[DispId(3008)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int AudioSampleSize
		{
			[DispId(3009)]
			get;
		}

		string AudioSampleSizeString
		{
			[DispId(3010)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		float AudioTreble
		{
			[DispId(3011)]
			get;
			[DispId(3011)]
			set;
		}

		int AudioVolume
		{
			[DispId(1003)]
			get;
			[DispId(1003)]
			set;
		}

		int bottom
		{
			[DispId(1004)]
			get;
			[DispId(1004)]
			set;
		}

		string Copyright
		{
			[DispId(1005)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1005)]
			set;
		}

		int DataRate
		{
			[DispId(1006)]
			get;
		}

		bool DeinterlaceFields
		{
			[DispId(1007)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1007)]
			set;
		}

		int Depth
		{
			[DispId(2002)]
			get;
		}

		QTPOINT Dimensions
		{
			[DispId(1008)]
			get;
			[DispId(1008)]
			set;
		}

		string DisplayName
		{
			[DispId(1009)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1009)]
			set;
		}

		int Duration
		{
			[DispId(1010)]
			get;
		}

		float DynamicFrameRate
		{
			[DispId(1011)]
			get;
		}

		bool Enabled
		{
			[DispId(1012)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1012)]
			set;
		}

		int EndTime
		{
			[DispId(1013)]
			get;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		string Format
		{
			[DispId(1014)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Height
		{
			[DispId(1016)]
			get;
			[DispId(1016)]
			set;
		}

		bool HighQualityMode
		{
			[DispId(1017)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1017)]
			set;
		}

		string HREF
		{
			[DispId(1019)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1019)]
			set;
		}

		string Kind
		{
			[DispId(1020)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Language
		{
			[DispId(1021)]
			get;
			[DispId(1021)]
			set;
		}

		int Layer
		{
			[DispId(1022)]
			get;
			[DispId(1022)]
			set;
		}

		int left
		{
			[DispId(1023)]
			get;
			[DispId(1023)]
			set;
		}

		IQTMatrix Matrix
		{
			[DispId(1024)]
			get;
			[DispId(1024)]
			set;
		}

		bool Mute
		{
			[DispId(1025)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1025)]
			set;
		}

		string Name
		{
			[DispId(1026)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1026)]
			set;
		}

		QTRECT NaturalRect
		{
			[DispId(1027)]
			get;
		}

		int Number
		{
			[DispId(1028)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		string OperationColor
		{
			[DispId(1029)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1029)]
			set;
		}

		ICFObject PotentialExporters
		{
			[DispId(1030)]
			get;
		}

		bool Preload
		{
			[DispId(1031)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(1031)]
			set;
		}

		int PreloadDuration
		{
			[DispId(1032)]
			get;
			[DispId(1032)]
			set;
		}

		int PreloadTime
		{
			[DispId(1033)]
			get;
			[DispId(1033)]
			set;
		}

		QTRECT Rectangle
		{
			[DispId(1034)]
			get;
			[DispId(1034)]
			set;
		}

		int right
		{
			[DispId(1036)]
			get;
			[DispId(1036)]
			set;
		}

		bool SingleField
		{
			[DispId(2001)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			get;
			[DispId(2001)]
			set;
		}

		int Size
		{
			[DispId(1037)]
			get;
		}

		int StartTime
		{
			[DispId(1038)]
			get;
			[DispId(1038)]
			set;
		}

		float StaticFrameRate
		{
			[DispId(1039)]
			get;
		}

		int StreamPacketsLost
		{
			[DispId(6001)]
			get;
		}

		int StreamPacketsReceived
		{
			[DispId(6002)]
			get;
		}

		float StreamPercentPacketsLost
		{
			[DispId(6003)]
			get;
		}

		IQTStreams Streams
		{
			[DispId(659459)]
			get;
		}

		int TimeScale
		{
			[DispId(1040)]
			get;
		}

		int top
		{
			[DispId(1041)]
			get;
			[DispId(1041)]
			set;
		}

		QTTransferModesEnum TransferMode
		{
			[DispId(1042)]
			get;
			[DispId(1042)]
			set;
		}

		int Type
		{
			[DispId(1043)]
			get;
		}

		int UniqueID
		{
			[DispId(1044)]
			get;
		}

		int Width
		{
			[DispId(1045)]
			get;
			[DispId(1045)]
			set;
		}
	}

	[Guid("0C1EACCD-B10C-4930-83EB-F147E69F5572")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTTracks: System.Collections.IEnumerable
	{
		[DispId(0)]
		IQTTrack Item (object Item) /* property get method */;

		[DispId(659458)]
		void Remove (object Item);

		object _NewEnum
		{
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
		}

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("3CEAE58F-44BD-4905-96DC-971D72780878")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTUtils
	{
		[DispId(659457)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string FourCharCodeToString (int fcc);

		[DispId(659458)]
		int StringToFourCharCode ([MarshalAs(UnmanagedType.BStr)] string strFCC);

		[DispId(659459)]
		int QTErrorFromErrorCode (int ErrorCode);
	}

	[Guid("B12C3545-BBDE-4664-A4C4-806FE12F15C3")]
	[ComImport]
	[TypeLibType((short)4160)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTVRNode
	{
		[DispId(659722)]
		object _Property (int propertyClass, int propertyID) /* property get method */;

		[DispId(659722)]
		void _Property (int propertyClass, int propertyID, object value) /* property put method */;

		[DispId(659737)]
		void _GetObjectProperty (int propertyClass, int propertyID, int desiredFormat, [In, Out] ref int valueBuffer, int valueBufferSize, [In, Out] ref int outValueSize, [In] ref int paramArray, int paramArrayCount);

		[DispId(659738)]
		void _SetObjectProperty (int propertyClass, int propertyID, int valueFormat, [In] ref int valueBuffer, int valueBufferSize, int valueFlags, [In] ref int paramArray, int paramArrayCount);

		string Comments
		{
			[DispId(4102)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		IQTEventListeners EventListeners
		{
			[DispId(721170)]
			get;
		}

		IQTHotspots Hotspots
		{
			[DispId(659457)]
			get;
		}

		string Name
		{
			[DispId(4104)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int Number
		{
			[DispId(4105)]
			get;
		}

		int ObjectClass
		{
			[DispId(721173)]
			get;
		}

		int ObjectSubClass
		{
			[DispId(721174)]
			get;
		}

		int Type
		{
			[DispId(4106)]
			get;
		}

		int UniqueID
		{
			[DispId(4103)]
			get;
		}
	}

	[Guid("5F3B7CC7-CA8A-4F35-AC3C-D9DD0CC7D729")]
	[ComImport]
	[TypeLibType((short)4160)]
	[DefaultMember("Item")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IQTVRNodes: System.Collections.IEnumerable
	{
		[DispId(0)]
		IQTVRNode Item (object Item) /* property get method */;

		object _NewEnum
		{
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
		}

		int Count
		{
			[DispId(720897)]
			get;
		}
	}

	[Guid("EB0DCF74-D462-4FF6-855C-C40BB17CB8DA")]
	[ComImport]
	[TypeLibType((short)0)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface _IQTBaseObjectPriv
	{
		void _FireErrorEvent (int ErrorCode);

		IQTError _GetErrorObject ();

		int _GetErrorHandlingOption ();

		void _FireQTEvent (int MsgClass, int MsgID, int Flags, int MsgRef, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

		int _Property (int propertyClass, int propertyID) /* property get method */;

		void put__Property (int propertyClass, int propertyID, int pVal) /* property put method */;
	}

	[Guid("B3C1F670-4DB1-4508-82C8-8C125D39C7A8")]
	[ComImport]
	[TypeLibType((short)0)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface _IQTControlFireEvent
	{
		void _Fire_QTEvent (int EventClass, int EventID, int Flags, IQTEventObject EventObject, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

		void _Fire_Error (int ErrorCode, int Origin);
	}

	[Guid("BF412ABA-B823-4818-A36B-5962953221CF")]
	[ComImport]
	[TypeLibType((short)0)]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface _IQTEventCapture
	{
		void put__QTControlFireEvent (_IQTControlFireEvent pVal) /* property put method */;

		_IQTControlFireEvent _QTControlFireEvent () /* property get method */;
	}

	[Guid("47ECAC10-2F4B-4F79-8702-ECE38A887E8A")]
	[ComImport]
	[CoClass(typeof(CFObjectClass))]
	public interface CFObject: ICFObject
	{
	}

	[Guid("60EB3672-E108-48E5-8F14-9E3DC7D618E0")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class CFObjectClass // : ICFObject, CFObject
	{
	}

	[Guid("A3732EA4-F490-4F30-8C7B-37750215D11F")]
	[ComImport]
	[CoClass(typeof(CFObjectsClass))]
	public interface CFObjects: ICFObjects
	{
	}

	[Guid("14E8B49D-DB67-4B32-9CCB-0F3416866ADC")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class CFObjectsClass // : ICFObjects, CFObjects
	{
	}

	[Guid("70E6D439-F975-4969-83C5-855534600B3A")]
	[ComImport]
	[CoClass(typeof(ErrorClass))]
	public interface Error: IQTError
	{
	}

	[Guid("BF72FADC-9E2E-47C3-82FE-DE38FE50168C")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class ErrorClass // : IQTError, Error
	{
	}

	[Guid("2A7BCC60-AE86-4707-81A9-CD2227BBD97A")]
	[ComImport]
	[CoClass(typeof(QTChapterClass))]
	public interface QTChapter: IQTChapter
	{
	}

	[Guid("0098D378-843B-41A7-A261-77390BF749FA")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTChapterClass // : IQTChapter, QTChapter
	{
	}

	[Guid("F0B2D3E8-7B9C-407A-9F82-C56E3F9533D0")]
	[ComImport]
	[CoClass(typeof(QTChaptersClass))]
	public interface QTChapters: IQTChapters
	{
	}

	[Guid("841EC59E-226D-4D9A-AC1B-2E8AB594B6C7")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTChaptersClass // : IQTChapters, QTChapters, IEnumerable
	{
	}

	[Guid("D464A8C3-5BC8-48FB-B1F6-7EA0A32E9BB8")]
	[ComImport]
	[CoClass(typeof(QTEventListenersClass))]
	public interface QTEventListeners: IQTEventListeners
	{
	}

	[Guid("200C1EF3-9EB9-4FC7-BF55-46F19EBDF96A")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTEventListenersClass // : IQTEventListeners, QTEventListeners
	{
	}

	[Guid("F10FB760-2AFB-48B4-AD2E-800865A23232")]
	[ComImport]
	[CoClass(typeof(QTEventObjectClass))]
	public interface QTEventObject: IQTEventObject
	{
	}

	[Guid("4BD4ADEE-26BB-4874-9FC7-EA835F91ACED")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTEventObjectClass // : IQTEventObject, QTEventObject
	{
	}

	[Guid("0CCD18D4-4DE3-4CB6-9DB7-4232A8A066D3")]
	[ComImport]
	[CoClass(typeof(QTExporterClass))]
	public interface QTExporter: IQTExporter
	{
	}

	[Guid("E46C7ED1-C750-4C41-A8BB-A0EE2B87C5C9")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTExporterClass // : IQTExporter, QTExporter
	{
	}

	[Guid("88B370F8-683E-4403-855E-0783E2A7CE34")]
	[ComImport]
	[CoClass(typeof(QTExportersClass))]
	public interface QTExporters: IQTExporters
	{
	}

	[Guid("89D8BDCD-9C5F-4574-B578-8E23F9CBDD95")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTExportersClass // : IQTExporters, QTExporters, IEnumerable
	{
	}

	[Guid("F6EE34D2-FDA8-40EF-BF7A-C28E04D2A6F1")]
	[ComImport]
	[CoClass(typeof(QTFrequencyMeterClass))]
	public interface QTFrequencyMeter: IQTFrequencyMeter
	{
	}

	[Guid("AF0AE9AA-556F-48D2-8A99-5DE2050D644E")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTFrequencyMeterClass // : IQTFrequencyMeter, QTFrequencyMeter
	{
	}

	[Guid("7F9B97B0-D0D0-4036-815B-4E2A874CCD4B")]
	[ComImport]
	[CoClass(typeof(QTHotspotClass))]
	public interface QTHotspot: IQTHotspot
	{
	}

	[Guid("69B51ED1-7975-4EF5-A494-8C683A091790")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTHotspotClass // : IQTHotspot, QTHotspot
	{
	}

	[Guid("C210E589-6B11-41F3-BFD6-79FDF3A206D6")]
	[ComImport]
	[CoClass(typeof(QTHotspotsClass))]
	public interface QTHotspots: IQTHotspots
	{
	}

	[Guid("6F1F8C67-9046-4AAB-B199-9D95119568DF")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTHotspotsClass // : IQTHotspots, QTHotspots, IEnumerable
	{
	}

	[Guid("516DB716-A2D9-4E0C-B724-3B70A2724DE9")]
	[ComImport]
	[CoClass(typeof(QTMatrixClass))]
	public interface QTMatrix: IQTMatrix
	{
	}

	[Guid("A882BDEE-BD01-4B16-9EAF-04B74A43DF7C")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTMatrixClass // : IQTMatrix, QTMatrix
	{
	}

	[Guid("4ADDED78-C61F-4530-86BE-EE3E2E28B0F3")]
	[ComImport]
	[CoClass(typeof(QTMovieClass))]
	public interface QTMovie: IQTMovie
	{
	}

	[Guid("815031F4-05E5-4269-830C-FD3C0EA9BA58")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("_IQTObjectEvents")]
	public class QTMovieClass // : IQTObject, _IQTEventCapture, _IQTBaseObjectPriv, IQTMovie, QTMovie, _IQTObjectEvents_Event
	{
	}

	[Guid("6D307784-BE9F-46D9-A8DA-21EFD156F3CA")]
	[ComImport]
	[CoClass(typeof(QTQuickTimeClass))]
	public interface QTQuickTime: IQTQuickTime
	{
	}

	[Guid("30063361-BAE0-480A-BF2B-417D18530A0D")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces("_IQTObjectEvents")]
	public class QTQuickTimeClass // : _IQTEventCapture, _IQTBaseObjectPriv, IQTQuickTime, QTQuickTime, _IQTObjectEvents_Event
	{
	}

	[Guid("7C1139DF-A316-4C15-AD77-E32381887D08")]
	[ComImport]
	[CoClass(typeof(QTSettingsClass))]
	public interface QTSettings: IQTSettings
	{
	}

	[Guid("2063DEEB-6B23-40FD-AE0E-49C4FD41AA35")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTSettingsClass // : IQTSettings, QTSettings
	{
	}

	[Guid("BEE6A65B-92EB-4F66-8793-749905A024F4")]
	[ComImport]
	[CoClass(typeof(QTStreamClass))]
	public interface QTStream: IQTStream
	{
	}

	[Guid("41E7F020-A9DF-4C2E-A063-E0945AF5CFE3")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTStreamClass // : IQTStream, QTStream
	{
	}

	[Guid("D75A4EFE-6E14-4338-8800-2E7A91C07BE4")]
	[ComImport]
	[CoClass(typeof(QTStreamsClass))]
	public interface QTStreams: IQTStreams
	{
	}

	[Guid("2684CAD6-07AE-4B04-A0DC-330729B26255")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTStreamsClass // : IQTStreams, QTStreams, IEnumerable
	{
	}

	[Guid("7B63E33C-76F2-4891-A920-FBF4D91EE33F")]
	[ComImport]
	[CoClass(typeof(QTTrackClass))]
	public interface QTTrack: IQTTrack
	{
	}

	[Guid("77CC2139-8CC0-4528-91FC-F91154554A37")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTTrackClass // : IQTObject, IQTTrack, QTTrack
	{
	}

	[Guid("0C1EACCD-B10C-4930-83EB-F147E69F5572")]
	[ComImport]
	[CoClass(typeof(QTTracksClass))]
	public interface QTTracks: IQTTracks
	{
	}

	[Guid("FB097A8B-16D5-43D2-B250-7255C5A89FA3")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTTracksClass // : IQTTracks, QTTracks, IEnumerable
	{
	}

	[Guid("3CEAE58F-44BD-4905-96DC-971D72780878")]
	[ComImport]
	[CoClass(typeof(QTUtilsClass))]
	public interface QTUtils: IQTUtils
	{
	}

	[Guid("C69EBBD4-3B66-4BF6-BE1B-E2B44C5154B2")]
	[ComImport]
	[TypeLibType((short)2)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTUtilsClass // : IQTUtils, QTUtils
	{
	}

	[Guid("B12C3545-BBDE-4664-A4C4-806FE12F15C3")]
	[ComImport]
	[CoClass(typeof(QTVRNodeClass))]
	public interface QTVRNode: IQTVRNode
	{
	}

	[Guid("8BD76371-A323-44BE-96C6-6568BC5D5BEE")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTVRNodeClass // : IQTVRNode, QTVRNode
	{
	}

	[Guid("5F3B7CC7-CA8A-4F35-AC3C-D9DD0CC7D729")]
	[ComImport]
	[CoClass(typeof(QTVRNodesClass))]
	public interface QTVRNodes: IQTVRNodes
	{
	}

	[Guid("D428018D-8748-4E6B-A934-0C2DC5DE8382")]
	[ComImport]
	[TypeLibType((short)0)]
	[ClassInterface(ClassInterfaceType.None)]
	public class QTVRNodesClass // : IQTVRNodes, QTVRNodes, IEnumerable
	{
	}
}
