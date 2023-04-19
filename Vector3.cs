﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_
{
	public class Vector3
	{
		private double x;
		private double y;
		private double z;

		public Vector3(double x, double y)
		{
			this.X = x;
			this.Y = y;
			this.Z = 0.0;
		}

		public Vector3(double x, double y, double z) : this(x, y)
		{
			this.Z = z;
		}


		public double Z
		{
			get { return z; }
			set { z = value; }
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

		public PointF ToPointF
		{
			get { return new PointF((float)X, (float)Y); }
		}
		public static Vector3 Zero
		{
			get { return new Vector3(0.0, 0.0, 0.0); }
		}
		public double DistanceFrom(Vector3 v)
		{
			double dx = v.X - X;
			double dy = v.Y - Y;
			double dz = v.Z - Z;
			return Math.Sqrt(dx * dx + dy * dy + dz * dz);
		}
	}
}
