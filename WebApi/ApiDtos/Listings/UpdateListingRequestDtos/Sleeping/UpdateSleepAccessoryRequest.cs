namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateSleepAccessoryRequest : UpdateCampingListingRequest
    {
        public Guid SleepAcessoryTypeId { get; set; }
    }
}
