/**
 * 
 * tfw * 2/5/2009 * 1:41 PM
 * 
**/
using System;

namespace intrinsic
{
	[System.Windows.Forms.AxHost.ClsidAttribute("{"+Shell32.UUID.Folder+"}")]
	/// <summary>Description of AxHost.</summary>
	public class AxHostBase : System.Windows.Forms.AxHost
	{
		const string idShockwaveFlashClass			= "D27CDB6E-AE6D-11CF-96B8-444553540000";
		const string idShockwaveFlash				= "D27CDB6C-AE6D-11CF-96B8-444553540000";
		const string idFlashObjectInterfaceClass	= "AE6D-11CF-96B8-444553540000";
		const string idFlashObjectInterface			= "D27CDB72-AE6D-11CF-96B8-444553540000";
		const string idIServiceProvider				= "6D5140C1-7436-11CE-8034-00AA006009FA";
		const string idIFlashObjectInterface		= "D27CDB72-AE6D-11CF-96B8-444553540000";
		const string idIFlashFactory				= "D27CDB70-AE6D-11CF-96B8-444553540000";
		const string idIDispatchEx					= "A6EF9860-C720-11D0-9337-00A0C90DCAA9";
		const string id_IShockwaveFlashEvents		= "D27CDB6D-AE6D-11CF-96B8-444553540000";

		const string def_uuid = "{"+Shell32.UUID.Folder+"}";
		public AxHostBase() : base(def_uuid) { }
	}
}
