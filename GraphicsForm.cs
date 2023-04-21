namespace DrawingWithC_
{
	public partial class GraphicsForm : Form
	{
		public GraphicsForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		Pen pen = new Pen(Color.Blue, 1.0f);
		Pen grayPen = new Pen(Color.Gray, 1.0f);

		private List<Entities.Point> points = new List<Entities.Point>();
		private List<Entities.Line> lines = new List<Entities.Line>();
		private List<Entities.Circle> circles = new List<Entities.Circle>();
		private List<Entities.Ellipse> ellipses = new List<Entities.Ellipse>();
		private List<Entities.Arc> arcs = new List<Entities.Arc>();
		private List<Entities.LwPolyline> polylines = new List<Entities.LwPolyline>();

		private Vector3 currentPosition;
		private Vector3 firstPoint;
		private Vector3 secondPoint;
		private int direction;
		private Entities.LwPolyline tempPolyline = new Entities.LwPolyline();

		// enable and disable drawing
		private int DrawIndex = -1;
		private bool active_drawing = false;
		private int clickNum = 1;

		// scroll settings
		private float XScroll;
		private float YScroll;
		private float ScaleFactor = 1.0f;

		#region drawing panel events
		private void drawing_MouseMove(object sender, MouseEventArgs e)
		{
			// when mouse moving through drawing panel,
			// assign mouseLocation to currentPosition
			currentPosition = PointToCartesian(e.Location);
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
						// 3: for drawing ellipse
						// 4: for drawing circle with 3 points
						// 5: for drawing arc
						// 6: for drawing polyline
						// 7: for drawing rectangle
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
									//clickNum = 1
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
						case 5:
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
									Entities.Arc a = Methods.Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition);
									arcs.Add(a);
									CancelAll();
									break;
							}
							break;
						case 6:
							firstPoint = currentPosition;
							tempPolyline.Vertexes.Add(new Entities.LwPolylineVertex(firstPoint.ToVector2));
							clickNum = 2;
							break;
						case 7:
							switch (clickNum)
							{
								case 1:
									firstPoint = currentPosition;
									clickNum++;
									break;
								case 2:
									polylines.Add(Methods.Method.PointToRect(firstPoint, currentPosition, out direction));
									CancelAll();
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
			e.Graphics.SetParameters(XScroll, YScroll, ScaleFactor, PixelToMl(drawing.Height));

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

			// draw gray extended line
			switch (DrawIndex)
			{
				case 6: // polyline
				case 1: // line
					if (clickNum == 2)
					{
						Entities.Line line = new Entities.Line(firstPoint, currentPosition);
						e.Graphics.DrawLine(grayPen, line);
					}
					break;
				case 7: // rect
					if (clickNum == 2)
					{
						Entities.LwPolyline lw = Methods.Method.PointToRect(firstPoint, currentPosition, out direction);
						e.Graphics.DrawPolyline(grayPen, lw);
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
				case 5:
					switch (clickNum)
					{
						case 2:
							Entities.Line line = new Entities.Line(firstPoint, currentPosition);
							e.Graphics.DrawLine(grayPen, line);
							break;
						case 3:
							Entities.Arc a = Methods.Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition);
							e.Graphics.DrawArc(grayPen, a);
							break;
					}
					break;
			}

			// test line line intersection
			if (lines.Count > 0)
			{
				foreach (Entities.Line l1 in lines)
				{
					foreach (Entities.Line l2 in lines)
					{
						Vector3 v = Methods.Method.LineLineIntersection(l1, l2);
						Entities.Point p = new Entities.Point(v);
						e.Graphics.DrawPoint(new Pen(Color.Red, 0), p);
					}
				}
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

			// draw all arcs
			if (arcs.Count > 0)
			{
				foreach (Entities.Arc arc in arcs)
				{
					e.Graphics.DrawArc(pen, arc);
				}
			}

			// draw all LwPolyline
			if (polylines.Count > 0)
			{
				foreach (Entities.LwPolyline lw in polylines)
				{
					e.Graphics.DrawPolyline(pen, lw);
				}
			}
			// draw tempPolyline
			if (tempPolyline.Vertexes.Count > 1)
			{
				e.Graphics.DrawPolyline(pen, tempPolyline);
			}
		}

		#endregion

		#region SHAPES BUTTON

		private void btnPoint_Click(object sender, EventArgs e)
		{
			// index 0 for drawing point
			DrawIndex = 0;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		private void btnLine_Click(object sender, EventArgs e)
		{
			// index 1 for drawing line
			DrawIndex = 1;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		private void btnCircle_Click(object sender, EventArgs e)
		{
			// index 2 for drawing circle
			DrawIndex = 2;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		private void btnEllipse_Click(object sender, EventArgs e)
		{
			// index 3 for drawing ellipse
			DrawIndex = 3;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		private void btnArc_Click(object sender, EventArgs e)
		{
			// index 5 for drawing arc
			DrawIndex = 5;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		private void btnPolyline_Click(object sender, EventArgs e)
		{
			// index 6 for drawing polyline
			DrawIndex = 6;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}
		private void btnRectangle_Click(object sender, EventArgs e)
		{
			// index 7 for drawing rectangle
			DrawIndex = 7;
			active_drawing = true;
			drawing.Cursor = Cursors.Cross;
		}

		#endregion

		#region CONVERT UNIT

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
			return new Vector3((PixelToMl(point.X) + XScroll) / ScaleFactor, (PixelToMl(this.drawing.Height - point.Y) - YScroll) / ScaleFactor);
		}
		// convert pixels to milimeters
		private float PixelToMl(float pixel)
		{
			return pixel * 25.4f / DPI;
		}

		#endregion

		#region CUSTOM FUNCTIONS

		private void CancelAll(int index = 1)
		{
			DrawIndex = -1;
			active_drawing = false;
			drawing.Cursor = Cursors.Default;
			clickNum = 1;
			LwPolylineCloseStatus(index);
		}
		private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CancelAll();
		}
		private void btnCloseBoundary_Click(object sender, EventArgs e)
		{
			switch (DrawIndex)
			{
				case 2: // line
					break;
				case 6: // polyline
					CancelAll(2);
					break;
			}
		}

		#endregion

		#region SCROLL SETTINGS

		private void vScrollbar_Scroll(object sender, ScrollEventArgs e)
		{
			YScroll = (sender as VScrollBar).Value;
			drawing.Refresh();
		}

		private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
		{
			XScroll = (sender as HScrollBar).Value;
			drawing.Refresh();
		}

		#endregion

		private void LwPolylineCloseStatus(int index)
		{
			List<Entities.LwPolylineVertex> vertexes = new List<Entities.LwPolylineVertex>();
			foreach (Entities.LwPolylineVertex lw in tempPolyline.Vertexes)
			{
				vertexes.Add(lw);
			}
			if (vertexes.Count > 1)
			{
				switch (index)
				{
					case 1:
						if (vertexes.Count > 2)
						{
							polylines.Add(new Entities.LwPolyline(vertexes, true));
						}
						else
						{
							polylines.Add(new Entities.LwPolyline(vertexes, false));
						}
						break;
					case 2:
						polylines.Add(new Entities.LwPolyline(vertexes, true));
						break;
				}
			}
			tempPolyline.Vertexes.Clear();
		}

	}
}