namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateBinocularsListingRequest : CreateCampingListingRequest {
		public Guid BinocularsTypeId { get; set; }

	}
}
