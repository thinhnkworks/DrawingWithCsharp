using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public class Circle : EntityObject
	{
		private Vector3 center;
		private double radius;
		private double thickness;

		public Circle() : this(Vector3.Zero, 1.0, new Pen(Color.Black, 1.0f)) { }
		public Circle(Vector3 center, double radius, Pen pen) : base(EntityType.Circle, pen)
		{
			this.Center = center;
			this.Radius = radius;
			this.Thickness = 0.0;
		}

		public double Thickness
		{
			get { return thickness; }
			set { thickness = value; }
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

		public double Diameter
		{
			get { return this.Radius * 2.0; }
		}

		public override object Clone()
		{
			return new Circle
			{
				Center = this.Center,
				Radius = this.Radius,
				Thickness = this.Thickness,
				// entity object properties
				IsVisible = this.IsVisible,
			};
		}
		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
		{
			Vector3 c = this.center.CopyOrMove(fromPoint, toPoint);
			return new Circle
			{
				Center = c,
				Radius = this.Radius,
				Thickness = this.Thickness,
				IsVisible = this.IsVisible,
				Pen = this.Pen,
			};

		}
	}
}
