using Domain.Entities;
using WebApi.ApiDtos.AttributeGroups;

namespace WebApi.ApiDtos.Categories {
	public class CategoryDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public CategoryDto? ParentCategory { get; set; }
		public List<CategoryDto> ChildrenCategories { get; set; }
		public List<AttributeGroupDto> AttributeGroups { get; set; }
	}
}
