namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateLightingListingRequest : UpdateCampingListingRequest
    {
        public Guid LightingBrandId { get; set; }
        public Guid LightingTypeId { get; set; }
    }
}
