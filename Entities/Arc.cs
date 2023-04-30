using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public class Arc : EntityObject
	{
		private Vector3 center;
		private double radius;
		private double startAngle;
		private double endAngle;
		private double thickness;

		public Arc() : this(Vector3.Zero, 1.0, 0.0, 180.0, new Pen(Color.Black, 1.0f)) { }
		public Arc(Vector3 center, double radius, double startAngle, double endAngle, Pen pen) : base(EntityType.Arc, pen)
		{
			this.Center = center;
			this.Radius = radius;
			this.StartAngle = startAngle;
			this.EndAngle = endAngle;
			this.Thickness = 0.0;
		}

		public double Thickness
		{
			get { return thickness; }
			set { thickness = value; }
		}

		public double EndAngle
		{
			get { return endAngle; }
			set { endAngle = value; }
		}

		public double StartAngle
		{
			get { return startAngle; }
			set { startAngle = value; }
		}

		public double Radius
		{
			get { return radius; }
			set { radius = value; }
		}

		public Vector3 Center
		{
			get { return center; }
			set { center = value; }
		}

		public Vector3 StartPoint
		{
			get
			{
				double x = radius * Math.Cos(startAngle * Methods.Method.DegToRad);
				double y = radius * Math.Sin(startAngle * Methods.Method.DegToRad);
				return new Vector3(center.X + x, center.Y + y);
			}
		}
		public Vector3 EndPoint
		{
			get
			{
				double x = radius * Math.Cos((startAngle + endAngle) * Methods.Method.DegToRad);
				double y = radius * Math.Sin((startAngle + endAngle) * Methods.Method.DegToRad);
				return new Vector3(center.X + x, center.Y + y);
			}
		}

		public double Diameter
		{
			get { return this.Radius * 2; }
		}

		public override object Clone()
		{
			return new Arc
			{
				Center = this.Center,
				Radius = this.Radius,
				StartAngle = this.StartAngle,
				EndAngle = this.EndAngle,
				Thickness = this.Thickness,
				// entity object properties
				IsVisible = this.IsVisible,
				Pen = this.Pen
			};
		}
		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
		{
			Vector3 c = this.center.CopyOrMove(fromPoint, toPoint);
			return new Arc
			{
				Center = c,
				Radius = this.Radius,
				StartAngle = this.StartAngle,
				EndAngle = this.EndAngle,
				Thickness = this.Thickness,
				IsVisible = this.IsVisible,
				Pen = this.Pen
			};
		}
	}
}
