namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateLightingRequest : UpdateCampingListingRequest
    {
        public Guid LightingBrandId { get; set; }
        public Guid LightingTypeId { get; set; }
    }
}
