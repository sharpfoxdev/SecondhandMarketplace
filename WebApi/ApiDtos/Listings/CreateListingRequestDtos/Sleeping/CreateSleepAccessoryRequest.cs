namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateSleepAccessoryRequest : CreateCampingListingRequest {
		public Guid SleepAcessoryTypeId { get; set; }
	}
}
