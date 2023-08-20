using Domain.Common;

namespace Domain.Entities.Listings.Gear.Binoculars
{
    /// <summary>
    /// Monoculars, binoculars
    /// </summary>
    public class BinocularsType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
