namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateTarpRequest : CreateCampingListingRequest {
		public Guid TarpBrandId { get; set; }
		public Guid ColorId { get; set; }
		public Guid TarpShapeId { get; set; }
		public float? SizeXMetres { get; set; }
		public float? SizeYMetres { get; set; }
	}
}
