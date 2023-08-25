using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Rectangle, hexagon, ...
    /// </summary>
    public class TarpShape : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
