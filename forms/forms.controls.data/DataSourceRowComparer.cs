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
	/// because the DataSourceRow class is a wrapper class around the real data,
	/// the compared object used to sort the real data is wrapped by this DataSourceRowComparer class.
	/// </summary>
	internal class DataSourceRowComparer : IComparer
	{
	    IComparer baseComparer;
	    public DataSourceRowComparer(IComparer baseComparer)
	    {
	        this.baseComparer = baseComparer;
	    }
	
	
	    public int Compare(object x, object y)
	    {
	        DataSourceRow r1 = (DataSourceRow)x;
	        DataSourceRow r2 = (DataSourceRow)y;
	        return baseComparer.Compare(r1.BoundItem, r2.BoundItem);
	    }
	}
}
