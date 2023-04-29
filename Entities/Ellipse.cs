using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public class Ellipse : EntityObject
	{
		private Vector3 center;
		private double majorAxis;
		private double minorAxis;
		private double rotation;
		private double startAngle;
		private double endAngle;
		private double thickness;

		public Ellipse() : this(Vector3.Zero, 1.0, 0.5) { }

		public Ellipse(Vector3 center, double majorAxis, double minorAxis) : base(EntityType.Ellipse)
		{
			this.Center = center;
			this.MajorAxis = majorAxis;
			this.MinorAxis = minorAxis;
			this.StartAngle = 0.0;
			this.EndAngle = 360.0;
			this.Rotation = 0.0;
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

		public double Rotation
		{
			get { return rotation; }
			set { rotation = value; }
		}


		public double MinorAxis
		{
			get { return minorAxis; }
			set { minorAxis = value; }
		}

		public double MajorAxis
		{
			get { return majorAxis; }
			set { majorAxis = value; }
		}

		public Vector3 Center
		{
			get { return center; }
			set { center = value; }
		}

		public override object Clone()
		{
			return new Ellipse
			{
				Center = center,
				MajorAxis = majorAxis,
				MinorAxis = minorAxis,
				Rotation = rotation,
				Thickness = thickness,
				StartAngle = startAngle,
				EndAngle = endAngle,
				// entity object properties
				IsVisible = this.IsVisible
			};
		}
		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
		{
			Vector3 c = this.center.CopyOrMove(fromPoint, toPoint);
			return new Ellipse
			{
				Center = c,
				MajorAxis = majorAxis,
				MinorAxis = minorAxis,
				Rotation = rotation,
				Thickness = thickness,
				StartAngle = startAngle,
				EndAngle = endAngle,
				IsVisible = this.IsVisible
			};
		}
	}
}
