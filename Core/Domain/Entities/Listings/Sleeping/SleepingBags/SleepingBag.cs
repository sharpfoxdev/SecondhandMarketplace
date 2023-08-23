using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Sleeping.SleepingBags
{
    public class SleepingBag : Sleeping
    {
        // green, blue, red, etc.
        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        // left, right, both
        public SleepingBagZipSide SleepingBagZipSide { get; set; }
        public Guid SleepingBagZipSideId { get; set; }

        // mummy, rectangular, etc.
        public SleepingBagShape SleepingBagShape { get; set; }
        public Guid SleepingBagShapeId { get; set; }

        // brand - Husky, Warmpeace, ...
        public SleepingBagBrand SleepingBagBrand { get; set; }
        public Guid SleepingBagBrandId { get; set; }

        // down, synthetic
        public SleepingBagInsulationType SleepingBagInsulationType { get; set; }
        public Guid SleepingBagInsulationTypeId { get; set; }

        // summer, three season, winter
        public SleepingBagSeason SleepingBagSeason { get; set; }
        public Guid SleepingBagSeasonId { get; set; }

        // TODO maybe not needed?
        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        // temperature rating
        public int? ComfortTemperature { get; set; }
        public int? LimitTemperature { get; set; }
        public int? ExtremeTemperature { get; set; }

		public override void Update(BaseListing updatedListing) {
			base.Update(updatedListing);
            ColorId = ((SleepingBag)updatedListing).ColorId;
            SleepingBagZipSideId = ((SleepingBag)updatedListing).SleepingBagZipSideId;
            SleepingBagShapeId = ((SleepingBag)updatedListing).SleepingBagZipSideId;
            SleepingBagBrandId = ((SleepingBag)updatedListing).SleepingBagBrandId;
            SleepingBagInsulationTypeId = ((SleepingBag)updatedListing).SleepingBagInsulationTypeId;
            SleepingBagSeasonId = ((SleepingBag)updatedListing).SleepingBagSeasonId;
            GenderId = ((SleepingBag)updatedListing).GenderId;
            ComfortTemperature = ((SleepingBag)updatedListing).ComfortTemperature;
            LimitTemperature = ((SleepingBag)updatedListing).LimitTemperature;
            ExtremeTemperature = ((SleepingBag)updatedListing).ExtremeTemperature;
		}
	}
}
