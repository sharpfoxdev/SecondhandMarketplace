using Domain.Common;

namespace Domain.Entities.Listings.Sleeping.SleepingPads
{
    /// <summary>
    /// Foam, inflatable, alupad, pillow...
    /// </summary>
    public class SleepingPadType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
