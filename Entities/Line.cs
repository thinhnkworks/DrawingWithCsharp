using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public class Line : EntityObject
	{
		private Vector3 startPoint;
		private Vector3 endPoint;
		private double thickness;

		public double Thickness
		{
			get { return thickness; }
			set { thickness = value; }
		}
		public Line() : this(Vector3.Zero, Vector3.Zero, new Pen(Color.Black, 1.0f))
		{
		}
		public Line(Vector3 start, Vector3 end, Pen pen) : base(EntityType.Line, pen)
		{
			this.StartPoint = start;
			this.EndPoint = end;
			this.Thickness = 0.0;
		}
		public Vector3 EndPoint
		{
			get { return endPoint; }
			set { endPoint = value; }
		}

		public Vector3 StartPoint
		{
			get { return startPoint; }
			set { startPoint = value; }
		}

		public double Length
		{
			get
			{
				double dx = endPoint.X - startPoint.X;
				double dy = endPoint.Y - startPoint.Y;
				double dz = endPoint.Z - startPoint.Z;

				return Math.Sqrt(dx * dx + dy * dy + dz * dz);
			}
		}

		public double Angle
		{
			get
			{
				double angle = Math.Atan2((endPoint.Y - startPoint.Y), (endPoint.X - startPoint.X)) * 180.0 / Math.PI;
				if (angle < 0)
				{
					angle += 360.0;
				}
				return angle;
			}
		}

		public override object Clone()
		{
			return new Line
			{
				StartPoint = this.StartPoint,
				EndPoint = this.EndPoint,
				Thickness = this.Thickness,
				// entity object properties
				IsVisible = this.IsVisible,
				Pen = this.Pen
			};
		}
		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
		{
			Vector3 startPoint = this.startPoint.CopyOrMove(fromPoint, toPoint);
			Vector3 endPoint = this.endPoint.CopyOrMove(fromPoint, toPoint);
			return new Line
			{
				StartPoint = startPoint,
				EndPoint = endPoint,
				Thickness = this.Thickness,
				IsVisible = this.IsVisible,
				Pen = this.Pen
			};
		}
	}
}
