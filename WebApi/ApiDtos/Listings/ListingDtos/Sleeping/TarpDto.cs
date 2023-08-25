using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class TarpDto : SleepingDto {
		public TarpBrandDto TarpBrand { get; set; }
		public ColorDto Color { get; set; }
		public TarpShapeDto TarpShape { get; set; }
		public float? SizeXMetres { get; set; }
		public float? SizeYMetres { get; set; }

	}
}
