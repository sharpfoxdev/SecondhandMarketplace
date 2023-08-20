using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Gear.KnivesMultitools
{
    public class KnifeMultitool : Gear
    {
        public KnifeMultitoolBrand KnifeMultitoolBrand { get; set; }
        public Guid KnifeMultitoolBrandId { get; set; }
        public KnifeMultitoolType KnifeMultitoolType { get; set; }
        public Guid KnifeMultitoolTypeId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }
    }
}
