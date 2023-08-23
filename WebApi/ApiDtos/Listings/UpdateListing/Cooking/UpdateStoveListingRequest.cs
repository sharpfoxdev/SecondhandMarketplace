namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateStoveListingRequest : UpdateCampingListingRequest
    {
        public Guid StoveBrandId { get; set; }
        public Guid StoveFuelTypeId { get; set; }
    }
}
