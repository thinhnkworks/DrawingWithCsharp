using System.Drawing;
using System.Drawing.Drawing2D;

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

		public static Pen pen = new Pen(Color.Blue, 1.0f);
		public static Pen grayPen = new Pen(Color.Gray, 1.0f);

		private List<Entities.Point> points = new List<Entities.Point>();
		private List<Entities.Line> lines = new List<Entities.Line>();
		private List<Entities.Circle> circles = new List<Entities.Circle>();
		private List<Entities.Ellipse> ellipses = new List<Entities.Ellipse>();
		private List<Entities.Arc> arcs = new List<Entities.Arc>();
		private List<Entities.LwPolyline> polylines = new List<Entities.LwPolyline>();

		private Vector3 currentPosition;
		private Vector3 firstPoint;
		private Vector3 secondPoint;
		private Point firstCorner;
		private Entities.LwPolyline tempPolyline = new Entities.LwPolyline();

		// polygon settings
		public static int direction;
		public static int sidesQty = 5;
		public static int inscribed = 1;

		// enable and disable drawing
		private int DrawIndex = -1;
		private bool active_drawing = false;
		private int clickNum = 1;

		// scroll settings
		private float XScroll;
		private float YScroll;
		private float ScaleFactor = 1.0f;

		// zoom settings
		private bool active_zoom = false;
		private int zoomClick = 1;
		private float x1, y1, x2, y2;

		// canvas size
		private SizeF drawingSize = new SizeF(290, 123);

		#region DRAWING PANEL EVENTS

		private void drawing_MouseMove(object sender, MouseEventArgs e)
		{
			// when mouse moving through drawing panel,
			// assign mouseLocation to currentPosition
			currentPosition = PointToCartesian(e.Location);
			label2.Text = string.Format("{0,0:F3}, {1,0:F3}", currentPosition.X, currentPosition.Y);

			x1 = e.Location.X;
			x2 = drawing.ClientSize.Width - x1;
			y1 = e.Location.Y;
			y2 = drawing.ClientSize.Height - y1;

			// refresh drawing panel when moving mouse
			drawing.Refresh();
		}
		private void drawing_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (active_zoom)
				{
					switch (zoomClick)
					{
						case 1:
							firstCorner = e.Location;
							zoomClick++;
							break;
						case 2:
							SetZoomWin(firstCorner, e.Location);
							active_zoom = false;
							zoomClick = 1;
							break;
					}
				}
				if (active_drawing && !active_zoom)
				{
					// 0: for drawing point
					// 1: for drawing line
					// 2: for drawing circle
					// 3: for drawing ellipse
					// 4: for drawing circle with 3 points
					// 5: for drawing arc
					// 6: for drawing polyline
					// 7: for drawing rectangle
					// 8: for drawing polygon
					switch (DrawIndex)
					{
						case 0:
							points.Add(new Entities.Point(currentPosition));
							break;
						case 1: // line
							switch (clickNum)
							{
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
						case 2: // circle
							switch (clickNum)
							{
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
						case 3: // ellipse
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
									break;
							}
							break;
						case 5: // arc
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
									clickNum = 1;
									break;
							}
							break;
						case 6: // polyline
							firstPoint = currentPosition;
							tempPolyline.Vertexes.Add(new Entities.LwPolylineVertex(firstPoint.ToVector2));
							clickNum = 2;
							break;
						case 7: // rectangle
							switch (clickNum)
							{
								case 1:
									firstPoint = currentPosition;
									clickNum++;
									break;
								case 2:
									polylines.Add(Methods.Method.PointToRect(firstPoint, currentPosition, out direction));
									clickNum = 1;
									break;
							}
							break;
						case 8: // polygon
							switch (clickNum)
							{
								case 1:
									firstPoint = currentPosition;
									clickNum++;
									break;
								case 2:
									polylines.Add(Methods.Method.GetPolygon(firstPoint, currentPosition, sidesQty, inscribed)); ;
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
				case 7: // rect
					if (clickNum == 2)
					{
						Entities.LwPolyline lw = Methods.Method.PointToRect(firstPoint, currentPosition, out direction);
						e.Graphics.DrawPolyline(grayPen, lw);
					}
					break;
				case 8: // polygon
					if (clickNum == 2)
					{
						Entities.Line line = new Entities.Line(firstPoint, currentPosition);
						e.Graphics.DrawLine(grayPen, line);
						Entities.LwPolyline lw = Methods.Method.GetPolygon(firstPoint, currentPosition, sidesQty, inscribed);
						e.Graphics.DrawPolyline(grayPen, lw);
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
		private void drawing_MouseWheel(object sender, MouseEventArgs e)
		{
			float cx = drawing.ClientSize.Width / 2.0f;
			float cy = drawing.ClientSize.Height / 2.0f;

			float w = (x1 < cx) ? Math.Min(x1, x2) * 2.0f : Math.Max(x1, x2) * 2.0f;
			float h = (y1 < cy) ? Math.Max(y1, y2) * 2.0f : Math.Min(y1, y2) * 2.0f;

			float scale = (e.Delta < 0) ? 1 / 1.25f : 1.25f;

			ScaleFactor *= scale;

			float width = w * scale;
			float height = h * scale;

			float wl = (w - width) / 2;
			float hl = (h - height) / 2;

			XScroll = XScroll * scale - PixelToMl(wl);
			YScroll = YScroll * scale + PixelToMl(hl);

			SetScrollbarValues();
		}
		#endregion

		#region SHAPES BUTTON

		private void btnPoint_Click(object sender, EventArgs e)
		{
			// index 0 for drawing point
			DrawIndex = 0;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnLine_Click(object sender, EventArgs e)
		{
			// index 1 for drawing line
			DrawIndex = 1;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnCircle_Click(object sender, EventArgs e)
		{
			// index 2 for drawing circle
			DrawIndex = 2;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnEllipse_Click(object sender, EventArgs e)
		{
			// index 3 for drawing ellipse
			DrawIndex = 3;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnArc_Click(object sender, EventArgs e)
		{
			// index 5 for drawing arc
			DrawIndex = 5;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnPolyline_Click(object sender, EventArgs e)
		{
			// index 6 for drawing polyline
			DrawIndex = 6;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnRectangle_Click(object sender, EventArgs e)
		{
			// index 7 for drawing rectangle
			DrawIndex = 7;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnPolygon_Click(object sender, EventArgs e)
		{
			// index 8 for drawing polygon
			DrawIndex = 8;
			active_drawing = true;
			ActiveCursor(1);
		}
		private void btnSettings_Click(object sender, EventArgs e)
		{
			var settings = new SettingsForm();
			settings.Show();
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
		// convert milimeters to pixels
		private float MlToPixel(float millimeter)
		{
			return millimeter / 25.4f * DPI;
		}

		#endregion

		#region CUSTOM FUNCTIONS

		private void CancelAll(int index = 1)
		{
			DrawIndex = -1;
			active_drawing = false;
			ActiveCursor(0);
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
		private void ActiveCursor(int index, float size = 12)
		{
			Cursor cursor = Cursors.Default;
			if (index > 0)
			{
				cursor = new Cursor(Methods.Method.SetCursor(index, MlToPixel(size), Color.Red).GetHicon());
			}
			drawing.Cursor = cursor;
		}
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
		private void SetScrollbarValues()
		{
			float width = Math.Max(0, drawingSize.Width * ScaleFactor - PixelToMl(drawing.ClientSize.Width)) + 50 * ScaleFactor;
			float height = Math.Max(0, drawingSize.Height * ScaleFactor - PixelToMl(drawing.ClientSize.Height)) + 50 * ScaleFactor;

			hScrollBar.Maximum = (int)width;
			hScrollBar.Minimum = -(int)(50 * ScaleFactor);

			vScrollBar.Maximum = (int)(50 * ScaleFactor);
			vScrollBar.Minimum = -(int)height;

			try
			{
				hScrollBar.Minimum = (int)Math.Min(XScroll, hScrollBar.Minimum);
				hScrollBar.Maximum = (int)Math.Max(XScroll, hScrollBar.Maximum);
				vScrollBar.Minimum = (int)Math.Min(YScroll, vScrollBar.Minimum);
				vScrollBar.Maximum = (int)Math.Max(YScroll, vScrollBar.Maximum);

				hScrollBar.Value = (int)XScroll;
				vScrollBar.Value = (int)YScroll;
			}
			catch { }
			drawing.Refresh();
		}

		#endregion

		#region SCROLL SETTINGS

		private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
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

		#region ZOOM FUNCTIONS

		private void SetZoomWin(Point firstCorner, Point secondCorner)
		{
			Vector3 p1 = PointToCartesian(firstCorner);
			Vector3 p2 = PointToCartesian(secondCorner);

			float minX = Math.Min(p1.ToPointF.X, p2.ToPointF.X);
			float minY = Math.Min(p1.ToPointF.Y, p2.ToPointF.Y);

			float w = Math.Abs(firstCorner.X - secondCorner.X);
			float h = Math.Abs(firstCorner.Y - secondCorner.Y);

			float width = drawing.ClientSize.Width / w;
			float height = drawing.ClientSize.Height / h;

			float min = Math.Min(width, height);

			ScaleFactor *= min;

			float wl = (drawing.ClientSize.Width - w * min) / 2;
			float hl = (drawing.ClientSize.Height - h * min) / 2;

			XScroll = ScaleFactor * minX - PixelToMl(wl);
			YScroll = -ScaleFactor * minY - PixelToMl(hl);

			SetScrollbarValues();
		}
		private void SetZoomInOut(int index)
		{
			float scale = (index == 0) ? 1 / 1.25f : 1.25f;

			ScaleFactor *= scale;

			float width = drawing.ClientSize.Width * scale;
			float height = drawing.ClientSize.Height * scale;

			float wl = (drawing.ClientSize.Width - width) / 2;
			float hl = (drawing.ClientSize.Height - height) / 2;

			XScroll = XScroll * scale - PixelToMl(wl);
			YScroll = YScroll * scale + PixelToMl(hl);
		}
		private void ZoomEvents(int index)
		{
			switch (index)
			{
				case 0: // zoom out
				case 1: // zoom in
					SetZoomInOut(index);
					break;
			}
		}
		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			ZoomEvents(1);
			drawing.Refresh();
		}
		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			ZoomEvents(0);
			drawing.Refresh();
		}

		#endregion


	}
}