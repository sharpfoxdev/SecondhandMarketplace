using Domain.Common;

namespace Domain.Entities.Listings
{

    /// <summary>
    /// DD-Hammocks, lesovik, ...
    /// </summary>
    public class HammockBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
