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

		public Point() : this(Vector3.Zero, new Pen(Color.Black, 1.0f))
		{
		}
		public Point(Vector3 position, Pen pen) : base(EntityType.Point, pen)
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
				IsVisible = this.IsVisible,
				Pen = this.Pen
			};
		}
		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
		{
			Vector3 p = this.Position.CopyOrMove(fromPoint, toPoint);
			return new Point
			{
				Position = p,
				Thickness = this.Thickness,
				IsVisible = this.IsVisible,
				Pen = this.Pen
			};
		}
	}
}
