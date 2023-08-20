using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.Tents
{
    public class TentBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
