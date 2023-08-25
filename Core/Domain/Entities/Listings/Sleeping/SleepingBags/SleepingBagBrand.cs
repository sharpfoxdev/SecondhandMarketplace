using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Brands of sleeping bags, Husky, Warmpeace, ...
    /// </summary>
    public class SleepingBagBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
