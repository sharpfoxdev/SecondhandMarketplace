using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Sleeping.SleepingPads
{
    public class SleepingPad : Sleeping
    {
        public SleepingPadBrand SleepingPadBrand { get; set; }
        public Guid SleepingPadBrandId { get; set; }
        public SleepingPadType SleepingPadType { get; set; }
        public Guid SleepingPadTypeId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }
    }
}
