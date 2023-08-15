namespace Marketplace.API.Models.Domain {
	public class SleepingBag {
		public Color Color { get; set; }
		public Guid ColorId { get; set; }

		public SleepingBagZipSide SleepingBagZipSide { get; set; }
		public Guid SleepingBagZipSideId { get; set; }

		public SleepingBagShape SleepingBagShape { get; set; }
		public Guid SleepingBagShapeId { get; set; }

		public SleepingBagBrand SleepingBagBrand { get; set; }
		public Guid SleepingBagBrandId { get; set; }

		public SleepingBagInsulationType SleepingBagInsulationType { get; set; }
		public Guid SleepingBagInsulationTypeId { get; set; }

		public SleepingBagSeason SleepingBagSeason { get; set; }
		public Guid SleepingBagSeasonId { get; set; }

		public Gender Gender { get; set; }
		public Guid GenderId { get; set; }

		public int? ComfortTemperature { get; set; }
		public int? LimitTemperature { get; set; }
		public int? ExtremeTemperature { get; set; }
	}
}
