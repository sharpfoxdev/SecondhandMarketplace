using Domain.Common;

namespace Domain.Entities.Listings.Gear.KnivesMultitools
{
    public class KnifeMultitoolBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
