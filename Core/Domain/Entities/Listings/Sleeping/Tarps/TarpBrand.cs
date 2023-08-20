using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.Tarps
{
    public class TarpBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
