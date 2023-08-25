namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateHammockRequest : UpdateCampingListingRequest
    {
        public Guid HammockBrandId { get; set; }
        public Guid ColorId { get; set; }
    }
}
