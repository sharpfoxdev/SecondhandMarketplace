using Domain.Common;

namespace Domain.Entities.Listings
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
