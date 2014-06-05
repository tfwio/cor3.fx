﻿// Copyright 2006 Herre Kuijpers - <herre@xs4all.nl>
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
using System.Text;
using System.Windows.Forms;

namespace OutlookStyleControls
{
	/// <summary>
	/// IOutlookGridGroup specifies the interface of any implementation of a OutlookGridGroup class
	/// Each implementation of the IOutlookGridGroup can override the behaviour of the grouping mechanism
	/// Notice also that ICloneable must be implemented. The OutlookGrid makes use of the Clone method of the Group
	/// to create new Group clones. Related to this is the OutlookGrid.GroupTemplate property, which determines what
	/// type of Group must be cloned.
	/// </summary>
	public interface IOutlookGridGroup : IComparable, ICloneable
	{
	    /// <summary>the text to be displayed in the group row</summary>
	    string Text { get; set; }
	    /// <summary>determines the value of the current group. this is used to compare the group value against each item's value.</summary>
	    object Value { get; set; }
	    /// <summary>indicates whether the group is collapsed. If it is collapsed, it group items (rows) will not be displayed.</summary>
	    bool Collapsed { get; set; }
	    /// <summary>specifies which column is associated with this group</summary>
	    DataGridViewColumn Column { get; set; }
	    /// <summary>specifies the number of items that are part of the current group this value is automatically filled each time the grid is re-drawn e.g. after sorting the grid.</summary>
	    int ItemCount { get; set; }
	    /// <summary>specifies the default height of the group each group is cloned from the GroupStyle object. Setting the height of this object will also set the default height of each group. </summary>
	    int Height { get; set; }
	}
}
