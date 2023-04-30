using DrawingWithC_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Methods
{
	public class Method
	{
		public static Ellipse GetEllipse(Vector3 center, Vector3 firstPoint, Vector3 secondPoint, Pen pen)
		{
			double major = center.DistanceFrom(firstPoint);
			double minor = center.DistanceFrom(secondPoint);
			double angle = LineAngle(center, firstPoint);
			Ellipse elp = new Ellipse(center, major, minor, pen);
			elp.Rotation = angle;
			return elp;
		}
		public static LwPolyline GetPolygon(Vector3 center, Vector3 secondPoint, int sidesQty, int inscribed, Pen pen)
		{
			List<Entities.LwPolylineVertex> vertexes = new List<Entities.LwPolylineVertex>();
			double sides_angle = 360.0 / sidesQty;
			double radius = center.DistanceFrom(secondPoint);
			double lineAngle = LineAngle(center, secondPoint);

			if (inscribed == 1)
			{
				lineAngle -= sides_angle / 2.0;
				radius /= Math.Cos(sides_angle / 180.0 * Math.PI / 2.0);
			}

			for (int i = 0; i < sidesQty; i++)
			{
				double x = center.X + radius * Math.Cos(lineAngle / 180.0 * Math.PI);
				double y = center.Y + radius * Math.Sin(lineAngle / 180.0 * Math.PI);

				vertexes.Add(new Entities.LwPolylineVertex(x, y));
				lineAngle += sides_angle;
			}

			return new Entities.LwPolyline(vertexes, true, pen);
		}
		public static Circle GetCircleWith3Points(Vector3 p1, Vector3 p2, Vector3 p3)
		{
			double x1 = (p1.X + p2.X) / 2;
			double y1 = (p1.Y + p2.Y) / 2;
			double dx1 = p2.X - p1.X;
			double dy1 = p2.Y - p1.Y;

			double x2 = (p2.X + p3.X) / 2;
			double y2 = (p2.Y + p3.Y) / 2;
			double dx2 = p3.X - p2.X;
			double dy2 = p3.Y - p2.Y;

			Line line1 = new Line(new Vector3(x1, y1), new Vector3(x1 - dy1, y1 + dx1), new Pen(Color.Black, 1.0f));
			Line line2 = new Line(new Vector3(x2, y2), new Vector3(x2 - dy2, y2 + dx2), new Pen(Color.Black, 1.0f));

			Vector3 center = LineLineIntersection(line1, line2, true);

			double dx = center.X - p1.X;
			double dy = center.Y - p1.Y;

			double radius = Math.Sqrt(dx * dx + dy * dy);

			return new Circle(center, radius, new Pen(Color.Black, 1.0f));
		}
		public static Arc GetArcWith3Points(Vector3 p1, Vector3 p2, Vector3 p3, Pen pen)
		{
			double start, end;
			Arc result = new Arc();

			Circle c = GetCircleWith3Points(p1, p2, p3);

			if (c.Radius > 0)
			{
				if (DeterminePointOfLine(new Line(p1, p3, new Pen(Color.Black, 1.0f)), p2) < 0)
				{
					start = LineAngle(c.Center, p3);
					end = LineAngle(c.Center, p1);
				}
				else
				{
					start = LineAngle(c.Center, p1);
					end = LineAngle(c.Center, p3);
				}
				if (end > start)
				{
					end -= start;
				}
				else
				{
					end += 360 - start;
				}
				result = new Arc(c.Center, c.Radius, start, end, pen);
			}
			return result;
		}

		private static bool IsPointOnLine(Line line1, Vector3 point)
		{
			return IsEqual(line1.Length, line1.StartPoint.DistanceFrom(point) + line1.EndPoint.DistanceFrom(point));
		}
		private static double DeterminePointOfLine(Line line, Vector3 v)
		{
			return (v.X - line.StartPoint.X) * (line.EndPoint.Y - line.StartPoint.Y) - (v.Y - line.StartPoint.Y) * (line.EndPoint.X - line.StartPoint.X);
		}
		private static bool IsPointOnArc(Arc arc, Vector3 v)
		{
			Entities.Line line = new Entities.Line(arc.Center, v, new Pen(Color.Black, 1.0f));

			double angle = line.Angle;
			double start = arc.StartAngle;
			double end = (arc.EndAngle + arc.StartAngle) % 360.0;

			if ((start < end) && (start <= angle) && (angle <= end))
			{
				return true;
			}
			else if ((start > end) && (angle >= start) && (angle <= 360.0))
			{
				return true;
			}
			else if ((start > end) && (angle >= 0) && (angle <= end))
			{
				return true;
			}
			return false;
		}
		private static bool IsPointInPolyline(PointF[] cursor_rect, Vector3 point)
		{
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			path.AddPolygon(cursor_rect);
			return path.IsVisible(point.ToPointF);
		}

		#region Comparision

		public static bool IsEqual(double d1, double d2)
		{
			return IsEqual(d1, d2, Epsilon);
		}
		public static bool IsEqual(double d1, double d2, double epsilon)
		{
			return IsZero(d1 - d2, epsilon);
		}
		public static bool IsZero(double d, double epsilon)
		{
			return d >= -epsilon && d <= epsilon;
		}
		public static bool IsZero(double d)
		{
			return IsZero(d, Epsilon);
		}
		#endregion

		#region Intersections

		public static List<Vector3> LineEllipseIntersection(Line line, Ellipse ellipse)
		{
			double x1 = line.StartPoint.X;
			double y1 = line.StartPoint.Y;
			double x2 = line.EndPoint.X;
			double y2 = line.EndPoint.Y;

			double xc = ellipse.Center.X;
			double yc = ellipse.Center.Y;

			double a = ellipse.MajorAxis;
			double b = ellipse.MinorAxis;

			double angle = ellipse.Rotation * DegToRad;

			double X, Y;
			List<Vector3> result = new List<Vector3>();

			double x21 = x2 - x1;
			double y21 = y2 - y1;

			x1 -= xc;
			y1 -= yc;

			double sin = Math.Sin(angle);
			double cos = Math.Cos(angle);

			double A1 = b * b * cos * cos + a * a * sin * sin;
			double B1 = a * a * cos * cos + b * b * sin * sin;
			double C1 = 2 * (b * b - a * a) * sin * cos;

			double A = A1 * x21 * x21 + B1 * y21 * y21 + C1 * x21 * y21;
			double B = 2 * A1 * x1 * x21 + 2 * B1 * y1 * y21 + C1 * x1 * y21 + C1 * x21 * y1;
			double C = A1 * x1 * x1 + B1 * y1 * y1 + C1 * x1 * y1 - a * a * b * b;

			double Delta = B * B - 4 * A * C;

			List<double> t_value = new List<double>();

			if (Delta == 0)
			{
				t_value.Add(-B / 2 / A);
			}
			else if (Delta > 0)
			{
				t_value.Add((-B + Math.Sqrt(Delta)) / 2 / A);
				t_value.Add((-B - Math.Sqrt(Delta)) / 2 / A);
			}

			foreach (double t in t_value)
			{
				if ((t >= 0.0) && (t <= 1.0))
				{
					X = x1 + x21 * t + xc;
					Y = y1 + y21 * t + yc;
					result.Add(new Vector3(X, Y));
				}
			}
			return result;
		}
		public static List<Vector3> LineCircleIntersection(Line line, Circle circle)
		{
			List<Vector3> result = new List<Vector3>();
			double x1 = line.StartPoint.X;
			double y1 = line.StartPoint.Y;
			double x2 = line.EndPoint.X;
			double y2 = line.EndPoint.Y;

			double xc = circle.Center.X;
			double yc = circle.Center.Y;
			double r = circle.Radius;

			double dx = x2 - x1;
			double dy = y2 - y1;

			x1 -= xc;
			y1 -= yc;

			double A = dx * dx + dy * dy;
			double B = 2 * (x1 * dx + y1 * dy);
			double C = x1 * x1 + y1 * y1 - r * r;

			double Delta = B * B - 4 * A * C;

			List<double> t_values = new List<double>();

			if (Delta == 0)
			{
				t_values.Add(-B / 2 / A);
			}
			else if (Delta > 0)
			{
				t_values.Add((-B + Math.Sqrt(Delta)) / 2 / A);
				t_values.Add((-B - Math.Sqrt(Delta)) / 2 / A);
			}

			foreach (double t in t_values)
			{
				if ((t >= 0) && (t <= 1.0))
				{
					double X = x1 + dx * t + xc;
					double Y = y1 + dy * t + yc;
					result.Add(new Vector3(X, Y));
				}
			}
			return result;
		}
		public static Vector3 LineLineIntersection(Entities.Line line1, Entities.Line line2, bool extended = false)
		{
			Vector3 result;
			Vector3 p1 = line1.StartPoint;
			Vector3 p2 = line1.EndPoint;
			Vector3 p3 = line2.StartPoint;
			Vector3 p4 = line2.EndPoint;

			double dx12 = p2.X - p1.X;
			double dy12 = p2.Y - p1.Y;
			double dx34 = p4.X - p3.X;
			double dy34 = p4.Y - p3.Y;

			double denominator = (dy12 * dx34 - dx12 * dy34);
			double k1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;

			if (double.IsInfinity(k1))
			{
				return new Vector3(double.NaN, double.NaN);
			}

			result = new Vector3(p1.X + dx12 * k1, p1.Y + dy12 * k1);

			if (extended)
			{
				return result;
			}
			else
			{
				if (IsPointOnLine(line1, result) && IsPointOnLine(line2, result))
				{
					return result;
				}
				else
				{
					return new Vector3(double.NaN, double.NaN);
				}
			}
		}
		public static List<Vector3> LineArcIntersection(Line line, Arc arc)
		{
			List<Vector3> result = new List<Vector3>();
			List<Vector3> list = LineCircleIntersection(line, new Circle(arc.Center, arc.Radius, new Pen(Color.Black, 1.0f)));
			foreach (Vector3 v in list)
			{
				if (IsPointOnArc(arc, v))
				{
					result.Add(v);
				}
			}
			return result;
		}

		#endregion

		#region Calculate distance

		public static double DistanceFromLine(Line line, Vector3 point, out Vector3 closet, bool isExtended = false)
		{
			double x1 = line.StartPoint.X;
			double y1 = line.StartPoint.Y;
			double x2 = line.EndPoint.X;
			double y2 = line.EndPoint.Y;

			double x = point.X;
			double y = point.Y;

			double dx = x2 - x1;
			double dy = y2 - y1;

			if ((dx == 0) && (dy == 0))
			{
				closet = line.StartPoint;
				dx = x - x1;
				dy = y - y1;
				return Math.Sqrt(dx * dx + dy * dy);
			}

			double k = ((x - x1) * dx + (y - y1) * dy) / (dx * dx + dy * dy);

			closet = new Vector3(x1 + k * dx, y1 + k * dy);
			dx = x - closet.X;
			dy = y - closet.Y;

			if (!isExtended)
			{
				if (k < 0)
				{
					closet = new Vector3(x1, y1);
					dx = x - x1;
					dy = y - y1;

				}
				else if (k > 1)
				{
					closet = new Vector3(x2, y2);
					dx = x - x2;
					dy = y - y2;
				}
			}
			return Math.Sqrt(dx * dx + dy * dy);
		}
		public static double DistancePointToEllipse(Ellipse ellipse, Vector3 point, out Vector3 pointOnEllipse)
		{
			double a = ellipse.MajorAxis;
			double b = ellipse.MinorAxis;
			double angle = ellipse.Rotation * DegToRad;
			double sin = Math.Sin(angle);
			double cos = Math.Cos(angle);
			double xc = ellipse.Center.X;
			double yc = ellipse.Center.Y;

			double x1 = point.X;
			double y1 = point.Y;

			x1 -= xc;
			y1 -= yc;

			double xr = cos * x1 + sin * y1;
			double yr = -sin * x1 + cos * y1;

			double xt = cos;
			double yt = sin;
			double x = 0, y = 0;

			foreach (int i in Enumerable.Range(0, 3))
			{
				x = a * xt;
				y = b * yt;

				double ex = (a * a - b * b) * Math.Pow(xt, 3) / a;
				double ey = (b * b - a * a) * Math.Pow(yt, 3) / b;

				double xq = Math.Abs(xr) - ex;
				double yq = Math.Abs(yr) - ey;

				double nx = Math.Sqrt((x - ex) * (x - ex) + (y - ey) * (y - ey)) / Math.Sqrt(xq * xq + yq * yq);

				xt = (xq * nx + ex) / a;
				yt = (yq * nx + ey) / b;

				double nt = Math.Sqrt(xt * xt + yt * yt);
				xt /= nt;
				yt /= nt;
			}

			x = CopySign(x, xr);
			y = CopySign(y, yr);

			pointOnEllipse = new Vector3(cos * x - sin * y + xc, sin * x + cos * y + yc);

			return point.DistanceFrom(pointOnEllipse);
		}
		public static double DistancePointToCircle(Circle circle, Vector3 point, out Vector3 pointOnCircle)
		{
			double d = point.DistanceFrom(circle.Center) - circle.Radius;
			double angle = LineAngle(point, circle.Center);

			double x = d * Math.Cos(angle * DegToRad) + point.X;
			double y = d * Math.Sin(angle * DegToRad) + point.Y;

			pointOnCircle = new Vector3(x, y);

			return point.DistanceFrom(pointOnCircle);
		}
		public static double DistancePointToArc(Arc arc, Vector3 point, out Vector3 pointOnArc)
		{
			double d = point.DistanceFrom(arc.Center) - arc.Radius;
			double angle = LineAngle(point, arc.Center);

			double x = d * Math.Cos(angle * DegToRad) + point.X;
			double y = d * Math.Sin(angle * DegToRad) + point.Y;

			Vector3 result = new Vector3(x, y);

			if (IsPointOnArc(arc, result))
			{
				pointOnArc = result;
			}
			else
			{
				double dist1 = arc.StartPoint.DistanceFrom(point);
				double dist2 = arc.EndPoint.DistanceFrom(point);

				if (dist1 < dist2)
				{
					d = dist1;
					pointOnArc = arc.StartPoint;
				}
				else
				{
					d = dist2;
					pointOnArc = arc.EndPoint;
				}
			}
			return Math.Abs(d);
		}
		public static double DistancePointToLwPolyline(LwPolyline polyline, Vector3 point, out Vector3 pointOnLwPolyline)
		{
			double result = double.MaxValue;
			pointOnLwPolyline = new Vector3();

			foreach (EntityObject entity in polyline.Explode())
			{
				switch (entity.Type)
				{
					case EntityType.Line:
						double d = DistanceFromLine(entity as Entities.Line, point, out Vector3 v);
						if (d < result)
						{
							pointOnLwPolyline = v;
							result = d;
						}
						break;
					case EntityType.Arc:
						d = DistancePointToArc(entity as Entities.Arc, point, out v);
						if (d < result)
						{
							pointOnLwPolyline = point;
							result = d;
						}
						break;
				}
			}
			return result;
		}
		#endregion

		#region Custom Functions

		private static double CopySign(double a, double b)
		{
			return a * Math.Sign(b);
		}
		public static Bitmap SetCursor(int index, float size, Color color)
		{
			Bitmap bitmap = new Bitmap((int)size + 1, (int)size + 1);
			float cx = size / 2;
			float cy = size / 2;
			PointF[] points;

			using (Graphics gr = Graphics.FromImage(bitmap))
			{
				gr.Clear(Color.Transparent);
				switch (index)
				{
					case 0: // default cursor
						break;
					case 1: // drawing cursor
						points = new PointF[]
						{
							new PointF(cx,0),
							new PointF(2*cx, cy),
							new PointF(cx, 2*cy),
							new PointF(0,cy)
						};
						gr.DrawLine(new Pen(color, 2.0f), points[0], points[2]);
						gr.DrawLine(new Pen(color, 2.0f), points[1], points[3]);
						break;
					case 2: // editing cursor
						points = new PointF[]
						{
							new PointF(1,1),
							new PointF(2*cx-1, 1),
							new PointF(2*cx-1, 2*cy-1),
							new PointF(1, 2*cy-1),
						};
						gr.DrawPolygon(new Pen(color, 2.0f), points);
						break;
				}
				return bitmap;
			}
		}
		public static double Epsilon = 1e-12;
		public static double DegToRad = Math.PI / 180.0f;
		public static Entities.LwPolyline PointToRect(Vector3 firstCorner, Vector3 secondCorner, out int dir, Pen pen)
		{
			double x = Math.Min(firstCorner.X, secondCorner.X);
			double y = Math.Min(firstCorner.Y, secondCorner.Y);

			double width = Math.Abs(secondCorner.X - firstCorner.X);
			double height = Math.Abs(secondCorner.Y - firstCorner.Y);

			double dx = secondCorner.X - firstCorner.X;

			List<Entities.LwPolylineVertex> vertexes = new List<Entities.LwPolylineVertex>();
			vertexes.Add(new Entities.LwPolylineVertex(x, y)); ;
			vertexes.Add(new Entities.LwPolylineVertex(x + width, y));
			vertexes.Add(new Entities.LwPolylineVertex(x + width, y + height));
			vertexes.Add(new Entities.LwPolylineVertex(x, y + height));

			if (dx > 0)
				dir = 1;
			else if (dx < 0)
				dir = 2;
			else
				dir = -1;

			return new LwPolyline(vertexes, true, pen);
		}
		public static double LineAngle(Vector3 start, Vector3 end)
		{
			double angle = Math.Atan2((end.Y - start.Y), (end.X - start.X)) * 180.0 / Math.PI;
			if (angle < 0.0)
			{
				angle += 360.0;
			}
			return angle;
		}

		#endregion

		#region Selection

		public static int GetSegmentIndex(List<EntityObject> entities, Vector3 mousePosition, PointF[] cursor_rect, out Vector3 PointOnSegment)
		{
			bool flags = false;
			Vector3 poSegment = new Vector3();

			for (int i = 0; i < entities.Count; i++)
			{
				switch (entities[i].Type)
				{
					case EntityType.Arc:
						double d = DistancePointToArc(entities[i] as Arc, mousePosition, out poSegment);
						break;
					case EntityType.Circle:
						d = DistancePointToCircle(entities[i] as Circle, mousePosition, out poSegment);
						break;
					case EntityType.Ellipse:
						d = DistancePointToEllipse(entities[i] as Ellipse, mousePosition, out poSegment);
						break;
					case EntityType.Line:
						d = DistanceFromLine(entities[i] as Line, mousePosition, out poSegment);
						break;
					case EntityType.LwPolyline:
						d = DistancePointToLwPolyline(entities[i] as LwPolyline, mousePosition, out poSegment);
						break;
				}
				if (!flags)
				{
					if (IsPointInPolyline(cursor_rect, poSegment))
					{
						PointOnSegment = poSegment;
						flags = true;
						entities[i].Select();
						return i;
					}
				}
			}
			PointOnSegment = Vector3.NaN;
			return -1;
		}
		public static void Modify1Selection(int modifyIndex, List<EntityObject> entities, Vector3 fromPoint, Vector3 toPoint)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].IsSelected)
				{
					switch (modifyIndex)
					{
						case 0: // copy
							entities.Add(entities[i].CopyOrMove(fromPoint, toPoint) as EntityObject);
							break;
						case 1: // move
							entities[i] = entities[i].CopyOrMove(fromPoint, toPoint) as EntityObject;
							entities[i].DeSelect();
							break;
					}
				}
			}
		}

		#endregion
	}
}
