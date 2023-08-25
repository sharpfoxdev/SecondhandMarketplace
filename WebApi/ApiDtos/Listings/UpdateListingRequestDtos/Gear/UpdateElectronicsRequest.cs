namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateElectronicsRequest : UpdateCampingListingRequest
    {
        public Guid ElectronicsTypeId { get; set; }

    }
}
