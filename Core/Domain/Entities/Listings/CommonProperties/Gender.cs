using Domain.Common;

namespace Domain.Entities.Listings.CommonProperties
{

    /// <summary>
    /// Male, female, unisex, kids, currently just the czech mutation. 
    /// 
    /// TODO Beware of filtering
    /// </summary>
    public class Gender : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
