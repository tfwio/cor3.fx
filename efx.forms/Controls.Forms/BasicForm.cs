/**
 * tfw * 1/17/2009 * 1:02 PM
**/
using System;

namespace efx.Forms
{
	/// <summary>Description of BasicForm.</summary>
	public class BasicForm : System.Windows.Forms.Form
	{
		internal bool alldone = false;

		public BasicForm() : base() {
		}

		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing) { if (disposing) { if (components != null) { components.Dispose(); } } base.Dispose(disposing); }
		virtual public void InitializeComponent() { }
	}
}
