using Domain.Entities;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.Listings;

namespace WebApi.ApiDtos.Categories {
	public class CategoryDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
    public class CategoryDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ListingPropertyDetailDto> ListingProperties { get; set; }
    }
    public class CategoryHierarchyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryDto? ParentCategory { get; set; }
        public List<CategoryHierarchyDto> ChildrenCategories { get; set; }
    }
}
