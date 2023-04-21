﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_
{
	public class Vector2
	{
		private double x;
		private double y;

		public Vector2(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector2 Zero
		{
			get { return new Vector2(0.0, 0.0); }
		}

		public double Y
		{
			get { return y; }
			set { y = value; }
		}

		public double X
		{
			get { return x; }
			set { x = value; }
		}

		public double DistanceFrom(Vector2 v)
		{
			double dx = v.X - X;
			double dy = v.Y - Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}
	}
}
