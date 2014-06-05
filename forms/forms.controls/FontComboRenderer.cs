/*
 * User: tfw
 * Date: 8/13/2009
 * Time: 3:57 PM
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Cor3.man;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Cor3;
using drawing;

namespace System.Cor3.Forms
{
	public class FontComboRenderer : object_manager<FontCombo>
	{
		public struct fontitem
		{
			public string	Name;
			public bool		IsFixed;
			public byte		charset;
			
			public fontitem(string name, bool isfix, byte cset) { Name=name; IsFixed=isfix; charset=cset; }
			public fontitem(int index)
			{
				
				using (Font fnt = font_util.CreateFont(index))
				{
					if (fnt==null)
					{
					Name = System.Drawing.FontFamily.GenericMonospace.Name;
					Font fnt1 = new Font(
						System.Drawing.FontFamily.GenericMonospace,
						11f,FontStyle.Regular,GraphicsUnit.Point);
					IsFixed=font_util.IsFitted(fnt);
					Name = System.Drawing.FontFamily.GenericMonospace.Name;
					charset = fnt1.GdiCharSet;
					}
					else
					{
					Name = fnt.Name;
					IsFixed=font_util.IsFitted(fnt);
					charset = fnt.GdiCharSet;
					}
				}
			}
			public override string ToString() { return Name; }
		}

		#region Static
		static float font_size = 9.0f, boxwidth = 24;
		public FloatRect region;
		// we'll be ignoring the right padding (width)
		static Padding padding = new Padding(18,3,6,3);
		static FloatPoint padding_topleft = FloatPoint.GetPaddingTopLeft(padding);
		static Bitmap font_img = fam3.efx_ico.rimshotdesign_font;
		static Color clr_line { get { return SystemColors.ControlLight; } }
		static Pen DottedPen
		{
			get
			{
				Pen pe = new Pen(clr_line,1.000f);
				pe.DashStyle = DashStyle.Dot;
				pe.DashPattern = new float[]{ 6.0f };
				return pe;
			}
		}
		static Color FixedColor = Color.Red;
		static LinearGradientBrush lgb { get { return new LinearGradientBrush(FloatPoint.Empty,new FloatPoint(boxwidth,0),Color.FromArgb(176,216,255),Color.White); } }
		static LinearGradientBrush lgc { get { return new LinearGradientBrush(FloatPoint.Empty,new FloatPoint(boxwidth,0),Color.FromArgb(0,127,255),Color.White); } }
		#endregion
		
		fontitem this[int index] { get { return (fontitem)ItemObjects[index]; } }
		fontitem CurrentFontItem { get { return this[Client.SelectedIndex]; } }

		IList ItemObjects;
	
		public int Stat(int i) { return i; }
		public Graphics Gqual(Graphics fx)
		{
			fx.InterpolationMode = InterpolationMode.HighQualityBicubic;
			fx.SmoothingMode = SmoothingMode.HighQuality;
			return fx;
		}
		public void Measure(object sender, MeasureItemEventArgs a)
		{
			if (a.Index==-1) return;
			FloatPoint hp = font_util.Measure(a.Index);
			if (hp==FloatPoint.Empty) return;
		}

		protected void SelectedIndexChanged(object sender, EventArgs e)
		{
			Client.Font = font_util.CreateFont(Client.SelectedIndex);
		}
	
		public void drawtext(Graphics fx, int index)
		{
			if (index==-1) return;
			try{
				using (Font fnt = font_util.CreateFont(index,font_size))
				{
					fx.DrawImage(font_img,region.Location+2);
					using (Brush brsh = (this[index].IsFixed) ? new SolidBrush(FixedColor) : new SolidBrush(Client.ForeColor))
					{
						FloatPoint pointbase = region.Location +padding_topleft + new FloatPoint(0,fnt.GetHeight());
//						using (Pen dp = DottedPen)
//						{
//						fx.DrawLine(dp,pointbase,pointbase+new HPoint(region.Width,0));
//						}
						Gqual(fx).DrawString(this[index].Name,fnt,brsh,region.Location+padding_topleft);
					}
				}
			}catch{}
		}
		
		public void DoDrawItem ( object sender, DrawItemEventArgs args )
		{
			region = args.Bounds;
			args.DrawBackground();
			args.DrawFocusRectangle();
//			args.Graphics.SetClip(region);
			switch (args.State)
			{
			case DrawItemState.ComboBoxEdit: drawtext(args.Graphics, args.Index); break;
			case DrawItemState.HotLight:
			case DrawItemState.Selected:
			case DrawItemState.Focus: drawtext(args.Graphics, args.Index); break;
			case DrawItemState.Default:
			default: drawtext(args.Graphics, args.Index); break;
			}
//			args.Graphics.ResetClip();
		}
		
		public override void Initialize()
		{
			base.Initialize();
			Client.DrawMode = DrawMode.OwnerDrawFixed;
			Client.DrawItem += new DrawItemEventHandler(DoDrawItem);
			font_util.InitializeFontCollection();
			ItemObjects = new List<fontitem>();
			Client.Items.Clear();
			//if (DesignMode) return;
			for ( int i = 0 ; i < font_util.Fonts.Length; i++ )
				ItemObjects.Add(new fontitem(i));
			Client.SetCoreItems(ItemObjects);
		}
		void Uninitialize() { font_util.UnInitializeFontCollection(); }
	
		public FontComboRenderer(FontCombo combo) : base(combo)
		{
			try { Initialize(); } catch (Exception e) {}
		}
		~FontComboRenderer() { Uninitialize(); }
		
	}
}
