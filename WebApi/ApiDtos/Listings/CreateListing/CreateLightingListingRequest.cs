namespace WebApi.ApiDtos.Listings.CreateListing {
	public class CreateLightingListingRequest : CreateCampingListingRequest {
		public Guid LightingBrandId { get; set; }
		public Guid LightingTypeId { get; set; }
	}
}
