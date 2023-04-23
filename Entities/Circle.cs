using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public class Circle : EntityObject
	{
		private Vector3 vector3;
		private double radius;
		private double thickness;

		public Circle() : this(Vector3.Zero, 1.0) { }
		public Circle(Vector3 center, double radius) : base(EntityType.Circle)
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
			get { return vector3; }
			set { vector3 = value; }
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
	}
}
