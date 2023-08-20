using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.Hammocks
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
