using Domain.Common;

namespace Domain.Entities.Listings.Shoes
{
    /// <summary>
    /// Shoe type - high, mid, low, sandals, running, ...
    /// 
    /// Just the czech mutation for now. 
    /// 
    /// Used instead making children further from Shoe.cs category, as there wouldn't
    /// be any new properties.
    /// </summary>
    public class ShoeType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
