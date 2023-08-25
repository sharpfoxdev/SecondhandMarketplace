using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class ShoeDto : CampingListingDto {
		public ShoeBrandDto ShoeBrand { get; set; }
		public ShoeTypeDto ShoeType { get; set; }
		public ShoeSizeDto ShoeSize { get; set; }
		public ColorDto Color { get; set; }
		public GenderDto Gender { get; set; }
	}
}
