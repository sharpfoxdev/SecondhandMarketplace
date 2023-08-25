namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateStoveRequest : UpdateCampingListingRequest
    {
        public Guid StoveBrandId { get; set; }
        public Guid StoveFuelTypeId { get; set; }
    }
}
