using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Season of usage - summer, winter, etc.
    /// 
    /// Column for czech localisation
    /// </summary>
    public class SleepingBagSeason : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
