namespace WebApi.ApiDtos.Listings.UpdateListing
{
    public class UpdateTentRequest : UpdateCampingListingRequest
    {
        public int NumberOfPeople { get; set; }
        public int NumberOfDoors { get; set; }
        public Guid TentBrandId { get; set; }
    }
}
