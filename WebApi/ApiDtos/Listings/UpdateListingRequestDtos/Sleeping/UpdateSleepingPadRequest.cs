namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateSleepingPadRequest : UpdateCampingListingRequest
    {
        public Guid SleepingPadBrandId { get; set; }
        public Guid SleepingPadTypeId { get; set; }
        public Guid ColorId { get; set; }
    }
}
