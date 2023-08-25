namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateBinocularsRequest : CreateCampingListingRequest {
		public Guid BinocularsTypeId { get; set; }

	}
}
