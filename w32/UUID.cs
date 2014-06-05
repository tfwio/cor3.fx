using System;
using System.Runtime.InteropServices;

namespace w32.shell
{
	#region unused
//	internal Guid DIDiskQuotaUser		= new Guid("7988B571-EC89-11cf-9C00-00AA00A14F56");
//	internal Guid DiskQuotaControl		= new Guid("7988B571-EC89-11cf-9C00-00AA00A14F56");
//	internal Guid Folder				= new Guid("BBCBDE60-C3FF-11CE-8350-444553540000");
//	internal Guid Folder2				= new Guid("f0d2d8ef-3890-11d2-bf8b-00c04fb93661");
//	internal Guid FolderItem			= new Guid("744129E0-CBE5-11CE-8350-444553540000");
//	internal Guid FolderItems			= new Guid("744129E0-CBE5-11CE-8350-444553540000");
//	internal Guid FolderItems2			= new Guid("C94F0AD0-F363-11d2-A327-00C04F8EEC7F");
//	internal Guid FolderItemVerb		= new Guid("08EC3E00-50B0-11CF-960C-0080C7F4EE85");
//	internal Guid FolderItemVerbs		= new Guid("1F8352C0-50B0-11CF-960C-0080C7F4EE85");
//	internal Guid IShellDispatch2		= new Guid("A4C6892C-3BA9-11d2-9DEA-00C04FB16162");
//	internal Guid IShellLinkDual2		= new Guid("317EE249-F12E-11d2-B1E4-00C04F8EEB3E");
//	internal Guid Shell					= new Guid("13709620-C279-11CE-A49E-444553540000");
//	internal Guid ShellFolderItem		= new Guid("2fe352ea-fd1f-11d2-b1f4-00c04f8eeb3e");
//	internal Guid ShellFolderView		= new Guid("62112AA1-EBE4-11cf-A5FB-0020AFE7292D");
//	internal Guid ShellFolderViewOC		= new Guid("4a3df050-23bd-11d2-939f-00a0c91eedba");
//	internal Guid ShellLinkObject		= new Guid("11219420-1768-11d1-95BE-00609797EA4F");
//	internal Guid ShellUIHelper			= new Guid("64AB4BB7-111E-11D1-8F79-00C04FC2FBE1");
//	internal Guid ShellWindows			= new Guid("9BA05972-F6A8-11CF-A442-00A0C90A8F39");
//	internal Guid WebViewFolderContents	= new Guid("1820FED0-473E-11D0-A96C-00C04FD705A2");
	#endregion

	public class _iid
	{
	    public const string IID_IShellFolder = ("{000214E6-0000-0000-C000-000000000046}");
	    public const string IID_IContextMenu = ("{000214e4-0000-0000-c000-000000000046}");
	    public const string IID_IContextMenu2 = ("{000214f4-0000-0000-c000-000000000046}");
	    public const string IID_IContextMenu3 = ("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");
	    public const string xID_IShellFolder = ("000214E6-0000-0000-C000-000000000046");
	    public const string xID_IContextMenu = ("000214e4-0000-0000-c000-000000000046");
	    public const string xID_IContextMenu2 = ("000214f4-0000-0000-c000-000000000046");
	    public const string xID_IContextMenu3 = ("bcfce0a0-ec17-11d0-8d10-00a0c90f2719");
	}
	public class uuid_const_v471
	{
		public Guid this[sh_id_v471 Key] { get { return new Guid(GetUUID(Key)); } }
		public enum sh_id_v471
		{
			Folder,
			FolderItemVerb,
			FolderItemVerbs,
			Shell,
			ShellFolderView,
			ShellUIHelper,
			WebViewFolderContents,
		}
		internal const string Folder				= "BBCBDE60-C3FF-11CE-8350-444553540000";
		internal const string FolderItemVerb		= "08EC3E00-50B0-11CF-960C-0080C7F4EE85";
		internal const string FolderItemVerbs		= "1F8352C0-50B0-11CF-960C-0080C7F4EE85";
		internal const string Shell					= "13709620-C279-11CE-A49E-444553540000";
		internal const string ShellFolderView		= "62112AA1-EBE4-11cf-A5FB-0020AFE7292D";
		internal const string ShellUIHelper			= "64AB4BB7-111E-11D1-8F79-00C04FC2FBE1";
		internal const string WebViewFolderContents	= "1820FED0-473E-11D0-A96C-00C04FD705A2";
		static public Guid FromString(string guid) { return new Guid(guid); }
		static public string GetUUID(sh_id_v471 sh_id_v471)
		{
			switch (sh_id_v471) {
				case sh_id_v471.Folder: return (Folder);
				case sh_id_v471.FolderItemVerb: return (FolderItemVerb);
				case sh_id_v471.FolderItemVerbs: return (FolderItemVerbs);
				case sh_id_v471.Shell: return (Shell);
				case sh_id_v471.ShellFolderView: return (ShellFolderView);
				case sh_id_v471.ShellUIHelper: return (ShellUIHelper);
				case sh_id_v471.WebViewFolderContents: return (WebViewFolderContents);
				default: return string.Empty;
			}
		}
	}
	public class uuid_const_v5 : uuid_const_v471
	{
		public Guid this[sh_id_v5 Key] { get { return new Guid(GetUUID(Key)); } }
		public enum sh_id_v5
		{
			DIDiskQuotaUser,
			DiskQuotaControl,
			Folder2,
			FolderItem,
			FolderItems,
			FolderItems2,
			IShellDispatch2,
			IShellLinkDual2,
			ShellFolderItem,
			ShellFolderViewOC,
			ShellLinkObject,
			ShellWindows,
		}
		internal const string DIDiskQuotaUser		= "7988B571-EC89-11cf-9C00-00AA00A14F56";
		internal const string DiskQuotaControl		= "7988B571-EC89-11cf-9C00-00AA00A14F56";
		internal const string Folder2				= "f0d2d8ef-3890-11d2-bf8b-00c04fb93661";
		internal const string FolderItem			= "744129E0-CBE5-11CE-8350-444553540000";
		internal const string FolderItems			= "744129E0-CBE5-11CE-8350-444553540000";
		internal const string FolderItems2			= "C94F0AD0-F363-11d2-A327-00C04F8EEC7F";
		internal const string IShellDispatch2		= "A4C6892C-3BA9-11d2-9DEA-00C04FB16162";
		internal const string IShellLinkDual2		= "317EE249-F12E-11d2-B1E4-00C04F8EEB3E";
		internal const string ShellFolderItem		= "2fe352ea-fd1f-11d2-b1f4-00c04f8eeb3e";
		internal const string ShellFolderViewOC		= "4a3df050-23bd-11d2-939f-00a0c91eedba";
		internal const string ShellLinkObject		= "11219420-1768-11d1-95BE-00609797EA4F";
		internal const string ShellWindows			= "9BA05972-F6A8-11CF-A442-00A0C90A8F39";

		static public string GetUUID(sh_id_v5 sh_id_v5)
		{
			switch (sh_id_v5) {
				case sh_id_v5.DIDiskQuotaUser: return (DIDiskQuotaUser);
				case sh_id_v5.DiskQuotaControl: return (DiskQuotaControl);
				case sh_id_v5.Folder2: return (Folder2);
				case sh_id_v5.FolderItem: return (FolderItem);
				case sh_id_v5.FolderItems: return (FolderItems);
				case sh_id_v5.FolderItems2: return (FolderItems2);
				case sh_id_v5.IShellDispatch2: return (IShellDispatch2);
				case sh_id_v5.IShellLinkDual2: return (IShellLinkDual2);
				case sh_id_v5.ShellFolderItem: return (ShellFolderItem);
				case sh_id_v5.ShellFolderViewOC: return (ShellFolderViewOC);
				case sh_id_v5.ShellLinkObject: return (ShellLinkObject);
				case sh_id_v5.ShellWindows: return (ShellWindows);
				default: return string.Empty;
			}
		}
	}
	public class UUID : uuid_const_v5
	{
		internal const string AxShockwaveFlash = "d27cdb6e-ae6d-11cf-96b8-444553540000";
	}
}
