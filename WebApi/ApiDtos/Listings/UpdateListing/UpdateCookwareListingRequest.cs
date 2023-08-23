namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateCookwareListingRequest : UpdateCampingListingRequest
    {
        public Guid CookwareBrandId { get; set; }
        public Guid CookwareTypeId { get; set; }
        public Guid CookwareMaterialId { get; set; }
        public Guid ColorId { get; set; }
    }
}
