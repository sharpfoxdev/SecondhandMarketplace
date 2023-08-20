using Domain.Common;

namespace Domain.Entities.Listings.Gear.TrekkingPoles
{
    /// <summary>
    /// Trekking, nordic walking
    /// </summary>
    public class TrekkingPoleType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
