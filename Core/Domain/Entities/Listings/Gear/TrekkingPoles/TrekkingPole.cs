using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Gear.TrekkingPoles
{
    public class TrekkingPole : Gear
    {
        public Color Color { get; set; }
        public Guid ColorId { get; set; }
        public TrekkingPoleBrand TrekkingPoleBrand { get; set; }
        public Guid TrekkingPoleBrandId { get; set; }
        public TrekkingPoleType TrekkingPoleType { get; set; }
        public Guid TrekkingPoleTypeId { get; set; }
    }
}
