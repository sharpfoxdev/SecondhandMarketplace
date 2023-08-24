namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateBinocularsListingRequest : UpdateCampingListingRequest
    {
        public Guid BinocularsTypeId { get; set; }

    }
}
