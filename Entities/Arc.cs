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

		public Arc() : this(Vector3.Zero, 1.0, 0.0, 180.0) { }
		public Arc(Vector3 center, double radius, double startAngle, double endAngle) : base(EntityType.Arc)
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
			};
		}
	}
}
