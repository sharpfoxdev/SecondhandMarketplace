namespace WebApi.ApiDtos.Listings.CreateListing {
	public class CreateElectronicsListingRequest : CreateCampingListingRequest {
		public Guid ElectronicsTypeId { get; set; }

	}
}
