namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateTentRequest : CreateCampingListingRequest {
		public int NumberOfPeople { get; set; }
		public int NumberOfDoors { get; set; }
		public Guid TentBrandId { get; set; }
	}
}
