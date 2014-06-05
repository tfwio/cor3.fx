/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 9/19/2008
 * Time: 11:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

using efx;
using efx.Forms.Controls;

namespace Drawing.Forms.Controls
{
	[
	ProvideProperty("HelpText",typeof(Control)),
	Designer(typeof(FontHelpLabel.HelpLabelDesigner))
	]
	public class FontHelpLabel : GraphicContainer/*CDraw*/, System.ComponentModel.IExtenderProvider 
	{
		/// <summary>
		///    Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		private Hashtable helpTexts;
		private System.Windows.Forms.Control activeControl;
		public override void DoPaint(Control ctl, Graphics gfx)
		{
			base.DoPaint(ctl, gfx);
			string lttleguy = "SAMPLE TEXT\r\nsample text";
			Rectangle rect = ClientRectangle;

//			Pen borderPen = new Pen(ForeColor);
//			pe.Graphics.DrawRectangle(borderPen, rect);
//			borderPen.Dispose();
			
	
			// Finally, draw the text over the top of the
			// rectangle.
			//
			// rectangle.
			if (activeControl is LvFont)
			{
				string texty = (string)helpTexts[activeControl];
				if (texty != null && texty.Length > 0) 
				{
//					pe.Graphics.TextContrast = 24;
//					pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					LvFont flv = (LvFont)activeControl;
					Font usefont = flv.fc[texty];
					rect.Inflate(-2, -2);
					Brush brush = new SolidBrush(ForeColor);
					gfx.DrawString(texty, this.Font, brush, rect);
					brush.Dispose(); brush = null;
					brush = new SolidBrush(Color.Black);
					rect.Inflate(-3,-3);
					m_gfx.Clip = new Region(rect);
					rect.Y = rect.Y+10;
					gfx.Clear(SystemColors.Window);
					gfx.DrawString(lttleguy, usefont, brush, rect);
					brush.Dispose();
					usefont.Dispose();
					gfx.ResetClip();
				}
			}
			else if (activeControl != null) 
			{
				string text = (string)helpTexts[activeControl]+" "+ activeControl.GetType().ToString();
				if (text != null && text.Length > 0) 
				{
					rect.Inflate(-2, -2);
					Brush brush = new SolidBrush(ForeColor);
					gfx.DrawString(text, Font, brush, rect);
					brush.Dispose();
				} else {
					rect.Inflate(-2, -2);
					Brush brush = new SolidBrush(ForeColor);
					gfx.DrawString(activeControl.GetType().ToString(), Font, brush, rect);
					brush.Dispose();
				}
			}
		}
		//
		// <doc>
		// <desc>
		//      Creates a new help label object.
		// </desc>
		// </doc>
		//
		public FontHelpLabel() 
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
	
			helpTexts = new Hashtable();
		}
	
		/// <summary>
		///    Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) 
		{
			if (disposing) 
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	
		/// <summary>
		///    Required method for Designer support - do not modify
		///    the contents of this method with the code editor.
		/// </summary>
		public override void InitializeComponent() 
		{
			this.components = new System.ComponentModel.Container ();
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ForeColor = System.Drawing.SystemColors.InfoText;
			this.TabStop = false;
		}
	
		//
		// <doc>
		// <desc>
		//      Overrides the text property of Control.  This label ignores
		//      the text property, so we add additional attributes here so the
		//      property does not show up in the properties window and is not
		//      persisted.
		// </desc>
		// </doc>
		//
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public override string Text 
		{
			get 
			{
				return base.Text;
			}
			set 
			{
				base.Text = value;
			}
		}
	
		//
		// <doc>
		// <desc>
		//      This implements the IExtenderProvider.CanExtend method.  The
		//      help label provides an extender property, and the design time
		//      framework will call this method once for each component to determine
		//      if we are interested in providing our extended properties for the
		//      component.  We return true here if the object is a control and is
		//      not a HelpLabel (since it would be silly to add this property to
		//      ourselves).
		// </desc>
		// </doc>
		//
		bool IExtenderProvider.CanExtend(object target) 
		{
			if ((target is Control && !(target is FontHelpLabel)) || target is efx.Forms.Controls.LvFont)
			{
				return true;
			}
			return false;
		}
	
		[DefaultValue("")]
		public string GetHelpText(Control control) 
		{
			string text = (string)helpTexts[control];
			if (text == null) 
			{
				if (control is SplitContainer || control is Splitter) Global.cstat(ConsoleColor.Red,control.ToString());
				text = control.GetType().Name;
			}
			return text;
		}
	
		private void OnControlEnter(object sender, EventArgs e) 
		{
			activeControl = (Control)sender;
			Invalidate();
		}
		private void OnControlLeave(object sender, EventArgs e) 
		{
			if (sender == activeControl) { activeControl = null; Invalidate(); }
		}
	
		public void SetHelpText(Control control, string value) 
		{
			if (value == null) value = string.Empty;
	
			if (value.Length == 0) {
				helpTexts.Remove(control);
				control.Enter -= new EventHandler(OnControlEnter);
				control.Leave -= new EventHandler(OnControlLeave);
			} else  {
				helpTexts[control] = value;
	
				control.Enter += new EventHandler(OnControlEnter);
				control.Leave += new EventHandler(OnControlLeave);
			}
			if (control == activeControl) Invalidate();
		}
	
		public bool ShouldSerializeBackColor() { return(!BackColor.Equals(SystemColors.Info)); }
		public bool ShouldSerializeForeColor() { return(!ForeColor.Equals(SystemColors.InfoText)); }
	
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
		public class HelpLabelDesigner : System.Windows.Forms.Design.ControlDesigner 
		{
	
			private bool trackSelection = true;
	
			private bool TrackSelection
			{
				get { return trackSelection; }
				set {
					trackSelection = value;
					if (trackSelection)
					{
						ISelectionService ss = (ISelectionService)GetService(typeof(ISelectionService));
						if (ss != null)
						{
							UpdateHelpLabelSelection(ss);
						}
					}
					else
					{
						FontHelpLabel helpLabel = (FontHelpLabel)Control;
						if (helpLabel.activeControl != null)
						{
							helpLabel.activeControl = null;
							helpLabel.Invalidate();
						}
					}
				}
			}
	
			public override DesignerVerbCollection Verbs
			{
				get
				{
					return new DesignerVerbCollection(
						new DesignerVerb[]
						{
							new DesignerVerb("Dock Top", new EventHandler(OnSampleVerb)),
							new DesignerVerb("Dock Bottom", new EventHandler(OnSampleVerb))
						}
					);
				}
			}
	
			protected override void Dispose(bool disposing) 
			{
				if (disposing) {
					ISelectionService ss = (ISelectionService)GetService(typeof(ISelectionService));
					if (ss != null) {
						ss.SelectionChanged -= new EventHandler(OnSelectionChanged);
					}
				}
	
				base.Dispose(disposing);
			}
	
			public override void Initialize(IComponent component) 
			{
				base.Initialize(component);
	
				ISelectionService ss = (ISelectionService)GetService(typeof(ISelectionService));
				if (ss != null) 
				{
					ss.SelectionChanged += new EventHandler(OnSelectionChanged);
				}
			}
	
			private void OnSampleVerb(object sender, EventArgs e)
			{
				MessageBox.Show("You have just invoked a sample verb.  Normally, this would do something interesting.");
			}
			private void OnSelectionChanged(object sender, EventArgs e) 
			{
				if (trackSelection)
				{
					ISelectionService ss = (ISelectionService)sender;
					UpdateHelpLabelSelection(ss);
				}
			}
	
			protected override void PreFilterProperties(IDictionary properties)
			{
				// Always call base first in PreFilter* methods, and last in PostFilter*
				// methods.
				base.PreFilterProperties(properties);
	
				// We add a design-time property called "TrackSelection" that is used to track
				// the active selection.  If the user sets this to true (the default), then
				// we will listen to selection change events and update the control's active
				// control to point to the current primary selection.
				properties["TrackSelection"] = TypeDescriptor.CreateProperty(
					this.GetType(),        // the type this property is defined on
					"TrackSelection",    // the name of the property
					typeof(bool),        // the type of the property
					new Attribute[] {CategoryAttribute.Design});    // attributes
			}
	
			/// <summary>
			/// This is a helper method that, given a selection service, will update the active control
			/// of our help label with the currently active selection.
			/// </summary>
			/// <param name="ss"></param>
			private void UpdateHelpLabelSelection(ISelectionService ss)
			{
				Control c = ss.PrimarySelection as Control;
				FontHelpLabel helpLabel = (FontHelpLabel)Control;
				if (c != null)
				{
					helpLabel.activeControl = c;
					helpLabel.Invalidate();
				}
				else
				{
					if (helpLabel.activeControl != null)
					{
						helpLabel.activeControl = null;
						helpLabel.Invalidate();
					}
				}
			}
		}
	}
}
