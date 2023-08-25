﻿
namespace Domain.Entities.Listings
{
    public class KnifeMultitool : Gear
    {
        public KnifeMultitoolBrand KnifeMultitoolBrand { get; set; }
        public Guid KnifeMultitoolBrandId { get; set; }
        public KnifeMultitoolType KnifeMultitoolType { get; set; }
        public Guid KnifeMultitoolTypeId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            KnifeMultitoolBrandId = ((KnifeMultitool)updatedListing).KnifeMultitoolBrandId;
            KnifeMultitoolTypeId = ((KnifeMultitool)updatedListing).KnifeMultitoolTypeId;
            ColorId = ((KnifeMultitool)updatedListing).ColorId;
        }
    }
}
