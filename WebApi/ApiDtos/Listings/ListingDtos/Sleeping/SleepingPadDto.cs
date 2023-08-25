using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class SleepingPadDto : SleepingDto {
		public SleepingPadBrandDto SleepingPadBrand { get; set; }
		public SleepingPadTypeDto SleepingPadType { get; set; }
		public ColorDto Color { get; set; }
	}
}
