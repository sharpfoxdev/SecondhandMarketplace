namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateTrekkingPoleRequest : CreateCampingListingRequest {
		public Guid ColorId { get; set; }
		public Guid TrekkingPoleBrandId { get; set; }
		public Guid TrekkingPoleTypeId { get; set; }
	}
}
