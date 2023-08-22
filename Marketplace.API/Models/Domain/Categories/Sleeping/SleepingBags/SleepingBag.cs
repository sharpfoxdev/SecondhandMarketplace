﻿using Marketplace.API.Models.Domain.Categories.CommonProperties;

namespace Marketplace.API.Models.Domain.Categories.Sleeping.SleepingBags
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
    }
}