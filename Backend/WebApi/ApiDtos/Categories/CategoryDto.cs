using Domain.Entities;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.Listings;

namespace WebApi.ApiDtos.Categories {
	public class CategoryDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public CategoryDto? ParentCategory { get; set; }
		public List<CategoryDto> ChildrenCategories { get; set; }
		public List<ListingPropertyDto> ListingProperties { get; set; }
		public List<ListingDto> Listings { get; set; }
	}
}
