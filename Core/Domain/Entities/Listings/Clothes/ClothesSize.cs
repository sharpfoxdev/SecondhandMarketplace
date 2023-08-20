using Domain.Common;

namespace Domain.Entities.Listings.Clothes
{
    /// <summary>
    /// Different clothes sizes - S, M, L, XL, ...
    /// </summary>
    public class ClothesSize : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
