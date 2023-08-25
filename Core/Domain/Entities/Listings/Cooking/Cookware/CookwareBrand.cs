using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Sea to summit, Esbit, ...
    /// </summary>
    public class CookwareBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
