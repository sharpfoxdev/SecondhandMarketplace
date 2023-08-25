namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateStoveRequest : CreateCampingListingRequest {
		public Guid StoveBrandId { get; set; }
		public Guid StoveFuelTypeId { get; set; }
	}
}
