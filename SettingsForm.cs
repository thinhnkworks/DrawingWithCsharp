using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingWithC_
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		public Color PenColor { get; private set; }
		public int PenSize { get; private set; }
		public DashStyle PenStyle { get; private set; }

		public Color FillColor { get; private set; }

		public int SidesQty { get; private set; }
		public int Inscribed { get; private set; }


		private void btnPenSettings_Click(object sender, EventArgs e)
		{
			panelPenSettings.BringToFront();
			btnPenSettings.ForeColor = Color.Gray;
			btnBrushSettings.ForeColor = Color.Black;
			btnPolygonSettings.ForeColor = Color.Black;
		}

		private void btnBrushSettings_Click(object sender, EventArgs e)
		{
			panelBrushSettings.BringToFront();
			btnPenSettings.ForeColor = Color.Black;
			btnBrushSettings.ForeColor = Color.Gray;
			btnPolygonSettings.ForeColor = Color.Black;
		}

		private void btnPolygonSettings_Click(object sender, EventArgs e)
		{
			btnPenSettings.ForeColor = Color.Black;
			btnBrushSettings.ForeColor = Color.Black;
			btnPolygonSettings.ForeColor = Color.Gray;
			panelPolygonSettings.BringToFront();
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			btnPenSettings.ForeColor = Color.Gray;
			panelPenSettings.BringToFront();

			picPenColor.BackColor = GraphicsForm.pen.Color;
			nudPenSize.Value = Convert.ToInt32(GraphicsForm.pen.Width);

			cbbPenStyle.SelectedIndex = cbbPenStyle.FindString(Convert.ToString(GraphicsForm.pen.DashStyle));
			cbbPolygonStatus.SelectedIndex = GraphicsForm.inscribed;
			nudPolygonSides.Value = GraphicsForm.sidesQty;
		}

		private void btnPenColorWheel_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.AllowFullOpen = true;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				picPenColor.BackColor = colorDialog.Color;
			}
		}

		private void btnOKSettings_Click(object sender, EventArgs e)
		{
			// pen settings
			PenColor = picPenColor.BackColor;
			PenSize = Convert.ToInt32(nudPenSize.Value);
			switch (cbbPenStyle.Text)
			{
				case "Solid":
					PenStyle = DashStyle.Solid;
					break;
				case "Dash":
					PenStyle = DashStyle.Dash;
					break;
				case "Dash dot":
					PenStyle = DashStyle.DashDot;
					break;
				case "Dot":
					PenStyle = DashStyle.Dot;
					break;
			}

			// brush settings
			FillColor = picBrushColor.BackColor;

			// polygon settings
			SidesQty = Convert.ToInt32(nudPolygonSides.Text);
			Inscribed = cbbPolygonStatus.SelectedIndex;

			// update pen settings
			GraphicsForm.pen.Color = PenColor;
			GraphicsForm.pen.Width = PenSize;
			GraphicsForm.pen.DashStyle = PenStyle;
			GraphicsForm.picPenColor.BackColor = PenColor;

			if (SidesQty < 3)
			{
				MessageBox.Show("So canh phai nhieu hon 3", "Warning");
				nudPolygonSides.Focus();
			}
			else
			{
				// update polygon settings
				GraphicsForm.sidesQty = SidesQty;
				GraphicsForm.inscribed = Inscribed;
				Close();
			}
		}

		private void btnCancelSettings_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnBrushColorWheel_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.AllowFullOpen = true;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				picBrushColor.BackColor = colorDialog.Color;
			}
		}

	}
}
