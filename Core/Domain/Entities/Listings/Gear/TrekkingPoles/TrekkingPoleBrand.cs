using Domain.Common;

namespace Domain.Entities.Listings.Gear.TrekkingPoles
{
    /// <summary>
    /// Black Diamond, Leki, ...
    /// </summary>
    public class TrekkingPoleBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
