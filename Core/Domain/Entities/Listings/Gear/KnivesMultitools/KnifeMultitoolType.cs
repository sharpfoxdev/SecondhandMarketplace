using Domain.Common;

namespace Domain.Entities.Listings.Gear.KnivesMultitools
{
    /// <summary>
    /// Knife, multitool, ...
    /// </summary>
    public class KnifeMultitoolType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
