using Domain.Common;

namespace Domain.Entities.Listings.Clothes
{
    /// <summary>
    /// Brand of clothes - nike, adidas, ...
    /// </summary>
    public class ClothesBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
