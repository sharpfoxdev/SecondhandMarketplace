using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class CampingListingDto {
		public Guid Id { get; set; }
		public decimal Price { get; set; }
		public Guid SellerId { get; set; }
		public string Title { get; set; }
		public StateOfItemDto StateOfItem { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public bool IsSold { get; set; }
		public string ListingImageUrl { get; set; }
		public bool Ultralight { get; set; }
		public float? Weight { get; set; }
	}
}
