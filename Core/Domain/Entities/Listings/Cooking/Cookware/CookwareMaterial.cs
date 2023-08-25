using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Aluminum, cast iron, silicone, stainless steel, steel, titanium, plastic
    /// </summary>
    public class CookwareMaterial : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
