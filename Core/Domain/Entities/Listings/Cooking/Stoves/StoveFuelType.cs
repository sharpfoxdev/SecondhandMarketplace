using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Gas cartridge, liquid fuel, wood, ...
    /// </summary>
    public class StoveFuelType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
