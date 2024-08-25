using WebApi.ApiDtos.ListingPropertyValues;

namespace WebApi.ApiDtos.ListingProperties {
	public class CreateListingPropertyRequest {
		public string Name { get; set; }
		public List<CreatePropertyValueInsidePropertyRequest> Attributes { get; set; }
	}
}
