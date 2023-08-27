using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	public class Category : IEntity {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid? ParentCategoryId { get; set; }
		public Category? ParentCategory { get; set; }
		public List<Category> ChildrenCategories { get; set; }
		public List<AttributeGroup> AttributeGroups { get; set; }
	}
}
