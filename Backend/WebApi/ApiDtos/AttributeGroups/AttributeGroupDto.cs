using Domain.Entities;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.ListingAttribute;

namespace WebApi.ApiDtos.AttributeGroups {
	public class AttributeGroupDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<CategoryDto> Categories { get; set; }
		public List<ListingAttributeDto> Attributes { get; set; }
	}
}
