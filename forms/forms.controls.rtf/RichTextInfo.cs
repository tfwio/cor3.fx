/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using System.Cor3.man;
namespace System.Cor3.Forms.rtf
{
	public delegate void RichTextInfoSelChanged();
	public class RichTextInfo : object_manager<RichTextControl>
	{
		public event RichTextInfoSelChanged SelectionChanged;
		
		[
			Category("Selection Info"),
			TypeConverter(typeof(ArrayConverter))
		] public int[] SelectionTabs { get { return Client.SelectionTabs; } set { Client.SelectionTabs = value;} }
		[Category("Selection Info")] public RichTextBoxSelectionTypes SelectionType { get { return Client.SelectionType; } }

		[Category("Selection Bullet")] public int BulletIndent { get { return Client.BulletIndent; } set { Client.BulletIndent = value;} }
		[Category("Selection Bullet")] public bool SelectionBullet { get { return Client.SelectionBullet; } set { Client.SelectionBullet = value;} }

		[Category("Selection Info")] public bool SelectionProtected { get { return Client.SelectionProtected; } set { Client.SelectionProtected = value;} }
		[Category("Selection Indent")] public int SelectionIndent { get { return Client.SelectionIndent; } set { Client.SelectionIndent = value;} }
		[Category("Selection Indent")] public int SelectionRightIndent { get { return Client.SelectionRightIndent; } set { Client.SelectionRightIndent = value;} }
		[Category("Selection Indent")] public int SelectionHangingIndent { get { return Client.SelectionHangingIndent; } set { Client.SelectionHangingIndent = value;} }
		[Category("Selection Style")] public Color SelectionColor { get { return Client.SelectionColor; } set { Client.SelectionColor = value;} }
		[Category("Selection Style")] public Font SelectionFont { get { return Client.SelectionFont; } set { Client.SelectionFont = value;} }
		[Category("Selection Style")] public HorizontalAlignment SelectionAlignment { get { return Client.SelectionAlignment; } set { Client.SelectionAlignment = value;} }
		
		void eSelectionChanged(object sender, EventArgs e)
		{
			
		}

		public override void AddEvents()
		{
			base.AddEvents();
			Client.SelectionChanged += eSelectionChanged;
		}

		public RichTextInfo(RichTextControl rtf) : base(rtf)
		{
			
		}
	}
}
