/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using drawing;
using drawing.render.surface;

namespace System.Cor3.Forms.rtf
{
	
	public class MarginRenderer : BufferedRenderer
	{
		public ContextMenu cmenu;
		FPoint MousePoint { get { return Client.PointToClient(Control.MousePosition); } }
		float XMouse { get { return MousePoint.X; } }
		float XMouseScaled { get { return XMouse/(fu); } }
		static public MenuItem MakeUnitItem(float value, string name, EventHandler e)
		{
			MenuItem m_item = new MenuItem(name,e);
			m_item.Tag = value;
			return m_item;
		}
		MenuItem m_0125, m_0250, m_0500, m_0750, m_1000;
		const string me = "me";
		const float fu = 80f; // should depend on the selected rtf component's tabs
							// and also the rendering units?
		public float scaler = 0.25f;
		//
		float snap = 1f;
		public float SnapToUnits { get { return snap; } set { snap=value; } }
		Pen Pen1 { get { return new Pen(SystemColors.ControlDarkDark,0.5f); } }
		Pen Pen2 { get { return new Pen(Color.Red,1f); } }
		Pen Pen2B { get { return new Pen(Color.FromArgb(0,127,255),1f); } }
		Pen Pen2C { get { return new Pen(Color.FromArgb(0,127,255),1f); } }
		Pen Pen3 { get { Pen x = new Pen(Color.FromArgb(127,0,127,255),2f); x.Alignment = PenAlignment.Outset; x.LineJoin = LineJoin.Round; return x; } }
		Brush BW { get { return new SolidBrush(Color.White); } }
		Brush BB { get { return new SolidBrush(Color.Black); } }
		StringFormat rsf = new StringFormat(StringFormatFlags.LineLimit);
		StringFormat RulerStringFormat { get { return rsf; } }
		Ruler Client;
		rtf_info_typ rinfo;
		rtf_info_typ RtfInfo { get { return rinfo; } set { rinfo = value; } }
		public void GetCursor()
		{
			
		}
		public void Update()
		{
			RtfInfo = new rtf_info_typ(Client.RTF);
		}
		public void eMarginButton(object sender, EventArgs e)
		{
			
		}
		MenuItem[] MakeMenu(params float[] value)
		{
		m_0125 = MakeUnitItem(0.125f,"Eighth Inch",eMarginButton);
		m_0250 = MakeUnitItem(0.25f,"Quarter Inch",eMarginButton);
		m_0500 = MakeUnitItem(0.5f,"Half Inch",eMarginButton);
		m_0750 = MakeUnitItem(0.75f,"Three-Quarter Inch",eMarginButton);
		m_1000 = MakeUnitItem(1f,"Inch",eMarginButton);
		return new MenuItem[]{m_0125,m_0250,m_0500,m_0750,m_1000};
		}
		void eRightClick(object s, MouseEventArgs e)
		{
			if (e.Button== MouseButtons.Right)
			{
				cmenu.Show(Client,Client.PointToClient(Control.MousePosition));
			}
		}
		public MarginRenderer(Ruler rtc) : base(rtc)
		{
			Client = rtc;
			Client.MouseMove += delegate { Update(); Client.Invalidate(); };
			Client.RTF.SelectionChanged += delegate{ Update(); Client.Invalidate(); };
			Client.MouseUp += eRightClick;
			rsf.LineAlignment = StringAlignment.Far;
			rsf.Alignment = StringAlignment.Near;
			cmenu = new ContextMenu(MakeMenu());
		}
		FPoint C { get { return Client.ClientSize; } }

		public GraphicsPath CursorPath
		{
			get {
				GraphicsPath gp = new GraphicsPath();
				float cur = (float)Client.PointToClient(System.Windows.Forms.Control.MousePosition).X;
				gp.AddLine(cur,0,cur,C.Y); gp.StartFigure();
				return gp;
			}
		}
		public GraphicsPath RulerPath
		{
			get {
				GraphicsPath gp = new GraphicsPath();
				float f = (fu*scaler) * (Client.RTF.ZoomFactor*scaler);
				do {
					gp.AddLine(f,0,f,C.Y); gp.StartFigure();
				} while ( (f += (fu*scaler)) < C.X);
				return gp;
			}
		}

		public bool HasTabPath
		{
			get {
			
				if (Client.RTF==null) return false;
				if (!RtfInfo.HasSelection) return false;
				if (RtfInfo.SelectionTabs==null) return false;
				return true;
			}
		}
		public GraphicsPath TabsPath
		{
			get {
				GraphicsPath gp = new GraphicsPath();
				if (!HasTabPath) return gp;
				for (int f=0;f<RtfInfo.SelectionTabs.Length; f++)
				{
					gp.AddLine(RtfInfo.SelectionTabs[f],0,RtfInfo.SelectionTabs[f],C.Y); gp.StartFigure();
					
				}
				return gp;
			}
		}
		public GraphicsPath MarginsPath
		{
			get {
				GraphicsPath gp = new GraphicsPath();
				FPoint ml,mc,mr;
				float y1 = 0, y2 = Client.ClientSize.Height;
				FPoint ml1 = new FPoint(RtfInfo.SelectionIndent,y1);
				FPoint ml2 = new FPoint(RtfInfo.SelectionIndent,y2);
				FPoint mc1 = new FPoint(RtfInfo.SelectionRightIndent,y1);
				FPoint mc2 = new FPoint(RtfInfo.SelectionRightIndent,y2);
				FPoint mh1 = new FPoint(RtfInfo.SelectionHang,y1);
				FPoint mh2 = new FPoint(RtfInfo.SelectionHang,y2);
				gp.AddLine(ml1,ml2); gp.StartFigure();
				gp.AddLine(mc1,mc2); gp.StartFigure();
				gp.AddLine(mh1,mh2); gp.StartFigure();
				return gp;
			}
		}
		public GraphicsPath RulerLabels
		{
			get {
				GraphicsPath gp = new GraphicsPath();
				float f = (fu*scaler) * Client.RTF.ZoomFactor;
				do {
					gp.AddString(
						string.Format("{0:##0.00}",f/(fu)),
						Client.Font.FontFamily, (int)Client.Font.Style,Client.Font.Size,
						new FPoint(f,C.Y),
						RulerStringFormat
					);
				} while ( (f +=  (fu*scaler)) < C.X);
				return gp;
			}
		}
		public GraphicsPath Label2
		{
			get {
				GraphicsPath gp = new GraphicsPath();
				gp.AddString(
					string.Format("{0}",XMouseScaled),
					Client.Font.FontFamily, (int)Client.Font.Style,Client.Font.Size,
					new FPoint(0,C.Y),
					RulerStringFormat
				);
				return gp;
			}
		}

		public override void Render(Graphics fx)
		{
			fx.SmoothingMode = SmoothingMode.HighQuality;
			fx.InterpolationMode = InterpolationMode.HighQualityBicubic;
			base.Render(fx);
			using (Pen p = Pen1) fx.DrawPath(p,RulerPath);
			using (Pen px = Pen3) fx.DrawPath(px,RulerLabels);
			using (Brush b = BW) fx.FillPath(b,RulerLabels);
			using (Pen px = Pen3) fx.DrawPath(px,Label2);
			using (Pen px = Pen2) fx.DrawPath(px,CursorPath);
			if (HasTabPath) using (Pen px = Pen2B) fx.DrawPath(px,TabsPath);
			if (HasTabPath) using (Pen px = Pen2C) fx.DrawPath(px,MarginsPath);
			using (Brush b = BW) fx.FillPath(b,Label2);
		}
		
	}
}
