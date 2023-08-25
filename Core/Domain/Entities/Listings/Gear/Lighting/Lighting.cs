namespace Domain.Entities.Listings
{
    public class Lighting : Gear
    {
        public LightingBrand LightingBrand { get; set; }
        public Guid LightingBrandId { get; set; }
        public LightingType LightingType { get; set; }
        public Guid LightingTypeId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            LightingBrandId = ((Lighting)updatedListing).LightingBrandId;
            LightingTypeId = ((Lighting)updatedListing).LightingTypeId;
        }
    }
}
