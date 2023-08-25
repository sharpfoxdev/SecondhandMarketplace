using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class BackpackDto : CampingListingDto {
		public BackpackBrandDto BackpackBrand { get; set; }
		public BackpackTypeDto BackpackType { get; set; }
		public ColorDto Color { get; set; }
		public float? Volume { get; set; }
	}
}
