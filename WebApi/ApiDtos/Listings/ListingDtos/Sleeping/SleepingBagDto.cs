using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class SleepingBagDto : SleepingDto {
		public ColorDto Color { get; set; }

		public SleepingBagZipSideDto SleepingBagZipSide { get; set; }

		public SleepingBagShapeDto SleepingBagShape { get; set; }

		public SleepingBagBrandDto SleepingBagBrand { get; set; }

		public SleepingBagInsulationTypeDto SleepingBagInsulationType { get; set; }

		public SleepingBagSeasonDto SleepingBagSeason { get; set; }

		public GenderDto Gender { get; set; }

		public int? ComfortTemperature { get; set; }
		public int? LimitTemperature { get; set; }
		public int? ExtremeTemperature { get; set; }
	}
}
