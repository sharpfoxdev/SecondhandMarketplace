namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateSleepingPadRequest : CreateCampingListingRequest {
		public Guid SleepingPadBrandId { get; set; }
		public Guid SleepingPadTypeId { get; set; }
		public Guid ColorId { get; set; }
	}
}
