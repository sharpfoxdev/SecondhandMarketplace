namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateHammockRequest : CreateCampingListingRequest {
		public Guid HammockBrandId { get; set; }
		public Guid ColorId { get; set; }
	}
}
