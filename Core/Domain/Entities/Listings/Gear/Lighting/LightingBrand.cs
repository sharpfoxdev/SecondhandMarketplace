using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Petzl, Fenix, ...
    /// </summary>
    public class LightingBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
