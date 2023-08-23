namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateKnifeMultitoolListingRequest : CreateCampingListingRequest {
		public Guid KnifeMultitoolBrandId { get; set; }
		public Guid KnifeMultitoolTypeId { get; set; }
		public Guid ColorId { get; set; }
	}
}
