namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateElectronicsRequest : CreateCampingListingRequest {
		public Guid ElectronicsTypeId { get; set; }

	}
}
