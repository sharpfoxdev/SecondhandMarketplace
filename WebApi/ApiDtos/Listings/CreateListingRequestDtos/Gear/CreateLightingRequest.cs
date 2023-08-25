namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateLightingRequest : CreateCampingListingRequest {
		public Guid LightingBrandId { get; set; }
		public Guid LightingTypeId { get; set; }
	}
}
