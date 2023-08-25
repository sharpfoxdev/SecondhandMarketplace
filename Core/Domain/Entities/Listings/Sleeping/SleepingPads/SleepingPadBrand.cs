using Domain.Common;

namespace Domain.Entities.Listings
{
    public class SleepingPadBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
