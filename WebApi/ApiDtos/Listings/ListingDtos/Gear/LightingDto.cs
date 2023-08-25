using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class LightingDto : GearDto {
		public LightingBrandDto LightingBrand { get; set; }
		public LightingTypeDto LightingType { get; set; }
	}
}
