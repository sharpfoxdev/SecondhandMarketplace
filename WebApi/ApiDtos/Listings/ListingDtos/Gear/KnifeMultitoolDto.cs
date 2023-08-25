using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class KnifeMultitoolDto : GearDto {
		public KnifeMultitoolBrandDto KnifeMultitoolBrand { get; set; }
		public KnifeMultitoolTypeDto KnifeMultitoolType { get; set; }
		public ColorDto Color { get; set; }
	}
}
