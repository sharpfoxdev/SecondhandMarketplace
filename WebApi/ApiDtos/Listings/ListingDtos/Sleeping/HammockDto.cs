using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class HammockDto : SleepingDto {
		public HammockBrandDto HammockBrand { get; set; }
		public ColorDto Color { get; set; }
	}
}
