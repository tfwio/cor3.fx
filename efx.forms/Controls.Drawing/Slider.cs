/**
 * 
 * User: tfw
 * Date: 11/10/2008
 * Time: 6:24 PM
 * 
**/
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using efx;
namespace Drawing.Forms.Controls
{
	public class Slider : GraphicControl
	{
		float fmin=0f,fmax=1f,fvalue=0.5f,fsm=0.05f,flrg=0.1f;
		/// <summary>Must be less then Maximum</summary>
		public float Minimum { get { return fmin; } set { fmin = value; } }
		/// <summary>Must be greater than Minimum</summary>
		public float Maximum { get { return fmax; } set { fmax = value; } }
		public float Value { get { return fvalue; } set { fvalue = value; } }
		public float IncrSmall { get { return fsm; } set { fsm = value; } }
		public float IncrLarge { get { return flrg; } set { flrg = value; } }
		public Slider() : base(new HGradient(HGradient.Alignment.Horizontal)) {}
		protected override void RenderBackground(Graphics gfx)
		{
			base.RenderBackground(gfx);
			if (IsHorizontal) for (float i = Minimum;  i < Maximum;  i+= IncrLarge) gfx.DrawLine(SystemPens.Highlight,i,0,i,Height);
			else for (float i = Minimum;  i < Maximum;  i+= IncrLarge) gfx.DrawLine(SystemPens.Highlight,0,GetScale(i),Width,i);
		}
		public bool IsHorizontal { get { return (BackGradient.Align==HGradient.Alignment.Horizontal)?true:false; } }

		public float ScaledPosition
		{
			get
			{
				return 0f;
			}
		}
		public float GetScale(float value_in)
		{
			if (IsHorizontal) return value_in/(float)ClientSize.Width;
			return value_in/(float)ClientSize.Height;
		}
	}
	public class SliderV : Slider { public SliderV() : base() {} }
	public class SliderH : Slider { public SliderH() : base() {  } }
}
