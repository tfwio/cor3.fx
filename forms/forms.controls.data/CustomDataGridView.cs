using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace cor3.forms.controls.data
{
	/// http://flexlikedatagrid.codeplex.com
	public partial class CustomDataGridView : DataGridView
	{
		private int prevRowIndex;
		private int prevRowClickedIndex = -1;

		private Color customBackgroundColorLight = Color.FromArgb(51, 51, 51);
		private Color customBackgroundColorDark = Color.FromArgb(51, 51, 51);
		private Color customHeaderColorLight = Color.FromArgb(255, 255, 255);
		private Color customHeaderColorDark = Color.FromArgb(234, 234, 234);
		private LinearGradientMode customBackgroundColorGradient = LinearGradientMode.Horizontal;

		[Category("Appearance"), DefaultValue(typeof(Color), "1,51,51,51"), Description("First shade of background color.")]
		public string CustomBackgroundColorLight { get { return CustomDataGridView.GetStringFromColor(customBackgroundColorLight); } set { customBackgroundColorLight = CustomDataGridView.GetColorFromString(value); this.Invalidate(); } }
		[Category("Appearance"), DefaultValue(typeof(Color), "1,51,51,51"), Description("Second shade of background color.")]
		public string CustomBackgroundColorDark { get { return CustomDataGridView.GetStringFromColor(customBackgroundColorDark); } set { customBackgroundColorDark = CustomDataGridView.GetColorFromString(value); this.Invalidate(); } }
		[Category("Appearance"), DefaultValue(typeof(LinearGradientMode), "Horizontal"), Description("Background color gradient mode.")]
		public string CustomBackgroundColorGradient { get { return customBackgroundColorGradient.ToString(); } set { this.customBackgroundColorGradient = (LinearGradientMode)Enum.Parse(typeof(LinearGradientMode), value, true); } }
		private Color customCellColorLight = Color.FromArgb(69, 69, 69);
		private Color customCellColorDark = Color.FromArgb(69, 69, 69);
		[Category("Appearance"), DefaultValue(typeof(Color), "1,69, 69, 69"), Description("First shade of cell color.")]
		public string CustomCellColorLight { get { return CustomDataGridView.GetStringFromColor(customCellColorLight); } set { customCellColorLight = CustomDataGridView.GetColorFromString(value); this.Invalidate(); } }
		[Category("Appearance"), DefaultValue(typeof(Color), "1,69, 69, 69"), Description("Second shade of cell color.")]
		public string CustomCellColorDark { get { return CustomDataGridView.GetStringFromColor(customCellColorDark); } set { customCellColorDark = CustomDataGridView.GetColorFromString(value); this.Invalidate(); } }
		[Category("Appearance"), DefaultValue(typeof(Color), "1,255,255,255"), Description("First shade of header color.")]
		public string CustomHeaderColorLight { get { return CustomDataGridView.GetStringFromColor(customHeaderColorLight); } set { customHeaderColorLight = CustomDataGridView.GetColorFromString(value); this.Invalidate(); } }
		[Category("Appearance"), DefaultValue(typeof(Color), "1,234,234,234"), Description("First shade of header color.")]
		public string CustomHeaderColorDark { get { return CustomDataGridView.GetStringFromColor(customHeaderColorDark); } set { customHeaderColorDark = CustomDataGridView.GetColorFromString(value); this.Invalidate(); } }
		private Color customHoverColor = Color.FromArgb(178, 225, 255);
		[Category("Appearance"), DefaultValue(typeof(Color), "1,178,225,255"), Description("Mouse hover color.")]
		public string CustomHoverColor { get { return CustomDataGridView.GetStringFromColor(customHoverColor); } set { customHoverColor = CustomDataGridView.GetColorFromString(value); this.Invalidate(); } }

		public CustomDataGridView()
		{
			InitializeComponent();
			this.Font = new Font("Verdana", 8);
			//this.EnableHeadersVisualStyles = false;
			this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247,247,247);
			this.GridColor = Color.FromArgb(183, 186, 188);
			this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			//this.BorderStyle = BorderStyle.Fixed3D;
			this.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			//this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			//this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			this.AllowUserToResizeRows = false;
			//            this.MouseMove += new MouseEventHandler(CustomDataGridView_MouseMove);
			//            this.CellClick += new DataGridViewCellEventHandler(CustomDataGridView_CellClick);
			this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(127, 206, 255);
			this.RowHeadersWidth = 22;
		}

		void CustomDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex > -1 && e.RowIndex > -1)
			{
				if (e.RowIndex != this.prevRowClickedIndex)
				{
					this.Rows[e.RowIndex].Height = 100;
					if (prevRowClickedIndex > -1)
					{
						this.Rows[this.prevRowClickedIndex].Height = 22;

					}
					this.prevRowClickedIndex = e.RowIndex;
				}
			}
		}
		void CustomDataGridView_MouseMove(object sender, MouseEventArgs e)
		{
			int curRowIndex = this.HitTest(e.X, e.Y).RowIndex;
			if (curRowIndex >= 0 && curRowIndex != this.NewRowIndex)
			{
				if (this.prevRowIndex != -1 && curRowIndex != this.prevRowIndex)
				{
					if (curRowIndex % 2 == 0)
						this.Rows[this.prevRowIndex].DefaultCellStyle.BackColor = Color.White;
					else
						this.Rows[this.prevRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(247, 247, 247);
				}

				this.Rows[curRowIndex].DefaultCellStyle.BackColor = this.customHoverColor;
				this.prevRowIndex = curRowIndex;
			}
		}

		protected override void PaintBackground(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle gridBounds)
		{
			//base.PaintBackground(graphics, clipBounds, gridBounds);
			Brush customBrush = new LinearGradientBrush(clipBounds, this.customBackgroundColorLight, this.customBackgroundColorDark, this.customBackgroundColorGradient);
			graphics.FillRectangle(customBrush, clipBounds);
		}

		protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				Brush customBrush = new LinearGradientBrush(e.ClipBounds, this.customHeaderColorLight, this.customHeaderColorDark, LinearGradientMode.Vertical);
				e.Graphics.FillRectangle(customBrush, e.CellBounds);
				e.PaintContent(e.ClipBounds);
				e.CellStyle.ForeColor = Color.Black;
				e.Handled = true;
			}
			else
			{
				if (e.ColumnIndex == -1)
				{
					//Brush customBrush = new LinearGradientBrush(e.ClipBounds, this.customHeaderColorLight, this.customHeaderColorDark, LinearGradientMode.ForwardDiagonal);
					Brush customBrush;
					if (e.RowIndex % 2 == 0)
					{
						customBrush = new LinearGradientBrush(e.ClipBounds, Color.White, Color.White, LinearGradientMode.ForwardDiagonal);
						e.Graphics.FillRectangle(customBrush, e.CellBounds);
					}
					else
					{
						customBrush = new LinearGradientBrush(e.ClipBounds, Color.FromArgb(247, 247, 247), Color.FromArgb(247, 247, 247), LinearGradientMode.ForwardDiagonal);
						e.Graphics.FillRectangle(customBrush, e.CellBounds);
					}
					e.PaintContent(e.ClipBounds);

					if (e.RowIndex > -1)
					{
						//e.PaintBackground(e.ClipBounds, false);
						int row = e.RowIndex + 1;
						string rowNum = row.ToString();
						Single ofs = Convert.ToSingle(e.CellBounds.Height - this.FontHeight) / 2;
						RectangleF layoutRect = e.CellBounds;
						layoutRect.Inflate(0, -ofs);
						layoutRect.X += 10;
						layoutRect.Width -= 5;
						e.Graphics.DrawString(rowNum, this.Font, Brushes.Black, layoutRect);
					}
					e.Handled = true;
				}
			}
		}

		private static Color GetColorFromString(string colorString)
		{
			try
			{
				char[] delim = { ',' };
				string[] colorCodes = colorString.Split(delim);
				if (colorCodes.Length == 1) { return Color.FromName(colorCodes[0]); }
				else if (colorCodes.Length == 3)
				{
					int r = Convert.ToInt32(colorCodes[0]);
					int g = Convert.ToInt32(colorCodes[1]);
					int b = Convert.ToInt32(colorCodes[2]);
					return Color.FromArgb(r, g, b);
				}
				else if (colorCodes.Length == 4)
				{
					int A = Convert.ToInt32(colorCodes[0]);
					int r = Convert.ToInt32(colorCodes[1]);
					int g = Convert.ToInt32(colorCodes[2]);
					int b = Convert.ToInt32(colorCodes[3]);
					return Color.FromArgb(A,r, g, b);
				}
				else return Color.LightSteelBlue;
			}
			catch (Exception) { return Color.LightSteelBlue; }
		}
		private static string GetStringFromColor(Color controlColor)
		{
			return string.Format("{0},{1},{2},{3}",controlColor.A,controlColor.R,controlColor.G,controlColor.B);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
	}
}
