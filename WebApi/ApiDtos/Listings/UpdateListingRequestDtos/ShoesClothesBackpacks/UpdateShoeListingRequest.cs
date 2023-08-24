namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateShoeListingRequest : UpdateCampingListingRequest
    {
        public Guid ShoeBrandId { get; set; }
        public Guid ShoeTypeId { get; set; }
        public Guid ShoeSizeId { get; set; }
        public Guid ColorId { get; set; }
        public Guid GenderId { get; set; }
    }
}
