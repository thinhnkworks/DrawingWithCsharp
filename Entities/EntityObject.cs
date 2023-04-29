using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingWithC_.Entities
{
	public abstract class EntityObject : ICloneable
	{
		private readonly EntityType type;
		protected bool isVisible;
		protected bool isSelected;

		public EntityObject(EntityType type)
		{
			this.type = type;
			this.isVisible = true;
			this.isSelected = false;
		}

		public EntityType Type
		{
			get { return this.type; }
		}

		public bool IsVisible
		{
			get { return this.isVisible; }
			set { this.isVisible = value; }
		}
		public bool IsSelected
		{
			get { return this.isSelected; }
		}
		public void Select()
		{
			this.isSelected = true;
		}
		public void DeSelect()
		{
			this.isSelected = false;
		}
		public abstract object CopyOrMove(Vector3 fromPoint, Vector3 toPoint);
		public abstract object Clone();
	}
}
