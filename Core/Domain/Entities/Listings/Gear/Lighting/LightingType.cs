using Domain.Common;

namespace Domain.Entities.Listings.Gear.Lighting
{
    /// <summary>
    /// Headlamp, lamp, torch, ...
    /// </summary>
    public class LightingType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
