namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateTrekkingPoleListingRequest : UpdateCampingListingRequest
    {
        public Guid ColorId { get; set; }
        public Guid TrekkingPoleBrandId { get; set; }
        public Guid TrekkingPoleTypeId { get; set; }
    }
}
