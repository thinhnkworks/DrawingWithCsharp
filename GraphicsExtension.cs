﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_
{
	public static class GraphicsExtension
	{
		private static float Height;

		public static void SetParameters(this Graphics g, float height)
		{
			Height = height;
		}

		public static void SetTransform(this Graphics g)
		{
			g.PageUnit = GraphicsUnit.Millimeter;
			g.TranslateTransform(0, Height);
			g.ScaleTransform(1.0f, -1.0f);
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
			g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
			g.ResetTransform();
		}
		public static void DrawCircle(this Graphics g, Pen pen, Entities.Circle circle)
		{
			float x = (float)(circle.Center.X - circle.Radius);
			float y = (float)(circle.Center.Y - circle.Radius);
			float d = (float)(circle.Diameter);

			g.SetTransform();
			g.DrawEllipse(pen, x, y, d, d);
			g.ResetTransform();
		}
		public static void DrawEllipse(this Graphics g, Pen pen, Entities.Ellipse ellipse)
		{
			SetTransform(g);
			g.TranslateTransform(ellipse.Center.ToPointF.X, ellipse.Center.ToPointF.Y);
			g.RotateTransform((float)(ellipse.Rotation));
			g.DrawEllipse(pen, -(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
			g.ResetTransform();
		}
		public static void DrawArc(this Graphics g, Pen pen, Entities.Arc arc)
		{
			float x = (float)(arc.Center.X - arc.Radius);
			float y = (float)(arc.Center.Y - arc.Radius);
			float d = (float)(arc.Diameter);

			System.Drawing.RectangleF rect = new System.Drawing.RectangleF(x, y, d, d);

			g.SetTransform();
			g.DrawArc(pen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
			g.ResetTransform();
		}
	}
}
