using Domain.Common;

namespace Domain.Entities.Listings.Shoes
{
    /// <summary>
    /// Shoe brand - Nike, Adidas, etc.
    /// </summary>
    public class ShoeBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
