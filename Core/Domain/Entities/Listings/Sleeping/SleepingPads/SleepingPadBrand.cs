using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.SleepingPads
{
    public class SleepingPadBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
