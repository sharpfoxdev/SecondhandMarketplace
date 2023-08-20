namespace Domain.Entities.Listings.Gear.Lighting
{
    public class Lighting : Gear
    {
        public LightingBrand LightingBrand { get; set; }
        public Guid LightingBrandId { get; set; }
        public LightingType LightingType { get; set; }
        public Guid LightingTypeId { get; set; }
    }
}
