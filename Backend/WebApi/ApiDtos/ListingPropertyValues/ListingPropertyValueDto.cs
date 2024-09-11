using Domain.Entities;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.Listings;

namespace WebApi.ApiDtos.ListingPropertyValues {
	public class ListingPropertyValueDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ListingPropertyDto ListingProperty { get; set; }
		public List<ListingDto> Listings { get; set; }
	}
}
