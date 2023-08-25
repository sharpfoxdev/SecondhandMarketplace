using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class CookwareDto : CookingDto {
		public CookwareBrandDto CookwareBrand { get; set; }
		public CookwareTypeDto CookwareType { get; set; }
		public CookwareMaterialDto CookwareMaterial { get; set; }
		public ColorDto Color { get; set; }
	}
}
