using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public class Point : EntityObject
	{
		private Vector3 vector3;
		private double thickness;
		public Point() : this(Vector3.Zero)
		{
		}
		public Point(Vector3 position) : base(EntityType.Point)
		{
			this.Position = position;
			this.Thickness = 0.0;
		}
		public double Thickness
		{
			get { return thickness; }
			set { thickness = value; }
		}

		public Vector3 Position
		{
			get { return vector3; }
			set { vector3 = value; }
		}

		public override object Clone()
		{
			return new Entities.Point
			{
				Position = this.Position,
				Thickness = this.Thickness,
				// entity object properties
				IsVisible = this.IsVisible
			};
		}
	}
}
