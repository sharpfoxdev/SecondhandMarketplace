namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateBinocularsRequest : UpdateCampingListingRequest
    {
        public Guid BinocularsTypeId { get; set; }

    }
}
