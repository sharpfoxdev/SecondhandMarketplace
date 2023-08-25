using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Cutlery, pot, pan, cup
    /// </summary>
    public class CookwareType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
