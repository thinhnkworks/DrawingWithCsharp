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

		Pen pen = new Pen(Color.Blue, 0.1f);
		Pen grayPen = new Pen(Color.Gray, 0.1f);

		private List<Entities.Point> points = new List<Entities.Point>();
		private List<Entities.Line> lines = new List<Entities.Line>();
		private List<Entities.Circle> circles = new List<Entities.Circle>();
		private List<Entities.Ellipse> ellipses = new List<Entities.Ellipse>();

		private Vector3 currentPosition;
		private Vector3 firstPoint;
		private Vector3 secondPoint;

		private int DrawIndex = -1;
		private bool active_drawing = false;
		private int clickNum = 1;

		#region drawing panel events
		private void drawing_MouseMove(object sender, MouseEventArgs e)
		{
			// when mouse moving through drawing panel,
			// assign mouseLocation to currentPosition
			currentPosition = PointToCartesian(e.Location);
			label1.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
			label2.Text = string.Format("{0,0:F3}, {1,0:F3}", currentPosition.X, currentPosition.Y);
			// refresh drawing panel when moving mouse
			drawing.Refresh();
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
						// 2: for drawing circle
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
						case 2:
							switch (clickNum)
							{
								// 1: firstPoint => center of circle
								// 2: currentPosition => calculate radius
								case 1:
									firstPoint = currentPosition;
									clickNum++;
									break;
								case 2:
									double r = firstPoint.DistanceFrom(currentPosition);
									circles.Add(new Entities.Circle(firstPoint, r));
									clickNum = 1;
									break;
							}
							break;
						case 3:
							switch (clickNum)
							{
								case 1:
									firstPoint = currentPosition;
									clickNum++;
									break;
								case 2:
									secondPoint = currentPosition;
									clickNum++;
									break;
								case 3:
									Entities.Ellipse ellipse = Methods.Method.GetEllipse(firstPoint, secondPoint, currentPosition);
									ellipses.Add(ellipse);
									clickNum = 1;
									active_drawing = false;
									drawing.Cursor = Cursors.Default;
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

			// draw extended line
			// show gray line when first click to simulate drawing 
			switch (DrawIndex)
			{
				case 1:
					if (clickNum == 2)
					{
						Entities.Line line = new Entities.Line(firstPoint, currentPosition);
						e.Graphics.DrawLine(grayPen, line);
					}
					break;
				case 2:
					if (clickNum == 2)
					{
						Entities.Line line = new Entities.Line(firstPoint, currentPosition);
						e.Graphics.DrawLine(grayPen, line);
						double r = firstPoint.DistanceFrom(currentPosition);
						Entities.Circle circle = new Entities.Circle(firstPoint, r);
						e.Graphics.DrawCircle(grayPen, circle);
					}
					break;
				case 3:
					switch (clickNum)
					{
						case 2:
							Entities.Line line = new Entities.Line(firstPoint, currentPosition);
							e.Graphics.DrawLine(grayPen, line);
							break;
						case 3:
							Entities.Line line1 = new Entities.Line(firstPoint, currentPosition);
							e.Graphics.DrawLine(grayPen, line1);

							Entities.Ellipse elp = Methods.Method.GetEllipse(firstPoint, secondPoint, currentPosition);
							e.Graphics.DrawEllipse(grayPen, elp);
							break;
					}
					break;
			}

			// draw all circles
			if (circles.Count > 0)
			{
				foreach (Entities.Circle circle in circles)
				{
					e.Graphics.DrawCircle(pen, circle);
				}
			}

			// draw all ellipses
			if (ellipses.Count > 0)
			{
				foreach (Entities.Ellipse elp in ellipses)
				{
					e.Graphics.DrawEllipse(pen, elp);
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
		private void circleBtn_Click(object sender, EventArgs e)
		{
			// index 2 for drawing circle
			DrawIndex = 2;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		private void ellipseBtn_Click(object sender, EventArgs e)
		{
			DrawIndex = 3;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		#endregion

		#region convert units
		// get screen DPI
		private float DPI
		{
			get
			{
				using (var g = CreateGraphics()) return g.DpiX;
			}
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
		#endregion

	}
}