using Domain.Common;

namespace Domain.Entities.Listings
{
    public class TentBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
