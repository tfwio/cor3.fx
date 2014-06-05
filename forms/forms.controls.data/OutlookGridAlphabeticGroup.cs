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

namespace OutlookStyleControls
{

    /// <summary>
    /// this group simple example of an implementation which groups the items into Alphabetic categories
    /// based only on the first letter of each item
    /// 
    /// for this we need to override the Value property (used for comparison)
    /// and the CompareTo function.
    /// Also the Clone method must be overriden, so this Group object can create clones of itself.
    /// Cloning of the group is used by the OutlookGrid
    /// </summary>
    public class OutlookGridAlphabeticGroup : OutlookgGridDefaultGroup
    {
        public OutlookGridAlphabeticGroup()
            : base()
        {
            
        }

        public override string Text
        {
            get
            {
                return string.Format("Alphabetic: {1} ({2})", column.HeaderText, Value.ToString(), itemCount == 1 ? "1 item" : itemCount.ToString() + " items");
            }
            set { text = value; }
        }

        public override object Value
        {
            get { return val; }
            set { val = value.ToString().Substring(0,1).ToUpper(); }
        }

        #region ICloneable Members
        /// <summary>
        /// each group class must implement the clone function
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            OutlookGridAlphabeticGroup gr = new OutlookGridAlphabeticGroup();
            gr.column = this.column;
            gr.val = this.val;
            gr.collapsed = this.collapsed;
            gr.text = this.text;
            gr.height = this.height;
            return gr;
        }

        #endregion

        #region IComparable Members
        /// <summary>
        /// overide the CompareTo, so only the first character is compared, instead of the whole string
        /// this will result in classifying each item into a letter of the Alphabet.
        /// for instance, this is usefull when grouping names, they will be categorized under the letters A, B, C etc..
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int CompareTo(object obj)
        {
            return string.Compare(val.ToString(), obj.ToString().Substring(0, 1).ToUpper());
        }

        #endregion IComparable Members

    }
    
}
