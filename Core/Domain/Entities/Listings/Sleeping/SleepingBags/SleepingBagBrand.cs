using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.SleepingBags
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
