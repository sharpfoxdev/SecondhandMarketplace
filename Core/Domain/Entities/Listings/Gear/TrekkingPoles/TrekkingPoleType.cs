using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Trekking, nordic walking
    /// </summary>
    public class TrekkingPoleType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
