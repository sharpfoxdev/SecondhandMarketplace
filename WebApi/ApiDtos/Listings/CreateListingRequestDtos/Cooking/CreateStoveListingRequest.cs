namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateStoveListingRequest : CreateCampingListingRequest {
		public Guid StoveBrandId { get; set; }
		public Guid StoveFuelTypeId { get; set; }
	}
}
