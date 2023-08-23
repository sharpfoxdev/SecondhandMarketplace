namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateSleepAccessoryListingRequest : UpdateCampingListingRequest
    {
        public Guid SleepAcessoryTypeId { get; set; }
    }
}
