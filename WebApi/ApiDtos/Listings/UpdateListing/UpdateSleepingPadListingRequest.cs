namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateSleepingPadListingRequest : UpdateCampingListingRequest
    {
        public Guid SleepingPadBrandId { get; set; }
        public Guid SleepingPadTypeId { get; set; }
        public Guid ColorId { get; set; }
    }
}
