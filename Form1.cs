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

		private List<Entities.Line> lines = new List<Entities.Line>();

		private Vector3 currentPosition;

		private Vector3 firstPoint;

		private int DrawIndex = -1;

		private bool active_drawing = false;

		private int clickNum = 1;

		#region drawing panel events
		private void drawing_MouseMove(object sender, MouseEventArgs e)
		{
			// when mouse moving through drawing panel
			// assign currentPosition to mouse location
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
						// 0: for drawing point
						// 1: for drawing line
						case 0:
							points.Add(new Entities.Point(currentPosition));
							break;
						case 1:
							switch (clickNum)
							{
								// 1: firstPoint of line
								// 2: endPoint of line
								case 1:
									firstPoint = currentPosition;
									points.Add(new Entities.Point(currentPosition));
									clickNum++;
									break;
								case 2:
									lines.Add(new Entities.Line(firstPoint, currentPosition));
									points.Add(new Entities.Point(currentPosition));
									firstPoint = currentPosition;
									clickNum = 1;
									break;
							}
							break;
					}
					// refresh drawing panel after mouse left-click
					drawing.Refresh();
				}
			}
		}

		private void drawing_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SetParameters(PixelToMl(drawing.Height));
			Pen pen = new Pen(Color.Blue, 0.1f);
			// draw all points in list points
			if (points.Count > 0)
			{
				foreach (Entities.Point p in points)
				{
					e.Graphics.DrawPoint(new Pen(Color.Red, 0), p);
				}
			}
			// draw all lines in list lines
			if (lines.Count > 0)
			{
				foreach (Entities.Line line in lines)
				{
					e.Graphics.DrawLine(pen, line);
				}
			}
		}
		#endregion

		#region button shapes
		private void pointButton_Click(object sender, EventArgs e)
		{
			// index 0 for drawing point
			DrawIndex = 0;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}

		private void lineBtn_Click(object sender, EventArgs e)
		{
			// index 1 for drawing line
			DrawIndex = 1;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		#endregion

		// get screen DPI
		private float DPI
		{
			get
			{
				using (var g = CreateGraphics()) return g.DpiX;
			}
		}
	}
}