namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateShoeListingRequest : CreateCampingListingRequest {
		public Guid ShoeBrandId { get; set; }
		public Guid ShoeTypeId { get; set; }
		public Guid ShoeSizeId { get; set; }
		public Guid ColorId { get; set; }
		public Guid GenderId { get; set; }
	}
}
