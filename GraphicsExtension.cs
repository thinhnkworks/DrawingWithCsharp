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
	}
}
