/* oOo * 11/14/2007 : 10:22 PM */
using System;

namespace iface
{
	public enum EventEnum
	{
		/// <summary>Main Document Changed (Activated)</summary>
		Act,
		/// <summary>Main Content Changed (Activated)</summary>
		Act_Content,
		/// <summary>Final Message?</summary>
		Fin,
		OnReset,
		/// <summary>PreConfig</summary>
		PreConfig,
		/// <summary>PostConfig</summary>
		PostConfig,
		OnLoad,Load,
		/// <summary>the action of the ListView populating takes place.<br/>Globe.DocMan.List();</summary>
		UpdateFiles,
		/// <summary>MRU IS TO BE NOTIFIED<br/></summary>
		File,
		/// <summary>MRU IS TO BE NOTIFIED<br/>(maybe)</summary>
		Path,
		ThreadPriority,
	}
}
