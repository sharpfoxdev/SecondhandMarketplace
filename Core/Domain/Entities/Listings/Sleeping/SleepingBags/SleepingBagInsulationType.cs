using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Type of insulation, down, syntetic
    /// </summary>
    public class SleepingBagInsulationType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
