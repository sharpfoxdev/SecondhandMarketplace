namespace WebApi.ApiDtos.Listings.CreateListing {
	public class CreateHammockListingRequest : CreateCampingListingRequest {
		public Guid HammockBrandId { get; set; }
		public Guid ColorId { get; set; }
	}
}
