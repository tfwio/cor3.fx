// Copyright 2006 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------
using System;
using System.Collections;

namespace OutlookStyleControls
{
	/// <summary>
	/// The DataSourceRow is a wrapper row class around the real bound data. This row is an abstraction
	/// so different types of data can be encaptulated in this class, although for the OutlookGrid it will
	/// simply look as one type of data.
	/// Note: this class does not implement all row wrappers optimally. It is merely used for demonstration purposes
	/// </summary>
	internal class DataSourceRow : CollectionBase
	{
		DataSourceManager manager;
		object boundItem;

		public DataSourceRow(DataSourceManager manager, object boundItem)
		{
			this.manager = manager;
			this.boundItem = boundItem;
		}

		public object this[int index] { get { return List[index]; } }
		public object BoundItem { get { return boundItem; } }
		public int Add(object val) { return List.Add(val); }
		
	}
}
