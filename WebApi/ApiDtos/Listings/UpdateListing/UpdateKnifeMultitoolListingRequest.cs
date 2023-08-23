namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateKnifeMultitoolListingRequest : UpdateCampingListingRequest
    {
        public Guid KnifeMultitoolBrandId { get; set; }
        public Guid KnifeMultitoolTypeId { get; set; }
        public Guid ColorId { get; set; }
    }
}
