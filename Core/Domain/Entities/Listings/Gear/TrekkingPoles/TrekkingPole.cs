
namespace Domain.Entities.Listings
{
    public class TrekkingPole : Gear
    {
        public Color Color { get; set; }
        public Guid ColorId { get; set; }
        public TrekkingPoleBrand TrekkingPoleBrand { get; set; }
        public Guid TrekkingPoleBrandId { get; set; }
        public TrekkingPoleType TrekkingPoleType { get; set; }
        public Guid TrekkingPoleTypeId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            ColorId = ((TrekkingPole)updatedListing).ColorId;
            TrekkingPoleBrandId = ((TrekkingPole)updatedListing).TrekkingPoleBrandId;
            TrekkingPoleTypeId = ((TrekkingPole)updatedListing).TrekkingPoleTypeId;
        }
    }
}
