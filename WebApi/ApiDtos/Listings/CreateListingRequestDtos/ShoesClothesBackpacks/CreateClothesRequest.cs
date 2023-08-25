namespace WebApi.ApiDtos.Listings.CreateListing
{
    public class CreateClothesRequest : CreateCampingListingRequest {
		public Guid ClothesSizeId { get; set; }
		public Guid ClothesBrandId { get; set; }
		public Guid ColorId { get; set; }
		public Guid GenderId { get; set; }
		public Guid ClothesTypeId { get; set; }
	}
}
