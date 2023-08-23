namespace WebApi.ApiDtos.Listings.CreateListing {
	public class CreateSleepAccessoryListingRequest : CreateCampingListingRequest {
		public Guid SleepAcessoryTypeId { get; set; }
	}
}
