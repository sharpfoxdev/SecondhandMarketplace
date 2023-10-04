using Domain.Entities;
using WebApi.ApiDtos.AttributeGroups;
using WebApi.ApiDtos.Listings;

namespace WebApi.ApiDtos.ListingAttribute {
	public class ListingAttributeDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public AttributeGroupDto AttributeGroup { get; set; }
		public List<ListingDto> Listings { get; set; }
	}
}
