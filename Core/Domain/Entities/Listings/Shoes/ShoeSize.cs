using Domain.Common;

namespace Domain.Entities.Listings.Shoes
{
    /// <summary>
    /// Shoe size, will probably use different sizing types (EU, US etc.), because
    /// the sizes are different for different manufacturers
    /// </summary>
    public class ShoeSize : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
