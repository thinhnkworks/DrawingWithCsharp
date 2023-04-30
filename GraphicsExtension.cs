using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_
{
	public static class GraphicsExtension
	{
		private static float Height;
		private static float XScroll;
		private static float YScroll;
		private static float ScaleFactor;
		private static Pen extpen = new Pen(Color.Gray, 0);

		public static void SetParameters(this Graphics g, float xscroll, float yscroll, float scalefactor, float height)
		{
			XScroll = xscroll;
			YScroll = yscroll;
			ScaleFactor = scalefactor;
			Height = height;
			extpen.DashPattern = new float[] { 1.5f / ScaleFactor, 2.0f / ScaleFactor };
		}
		public static void SetTransform(this Graphics g)
		{
			g.PageUnit = GraphicsUnit.Millimeter;
			g.TranslateTransform(0, Height);
			g.ScaleTransform(ScaleFactor, -ScaleFactor);
			g.TranslateTransform(-XScroll / ScaleFactor, YScroll / ScaleFactor);
		}

		public static void DrawPoint(this Graphics g, Pen pen, Entities.Point point)
		{
			g.SetTransform();
			PointF p = point.Position.ToPointF;
			g.DrawEllipse(pen, p.X - 1, p.Y - 1, 2, 2);
			g.ResetTransform();
		}
		public static void DrawLine(this Graphics g, Pen pen, Entities.Line line)
		{
			g.SetTransform();
			if (!line.IsSelected)
			{
				g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
			}
			else
			{
				g.DrawLine(extpen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
			}
			g.ResetTransform();
		}
		public static void DrawCircle(this Graphics g, Pen pen, Entities.Circle circle)
		{
			float x = (float)(circle.Center.X - circle.Radius);
			float y = (float)(circle.Center.Y - circle.Radius);
			float d = (float)(circle.Diameter);

			g.SetTransform();
			if (!circle.IsSelected)
			{
				g.DrawEllipse(pen, x, y, d, d);
			}
			else
			{
				g.DrawEllipse(extpen, x, y, d, d);
			}
			g.ResetTransform();
		}
		public static void DrawEllipse(this Graphics g, Pen pen, Entities.Ellipse ellipse)
		{
			SetTransform(g);
			g.TranslateTransform(ellipse.Center.ToPointF.X, ellipse.Center.ToPointF.Y);
			g.RotateTransform((float)(ellipse.Rotation));
			if (!ellipse.IsSelected)
			{
				g.DrawEllipse(pen, -(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
			}
			else
			{
				g.DrawEllipse(extpen, -(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
			}
			g.ResetTransform();
		}
		public static void DrawArc(this Graphics g, Pen pen, Entities.Arc arc)
		{
			float x = (float)(arc.Center.X - arc.Radius);
			float y = (float)(arc.Center.Y - arc.Radius);
			float d = (float)(arc.Diameter);

			System.Drawing.RectangleF rect = new System.Drawing.RectangleF(x, y, d, d);

			g.SetTransform();
			if (!arc.IsSelected)
			{
				g.DrawArc(pen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
			}
			else
			{
				g.DrawArc(extpen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
			}
			g.ResetTransform();
		}
		public static void DrawPolyline(this Graphics g, Pen pen, Entities.LwPolyline polyline)
		{
			foreach (Entities.EntityObject entity in polyline.Explode())
			{
				if (!polyline.IsSelected)
				{
					g.DrawEntity(pen, entity);
				}
				else
				{
					g.DrawEntity(extpen, entity);
				}
			}
		}

		public static void DrawEntity(this Graphics g, Pen pen, Entities.EntityObject entity)
		{
			switch (entity.Type)
			{
				case Entities.EntityType.Arc:
					g.DrawArc(pen, entity as Entities.Arc);
					break;
				case Entities.EntityType.Circle:
					g.DrawCircle(pen, entity as Entities.Circle);
					break;
				case Entities.EntityType.Ellipse:
					g.DrawEllipse(pen, entity as Entities.Ellipse);
					break;
				case Entities.EntityType.Line:
					g.DrawLine(pen, entity as Entities.Line);
					break;
				case Entities.EntityType.LwPolyline:
					g.DrawPolyline(pen, entity as Entities.LwPolyline);
					break;
				case Entities.EntityType.Point:
					g.DrawPoint(pen, entity as Entities.Point);
					break;
			}
		}
	}
}
