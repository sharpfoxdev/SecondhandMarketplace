namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateBackpackListingRequest : CreateCampingListingRequest {
		public Guid BackpackBrandId { get; set; }
		public Guid BackpackTypeId { get; set; }
		public Guid ColorId { get; set; }
		public float? Volume { get; set; }
	}
}
