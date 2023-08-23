namespace WebApi.ApiDtos.Listings.CreateListing {
	public class CreateCookwareListingRequest : CreateCampingListingRequest {
		public Guid CookwareBrandId { get; set; }
		public Guid CookwareTypeId { get; set; }
		public Guid CookwareMaterialId { get; set; }
		public Guid ColorId { get; set; }
	}
}
