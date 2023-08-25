using Domain.Common;

namespace Domain.Entities.Listings
{
    /// <summary>
    /// Pillow, ground sheet, stakes, cordage, ... 
    /// </summary>
    public class SleepAccessoryType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
