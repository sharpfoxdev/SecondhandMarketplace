using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class StoveDto : CookingDto {
		public StoveBrandDto StoveBrand { get; set; }
		public StoveFuelTypeDto StoveFuelType { get; set; }
	}
}
