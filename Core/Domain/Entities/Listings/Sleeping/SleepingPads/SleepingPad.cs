
namespace Domain.Entities.Listings
{
    public class SleepingPad : Sleeping
    {
        public SleepingPadBrand SleepingPadBrand { get; set; }
        public Guid SleepingPadBrandId { get; set; }
        public SleepingPadType SleepingPadType { get; set; }
        public Guid SleepingPadTypeId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            SleepingPadBrandId = ((SleepingPad)updatedListing).SleepingPadBrandId;
            SleepingPadTypeId = ((SleepingPad)updatedListing).SleepingPadTypeId;
            ColorId = ((SleepingPad)updatedListing).ColorId;
        }
    }
}
