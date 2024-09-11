namespace WebApi.ApiDtos.ListingPropertyValues {
	public class CreateListingPropertyValueRequest {
		public string Name { get; set; }
		public Guid ListingPropertyId { get; set; }
	}
}
