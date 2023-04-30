using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public class LwPolylineVertex : ICloneable
	{
		private Vector2 position;
		private double bulge;
		protected Pen pen;

		public LwPolylineVertex() : this(Vector2.Zero, 0.0, new Pen(Color.Black, 1.0f)) { }

		public LwPolylineVertex(Vector2 position, Pen pen) : this(position, 0.0, pen) { }

		public LwPolylineVertex(Vector2 position, double bulge, Pen pen)
		{
			this.position = position;
			this.bulge = bulge;
			this.pen = pen;
		}

		public LwPolylineVertex(double x, double y) : this(new Vector2(x, y), 0.0, new Pen(Color.Black, 1.0f)) { }

		public double Bulge
		{
			get { return bulge; }
			set { bulge = value; }
		}

		public Vector2 Position
		{
			get { return position; }
			set { position = value; }
		}

		public Pen Pen
		{
			get { return pen; }
			set { pen = value; }
		}

		public object Clone()
		{
			return new LwPolylineVertex
			{
				Position = this.position,
				Bulge = this.bulge,
				Pen = this.pen
			};
		}
	}
}
