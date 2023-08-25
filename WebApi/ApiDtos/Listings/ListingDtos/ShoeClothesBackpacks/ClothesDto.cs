using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class ClothesDto : CampingListingDto {
		public ClothesSizeDto ClothesSize { get; set; }

		public ClothesBrandDto ClothesBrand { get; set; }

		public ColorDto Color { get; set; }

		public GenderDto Gender { get; set; }

		public ClothesTypeDto ClothesType { get; set; }
	}
}
