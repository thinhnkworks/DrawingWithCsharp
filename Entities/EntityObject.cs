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
		protected bool selected;

		public EntityObject(EntityType type)
		{
			this.type = type;
			this.isVisible = true;
			this.selected = false;
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
		public bool Selected
		{
			get { return this.selected; }
		}
		public void Select()
		{
			this.selected = true;
		}
		public void DeSelect()
		{
			this.selected = false;
		}
		public abstract object Clone();
	}
}
