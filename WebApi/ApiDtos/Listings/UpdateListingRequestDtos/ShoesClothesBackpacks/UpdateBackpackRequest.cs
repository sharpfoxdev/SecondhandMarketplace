namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateBackpackRequest : UpdateCampingListingRequest
    {
        public Guid BackpackBrandId { get; set; }
        public Guid BackpackTypeId { get; set; }
        public Guid ColorId { get; set; }
        public float? Volume { get; set; }
    }
}
