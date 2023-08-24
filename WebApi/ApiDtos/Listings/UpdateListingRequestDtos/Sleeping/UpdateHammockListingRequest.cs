namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateHammockListingRequest : UpdateCampingListingRequest
    {
        public Guid HammockBrandId { get; set; }
        public Guid ColorId { get; set; }
    }
}
