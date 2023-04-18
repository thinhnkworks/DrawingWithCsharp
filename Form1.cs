namespace DrawingWithC_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private List<Entities.Point> points = new List<Entities.Point>();

		private Vector3 currentPosition;

		private int DrawIndex = -1;

		private bool active_drawing = false;

		private void drawing_MouseMove(object sender, MouseEventArgs e)
		{
			currentPosition = PointToCartesian(e.Location);
			label1.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
			label2.Text = string.Format("{0,0:F3}, {1,0:F3}", currentPosition.X, currentPosition.Y);
		}
		// convert system point to world point
		private Vector3 PointToCartesian(Point point)
		{
			return new Vector3(PixelToMl(point.X), PixelToMl(this.drawing.Height - point.Y));
		}
		// convert pixels to milimeters
		private float PixelToMl(float pixel)
		{
			return pixel * 25.4f / DPI;
		}

		private void drawing_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (active_drawing)
				{
					switch (DrawIndex)
					{
						case 0:
							points.Add(new Entities.Point(currentPosition));
							break;
					}
					drawing.Refresh();
				}
			}
		}

		private void drawing_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SetParameters(PixelToMl(drawing.Height));

			if (points.Count > 0)
			{
				foreach (Entities.Point p in points)
				{
					e.Graphics.DrawPoint(new Pen(Color.Red, 0), p);
				}
			}
		}

		private void pointButton_Click(object sender, EventArgs e)
		{
			DrawIndex = 0;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}

		private float DPI
		{
			get
			{
				using (var g = CreateGraphics()) return g.DpiX;
			}
		}
	}
}