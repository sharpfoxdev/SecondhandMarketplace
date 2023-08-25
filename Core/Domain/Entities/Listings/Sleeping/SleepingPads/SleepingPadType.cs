using Domain.Common;

namespace Domain.Entities.Listings
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
