namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateElectronicsListingRequest : UpdateCampingListingRequest
    {
        public Guid ElectronicsTypeId { get; set; }

    }
}
