using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class TrekkingPoleDto : GearDto {
		public ColorDto Color { get; set; }
		public TrekkingPoleBrandDto TrekkingPoleBrand { get; set; }
		public TrekkingPoleTypeDto TrekkingPoleType { get; set; }
	}
}
